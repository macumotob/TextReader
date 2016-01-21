using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SS.GoogleTranslation;

namespace Baybak.TextReader
{
 // using Baybak.Data.Broker;

  public partial class TextViewer : UserControl
  {
    public delegate void EventBookmarkChanged(Guid userId, Guid bookId, int wordIndex, bool delete);
    public event EventBookmarkChanged _OnBookmarkChanged;
    public delegate void EventTextSelected(string text);
    public event EventTextSelected OnTextSelected;

    public bool _IsText = true;
    private BaybakText _Text = new BaybakText();
    public string _Word;

    //Borders _Borders = new Borders();
    private Helper _helper;
    public Helper _Helper
    {
      get
      {
        return this._helper;
      }
      set
      {
        _helper = value;
      }
    }

    public TextViewer()
    {
      InitializeComponent();
    }

    //public void _SetDictionaryBroker(DictionaryBroker broker)
    //{
    //  //this._Helper._Broker = broker;
    //}
    private float _FontStep = 1.0f;

    private int _BookmarkIndex = -1;
    internal bool _SingleWordTranslateMode = true;

    private GoogleTranslator _Translator = new GoogleTranslator();
  

    public string _GetSelectedText()
    {
      return _Text.GetText(_SelectionBegin, _SelectionEnd);
    }
    public void _GoogleTranslate()
    {
      _Translator.SourceText = _Text.GetText(_SelectionBegin, _SelectionEnd);
      _Translator.SourceLanguage = "English";
      _Translator.TargetLanguage = "Russian";
      _Translator.Translate();
     
    }
    public void _SelectionModeChange()
    {
      _SingleWordTranslateMode = !_SingleWordTranslateMode;
    }
    public void BookmarkNext()
    {
      if (_Bookmarks == null || _Bookmarks.Count == 0)
      {
        return;
      }
      _BookmarkIndex++;
      if (_BookmarkIndex >= _Bookmarks.Count - 1)
      {
        _BookmarkIndex = _Bookmarks.Count - 1;
      }
      if (_BookmarkIndex < 0)
      {
        _BookmarkIndex = 0;
      }
      _Text.FirstVisibleLine = _Text.GetLineIndexByWordIndex(_Bookmarks[_BookmarkIndex]) - 1;
      this.Invalidate();
    }
    public void BookmarkFirst()
    {
      if (_Bookmarks == null || _Bookmarks.Count == 0)
      {
        return;
      }
      _BookmarkIndex = 0;
      _Text.FirstVisibleLine = _Text.GetLineIndexByWordIndex(_Bookmarks[_BookmarkIndex]) - 1;
      this.Invalidate();
    }

    public void BookmarkPrev()
    {
      if (_Bookmarks == null || _Bookmarks.Count == 0)
      {
        return;
      }
      _BookmarkIndex--;
      if (_BookmarkIndex < 0)
      {
        _BookmarkIndex = 0;
      }
      _Text.FirstVisibleLine = _Text.GetLineIndexByWordIndex(_Bookmarks[_BookmarkIndex]) - 1;
      this.Invalidate();
    }
    public void BookmarkLast()
    {
      if (_Bookmarks == null || _Bookmarks.Count == 0)
      {
        _Text.FirstVisibleLine = 0;
        this.Invalidate();
        return;
      }
      _BookmarkIndex = _Bookmarks.Count - 1;
      _Text.FirstVisibleLine = _Text.GetLineIndexByWordIndex(_Bookmarks[_BookmarkIndex]) - 1;
      this.Invalidate();
    }
    public void ZoomIn()
    {
      this.Font = new Font("Georgia", this.Font.Size - this._FontStep);
      _prevHeight = -1;
      this.Invalidate();
    }
    public void ZoomOut()
    {
      this.Font = new Font("Georgia", this.Font.Size + this._FontStep);
      _prevHeight = -1;
      this.Invalidate();
    }
    public void MoveFirstLine()
    {
      _Text.FirstVisibleLine = 0;
      this.Invalidate();
    }
    public void MoveLastLine()
    {
      _Text.FirstVisibleLine = this._Text.LineWordsIndex.Count - 1;
      this.Invalidate();
    }
    public void MoveNextLine()
    {
      _Text.FirstVisibleLine++;
      this.Invalidate();
    }
    public void MovePreviousLine()
    {
      _Text.FirstVisibleLine--;
      this.Invalidate();
    }
    public void MovePageUp()
    {
      _Text.FirstVisibleLine -= this._PageSize;
      this.Invalidate();
    }
    public void MovePageDown()
    {
      _Text.FirstVisibleLine += this._PageSize;
      this.Invalidate();
    }
    
    public void _SetText(string text)
    {
      _Text.Text = text;
      _Text.FirstVisibleLine = 0;
      _prevWidth = -1;
      _prevHeight = -1;
      this.Invalidate();
    }
    private int _SelectedLine;

    public Guid _BookId;
    private List<int> _Bookmarks
    {
      get
      {
        return BooksBroker.Instance.CurrentBook == null ? null: BooksBroker.Instance.CurrentBook.Bookmarks;
      }
    }
    //public void LoadFromServer(BooksBroker broker, Guid id)
    //{
    //  _BookId = id;

    //  this._Text.Id = id;

    //  _prevWidth = -1;
    //  _prevHeight = -1;

    //  _BookmarkIndex = -1;
    //  _Text._Graphics = null;
    //  this.Invalidate();
    //}
    public void SetText(string text)
    {
      _Text.Text = text;
      _Text.FirstVisibleLine = 0;
      _prevWidth = -1;
      _prevHeight = -1;

      _BookmarkIndex = -1;

      _Text._Graphics = null;
      this.Invalidate();
    }

    private int _PageSize;

    private int _prevWidth;
    private int _prevHeight;

    private bool _NeedFormat
    {
      get
      {
        //System.Diagnostics.Debug.Print(string.Format("W:{0}|{2} H:{0}|{3}", this.Width, this.Height, this._prevWidth, this._prevHeight));
        bool result = (_prevHeight != this.Height || _prevWidth != this.Width);

        this._prevHeight = this.Height;
        this._prevWidth = this.Width;
       return result;
      }
      set
      {
        _prevWidth = -1;
        _prevHeight = -1;
      }
    }


    private int _TextWidth
    {
      get
      {
        return this.Width - _LeftBorder * 2;
      }
    }
    private int _TextHeight
    {
      get
      {
        return this.Height - _TopMargin;
      }
    }
    private int _LeftBorder = 100;
    public int LeftBorder
    {
      get
      {
        return _LeftBorder;
      }
      set
      {
        _LeftBorder = value;
      }
    }
    int _TopMargin = 30;


    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      if (_Text != null)
      {
        _Text._Graphics = null;
      }
      this.Invalidate();
    }

 //   StringFormat _stringFormat;

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

    private void _DrawWord(Graphics g, Brush brush, ref int x, int y,string word)
    {
      g.DrawString(word, this.Font, brush, x, y, _StringFormat);
      x += (int)_Text.GetWordSize(word,this.Font,_StringFormat).Width;
    }
    private void _DrawWords(Graphics g,int line,int x,int y)
    {
      int from = this._Text.LineWordsIndex[line];
      int to = this._Text.LastWordIndex(line);

      for (int i = from; i <= to; i++)
      {
          this._DrawWord(g, _SelectionBegin <= i && i <= _SelectionEnd ? Brushes.Blue: Brushes.Black,
            ref x, y, this._Text.Words[i]);
      }
    }
    private void _DrawText(Graphics g)
    {
      //this._PageSize = (int)(this._Borders.Text.Height / this._size.Height) - 2;

      int i = _Text.FirstVisibleLine;
      int h = _TopMargin;
      int x = 0;

      bool beginParagraph = false;
      _PageSize = 1;
      while (h < _TextHeight && i < _Text.LineWordsIndex.Count)
      {
        //string lineNumber = i.ToString();
        g.DrawLine((i == _SelectedLine ? Pens.Brown : Pens.LightGray), _LeftBorder, h +_Text._Size.Height ,
          _TextWidth+_LeftBorder , h + _Text._Size.Height);
        if (beginParagraph)
        {
          x = _Text.ParagraphOffset + _LeftBorder;
          beginParagraph = false;
        }
        else
        {
          x = _LeftBorder;
        }

        if (_Text.IsParagraph(i))
        {
          beginParagraph = true;
          //
        }
        else
        {
          _DrawWords(g, i, x, h);
          _DrawBookmark(g, i, h);
        }
        h += (int)_Text._Size.Height;
        i++;
        _PageSize++;
      }
      this._PageSize -=2;
      if (this._PageSize < 1) this._PageSize = 1;
    }

    
    private Font _BookmarkFont = new Font("Tahoma", 8);
    private void _DrawBookmark(Graphics g, int line,int y)
    {
      if(_Bookmarks == null)
      {
        return;
      }
      for (int i = 0; i < _Bookmarks.Count; i++)
      {
        int index1 = _Text.LineWordsIndex[line];
        int index2 = _Text.LastWordIndex(line);
        if (index1 <= _Bookmarks[i] && _Bookmarks[i] <= index2)
        {
          g.FillRectangle(Brushes.Brown, 2, y, _LeftBorder, _Text._Size.Height);
          g.DrawRectangle(Pens.Yellow, 2, y, _LeftBorder, _Text._Size.Height);
          g.DrawString(string.Format("{0}/{1}", i + 1, _Bookmarks.Count), _BookmarkFont, Brushes.Yellow, 4, y);
        }
      }
    }
    protected override void OnPaint(PaintEventArgs e)
    {
      Graphics g = e.Graphics;
      if (_Text != null)
      {
        _Text._Graphics = this.CreateGraphics();
      }

//      g.FillRectangle(this., 0, 0, this.Width, this.Height);

      g.DrawLine(Pens.Brown, _TextWidth + _LeftBorder, _TopMargin, _TextWidth + _LeftBorder, this.Height);
      if (this._NeedFormat)
      {
        _Text.FormatText(this.Font, _StringFormat, _TextWidth);
        if (_BookmarkIndex == -1 && _Bookmarks != null && _Bookmarks.Count > 0)
        {
          BookmarkLast();
        }
      }
      _DrawText(g);

      string s = string.Format("{0} : {1} {2}:{3}", (_Text.FirstVisibleLine / this._PageSize).ToString(),
        (this._Text.LineWordsIndex.Count / this._PageSize).ToString(),
        _SelectionBegin,_SelectionEnd);
      g.DrawString(s, _BookmarkFont, Brushes.Brown, 10, 3);

      base.OnPaint(e);
    }
    System.Speech.Synthesis.SpeechSynthesizer _speecher = new System.Speech.Synthesis.SpeechSynthesizer();

    private void _RaiseWordSelected()
    {
      if (this._Text.LineWordsIndex.Count == 0)
      { 
        return;
      }
      _Word = _Text.GetText(_SelectionBegin, _SelectionEnd);
      if(OnTextSelected != null)
      {
        OnTextSelected(_Word);
      }
      if (_SelectionBegin == _SelectionEnd)
      {
       // _Helper._TranslateWord(_Word);//_Text.Words[_SelectionBegin]);
       // using (System.Speech.Synthesis.SpeechSynthesizer ss = new System.Speech.Synthesis.SpeechSynthesizer())
        {
          _speecher.Volume = 100;
          _speecher.Rate = 0;
          _speecher.Speak(_Word);
          
         //_speecher.Dispose();
        }
      }
      else
      {
      //  using (System.Speech.Synthesis.SpeechSynthesizer ss = new System.Speech.Synthesis.SpeechSynthesizer())
        {

         // ss.SetOutputToWaveFile("d:\\chvan2.wav");
          _speecher.Volume = 100;
          _speecher.Rate = 0;
          _speecher.Speak(_Word);
          //_speecher.Dispose();
        }
       // _Helper._TranslateText(_Word);
      }
      this.Focus();
    }
    #region Mouse

    private Point _MouseDownLocation;
    private Point _MouseClickLocation;
    protected override void OnMouseEnter(EventArgs e)
    {
      base.OnMouseEnter(e);
      this.Focus();
    }
    private void _SetSelectedLine(int y)
    {
      if (_Text._Size.Height <= 0)
      {
        _SelectedLine = 0;
        return;
      }
      _SelectedLine = _Text.FirstVisibleLine + (y - _TopMargin ) / ((int)_Text._Size.Height);
    }
    private void _ProcessBookmark(MouseEventArgs e)
    {
      if(_Bookmarks == null)
      {
        return;
      }
      _SetSelectedLine(e.Y);
      if (_Text.LineWordsIndex.Count == 0)
      {
        return;
      }
      int firstWord = _Text.LineWordsIndex[_SelectedLine];
      int lastWord = _Text.LastWordIndex(_SelectedLine);
      bool addNewBookmark = true;
      for (int i = firstWord; i <= lastWord; i++)
      {
        bool delete = _Bookmarks.Exists(x => x == i);
        if (delete)
        {
          _Bookmarks.Remove(i);
          BooksBroker.Instance.SaveHistory();
          addNewBookmark = false;
        }
      }
      if (addNewBookmark)
      {
        int wordIndex = _Text.LineWordsIndex[_SelectedLine];
        _Bookmarks.Add(wordIndex);
        BooksBroker.Instance.SaveHistory();
      }
      this.Invalidate();
    }
    private int _selectionBegin = -1;
    private int _SelectionBegin
    {
      get
      {
        return _selectionBegin <= _selectionEnd ? _selectionBegin : _selectionEnd;
      }
    }
    private int _selectionEnd=-1;
    private int _SelectionEnd
    {
      get
      {
        return _selectionBegin <= _selectionEnd ? _selectionEnd : _selectionBegin  ;
      }
    }
    private int _GetWordUnderCursor(Point mouse)
    {
      return _Text.GetWordUnderCursor(mouse, _TopMargin , _LeftBorder, this.Font, this._StringFormat);
    }

    private void _Translate(Point location)
    {
      _SetSelectedLine(location.Y);
      if (_SingleWordTranslateMode)
      {
        _selectionBegin = _selectionEnd = _GetWordUnderCursor(location);
        this.Invalidate();
        _RaiseWordSelected();
        return;
      }

      if (_selectionBegin == _selectionEnd && _selectionEnd == -1)
      {
        _selectionBegin = _selectionEnd = _GetWordUnderCursor(location);
        this.Invalidate();
        _RaiseWordSelected();
      }
      else if (_selectionBegin == _selectionEnd)
      {
        _selectionEnd = _GetWordUnderCursor(location);
        if (_selectionBegin == _selectionEnd)
        {
          _selectionBegin = _selectionEnd = -1;
          this.Invalidate();
        }
        else
        {
          this.Invalidate();
          _RaiseWordSelected();
        }
      }
      else
      {
        _selectionBegin = _selectionEnd = _GetWordUnderCursor(location);
        this.Invalidate();
        _RaiseWordSelected();
      }

    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      if ((Control.ModifierKeys & Keys.Shift) != 0)
      {
        _SetSelectedLine(e.Location.Y);
        int wordIndex = _GetWordUnderCursor(e.Location);
        _Text.InsertParagraph(wordIndex);
        _NeedFormat = true;
         this.Invalidate();
         return;
      }
      this.Cursor = Cursors.Hand;
      if (e.Button == System.Windows.Forms.MouseButtons.Right)
      {
        _selectionBegin = _selectionEnd = -1;
        return;
      }
      if (e.Button != System.Windows.Forms.MouseButtons.Left)
      {
        return;
      }
      _MouseClickLocation = _MouseDownLocation = e.Location;

      if (this._TopMargin < e.Y && e.X > _LeftBorder && e.X < _TextWidth + _LeftBorder  )
      {
        _Translate(e.Location);
        return;
      }

      if (e.X < _LeftBorder)
      {
        _ProcessBookmark(e);
      }
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);

      if (e.Button != System.Windows.Forms.MouseButtons.Left) return;

      if (e.X <= _LeftBorder || e.X > _LeftBorder + _TextWidth)
      {
        if (_MouseDownLocation.Y > e.Y)
        {
          _Text.FirstVisibleLine--;
          this.Invalidate();
        }
        else
        {
          _Text.FirstVisibleLine++;
          this.Invalidate();
        }
        _MouseDownLocation = e.Location;
      }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);
      this.Cursor = Cursors.Default;
      this.Invalidate();
    }
    protected override void OnMouseWheel(MouseEventArgs e)
    {
      if (e.Delta > 0)
      {
        _Text.FirstVisibleLine--;
        this.Invalidate();
      }
      else if (e.Delta < 0)
      {
        _Text.FirstVisibleLine++;
        this.Invalidate();
      }
      base.OnMouseWheel(e);
    }

    #endregion

    protected override bool IsInputKey(Keys keyData)
    {
      return true;//base.IsInputKey(keyData);
    }
    protected override void OnKeyDown(KeyEventArgs e)
    {
      base.OnKeyDown(e);
      switch (e.KeyCode)
      {
        case Keys.Up:
          _Text.FirstVisibleLine--;
          break;
        case Keys.PageUp:
          _Text.FirstVisibleLine -= this._PageSize;
          break;
        case Keys.Down:
          _Text.FirstVisibleLine++; 
          break;
        case Keys.PageDown:
          _Text.FirstVisibleLine += this._PageSize;
          break;
        case Keys.Home:
          if (e.Control)
          {
            _Text.FirstVisibleLine = 0;
          }
          break;
        case Keys.End:
          if (e.Control)
          {
            _Text.FirstVisibleLine = this._Text.LineWordsIndex.Count - 1;
          }
          break;
      }
      this.Invalidate();
    }
    /*
    class Borders
    {
      public Rectangle ToolBar = new Rectangle();
      public Rectangle Numbers = new Rectangle();
      public Rectangle Text = new Rectangle();
      public Rectangle RightTool = new Rectangle();

    }*/
  } //
}
