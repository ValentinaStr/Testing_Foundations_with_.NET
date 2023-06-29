using OOP.Specification;
using System.Xml.Linq;

namespace OOP.TypesOfTransport
{
	public class Car : Transport
	{
		public string BodyStyle { get; set; }
		public int NumberOfSeats { get; set; }

		public Car(string model, string bodyStyle, int numberOfSeats, Engine engine, Transmission transmission, Chassis chassis) : base(model,engine, transmission, chassis)
		{
			BodyStyle = bodyStyle;
			NumberOfSeats = numberOfSeats;
		}

		protected Car()
		{
		}

		internal override string GetStringWithAllInformation()
		{
			return base.Model + 
				"\n Passenger car with the following characteristics:" + 
				"\n Body Style:" + BodyStyle + 
				"\n Number Of Seats:" + NumberOfSeats +
				base.GetStringWithAllInformation();
		}

		public override XElement GetSpecificationXML()
		{
			XElement car = new XElement("Car", base.Model,
					new XElement("BodyStyle", BodyStyle),
					new XElement("NumberOfSeats", NumberOfSeats));
			car.Add(base.GetSpecificationXML());
			return car;
		}
	}
}