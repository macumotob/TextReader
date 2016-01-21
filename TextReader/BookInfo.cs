using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baybak.TextReader
{
  public class BookInfo
  {
    private string fileName;
    public string FileName
    {
      get
      {
        return fileName;
      }
      set
      {
        fileName = value.Replace('\\', '/');
      }
    }
    public string Title {get;set;}
    public string Author { get; set; }
    public int WordIndex;
    public List<int> Bookmarks = new List<int>();
    public DateTime LastTime;
    public string Comment { get; set; }
  }
}
