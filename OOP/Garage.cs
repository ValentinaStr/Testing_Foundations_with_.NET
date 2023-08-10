using OOP.TypesOfTransport;
using OOP.GarageExceptions;

namespace OOP
{
	internal class Garage
	{
		public List<Transport> Transports { get; set; }

		public Garage(List<Transport> transports)
		{
			Transports = transports;
		}

		public void AddTransport(Transport transportToAdd)
		{
			if (Transports.Contains(transportToAdd))
			{
				throw new AddException($"Transport with ID {transportToAdd.ID} already exists. \n");
			}

			Transports.Add(transportToAdd);
		}

		public List<Transport> GetAutoByParameter(string parameter, string value)
		{
			List<Transport> selectedTransports = new();

			foreach (var transport in Transports)
			{
				if (transport.GetParametrValue(parameter) == value)
				{
					selectedTransports.Add(transport);
				}
			}

			if (!selectedTransports.Any())
			{
				throw new GetAutoByParameterException($"Transport with parameter {parameter} value {value} was not found \n");
			}

			return selectedTransports;
		}

		public void UpdateAuto(int id, Transport transport)
		{
			var indexSelectedTransport = Transports.FindIndex(p => p.ID == id);

			if (indexSelectedTransport == -1)
			{
				throw new UpdateAutoException($"There is no transport with ID {id} in the garage to update.\n ");
			}

			Transports[indexSelectedTransport] = transport;
		}

		public void RemoveAuto(int id)
		{
			var selectedTransport = Transports.Find(p => p.ID == id);

			if (selectedTransport is null)
			{
				throw new RemoveAutoException($"There is no transport with ID {id} in the garage to remove.\n");
			}

			Transports.Remove(selectedTransport);
		}
	}
}