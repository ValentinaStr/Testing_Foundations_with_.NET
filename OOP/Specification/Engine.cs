namespace OOP.Specification
{
	internal class Engine
	{
		private double power;
		private double volume;
		internal string Type { get; set; }
		internal double Power
		{
			get { return power; }
			set
			{
				if (value < 1) throw new ArgumentOutOfRangeException("Wrong Power Of Engine.");
				power = value;
			}
		}

		internal double Volume
		{
			get { return volume; }
			set
			{
				if (value < 0) throw new ArgumentOutOfRangeException("Wrong Volume Of Engine.");
				volume = value;
			}
		}

		internal string SerialNumber { get; set; }
		public Engine(string type, int power, int volume, string serialNumber)
		{
			Type = type;
			Power = power;
			Volume = volume;
			SerialNumber = serialNumber;
		}

		public string GetInformation()
		{
			return "Engine:  \n" +
				"  Type: " + Type +
				"\n  Power: " + Power +
				"\n  Voume: " + Volume +
				"\n  Serial Number:" + SerialNumber + "\n";
		}
	}
}