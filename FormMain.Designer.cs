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
			this.lWidth = new System.Windows.Forms.Label();
			this.lHeight = new System.Windows.Forms.Label();
			this.lColors = new System.Windows.Forms.Label();
			this.cbColors = new System.Windows.Forms.ComboBox();
			this.cbArrayBrackets = new System.Windows.Forms.CheckBox();
			this.cbPythonMode = new System.Windows.Forms.CheckBox();
			this.cbAddFontWidthAtEnd = new System.Windows.Forms.CheckBox();
			this.cbVerticalDataOrientation = new System.Windows.Forms.CheckBox();
			this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonRemove = new System.Windows.Forms.Button();
			this.buttonLoadAll = new System.Windows.Forms.Button();
			this.buttonSaveAll = new System.Windows.Forms.Button();
			this.buttonClearAll = new System.Windows.Forms.Button();
			this.listBox = new System.Windows.Forms.ListBox();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.cbFonts = new System.Windows.Forms.ComboBox();
			this.cbFontSize = new System.Windows.Forms.ComboBox();
			this.cbBold = new System.Windows.Forms.CheckBox();
			this.cbItalic = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.nudOffsetY = new System.Windows.Forms.NumericUpDown();
			this.cbFontInterpolate = new System.Windows.Forms.CheckBox();
			this.labelLimit = new System.Windows.Forms.Label();
			this.nudLimit = new System.Windows.Forms.NumericUpDown();
			this.btnGenerateFonts = new System.Windows.Forms.Button();
			this.lGenerateChars = new System.Windows.Forms.Label();
			this.tbGenerateChars = new System.Windows.Forms.TextBox();
			this.logoEditor = new FontEditor.SignEditorControl();
			((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel4.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudOffsetY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudLimit)).BeginInit();
			this.SuspendLayout();
			// 
			// nudWidth
			// 
			this.nudWidth.Location = new System.Drawing.Point(3, 16);
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
			this.nudWidth.Size = new System.Drawing.Size(54, 21);
			this.nudWidth.TabIndex = 1;
			this.nudWidth.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.nudWidth.ValueChanged += new System.EventHandler(this.NudWidth_ValueChanged);
			// 
			// nudHeight
			// 
			this.nudHeight.Location = new System.Drawing.Point(3, 56);
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
			this.nudHeight.Size = new System.Drawing.Size(54, 21);
			this.nudHeight.TabIndex = 2;
			this.nudHeight.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.nudHeight.ValueChanged += new System.EventHandler(this.NudHeight_ValueChanged);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.lWidth);
			this.flowLayoutPanel1.Controls.Add(this.nudWidth);
			this.flowLayoutPanel1.Controls.Add(this.lHeight);
			this.flowLayoutPanel1.Controls.Add(this.nudHeight);
			this.flowLayoutPanel1.Controls.Add(this.lColors);
			this.flowLayoutPanel1.Controls.Add(this.cbColors);
			this.flowLayoutPanel1.Controls.Add(this.cbArrayBrackets);
			this.flowLayoutPanel1.Controls.Add(this.cbPythonMode);
			this.flowLayoutPanel1.Controls.Add(this.cbAddFontWidthAtEnd);
			this.flowLayoutPanel1.Controls.Add(this.cbVerticalDataOrientation);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(597, 8);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(147, 215);
			this.flowLayoutPanel1.TabIndex = 3;
			// 
			// lWidth
			// 
			this.lWidth.AutoSize = true;
			this.lWidth.Location = new System.Drawing.Point(0, 3);
			this.lWidth.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
			this.lWidth.Name = "kryptonLabel1";
			this.lWidth.Size = new System.Drawing.Size(39, 13);
			this.lWidth.TabIndex = 0;
			this.lWidth.Text = "Width:";
			// 
			// lHeight
			// 
			this.lHeight.AutoSize = true;
			this.lHeight.Location = new System.Drawing.Point(0, 43);
			this.lHeight.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
			this.lHeight.Name = "kryptonLabel2";
			this.lHeight.Size = new System.Drawing.Size(42, 13);
			this.lHeight.TabIndex = 2;
			this.lHeight.Text = "Height:";
			// 
			// lColors
			// 
			this.lColors.AutoSize = true;
			this.lColors.Location = new System.Drawing.Point(0, 83);
			this.lColors.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
			this.lColors.Name = "label3";
			this.lColors.Size = new System.Drawing.Size(41, 13);
			this.lColors.TabIndex = 7;
			this.lColors.Text = "Colors:";
			// 
			// cbColors
			// 
			this.cbColors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbColors.FormattingEnabled = true;
			this.cbColors.Location = new System.Drawing.Point(3, 99);
			this.cbColors.MaxDropDownItems = 16;
			this.cbColors.Name = "cbColors";
			this.cbColors.Size = new System.Drawing.Size(54, 21);
			this.cbColors.TabIndex = 8;
			this.cbColors.SelectedIndexChanged += new System.EventHandler(this.CbColors_IndexChanged);
			// 
			// cbArrayBrackets
			// 
			this.cbArrayBrackets.AutoSize = true;
			this.cbArrayBrackets.Location = new System.Drawing.Point(3, 126);
			this.cbArrayBrackets.Name = "cbArrayBrackets";
			this.cbArrayBrackets.Size = new System.Drawing.Size(97, 17);
			this.cbArrayBrackets.TabIndex = 3;
			this.cbArrayBrackets.Text = "Array brackets";
			this.cbArrayBrackets.UseVisualStyleBackColor = true;
			// 
			// cbPythonMode
			// 
			this.cbPythonMode.AutoSize = true;
			this.cbPythonMode.Location = new System.Drawing.Point(3, 149);
			this.cbPythonMode.Name = "cbPythonMode";
			this.cbPythonMode.Size = new System.Drawing.Size(89, 17);
			this.cbPythonMode.TabIndex = 4;
			this.cbPythonMode.Text = "Python mode";
			this.cbPythonMode.UseVisualStyleBackColor = true;
			// 
			// cbAddFontWidthAtEnd
			// 
			this.cbAddFontWidthAtEnd.AutoSize = true;
			this.cbAddFontWidthAtEnd.Checked = true;
			this.cbAddFontWidthAtEnd.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbAddFontWidthAtEnd.Location = new System.Drawing.Point(3, 172);
			this.cbAddFontWidthAtEnd.Name = "cbAddFontWidthAtEnd";
			this.cbAddFontWidthAtEnd.Size = new System.Drawing.Size(131, 17);
			this.cbAddFontWidthAtEnd.TabIndex = 5;
			this.cbAddFontWidthAtEnd.Text = "Add font width at end";
			this.cbAddFontWidthAtEnd.UseVisualStyleBackColor = true;
			// 
			// cbVerticalDataOrientation
			// 
			this.cbVerticalDataOrientation.AutoSize = true;
			this.cbVerticalDataOrientation.Location = new System.Drawing.Point(3, 195);
			this.cbVerticalDataOrientation.Name = "cbVerticalDataOrientation";
			this.cbVerticalDataOrientation.Size = new System.Drawing.Size(141, 17);
			this.cbVerticalDataOrientation.TabIndex = 6;
			this.cbVerticalDataOrientation.Text = "Vertical data orientation";
			this.cbVerticalDataOrientation.UseVisualStyleBackColor = true;
			this.cbVerticalDataOrientation.Visible = false;
			// 
			// flowLayoutPanel4
			// 
			this.flowLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel4.Controls.Add(this.textBoxName);
			this.flowLayoutPanel4.Controls.Add(this.buttonAdd);
			this.flowLayoutPanel4.Controls.Add(this.buttonRemove);
			this.flowLayoutPanel4.Controls.Add(this.buttonLoadAll);
			this.flowLayoutPanel4.Controls.Add(this.buttonSaveAll);
			this.flowLayoutPanel4.Controls.Add(this.buttonClearAll);
			this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel4.Location = new System.Drawing.Point(742, 262);
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
			this.textBoxName.Size = new System.Drawing.Size(140, 21);
			this.textBoxName.TabIndex = 1;
			this.textBoxName.TextChanged += new System.EventHandler(this.TextBoxName_TextChanged);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAdd.Location = new System.Drawing.Point(3, 27);
			this.buttonAdd.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(140, 25);
			this.buttonAdd.TabIndex = 2;
			this.buttonAdd.Text = "Add item";
			this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
			// 
			// buttonRemove
			// 
			this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRemove.Location = new System.Drawing.Point(3, 55);
			this.buttonRemove.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.buttonRemove.Name = "buttonRemove";
			this.buttonRemove.Size = new System.Drawing.Size(140, 25);
			this.buttonRemove.TabIndex = 3;
			this.buttonRemove.Text = "Remove item";
			this.buttonRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
			// 
			// buttonLoadAll
			// 
			this.buttonLoadAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonLoadAll.Location = new System.Drawing.Point(3, 83);
			this.buttonLoadAll.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.buttonLoadAll.Name = "buttonLoadAll";
			this.buttonLoadAll.Size = new System.Drawing.Size(140, 25);
			this.buttonLoadAll.TabIndex = 4;
			this.buttonLoadAll.Text = "Load all from clipboard";
			this.buttonLoadAll.Click += new System.EventHandler(this.ButtonLoadAll_Click);
			// 
			// buttonSaveTo
			// 
			this.buttonSaveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSaveAll.Location = new System.Drawing.Point(3, 111);
			this.buttonSaveAll.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.buttonSaveAll.Name = "buttonSaveTo";
			this.buttonSaveAll.Size = new System.Drawing.Size(140, 25);
			this.buttonSaveAll.TabIndex = 5;
			this.buttonSaveAll.Text = "Save all to clipboard";
			this.buttonSaveAll.Click += new System.EventHandler(this.ButtonSaveAll_Click);
			// 
			// buttonClearAll
			// 
			this.buttonClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClearAll.Location = new System.Drawing.Point(3, 139);
			this.buttonClearAll.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.buttonClearAll.Name = "buttonClearAll";
			this.buttonClearAll.Size = new System.Drawing.Size(140, 25);
			this.buttonClearAll.TabIndex = 6;
			this.buttonClearAll.Text = "Clear all";
			this.buttonClearAll.Click += new System.EventHandler(this.ButtonClearAll_Click);
			// 
			// listBox
			// 
			this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBox.Location = new System.Drawing.Point(745, 8);
			this.listBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.listBox.Name = "listBox";
			this.listBox.Size = new System.Drawing.Size(140, 251);
			this.listBox.TabIndex = 0;
			this.listBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel2.Controls.Add(this.cbFonts);
			this.flowLayoutPanel2.Controls.Add(this.cbFontSize);
			this.flowLayoutPanel2.Controls.Add(this.cbBold);
			this.flowLayoutPanel2.Controls.Add(this.cbItalic);
			this.flowLayoutPanel2.Controls.Add(this.label2);
			this.flowLayoutPanel2.Controls.Add(this.nudOffsetY);
			this.flowLayoutPanel2.Controls.Add(this.cbFontInterpolate);
			this.flowLayoutPanel2.Controls.Add(this.labelLimit);
			this.flowLayoutPanel2.Controls.Add(this.nudLimit);
			this.flowLayoutPanel2.Controls.Add(this.btnGenerateFonts);
			this.flowLayoutPanel2.Location = new System.Drawing.Point(8, 398);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(732, 29);
			this.flowLayoutPanel2.TabIndex = 6;
			// 
			// cbFonts
			// 
			this.cbFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFonts.FormattingEnabled = true;
			this.cbFonts.Location = new System.Drawing.Point(3, 3);
			this.cbFonts.MaxDropDownItems = 16;
			this.cbFonts.Name = "cbFonts";
			this.cbFonts.Size = new System.Drawing.Size(200, 21);
			this.cbFonts.TabIndex = 0;
			// 
			// cbFontSize
			// 
			this.cbFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFontSize.FormattingEnabled = true;
			this.cbFontSize.Items.AddRange(new object[] {
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32"});
			this.cbFontSize.Location = new System.Drawing.Point(209, 3);
			this.cbFontSize.MaxDropDownItems = 16;
			this.cbFontSize.Name = "cbFontSize";
			this.cbFontSize.Size = new System.Drawing.Size(65, 21);
			this.cbFontSize.TabIndex = 1;
			// 
			// cbBold
			// 
			this.cbBold.AutoSize = true;
			this.cbBold.Location = new System.Drawing.Point(280, 6);
			this.cbBold.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
			this.cbBold.Name = "cbBold";
			this.cbBold.Size = new System.Drawing.Size(46, 17);
			this.cbBold.TabIndex = 3;
			this.cbBold.Text = "Bold";
			this.cbBold.UseVisualStyleBackColor = true;
			// 
			// cbItalic
			// 
			this.cbItalic.AutoSize = true;
			this.cbItalic.Location = new System.Drawing.Point(332, 6);
			this.cbItalic.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
			this.cbItalic.Name = "cbItalic";
			this.cbItalic.Size = new System.Drawing.Size(49, 17);
			this.cbItalic.TabIndex = 4;
			this.cbItalic.Text = "Italic";
			this.cbItalic.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(384, 6);
			this.label2.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(17, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Y:";
			// 
			// nudOffsetY
			// 
			this.nudOffsetY.Location = new System.Drawing.Point(404, 3);
			this.nudOffsetY.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
			this.nudOffsetY.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            -2147483648});
			this.nudOffsetY.Name = "nudOffsetY";
			this.nudOffsetY.Size = new System.Drawing.Size(42, 21);
			this.nudOffsetY.TabIndex = 6;
			// 
			// cbFontInterpolate
			// 
			this.cbFontInterpolate.AutoSize = true;
			this.cbFontInterpolate.Location = new System.Drawing.Point(452, 6);
			this.cbFontInterpolate.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
			this.cbFontInterpolate.Name = "cbFontInterpolate";
			this.cbFontInterpolate.Size = new System.Drawing.Size(80, 17);
			this.cbFontInterpolate.TabIndex = 7;
			this.cbFontInterpolate.Text = "Interpolate";
			this.cbFontInterpolate.UseVisualStyleBackColor = true;
			// 
			// labelLimit
			// 
			this.labelLimit.AutoSize = true;
			this.labelLimit.Location = new System.Drawing.Point(535, 6);
			this.labelLimit.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
			this.labelLimit.Name = "labelLimit";
			this.labelLimit.Size = new System.Drawing.Size(52, 13);
			this.labelLimit.TabIndex = 5;
			this.labelLimit.Text = "B/W limit:";
			// 
			// nudLimit
			// 
			this.nudLimit.Location = new System.Drawing.Point(590, 3);
			this.nudLimit.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.nudLimit.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.nudLimit.Name = "nudLimit";
			this.nudLimit.Size = new System.Drawing.Size(54, 21);
			this.nudLimit.TabIndex = 6;
			this.nudLimit.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
			// 
			// btnGenerateFonts
			// 
			this.btnGenerateFonts.Location = new System.Drawing.Point(650, 2);
			this.btnGenerateFonts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
			this.btnGenerateFonts.Name = "btnGenerateFonts";
			this.btnGenerateFonts.Size = new System.Drawing.Size(75, 23);
			this.btnGenerateFonts.TabIndex = 2;
			this.btnGenerateFonts.Text = "Generate";
			this.btnGenerateFonts.UseVisualStyleBackColor = true;
			this.btnGenerateFonts.Click += new System.EventHandler(this.BtnGenerateFonts_Click);
			// 
			// label1
			// 
			this.lGenerateChars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lGenerateChars.AutoSize = true;
			this.lGenerateChars.Location = new System.Drawing.Point(12, 345);
			this.lGenerateChars.Name = "label1";
			this.lGenerateChars.Size = new System.Drawing.Size(85, 13);
			this.lGenerateChars.TabIndex = 0;
			this.lGenerateChars.Text = "Generate chars:";
			// 
			// tbGenerateChars
			// 
			this.tbGenerateChars.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbGenerateChars.Location = new System.Drawing.Point(11, 361);
			this.tbGenerateChars.Multiline = true;
			this.tbGenerateChars.Name = "tbGenerateChars";
			this.tbGenerateChars.Size = new System.Drawing.Size(722, 34);
			this.tbGenerateChars.TabIndex = 1;
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
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.ClientSize = new System.Drawing.Size(891, 432);
			this.Controls.Add(this.tbGenerateChars);
			this.Controls.Add(this.lGenerateChars);
			this.Controls.Add(this.flowLayoutPanel2);
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
			this.Text = "Font editor";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.flowLayoutPanel4.ResumeLayout(false);
			this.flowLayoutPanel4.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudOffsetY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudLimit)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

    }

    #endregion

    private FontEditor.SignEditorControl logoEditor;
    private System.Windows.Forms.NumericUpDown nudWidth;
    private System.Windows.Forms.NumericUpDown nudHeight;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.Label lWidth;
    private System.Windows.Forms.Label lHeight;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
    private System.Windows.Forms.ListBox listBox;
    private System.Windows.Forms.TextBox textBoxName;
    private System.Windows.Forms.Button buttonAdd;
    private System.Windows.Forms.Button buttonRemove;
    private System.Windows.Forms.Button buttonLoadAll;
    private System.Windows.Forms.Button buttonSaveAll;
    private System.Windows.Forms.CheckBox cbArrayBrackets;
    private System.Windows.Forms.CheckBox cbAddFontWidthAtEnd;
		private System.Windows.Forms.Button buttonClearAll;
		private System.Windows.Forms.CheckBox cbPythonMode;
		private System.Windows.Forms.CheckBox cbVerticalDataOrientation;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.ComboBox cbFonts;
		private System.Windows.Forms.ComboBox cbFontSize;
		private System.Windows.Forms.Button btnGenerateFonts;
		private System.Windows.Forms.CheckBox cbBold;
		private System.Windows.Forms.CheckBox cbItalic;
		private System.Windows.Forms.Label lGenerateChars;
		private System.Windows.Forms.TextBox tbGenerateChars;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown nudOffsetY;
		private System.Windows.Forms.Label lColors;
		private System.Windows.Forms.Label labelLimit;
		private System.Windows.Forms.NumericUpDown nudLimit;
		private System.Windows.Forms.ComboBox cbColors;
		private System.Windows.Forms.CheckBox cbFontInterpolate;
	}
}

