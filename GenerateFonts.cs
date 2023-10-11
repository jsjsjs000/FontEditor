using System;
using System.Drawing;
using System.Drawing.Text;

namespace FontEditor
{
	public partial class FormMain
	{
		public void GenerateFontChars(string fontFamily, float fontSize,
				bool bold, bool italic, int offsetY,
				bool fontInterpolate, byte limit, string chars)
		{
			ClearAll();
			RemoveAllNewItems();

			Bitmap bitmap = new Bitmap(128, 128);
			Graphics graphic = Graphics.FromImage(bitmap);
			if (fontInterpolate)
			{
				graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
				graphic.TextContrast = 0;
				graphic.TextRenderingHint = TextRenderingHint.AntiAlias;
			}

			FontStyle fontStyle = FontStyle.Regular;
			if (bold)
			{
				fontStyle |= FontStyle.Bold;
				fontStyle &= ~FontStyle.Regular;
			}
			if (italic)
			{
				fontStyle |= FontStyle.Italic;
				fontStyle &= ~FontStyle.Regular;
			}
			Font font = new Font(fontFamily, fontSize, fontStyle);
			Point offset = new Point(0, offsetY);

			foreach (char c in chars)
			{
				FontItem item = new FontItem
				{
					name = string.Format("{0} - {1} 0x{2:x2}", c.ToString(), (uint)c, (uint)c),
				};
				items.Add(item);
				listBox.Items.Add(item);
				GenerateFontChar(font, graphic, bitmap, item, offset, limit, c);
			}

			font.Dispose();
			graphic.Dispose();
			bitmap.Dispose();
		}

		public void GenerateFontChar(Font font, Graphics graphics, Bitmap bitmap,
				FontItem item, Point offset, byte limit, char c)
		{
			graphics.FillRectangle(Brushes.Black, 0, 0, bitmap.Width, bitmap.Height);
			graphics.DrawString(c.ToString(), font, Brushes.White, offset);

			int colorsLength = 256 / logoEditor.Colors;

			for (int y = 0; y < logoEditor.SignHeight; y++)
				for (int x = 0; x < logoEditor.SignWidth; x++)
					if (logoEditor.Colors == 2)
					{
						if (bitmap.GetPixel(x, y).R > limit)
							item.data[x, y] = 1;
					}
					else
					{
						int in_ = bitmap.GetPixel(x, y).R;
						int out_ = in_ * 256 / (256 - limit);
						out_ = Math.Max(0, out_);
						out_ = Math.Min(out_, 255);

						item.data[x, y] = (byte)Math.Max(0, out_ / colorsLength);
					}

			TrimCharLeft(item);
		}

		void TrimCharLeft(FontItem item)
		{
			for (int y = 0; y < logoEditor.SignHeight; y++)
				if (IsLineEmpty(item, 0))
					ShiftLeft(item);
		}

		bool IsLineEmpty(FontItem item, int x)
		{
			for (int y = 0; y < logoEditor.SignHeight; y++)
				if (item.data[0, y] != 0)
					return false;

			return true;
		}

		void ShiftLeft(FontItem item)
		{
			for (int y = 0; y < logoEditor.SignHeight; y++)
			{
				for (int x = 0; x < logoEditor.SignWidth - 1; x++)
					item.data[x, y] = item.data[x + 1, y];
				item.data[logoEditor.SignWidth - 1, y] = 0;
			}
		}
	}
}
