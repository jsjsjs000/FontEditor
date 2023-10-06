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
    public ulong[] data = new ulong[16];

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

    public void HideButtonSaveAndCancel()
    {
      this.buttonSave.Hide();
      this.buttonCancel.Hide();
    }

    bool lastPictureSet = false;

    public SignEditorControl()
    {
      InitializeComponent();

      pictureOverview16.Image = new Bitmap(Sign.SignWidth, Sign.SignHeight);
      pictureOverview32.Image = new Bitmap(Sign.SignWidth * 2, Sign.SignHeight * 2);
      UpdatePreview();
    }

    private void Picture_Paint(object sender, PaintEventArgs e)
    {
      Graphics g = e.Graphics;
      for (int x = 0; x <= Sign.SignWidth; x++)
        g.DrawLine(Pens.DarkGray, x * Sign.CellSize, 0, x * Sign.CellSize, Sign.CellSize * Sign.SignHeight);
      for (int y = 0; y <= Sign.SignHeight; y++)
        g.DrawLine(Pens.DarkGray, 0, y * Sign.CellSize, Sign.CellSize * Sign.SignWidth, y * Sign.CellSize);

      for (int x = 0; x < Sign.SignWidth; x++)
        for (int y = 0; y < Sign.SignHeight; y++)
          if ((data[y] & (1UL << (Sign.SignWidth - x - 1))) != 0)
            g.FillRectangle(Brushes.Black, x * Sign.CellSize + 1, y * Sign.CellSize + 1,
                Sign.CellSize - 2, Sign.CellSize - 2);
    }

    private void Picture_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;

      bool p = GetPixel(e.X / Sign.CellSize, e.Y / Sign.CellSize);
      SetPixel(e.X / Sign.CellSize, e.Y / Sign.CellSize, !p);
      lastPictureSet = !p;
      UpdatePreview();
    }

    private void Picture_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;

      SetPixel(e.X / Sign.CellSize, e.Y / Sign.CellSize, lastPictureSet);
      UpdatePreview();
    }

    bool GetPixel(int x, int y)
    {
      if (x < 0 || y < 0 || x >= Sign.SignWidth || y >= Sign.SignHeight)
        return false;

      return (data[y] & (1UL << (Sign.SignWidth - x - 1))) != 0;
    }

    void SetPixel(int x, int y, bool set)
    {
      if (x < 0 || y < 0 || x >= Sign.SignWidth || y >= Sign.SignHeight)
        return;

      if (set)
        data[y] |= 1UL << (Sign.SignWidth - x - 1);
      else
        data[y] &= 0xffffffffUL ^ (1UL << (Sign.SignWidth - x - 1));
    }

    void DrawOverview16()
    {
      if (pictureOverview16.Image == null)
        return;

      Bitmap bmp = (Bitmap)pictureOverview16.Image;
      for (int x = 0; x < Sign.SignWidth; x++)
        for (int y = 0; y < Sign.SignHeight; y++)
        {
          if ((data[y] & (1UL << (Sign.SignWidth - x - 1))) != 0)
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
      for (int x = 0; x < Sign.SignWidth; x++)
        for (int y = 0; y < Sign.SignHeight; y++)
        {
          Color color;
          if ((data[y] & (1UL << (Sign.SignWidth - x - 1))) != 0)
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
      for (int x = 0; x < Sign.SignWidth; x++)
        for (int y = 0; y < Sign.SignHeight; y++)
          SetPixel(x, y, false);

      UpdatePreview();
    }

    private void ButtonInvert_Click(object sender, EventArgs e)
    {
      for (int x = 0; x < Sign.SignWidth; x++)
        for (int y = 0; y < Sign.SignHeight; y++)
          SetPixel(x, y, !GetPixel(x, y));
      UpdatePreview();
    }

    public void RecreatePreviewPictures()
    {
      pictureOverview16.Image = new Bitmap(Sign.SignWidth, Sign.SignHeight);
      pictureOverview32.Image = new Bitmap(Sign.SignWidth * 2, Sign.SignHeight * 2);
    }

    public void UpdatePreview()
    {
      picture.Refresh();
      DrawOverview16();
      DrawOverview32();
    }

    public void UpdateControlSize()
    {
      picture.Width = Sign.CellSize * Sign.SignWidth + 1;
      picture.Height = Sign.CellSize * Sign.SignHeight + 1;
      pictureOverview16.Width = Sign.SignWidth;
      pictureOverview16.Height = Sign.SignHeight;
      pictureOverview32.Width = Sign.SignWidth * 2;
      pictureOverview32.Height = Sign.SignHeight * 2;
    }

    private void ButtonLeft_Click(object sender, EventArgs e)
    {
      for (int y = 0; y < Sign.SignHeight; y++)
        data[y] = (data[y] << 1) | (data[y] >> (Sign.SignWidth - 1));
      UpdatePreview();
    }

    private void ButtonRight_Click(object sender, EventArgs e)
    {
      for (int y = 0; y < Sign.SignHeight; y++)
        data[y] = (data[y] >> 1) | (data[y] << (Sign.SignWidth - 1));
      UpdatePreview();
    }

    private void ButtonTop_Click(object sender, EventArgs e)
    {
      ulong tmp = data[0];
      for (int y = 1; y < Sign.SignHeight; y++)
        data[y - 1] = data[y];
      data[Sign.SignHeight - 1] = tmp;
      UpdatePreview();
    }

    private void ButtonBottom_Click(object sender, EventArgs e)
    {
      ulong tmp = data[Sign.SignHeight - 1];
      for (int y = Sign.SignHeight - 2; y >= 0; y--)
        data[y + 1] = data[y];
      data[0] = tmp;
      UpdatePreview();
    }

    public static string Export(ulong[] data, bool divide, bool addFontWidthAtEnd, bool verticalDataOrientation)
    {
      ulong[] data_ = new ulong[data.Length];
      Array.Copy(data, data_, data.Length);
      for (int i = 0; i < data_.Length; i++)
        data_[i] &= (1UL << Sign.SignWidth) - 1UL;

      int height = Sign.SignHeight;
      if (verticalDataOrientation)
      {
        ulong[] vdata = new ulong[data.Length];
        for (int x = 0; x < Sign.SignHeight; x++)
          for (int y = 0; y < Sign.SignWidth; y++)
            if (Sign.SignWidth - y - 1 >= 0)
          {
            bool bit = (data_[x] & (1UL << y)) != 0;
            vdata[Sign.SignWidth - y - 1] |= (bit ? 1UL : 0UL) << x;
          }
        data_ = vdata;
        height = Sign.SignWidth;
      }

      string s;
      if (Sign.SignWidth <= 8)
        s = Common.ArrayToHexString(data_, divide, height, 2);
      else if (Sign.SignWidth <= 16)
        s = Common.ArrayToHexString(data_, divide, height, 4);
      else
        s = Common.ArrayToHexString(data_, divide, height, 8);
      int effectiveWidth = 0;
      for (int y = 0; y < Sign.SignHeight; y++)
        for (int x = Sign.SignWidth - 1; x >= 0; x--)
          if ((data_[y] & (1UL << x)) != 0)
            effectiveWidth = Math.Max(effectiveWidth, (Sign.SignWidth - x));

      if (addFontWidthAtEnd && Sign.SignWidth <= 8)
        s += ", 0x" + effectiveWidth.ToString("x2");
      if (addFontWidthAtEnd && Sign.SignWidth > 8)
        s += ", 0x" + effectiveWidth.ToString("x4");
      return s;
    }

    public void CopyToClipboard(bool addFontWidthAtEnd, bool verticalDataOrientation)
    {
      try
      {
        Clipboard.SetText(Export(data, true, addFontWidthAtEnd, verticalDataOrientation));
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

      ulong[] array = Common.HexStringToUlongArray(s);
      Array.Copy(array, data, array.Length);
      UpdatePreview();
    }
  }
}
