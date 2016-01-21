namespace Baybak.TextReader
{
  partial class UserControlSpeeker
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
      if (ss != null)
      {
        ss.Pause();
        ss.Dispose();
        ss = null;
      }
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
      this._cmdPlay = new System.Windows.Forms.Button();
      this._Volume = new System.Windows.Forms.TrackBar();
      this._Rate = new System.Windows.Forms.TrackBar();
      this._cmdStop = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this._Volume)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._Rate)).BeginInit();
      this.SuspendLayout();
      // 
      // _cmdPlay
      // 
      this._cmdPlay.Location = new System.Drawing.Point(3, 3);
      this._cmdPlay.Name = "_cmdPlay";
      this._cmdPlay.Size = new System.Drawing.Size(75, 28);
      this._cmdPlay.TabIndex = 0;
      this._cmdPlay.Text = "Play";
      this._cmdPlay.UseVisualStyleBackColor = true;
      // 
      // _Volume
      // 
      this._Volume.Location = new System.Drawing.Point(84, 3);
      this._Volume.Maximum = 100;
      this._Volume.Name = "_Volume";
      this._Volume.Size = new System.Drawing.Size(240, 45);
      this._Volume.TabIndex = 1;
      this._Volume.Value = 100;
      // 
      // _Rate
      // 
      this._Rate.LargeChange = 1;
      this._Rate.Location = new System.Drawing.Point(84, 52);
      this._Rate.Minimum = -10;
      this._Rate.Name = "_Rate";
      this._Rate.Size = new System.Drawing.Size(240, 45);
      this._Rate.TabIndex = 2;
      this._Rate.Value = -10;
      // 
      // _cmdStop
      // 
      this._cmdStop.Location = new System.Drawing.Point(0, 52);
      this._cmdStop.Name = "_cmdStop";
      this._cmdStop.Size = new System.Drawing.Size(75, 28);
      this._cmdStop.TabIndex = 3;
      this._cmdStop.Text = "Play";
      this._cmdStop.UseVisualStyleBackColor = true;
      // 
      // UserControlSpeeker
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.Controls.Add(this._cmdStop);
      this.Controls.Add(this._Rate);
      this.Controls.Add(this._Volume);
      this.Controls.Add(this._cmdPlay);
      this.Name = "UserControlSpeeker";
      this.Size = new System.Drawing.Size(325, 98);
      ((System.ComponentModel.ISupportInitialize)(this._Volume)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._Rate)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button _cmdPlay;
    private System.Windows.Forms.TrackBar _Volume;
    private System.Windows.Forms.TrackBar _Rate;
    private System.Windows.Forms.Button _cmdStop;
  }
}
