using System.Xml.Linq;

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

		internal Engine(string type, double power, double volume, string serialNumber)
		{
			Type = type;
			Power = power;
			Volume = volume;
			SerialNumber = serialNumber;
		}

		internal string GetInformation()
		{
			return "Engine:  \n" +
				"  Type: " + Type +
				"\n  Power: " + Power +
				"\n  Voume: " + Volume +
				"\n  Serial Number:" + SerialNumber + "\n";
		}

		internal XElement GetEngineInformationXML()
		{
			return new XElement("Engine",
				new XElement("Type", Type),
				new XElement("Power", Power),
				new XElement("Volume", Volume),
				new XElement("SerialNumber", SerialNumber));
		}

		internal XElement GetEngineTypePowerSerialNumberXML()
		{
			return new XElement("Engine",
				new XElement("Type", Type),
				new XElement("SerialNumber", SerialNumber),
				new XElement("Power", Power));
		}
	}
}