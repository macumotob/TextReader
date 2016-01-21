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
      this.textEditControl1 = new Baybak.TextReader.TextEditControl();
      this.SuspendLayout();
      // 
      // textEditControl1
      // 
      this.textEditControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textEditControl1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
      this.textEditControl1.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textEditControl1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.textEditControl1.Location = new System.Drawing.Point(2, 12);
      this.textEditControl1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.textEditControl1.Name = "textEditControl1";
      this.textEditControl1.Size = new System.Drawing.Size(562, 317);
      this.textEditControl1.TabIndex = 1;
      // 
      // frmComments
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(576, 341);
      this.Controls.Add(this.textEditControl1);
      this.Name = "frmComments";
      this.Text = "frmComments";
      this.ResumeLayout(false);

    }

    #endregion

    private TextEditControl textEditControl1;
  }
}