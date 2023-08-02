﻿using OOP.Specification;
using System.Xml.Linq;

namespace OOP.TypesOfTransport
{
	internal class Truck : Transport
	{
		internal string TrailerType { get; set; }

		internal Truck(string model, string trailerType,  Engine engine, Transmission transmission, Chassis chassis) : base(model, engine, transmission, chassis)
		{
			TrailerType = trailerType;
		}

		internal override string GetStringWithAllInformation()
		{
			return base.Model + "\n Truck with the following characteristics:" +
				"\n Trailer Type:" + TrailerType +
				base.GetStringWithAllInformation();
		}

		internal override XElement GetSpecificationXML()
		{
			XElement truck = new XElement("Truck", base.Model,
					new XElement("TrailerType", TrailerType));
			truck.Add(base.GetSpecificationXML());
			return truck;
		}
	}
}