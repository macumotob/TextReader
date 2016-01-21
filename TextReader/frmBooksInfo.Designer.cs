namespace Baybak.TextReader
{
  partial class frmBooksInfo
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.cmdEdit = new System.Windows.Forms.Button();
      this.cmdAdd = new System.Windows.Forms.Button();
      this.cmdOpen = new System.Windows.Forms.Button();
      this._BookList = new Baybak.TextReader.BookList();
      this.SuspendLayout();
      // 
      // cmdEdit
      // 
      this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cmdEdit.Location = new System.Drawing.Point(607, 368);
      this.cmdEdit.Name = "cmdEdit";
      this.cmdEdit.Size = new System.Drawing.Size(123, 23);
      this.cmdEdit.TabIndex = 1;
      this.cmdEdit.Text = "Edit";
      this.cmdEdit.UseVisualStyleBackColor = true;
      this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
      // 
      // cmdAdd
      // 
      this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cmdAdd.Location = new System.Drawing.Point(478, 368);
      this.cmdAdd.Name = "cmdAdd";
      this.cmdAdd.Size = new System.Drawing.Size(123, 23);
      this.cmdAdd.TabIndex = 2;
      this.cmdAdd.Text = "Add";
      this.cmdAdd.UseVisualStyleBackColor = true;
      this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
      // 
      // cmdOpen
      // 
      this.cmdOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cmdOpen.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.cmdOpen.Location = new System.Drawing.Point(349, 368);
      this.cmdOpen.Name = "cmdOpen";
      this.cmdOpen.Size = new System.Drawing.Size(123, 23);
      this.cmdOpen.TabIndex = 3;
      this.cmdOpen.Text = "Open";
      this.cmdOpen.UseVisualStyleBackColor = true;
      // 
      // _BookList
      // 
      this._BookList._Count = 0;
      this._BookList._FirstVisibleIndex = 0;
      this._BookList._SelectedIndex = 0;
      this._BookList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._BookList.BackColor = System.Drawing.Color.White;
      this._BookList.Location = new System.Drawing.Point(8, 12);
      this._BookList.Name = "_BookList";
      this._BookList.Size = new System.Drawing.Size(722, 350);
      this._BookList.TabIndex = 6;
      // 
      // frmBooksInfo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(742, 403);
      this.Controls.Add(this._BookList);
      this.Controls.Add(this.cmdOpen);
      this.Controls.Add(this.cmdAdd);
      this.Controls.Add(this.cmdEdit);
      this.Name = "frmBooksInfo";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "frmBooksInfo";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button cmdEdit;
    private System.Windows.Forms.Button cmdAdd;
    private System.Windows.Forms.Button cmdOpen;
    private BookList _BookList;
  }
}