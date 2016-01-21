using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Baybak.TextReader
{
 // using Baybak.Data.Broker;
  using Baybak.GUI;

  public partial class frmBooksInfo : Form
  {
//    BookItem _Book;
    BooksBroker _Broker;

    public frmBooksInfo(BooksBroker broker)
    {
      _Broker = broker;
      InitializeComponent();
      this._BookList._OnIndexSelected +=new EventIndexSelected(_BookList_OnBookIndexSelected);
    }
    public Guid _BookId;

    protected override void OnShown(EventArgs e)
    {
     // _Broker.Refresh();
      _BookList._Broker = this._Broker;
      base.OnShown(e);
    }
    protected override void OnClosed(EventArgs e)
    {
      base.OnClosed(e);
    }
    private void cmdAdd_Click(object sender, EventArgs e)
    {
      using (frmBookInfo frm = new frmBookInfo(_Broker,true))
      {
        frm.ShowDialog(this);
      }
    }

    private void _BookList_OnBookIndexSelected(int index)
    {
      _Broker.Index = index;
      _BookId = _Broker.Current.Id;
    }

    private void cmdEdit_Click(object sender, EventArgs e)
    {
      _Broker.LoadItem(_BookId);
      _Broker.LoadCurrentBookContent();
    //  _Broker.SelectedItem = _Broker.Current.Clone(); 
      using (frmBookInfo frm = new frmBookInfo(_Broker,false ))
      {
        frm.ShowDialog(this);
      }
    }
  }
}
