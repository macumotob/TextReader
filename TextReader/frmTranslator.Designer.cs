namespace Baybak.TextReader
{
  partial class frmTranslator
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
      this._cmdTrans = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this._txtWord = new System.Windows.Forms.TextBox();
      this._browser = new System.Windows.Forms.WebBrowser();
      this._commandBack = new System.Windows.Forms.Button();
      this._commandHrefs = new System.Windows.Forms.Button();
      this._commandCanvas = new System.Windows.Forms.Button();
      this._cmdLib = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // _cmdTrans
      // 
      this._cmdTrans.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this._cmdTrans.ForeColor = System.Drawing.Color.PeachPuff;
      this._cmdTrans.Location = new System.Drawing.Point(715, 9);
      this._cmdTrans.Name = "_cmdTrans";
      this._cmdTrans.Size = new System.Drawing.Size(75, 26);
      this._cmdTrans.TabIndex = 0;
      this._cmdTrans.Text = "button1";
      this._cmdTrans.UseVisualStyleBackColor = true;
      this._cmdTrans.Click += new System.EventHandler(this._cmdTrans_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(122, 19);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "label1";
      // 
      // _txtWord
      // 
      this._txtWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._txtWord.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this._txtWord.Location = new System.Drawing.Point(163, 9);
      this._txtWord.Name = "_txtWord";
      this._txtWord.Size = new System.Drawing.Size(537, 26);
      this._txtWord.TabIndex = 2;
      this._txtWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this._txtWord_KeyDown);
      // 
      // _browser
      // 
      this._browser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._browser.Location = new System.Drawing.Point(12, 41);
      this._browser.MinimumSize = new System.Drawing.Size(20, 20);
      this._browser.Name = "_browser";
      this._browser.Size = new System.Drawing.Size(778, 437);
      this._browser.TabIndex = 4;
      // 
      // _commandBack
      // 
      this._commandBack.Location = new System.Drawing.Point(12, 9);
      this._commandBack.Name = "_commandBack";
      this._commandBack.Size = new System.Drawing.Size(21, 23);
      this._commandBack.TabIndex = 5;
      this._commandBack.Text = "<";
      this._commandBack.UseVisualStyleBackColor = true;
      this._commandBack.Click += new System.EventHandler(this._commandBack_Click);
      // 
      // _commandHrefs
      // 
      this._commandHrefs.Location = new System.Drawing.Point(39, 9);
      this._commandHrefs.Name = "_commandHrefs";
      this._commandHrefs.Size = new System.Drawing.Size(21, 23);
      this._commandHrefs.TabIndex = 6;
      this._commandHrefs.Text = "?";
      this._commandHrefs.UseVisualStyleBackColor = true;
      this._commandHrefs.Click += new System.EventHandler(this._commandHrefs_Click);
      // 
      // _commandCanvas
      // 
      this._commandCanvas.Location = new System.Drawing.Point(66, 9);
      this._commandCanvas.Name = "_commandCanvas";
      this._commandCanvas.Size = new System.Drawing.Size(21, 23);
      this._commandCanvas.TabIndex = 7;
      this._commandCanvas.Text = "?";
      this._commandCanvas.UseVisualStyleBackColor = true;
      this._commandCanvas.Click += new System.EventHandler(this._commandCanvas_Click);
      // 
      // _cmdLib
      // 
      this._cmdLib.Location = new System.Drawing.Point(93, 9);
      this._cmdLib.Name = "_cmdLib";
      this._cmdLib.Size = new System.Drawing.Size(21, 23);
      this._cmdLib.TabIndex = 8;
      this._cmdLib.Text = "L";
      this._cmdLib.UseVisualStyleBackColor = true;
      this._cmdLib.Click += new System.EventHandler(this._cmdLib_Click);
      // 
      // frmTranslator
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Khaki;
      this.ClientSize = new System.Drawing.Size(802, 490);
      this.Controls.Add(this._cmdLib);
      this.Controls.Add(this._commandCanvas);
      this.Controls.Add(this._commandHrefs);
      this.Controls.Add(this._commandBack);
      this.Controls.Add(this._browser);
      this.Controls.Add(this._txtWord);
      this.Controls.Add(this.label1);
      this.Controls.Add(this._cmdTrans);
      this.ForeColor = System.Drawing.Color.Black;
      this.Name = "frmTranslator";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "frmTranslator";
      this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button _cmdTrans;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox _txtWord;
    private System.Windows.Forms.WebBrowser _browser;
    private System.Windows.Forms.Button _commandBack;
    private System.Windows.Forms.Button _commandHrefs;
    private System.Windows.Forms.Button _commandCanvas;
    private System.Windows.Forms.Button _cmdLib;
  }
}