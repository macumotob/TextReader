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
    private string _file_name;

    public frmTranslator _main_form;
    public frmComments()
    {
      InitializeComponent();
      _editor.OnWordSelected += _editor_OnWordSelected;
    }

    private void _editor_OnWordSelected(string word)
    {
    //  this.Text = word;
      RunManager.Manager.Speek(word);
      _main_form._show_translation_result(word);

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
      _editor.Save();
    }
    protected override void OnClosed(EventArgs e)
    {
      _saveFile();

      base.OnClosed(e);
    }
    public void LoadFromFile( string file)
    {
      this.Text = _file_name = file;

      _editor.LoadFromFile(file);
    }
  }
}
