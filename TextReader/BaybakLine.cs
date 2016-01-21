using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baybak.TextReader
{
  class BaybakLine
  {

    public BaybakLine(string text)
    {
      this._Text = text;
    }
    private List<BaybakLine> _Childs;

    internal List<BaybakLine> Childs
    {
      get 
      {
        if (this._Childs == null)
        {
          this._Childs = new List<BaybakLine>();
        }
        return _Childs; 
      }
      set 
      {
        _Childs = value; 
      }
    }

    private string _Text;

    public string Text
    {
      get { return _Text; }
      set { _Text = value; }
    }
    public override string ToString()
    {
      return this.Text;
    }
  }
}
