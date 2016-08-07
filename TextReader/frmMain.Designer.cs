namespace Baybak.TextReader
{
  partial class frmMain
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this._txtEditable = new Baybak.TextReader.TextEditControl();
      this.textViewer1 = new Baybak.TextReader.TextViewer();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this._commandMode = new System.Windows.Forms.ToolStripButton();
      this._commandGoogle = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this._commandFontMinus = new System.Windows.Forms.ToolStripButton();
      this._commandFontPlus = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this._commandBFirst = new System.Windows.Forms.ToolStripButton();
      this._commandBPrev = new System.Windows.Forms.ToolStripButton();
      this._commandBNext = new System.Windows.Forms.ToolStripButton();
      this._commandBLast = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this._commandFirstLine = new System.Windows.Forms.ToolStripButton();
      this._commandPrevLine = new System.Windows.Forms.ToolStripButton();
      this._commandNextLine = new System.Windows.Forms.ToolStripButton();
      this._commandLastLine = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this._commandPageUp = new System.Windows.Forms.ToolStripButton();
      this._commandPageDown = new System.Windows.Forms.ToolStripButton();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this._commandOpenFile = new System.Windows.Forms.ToolStripMenuItem();
      this._historyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.translateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this._commandKino = new System.Windows.Forms.ToolStripMenuItem();
      this._commandEditor = new System.Windows.Forms.ToolStripMenuItem();
      this._commandHist = new System.Windows.Forms.ToolStripMenuItem();
      this.dictionaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this._commandAddToDictionary = new System.Windows.Forms.ToolStripMenuItem();
      this.splitContainer3 = new System.Windows.Forms.SplitContainer();
      this._textContent = new System.Windows.Forms.TextBox();
      this._webBrowser = new System.Windows.Forms.WebBrowser();
      this.toolStrip2 = new System.Windows.Forms.ToolStrip();
      this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
      this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
      this.splitContainer3.Panel1.SuspendLayout();
      this.splitContainer3.Panel2.SuspendLayout();
      this.splitContainer3.SuspendLayout();
      this.toolStrip2.SuspendLayout();
      this.SuspendLayout();
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // splitContainer2
      // 
      this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer2.Location = new System.Drawing.Point(0, 35);
      this.splitContainer2.Name = "splitContainer2";
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this._txtEditable);
      this.splitContainer2.Panel1.Controls.Add(this.textViewer1);
      this.splitContainer2.Panel1.Controls.Add(this.toolStrip1);
      this.splitContainer2.Panel1.Controls.Add(this.menuStrip1);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
      this.splitContainer2.Size = new System.Drawing.Size(930, 469);
      this.splitContainer2.SplitterDistance = 537;
      this.splitContainer2.TabIndex = 7;
      // 
      // _txtEditable
      // 
      this._txtEditable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._txtEditable.BackColor = System.Drawing.Color.LightGoldenrodYellow;
      this._txtEditable.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._txtEditable.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this._txtEditable.Location = new System.Drawing.Point(4, 270);
      this._txtEditable.Margin = new System.Windows.Forms.Padding(4);
      this._txtEditable.Name = "_txtEditable";
      this._txtEditable.Size = new System.Drawing.Size(529, 199);
      this._txtEditable.TabIndex = 16;
      // 
      // textViewer1
      // 
      this.textViewer1._Helper = null;
      this.textViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textViewer1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
      this.textViewer1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textViewer1.LeftBorder = 40;
      this.textViewer1.Location = new System.Drawing.Point(4, 48);
      this.textViewer1.Margin = new System.Windows.Forms.Padding(4);
      this.textViewer1.Name = "textViewer1";
      this.textViewer1.Size = new System.Drawing.Size(529, 214);
      this.textViewer1.TabIndex = 15;
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._commandMode,
            this._commandGoogle,
            this.toolStripSeparator1,
            this._commandFontMinus,
            this._commandFontPlus,
            this.toolStripSeparator2,
            this._commandBFirst,
            this._commandBPrev,
            this._commandBNext,
            this._commandBLast,
            this.toolStripSeparator3,
            this._commandFirstLine,
            this._commandPrevLine,
            this._commandNextLine,
            this._commandLastLine,
            this.toolStripSeparator4,
            this._commandPageUp,
            this._commandPageDown});
      this.toolStrip1.Location = new System.Drawing.Point(0, 24);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(537, 25);
      this.toolStrip1.TabIndex = 14;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // _commandMode
      // 
      this._commandMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this._commandMode.Image = ((System.Drawing.Image)(resources.GetObject("_commandMode.Image")));
      this._commandMode.ImageTransparentColor = System.Drawing.Color.Magenta;
      this._commandMode.Name = "_commandMode";
      this._commandMode.Size = new System.Drawing.Size(23, 22);
      this._commandMode.ToolTipText = "Change Selection Mode";
      // 
      // _commandGoogle
      // 
      this._commandGoogle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this._commandGoogle.Image = global::Baybak.TextReader.Properties.Resources.google;
      this._commandGoogle.ImageTransparentColor = System.Drawing.Color.Magenta;
      this._commandGoogle.Name = "_commandGoogle";
      this._commandGoogle.Size = new System.Drawing.Size(23, 22);
      this._commandGoogle.ToolTipText = "Google Translate";
      this._commandGoogle.Click += new System.EventHandler(this._commandGoogle_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // _commandFontMinus
      // 
      this._commandFontMinus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this._commandFontMinus.Image = global::Baybak.TextReader.Properties.Resources.fontminus;
      this._commandFontMinus.ImageTransparentColor = System.Drawing.Color.Magenta;
      this._commandFontMinus.Name = "_commandFontMinus";
      this._commandFontMinus.Size = new System.Drawing.Size(23, 22);
      this._commandFontMinus.Text = "_commandFontMinus";
      this._commandFontMinus.ToolTipText = "Font Zoom -";
      this._commandFontMinus.Click += new System.EventHandler(this._commandFontMinus_Click);
      // 
      // _commandFontPlus
      // 
      this._commandFontPlus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this._commandFontPlus.Image = global::Baybak.TextReader.Properties.Resources.fontplus;
      this._commandFontPlus.ImageTransparentColor = System.Drawing.Color.Magenta;
      this._commandFontPlus.Name = "_commandFontPlus";
      this._commandFontPlus.Size = new System.Drawing.Size(23, 22);
      this._commandFontPlus.Text = "toolStripButton2";
      this._commandFontPlus.ToolTipText = "Font Zoom +";
      this._commandFontPlus.Click += new System.EventHandler(this._commandFontPlus_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
      // 
      // _commandBFirst
      // 
      this._commandBFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this._commandBFirst.Image = global::Baybak.TextReader.Properties.Resources.bfirst;
      this._commandBFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
      this._commandBFirst.Name = "_commandBFirst";
      this._commandBFirst.Size = new System.Drawing.Size(23, 22);
      this._commandBFirst.Text = "toolStripButton1";
      this._commandBFirst.ToolTipText = "Bookmark First";
      this._commandBFirst.Click += new System.EventHandler(this._commandBFirst_Click);
      // 
      // _commandBPrev
      // 
      this._commandBPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this._commandBPrev.Image = global::Baybak.TextReader.Properties.Resources.bprev;
      this._commandBPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
      this._commandBPrev.Name = "_commandBPrev";
      this._commandBPrev.Size = new System.Drawing.Size(23, 22);
      this._commandBPrev.Text = "toolStripButton2";
      this._commandBPrev.ToolTipText = "Bookmark Previous";
      this._commandBPrev.Click += new System.EventHandler(this._commandBPrev_Click);
      // 
      // _commandBNext
      // 
      this._commandBNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this._commandBNext.Image = global::Baybak.TextReader.Properties.Resources.bnext;
      this._commandBNext.ImageTransparentColor = System.Drawing.Color.Magenta;
      this._commandBNext.Name = "_commandBNext";
      this._commandBNext.Size = new System.Drawing.Size(23, 22);
      this._commandBNext.Text = "toolStripButton3";
      this._commandBNext.ToolTipText = "Bookmark Next";
      this._commandBNext.Click += new System.EventHandler(this._commandBNext_Click);
      // 
      // _commandBLast
      // 
      this._commandBLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this._commandBLast.Image = global::Baybak.TextReader.Properties.Resources.blast;
      this._commandBLast.ImageTransparentColor = System.Drawing.Color.Magenta;
      this._commandBLast.Name = "_commandBLast";
      this._commandBLast.Size = new System.Drawing.Size(23, 22);
      this._commandBLast.Text = "toolStripButton4";
      this._commandBLast.ToolTipText = "Bookmark Last";
      this._commandBLast.Click += new System.EventHandler(this._commandBLast_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
      // 
      // _commandFirstLine
      // 
      this._commandFirstLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this._commandFirstLine.Image = ((System.Drawing.Image)(resources.GetObject("_commandFirstLine.Image")));
      this._commandFirstLine.ImageTransparentColor = System.Drawing.Color.Magenta;
      this._commandFirstLine.Name = "_commandFirstLine";
      this._commandFirstLine.Size = new System.Drawing.Size(23, 22);
      this._commandFirstLine.Text = "toolStripButton1";
      this._commandFirstLine.ToolTipText = "Move to First Line";
      this._commandFirstLine.Click += new System.EventHandler(this._commandFirstLine_Click);
      // 
      // _commandPrevLine
      // 
      this._commandPrevLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this._commandPrevLine.Image = ((System.Drawing.Image)(resources.GetObject("_commandPrevLine.Image")));
      this._commandPrevLine.ImageTransparentColor = System.Drawing.Color.Magenta;
      this._commandPrevLine.Name = "_commandPrevLine";
      this._commandPrevLine.Size = new System.Drawing.Size(23, 22);
      this._commandPrevLine.Text = "toolStripButton2";
      this._commandPrevLine.ToolTipText = "Previuos Line";
      this._commandPrevLine.Click += new System.EventHandler(this._commandPrevLine_Click);
      // 
      // _commandNextLine
      // 
      this._commandNextLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this._commandNextLine.Image = ((System.Drawing.Image)(resources.GetObject("_commandNextLine.Image")));
      this._commandNextLine.ImageTransparentColor = System.Drawing.Color.Magenta;
      this._commandNextLine.Name = "_commandNextLine";
      this._commandNextLine.Size = new System.Drawing.Size(23, 22);
      this._commandNextLine.Text = "toolStripButton3";
      this._commandNextLine.ToolTipText = "Next Line";
      this._commandNextLine.Click += new System.EventHandler(this._commandNextLine_Click);
      // 
      // _commandLastLine
      // 
      this._commandLastLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this._commandLastLine.Image = ((System.Drawing.Image)(resources.GetObject("_commandLastLine.Image")));
      this._commandLastLine.ImageTransparentColor = System.Drawing.Color.Magenta;
      this._commandLastLine.Name = "_commandLastLine";
      this._commandLastLine.Size = new System.Drawing.Size(23, 22);
      this._commandLastLine.Text = "toolStripButton4";
      this._commandLastLine.ToolTipText = "Last Line";
      this._commandLastLine.Click += new System.EventHandler(this._commandLastLine_Click);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
      // 
      // _commandPageUp
      // 
      this._commandPageUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this._commandPageUp.Image = ((System.Drawing.Image)(resources.GetObject("_commandPageUp.Image")));
      this._commandPageUp.ImageTransparentColor = System.Drawing.Color.Magenta;
      this._commandPageUp.Name = "_commandPageUp";
      this._commandPageUp.Size = new System.Drawing.Size(23, 22);
      this._commandPageUp.Text = "toolStripButton1";
      this._commandPageUp.ToolTipText = "Page Up";
      this._commandPageUp.Click += new System.EventHandler(this._commandPageDown_Click);
      // 
      // _commandPageDown
      // 
      this._commandPageDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this._commandPageDown.Image = ((System.Drawing.Image)(resources.GetObject("_commandPageDown.Image")));
      this._commandPageDown.ImageTransparentColor = System.Drawing.Color.Magenta;
      this._commandPageDown.Name = "_commandPageDown";
      this._commandPageDown.Size = new System.Drawing.Size(23, 22);
      this._commandPageDown.Text = "toolStripButton2";
      this._commandPageDown.ToolTipText = "Page Down";
      this._commandPageDown.Click += new System.EventHandler(this._commandPageDown_Click);
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.dictionaryToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(537, 24);
      this.menuStrip1.TabIndex = 10;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._commandOpenFile,
            this._historyMenuItem,
            this.translateToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // _commandOpenFile
      // 
      this._commandOpenFile.Name = "_commandOpenFile";
      this._commandOpenFile.Size = new System.Drawing.Size(122, 22);
      this._commandOpenFile.Text = "Open";
      this._commandOpenFile.Click += new System.EventHandler(this.openMenuItem_Click);
      // 
      // _historyMenuItem
      // 
      this._historyMenuItem.Name = "_historyMenuItem";
      this._historyMenuItem.Size = new System.Drawing.Size(122, 22);
      this._historyMenuItem.Text = "History";
      this._historyMenuItem.Click += new System.EventHandler(this._historyMenuItem_Click);
      // 
      // translateToolStripMenuItem
      // 
      this.translateToolStripMenuItem.Name = "translateToolStripMenuItem";
      this.translateToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
      this.translateToolStripMenuItem.Text = "Translate";
      this.translateToolStripMenuItem.Click += new System.EventHandler(this.translateToolStripMenuItem_Click);
      // 
      // viewToolStripMenuItem
      // 
      this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._commandKino,
            this._commandEditor,
            this._commandHist});
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.viewToolStripMenuItem.Text = "View";
      // 
      // _commandKino
      // 
      this._commandKino.Name = "_commandKino";
      this._commandKino.Size = new System.Drawing.Size(112, 22);
      this._commandKino.Text = "Kino";
      this._commandKino.Click += new System.EventHandler(this._commandKino_Click);
      // 
      // _commandEditor
      // 
      this._commandEditor.Name = "_commandEditor";
      this._commandEditor.Size = new System.Drawing.Size(112, 22);
      this._commandEditor.Text = "Editor";
      this._commandEditor.Click += new System.EventHandler(this._commandEditor_Click);
      // 
      // _commandHist
      // 
      this._commandHist.Name = "_commandHist";
      this._commandHist.Size = new System.Drawing.Size(112, 22);
      this._commandHist.Text = "History";
      this._commandHist.Click += new System.EventHandler(this._commandHist_Click);
      // 
      // dictionaryToolStripMenuItem
      // 
      this.dictionaryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._commandAddToDictionary});
      this.dictionaryToolStripMenuItem.Name = "dictionaryToolStripMenuItem";
      this.dictionaryToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
      this.dictionaryToolStripMenuItem.Text = "Dictionary";
      // 
      // _commandAddToDictionary
      // 
      this._commandAddToDictionary.Name = "_commandAddToDictionary";
      this._commandAddToDictionary.Size = new System.Drawing.Size(167, 22);
      this._commandAddToDictionary.Text = "Add to Dictionary";
      this._commandAddToDictionary.Click += new System.EventHandler(this._commandAddToDictionary_Click);
      // 
      // splitContainer3
      // 
      this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer3.Location = new System.Drawing.Point(0, 0);
      this.splitContainer3.Name = "splitContainer3";
      this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer3.Panel1
      // 
      this.splitContainer3.Panel1.Controls.Add(this._textContent);
      // 
      // splitContainer3.Panel2
      // 
      this.splitContainer3.Panel2.Controls.Add(this._webBrowser);
      this.splitContainer3.Size = new System.Drawing.Size(389, 469);
      this.splitContainer3.SplitterDistance = 215;
      this.splitContainer3.TabIndex = 2;
      // 
      // _textContent
      // 
      this._textContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this._textContent.Dock = System.Windows.Forms.DockStyle.Fill;
      this._textContent.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._textContent.Location = new System.Drawing.Point(0, 0);
      this._textContent.Multiline = true;
      this._textContent.Name = "_textContent";
      this._textContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this._textContent.Size = new System.Drawing.Size(389, 215);
      this._textContent.TabIndex = 2;
      // 
      // _webBrowser
      // 
      this._webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
      this._webBrowser.Location = new System.Drawing.Point(0, 0);
      this._webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
      this._webBrowser.Name = "_webBrowser";
      this._webBrowser.Size = new System.Drawing.Size(389, 250);
      this._webBrowser.TabIndex = 0;
      // 
      // toolStrip2
      // 
      this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
      this.toolStrip2.Location = new System.Drawing.Point(0, 0);
      this.toolStrip2.Name = "toolStrip2";
      this.toolStrip2.Size = new System.Drawing.Size(930, 25);
      this.toolStrip2.TabIndex = 8;
      this.toolStrip2.Text = "toolStrip2";
      // 
      // toolStripButton1
      // 
      this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
      this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButton1.Name = "toolStripButton1";
      this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
      this.toolStripButton1.Text = "_commandHistory";
      this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
      // 
      // toolStripButton2
      // 
      this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
      this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButton2.Name = "toolStripButton2";
      this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
      this.toolStripButton2.Text = "toolStripButton2";
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(930, 504);
      this.Controls.Add(this.toolStrip2);
      this.Controls.Add(this.splitContainer2);
      this.DoubleBuffered = true;
      this.KeyPreview = true;
      this.Name = "frmMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "frmMain";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel1.PerformLayout();
      this.splitContainer2.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
      this.splitContainer2.ResumeLayout(false);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.splitContainer3.Panel1.ResumeLayout(false);
      this.splitContainer3.Panel1.PerformLayout();
      this.splitContainer3.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
      this.splitContainer3.ResumeLayout(false);
      this.toolStrip2.ResumeLayout(false);
      this.toolStrip2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.SplitContainer splitContainer3;
    private System.Windows.Forms.TextBox _textContent;
    private System.Windows.Forms.WebBrowser _webBrowser;
    private TextViewer textViewer1;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton _commandMode;
    private System.Windows.Forms.ToolStripButton _commandGoogle;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton _commandFontMinus;
    private System.Windows.Forms.ToolStripButton _commandFontPlus;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripButton _commandBFirst;
    private System.Windows.Forms.ToolStripButton _commandBPrev;
    private System.Windows.Forms.ToolStripButton _commandBNext;
    private System.Windows.Forms.ToolStripButton _commandBLast;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripButton _commandFirstLine;
    private System.Windows.Forms.ToolStripButton _commandPrevLine;
    private System.Windows.Forms.ToolStripButton _commandNextLine;
    private System.Windows.Forms.ToolStripButton _commandLastLine;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripButton _commandPageUp;
    private System.Windows.Forms.ToolStripButton _commandPageDown;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem _commandOpenFile;
    private System.Windows.Forms.ToolStripMenuItem _historyMenuItem;
    private System.Windows.Forms.ToolStripMenuItem translateToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem _commandKino;
    private System.Windows.Forms.ToolStripMenuItem dictionaryToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem _commandAddToDictionary;
    private System.Windows.Forms.ToolStripMenuItem _commandEditor;
    private System.Windows.Forms.ToolStripMenuItem _commandHist;
    private System.Windows.Forms.ToolStrip toolStrip2;
    private System.Windows.Forms.ToolStripButton toolStripButton1;
    private TextEditControl _txtEditable;
    private System.Windows.Forms.ToolStripButton toolStripButton2;
  }
}