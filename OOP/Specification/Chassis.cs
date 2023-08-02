namespace OOP.Specification
{
	internal class Chassis
	{
		private int countOfWheels;
		internal string NumberOfChassis { get; set; }
		internal int BearingCapacity { get; set; }
		internal int CountOfWheels
		{
			get { return countOfWheels; }
			set
			{
				if (value < 1) throw new ArgumentOutOfRangeException("Wrong Count Of Wheels.");
				countOfWheels = value;
			}
		}

		internal Chassis(int countOfWheels, string numberOfChassis, int bearingCapacity)
		{
			CountOfWheels = countOfWheels;
			NumberOfChassis = numberOfChassis;
			BearingCapacity = bearingCapacity;
		}

		internal string GetInformation()
		{
			return "Chassis:  \n" +
				"  Count Of Wheels: " + CountOfWheels +
				"\n  Number Of Chassis: " + NumberOfChassis +
				"\n  Bearing Capacity:" + BearingCapacity;
		}
	}
}