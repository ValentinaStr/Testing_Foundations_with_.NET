namespace OOP.Specification
{
	internal class Transmission
	{
		private int numberOfGears;
		internal string Type { get; set; }
		internal int NumberOfGears
		{
			get { return numberOfGears; }
			set
			{
				if (value < 1) throw new ArgumentOutOfRangeException("Wrong Number of gears.");
				numberOfGears = value;
			}
		}

		internal string Manufacturer { get; set; }
		internal Transmission(string type, int numberOfGears, string manufacturer)
		{
			Type = type;
			NumberOfGears = numberOfGears;
			Manufacturer = manufacturer;
		}

		internal string GetInformation()
		{
			return "Transmission : \n" +
				"  Type:" + Type +
				"\n  Number Of Gears:" + NumberOfGears +
				"\n  Manufacturer:" + Manufacturer + "\n";
		}
	}
}