﻿using OOP.Specification;
using System.Xml.Linq;

namespace OOP.TypesOfTransport
{
	internal class Scooter : Transport
	{
		internal string TypeOfScooter { get; set; }

		internal Scooter(string model, string typeOfScooter, Engine engine, Transmission transmission, Chassis chassis) : base(model, engine, transmission, chassis)
		{
			TypeOfScooter = typeOfScooter;
		}

		internal override string GetStringWithAllInformation()
		{
			return base.Model + "\n Scooter with the following characteristics:" +
				"\n Type Of Scooter:" + TypeOfScooter +
				base.GetStringWithAllInformation();
		}

		internal override XElement GetSpecificationXML()
		{
			XElement scooter = new XElement("Scooter", base.Model,
					new XElement("TypeOfScooter", TypeOfScooter));
			scooter.Add(base.GetSpecificationXML());
			return scooter;
		}
	}
}