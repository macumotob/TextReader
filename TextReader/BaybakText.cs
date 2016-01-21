using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Baybak.TextReader
{
  class BaybakText
  {
    public Guid Id;
    public List<string> Words = new List<string>();
    public List<int> LineWordsIndex = new List<int>();

    private string _Text;

    public string Text
    {
      get { return _Text; }
      set 
      {
        this.Clear();
        _Text = value;
        this.MakeWords();
      }
    }
    // использовать только для расчетов
    private Graphics _graphics;
    public Graphics _Graphics
    {
      set
      {
        if (_graphics != null)
        {
          _graphics.Dispose();
          _graphics = null;
        }
        _graphics = value;
      }
    }
    private int _FirstVisibleLine;
    public int FirstVisibleLine
    {
      get
      {
        return this._FirstVisibleLine;
      }
      set
      {
        this._FirstVisibleLine = value;
        if (this._FirstVisibleLine > this.LineWordsIndex.Count - 1)
        {
          this._FirstVisibleLine = this.LineWordsIndex.Count - 1;
        }
        if (this._FirstVisibleLine < 0)
        {
          this._FirstVisibleLine = 0;
        }
      }
    }

    public int ParagraphOffset = 150;

    public SizeF _Size;

    public SizeF GetWordSize(string word,Font font,StringFormat format)
    {
      _Size = _graphics.MeasureString(word, font, -1, format);
      if (word == " ")
      {
        _Size.Width = 7.0f;
      }
      else if (word == ".")
      {
        _Size.Width = 20.0f;
      }
      return _Size;
    }


    public int GetWordUnderCursor(Point mouse, int top, int left, Font font, StringFormat format)
    {
      if (_Size.Height == 0)
      {
        return -1;
      }
      //int offset = (mouse.Y - this._Borders.Text.Y) / (int)_size.Height;
      int offset = (mouse.Y - top) / (int)_Size.Height;
      int line = this.FirstVisibleLine + offset;
      if (line == -1)
      {
        return -1;
      }
      bool isParagraph = (0 < line && this.IsParagraph(line - 1));
      //int x = (int)mouse.X - this._Borders.Text.Left - (isParagraph ? this._ParagraphOffset : 0);
      int x = (int)mouse.X - left - (isParagraph ? this.ParagraphOffset : 0);

      int i = this.LineWordsIndex.Count == 0 ? 0 :  this.LineWordsIndex[line];
      int to = this.LastWordIndex(line);
      int x1 = 0;
      int x2 = 0;
      while (i <= to && this.Words.Count > 0)
      {
        x2 = x1 + (int)this.GetWordSize(this.Words[i],font,format).Width;
        if (x1 <= x && x <= x2)
        {
          return i;
        }
        x1 = x2;
        i++;
      }
      return -1;
    }
    public void FormatText(Font font, StringFormat format,int textWidth)
    {
      this.LineWordsIndex.Clear();
      if (this.Words.Count == 0)
      {
        return;
      }

      this.LineWordsIndex.Add(0);
      float width = 0;
      int i = 0;

      while (i < this.Words.Count)
      {
        if (this.Words[i] == null)
        {
          this.LineWordsIndex.Add(i++);
          if (i >= this.Words.Count)
          {
            break;
          }
          this.LineWordsIndex.Add(i);
          _Size = this.GetWordSize(this.Words[i],font, format);
          width = _Size.Width + this.ParagraphOffset;
        }
        else
        {
          _Size = this.GetWordSize(this.Words[i], font, format);
          if (width + _Size.Width <= textWidth) //this._Borders.Text.Width)
          {
            width += _Size.Width;
          }
          else
          {
            if (this.Words[i] == " ") // строка начинается с пробела
            {
              i++; // пропускаем пробел
              this.LineWordsIndex.Add(i);
              _Size = this.GetWordSize(this.Words[i], font, format);
              width = _Size.Width;
            }
            else
            {
              this.LineWordsIndex.Add(i);
              width = _Size.Width;
            }
          }
          i++;
        }
      }
    }


    public void LoadFromFile(string fileName)
    {
      this.LoadFromFile(fileName, Encoding.UTF8);
    }

    private void MakeWords()
    {
      this.Words = Parser.GetAllWords(this.Text);
      this.ValidateParagraphs();
    }
    private void Clear()
    {
      this._Text = null;
      this.LineWordsIndex.Clear();
      this.Words.Clear();
    }
    public void LoadFromFile(string fileName,Encoding encoding)
    {
      this.Clear();
      if (System.IO.File.Exists(fileName))
      {
        this.Text = System.IO.File.ReadAllText(fileName, encoding);
      }
    }
    public void InsertParagraph(int beforeWordIndex)
    {
      this.Words.Insert(beforeWordIndex, null);
    }
    private void ValidateParagraphs()
    {
      int i = 0;
      while (i < this.Words.Count)
      {
        string prev = ( i-1 < 0 ? " " : this.Words[i-1]);
        string next = ( i+1 >= this.Words.Count ? " " : this.Words[i+1]);
        if (this.Words[i] == "\n" || ( this.Words[i].Length > 0 && this.Words[i][0] == '\r'))
        {
          if (next == "\n")
          {
            this.Words[i] = null; // paragraph
            i++;
            while (i < this.Words.Count && this.Words[i] == "\n")
            {
              this.Words.RemoveAt(i);
            }
            continue;
          }
          if (next.Length >0 && next[0] == ' ')
          {
            this.Words[i] = null; // paragraph
            i++;
            continue;
          }
          this.Words[i] = " ";
        }
          /*
        else if (this.Words[i] == " " && next == "\n")
        {
          this.Words[i] = null; // paragraph
          i++;
          while (i < this.Words.Count && this.Words[i] == "\n")
          {
            this.Words.RemoveAt(i);
          }
          continue;
        }*/
        i++;
      }
    }
    public int LastWordIndex(int lineIndex)
    {
      if (this.Words.Count == 0)
      {
        return 0;
      }
      int firstIndex = this.LineWordsIndex[lineIndex];
      int lastIndex = (lineIndex + 1 < this.LineWordsIndex.Count ? this.LineWordsIndex[lineIndex + 1] - 1 : this.Words.Count - 1);

      return lastIndex;
    }

    public bool IsParagraph(int lineIndex)
    {
      if (lineIndex >= this.LineWordsIndex.Count)
      {
        return true;
      }
      return this.Words[this.LineWordsIndex[lineIndex]] == null;
    }
    public string GetText(int lineIndex)
    {
      if (this.Words.Count == 0)
      {
        return "";
      }
      string s = "";


      int firstIndex = this.LineWordsIndex[lineIndex];
      string word = this.Words[firstIndex];

      if (word == null)
      {
        return null;
      }

      int lastIndex = (lineIndex+1 < this.LineWordsIndex.Count ?
        this.LineWordsIndex[lineIndex + 1] - 1 : this.Words.Count - 1);

      for (int i = firstIndex; i <= lastIndex; i++)
      {
        if (this.Words[i] == null)
        {
          break;
        }
        s += this.Words[i];
      }
      return s;
    }
    public string GetText(int fromIndex,int toIndex)
    {

      if (this.Words.Count == 0 || fromIndex == -1 ||  toIndex == -1)
      {
        return "";
      }
      string s = "";
      int i = fromIndex;
      while( i <= toIndex && i < this.Words.Count)
      {
        if (this.Words[i] == null)
        {
          s += " ";
        }
        s += this.Words[i];
        i++;
      }
      return s;
    }
    public int GetLineIndexByWordIndex(int wordIndex)
    {
      if (this.LineWordsIndex.Count == 0)
      {
        return 0;
      }
      for (int i = 0; i < this.LineWordsIndex.Count - 1; i++)
      {
        int first = this.LineWordsIndex[i];
        int last = this.LineWordsIndex[i+1] - 1;
        if (first <= wordIndex && wordIndex <= last)
        {
          return i;
        }
      }
      return this.LineWordsIndex.Count - 1;
    }
  }
}
