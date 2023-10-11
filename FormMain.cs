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
			cbColors.Items.Add(new ComboBoxItem(16, "16"));
			cbColors.SelectedIndex = 1;

			logoEditor.SetFontItem(new FontItem());
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
			nudLimit.Value = 0;

			this.MinimumSize = new Size(this.Width, this.Height);
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
			logoEditor.SignWidth = (int)nudWidth.Value;
			logoEditor.RecreatePreviewPictures();
			logoEditor.UpdatePreview();
			logoEditor.UpdateControlSize();
		}

		private void NudHeight_ValueChanged(object sender, EventArgs e)
		{
			logoEditor.SignHeight = (int)nudHeight.Value;
			logoEditor.RecreatePreviewPictures();
			logoEditor.UpdatePreview();
			logoEditor.UpdateControlSize();
		}

		private void CbColors_IndexChanged(object sender, EventArgs e)
		{
			logoEditor.Colors = ((ComboBoxItem)cbColors.SelectedItem).Value;
			logoEditor.RecreatePreviewPictures();
			logoEditor.UpdatePreview();
			logoEditor.UpdateControlSize();
		}

		private void FormMain_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && !e.Alt && e.KeyCode == Keys.C)
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
			logoEditor.SetFontItem(item);
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

		bool IsArrayEmpty(byte[,] array)
		{
			foreach (byte item in array)
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

			ImportAll(s, items, listBox.Items, cbVerticalDataOrientation.Checked);

			canUpdateControls = true;
			listBox.SelectedIndex = listBox.Items.Count - 1;
		}

		private void ButtonSaveAll_Click(object sender, EventArgs e)
		{
			string s = ExportAll(cbArrayBrackets.Checked, cbPythonMode.Checked);

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

		private void BtnGenerateFonts_Click(object sender, EventArgs e)
		{
			int i = listBox.SelectedIndex;
			canUpdateControls = false;

			GenerateFontChars(cbFonts.Text, float.Parse(cbFontSize.Text),
					cbBold.Checked, cbItalic.Checked, (int)nudOffsetY.Value, cbFontInterpolate.Checked,
					(byte)nudLimit.Value, tbGenerateChars.Text);

			canUpdateControls = true;
			if (i >= 0 && i < listBox.Items.Count)
				listBox.SelectedIndex = i;
			else if (listBox.Items.Count > 0)
				listBox.SelectedIndex = listBox.Items.Count - 1;
		}
	}
}
