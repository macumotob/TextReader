namespace Baybak.TextReader
{
  partial class frmBookInfo
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
      this.label1 = new System.Windows.Forms.Label();
      this._txtTitle = new System.Windows.Forms.TextBox();
      this.cmdAdd = new System.Windows.Forms.Button();
      this._txtAuthors = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this._txtNotes = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 10);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(27, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Title";
      // 
      // _txtTitle
      // 
      this._txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._txtTitle.Location = new System.Drawing.Point(110, 7);
      this._txtTitle.Name = "_txtTitle";
      this._txtTitle.Size = new System.Drawing.Size(366, 20);
      this._txtTitle.TabIndex = 1;
      // 
      // cmdAdd
      // 
      this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cmdAdd.Location = new System.Drawing.Point(197, 311);
      this.cmdAdd.Name = "cmdAdd";
      this.cmdAdd.Size = new System.Drawing.Size(82, 23);
      this.cmdAdd.TabIndex = 2;
      this.cmdAdd.Text = "Add";
      this.cmdAdd.UseVisualStyleBackColor = true;
      this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
      // 
      // _txtAuthors
      // 
      this._txtAuthors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._txtAuthors.Location = new System.Drawing.Point(110, 35);
      this._txtAuthors.Name = "_txtAuthors";
      this._txtAuthors.Size = new System.Drawing.Size(366, 20);
      this._txtAuthors.TabIndex = 4;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 38);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(43, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Authors";
      // 
      // _txtNotes
      // 
      this._txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._txtNotes.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._txtNotes.Location = new System.Drawing.Point(12, 62);
      this._txtNotes.MaxLength = 0;
      this._txtNotes.Multiline = true;
      this._txtNotes.Name = "_txtNotes";
      this._txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this._txtNotes.Size = new System.Drawing.Size(464, 243);
      this._txtNotes.TabIndex = 8;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(28, 118);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(35, 13);
      this.label4.TabIndex = 7;
      this.label4.Text = "Notes";
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // frmBookInfo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(488, 346);
      this.Controls.Add(this._txtNotes);
      this.Controls.Add(this.label4);
      this.Controls.Add(this._txtAuthors);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cmdAdd);
      this.Controls.Add(this._txtTitle);
      this.Controls.Add(this.label1);
      this.Name = "frmBookInfo";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "frmBookInfo";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox _txtTitle;
    private System.Windows.Forms.Button cmdAdd;
    private System.Windows.Forms.TextBox _txtAuthors;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox _txtNotes;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
  }
}