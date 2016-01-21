using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baybak.TextReader
{
  public class Word
  {
    public string English;
    public string Russian;

    public List<string> Variants;
    public int Count;
    public Word(string en, string ru)
    {
      this.English = en;
      this.Russian = ru;
      this.Count = 0;
    }
    public Word(string en)
    {
      this.English = en;
      this.Count = 1;
    }
    public void AddVariants(string text)
    {
      if (this.Variants == null)
      {
        this.Variants = new List<string>();
      }
      this.Variants.Add(text); 
    }
    public override string ToString()
    {
      return this.English + " " + this.Count.ToString();
    }
  }
}
