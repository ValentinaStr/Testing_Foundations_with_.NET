using OOP.Specification;
using System.Xml.Linq;

namespace OOP.TypesOfTransport
{
	internal class Car : Transport
	{
		private int numberOfSeats;
		internal string BodyStyle { get; set; }
		internal int NumberOfSeats
		{
			get { return numberOfSeats; }
			set
			{
				if (value < 1)
				{
					throw new ArgumentOutOfRangeException("Number of seats mast be positive number");
				}

				numberOfSeats = value;
			}
		}

		internal Car(string model, string bodyStyle, int numberOfSeats, Engine engine, Transmission transmission, Chassis chassis) : base(model,engine, transmission, chassis)
		{
			BodyStyle = bodyStyle;
			NumberOfSeats = numberOfSeats;
		}

		internal override string GetStringWithAllInformation()
		{
			return base.Model + 
				"\n Passenger car with the following characteristics:" + 
				"\n Body Style:" + BodyStyle + 
				"\n Number Of Seats:" + NumberOfSeats +
				base.GetStringWithAllInformation();
		}

		internal override XElement GetSpecificationXML()
		{
			XElement car = new XElement("Car", base.Model,
					new XElement("BodyStyle", BodyStyle),
					new XElement("NumberOfSeats", NumberOfSeats));
			car.Add(base.GetSpecificationXML());
			return car;
		}
	}
}