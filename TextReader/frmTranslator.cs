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
//  using Baybak.Data.Broker;
  [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
  [System.Runtime.InteropServices.ComVisibleAttribute(true)]

  public partial class frmTranslator : Form
  {
    Links _links = new Links();
    ZipReader _zipper = new ZipReader();

    //HtmlElement _textSource;
    public frmTranslator()
    {
      InitializeComponent();
     // _browser.ScriptErrorsSuppressed = true;
      _browser.ObjectForScripting = this;

      _browser.DocumentCompleted += _browser_DocumentCompleted;
      _browser.Navigating += _browser_Navigating;
      
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
    public string _getText()
    {
      string text = System.IO.File.ReadAllText(_book.FileName, Encoding.UTF8);
      return text;
    }
    private bool _dontNavigate(string s)
    {
      string[] urls = { "http://vk.com/" };

      for(int i = 0;i <urls.Length;i++)
      {
        if (s.IndexOf(urls[i], StringComparison.InvariantCultureIgnoreCase) >= 0) return true;
      }
      return false;
    }

    protected override void OnShown(EventArgs e)
    {
      _zipper.Load();
      string s = "<table width='100%'><tr><td valign='top'><table width='10%'>";
      Dictionary<char, int> dic = _zipper.GetChars();
      foreach (char c in dic.Keys)
      {
        s += "<tr onclick=\"window.external.ShowBooks(\'" + c + "\');\"><td>" + c + "</td><td>" + dic[c].ToString() + "</td></tr>";
      }
      s += "</table width='90%'></td><td valign='top'><div style='width:100%;' id='bist'>555</div></td></tr></table>";
      _browser.DocumentText = s;

      //_links.LoadFromFile(Application.StartupPath + "\\links.data");
      //_browser.Navigate("http://kinogo.co/5712-shtamm-2-sezon.html");
      //_browser.Navigate("file://E:/github/TextReader/TextReader/html/canvas.html");
      base.OnShown(e);
    }
    void _browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
    {
      if (_links != null)
      {
        string s = e.Url.ToString().ToLower();
        e.Cancel = _dontNavigate(s);
        if (!e.Cancel)
        {
         // _links.Add(s, "");
        }
      }
    }



    void _browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
   //   string[] elements = { "gbq1","gb", "gba", "gt-ft-res", "gt-ft"  ,"gt-appbar","gt-bbar-c",
   //                         "gt-langs","gb_Va","gt-logo","gt-logo-icon"};
   //   foreach (string id in elements)
   //   {
   //     var element = _browser.Document.GetElementById(id);
   //     if (element != null) element.InnerHtml = "";
   //   }
   //_textSource = _browser.Document.GetElementById("source");
    }
    protected override void OnClosing(CancelEventArgs e)
    {
     // e.Cancel = !this._CanClose;
      base.OnClosing(e);
    }
    public bool _CanClose = false;

    //public void _Translate(string word)
    //{
    //  if (_textSource == null)
    //  {
    //    string url = "http://translate.google.com.ua/?hl=ru&tab=wT#en/ru/" + word.Replace(" ", "%20");
    //    _browser.Navigate(url);
    //  }
    //  else
    //  {
    //    _textSource.InnerText = word;
    //  }
    //}

    private void _cmdTrans_Click(object sender, EventArgs e)
    {
      _browser.Navigate(_txtWord.Text);

    }

    private void _txtWord_KeyDown(object sender, KeyEventArgs e)
    {
      if(e.KeyCode == Keys.Enter)
      {
        _browser.Navigate(_txtWord.Text);
      }
    }

    private void _commandBack_Click(object sender, EventArgs e)
    {
      _browser.GoBack();
    }

    private void _commandHrefs_Click(object sender, EventArgs e)
    {
      _browser.DocumentText = _links.ToHtml();
    }

    private void _commandCanvas_Click(object sender, EventArgs e)
    {
      _browser.DocumentText = Properties.Resources.canvas;
    }
    public void ShowBooks(string c)
    {
        HtmlElement div = _browser.Document.GetElementById("bist");
      string s="";
      List<BibInfo>list=    _zipper.GetBooks(c[0]);

      foreach (BibInfo info in list)
      {
        s += "<p onclick='window.external.openFromZip(\"" + info.FileName +
          "\",\"" + info.FileId + "\")'>" + info.Author + "<b>" + info.Title + "</b></p>";
      }
      div.InnerHtml=s;
      //string div = (eng.DomElement as IHTMLDivElement);
    }
    public void openFromZip(string zipFile, string file)
    {
      _zipper.OpenFromZip(zipFile, file);
    }
    private void _cmdLib_Click(object sender, EventArgs e)
    {

    }
  }
}
