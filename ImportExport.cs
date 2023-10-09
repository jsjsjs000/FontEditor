using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FontEditor
{
	public partial class SignEditorControl
	{
		//public string ExportChar(bool divide, bool addFontWidthAtEnd,
		//		bool verticalDataOrientation)
		//{
		//	byte[] data_ = new byte[(int)Math.Ceiling((Width + 1) / 8f) * 8 * Height];
		//	//Array.Copy(data, data_, data.Length);
		//	//for (int i = 0; i < data_.Length; i++)
		//	//  data_[i] &= (byte)((1UL << Sign.SignWidth) - 1UL);

		//	//int height = Sign.SignHeight;
		//	//if (verticalDataOrientation)
		//	//{
		//	//  byte[] vdata = new byte[data.Length];
		//	//  for (int x = 0; x < Sign.SignHeight; x++)
		//	//    for (int y = 0; y < Sign.SignWidth; y++)
		//	//      if (Sign.SignWidth - y - 1 >= 0)
		//	//    {
		//	//      bool bit = (data_[x] & (1UL << y)) != 0;
		//	//      vdata[Sign.SignWidth - y - 1] |= (byte)((bit ? 1UL : 0UL) << x);
		//	//    }
		//	//  data_ = vdata;
		//	//  height = Sign.SignWidth;
		//	//}

		//	string s = Common.ArrayToHexString(data_, divide, SignHeight, 2);
		//	//if (SignWidth <= 8)
		//	//  s = Common.ArrayToHexString(data_, divide, SignHeight, 2);
		//	//else if (SignWidth <= 16)
		//	//  s = Common.ArrayToHexString(data_, divide, SignHeight, 4);
		//	//else
		//	//s = Common.ArrayToHexString(data_, divide, SignHeight, 8);
		//	int effectiveWidth = 0;
		//	for (int y = 0; y < SignHeight; y++)
		//	  for (int x = SignWidth - 1; x >= 0; x--)
		//	    if ((data_[y] & (1UL << x)) != 0)
		//	      effectiveWidth = Math.Max(effectiveWidth, (SignWidth - x));
			
		//	//string s;
		//	//if (Sign.SignWidth <= 8)
		//	//  s = Common.ArrayToHexString(data_, divide, height, 2);
		//	//else if (Sign.SignWidth <= 16)
		//	//  s = Common.ArrayToHexString(data_, divide, height, 4);
		//	//else
		//	//  s = Common.ArrayToHexString(data_, divide, height, 8);
		//	//int effectiveWidth = 0;
		//	//for (int y = 0; y < Sign.SignHeight; y++)
		//	//  for (int x = Sign.SignWidth - 1; x >= 0; x--)
		//	//    if ((data_[y] & (1UL << x)) != 0)
		//	//      effectiveWidth = Math.Max(effectiveWidth, (Sign.SignWidth - x));

		//	//if (addFontWidthAtEnd && Sign.SignWidth <= 8)
		//	//  s += ", 0x" + effectiveWidth.ToString("x2");
		//	//if (addFontWidthAtEnd && Sign.SignWidth > 8)
		//	//s += ", 0x" + effectiveWidth.ToString("x4");
		//	//string s = "";//$$$
		//	return s;
		//}

		public static void Import(string s, List<FontItem> items, ListBox.ObjectCollection Items,
				bool verticalDataOrientation)
		{
			string[] lines = s.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
			if (lines.Length > 1 && lines[0].Contains("\t// @"))
			{
				///  // @0 'A' (13 pixels wide)
				///  0x07, 0x00, //      ###     
				///  0x07, 0x00, //      ###     

				string name = "";
				FontItem item = new FontItem();
				//$$$ Array.Resize(ref item.data, SignEditorControl.DataSize);
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
						//$$$ Array.Resize(ref item.data, SignEditorControl.DataSize);
					}
					l++;
				}
			}
			else
			{
				foreach (string line in s.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
				{
					FontItem item = FontItem.Import(line, verticalDataOrientation);
					if (item != null)
					{
						items.Add(item);
						Items.Add(item);
					}
				}
			}
		}
	}
}
