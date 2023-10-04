namespace FontEditor
{
  partial class FormMain
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
			this.nudWidth = new System.Windows.Forms.NumericUpDown();
			this.nudHeight = new System.Windows.Forms.NumericUpDown();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.kryptonLabel1 = new System.Windows.Forms.Label();
			this.kryptonLabel2 = new System.Windows.Forms.Label();
			this.cbArrayBrackets = new System.Windows.Forms.CheckBox();
			this.cbAddFontWidthAtEnd = new System.Windows.Forms.CheckBox();
			this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonRemove = new System.Windows.Forms.Button();
			this.buttonLoadAll = new System.Windows.Forms.Button();
			this.buttonSaveTo = new System.Windows.Forms.Button();
			this.buttonClearAll = new System.Windows.Forms.Button();
			this.listBox = new System.Windows.Forms.ListBox();
			this.logoEditor = new FontEditor.SignEditorControl();
			this.cbPythonMode = new System.Windows.Forms.CheckBox();
			this.cbVerticalDataOrientation = new System.Windows.Forms.CheckBox();
			this.flowLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// nudWidth
			// 
			this.nudWidth.Location = new System.Drawing.Point(3, 23);
			this.nudWidth.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.nudWidth.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
			this.nudWidth.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.nudWidth.Name = "nudWidth";
			this.nudWidth.Size = new System.Drawing.Size(54, 22);
			this.nudWidth.TabIndex = 1;
			this.nudWidth.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.nudWidth.ValueChanged += new System.EventHandler(this.nudWidth_ValueChanged);
			// 
			// nudHeight
			// 
			this.nudHeight.Location = new System.Drawing.Point(3, 71);
			this.nudHeight.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.nudHeight.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
			this.nudHeight.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.nudHeight.Name = "nudHeight";
			this.nudHeight.Size = new System.Drawing.Size(54, 22);
			this.nudHeight.TabIndex = 2;
			this.nudHeight.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.nudHeight.ValueChanged += new System.EventHandler(this.nudHeight_ValueChanged);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.kryptonLabel1);
			this.flowLayoutPanel1.Controls.Add(this.nudWidth);
			this.flowLayoutPanel1.Controls.Add(this.kryptonLabel2);
			this.flowLayoutPanel1.Controls.Add(this.nudHeight);
			this.flowLayoutPanel1.Controls.Add(this.cbArrayBrackets);
			this.flowLayoutPanel1.Controls.Add(this.cbPythonMode);
			this.flowLayoutPanel1.Controls.Add(this.cbAddFontWidthAtEnd);
			this.flowLayoutPanel1.Controls.Add(this.cbVerticalDataOrientation);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(424, 8);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(147, 188);
			this.flowLayoutPanel1.TabIndex = 3;
			// 
			// kryptonLabel1
			// 
			this.kryptonLabel1.Location = new System.Drawing.Point(0, 3);
			this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
			this.kryptonLabel1.Name = "kryptonLabel1";
			this.kryptonLabel1.Size = new System.Drawing.Size(46, 20);
			this.kryptonLabel1.TabIndex = 0;
			this.kryptonLabel1.Text = "Width:";
			// 
			// kryptonLabel2
			// 
			this.kryptonLabel2.Location = new System.Drawing.Point(0, 51);
			this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
			this.kryptonLabel2.Name = "kryptonLabel2";
			this.kryptonLabel2.Size = new System.Drawing.Size(47, 20);
			this.kryptonLabel2.TabIndex = 2;
			this.kryptonLabel2.Text = "Height";
			// 
			// cbArrayBrackets
			// 
			this.cbArrayBrackets.AutoSize = true;
			this.cbArrayBrackets.Location = new System.Drawing.Point(3, 99);
			this.cbArrayBrackets.Name = "cbArrayBrackets";
			this.cbArrayBrackets.Size = new System.Drawing.Size(97, 17);
			this.cbArrayBrackets.TabIndex = 3;
			this.cbArrayBrackets.Text = "Array brackets";
			this.cbArrayBrackets.UseVisualStyleBackColor = true;
			// 
			// cbAddFontWidthAtEnd
			// 
			this.cbAddFontWidthAtEnd.AutoSize = true;
			this.cbAddFontWidthAtEnd.Checked = true;
			this.cbAddFontWidthAtEnd.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbAddFontWidthAtEnd.Location = new System.Drawing.Point(3, 145);
			this.cbAddFontWidthAtEnd.Name = "cbAddFontWidthAtEnd";
			this.cbAddFontWidthAtEnd.Size = new System.Drawing.Size(131, 17);
			this.cbAddFontWidthAtEnd.TabIndex = 4;
			this.cbAddFontWidthAtEnd.Text = "Add font width at end";
			this.cbAddFontWidthAtEnd.UseVisualStyleBackColor = true;
			// 
			// flowLayoutPanel4
			// 
			this.flowLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel4.Controls.Add(this.textBoxName);
			this.flowLayoutPanel4.Controls.Add(this.buttonAdd);
			this.flowLayoutPanel4.Controls.Add(this.buttonRemove);
			this.flowLayoutPanel4.Controls.Add(this.buttonLoadAll);
			this.flowLayoutPanel4.Controls.Add(this.buttonSaveTo);
			this.flowLayoutPanel4.Controls.Add(this.buttonClearAll);
			this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel4.Location = new System.Drawing.Point(567, 200);
			this.flowLayoutPanel4.Name = "flowLayoutPanel4";
			this.flowLayoutPanel4.Size = new System.Drawing.Size(146, 168);
			this.flowLayoutPanel4.TabIndex = 5;
			// 
			// textBoxName
			// 
			this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxName.Location = new System.Drawing.Point(3, 3);
			this.textBoxName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(140, 20);
			this.textBoxName.TabIndex = 1;
			this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAdd.Location = new System.Drawing.Point(3, 26);
			this.buttonAdd.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(140, 25);
			this.buttonAdd.TabIndex = 2;
			this.buttonAdd.Text = "Add item";
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// buttonRemove
			// 
			this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRemove.Location = new System.Drawing.Point(3, 54);
			this.buttonRemove.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.buttonRemove.Name = "buttonRemove";
			this.buttonRemove.Size = new System.Drawing.Size(140, 25);
			this.buttonRemove.TabIndex = 3;
			this.buttonRemove.Text = "Remove item";
			this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
			// 
			// buttonLoadAll
			// 
			this.buttonLoadAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonLoadAll.Location = new System.Drawing.Point(3, 82);
			this.buttonLoadAll.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.buttonLoadAll.Name = "buttonLoadAll";
			this.buttonLoadAll.Size = new System.Drawing.Size(140, 25);
			this.buttonLoadAll.TabIndex = 4;
			this.buttonLoadAll.Text = "Load all from clipboard";
			this.buttonLoadAll.Click += new System.EventHandler(this.buttonLoadAll_Click);
			// 
			// buttonSaveTo
			// 
			this.buttonSaveTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSaveTo.Location = new System.Drawing.Point(3, 110);
			this.buttonSaveTo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.buttonSaveTo.Name = "buttonSaveTo";
			this.buttonSaveTo.Size = new System.Drawing.Size(140, 25);
			this.buttonSaveTo.TabIndex = 5;
			this.buttonSaveTo.Text = "Save all to clipboard";
			this.buttonSaveTo.Click += new System.EventHandler(this.buttonSaveTo_Click);
			// 
			// buttonClearAll
			// 
			this.buttonClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClearAll.Location = new System.Drawing.Point(3, 138);
			this.buttonClearAll.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.buttonClearAll.Name = "buttonClearAll";
			this.buttonClearAll.Size = new System.Drawing.Size(140, 25);
			this.buttonClearAll.TabIndex = 6;
			this.buttonClearAll.Text = "Clear all";
			this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
			// 
			// listBox
			// 
			this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listBox.Location = new System.Drawing.Point(570, 8);
			this.listBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.listBox.Name = "listBox";
			this.listBox.Size = new System.Drawing.Size(140, 191);
			this.listBox.TabIndex = 0;
			this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
			// 
			// logoEditor
			// 
			this.logoEditor.AutoSize = true;
			this.logoEditor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.logoEditor.ButtonCancelText = "";
			this.logoEditor.ButtonClearText = "";
			this.logoEditor.ButtonInvertText = "";
			this.logoEditor.ButtonSaveText = "";
			this.logoEditor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.logoEditor.Location = new System.Drawing.Point(8, 8);
			this.logoEditor.Name = "logoEditor";
			this.logoEditor.Size = new System.Drawing.Size(410, 276);
			this.logoEditor.TabIndex = 0;
			// 
			// cbPythonMode
			// 
			this.cbPythonMode.AutoSize = true;
			this.cbPythonMode.Checked = true;
			this.cbPythonMode.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbPythonMode.Location = new System.Drawing.Point(3, 122);
			this.cbPythonMode.Name = "cbPythonMode";
			this.cbPythonMode.Size = new System.Drawing.Size(89, 17);
			this.cbPythonMode.TabIndex = 5;
			this.cbPythonMode.Text = "Python mode";
			this.cbPythonMode.UseVisualStyleBackColor = true;
			// 
			// cbVerticalDataOrientation
			// 
			this.cbVerticalDataOrientation.AutoSize = true;
			this.cbVerticalDataOrientation.Checked = true;
			this.cbVerticalDataOrientation.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbVerticalDataOrientation.Location = new System.Drawing.Point(3, 168);
			this.cbVerticalDataOrientation.Name = "cbVerticalDataOrientation";
			this.cbVerticalDataOrientation.Size = new System.Drawing.Size(141, 17);
			this.cbVerticalDataOrientation.TabIndex = 6;
			this.cbVerticalDataOrientation.Text = "Vertical data orientation";
			this.cbVerticalDataOrientation.UseVisualStyleBackColor = true;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(0xe0, 0xe0, 0xe0);
			this.ClientSize = new System.Drawing.Size(716, 370);
			this.Controls.Add(this.listBox);
			this.Controls.Add(this.flowLayoutPanel4);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.logoEditor);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.Black;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign editor";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.flowLayoutPanel4.ResumeLayout(false);
			this.flowLayoutPanel4.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

    }

    #endregion

    private FontEditor.SignEditorControl logoEditor;
    private System.Windows.Forms.NumericUpDown nudWidth;
    private System.Windows.Forms.NumericUpDown nudHeight;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.Label kryptonLabel1;
    private System.Windows.Forms.Label kryptonLabel2;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
    private System.Windows.Forms.ListBox listBox;
    private System.Windows.Forms.TextBox textBoxName;
    private System.Windows.Forms.Button buttonAdd;
    private System.Windows.Forms.Button buttonRemove;
    private System.Windows.Forms.Button buttonLoadAll;
    private System.Windows.Forms.Button buttonSaveTo;
    private System.Windows.Forms.CheckBox cbArrayBrackets;
    private System.Windows.Forms.CheckBox cbAddFontWidthAtEnd;
		private System.Windows.Forms.Button buttonClearAll;
		private System.Windows.Forms.CheckBox cbPythonMode;
		private System.Windows.Forms.CheckBox cbVerticalDataOrientation;
	}
}

