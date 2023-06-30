﻿using OOP.Specification;
using System.Xml.Linq;

namespace OOP.TypesOfTransport
{
	public abstract class Transport
	{
		public string Model { get; set; }
		public Engine EngineInformation;
		public Transmission TransmissionInformation;
		public Chassis ChassisInformation;

		public Transport()
		{
		}

		public Transport(string model, Engine engineInformation, Transmission transmissionInformation, Chassis chassisInformation)
		{
			Model = model;
			EngineInformation = engineInformation;
			TransmissionInformation = transmissionInformation;
			ChassisInformation = chassisInformation;
		}

		internal virtual string GetStringWithAllInformation()
		{
			return "\n " + EngineInformation.GetInformation() + TransmissionInformation.GetInformation() + ChassisInformation.GetInformation() + "\n\n";
		}

		public virtual XElement GetSpecificationXML()
		{

			XElement specification = new XElement("Specification");
			specification.Add(EngineInformation.GetEngineInformationXML());
			specification.Add(TransmissionInformation.GetTransmissionInformationXML());
			specification.Add(ChassisInformation.GetChassisInformationXML());
			return specification;
		}

		public static XElement GetTransportInformationXML(List<Transport> transports)
		{
			XElement xdocOfTransports = new XElement("Transport");

			foreach (var transport in transports)
			{
				xdocOfTransports.Add(transport.GetSpecificationXML());
			}

			return xdocOfTransports;
		}

		public static XElement GetTransportEngineInformationXML(List<Transport> transports)
		{
			XElement xdocOfTransports = new XElement("Transport");
			foreach (var transport in transports)
			{
				XElement model = new XElement("Model", transport.Model);
				xdocOfTransports.Add(model);
				model.Add(transport.EngineInformation.GetEngineTypePowerSerialNumberXML());
			}

			return xdocOfTransports;
		}

		public static XElement GetTransportInformationXMLSortByTransmission(List<Transport> transports)
		{
			var listOfTransporsGroupsByTransmission = transports.GroupBy(p => p.TransmissionInformation.Type).ToList();
			XElement xdocGroupByTransmissionsType = new XElement("Transport");

			foreach (var transportsGroupe in listOfTransporsGroupsByTransmission)
			{
				XElement typeTransmission = new XElement("TypeOfTransmission", transportsGroupe.Key);
				xdocGroupByTransmissionsType.Add(typeTransmission);

				foreach (Transport d in transportsGroupe)
				{
					typeTransmission.Add(d.GetSpecificationXML());
				}
			}

			return xdocGroupByTransmissionsType;
		}
	}
}