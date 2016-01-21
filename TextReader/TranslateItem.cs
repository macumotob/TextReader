using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baybak.TextReader
{
  class TranslateItem
  {
    public string English;
    public string Russian;
    public string Synonim;

    public string ToHtml()
    {
      return "<br/><b>" + this.English + "</b><pre>" + this.Russian +
        (string.IsNullOrEmpty(this.Synonim) ? "" : " Syn:" + this.Synonim) + "</pre>";
    }
  }

  class Persistent<T>
  {
    const char ROW_DELIMITER = (char)1;
    const char FIELD_DELIMITER = (char)2;
    protected List<T> _items = new List<T>();
    protected string _fileName;
    string[] _fieldsOrder;

    public void LoadFromFile(string file, string fieldsOrder)
    {
      _fileName = file;
      _fieldsOrder = fieldsOrder.Split(',');

      if (System.IO.File.Exists(_fileName))
      {
        Type type = typeof(T);
        using (System.IO.StreamReader sr = new System.IO.StreamReader(file, Encoding.UTF8))
        {
          string text = sr.ReadToEnd();
          sr.Close();
          string[] rows = text.Split(ROW_DELIMITER);

          foreach (string row in rows)
          {
            string[] fields = row.Split(FIELD_DELIMITER);
            if (fields.Length == _fieldsOrder.Length)
            {
              T item = Activator.CreateInstance<T>();
              for ( int i = 0 ; i < _fieldsOrder .Length;i++)
              {
               type.GetProperty(_fieldsOrder[i]).SetValue(item,fields[i]);
              }
              _items.Add(item);
            }
          }
        }
      }
    }
    public void Save()
    {
      Type type = typeof(T);
      using (System.IO.StreamWriter sw = new System.IO.StreamWriter(_fileName))
      {
        foreach (T item in _items)
        {
          for (int i = 0; i < _fieldsOrder.Length; i++)
          {
            string pname = _fieldsOrder[i];
            string value = type.GetProperty(pname).GetValue(item).ToString();
            sw.Write(value);
            if(i < _fieldsOrder.Length - 1)  sw.Write(FIELD_DELIMITER);
          }
          sw.Write(ROW_DELIMITER);
        }
      }
    }
  }
  class LinkInfo
  {
    public string HRef {get;set;}
    public string Desc {get;set;}
    public string Host
    {
      get
      {
        string s = this.HRef.Replace("http://", "").Replace("https://","");
        int i =  s.IndexOf('/');
        
        return i == -1 ? s : s = s.Substring(0,i);
      }
    }
  }
  class Links : Persistent<LinkInfo>
  {
    public void LoadFromFile(string file)
    {
      string fieldsOrder = "HRef,Desc";
      base.LoadFromFile(file, fieldsOrder);
    }
    public void Add(string href, string desc)
    {
      if (string.IsNullOrEmpty(href)) return;

      href = href.ToLower();
      LinkInfo item = _items.Find(it => { return it.HRef == href; });
      if (item == null)
      {
        item = new LinkInfo() { HRef = href, Desc = desc };
        _items.Add(item);
      }
      else
      {
        item.Desc = desc;
      }
      Save();
    }
    public string ToHtml()
    {
      string s = "<table style='width:100%;'><caption>LINKS</caption>";
      foreach (LinkInfo info in _items)
      {
        s += "<tr><td><b>" + info.Host + "</b></td>";
        s += "<td><a href='" + info.HRef + "'>" + info.HRef + "</a></td>";
        s += "</tr>";

      }
      return s + "</table>";
    }
  }
  class Translator
  {
    const char ROW_DELIMITER = (char)1;
    const char FIELD_DELIMITER = (char)2;
    List<TranslateItem> _items = new List<TranslateItem>();
    string _fileName;
    public void LoadFromFile(string file)
    {
      _fileName = file;
      if (System.IO.File.Exists(_fileName))
      {
        using (System.IO.StreamReader sr = new System.IO.StreamReader(file, Encoding.UTF8))
        {
          string text = sr.ReadToEnd();
          sr.Close();
          string[] rows = text.Split(ROW_DELIMITER);
          foreach (string row in rows)
          {
            string[] fields = row.Split(FIELD_DELIMITER);
            if (fields.Length == 3)
            {
              TranslateItem item = new TranslateItem() { English = fields[0], Synonim = fields[1], Russian = fields[2] };
              _items.Add(item);
            }
          }
        }
      }
    }
    public void Save()
    {
      using (System.IO.StreamWriter sw = new System.IO.StreamWriter(_fileName))
      {
        foreach(TranslateItem item in _items)
        {
          sw.Write(item.English);
          sw.Write(FIELD_DELIMITER);
          sw.Write(item.Synonim);
          sw.Write(FIELD_DELIMITER);
          sw.Write(item.Russian);
          sw.Write(ROW_DELIMITER);
        }
      }
    }

    public List<TranslateItem> Translate(string english)
    {
      List<TranslateItem> result = _items.FindAll(it => { return it.English == english; });
      return result;
    }
    public string ToHtml()
    {
      string s = "";
      _items.Sort((a,b) => { return string.Compare(a.English,b.English);});
      foreach(var item in _items)
      {
        s += item.ToHtml();
      }
      return s;
    }
    public void Add(string english,string synonim,string russion)
    {
      if (string.IsNullOrEmpty(english)) return;

      english = english.ToLower();
      TranslateItem item = _items.Find( it => { return it.English == english; });
      if(item == null)
      {
        item = new TranslateItem() { English = english, Synonim = synonim, Russian = russion };
        _items.Add(item);
      }
      else
      {
        item.Synonim = synonim;
        item.Russian = russion;
      }
      Save();
    }
  }
}
