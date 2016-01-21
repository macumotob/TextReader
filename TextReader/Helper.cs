using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Baybak.TextReader
{
  //using Baybak.Data.Broker;

  public partial class Helper : UserControl
  {
   // public DictionaryBroker _Broker;

    public Helper()
    {
      InitializeComponent();
      _txtTarget.KeyDown += new KeyEventHandler(_txtTarget_KeyDown);
    }

    void _txtTarget_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        _TranslateWord(_txtTarget.Text);
        _txtTarget.Focus();
      }
    }

    private int _index;
    private int _currentIndex
    {
      get
      {
        return _index;
      }
      set
      {
        _index = value;
        if (_index > _translateResult.Count - 1)
        {
          _index = _translateResult.Count - 1;
        }
        if (_index < 0)
        {
          _index = 0;
        }
      }
    }
    private string _englishWord;
    private List<string> _translateResult;
    private List<string> _translateResultAll;
    private string _translation
    {
      get
      {
        if (_currentIndex == -1)
        {
          return "<< NOT FOUND >>";
        }
        if (_translateResult.Count == 0)
        {
          if(_translateResultAll.Count == 0)
          {
            return "<< NOT FOUND >>";
          }
          return _translateResultAll[_currentIndex];
        }
        return _translateResult[_currentIndex];
      }
    }
    public void _TranslateWord(string word)
    {
      _englishWord = word;
      Words.Translate(word, out _translateResult, out _translateResultAll);
      _currentIndex = _translateResult.Count > 0 ? 0 : (_translateResultAll.Count > 0 ? 0 : -1);
      _listResult.Items.Clear();

      if (_translateResult.Count > 0)
      {
        foreach (string s in _translateResult)
        {
          _listResult.Items.Add(s);
        }
      }
      else
      {
        foreach (string s in _translateResultAll)
        {
          _listResult.Items.Add(s);
        }
      }
      _DisplayResult();
    }

    public void _TranslateText(string word)
    {
      this._RunGoogleTranslate(word);
      this._DisplayResult();
    }
    private void _DisplayResult()
    {
      _txtTarget.Text = _englishWord;

      _txtResult.Text = _translation;
      this._txtResult.Enabled = false;
      this.Parent.Focus();
    }
    private void _cmdPrev_Click(object sender, EventArgs e)
    {
      _currentIndex--;
      this._DisplayResult();
    }

    private void _cmdNext_Click(object sender, EventArgs e)
    {
      _currentIndex++;
      this._DisplayResult();
    }
    private void _lblMore_Click(object sender, EventArgs e)
    {
      //Chrome_OmniboxView SPY++
      this._RunGoogleTranslate(_englishWord);
    }
    private void _lblGoogleDic_Click(object sender, EventArgs e)
    {
      string s = string.Format("http://www.google.com/search?source=dict-chrome-ex&defl=en&hl=en&q={0}&tbo=1&tbs=dfn:1",_englishWord);
      this._RunChrome(s);
    }
    private void _RunGoogleTranslate(string text)
    {
      string arguments = "http://translate.google.com.ua/?hl=ru&tab=wT#en/ru/" +
        text.Replace(" ", "%20");
      this._RunChrome(arguments);
    }
    private void _RunChrome(string arguments)
    {
      ProcessStartInfo psi = new ProcessStartInfo("chrome.exe");
      psi.Arguments = arguments;
      Process p = new Process();
      p.StartInfo = psi;
      p.Start();
    }
    private Point MouseDownLocation;
    protected override void OnMouseDown(MouseEventArgs e)
    {
      if (e.Button == System.Windows.Forms.MouseButtons.Left)
      {
        MouseDownLocation = e.Location;
      }
      //base.OnMouseDown(e);
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
      if (e.Button == System.Windows.Forms.MouseButtons.Left)
      {
        if (e.Y > this.Height - 30 && e.X > this.Width - 100)
        {
          this.Width += e.X - MouseDownLocation.X;
          this.Height += e.Y - MouseDownLocation.Y;
          MouseDownLocation = e.Location;
        }
        else
        {
          this.Left = e.X + this.Left - MouseDownLocation.X;
          this.Top = e.Y + this.Top - MouseDownLocation.Y;
        }
      }
      //base.OnMouseMove(e);
    }

    private void _cmdHide_Click(object sender, EventArgs e)
    {
      this.Hide();
    }

    private void _cmdSave_Click(object sender, EventArgs e)
    {
      string content = _txtResult.Text;
      //this._Broker.Save(content);
      this._DisplayResult();
    }

    private void _cmdNew_Click(object sender, EventArgs e)
    {
      //this._Broker.Current.Clear();
      //this._lblId.Text = this._Broker.Current.Id.ToString();
      //this._txtResult.Text = this._Broker.Current.Content; // .FormatResult();
      this._txtResult.Enabled = true;
      this._txtResult.Focus();
    }

    private void _cmdEdit_Click(object sender, EventArgs e)
    {
      this._txtResult.Enabled = true;
      this._txtResult.Focus();
    }
    public void _MoveToBottom()
    {
      this.Left = 0;
      this.Top = this.Parent.Height - this.Height;
      this.Width = this.Parent.Width;
    }
    private void Helper_DoubleClick(object sender, EventArgs e)
    {
      _MoveToBottom();
    }

    private void _listResult_SelectedIndexChanged(object sender, EventArgs e)
    {
      _txtResult.Text = (string)_listResult.SelectedItem;
    }

  }
}
