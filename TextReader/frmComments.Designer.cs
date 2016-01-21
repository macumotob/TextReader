namespace Baybak.TextReader
{
  partial class frmComments
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
      this._editor = new Baybak.TextReader.TextEditControl();
      this.SuspendLayout();
      // 
      // _editor
      // 
      this._editor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._editor.BackColor = System.Drawing.Color.LightGoldenrodYellow;
      this._editor.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._editor.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this._editor.Location = new System.Drawing.Point(2, 12);
      this._editor.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this._editor.Name = "_editor";
      this._editor.Size = new System.Drawing.Size(562, 317);
      this._editor.TabIndex = 1;
      // 
      // frmComments
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(576, 341);
      this.Controls.Add(this._editor);
      this.Name = "frmComments";
      this.Text = "frmComments";
      this.ResumeLayout(false);

    }

    #endregion

    private TextEditControl _editor;
  }
}