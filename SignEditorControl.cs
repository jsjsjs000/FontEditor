using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FontEditor
{
  public partial class SignEditorControl : UserControl
  {
		public const int DataSize = 32 * 32; /// 1024
		public const int MaxSize = 32;

		public int SignWidth = 16;
		public int SignHeight = 16;
		public int Colors = 2;
		public int CellSize = 16;

		FontItem fontItem;
		bool lastPictureSet = false;

		string ButtonClearText_ = "";
    [Description(""), Category("Data")]
    public string ButtonClearText
    {
      get { return ButtonClearText_; }
      set
      {
        ButtonClearText_ = value;
        buttonClear.Text = value;
      }
    }

    string ButtonInvertText_ = "";
    [Description(""), Category("Data")]
    public string ButtonInvertText
    {
      get { return ButtonInvertText_; }
      set
      {
        ButtonInvertText_ = value;
        buttonInvert.Text = value;
      }
    }

    string ButtonSaveText_ = "";
    [Description(""), Category("Data")]
    public string ButtonSaveText
    {
      get { return ButtonSaveText_; }
      set
      {
        ButtonSaveText_ = value;
        buttonSave.Text = value;
      }
    }

    string ButtonCancelText_ = "";
    [Description(""), Category("Data")]
    public string ButtonCancelText
    {
      get { return ButtonCancelText_; }
      set
      {
        ButtonCancelText_ = value;
        buttonCancel.Text = value;
      }
    }

		public void SetFontItem(FontItem fontItem)
		{
			this.fontItem = fontItem;
		}

		public void HideButtonSaveAndCancel()
    {
      this.buttonSave.Hide();
      this.buttonCancel.Hide();
    }

    public SignEditorControl()
    {
      InitializeComponent();

      pictureOverview16.Image = new Bitmap(SignWidth, SignHeight);
      pictureOverview32.Image = new Bitmap(SignWidth * 2, SignHeight * 2);
      //$$UpdatePreview();
    }

    private void Picture_Paint(object sender, PaintEventArgs e)
    {
				/// Draw grid
      Graphics g = e.Graphics;
      for (int x = 0; x <= SignWidth; x++)
        g.DrawLine(Pens.DarkGray, x * CellSize, 0, x * CellSize, CellSize * SignHeight);
      for (int y = 0; y <= SignHeight; y++)
        g.DrawLine(Pens.DarkGray, 0, y * CellSize, CellSize * SignWidth, y * CellSize);

				/// Draw pixels
      for (int x = 0; x < SignWidth; x++)
        for (int y = 0; y < SignHeight; y++)
          //if ((data[y] & (1UL << (SignWidth - x - 1))) != 0)
					if (GetPixel(x, y))
            g.FillRectangle(Brushes.Black, x * CellSize + 1, y * CellSize + 1,
                CellSize - 2, CellSize - 2);
    }

    private void Picture_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;

      bool p = GetPixel(e.X / CellSize, e.Y / CellSize);
      SetPixel(e.X / CellSize, e.Y / CellSize, !p);
      lastPictureSet = !p;
      UpdatePreview();
    }

    private void Picture_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;

      SetPixel(e.X / CellSize, e.Y / CellSize, lastPictureSet);
      UpdatePreview();
    }

    public bool GetPixel(int x, int y)
    {
      if (x < 0 || y < 0 || x >= SignWidth || y >= SignHeight)
        return false;

			return fontItem.data[x, y] != 0;
      //return (data[y] & (1UL << (SignWidth - x - 1))) != 0;
    }

    public void SetPixel(int x, int y, bool set)
    {
      if (x < 0 || y < 0 || x >= SignWidth || y >= SignHeight)
        return;

			fontItem.data[x, y] = set ? (byte)1 : (byte)0;
      //if (set)
      //  data[y] |= (byte)(1UL << (SignWidth - x - 1));
      //else
        //data[y] &= (byte)(0xffffffffUL ^ (1UL << (SignWidth - x - 1)));
    }

    void DrawOverview16()
    {
      if (pictureOverview16.Image == null)
        return;

      Bitmap bmp = (Bitmap)pictureOverview16.Image;
      for (int x = 0; x < SignWidth; x++)
        for (int y = 0; y < SignHeight; y++)
        {
					if (GetPixel(x, y))
          //if ((data[y] & (1UL << (SignWidth - x - 1))) != 0)
            bmp.SetPixel(x, y, Color.Black);
          else
            bmp.SetPixel(x, y, Color.White);
        }

      pictureOverview16.Refresh();
    }

    void DrawOverview32()
    {
      if (pictureOverview32.Image == null)
        return;

      Bitmap bmp = (Bitmap)pictureOverview32.Image;
      for (int x = 0; x < SignWidth; x++)
        for (int y = 0; y < SignHeight; y++)
        {
          Color color;
					if (GetPixel(x, y))
          //if ((data[y] & (1UL << (SignWidth - x - 1))) != 0)
            color = Color.Black;
          else
            color = Color.White;
          bmp.SetPixel(x * 2    , y * 2    , color);
          bmp.SetPixel(x * 2 + 1, y * 2 + 1, color);
          bmp.SetPixel(x * 2 + 1, y * 2    , color);
          bmp.SetPixel(x * 2    , y * 2 + 1, color);
        }

      pictureOverview32.Refresh();
    }

    private void ButtonClear_Click(object sender, EventArgs e)
    {
      for (int x = 0; x < SignWidth; x++)
        for (int y = 0; y < SignHeight; y++)
          SetPixel(x, y, false);

      UpdatePreview();
    }

    private void ButtonInvert_Click(object sender, EventArgs e)
    {
      for (int x = 0; x < SignWidth; x++)
        for (int y = 0; y < SignHeight; y++)
          SetPixel(x, y, !GetPixel(x, y));
      UpdatePreview();
    }

    public void RecreatePreviewPictures()
    {
      pictureOverview16.Image = new Bitmap(SignWidth, SignHeight);
      pictureOverview32.Image = new Bitmap(SignWidth * 2, SignHeight * 2);
    }

    public void UpdatePreview()
    {
			if (fontItem == null)
				return;

      picture.Refresh();
      DrawOverview16();
      DrawOverview32();
    }

    public void UpdateControlSize()
    {
      picture.Width = CellSize * SignWidth + 1;
      picture.Height = CellSize * SignHeight + 1;
      pictureOverview16.Width = SignWidth;
      pictureOverview16.Height = SignHeight;
      pictureOverview32.Width = SignWidth * 2;
      pictureOverview32.Height = SignHeight * 2;
    }

    private void ButtonLeft_Click(object sender, EventArgs e)
    {
      //for (int y = 0; y < SignHeight; y++)
        //data[y] = (byte)((data[y] << 1) | (data[y] >> (SignWidth - 1)));
      UpdatePreview();
    }

    private void ButtonRight_Click(object sender, EventArgs e)
    {
      //for (int y = 0; y < SignHeight; y++)
        //data[y] = (byte)((data[y] >> 1) | (data[y] << (SignWidth - 1)));
      UpdatePreview();
    }

    private void ButtonTop_Click(object sender, EventArgs e)
    {
      //byte tmp = data[0];
      //for (int y = 1; y < SignHeight; y++)
      //  data[y - 1] = data[y];
      //data[SignHeight - 1] = tmp;
      UpdatePreview();
    }

    private void ButtonBottom_Click(object sender, EventArgs e)
    {
      //byte tmp = data[SignHeight - 1];
      //for (int y = SignHeight - 2; y >= 0; y--)
      //  data[y + 1] = data[y];
      //data[0] = tmp;
      UpdatePreview();
    }
    
    public void CopyToClipboard(bool addFontWidthAtEnd, bool verticalDataOrientation)
    {
      try
      {
				string s = ImportExport.ExportChar(fontItem.data, true, addFontWidthAtEnd, verticalDataOrientation);
        Clipboard.SetText(s);
      }
      catch
      {
				Console.WriteLine("Can't write to clipboard.");
			}
    }

    public void PasteFromClipboard()
    {
      string s;
      try
      {
        s = Clipboard.GetText();
      }
      catch
      {
				Console.WriteLine("Can't read clipboard.");
				return;
      }

			byte[,] array = new byte[0, 0]; // $$$ Common.HexStringToUlongArray(s);
      Array.Copy(array, fontItem.data, array.Length);
      UpdatePreview();
    }
  }
}
