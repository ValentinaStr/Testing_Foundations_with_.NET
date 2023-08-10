using System.Xml.Linq;

namespace OOP.Specification
{
	public class Chassis
	{
		private int countOfWheels;
		private int bearingCapacity;
		internal string NumberOfChassis { get; set; }
		internal int BearingCapacity
		{
			get { return bearingCapacity; }
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Wrong Bearing Capacity Of Wheels.");
				}

				bearingCapacity = value;
			}
		}
		internal int CountOfWheels
		{
			get { return countOfWheels; }
			set
			{
				if (value < 1)
				{
					throw new ArgumentOutOfRangeException("Wrong Count Of Wheels.");
				}

				countOfWheels = value;
			}
		}

		public Chassis(int countOfWheels, string numberOfChassis, int bearingCapacity)
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

		internal XElement GetChassisInformationXML()
		{
			return new XElement("Chassis",
					new XElement("CountOfWheels", CountOfWheels),
					new XElement("NumberOfChassis", NumberOfChassis),
					new XElement("BearingCapacity", BearingCapacity));
		}
	}
}