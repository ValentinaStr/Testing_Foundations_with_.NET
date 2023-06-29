using OOP.Specification;
using System.Xml.Linq;

namespace OOP.TypesOfTransport

{
	public class Scooter : Transport
	{
		public string TypeOfScooter { get; set; }

		public Scooter(string model, string typeOfScooter, Engine engine, Transmission transmission, Chassis chassis) : base(model, engine, transmission, chassis)
		{
			TypeOfScooter = typeOfScooter;
		}

		public Scooter()
		{
		}

		internal override string GetStringWithAllInformation()
		{
			return base.Model + "\n Scooter with the following characteristics:" +
				"\n Type Of Scooter:" + TypeOfScooter +
				base.GetStringWithAllInformation();
		}
		public override XElement GetSpecificationXML()
		{
			XElement scooter = new XElement("Scooter", base.Model,
					new XElement("TypeOfScooter", TypeOfScooter));
			scooter.Add(base.GetSpecificationXML());
			return scooter;
		}
	}
}