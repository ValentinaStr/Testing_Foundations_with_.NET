using System.Xml.Linq;

namespace OOP.Specification
{
    public class Engine
    {
        public string Type;
		public double Power;
		public double Volume;
		public string SerialNumber;

		public Engine()
		{
		}

		public Engine(string type, double power, double volume, string serialNumber)
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

		public XElement GetEngineInformationXML()
		{
			return new XElement("Engine",
				new XElement("Type", Type),
				new XElement("Power", Power),
				new XElement("Volume", Volume),
				new XElement("SerialNumber", SerialNumber));
		}

		public XElement GetEngineTypePowerSerialNumberXML()
		{
			return new XElement("Engine",
				new XElement("Type", Type),
				new XElement("SerialNumber", SerialNumber),
				new XElement("Power", Power));
		}
	}
}