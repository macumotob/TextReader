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
  public partial class frmComments : Form
  {
    private string _fileName;

    public frmComments()
    {
      InitializeComponent();

    }

    void _textContent_KeyDown(object sender, KeyEventArgs e)
    {
      if(e.Control && e.KeyCode == Keys.S)
      {
        _saveFile();
      }
    }

    private void _saveFile()
    {
    }
    protected override void OnClosed(EventArgs e)
    {
      _saveFile();

      base.OnClosed(e);
    }
    public void LoadFromFile( string file)
    {
      textEditControl1.LoadFromFile(file);
    }
  }
}
