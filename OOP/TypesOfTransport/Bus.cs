using OOP.Specification;
using System.Xml.Linq;

namespace OOP.TypesOfTransport
{
	public class Bus : Transport
	{
		public int NumberOfFloors { get; set; }
		public int NumberOfSeats { get; set; }

		public Bus(string model, int numberOfFloors, int numberOfSeats, Engine engin, Transmission transmission, Chassis chassis) : base(model, engin, transmission, chassis)
		{
			NumberOfFloors = numberOfFloors;
			NumberOfSeats = numberOfSeats;		
		}

		protected Bus()
		{
		}

		internal override string GetStringWithAllInformation()
		{
			return base.Model + 
				"\n Bus with the following characteristics:" + 
				"\n Number Of Floors:" + NumberOfFloors +
				"\n Number Of Seats:" + NumberOfSeats +
				base.GetStringWithAllInformation();
		}

		public override XElement GetSpecificationXML()
		{
			XElement bus = new XElement("Bus", base.Model,
							new XElement("NumberOfFloors", NumberOfFloors),
							new XElement("NumberOfSeats", NumberOfSeats));

			bus.Add(base.GetSpecificationXML());
			return bus;
		}
	}
}
