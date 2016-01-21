using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baybak.TextReader
{
  class WordInfo
  {
    public string Word;
    public int Count;
 //   public float Frequency;
    public float Percent;
    public WordInfo(string word)
    {
      this.Count = 1;
      this.Word = word;
    }
    public override string ToString()
    {
      return this.Word + " " + this.Count.ToString() + " " + this.Percent.ToString();
    }
  }
  class Parser
  {
    
    private int Length;
    
    //public void Parse(string file)
    //{
    //  string text = System.IO.File.ReadAllText(file);

    //  Dictionary<string, WordInfo> words = new Dictionary<string, WordInfo>();
    //  Length = text.Length;
    //  int i = 0;
    //  string word ;

    //  while ((word = Parser.GetWord(text, ref i)) != null)
    //  {
    //    word = word.ToLower();
    //    if (word.Length == 0 || word.Length == 1)
    //    {
    //      continue;
    //    }
    //    Words.Add2All(word);
    //  }
    //}
    private void AnalyzeWords(ref Dictionary<string, WordInfo> words)
    {
      int max = 0;
      float total = 0.0f;
      foreach (string key in words.Keys)
      {
        total += words[key].Count;
        if (words[key].Count > max)
        {
          max = words[key].Count;
        }
      }
      foreach (string key in words.Keys)
      {
        words[key].Percent = words[key].Count * 100.0f / total;
      }

      System.Linq.IOrderedEnumerable<System.Collections.Generic.KeyValuePair<string,WordInfo>>
        items =
         words.OrderByDescending(item => item.Value.Count  );

      
      
    }
    public static bool IsEnglishWord(string word)
    {
      if (word == null || word.Length == 0)
      {
        return false;
      }
      int i = 0;
      int minC = (int)'A';
      int maxC = (int)'z';
      while (i < word.Length)
      {
        int  c = (int)word[i];
        if (c < minC || c > maxC )
        {
          return false;
        }
        i++;
      }
      return true;
    }
    public static char GetFirstChar(string s, ref int i)
    {
      while (i < s.Length && (s[i] == ' ' || s[i] == '\t'))
      {
        i++;
      }
      if (i < s.Length)
      {
        return s[i];
      }
      return (char)0;
    }
    public static string GetWord(string s, ref int i)
    {
      string word = "";
      while(i < s.Length && !Char.IsLetter(s[i]))
      {
        word += s[i++];
      }
      word = "";
      while (i < s.Length && Char.IsLetter(s[i]))
      {
        word += s[i++];
      }
      if (word.Length > 0)
      {
        return word;
      }
      return null;
    }
    delegate bool CheckChar(char c);
    static private int GetToken(string s, ref int i, ref List<string> words, CheckChar func, bool ifTrue)
    {
      if (i == -1)
      {
        return i;
      }
      string word = "";
      if (ifTrue)
      {
        while (i < s.Length && func(s[i]))
        {
          word += s[i++];
        }
      }
      else if (!ifTrue)
      {
        while (i < s.Length && !func(s[i]))
        {
          word += s[i++];
        }
      }
      else
      {
      }
      if (word.Length > 0)
      {
        words.Add(word);
      }
      return i < s.Length ? i : -1;
    }
    static private bool GetToken(string s, ref int i, ref List<string> words, string mask)
    {
      if (i == -1)
      {
        return false;
      }
      string word = "";
      if (mask.IndexOf(s[i]) != -1)
      {
        while (i < s.Length && mask.IndexOf(s[i]) != -1)
        {
          if (s[i] == '\t')
          {
            //word += " ";
          }
          else
          {
            word += s[i];
          }
          i++;
        }
        words.Add(word);
        i = (i < s.Length ? i : -1);
        return true;
      }
      return false;
    }
    static public List<string> GetAllWords(string s)
    {

      List<string> list = new List<string>();
      if (s == null)
      {
        return list;
      }
      int i = 0;
      int prev = -1;
      while (i != -1 && i < s.Length )
      {
        if (prev == i)
        {
          char c = s[i];
          if (c == '―' || c == '‖' || c == '–' || c == '…' || c == '”' || c == '“'
            || c == '’' || c == '—')
          {
            list.Add("" + c);
            i++;
            continue;
          }
          else
          {
            list.Add("" + c);
            i++;
            continue;
          }
        }
        prev = i;
        if (s[i] == '\n')
        {
          list.Add("\n");
          i++;
          continue;
        }
        if (s[i] == '\r')
        {
          i++;
          continue;
        }
        if (Parser.GetToken(s, ref i, ref list, " \t\v"))
        {
          continue;
        }
        if (Parser.GetToken(s, ref i, ref list, ".,~`!@#$%^&*()_-+={[]}\'\";:/?<>"))
        {
          continue;
        }
        if (Parser.GetToken(s, ref i, ref list, "0123456789"))
        {
          continue;
        }
       // i = Parser.GetToken(s, ref i, ref list, char.IsLetter, false);
        i = Parser.GetToken(s, ref i, ref list, char.IsLetter, true);
      }
      return list;
    }

  }
}
