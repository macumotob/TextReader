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
  public partial class frmHistory : Form
  {
    string _selectedFileName;
    bool _isFileSelected;
    public frmHistory()
    {
      InitializeComponent();
      //
      _listBooks.SelectedIndexChanged += _listBooks_SelectedIndexChanged;
    }
    public string SelectedFileName
    {
      get
      {
        return (_isFileSelected ? _selectedFileName : null);
      }
    }
    void _listBooks_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (_listBooks.SelectedItems == null) return;
      if (_listBooks.SelectedItems.Count != 1) return;
      BookInfo info = (BookInfo)_listBooks.SelectedItems[0].Tag;
      _selectedFileName = info.FileName;
      _broker.SetCurrentBook(_selectedFileName);
      _updateControls();


    }
    private BooksBroker _broker
    {
      get
      {
        return BooksBroker.Instance;
      }
    }
    private BookInfo _book
    {
      get
      {
        return _broker.CurrentBook;
      }
    }
    protected override void OnResize(EventArgs e)
    {
      int w = _listBooks.Width;
      for(int i = 0; i <_listBooks.Columns.Count-1;i++)
      {
        w -= _listBooks.Columns[i].Width;
      }
      _listBooks.Columns[_listBooks.Columns.Count - 1].Width = w - 24;
      base.OnResize(e);
    }
    protected override void OnShown(EventArgs e)
    {
      _broker.SortByLastTime();
      _listBooks.Items.Clear();
      for (int i = 0; i < _broker.History.Count; i++)
      {
        BookInfo item = _broker.History[i];
        ListViewItem li =  _listBooks.Items.Add(item.Author);
        li.Tag = item;
        li.SubItems.Add(item.Title);
        li.SubItems.Add(item.Comment);
        li.SubItems.Add(item.FileName);
      }
      base.OnShown(e);
    }
    private void _updateControls()
    {
      _labelLastTime.Text = _book.LastTime.ToString();
      _textAuthor.Text = _book.Author;
      _textTitle.Text = _book.Title;
      _textFile.Text = _book.FileName;
      _textComment.Text = _book.Comment;
    }
    private void _updateData()
    {
      _book.Author = _textAuthor.Text;
      _book.Title = _textTitle.Text;
      _book.Comment = _textComment.Text;
      _broker.SaveHistory();
    }

    private void _buttonOpen_Click(object sender, EventArgs e)
    {
      if (_selectedFileName == null)
      {
        MessageBox.Show(this, "Select file !");
        return;
      }
      _isFileSelected = true;
      this.Close();
    }

    private void _buttonSave_Click(object sender, EventArgs e)
    {
      _updateData();
    }
  }
}
