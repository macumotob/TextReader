using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using mshtml;

namespace Baybak.TextReader
{

  [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
  [System.Runtime.InteropServices.ComVisibleAttribute(true)]

  public partial class frmMain : Form
  {
    string _commentFileName;
    Translator _translator = new Translator();

    public frmMain()
    {
      InitializeComponent();
      //this.textViewer1.OnWordSelected += new TextViewer.EventWordSelected(textViewer1_OnWordSelected);
     // this.textViewer1._Helper = this._Helper;
      this.textViewer1._OnBookmarkChanged += new TextViewer.EventBookmarkChanged(textViewer1__OnBookmarkChanged);
      this.textViewer1.OnTextSelected += (w) => { _show_translation_result(w); };
      //_Speeker._OnTextToSpeechNeeded += new UserControlSpeeker.EventTextToSpeechNeeded(_Speeker__OnTextToSpeechNeeded);
      _webBrowser.DocumentCompleted += _webBrowser_DocumentCompleted;
   //   _webBrowser.AllowWebBrowserDrop = false;
      _webBrowser.IsWebBrowserContextMenuEnabled = false;
     // _webBrowser.WebBrowserShortcutsEnabled = false;
      _webBrowser.ScriptErrorsSuppressed = true;
      _webBrowser.ObjectForScripting = this;
      //_ToolBarG._AddHandler("Book", _OpenBook2Read);
      //  _ToolBarG._AddHandler("Edit", _EditCurrentBook);
      RunManager.OnException += Manager_OnException;
   }

    private void Manager_OnException(Exception e)
    {
      string text = e.ToString();
      MessageBox.Show(text, "Run Manager Exception");
    }

    bool _historyLoaded;
    void _webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
      if (_historyLoaded)
      {
        _loadScript();
        return;
      }
      var txt = _webBrowser.Document.GetElementById("txt");
      if (txt != null)
      {
        string s = txt.OuterHtml;
        s = s.Substring(s.IndexOf("value=") + "value=".Length);
        s = s.Substring(0, s.IndexOf(">"));
        this.Translate(s);
      }
      else
      {
        string[] elements = { "gbq1","gb", "gba", "gt-ft-res", "gt-ft"  ,"gt-appbar","gt-bbar-c",
                            "gt-langs","gb_Va","gt-logo","gt-logo-icon"};
        foreach (string id in elements)
        {
          var element = _webBrowser.Document.GetElementById(id);
          if (element != null) element.InnerHtml = "";
        }
//        _textSource = _browser.Document.GetElementById("source");

      }
    }
    public void Translate(string text)
    {
      var dv = _webBrowser.Document.GetElementById("result");
      if (dv != null)
      {
        dv.InnerHtml = _translate_word(text);
      }
    }
    private string _englishWord;
    private List<string> _translateResult;
    private List<string> _translateResultAll;
    private string  _translate_word(string word)
    {
      _englishWord = word;
      Words.Translate(word, out _translateResult, out _translateResultAll);
      string result = "<br/>";
      List<TranslateItem> list = _translator.Translate(word);
      foreach (TranslateItem item in list)
      {
        result += item.ToHtml();// "<p><b>" + item.English + "</b> Syn:<i>" + item.Synonim + "</i> " + item.Russian + "</p>";
      }

      if (_translateResult.Count > 0)
      {
        foreach (string s in _translateResult)
        {
          result += "<p>" + s + "</p><br/>";
        }
      }
      else
      {
        foreach (string s in _translateResultAll)
        {
          result += "<p>" + s + "</p><br/>";
        }
      }
      return result;
    }

    public void _show_translation_result(string text)
    {
      string s = Properties.Resources.tr.Replace("{{TEXT}}", text);
      string result = _translate_word(text);

      _webBrowser.DocumentText = s;
    }
    private void _EditCurrentBook()
    {
      //frmBookInfo frm = new frmBookInfo(_BookBroker, false);
      //{
      //  frm.Show();
      //}
    }
    private void _SelectionModeChange()
    {
      this.textViewer1._SelectionModeChange();
      bool single = this.textViewer1._SingleWordTranslateMode;
    }
    string _Speeker__OnTextToSpeechNeeded()
    {
      return this.textViewer1._GetSelectedText();
    }

    //    BooksBroker _BookBroker = new BooksBroker();

    void textViewer1__OnBookmarkChanged(Guid userId, Guid bookId, int wordIndex, bool delete)
    {
      if (delete)
      {
        //_BookBroker.DeleteBookmark(userId, bookId,  wordIndex);
      }
      else
      {
        //_BookBroker.AddBookmark(userId, bookId, wordIndex);
      }
    }

    private BooksBroker _broker
    {
      get
      {
        return BooksBroker.Instance;
      }
    }
    private BookInfo _book
    {
      get
      {
        return _broker.CurrentBook;
      }
    }
    public string FileName;
    //public string FileNameRussian;

    /*
     void _MakeTranslation(string word)
     {
       if (this._frmTrans == null)
       {
         this._frmTrans = new frmTranslator();
         this._frmTrans.Show(this);
       }
       if (!this._frmTrans.Visible)
       {
         this._frmTrans.Show(this);
       }
       this._frmTrans._Translate(word);
     }
     void textViewer1_OnWordSelected(string word)
     {
       this._MakeTranslation(word);
     }*/
    protected override void OnShown(EventArgs e)
    {
      _translator.LoadFromFile(Application.StartupPath + "\\mydic.bin");

      if (_broker.CurrentBook != null)
      {
        _openFile(_broker.CurrentBook.FileName);
      }
      base.OnShown(e);
    }

    private void _saveComments()
    {
      // _commentFileName = file.Replace(".txt", ".ww.txt");
      if (_commentFileName == null) return;
      using (System.IO.StreamWriter sw = new System.IO.StreamWriter(_commentFileName, false, Encoding.UTF8))
      {
        sw.Write(_textContent.Text);
        sw.Close();
      }
    }
    void _saveAll()
    {
      if (_broker != null)
      {
        _broker.SaveHistory();
      }
      _saveComments();
    }

    protected override void OnClosed(EventArgs e)
    {
      _saveAll();
      base.OnClosed(e);
    }

    //private void openToolStripMenuItem_Click(object sender, EventArgs e)
    //{
    //  this.openFileDialog1.InitialDirectory = @"C:\ww\DownLoads\";
    //  openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
    //  openFileDialog1.FilterIndex = 1;
    //  openFileDialog1.RestoreDirectory = true;

    //  if (openFileDialog1.ShowDialog() == DialogResult.OK)
    //  {
    //    //OpenFile(openFileDialog1.FileName,Guid.Empty);
    //  }
    //}

    ////private static int _Compare(Word w1, Word w2)
    ////{
    ////  if (w1.Count == w2.Count)
    ////    return 0;
    ////  if (w1.Count > w2.Count)
    ////    return -1;
    ////  return 1;
    ////}

    protected override bool IsInputKey(Keys keyData)
    {
      return true;
    }

    private void openMenuItem_Click(object sender, EventArgs e)
    {
      

      OpenFileDialog ofd = new OpenFileDialog();

      ofd.Filter = "All Files|*.*";
      ofd.FilterIndex = 1;
      ofd.Multiselect = false;

      if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        _broker.Add(ofd.FileName);
        _openFile(ofd.FileName);
      }

    }
   // frmComments _commentsForm;
    public void _openFile(string file)
    {
      _saveAll();
      _historyLoaded = false;
      this.splitContainer2.SplitterDistance = this.Width / 2;

      string ext = System.IO.Path.GetExtension(file).ToLower();
      
      _commentFileName = file.ToLower().Replace(ext, ".ww" + ext);

     if (System.IO.File.Exists(_commentFileName))
      {
        _textContent.Text = System.IO.File.ReadAllText(_commentFileName, Encoding.UTF8);
      }
      else
      {
        _textContent.Text = DateTime.Now.ToLongDateString();
      }
     if (ext == ".txt" || ext == ".muse")
     {
       textViewer1.SetText(System.IO.File.ReadAllText(file, Encoding.UTF8));
       this.Text = _broker.CurrentBook.Title + " / " + System.IO.Path.GetFileName(_broker.CurrentBook.FileName);
     }
     else
     {
       RunManager.Manager.RunApplication(file);
     }
    }
    public void _editFileInfo(string file)
    {
      _broker.SetCurrentBook(file);
      string s = Properties.Resources.editfileinfo;
      s = s.Replace("@Author", _book.Author);
      s = s.Replace("@Title", _book.Title);
      s = s.Replace("@Comment", _book.Comment);
      s = s.Replace("@File", _book.FileName);

      _webBrowser.DocumentText = s;
    }
    private void _historyMenuItem_Click(object sender, EventArgs e)
    {
      using (frmHistory frm = new frmHistory())
      {
        frm.ShowDialog(this);
        if (frm.SelectedFileName != null)
        {
          _openFile(_broker.CurrentBook.FileName);
        }
      }
    }
    //frmTranslator _translateForm;
    private void _commandGoogle_Click(object sender, EventArgs e)
    {
     // string url = string.Format("http://www.google.com/search?source=dict-chrome-ex&defl=en&hl=en&q={0}&tbo=1&tbs=dfn:1",

           var url ="http://translate.google.com.ua/?hl=ru&tab=wT#en/ru/" +_englishWord;
      _webBrowser.Navigate(url);
      //return;
      //if (_translateForm == null)
      //{
      //  _translateForm = new frmTranslator();
      //  _translateForm.Show(this);
      //}
      //_translateForm._Translate(this.textViewer1._Word);
    }

    private void translateToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (frmTranslator frm = new frmTranslator())
      {
        frm.ShowDialog();
      }
    }

    private void _commandFontMinus_Click(object sender, EventArgs e)
    {
      this.textViewer1.ZoomIn();
    }

    private void _commandFontPlus_Click(object sender, EventArgs e)
    {
      this.textViewer1.ZoomOut();
    }

    private void _commandBFirst_Click(object sender, EventArgs e)
    {
      this.textViewer1.BookmarkFirst();
    }

    private void _commandBPrev_Click(object sender, EventArgs e)
    {
      this.textViewer1.BookmarkPrev();
    }

    private void _commandBNext_Click(object sender, EventArgs e)
    {
      this.textViewer1.BookmarkNext();
    }

    private void _commandBLast_Click(object sender, EventArgs e)
    {
      this.textViewer1.BookmarkLast();
    }

    private void _commandFirstLine_Click(object sender, EventArgs e)
    {
      this.textViewer1.MoveFirstLine();
    }

    private void _commandPrevLine_Click(object sender, EventArgs e)
    {
      this.textViewer1.MovePreviousLine();
    }

    private void _commandNextLine_Click(object sender, EventArgs e)
    {
      this.textViewer1.MoveNextLine();
    }

    private void _commandLastLine_Click(object sender, EventArgs e)
    {
      this.textViewer1.MoveLastLine();
    }

    private void _commandPageUp_Click(object sender, EventArgs e)
    {
      this.textViewer1.MovePageUp();
    }

    private void _commandPageDown_Click(object sender, EventArgs e)
    {
      this.textViewer1.MovePageDown();
    }

    private void _commandMode_Click(object sender, EventArgs e)
    {
      _SelectionModeChange();
    }

    private void _commandKino_Click(object sender, EventArgs e)
    {
      frmTranslator frm = new frmTranslator();
      frm.Show(this);
    }
    protected override void OnKeyDown(KeyEventArgs e)
    {
      if(e.KeyCode == Keys.S && e.Control)
      {
        _saveComments();
      }
      base.OnKeyDown(e);
    }

    private void _commandAddToDictionary_Click(object sender, EventArgs e)
    {
      string s = Properties.Resources.add2dic;
      _webBrowser.DocumentText = s;
    }
    public void Add2Dictionary()
    {
      HtmlElement eng = _webBrowser.Document.GetElementById("eng");
      var syn = _webBrowser.Document.GetElementById("syn");
      var rus = _webBrowser.Document.GetElementById("rus");
      string seng = (eng.DomElement as IHTMLInputElement).value;
      string ssyn = (syn.DomElement as IHTMLInputElement).value;
      string srus = (rus.DomElement as IHTMLTextAreaElement).value;
      _translator.Add(seng, ssyn, srus);
      _webBrowser.DocumentText = _translator.ToHtml();
    }

    private void _commandEditor_Click(object sender, EventArgs e)
    {
      frmComments frm = new frmComments();
      frm._main_form = this;
      frm.LoadFromFile(_broker.CurrentBook.FileName);
      frm.Show(this);
    }
    public void _showHistory()
    {
      _historyLoaded = true;
      this.splitContainer2.SplitterDistance = 20;
      string s = Properties.Resources.history;
      string[] body = s.Split('$');
      string maket = body[1];

      string text = body[0];
      _broker.SortByLastTime();
      for (int i = 0; i < _broker.History.Count; i++)
      {

        BookInfo item = _broker.History[i];
        string tr = maket.Replace("@Author", item.Author);
        tr = tr.Replace("@Title", item.Title);
        tr = tr.Replace("@Comment", item.Comment);
        tr = tr.Replace("@File", item.FileName);
        text += tr;
      }
      text += body[2];
      _webBrowser.DocumentText = text;
      
    }

    public void _conver2Txt(string file)
    {
      RunManager m = new RunManager();
      string txtfile = m.ConverPdf2Txt(file);
      if (txtfile != null) _openFile(txtfile);
    }
    private void _commandHist_Click(object sender, EventArgs e)
    {
      _showHistory();
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
      _showHistory();
    }
    public void _saveBookInfo(string file , string data)
    {
      _broker.SaveBookInfo(file, data);
      _showHistory();
    }
    void _loadScript()
    {
      return;
      HtmlElementCollection heads = _webBrowser.Document.GetElementsByTagName("head");
      HtmlElement head = heads[0];
      HtmlElement script = _webBrowser.Document.CreateElement("script");
      IHTMLScriptElement element = (IHTMLScriptElement)script.DomElement;
      element.text = Properties.Resources.main; //"function sayHello() { alert('hello') }";
      head.AppendChild(script);
      //_webBrowser.Document.InvokeScript("sayHello");
    }
  }//
}
