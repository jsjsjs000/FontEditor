using System;
using System.Collections.Generic;
using System.Drawing;
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

			nudWidth.Value = 16;
			nudHeight.Value = 16;

			logoEditor.data = new ulong[255];
			logoEditor.ButtonClearText = "Clear";
			logoEditor.ButtonInvertText = "Invert";
			logoEditor.HideButtonSaveAndCancel();
			logoEditor.UpdatePreview();
			logoEditor.UpdateControlSize();

			ClearAll();

			// GenerateFontChars("Ag");
			// GenerateFontChars("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789");
			GenerateFontChars(" !\"#$%&'()*+,-./0123456789:/<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[ ]^_`abcdefghijklmnopqrstuvwxyz |}~ ");

			this.MinimumSize = new Size(this.Width, this.Height);
			this.MaximumSize = new Size(this.Width, ushort.MaxValue);
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

		private void nudWidth_ValueChanged(object sender, EventArgs e)
		{
			Sign.SignWidth = (int)nudWidth.Value;
			logoEditor.RecreatePreviewPictures();
			logoEditor.UpdatePreview();
			logoEditor.UpdateControlSize();
		}

		private void nudHeight_ValueChanged(object sender, EventArgs e)
		{
			Sign.SignHeight = (int)nudHeight.Value;
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

		private void listBox_SelectedIndexChanged(object sender, EventArgs e)
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

		private void textBoxName_TextChanged(object sender, EventArgs e)
		{
			if (!canUpdateControls)
				return;

			canUpdateControls = false;
			FontItem item = (FontItem)listBox.SelectedItem;
			item.name = this.textBoxName.Text;
			this.listBox.Refresh();
			canUpdateControls = true;
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			FontItem item = new FontItem() { name = FontItem.NewString };
			items.Add(item);
			listBox.Items.Add(item);
			listBox.SelectedIndex = listBox.Items.Count - 1;
		}

		private void buttonRemove_Click(object sender, EventArgs e)
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

		private void buttonLoadAll_Click(object sender, EventArgs e)
		{
			canUpdateControls = false;

			RemoveAllNewItems();

			string s = Clipboard.GetText();
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
					if (line.IndexOf("// @") == 0)
					{
						name = "";
						int i = line.IndexOf('\'');
						if (i > 0)
							name = line[i + 1].ToString();
					}
					else if (line.IndexOf(", // ") > 0)
					{
						int c = line.IndexOf(", // ");
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

		private void buttonSaveTo_Click(object sender, EventArgs e)
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
			Clipboard.SetText(s);
		}

		private void buttonClearAll_Click(object sender, EventArgs e)
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

		void GenerateFontChars(string chars)
		{
			canUpdateControls = false;

			RemoveAllNewItems();

			Bitmap bitmap = new Bitmap(128, 128);
			Graphics graphic = Graphics.FromImage(bitmap);
			//graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
			//graphic.TextContrast = 0;
			//graphic.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

			Font font = new Font("Ubuntu", 14);
			Point offset = new Point(0, -4);

			foreach (char c in chars)
			{
				FontItem item = new FontItem { name = c.ToString() };
				Array.Resize(ref item.data, 255);
				items.Add(item);
				listBox.Items.Add(item);
				GenerateFontChar(font, graphic, bitmap, item, c, offset);
			}

			font.Dispose();
			graphic.Dispose();
			bitmap.Dispose();
			canUpdateControls = true;

			if (listBox.Items.Count > 0)
				listBox.SelectedIndex = listBox.Items.Count - 1;
		}

		void GenerateFontChar(Font font, Graphics graphics, Bitmap bitmap, FontItem item, char c, Point offset)
		{
			graphics.FillRectangle(Brushes.Black, 0, 0, bitmap.Width, bitmap.Height);
			graphics.DrawString(c.ToString(), font, Brushes.White, offset);

			for (int y = 0; y < 16; y++)
				for (int x = 0; x < 16; x++)
					if (bitmap.GetPixel(x, y).R >= 0x7f)
						item.data[y] |= 1U << (16 - 1 - x);
		}
	}
}

/*
	button generate
	text box chars
	16 kolorów z krzywą gammy
	interpolacja przy zapisie znaku
*/
