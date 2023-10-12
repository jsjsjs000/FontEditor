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

		public bool GetPixel2(int x, int y)
		{
			if (x < 0 || y < 0 || x >= data.GetLength(0) || y >= data.GetLength(1))
				return false;

			return data[x, y] != 0;
		}

		public byte GetPixel(int x, int y)
		{
			if (x < 0 || y < 0 || x >= data.GetLength(0) || y >= data.GetLength(1))
				return 0;

			return data[x, y];
		}

		public void SetPixel2(int x, int y, bool set)
		{
			if (x < 0 || y < 0 || x >= data.GetLength(0) || y >= data.GetLength(1))
				return;

			data[x, y] = set ? (byte)15 : (byte)0;
		}

		public void SetPixel(int x, int y, byte set)
		{
			if (x < 0 || y < 0 || x >= data.GetLength(0) || y >= data.GetLength(1))
				return;

			data[x, y] = set;
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
				
			string values = s;
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
				if (array.Length > 0)
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
				if (array.Length > 0)
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

			item.name = comment;
			return item;
		}

		public string ExportChar(int Width, int Height, int Colors,
				bool divide, bool addFontWidthAtEnd, bool verticalDataOrientation,
				out byte effectiveWidth)
		{
			effectiveWidth = 0;

			byte[] data_ = new byte[0];
			if (Colors == 16)
			{
				data_ = new byte[Width * 8 / Colors * Height];
				int i = 0;
				for (int y = 0; y < Height; y++)
					for (int x = 0; x < Width; x += 2)
					{
						byte c1 = GetPixel(x, y);
						byte c2 = GetPixel(x + 1, y);
						data_[i++] = (byte)((c1 << 4) | c2);
					}
			}
			else if (Colors == 2)
			{
				data_ = new byte[Width / 8 * Height];
				int i = 0;
				for (int y = 0; y < Height; y++)
					for (int x = 0; x < Width; x++)
					{
						if (GetPixel2(x, y))
							data_[i] |= (byte)(1 << (x % 8));
						if (x % 8 == 8 - 1)
							i++;
					}
			}
			
			string s = Common.ArrayToHexString(data_, divide, data_.Length, 2);
			for (int x = 0; x < Width; x++)
				for (int y = 0; y < Height; y++)
					if (GetPixel2(x, y))
						effectiveWidth = Math.Max(effectiveWidth, (byte)(x + 1));

			return s;
		}
	}
}
