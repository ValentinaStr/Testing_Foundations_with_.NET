using System.Xml.Linq;

namespace OOP.Specification
{
    public class Chassis
    {
        public int CountOfWheels;
        public string NumberOfChassis;
        public int BearingCapacity;

		public Chassis()
		{
		}

		public Chassis(int countOfWheels, string numberOfChassis, int bearingCapacity)
        {
            CountOfWheels = countOfWheels;
            NumberOfChassis = numberOfChassis;
            BearingCapacity = bearingCapacity;
        }


		public string GetInformation()
		{
			return "Chassis:  \n" +
				"  Count Of Wheels: " + CountOfWheels +
				"\n  Number Of Chassis: " + NumberOfChassis +
				"\n  Bearing Capacity:" + BearingCapacity;
		}

		public XElement GetChassisInformationXML()
		{
			return new XElement("Chassis",
					new XElement("CountOfWheels", CountOfWheels),
					new XElement("NumberOfChassis", NumberOfChassis),
					new XElement("BearingCapacity", BearingCapacity));
		}
	}
}