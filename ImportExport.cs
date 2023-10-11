using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FontEditor
{
	public partial class FormMain
	{
		public void ImportAll(string s, List<FontItem> items, ListBox.ObjectCollection Items,
				bool verticalDataOrientation)
		{
			string[] lines = s.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

			List<string> linesList = new List<string>() { "" };
			foreach (string line in lines)
				if (!line.Contains("//"))
					linesList[linesList.Count - 1] += Environment.NewLine + line;
				else
				{
					linesList[linesList.Count - 1] += Environment.NewLine + line;
					linesList.Add("");
				}

			lines = linesList.ToArray();

			if (lines.Length > 1 && lines[0].Contains(" // @"))
			{
				///  // @0 'A' (13 pixels wide)
				///  0x07, 0x00, //      ###     
				///  0x07, 0x00, //      ###     

				string name = "";
				FontItem item = new FontItem();
				int dataIndex = 0;

				int l = 0;
				foreach (string line_ in lines)
				{
					string line = line_.Trim();
					line = line.Replace('\t', ' ');
					line = line.Replace(Environment.NewLine, " ");
					if (line.IndexOf("// ", StringComparison.CurrentCulture) == 0)
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
						byte[] data = Common.HexStringToByteArray(line);
						Array.Copy(data, 0, item.data, dataIndex, data.Length);
						dataIndex += data.Length;
					}
					else if ((line == "" || l == lines.Length - 1) && dataIndex > 0)
					{
						item.name = name;
						items.Add(item);
						Items.Add(item);
						name = "";
						dataIndex = 0;
						item = new FontItem();
					}
					l++;
				}
			}
			else
			{
				foreach (string line_ in lines)
				{
					string line = line_.Trim();
					line = line.Replace('\t', ' ');
					line = line.Replace(Environment.NewLine, " ");
					if (line != "")
					{
						FontItem item = FontItem.ImportChar(line, verticalDataOrientation,
								logoEditor.SignWidth, logoEditor.SignHeight, logoEditor.Colors);
						if (item != null)
						{
							items.Add(item);
							Items.Add(item);
						}
					}
				}
			}
		}

		public string ExportAll(bool brackets, bool python)
		{
			string s = "";
			List<byte> widths = new List<byte>();

			foreach (FontItem item in items)
			{
				s += "\t";
				if (brackets && python)
					s += "[ ";
				if (brackets && !python)
					s += "{ ";

				string s_ = item.ExportChar(logoEditor.SignWidth, logoEditor.SignHeight,
						logoEditor.Colors, true, cbAddFontWidthAtEnd.Checked,
						cbVerticalDataOrientation.Checked, out byte effectiveWidth);
				s += s_.Replace(Environment.NewLine, Environment.NewLine + "\t");
				widths.Add(effectiveWidth);

				if (brackets && python)
					s += " ]";
				if (brackets && !python)
					s += " }";
				if (cbPythonMode.Checked)
					s += ", # " + item.name + Environment.NewLine;
				else
					s += ", // " + item.name + Environment.NewLine;
			}

			if (cbAddFontWidthAtEnd.Checked)
			{
				string s_ = Common.ArrayToHexString(widths.ToArray(), true, 0, 2);
				if (s_.Contains(Environment.NewLine))
					s_ = s_.Insert(s_.IndexOf(Environment.NewLine[0]), " // width in pixel");
				s_ = Environment.NewLine + s_;
				s_ = s_.Replace(Environment.NewLine, Environment.NewLine + "\t");
				s += Environment.NewLine + s_ + Environment.NewLine;
			}

			return s;
		}
	}
}
