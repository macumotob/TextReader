using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Baybak.TextReader
{
  public delegate void EventEnglishWord(string text);

  public class Words
  {
    static private List<string> _words = new List<string>();

    static public void ReadMullerDictionary(string file, EventEnglishWord onword)
    {

      string[] lines = System.IO.File.ReadAllLines(file, Encoding.GetEncoding(1251));
      string text = "";
      int i = 10;
      const int BeginningOfNames = 119345;
      while (i < lines.Length && i < BeginningOfNames)
      {

        string s = lines[i];
        if (s.Length == 0)
        {
          i++;
          continue;
        }
        text = "";
        if (s[0] == ' ' || s[0] == '\t')
        {
          text = s;
          if (IsNextNewWord(ref lines, i + 1))
          {
            onword(text);
            i++;
          }
          else
          {
            while (!IsNextNewWord(ref lines, i + 1))
            {
              i++;
              text += " " + lines[i];
            }
            onword(text);
            i++;
          }
        }
        else
        {

        }
      }
      // parse names
    }

    static public void LoadMullerDictionary()
    {
      _words.Clear(); 
      string file = Application.StartupPath + "\\aemuller.txt";
      Words.ReadMullerDictionary(file, (word) => 
      {
        _words.Add(word.Trim());
      });
    }

    static private List<string> _find(string word)
    {
      //return  _words.FindAll((w) => { return w.IndexOf(word, StringComparison.InvariantCultureIgnoreCase) >= 0; });
      return _words.FindAll((w) => { return w.IndexOf(word, StringComparison.InvariantCultureIgnoreCase) == 0; });
    }
    static private List<string> _findVariants(string word)
    {
      string[] data = {"ied","y","ed", "", "s", "", "es", "e", "er","e" ,"ies","y","ance","e", "ing","","ous","", "ly","","ness",""};
      for (int i = 0; i < data.Length; i += 2)
      {
        string sufix = data[i];
        int pos = word.LastIndexOf(sufix, StringComparison.InvariantCultureIgnoreCase);
        if (pos > 0 && (pos + sufix.Length) == word.Length)
        {
          string s = word.Substring(0, word.Length - sufix.Length) + data[i+1];
          List<string> res = _find(s);
          if(res.Count > 0)
          {
            return res;
          }
        }
      }
      return new List<string>();
    }
    static public void Translate(string word, out List<string> result, out List<string> result2)
    {
      result = result2 = new List<string>();
      if(string.IsNullOrEmpty(word) || string.IsNullOrWhiteSpace(word))
      {
        return;
      }
      result2 =  _words.FindAll((w) => { return w.IndexOf(word, StringComparison.InvariantCultureIgnoreCase) == 0; });
      if (result2.Count == 0)
      {
          result2 = _findVariants(word);
      }
      else if (result2.Count == 1)
      {
        List<string> r = _findVariants(word);
        foreach(string w in r)
        {
          result2.Add(w);
        }
      }
      else
      {
        result = result2.FindAll((w) => { return w.IndexOf(word, StringComparison.InvariantCultureIgnoreCase) == 0; });
      }
    }
    static private  bool IsNextNewWord(ref string[] lines, int i)
    {
      if (i >= lines.Length)
      {
        return true;
      }
      string s = lines[i];
      if (s.Length == 0)
      {
        return true;
      }
      return (s[0] == ' ' || s[0] == '\t');
    }
  }//
}
