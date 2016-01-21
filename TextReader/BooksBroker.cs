using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baybak.TextReader
{
  public class BooksBroker
  {
    static public BooksBroker Instance = new BooksBroker();
    private List<BookInfo> _history = new List<BookInfo>();

    public BookInfo CurrentBook;

    private string _historyFileName
    {
      get
      {
        return AppDomain.CurrentDomain.BaseDirectory + "\\history.txt";
      }
    }
    public List<BookInfo> History
    {
      get
      {
        return _history;
      }
    }
    public void LoadHistory()
    {
      _history.Clear();
      if (System.IO.File.Exists(_historyFileName))
      {
        BookInfo info = null;
        string[] lines = System.IO.File.ReadAllLines(_historyFileName, Encoding.UTF8);
        foreach (string s in lines)
        {
          int i = s.IndexOf(' ');
          if (i == -1) continue;
          string tag = s.Substring(0, i );
          string value = s.Substring(i + 1);
          switch (tag)
          {
            case "file":
              info = new BookInfo() { FileName = value };
              if (System.IO.File.Exists(info.FileName))
              {
                _history.Add(info);
              }
              break;
            case "bookmarks":
              {
                info.Bookmarks = new List<int>();
                string[] marks = value.Split(' ');
                for (int k = 0; k < marks.Length; k++)
                {
                  if (string.IsNullOrEmpty(marks[k])) continue;
                  info.Bookmarks.Add(int.Parse(marks[k]));
                }
              }
              break;
            case "wordindex":
              info.WordIndex = int.Parse(value);
              break;
            case "lasttime":
              info.LastTime = DateTime.Parse(value);
              break;
            case "title":
              info.Title = value;
              break;
            case "author":
              info.Author = value;
              break;
            case "comment":
              info.Comment = value;
              break;
          }
        }
      }
      if(_history.Count > 0)
      {
        this.CurrentBook = _history[0];
      }
    }
    public void SaveHistory()
    {
      using (System.IO.StreamWriter sw = new System.IO.StreamWriter(_historyFileName,false, Encoding.UTF8))
      {
        foreach (BookInfo info in _history)
        {
          sw.WriteLine(string.Format("file {0}",info.FileName));
          string s = "";
          for (int i = 0; i < info.Bookmarks.Count;i++ )
          {
            s += " " + info.Bookmarks[i].ToString();
          }
          sw.WriteLine(string.Format("bookmarks {0}", s));
          sw.WriteLine(string.Format("wordindex {0}", info.WordIndex));
          sw.WriteLine(string.Format("lasttime {0}", info.LastTime));
          sw.WriteLine(string.Format("title {0}", info.Title == null ? "?" : info.Title));
          sw.WriteLine(string.Format("author {0}", info.Author == null ? "?" : info.Author));
          sw.WriteLine(string.Format("comment {0}", info.Comment == null ? "?" : info.Comment));
        }
        sw.Close();
        sw.Dispose();
      }
    }
    public void Add(string fileName)
    {
      fileName = fileName.Replace('\\', '/');
      BookInfo info = _history.Find((book) => { return book.FileName.Equals(fileName, StringComparison.InvariantCultureIgnoreCase); });
      if(info == null)
      {
        info = new BookInfo();
        info.FileName = fileName;
        _history.Add(info);
      }
      this.SetCurrentBook(fileName);
      this.SaveHistory();
    }
    public int Count
    {
      get
      {
        return _history.Count;
      }
    }
    public string this[int index]
    {
      get
      {
        return _history[index].FileName;
      }
    }
    public BookInfo SetCurrentBook(string fileName)
    {
      this.CurrentBook = _history.Find((book) => { return book.FileName.Equals(fileName, StringComparison.InvariantCultureIgnoreCase); });
      this.CurrentBook.LastTime = DateTime.Now;
      return this.CurrentBook;
    }
    public void SortByLastTime()
    {
      _history.Sort((b1,b2) => { return (b1.LastTime == b2.LastTime ? 0 : (b1.LastTime > b2.LastTime ? -1 : 1)); });
      //_history.OrderBy<BookInfo,BookInfo>((b1,b2) => { return b1.LastTime.CompareTo(b2.LastTime); });
    }

    public void SaveBookInfo(string file, string data)
    {
      string fileCurrent = this.CurrentBook.FileName;
      this.SetCurrentBook(file);
      string[] items = data.Split(';');
      Type t = typeof(BookInfo);
      foreach (var item in items)
      {
        string[] itemdata = item.Split(':');
        System.Reflection.PropertyInfo p = t.GetProperty(itemdata[0]);
        p.SetValue(this.CurrentBook, itemdata[1]);
      }
      SaveHistory();
      SetCurrentBook(fileCurrent);
    }

  }

  //public class DictionaryBroker
  //{

  //}
}
