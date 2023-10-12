using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace FontEditor
{
  class Common
  {
    public static string ArrayToString(List<byte> list)
    {
      StringBuilder sb = new StringBuilder();
      foreach (byte b in list)
        sb.Append(b.ToString() + ", ");
      return sb.ToString().TrimEnd(' ').TrimEnd(',');
    }

    public static string ArrayToCompressedString(List<byte> list)
    {
      if (list.Count == 0)
        return "";

      list.Sort();
      StringBuilder sb = new StringBuilder();
      int from = list[0];
      string s = "";
      int last = -1;
      bool first = true;
      foreach (int e in list)
      {
        if (!first && e > last + 1)
        {
          if (s.Length > 0)
            s += ", ";
          if (from == last)
            s += from;
          else
            s += from + "-" + last;
          from = e;
        }
        last = e;
        first = false;
      }
      if (s.Length > 0)
        s += ", ";
      if (from == last)
        s += from;
      else
        s += from + "-" + last;
      return s;
    }

    public static string ArrayToString(List<string> list)
    {
      StringBuilder sb = new StringBuilder();
      foreach (string b in list)
        sb.Append(b.ToString() + ", ");
      return sb.ToString().TrimEnd(' ').TrimEnd(',');
    }

    public static string ArrayToString(ushort[] list)
    {
      StringBuilder sb = new StringBuilder();
      foreach (ushort b in list)
        sb.Append(b.ToString() + ", ");
      return sb.ToString().TrimEnd(' ').TrimEnd(',');
    }

    public static string ArrayToString(int[] list)
    {
      StringBuilder sb = new StringBuilder();
      foreach (int b in list)
        sb.Append(b.ToString() + ", ");
      return sb.ToString().TrimEnd(' ').TrimEnd(',');
    }

    public static string ArrayToHexString(byte[] list, bool divide, int length = 0)
    {
      if (length == 0)
        length = list.Length;
      StringBuilder sb = new StringBuilder();
      int count = 0;
      foreach (byte b in list)
      {
        string s = "0x" + b.ToString("x4") + ", ";
        count++;
        if (divide && count % 8 == 0)
        {
          s = s.TrimEnd(' ');
          s += Environment.NewLine;
        }
        sb.Append(s);
      }
      string s_ = sb.ToString();
      if (s_.EndsWith(Environment.NewLine, StringComparison.CurrentCulture))
        s_ = s_.Substring(0, s_.Length - Environment.NewLine.Length);
      return s_.TrimEnd(' ').TrimEnd(',');
    }

    public static string ArrayToHexString(byte[] list, bool divide, int length = 0, int digits = 16)
    {
      if (length == 0)
        length = list.Length;
      StringBuilder sb = new StringBuilder();
      int count = 0;
      foreach (ulong b in list)
      {
        string s = "0x" + b.ToString("x" + digits) + ", ";
        count++;
        if (divide && count % 8 == 0)
        {
          s = s.TrimEnd(' ');
          s += Environment.NewLine;
        }
        sb.Append(s);
        if (count >= length)
          break;
      }
      string s_ = sb.ToString();
      if (s_.EndsWith(Environment.NewLine, StringComparison.CurrentCulture))
        s_ = s_.Substring(0, s_.Length - Environment.NewLine.Length);
      return s_.TrimEnd(' ').TrimEnd(',');
    }

    public static string ArrayBytesToHexString(byte[] list)
    {
      StringBuilder sb = new StringBuilder();
      foreach (byte b in list)
        sb.Append(b.ToString("x2") + " ");
      return sb.ToString().TrimEnd(' ').TrimEnd(',');
    }

    public static string GetBeginningStringInArray(List<string> list, string beginString)
    {
      foreach (string s in list)
        if (s.IndexOf(beginString, StringComparison.CurrentCulture) == 0)
          return s;
      return "";
    }

    public static byte GetDigitFromNumber(int number, int digitNumber)
    {
      int power = (int)Math.Pow(10, digitNumber);
      int divided = number / power;
      return (byte)(divided - divided / 10 * 10);
    }

    public static string RevertString(string s)
    {
      string t = "";
      for (int i = s.Length - 1; i >= 0; i--)
        t += s[i];
      return t;
    }

      /// list must be sorted before
    public static void RemoveDuplicatesFromSortedList(List<byte> list)
    {
      for (int i = list.Count - 1; i > 0; i--)
        if (list[i] == list[i - 1])
          list.RemoveAt(i);
    }

    public static int IsSubArray(byte[] data, byte[] search)
    {
      if (search.Length > data.Length)
        return -1;

      for (int i = 0; i < data.Length - search.Length; i++)
      {
        bool found = true;
        for (int j = 0; j < search.Length; j++)
          if (data[i + j] != search[j])
          {
            found = false;
            break;
          }
        if (found)
          return i;
      }
      return -1;
    }

		public static bool ParseByteOrHex(string s, out byte value)
		{
			byte a;
			s = s.Trim();

			if (s.Length > 2 && s[0] == '0' && s[1] == 'x')
			{
				s = s.Substring(2, s.Length - 2);
				if (byte.TryParse(s, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out a))
				{
					value = a;
					return true;
				}
			}
			else if (byte.TryParse(s, out a))
			{
				value = a;
				return true;
			}

			value = 0;
			return false;
		}

		public static bool ParseIntOrHex(string s, out ushort value)
    {
      ushort a;
      s = s.Trim();

      if (s.Length > 2 && s[0] == '0' && s[1] == 'x')
      {
        s = s.Substring(2, s.Length - 2);
        if (ushort.TryParse(s, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out a))
        {
          value = a;
          return true;
        }
      }
      else if (ushort.TryParse(s, out a))
      {
        value = a;
        return true;
      }

      value = 0;
      return false;
    }

    public static bool ParseIntOrHex(string s, out uint value)
    {
      uint a;
      s = s.Trim();

      if (s.Length > 2 && s[0] == '0' && s[1] == 'x')
      {
        s = s.Substring(2, s.Length - 2);
        if (uint.TryParse(s, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out a))
        {
          value = a;
          return true;
        }
      }
      else if (uint.TryParse(s, out a))
      {
        value = a;
        return true;
      }

      value = 0;
      return false;
    }

    public static bool ParseULongOrHex(string s, out ulong value)
    {
      ulong a;
      s = s.Trim();

      if (s.Length > 2 && s[0] == '0' && s[1] == 'x')
      {
        s = s.Substring(2, s.Length - 2);
        if (ulong.TryParse(s, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out a))
        {
          value = a;
          return true;
        }
      }
      else if (ulong.TryParse(s, out a))
      {
        value = a;
        return true;
      }

      value = 0;
      return false;
    }

    public static string SplitWordsAddSpaces(string s)
    {
      string t = "";
      bool lastUpper = true;
      bool lastDigit = true;
      foreach (char s_ in s)
      {
        bool isUpper = (int)s_ >= (int)'A' && (int)s_ <= (int)'Z';
        bool isDigit = (int)s_ >= (int)'0' && (int)s_ <= (int)'9';
        if (!lastDigit && isDigit || !lastUpper && isUpper)
          t += " " + s_;
        else
          t += s_;
        lastUpper = isUpper;
        lastDigit = isDigit;
      }
      return t;
    }

		public static byte[] HexStringToByteArray(string s)
		{
			List<byte> array = new List<byte>();
			s = s.Replace(",", " ").Replace("\r", " ").Replace("\n", " ");
			string[] words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string word in words)
			{
				if (!ParseByteOrHex(word, out byte us))
					return new byte[0];
				array.Add(us);
			}
			return array.ToArray();
		}

		public static byte[,] HexStringToByteArray(string s, int width, int height)
		{
			byte[,] array = new byte[width, height];
			s = s.Replace(",", " ").Replace("\r", " ").Replace("\n", " ");
			string[] words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

			int x = 0;
			int y = 0;
			foreach (string word in words)
			{
				if (!ParseByteOrHex(word, out byte a))
					return new byte[0, 0];

				array[x, y] = a;

				x = (x + 1) % width;
				if (x == 0)
					y++;
			}
			return array;
		}

		public static string SizeToKMG_Size(int a)
    {
      if (a < 1024)
        return a.ToString() + " B";
      else if (a < 1024 * 1024)
        return (a / 1024f).ToString("#.##") + " KB";
      else if (a < 1024 * 1024 * 1024)
        return (a / 1024f / 1024f).ToString("#.##") + " MB";
      return (a / 1024f / 1024f / 1024f).ToString("#.##") + " GB";
    }

    public static ushort[] CloneArray(ushort[] array)
    {
      ushort[] copy = new ushort[array.Length];
      Array.Copy(array, copy, array.Length);
      return copy;
    }

    public static byte[] ConvertToByteArray(ushort[] array)
    {
      byte[] outArray = new byte[array.Length * 2];
      int j = 0;
      for (int i = 0; i < array.Length; i++)
      {
        outArray[j++] = (byte)(array[i] & 0xff);
        outArray[j++] = (byte)(array[i] >> 8);
      }
      return outArray;
    }

    public static List<byte> ConvertByteArrayToList(byte[] array, int from, int count)
    {
      List<byte> list = new List<byte>();
      for (int i = from; i < from + count; i++)
        if (i < array.Length)
          list.Add(array[i]);
      return list;
    }

    public static bool ParseHostnameAndPort(string text, int defaultPort, out string hostname, out int port)
    {
      if (text.Contains(":"))
      {
        string[] array = text.Split(new char[] { ':' });
        hostname = array[0];
        return int.TryParse(array[1], out port);
      }
      else
      {
        hostname = text;
        port = defaultPort;
        return true;
      }
    }

    public static void SetDateFormat()
    {
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("pl-PL");
      Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortTimePattern = "HH:mm";
      Thread.CurrentThread.CurrentCulture.DateTimeFormat.LongTimePattern = "HH:mm:ss";
      Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
      Thread.CurrentThread.CurrentCulture.DateTimeFormat.LongDatePattern = "d MMMM yyyy";
    }
  }
}
