using System;

namespace FontEditor
{
	public class FontItem
	{
		public const string NewString = "<new>";

		public string name = "";
		public byte[,] data = new byte[SignEditorControl.MaxSize, SignEditorControl.MaxSize];

		public override string ToString()
		{
			return name;
		}

		public static FontItem ImportChar(string s, bool verticalDataOrientation,
				int Width, int Height, int Colors)
		{
				/// { 0x1234, 0x1234, 0x1234, 0x1234, 0x1234, 0x1234, 0x1234, 0x1234 }
			s = s.Trim(' ', '\t');
			if (s.Length > 1 && s[0] != '{' && s.IndexOf('}') >= 0)
				s = s.Replace('{', ' ').Replace('}', ' ');

				/// [0x7e, 0x11, 0x11, 0x11, 0x7e], # 41 A
			if (s.Length > 1 && s[0] == '[' && s.IndexOf(']') >= 0)
				s = s.Replace('[', ' ').Replace(']', ' ');

			//int endBracketIx = s.IndexOf('}');
			//if (endBracketIx < 0)
			//  return null;

			string values = s;// s.Substring(1, endBracketIx - 1).Trim();
			int commentIx = s.IndexOf("//", StringComparison.CurrentCulture);
			if (commentIx == -1)
				commentIx = s.IndexOf("#", StringComparison.CurrentCulture);
			string comment = NewString;
			if (commentIx > 0)
			{
				values = s.Substring(0, commentIx).Trim(' ', '\t');
				comment = s.Substring(commentIx + 2, s.Length - commentIx - 2).Trim(' ', '\t');
			}

			FontItem item = new FontItem();

			byte[,] array = new byte[0, 0];
			if (Colors == 16)
			{
				array = Common.HexStringToByteArray(values, Width * 8 / Colors, Height);
				for (int y = 0; y < array.GetLength(1); y++)
					for (int x = 0; x < array.GetLength(0); x++)
					{
						item.data[x * 2,     y] = (byte)(array[x, y] >> 4);
						item.data[x * 2 + 1, y] = (byte)(array[x, y] & 0x0f);
					}
			}
			else if (Colors == 2)
			{
				array = Common.HexStringToByteArray(values, Width / 8, Height);
				for (int y = 0; y < Height; y++)
					for (int x = 0; x < Width; x++)
						if ((array[x / 8, y] & (1 << (x % 8))) != 0)
							item.data[x, y] = 16 - 1;
			}

			if (verticalDataOrientation)
			{
				byte[,] newData = new byte[SignEditorControl.MaxSize, SignEditorControl.MaxSize];
				for (int x = 0; x < 16; x++)
					for (int y = 0; y < 16; y++)
						if (x < item.data.Length)
						{
							//bool bit = GetPixel(x, y);
							//bool bit = (item.data[x] & (1UL << y)) != 0;
							//newData[y] |= (byte)((bit ? 1UL : 0UL) << (Sign.SignWidth - x - 1));
						}
				item.data = newData;
			}

			//Array.Resize(ref item.data, 255); $$$
			item.name = comment;
			return item;
		}
	}
}
