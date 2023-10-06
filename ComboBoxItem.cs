using System;

namespace FontEditor
{
	public class ComboBoxItem
	{
		public int Value;
		public string Display;

		public ComboBoxItem(int Value, string Display)
		{
			this.Value = Value;
			this.Display = Display;
		}

		public override string ToString()
		{
			return Display;
		}
	}
}
