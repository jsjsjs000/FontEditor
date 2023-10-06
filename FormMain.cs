using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FontEditor
{
	public partial class FormMain : Form
	{
		List<FontItem> items = new List<FontItem>();
		bool canUpdateControls = true;

		public FormMain()
		{
			InitializeComponent();

			this.Text = Program.ProgramName +
					" v" + Program.ProgramVersionMajor + "." + Program.ProgramVersionMinor;
			//+ "." + Program.ProgramVersionBuild + "." + Program.ProgramVersionRevision + " " +
			//Program.ProgramBuildDateTime;

			canUpdateControls = false;
			nudWidth.Value = 16;
			nudHeight.Value = 16;
			cbColors.Items.Add(new ComboBoxItem(2, "2"));
			cbColors.Items.Add(new ComboBoxItem(4, "4"));
			cbColors.Items.Add(new ComboBoxItem(8, "8"));
			cbColors.Items.Add(new ComboBoxItem(16, "16"));
			cbColors.SelectedIndex = 3; // $$

			logoEditor.data = new ulong[255];
			logoEditor.ButtonClearText = "Clear";
			logoEditor.ButtonInvertText = "Invert";
			canUpdateControls = true;

			logoEditor.HideButtonSaveAndCancel();
			logoEditor.UpdatePreview();
			logoEditor.UpdateControlSize();

			int i = -1;
			using (InstalledFontCollection collection = new InstalledFontCollection())
				foreach (FontFamily family in collection.Families)
				{
					cbFonts.Items.Add(family.Name);
					if (i == -1 && (family.Name == "Tahoma" || family.Name == "Verdana" || family.Name == "Ubuntu"))
						i = cbFonts.Items.Count - 1;
				}
			if (i >= 0)
				cbFonts.SelectedIndex = i;
			cbFontSize.SelectedIndex = 4;

			ClearAll();

			string Chars = " !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~ ";
			Chars += "ąćęłńóśżźĄĆĘŁŃÓŚŻŹ";
			tbGenerateChars.Text = Chars;

			//this.MinimumSize = new Size(this.Width, this.Height);
			//this.MaximumSize = new Size(this.Width, ushort.MaxValue);
		}

		void ClearAll()
		{
			items.Clear();
			listBox.Items.Clear();
			FontItem item = new FontItem() { name = FontItem.NewString };
			items.Add(item);
			listBox.Items.Add(item);
			listBox.SelectedIndex = 0;
		}

		private void NudWidth_ValueChanged(object sender, EventArgs e)
		{
			Sign.SignWidth = (int)nudWidth.Value;
			logoEditor.RecreatePreviewPictures();
			logoEditor.UpdatePreview();
			logoEditor.UpdateControlSize();
		}

		private void NudHeight_ValueChanged(object sender, EventArgs e)
		{
			Sign.SignHeight = (int)nudHeight.Value;
			logoEditor.RecreatePreviewPictures();
			logoEditor.UpdatePreview();
			logoEditor.UpdateControlSize();
		}

		private void CbColors_IndexChanged(object sender, EventArgs e)
		{
			Sign.Colors = ((ComboBoxItem)cbColors.SelectedItem).Value;
			logoEditor.RecreatePreviewPictures();
			logoEditor.UpdatePreview();
			logoEditor.UpdateControlSize();
		}

		private void FormMain_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && !e.Shift && !e.Alt && e.KeyCode == Keys.C)
				logoEditor.CopyToClipboard(cbAddFontWidthAtEnd.Checked, cbVerticalDataOrientation.Checked);
			if (e.Control && !e.Shift && !e.Alt && e.KeyCode == Keys.V)
				logoEditor.PasteFromClipboard();
		}

		private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!canUpdateControls)
				return;

			canUpdateControls = false;
			FontItem item = (FontItem)listBox.SelectedItem;
			this.textBoxName.Text = item.name;
			logoEditor.data = item.data;
			logoEditor.UpdatePreview();
			logoEditor.UpdateControlSize();
			canUpdateControls = true;
		}

		private void TextBoxName_TextChanged(object sender, EventArgs e)
		{
			if (!canUpdateControls)
				return;

			canUpdateControls = false;
			FontItem item = (FontItem)listBox.SelectedItem;
			item.name = this.textBoxName.Text;
			this.listBox.Refresh();
			canUpdateControls = true;
		}

		private void ButtonAdd_Click(object sender, EventArgs e)
		{
			FontItem item = new FontItem() { name = FontItem.NewString };
			items.Add(item);
			listBox.Items.Add(item);
			listBox.SelectedIndex = listBox.Items.Count - 1;
		}

		private void ButtonRemove_Click(object sender, EventArgs e)
		{
			if (listBox.Items.Count <= 1)
				return;

			canUpdateControls = false;
			int ix = listBox.SelectedIndex;
			listBox.Items.RemoveAt(ix);
			items.RemoveAt(ix);
			canUpdateControls = true;
			listBox.SelectedIndex = Math.Min(ix, listBox.Items.Count - 1);
		}

		bool IsArrayEmpty(ulong[] array)
		{
			foreach (ulong item in array)
				if (item != 0)
					return false;
			return true;
		}

		void RemoveAllNewItems()
		{
			while (items.Count >= 1 && items[0].name == "<new>" && IsArrayEmpty(items[0].data))
			{
				items.RemoveAt(0);
				listBox.Items.RemoveAt(0);
			}
		}

		private void ButtonLoadAll_Click(object sender, EventArgs e)
		{
			canUpdateControls = false;

			RemoveAllNewItems();

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

			string[] lines = s.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
			if (lines.Length > 1 && lines[0].Contains("\t// @"))
			{
				///  // @0 'A' (13 pixels wide)
				///  0x07, 0x00, //      ###     
				///  0x07, 0x00, //      ###     

				string name = "";
				FontItem item = new FontItem();
				Array.Resize(ref item.data, 255);
				int dataIndex = 0;

				int l = 0;
				foreach (string line_ in lines)
				{
					string line = line_.Trim();
					if (line.IndexOf("// @", StringComparison.CurrentCulture) == 0)
					{
						name = "";
						int i = line.IndexOf('\'');
						if (i > 0)
							name = line[i + 1].ToString();
					}
					else if (line.IndexOf(", // ", StringComparison.CurrentCulture) > 0)
					{
						int c = line.IndexOf(", // ", StringComparison.CurrentCulture);
						line = line.Substring(0, c);
						line.Split(',');

						line = line.Replace(", 0x", "");
						ulong[] data = Common.HexStringToUlongArray(line);
						Array.Copy(data, 0, item.data, dataIndex, data.Length);
						dataIndex += data.Length;
					}
					else if ((line == "" || l == lines.Length - 1) && dataIndex > 0)
					{
						item.name = name;
						items.Add(item);
						listBox.Items.Add(item);
						name = "";
						dataIndex = 0;
						item = new FontItem();
						Array.Resize(ref item.data, 255);
					}
					l++;
				}
			}
			else
			{
				foreach (string line in s.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
				{
					FontItem item = FontItem.Import(line, cbVerticalDataOrientation.Checked);
					if (item != null)
					{
						items.Add(item);
						listBox.Items.Add(item);
					}
				}
			}
			canUpdateControls = true;
			listBox.SelectedIndex = listBox.Items.Count - 1;
		}

		private void ButtonSaveTo_Click(object sender, EventArgs e)
		{
			bool python = cbPythonMode.Checked;
			bool brackets = cbArrayBrackets.Checked;

			string s = "";
			foreach (FontItem item in items)
			{
				s += "\t";
				if (brackets && python)
					s += "[ ";
				if (brackets && !python)
					s += "{ ";
				s += SignEditorControl.Export(item.data, false, cbAddFontWidthAtEnd.Checked,
						cbVerticalDataOrientation.Checked);
				if (brackets && python)
					s += " ]";
				if (brackets && !python)
					s += " }";
				if (cbPythonMode.Checked)
					s += ", # " + item.name + Environment.NewLine;
				else
					s += ", // " + item.name + Environment.NewLine;
			}

			try
			{
				Clipboard.SetText(s);
			}
			catch
			{
				Console.WriteLine("Can't write to clipboard.");
			}
		}

		private void ButtonClearAll_Click(object sender, EventArgs e)
		{
			ClearAllWithQuestion();
		}

		bool ClearAllWithQuestion()
		{
			if (MessageBox.Show("Do you want clear all data?", Program.ProgramName, MessageBoxButtons.YesNo,
					MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
				return false;

			ClearAll();
			return true;
		}

		void GenerateFontChars(string fontFamily, float fontSize, bool bold, bool italic, int offsetY,
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
				Array.Resize(ref item.data, 255);
				items.Add(item);
				listBox.Items.Add(item);
				GenerateFontChar(font, graphic, bitmap, item, offset, limit, c);
			}

			font.Dispose();
			graphic.Dispose();
			bitmap.Dispose();
		}

		void GenerateFontChar(Font font, Graphics graphics, Bitmap bitmap, FontItem item, Point offset, byte limit, char c)
		{
			graphics.FillRectangle(Brushes.Black, 0, 0, bitmap.Width, bitmap.Height);
			graphics.DrawString(c.ToString(), font, Brushes.White, offset);

			for (int y = 0; y < Sign.SignHeight; y++)
				for (int x = 0; x < Sign.SignWidth; x++)
					if (bitmap.GetPixel(x, y).R >= limit)
						item.data[y] |= 1U << (16 - 1 - x);

			TrimCharLeft(item.data);
		}

		void TrimCharLeft(ulong[] data)
		{
			for (int y = 0; y < Sign.SignHeight; y++)
				if (IsLineEmpty(data, 0))
					ShiftLeft(data);
		}

		bool IsLineEmpty(ulong[] data, int x)
		{
			for (int y = 0; y < Sign.SignHeight; y++)
				if (((data[y] >> (16 - 1 - x)) & 0x01) > 0)
					return false;

			return true;
		}

		void ShiftLeft(ulong[] data)
		{
			for (int y = 0; y < Sign.SignHeight; y++)
				data[y] = data[y] << 1;
		}

		private void BtnGenerateFonts_Click(object sender, EventArgs e)
		{
			int i = listBox.SelectedIndex;
			canUpdateControls = false;

			GenerateFontChars(cbFonts.Text, float.Parse(cbFontSize.Text), cbBold.Checked, cbItalic.Checked,
					(int)nudOffsetY.Value, cbFontInterpolate.Checked, (byte)nudLimit.Value, tbGenerateChars.Text);

			canUpdateControls = true;
			//if (i >= 0 && i < listBox.Items.Count) $$
			//	listBox.SelectedIndex = i;
			//else if (listBox.Items.Count > 0)
			//listBox.SelectedIndex = listBox.Items.Count - 1;

			listBox.SelectedIndex = 19;
		}
	}
}

/*
	ilość kolorów 16 kolorów z krzywą gammy
	button - interpolacja przy zapisie znaku
*/
