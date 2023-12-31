﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
      UpdatePreview();
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
          if (Colors == 2)
					{
						if (GetPixel2(x, y))
							g.FillRectangle(Brushes.Black, x * CellSize + 1, y * CellSize + 1,
									CellSize - 2, CellSize - 2);
					}
					else
					{
						byte color = (byte)(GetPixel(x, y) * (Colors - 1));
						color = (byte)(256 - 1 - color);
						Brush brush = new SolidBrush(Color.FromArgb(color, color, color));
						g.FillRectangle(brush, x * CellSize + 1, y * CellSize + 1,
									CellSize - 2, CellSize - 2);
					}
		}

    private void Picture_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;

      bool p = GetPixel2(e.X / CellSize, e.Y / CellSize);
      SetPixel2(e.X / CellSize, e.Y / CellSize, !p);
      lastPictureSet = !p;
      UpdatePreview();
    }

    private void Picture_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;

      SetPixel2(e.X / CellSize, e.Y / CellSize, lastPictureSet);
      UpdatePreview();
    }

    public bool GetPixel2(int x, int y)
    {
      if (x < 0 || y < 0 || x >= SignWidth || y >= SignHeight)
        return false;

			return fontItem.data[x, y] != 0;
    }

		public byte GetPixel(int x, int y)
		{
			if (x < 0 || y < 0 || x >= SignWidth || y >= SignHeight)
				return 0;

			return fontItem.data[x, y];
		}

		public void SetPixel2(int x, int y, bool set)
    {
      if (x < 0 || y < 0 || x >= SignWidth || y >= SignHeight)
        return;

			fontItem.data[x, y] = set ? (byte)15 : (byte)0;
    }

		public void SetPixel(int x, int y, byte set)
    {
      if (x < 0 || y < 0 || x >= SignWidth || y >= SignHeight)
        return;

			fontItem.data[x, y] = set;
    }

    void DrawOverview16()
    {
      if (pictureOverview16.Image == null)
        return;

      Bitmap bmp = (Bitmap)pictureOverview16.Image;
      for (int x = 0; x < SignWidth; x++)
        for (int y = 0; y < SignHeight; y++)
        {
					Color color;
					if (Colors == 2)
						color = GetPixel2(x, y) ? Color.Black : Color.White;
					else
					{
						byte c = (byte)(GetPixel(x, y) * (Colors - 1));
						c = (byte)(256 - 1 - c);
						color = Color.FromArgb(c, c, c);
					}
          bmp.SetPixel(x, y, color);
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
					if (Colors == 2)
						color = GetPixel2(x, y) ? Color.Black : Color.White;
					else
					{
						byte c = (byte)(GetPixel(x, y) * (Colors - 1));
						c = (byte)(256 - 1 - c);
						color = Color.FromArgb(c, c, c);
					}
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
          SetPixel2(x, y, false);

      UpdatePreview();
    }

    private void ButtonInvert_Click(object sender, EventArgs e)
    {
			for (int x = 0; x < SignWidth; x++)
				for (int y = 0; y < SignHeight; y++)
				{
					if (Colors == 2)
						SetPixel2(x, y, !GetPixel2(x, y));
					else
						SetPixel(x, y, (byte)(Colors - 1 - GetPixel(x, y)));
				}

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
			for (int y = 0; y < SignHeight; y++)
			{
				byte x0 = fontItem.data[0, y];
				for (int x = 0; x < SignWidth - 1; x++)
					fontItem.data[x, y] = fontItem.data[x + 1, y];
				fontItem.data[SignWidth - 1, y] = x0;
			}
			UpdatePreview();
    }

    private void ButtonRight_Click(object sender, EventArgs e)
    {
			for (int y = 0; y < SignHeight; y++)
			{
				byte x0 = fontItem.data[SignWidth - 1, y];
				for (int x = SignWidth - 1;  x > 0; x--)
					fontItem.data[x, y] = fontItem.data[x - 1, y];
				fontItem.data[0, y] = x0;
			}
			UpdatePreview();
    }

    private void ButtonTop_Click(object sender, EventArgs e)
    {
			for (int x = 0; x < SignWidth; x++)
			{
				byte y0 = fontItem.data[x, 0];
				for (int y = 0; y < SignHeight - 1; y++)
					fontItem.data[x, y] = fontItem.data[x, y + 1];
				fontItem.data[x, SignHeight - 1] = y0;
			}
      UpdatePreview();
    }

    private void ButtonBottom_Click(object sender, EventArgs e)
    {
			for (int x = 0; x < SignWidth; x++)
			{
				byte y0 = fontItem.data[x, SignHeight - 1];
				for (int y = SignHeight - 1; y > 0; y--)
					fontItem.data[x, y] = fontItem.data[x, y - 1];
				fontItem.data[x, 0] = y0;
			}
			UpdatePreview();
    }

		public void CopyToClipboard(bool addFontWidthAtEnd, bool verticalDataOrientation)
    {
      try
      {
				string s = fontItem.ExportChar(SignWidth, SignHeight, Colors, true,
						addFontWidthAtEnd, verticalDataOrientation, out _);
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

			byte[,] array = new byte[0, 0];
			if (Colors == 16)
			{
				array = Common.HexStringToByteArray(s, SignWidth * 8 / Colors, SignHeight);
				for (int y = 0; y < array.GetLength(1); y++)
					for (int x = 0; x < array.GetLength(0); x++)
					{
						fontItem.data[x * 2,     y] = (byte)(array[x, y] >> 4);
						fontItem.data[x * 2 + 1, y] = (byte)(array[x, y] & 0x0f);
					}
			}
			else if (Colors == 2)
			{
				array = Common.HexStringToByteArray(s, SignWidth / 8, SignHeight);
				for (int y = 0; y < SignHeight; y++)
					for (int x = 0; x < SignWidth; x++)
						if ((array[x / 8, y] & (1 << (x % 8))) != 0)
							fontItem.data[x, y] = 16 - 1;
			}

			UpdatePreview();
    }

		private void BtnCopy_Click(object sender, EventArgs e)
		{
      CopyToClipboard(false, false);
		}

		private void BtnPaste_Click(object sender, EventArgs e)
		{
      PasteFromClipboard();
		}
	}
}
