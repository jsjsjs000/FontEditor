using System;

namespace FontEditor
{
	class FontItem
	{
		public const string NewString = "<new>";

		public string name = "";
		public ulong[] data = new ulong[255];

		public override string ToString()
		{
			return name;
		}

		public static FontItem Import(string s, bool verticalDataOrientation)
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
			int commentIx = s.IndexOf("//");
			if (commentIx == -1)
				commentIx = s.IndexOf("#");
			string comment = NewString;
			if (commentIx > 0)
			{
				values = s.Substring(0, commentIx).Trim(' ', '\t');
				comment = s.Substring(commentIx + 2, s.Length - commentIx - 2).Trim(' ', '\t');
			}

			FontItem item = new FontItem();
			item.data = Common.HexStringToUlongArray(values);

			if (verticalDataOrientation)
			{
				ulong[] newData = new ulong[16];
				for (int x = 0; x < 16; x++)
					for (int y = 0; y < 16; y++)
						if (x < item.data.Length)
						{
							bool bit = (item.data[x] & (1UL << y)) != 0;
							newData[y] |= (bit ? 1UL : 0UL) << (Sign.SignWidth - x - 1);
						}
				item.data = newData;
			}

			Array.Resize(ref item.data, 255);
			item.name = comment;
			return item;
		}
	}
}
