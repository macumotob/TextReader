using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Baybak.TextReader
{
 // using Baybak.Data.Broker;
  using Baybak.GUI;

  public partial class BookList : VirtualScroller
  {
    public BooksBroker _Broker;

    public BookList()
    {
      InitializeComponent();
      _ItemHeight = 50;
    }
    
    public override int _Count
    {
      get
      {
        return (_Broker == null ? 0 : _Broker.Count);
      }
    }
    
    private Font _FontAutor = new Font("Georgia", 9);
    private Font _FontTitle = new Font("Georgia", 12);
    private Pen _PenBorder = new Pen(Brushes.Orange, 3);


    protected override void _DrawItem(Graphics g, int index, int y)
    {
      //base._DrawItem(g,  index,  y);      return;

      //this._Broker.LoadItem(index);
      _Broker.Index = index;
      BookItem item = _Broker.Current;
      int x = 4;
      g.DrawRectangle(this._PenBorder, x, y, _Width - 2 * x, this._ItemHeight);
      g.FillRectangle(Brushes.Khaki, x + 1, y + 1, _Width - 2 * x-1, this._ItemHeight-1);

      x += 3;
      g.DrawString(item.Author, this._FontAutor , Brushes.Black, x, y);

      SizeF size = g.MeasureString(item.Author, this._FontAutor);
      x += (int)size.Width + 20;
      g.DrawString(item.Title, this._FontTitle, Brushes.Blue, x, y);

      size = g.MeasureString(item.Author, this._FontTitle);
      if (index == this._SelectedIndex)
      {
        g.FillEllipse(Brushes.WhiteSmoke, _Width - 35, y + 5, 20, 20);
        g.DrawEllipse(this._PenBorder, _Width - 35, y + 5, 20, 20);
      }
    }
  }
}
