namespace Baybak.TextReader
{
  partial class Helper
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this._lblMore = new System.Windows.Forms.LinkLabel();
      this._lblGoogleDic = new System.Windows.Forms.LinkLabel();
      this._cmdHide = new System.Windows.Forms.Button();
      this._cmdSave = new System.Windows.Forms.Button();
      this._cmdNew = new System.Windows.Forms.Button();
      this._cmdEdit = new System.Windows.Forms.Button();
      this._txtTarget = new System.Windows.Forms.TextBox();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this._txtResult = new System.Windows.Forms.TextBox();
      this._listResult = new System.Windows.Forms.ListBox();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.SuspendLayout();
      // 
      // _lblMore
      // 
      this._lblMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this._lblMore.AutoSize = true;
      this._lblMore.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this._lblMore.Location = new System.Drawing.Point(9, 285);
      this._lblMore.Name = "_lblMore";
      this._lblMore.Size = new System.Drawing.Size(60, 15);
      this._lblMore.TabIndex = 5;
      this._lblMore.TabStop = true;
      this._lblMore.Text = "Google ...";
      this._lblMore.Click += new System.EventHandler(this._lblMore_Click);
      // 
      // _lblGoogleDic
      // 
      this._lblGoogleDic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this._lblGoogleDic.AutoSize = true;
      this._lblGoogleDic.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this._lblGoogleDic.Location = new System.Drawing.Point(90, 285);
      this._lblGoogleDic.Name = "_lblGoogleDic";
      this._lblGoogleDic.Size = new System.Drawing.Size(126, 15);
      this._lblGoogleDic.TabIndex = 6;
      this._lblGoogleDic.TabStop = true;
      this._lblGoogleDic.Text = "Google Dictionary ...";
      this._lblGoogleDic.Click += new System.EventHandler(this._lblGoogleDic_Click);
      // 
      // _cmdHide
      // 
      this._cmdHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this._cmdHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this._cmdHide.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this._cmdHide.ForeColor = System.Drawing.Color.WhiteSmoke;
      this._cmdHide.Location = new System.Drawing.Point(749, 7);
      this._cmdHide.Name = "_cmdHide";
      this._cmdHide.Size = new System.Drawing.Size(48, 28);
      this._cmdHide.TabIndex = 7;
      this._cmdHide.Text = "X";
      this._cmdHide.UseVisualStyleBackColor = true;
      this._cmdHide.Click += new System.EventHandler(this._cmdHide_Click);
      // 
      // _cmdSave
      // 
      this._cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this._cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this._cmdSave.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this._cmdSave.ForeColor = System.Drawing.Color.WhiteSmoke;
      this._cmdSave.Location = new System.Drawing.Point(556, 6);
      this._cmdSave.Name = "_cmdSave";
      this._cmdSave.Size = new System.Drawing.Size(66, 29);
      this._cmdSave.TabIndex = 9;
      this._cmdSave.Text = "Save";
      this._cmdSave.UseVisualStyleBackColor = true;
      this._cmdSave.Click += new System.EventHandler(this._cmdSave_Click);
      // 
      // _cmdNew
      // 
      this._cmdNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this._cmdNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this._cmdNew.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this._cmdNew.ForeColor = System.Drawing.Color.WhiteSmoke;
      this._cmdNew.Location = new System.Drawing.Point(695, 7);
      this._cmdNew.Name = "_cmdNew";
      this._cmdNew.Size = new System.Drawing.Size(48, 28);
      this._cmdNew.TabIndex = 10;
      this._cmdNew.Text = "+";
      this._cmdNew.UseVisualStyleBackColor = true;
      this._cmdNew.Click += new System.EventHandler(this._cmdNew_Click);
      // 
      // _cmdEdit
      // 
      this._cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this._cmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this._cmdEdit.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this._cmdEdit.ForeColor = System.Drawing.Color.WhiteSmoke;
      this._cmdEdit.Location = new System.Drawing.Point(641, 6);
      this._cmdEdit.Name = "_cmdEdit";
      this._cmdEdit.Size = new System.Drawing.Size(48, 28);
      this._cmdEdit.TabIndex = 11;
      this._cmdEdit.Text = "V";
      this._cmdEdit.UseVisualStyleBackColor = true;
      this._cmdEdit.Click += new System.EventHandler(this._cmdEdit_Click);
      // 
      // _txtTarget
      // 
      this._txtTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._txtTarget.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this._txtTarget.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this._txtTarget.Location = new System.Drawing.Point(100, 8);
      this._txtTarget.Name = "_txtTarget";
      this._txtTarget.Size = new System.Drawing.Size(437, 24);
      this._txtTarget.TabIndex = 12;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer1.Location = new System.Drawing.Point(12, 41);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this._txtResult);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this._listResult);
      this.splitContainer1.Size = new System.Drawing.Size(785, 241);
      this.splitContainer1.SplitterDistance = 571;
      this.splitContainer1.TabIndex = 13;
      // 
      // _txtResult
      // 
      this._txtResult.BackColor = System.Drawing.Color.Bisque;
      this._txtResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this._txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
      this._txtResult.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this._txtResult.Location = new System.Drawing.Point(0, 0);
      this._txtResult.Multiline = true;
      this._txtResult.Name = "_txtResult";
      this._txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this._txtResult.Size = new System.Drawing.Size(571, 241);
      this._txtResult.TabIndex = 3;
      // 
      // _listResult
      // 
      this._listResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this._listResult.Dock = System.Windows.Forms.DockStyle.Fill;
      this._listResult.FormattingEnabled = true;
      this._listResult.ItemHeight = 15;
      this._listResult.Location = new System.Drawing.Point(0, 0);
      this._listResult.Name = "_listResult";
      this._listResult.Size = new System.Drawing.Size(210, 241);
      this._listResult.TabIndex = 0;
      this._listResult.SelectedIndexChanged += new System.EventHandler(this._listResult_SelectedIndexChanged);
      // 
      // Helper
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this._txtTarget);
      this.Controls.Add(this._cmdEdit);
      this.Controls.Add(this._cmdNew);
      this.Controls.Add(this._cmdSave);
      this.Controls.Add(this._cmdHide);
      this.Controls.Add(this._lblGoogleDic);
      this.Controls.Add(this._lblMore);
      this.DoubleBuffered = true;
      this.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.Name = "Helper";
      this.Size = new System.Drawing.Size(801, 314);
      this.DoubleClick += new System.EventHandler(this.Helper_DoubleClick);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.LinkLabel _lblMore;
    private System.Windows.Forms.LinkLabel _lblGoogleDic;
    private System.Windows.Forms.Button _cmdHide;
    private System.Windows.Forms.Button _cmdSave;
    private System.Windows.Forms.Button _cmdNew;
    private System.Windows.Forms.Button _cmdEdit;
    private System.Windows.Forms.TextBox _txtTarget;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.TextBox _txtResult;
    private System.Windows.Forms.ListBox _listResult;
  }
}
