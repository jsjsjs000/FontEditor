namespace FontEditor
{
  partial class SignEditorControl
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
      this.picture = new System.Windows.Forms.PictureBox();
      this.pictureOverview16 = new System.Windows.Forms.PictureBox();
      this.buttonClear = new System.Windows.Forms.Button();
      this.buttonInvert = new System.Windows.Forms.Button();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.buttonSave = new System.Windows.Forms.Button();
      this.pictureOverview32 = new System.Windows.Forms.PictureBox();
      this.buttonTop = new System.Windows.Forms.Button();
      this.buttonBottom = new System.Windows.Forms.Button();
      this.buttonLeft = new System.Windows.Forms.Button();
      this.buttonRight = new System.Windows.Forms.Button();
      this.labelInfo = new System.Windows.Forms.Label();
      this.panelRight = new System.Windows.Forms.Panel();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureOverview16)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureOverview32)).BeginInit();
      //((System.ComponentModel.ISupportInitialize)(this.panelRight)).BeginInit();
      this.panelRight.SuspendLayout();
      this.flowLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // picture
      // 
      this.picture.Location = new System.Drawing.Point(3, 3);
      this.picture.Name = "picture";
      this.picture.Size = new System.Drawing.Size(257, 257);
      this.picture.TabIndex = 0;
      this.picture.TabStop = false;
      this.picture.Paint += new System.Windows.Forms.PaintEventHandler(this.Picture_Paint);
      this.picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseDown);
      this.picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseMove);
      // 
      // pictureOverview16
      // 
      this.pictureOverview16.Location = new System.Drawing.Point(20, 0);
      this.pictureOverview16.Name = "pictureOverview16";
      this.pictureOverview16.Size = new System.Drawing.Size(16, 16);
      this.pictureOverview16.TabIndex = 1;
      this.pictureOverview16.TabStop = false;
      // 
      // buttonClear
      // 
      this.buttonClear.Location = new System.Drawing.Point(6, 98);
      this.buttonClear.Name = "buttonClear";
      this.buttonClear.Size = new System.Drawing.Size(126, 25);
      this.buttonClear.TabIndex = 1;
      this.buttonClear.Text = "Clear";
      this.buttonClear.Click += new System.EventHandler(this.ButtonClear_Click);
      // 
      // buttonInvert
      // 
      this.buttonInvert.Location = new System.Drawing.Point(6, 67);
      this.buttonInvert.Name = "buttonInvert";
      this.buttonInvert.Size = new System.Drawing.Size(126, 25);
      this.buttonInvert.TabIndex = 0;
      this.buttonInvert.Text = "Invert";
      this.buttonInvert.Click += new System.EventHandler(this.ButtonInvert_Click);
      // 
      // buttonCancel
      // 
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Location = new System.Drawing.Point(6, 205);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(126, 25);
      this.buttonCancel.TabIndex = 6;
      this.buttonCancel.Text = "Cancel";
      // 
      // buttonSave
      // 
      this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonSave.Location = new System.Drawing.Point(6, 236);
      this.buttonSave.Name = "buttonSave";
      this.buttonSave.Size = new System.Drawing.Size(126, 25);
      this.buttonSave.TabIndex = 7;
      this.buttonSave.Text = "Save";
      // 
      // pictureOverview32
      // 
      this.pictureOverview32.Location = new System.Drawing.Point(61, 0);
      this.pictureOverview32.Name = "pictureOverview32";
      this.pictureOverview32.Size = new System.Drawing.Size(32, 32);
      this.pictureOverview32.TabIndex = 6;
      this.pictureOverview32.TabStop = false;
      // 
      // buttonTop
      // 
      this.buttonTop.Location = new System.Drawing.Point(54, 128);
      this.buttonTop.Name = "buttonTop";
      this.buttonTop.Size = new System.Drawing.Size(25, 25);
      this.buttonTop.TabIndex = 2;
      this.buttonTop.Text = "▲";
      this.buttonTop.Click += new System.EventHandler(this.ButtonTop_Click);
      // 
      // buttonBottom
      // 
      this.buttonBottom.Location = new System.Drawing.Point(54, 157);
      this.buttonBottom.Name = "buttonBottom";
      this.buttonBottom.Size = new System.Drawing.Size(25, 25);
      this.buttonBottom.TabIndex = 4;
      this.buttonBottom.Text = "▼";
      this.buttonBottom.Click += new System.EventHandler(this.ButtonBottom_Click);
      // 
      // buttonLeft
      // 
      this.buttonLeft.Location = new System.Drawing.Point(23, 144);
      this.buttonLeft.Name = "buttonLeft";
      this.buttonLeft.Size = new System.Drawing.Size(25, 25);
      //this.buttonLeft.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.buttonLeft.TabIndex = 3;
      this.buttonLeft.Text = "◄";
      this.buttonLeft.Click += new System.EventHandler(this.ButtonLeft_Click);
      // 
      // buttonRight
      // 
      this.buttonRight.Location = new System.Drawing.Point(85, 144);
      this.buttonRight.Name = "buttonRight";
      this.buttonRight.Size = new System.Drawing.Size(25, 25);
      //this.buttonRight.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.buttonRight.TabIndex = 5;
      this.buttonRight.Text = "►";
      this.buttonRight.Click += new System.EventHandler(this.ButtonRight_Click);
      // 
      // labelInfo
      // 
      this.labelInfo.Location = new System.Drawing.Point(6, 183);
      this.labelInfo.Name = "labelInfo";
      this.labelInfo.Size = new System.Drawing.Size(87, 20);
      this.labelInfo.TabIndex = 8;
      this.labelInfo.Text = "Ctrl+C, Ctrl+V";
      // 
      // panelRight
      // 
      this.panelRight.AutoSize = true;
      this.panelRight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.panelRight.Controls.Add(this.pictureOverview16);
      this.panelRight.Controls.Add(this.labelInfo);
      this.panelRight.Controls.Add(this.buttonClear);
      this.panelRight.Controls.Add(this.buttonRight);
      this.panelRight.Controls.Add(this.buttonInvert);
      this.panelRight.Controls.Add(this.buttonLeft);
      this.panelRight.Controls.Add(this.buttonCancel);
      this.panelRight.Controls.Add(this.buttonBottom);
      this.panelRight.Controls.Add(this.buttonSave);
      this.panelRight.Controls.Add(this.buttonTop);
      this.panelRight.Controls.Add(this.pictureOverview32);
      this.panelRight.Location = new System.Drawing.Point(266, 3);
      this.panelRight.Name = "panelRight";
      this.panelRight.Size = new System.Drawing.Size(135, 264);
      this.panelRight.BackColor = System.Drawing.Color.Transparent;
      this.panelRight.TabIndex = 9;
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.AutoSize = true;
      this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.flowLayoutPanel1.Controls.Add(this.picture);
      this.flowLayoutPanel1.Controls.Add(this.panelRight);
      this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(404, 270);
      this.flowLayoutPanel1.TabIndex = 10;
      // 
      // LogoEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Controls.Add(this.flowLayoutPanel1);
      this.DoubleBuffered = true;
      this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.Name = "LogoEditorControl";
      this.Size = new System.Drawing.Size(410, 276);
      ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureOverview16)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureOverview32)).EndInit();
      //((System.ComponentModel.ISupportInitialize)(this.panelRight)).EndInit();
      this.panelRight.ResumeLayout(false);
      this.panelRight.PerformLayout();
      this.flowLayoutPanel1.ResumeLayout(false);
      this.flowLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox picture;
    private System.Windows.Forms.PictureBox pictureOverview16;
    private System.Windows.Forms.Button buttonClear;
    private System.Windows.Forms.Button buttonInvert;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.Button buttonSave;
    private System.Windows.Forms.PictureBox pictureOverview32;
    private System.Windows.Forms.Button buttonTop;
    private System.Windows.Forms.Button buttonBottom;
    private System.Windows.Forms.Button buttonLeft;
    private System.Windows.Forms.Button buttonRight;
    private System.Windows.Forms.Label labelInfo;
    private System.Windows.Forms.Panel panelRight;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
  }
}
