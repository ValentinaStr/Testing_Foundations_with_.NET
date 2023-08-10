using OOP.GarageExceptions;
using OOP.Specification;
using System.Reflection;
using System.Xml.Linq;

namespace OOP.TypesOfTransport
{
	public abstract class Transport
	{
		private int iD;
		internal int ID
		{
			get { return iD; }
			set
			{
				iD = CheckID(value);
			}
		}
		public string Model { get; set; }
		public Engine EngineInformation;
		public Transmission TransmissionInformation;
		public Chassis ChassisInformation;

		public Transport(int iD, string model, Engine engineInformation, Transmission transmissionInformation, Chassis chassisInformation)
		{
			ID = iD;
			Model = model;
			EngineInformation = engineInformation;
			TransmissionInformation = transmissionInformation;
			ChassisInformation = chassisInformation;
		}

		public int CheckID(int iD)
		{
			if (iD < 0 || iD.ToString().Length != 6)
			{
				throw new InitializationException("Wrong new transport ID. \n");
			}

			return iD;
		}

		internal virtual string GetStringWithAllInformation()
		{
			return "\n " + EngineInformation.GetInformation() + TransmissionInformation.GetInformation() + ChassisInformation.GetInformation() + "\n\n";
		}

		public override bool Equals(object? obj)
		{
			if (obj != null && obj is Transport transport)
			{
				return ID == transport.ID;
			}

			return false;
		}

		public override int GetHashCode()
		{
			return ID.GetHashCode();
		}

		internal PropertyInfo? GetTransportParameter(string parameter)
		{
			Type typeOfTransport = GetType();
			var fieldOfTransport = typeOfTransport.GetProperty(parameter, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

			if (fieldOfTransport == null)
			{
				throw new GetAutoByParameterException($"Transport with parameter {parameter} was not found \n");
			}

			return fieldOfTransport;
		}

		internal string GetParametrValue(string parameter)
		{
			var fieldOfTransport = GetTransportParameter(parameter);
			var valueOfParametr = fieldOfTransport?.GetValue(this);

			if (valueOfParametr == null)
			{
				throw new GetAutoByParameterException($"Transport with parameter {parameter} value was not found \n");
			}

			return valueOfParametr.ToString();
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