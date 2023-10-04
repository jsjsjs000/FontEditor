﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
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

    public static string ArrayToHexString(ushort[] list, bool divide, int length = 0)
    {
      if (length == 0)
        length = list.Length;
      StringBuilder sb = new StringBuilder();
      int count = 0;
      foreach (ushort b in list)
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
      if (s_.EndsWith(Environment.NewLine))
        s_ = s_.Substring(0, s_.Length - Environment.NewLine.Length);
      return s_.TrimEnd(' ').TrimEnd(',');
    }

    public static string ArrayToHexString(ulong[] list, bool divide, int length = 0, int digits = 16)
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
      if (s_.EndsWith(Environment.NewLine))
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
        if (s.IndexOf(beginString) == 0)
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
      if (s.Length % 2 != 0)
        return new byte[0];

      byte[] result = new byte[s.Length / 2];
      for (int i = 0; i < s.Length; i++)
      {
        byte a;
        if (!byte.TryParse(s[i].ToString(), NumberStyles.HexNumber, CultureInfo.CurrentCulture, out a))
          return new byte[0];
        if (i % 2 == 0)
          result[i / 2] = (byte)(a << 4);
        else
          result[i / 2] |= a;
      }

      return result;
    }

    public static ushort[] HexStringToUshortArray(string s)
    {
      List<ushort> array = new List<ushort>();
      s = s.Replace(",", " ").Replace("\r", " ").Replace("\n", " ");
      string[] words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      foreach (string word in words)
      {
        ushort us;
        if (!ParseIntOrHex(word, out us))
          return new ushort[0];
        array.Add(us);
      }
      return array.ToArray();
    }

    public static ulong[] HexStringToUlongArray(string s)
    {
      List<ulong> array = new List<ulong>();
      s = s.Replace(",", " ").Replace("\r", " ").Replace("\n", " ");
      string[] words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      foreach (string word in words)
      {
        ulong us;
        if (!ParseULongOrHex(word, out us))
          return new ulong[0];
        array.Add(us);
      }
      return array.ToArray();
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

    public static ushort[] ConvertToUshortArray(byte[] array)
    {
      ushort[] outArray = new ushort[array.Length / 2];
      int j = 0;
      for (int i = 0; i < array.Length; i += 2)
      {
        outArray[j] = array[i];
        if (i + 1 < array.Length)
          outArray[j] |= (ushort)(array[i + 1] << 8);
        j++;
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

    public static DateTime GetPreviousMonth(DateTime dt)
    {
      return (new DateTime(dt.Date.Year, dt.Date.Month, 1)).AddSeconds(-1);
    }

    public static DateTime GetMonth(DateTime dt)
    {
      return (new DateTime(dt.Date.Year, dt.Date.Month, 1));
    }

    public static DateTime GetNextMonth(DateTime dt)
    {
      return (new DateTime(dt.Date.Year, dt.Date.Month, 1)).AddMonths(1);
    }

    public static bool IsTheSameMonth(DateTime dt1, DateTime dt2)
    {
      return dt1.Year == dt2.Year && dt1.Month == dt2.Month;
    }

    public static DateTime Min(DateTime dt1, DateTime dt2)
    {
      return (dt1 < dt2) ? dt1 : dt2;
    }

    public static DateTime Max(DateTime dt1, DateTime dt2)
    {
      return (dt1 > dt2) ? dt1 : dt2;
    }

    public static TimeSpan Min(TimeSpan dt1, TimeSpan dt2)
    {
      return (dt1 < dt2) ? dt1 : dt2;
    }

    public static TimeSpan Max(TimeSpan dt1, TimeSpan dt2)
    {
      return (dt1 > dt2) ? dt1 : dt2;
    }

    public static DateTime RoundDateTime10m(DateTime dt)
    {
      return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute % 10, 0);
    }

    public static DateTime RoundDateTime1h(DateTime dt)
    {
      return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0);
    }

    public static DateTime RoundDateTime1d(DateTime dt)
    {
      return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
    }

    ///   tests:
    /// DateTime from = new DateTime(2017, 9, 9); DateTime to = new DateTime(2017, 9, 20, 23, 59, 59);
    /// DateTime from = new DateTime(2017, 9, 9); DateTime to = new DateTime(2017, 10, 20, 23, 59, 59);
    /// DateTime from = new DateTime(2017, 9, 9); DateTime to = new DateTime(2017, 12, 20, 23, 59, 59);
    /// DateTime from = new DateTime(2017, 9, 1); DateTime to = new DateTime(2017, 9, 30, 23, 59, 59);
    /// DateTime from = new DateTime(2017, 9, 1); DateTime to = new DateTime(2017, 10, 31, 23, 59, 59);
    /// List<List<DateTime>> months = Common.GetMonthsList(from, to);

    public static List<List<DateTime>> GetMonthsList(DateTime from, DateTime to)
    {
      List<List<DateTime>> months = new List<List<DateTime>>();
      DateTime dt = from;
      DateTime dt2 = GetNextMonth(from).AddSeconds(-1);
      do
      {
        if (IsTheSameMonth(from, dt))
          months.Add(new List<DateTime>() { from, Min(to, dt2) });
        else
          months.Add(new List<DateTime>() { dt, Min(to, dt2) });

        dt = GetNextMonth(dt);
        dt2 = GetNextMonth(dt).AddSeconds(-1);
      }
      while (dt2 < to);

      if (dt < Min(to, dt2))
        months.Add(new List<DateTime>() { dt, Min(to, dt2) });

      return months;
    }


    //public static string EncodeBZip2String(string s)
    //{
    //  MemoryStream msIn = new MemoryStream();
    //  StreamWriter swIn = new StreamWriter(msIn);
    //  swIn.Write(s);
    //  swIn.Flush();
    //  msIn.Position = 0;
    //  MemoryStream msOut = new MemoryStream();
    //  BZip2.Compress(msIn, msOut, false, 9);
    //  msOut.Position = 0;
    //  byte[] dataOut = new byte[msOut.Length];
    //  msOut.Read(dataOut, 0, (int)msOut.Length);
    //  return Convert.ToBase64String(dataOut);
    //}

    //public static string DecodeBZip2String(string s)
    //{
    //  byte[] dataIn = Convert.FromBase64String(s);
    //  MemoryStream msIn = new MemoryStream();
    //  msIn.Write(dataIn, 0, dataIn.Length);
    //  msIn.Flush();
    //  msIn.Position = 0;
    //  MemoryStream msOut = new MemoryStream();
    //  BZip2.Decompress(msIn, msOut, false);
    //  msOut.Position = 0;
    //  StreamReader srOut = new StreamReader(msOut);
    //  return srOut.ReadToEnd();
    //}

    //public static string EncodeGZipString(string text)
    //{
    //  byte[] buffer = Encoding.UTF8.GetBytes(text);
    //  MemoryStream ms = new MemoryStream();
    //  using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true))
    //    zip.Write(buffer, 0, buffer.Length);

    //  byte[] compressed = new byte[ms.Length];
    //  ms.Position = 0;
    //  ms.Read(compressed, 0, (int)ms.Length);
    //  return Convert.ToBase64String(compressed);
    //}

    //public static string DecodeGZipString(string s)
    //{
    //  byte[] data = Convert.FromBase64String(s);
    //  MemoryStream ms = new MemoryStream(data);
    //  using (GZipStream zip = new GZipStream(ms, CompressionMode.Decompress))
    //  {
    //    int readBytes = 64 * 1;
    //    byte[] buffer = new byte[readBytes];
    //    int totalCount = 0;
    //    int count = 0;
    //    while ((count = zip.Read(buffer, totalCount, readBytes)) > 0)
    //    {
    //      totalCount += count;
    //      if (count < readBytes)
    //        break;
    //      Array.Resize(ref buffer, buffer.Length + readBytes);
    //    }
    //    if (buffer.Length != totalCount)
    //      Array.Resize(ref buffer, totalCount);
    //    return Encoding.UTF8.GetString(buffer);
    //  }
    //}

    static Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();

    public static void StartTimer()
    {
      stopwatch.Start();
    }

    public static long StopTimerAndGetTicks()
    {
      long a = stopwatch.ElapsedTicks;
      stopwatch.Start();
      return a;
    }

    public static long GetTicks()
    {
      return Environment.TickCount;
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
