using OOP.Specification;
using System.Xml.Linq;

namespace OOP.TypesOfTransport
{
	internal abstract class Transport
	{
		internal string Model { get; set; }
		internal Engine EngineInformation;
		internal Transmission TransmissionInformation;
		internal Chassis ChassisInformation;

		internal Transport(string model, Engine engineInformation, Transmission transmissionInformation, Chassis chassisInformation)
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

		internal virtual XElement GetSpecificationXML()
		{

			XElement specification = new XElement("Specification");
			specification.Add(EngineInformation.GetEngineInformationXML());
			specification.Add(TransmissionInformation.GetTransmissionInformationXML());
			specification.Add(ChassisInformation.GetChassisInformationXML());
			return specification;
		}

		internal static XElement GetTransportInformationXML(List<Transport> transports)
		{
			XElement xdocOfTransports = new XElement("Transport");

			foreach (var transport in transports)
			{
				xdocOfTransports.Add(transport.GetSpecificationXML());
			}

			return xdocOfTransports;
		}

		internal static XElement GetTransportEngineInformationXML(List<Transport> transports)
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

		internal static XElement GetTransportInformationXMLSortByTransmission(List<Transport> transports)
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