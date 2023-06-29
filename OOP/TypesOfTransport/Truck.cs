using OOP.Specification;
using System.Xml.Linq;

namespace OOP.TypesOfTransport
{
	public class Truck : Transport
	{
		public string TrailerType { get; set; }
		

		public Truck(string model, string trailerType,  Engine engine, Transmission transmission, Chassis chassis) : base(model, engine, transmission, chassis)
		{
			TrailerType = trailerType;
		}

		public Truck()
		{
		}

		internal override string GetStringWithAllInformation()
		{
			return base.Model + "\n Truck with the following characteristics:" +
				"\n Trailer Type:" + TrailerType +
				base.GetStringWithAllInformation();
		}
		public override XElement GetSpecificationXML()
		{
			XElement truck = new XElement("Truck", base.Model,
					new XElement("TrailerType", TrailerType));
			truck.Add(base.GetSpecificationXML());
			return truck;
		}
	}
}