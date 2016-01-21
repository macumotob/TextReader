using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baybak.TextReader
{
  public partial class TextEditControl : UserControl
  {
    public delegate void EventWordSelected(string word);
    public event EventWordSelected OnWordSelected;


    string _file_name = @"E:\waswas\GEORGE WOODCOCK.txt";
    string _text;
    int _topLine = 0;
    int _firstVisibleIndex = 0;
    int _currentEditIndex;
    int _lines_per_page = 0;
    int _selectedLine = 0;
    float _lineHeight;
    int _mouse_x = 0, _mouse_y = 0;
    bool _word_is_selected = false;

    Font _font = new Font("Lucida Console", 12);

    List<string> _words = new List<string>();
    List<float> _widths = new List<float>();


    public TextEditControl()
    {
      InitializeComponent();
    }
    public void LoadFromFile(string file)
    {
      _file_name = file;
      this.Text = System.IO.File.ReadAllText(_file_name, Encoding.UTF8);//, Encoding.Unicode);
    }
    public string Text
    {
      get
      {
        return _text;
      }
      set
      {
        _text = value;
        this.Invalidate();
      }
    }

    StringFormat _StringFormat
    {
      get
      {
        return StringFormat.GenericTypographic;
        //if (this._stringFormat == null)
        //{
        //  this._stringFormat = new StringFormat(StringFormatFlags.NoWrap );

        //  //this._stringFormat.LineAlignment = StringAlignment.Near;
        //  //this._stringFormat.Alignment = StringAlignment.Near;
        //  // this._stringFormat.Trimming = StringTrimming.Word;
        //}
        //return this._stringFormat;
      }
    }
    StringFormat _stringFormat = StringFormat.GenericTypographic;
    //private void _DrawWord(Graphics g, Brush brush, ref int x, int y, string word)
    //{
    //  g.DrawString(word, this.Font, brush, x, y, this._StringFormat);
    //  x += (int)_Text.GetWordSize(word, this.Font, this._StringFormat).Width;
    //}
    private int _findFirstChar(int line)
    {
      if (line == 0) return 0;
      int index = 0;
      for (int i = 1; i <= line; i++)
      {
        int n = _text.IndexOf('\n', index);
        if(n == -1)
        {
          return -1;
        }
        index = n + 1;
      }
      return index;
    }
    private void _moveLineDown()
    {
      int n = _text.IndexOf('\n', _firstVisibleIndex);
      if (n >= 0)
      {
        _topLine++;
        _firstVisibleIndex = n + 1;
        this.Invalidate();
      }
    }
    protected override bool IsInputKey(Keys keyData)
    {
      return true;// base.IsInputKey(keyData);
    }
    protected override bool IsInputChar(char charCode)
    {
      return true;//base.IsInputChar(charCode);
    }
    protected override void OnKeyPress(KeyPressEventArgs e)
    {
      char ch = e.KeyChar;

      string s = _text.Substring(0, _currentEditIndex) 
        + (ch == '\r' ? "\r\n" : ch + "")
        + _text.Substring(_currentEditIndex);
      _text = s;

      if (ch == '\r')
      {
        _selectedLine++;
        _currentEditIndex = _findFirstChar(_selectedLine + _topLine);
      }
      else
      {
        _currentEditIndex++;
      }
      this.Invalidate();
      //base.OnKeyPress(e);
    }
    protected override void OnKeyDown(KeyEventArgs e)
    {
      if(e.KeyCode == Keys.Down)
      {
        _moveLineDown();
        //_topLine++;
        //_firstVisibleIndex = _findFirstChar(_topLine);
        //this.Invalidate();
      }
      else if(e.KeyCode == Keys.PageDown)
      {
        _topLine += _lines_per_page;
        int i =_findFirstChar(_topLine);
        if(i != -1)
        {
          _firstVisibleIndex = i;
        }
        this.Invalidate();
      }
      else if (e.KeyCode == Keys.PageUp)
      {
        _topLine -= _lines_per_page;
        if (_topLine < 0) _topLine = 0;
        _firstVisibleIndex = _findFirstChar(_topLine);
        this.Invalidate();
      }
      else if (e.KeyCode == Keys.Up)
      {
        _topLine--;
        if (_topLine < 0) _topLine = 0;
        _firstVisibleIndex = _findFirstChar(_topLine);
        this.Invalidate();

      }
      base.OnKeyDown(e);
    }
    private void _raise_word_selected(string word)
    {
      if (OnWordSelected != null && _word_is_selected)
      {
        OnWordSelected(word);
      }
      _word_is_selected = false;
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
      //  base.OnMouseDown(e);

      _selectedLine = (int)(e.Y / _lineHeight);
      _currentEditIndex = _findFirstChar(_selectedLine + _topLine);

      _mouse_x = e.X;
      _mouse_y = e.Y;
      _word_is_selected = true;

      this.Invalidate();
      base.OnMouseDown(e);
    }
    protected override void OnMouseWheel(MouseEventArgs e)
    {
      _word_is_selected = false;
      _topLine += (e.Delta < 0 ? 1 : -1);
      if (_topLine < 0) _topLine = 0;
      _firstVisibleIndex = _findFirstChar(_topLine);
      this.Invalidate();
     // base.OnMouseWheel(e);
    }

    int _lineNumber;
    void _draw_line_number(Graphics g)
    {
      
      float x = 0;
      float y = _lineNumber * _lineHeight;
      g.DrawString((_topLine + _lineNumber).ToString(), _font, Brushes.Black, x, y + 7, _stringFormat);
      _lineNumber++;
    }
    bool _isWhite(char c)
    {
      return c == ' ' || c == '\t' || c == '\r' || c == '\n';
    }
    string _getWord(int i)
    {
      string s = "";
      while (i < _text.Length && !_isWhite(_text[i]))
      {
        s+= _text[i];
        i++;
      }
      return s;
    }
    string _getBlank(int i)
    {
      string s = "";
      while (_text[i] == ' ' || _text[i] == '\t')
      {
        s += ' ';// _text[i++];
        i++;
      }
      return s;
    }

    SizeF _wordSize;
    SizeF _getWordSize(Graphics g,string s)
    {
      _wordSize  = g.MeasureString(s, this.Font, 1000, _stringFormat);
      return _wordSize;
    }
    private void _get_line_words(Graphics g,ref int i, float width)
    {
      _words.Clear();
      _widths.Clear();
      _widths.Add(0);
      if (i == -1) return;

      string s;
      float w = 0;
      while(i < _text.Length)
      {
        s = "";
        char c = _text[i];
        if(_text[i] == ' ' || _text[i] == '\t')
        {
          s = _getBlank(i);
          _getWordSize(g,s);
          if (w + _wordSize.Width >= width)
          {
            return;
          }
          w += _wordSize.Width;
          i += s.Length;
          _words.Add(s);
          _widths.Add(w);
          continue;
        }
        if(_text[i] == '\r' && i+1 < _text.Length && _text[i+1] == '\n')
        {
          i += 2;
          return;
        }
        if (_text[i] == '\r')
        {
          i++;
          continue;
        }
        if(_text[i] == '\n')
        {
          i++;
          return;
        }
        s = _getWord(i);
        _getWordSize(g,s);
        if (w + _wordSize.Width >= width)
        {
          return;
        }
        i += s.Length;
        w += _wordSize.Width;
        _words.Add(s);
        _widths.Add(w);
      }
    }
    protected override void OnPaintBackground(PaintEventArgs e)
    {
      base.OnPaintBackground(e);
    }
    
    protected override void OnPaint(PaintEventArgs e)
    {
      _stringFormat.Trimming = StringTrimming.None;
      _stringFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoWrap;
      e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;


      Graphics g = e.Graphics;
   //   g.FillRectangle(Brushes.LightGoldenrodYellow, e.ClipRectangle);
      if (_text == null) return;

      _lineNumber = 0;
      _lines_per_page = 0;

      SizeF size = g.MeasureString("W", this.Font, 100, _stringFormat);

      float leftMargin = 100,rightMargin = 50;
      _lineHeight = size.Height;
      int i = _firstVisibleIndex;
      float y = 0;

      
      label_next_line:
      float x = leftMargin;

      _lines_per_page = (int)(this.Height / _lineHeight) - 1;

      _get_line_words(g, ref i, e.ClipRectangle.Width - rightMargin - leftMargin);

      if (i >= _text.Length) return;

      _draw_line_number(g);
   

      if (_words.Count > 0)
      {
        int n  = 0;
        foreach (string word in _words)
        {
          Brush brush = Brushes.Black;
          if (_lineNumber -1 == _selectedLine )
          {
            if (_widths[n] <= _mouse_x - leftMargin && _mouse_x - leftMargin <= _widths[n+1])
            {
              brush = _word_is_selected ? Brushes.Blue : Brushes.Black;
              _raise_word_selected(_words[n]);
            }
          }

          x = leftMargin + _widths[n++];
          g.DrawString(word, _font, brush, x, y, _stringFormat);
         // g.DrawLine(Pens.Gray, x, y, x, y + _lineHeight);
        }
      }

      y += _lineHeight;
      if (y < this.Height) goto label_next_line;

      y = (_selectedLine + 1) * _lineHeight;
  //    g.DrawLine(Pens.Gray, 0, y, this.Width, y);
      x = leftMargin - 3;
      g.DrawLine(Pens.Green, x, 0, x,  this.Height);

    }
    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      this.Invalidate();
    }
  }
}
