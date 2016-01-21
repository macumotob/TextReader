using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Baybak.Data.Broker;

namespace Baybak.TextReader
{


  public partial class frmBookInfo : Form
  {

    public frmBookInfo()
    {
      InitializeComponent();
    }

    private bool _AddNewBookMode;
    public frmBookInfo(BooksBroker broker, bool addNew)
    {
      InitializeComponent();
      _AddNewBookMode = addNew;
      _Broker = broker;

      if (addNew)
      {
        
      }
      else
      {
        if (_Broker.SelectedItem != null)
        {
          _Broker.LoadText(_Broker.SelectedItem);
          _Title = _Broker.SelectedItem.Title;
          _Authors = _Broker.SelectedItem.Author;
          _Notes = _Broker.SelectedItem.Text;
          cmdAdd.Text = "Save";
        }
      }
    }
    BooksBroker _Broker;

    public string _Title
    {
      get
      {
        return this._txtTitle.Text;
      }
      set
      {
        this._txtTitle.Text = value;
      }
    }
    public string _Authors
    {
      get
      {
        return this._txtAuthors.Text;
      }
      set
      {
        this._txtAuthors.Text = value;
      }
    }
    public string _Notes
    {
      get
      {
        return this._txtNotes.Text;
      }
      set
      {
        this._txtNotes.Text = value;
      }
    }

    private void cmdAdd_Click(object sender, EventArgs e)
    {

      if (_AddNewBookMode)
      {
        BookItem item = new BookItem(this._Title, this._Authors, this._Notes);
        _Broker.Save(item);
      }
      else
      {
        if (_Broker.SelectedItem == null)
        {
          BookItem item = new BookItem(this._Title, this._Authors, this._Notes);
          _Broker.Save(item);
        }
        else
        {
          _Broker.SelectedItem.Text = _Notes;
          _Broker.SelectedItem.Author = _Authors;
          _Broker.SelectedItem.Title = _Title;
          _Broker.Save(_Broker.SelectedItem);
        }
      }
      this.Close();
    }
  }
}
