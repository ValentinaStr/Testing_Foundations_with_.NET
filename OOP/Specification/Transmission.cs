using System.Xml.Linq;

namespace OOP.Specification
{
	public class Transmission
    {
		public string Type;
		public int NumberOfGears;
		public string Manufacturer;

		public Transmission()
		{
		}

		public Transmission(string type, int numberOfGears, string manufacturer)
        {
            Type = type;
            NumberOfGears = numberOfGears;
            Manufacturer = manufacturer;
        }


        public string GetInformation()
        {
            return "Transmission : \n" +
                "  Type:" + Type +
                "\n  Number Of Gears:" + NumberOfGears +
                "\n  Manufacturer:" + Manufacturer +"\n";
		}

        public XElement GetTransmissionInformationXML()
        {
			return new XElement("Transmission",
					new XElement("Type", Type),
					new XElement("NumberOfGears", NumberOfGears),
					new XElement("Manufacturer", Manufacturer));
		}
    }
}