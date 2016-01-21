namespace Baybak.TextReader
{
  partial class frmHistory
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
      this._buttonOpen = new System.Windows.Forms.Button();
      this._labelLastTime = new System.Windows.Forms.Label();
      this._textAuthor = new System.Windows.Forms.TextBox();
      this._textTitle = new System.Windows.Forms.TextBox();
      this._labelAuthor = new System.Windows.Forms.Label();
      this._labelTitle = new System.Windows.Forms.Label();
      this._buttonSave = new System.Windows.Forms.Button();
      this._listBooks = new System.Windows.Forms.ListView();
      this.Author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label1 = new System.Windows.Forms.Label();
      this._textFile = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this._textComment = new System.Windows.Forms.TextBox();
      this.Comment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.SuspendLayout();
      // 
      // _buttonOpen
      // 
      this._buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this._buttonOpen.Location = new System.Drawing.Point(403, 412);
      this._buttonOpen.Name = "_buttonOpen";
      this._buttonOpen.Size = new System.Drawing.Size(75, 23);
      this._buttonOpen.TabIndex = 1;
      this._buttonOpen.Text = "Open";
      this._buttonOpen.UseVisualStyleBackColor = true;
      this._buttonOpen.Click += new System.EventHandler(this._buttonOpen_Click);
      // 
      // _labelLastTime
      // 
      this._labelLastTime.AutoSize = true;
      this._labelLastTime.Location = new System.Drawing.Point(13, 9);
      this._labelLastTime.Name = "_labelLastTime";
      this._labelLastTime.Size = new System.Drawing.Size(53, 13);
      this._labelLastTime.TabIndex = 2;
      this._labelLastTime.Text = "Last Time";
      // 
      // _textAuthor
      // 
      this._textAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._textAuthor.Location = new System.Drawing.Point(117, 34);
      this._textAuthor.Name = "_textAuthor";
      this._textAuthor.Size = new System.Drawing.Size(361, 20);
      this._textAuthor.TabIndex = 3;
      // 
      // _textTitle
      // 
      this._textTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._textTitle.Location = new System.Drawing.Point(117, 63);
      this._textTitle.Name = "_textTitle";
      this._textTitle.Size = new System.Drawing.Size(361, 20);
      this._textTitle.TabIndex = 4;
      // 
      // _labelAuthor
      // 
      this._labelAuthor.AutoSize = true;
      this._labelAuthor.Location = new System.Drawing.Point(13, 36);
      this._labelAuthor.Name = "_labelAuthor";
      this._labelAuthor.Size = new System.Drawing.Size(38, 13);
      this._labelAuthor.TabIndex = 5;
      this._labelAuthor.Text = "Author";
      // 
      // _labelTitle
      // 
      this._labelTitle.AutoSize = true;
      this._labelTitle.Location = new System.Drawing.Point(13, 60);
      this._labelTitle.Name = "_labelTitle";
      this._labelTitle.Size = new System.Drawing.Size(27, 13);
      this._labelTitle.TabIndex = 6;
      this._labelTitle.Text = "Title";
      // 
      // _buttonSave
      // 
      this._buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this._buttonSave.Location = new System.Drawing.Point(403, 168);
      this._buttonSave.Name = "_buttonSave";
      this._buttonSave.Size = new System.Drawing.Size(75, 23);
      this._buttonSave.TabIndex = 7;
      this._buttonSave.Text = "Save";
      this._buttonSave.UseVisualStyleBackColor = true;
      this._buttonSave.Click += new System.EventHandler(this._buttonSave_Click);
      // 
      // _listBooks
      // 
      this._listBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._listBooks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Author,
            this.Title,
            this.Comment,
            this.Path});
      this._listBooks.FullRowSelect = true;
      this._listBooks.GridLines = true;
      this._listBooks.HideSelection = false;
      this._listBooks.Location = new System.Drawing.Point(16, 208);
      this._listBooks.Name = "_listBooks";
      this._listBooks.Size = new System.Drawing.Size(462, 198);
      this._listBooks.TabIndex = 8;
      this._listBooks.UseCompatibleStateImageBehavior = false;
      this._listBooks.View = System.Windows.Forms.View.Details;
      // 
      // Author
      // 
      this.Author.Text = "Author";
      this.Author.Width = 146;
      // 
      // Title
      // 
      this.Title.Text = "Title";
      this.Title.Width = 193;
      // 
      // Path
      // 
      this.Path.DisplayIndex = 2;
      this.Path.Text = "Path";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(16, 91);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(23, 13);
      this.label1.TabIndex = 10;
      this.label1.Text = "File";
      // 
      // _textFile
      // 
      this._textFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._textFile.Location = new System.Drawing.Point(117, 92);
      this._textFile.Name = "_textFile";
      this._textFile.Size = new System.Drawing.Size(361, 20);
      this._textFile.TabIndex = 9;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(17, 121);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(51, 13);
      this.label2.TabIndex = 12;
      this.label2.Text = "Comment";
      // 
      // _textComment
      // 
      this._textComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._textComment.Location = new System.Drawing.Point(118, 122);
      this._textComment.Name = "_textComment";
      this._textComment.Size = new System.Drawing.Size(361, 20);
      this._textComment.TabIndex = 11;
      // 
      // Comment
      // 
      this.Comment.DisplayIndex = 3;
      this.Comment.Text = "Comment";
      // 
      // frmHistory
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(498, 440);
      this.Controls.Add(this.label2);
      this.Controls.Add(this._textComment);
      this.Controls.Add(this.label1);
      this.Controls.Add(this._textFile);
      this.Controls.Add(this._listBooks);
      this.Controls.Add(this._buttonSave);
      this.Controls.Add(this._labelTitle);
      this.Controls.Add(this._labelAuthor);
      this.Controls.Add(this._textTitle);
      this.Controls.Add(this._textAuthor);
      this.Controls.Add(this._labelLastTime);
      this.Controls.Add(this._buttonOpen);
      this.Name = "frmHistory";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "frmHistory";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button _buttonOpen;
    private System.Windows.Forms.Label _labelLastTime;
    private System.Windows.Forms.TextBox _textAuthor;
    private System.Windows.Forms.TextBox _textTitle;
    private System.Windows.Forms.Label _labelAuthor;
    private System.Windows.Forms.Label _labelTitle;
    private System.Windows.Forms.Button _buttonSave;
    private System.Windows.Forms.ListView _listBooks;
    private System.Windows.Forms.ColumnHeader Author;
    private System.Windows.Forms.ColumnHeader Title;
    private System.Windows.Forms.ColumnHeader Path;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox _textFile;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox _textComment;
    private System.Windows.Forms.ColumnHeader Comment;
  }
}