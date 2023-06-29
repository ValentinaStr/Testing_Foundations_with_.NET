using OOP.TypesOfTransport;

namespace OOP
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/*Populate a collection containing objects of type "Truck", "Car", "Bus", "Scooter"
			 (from the previous OOP task) with different field values.
			Write the following information to the XML files:
				Complete information about all vehicles with an engine capacity of more than 1.5 liters;
				Engine type, serial number and power for all buses and trucks;
				Complete information about all vehicles grouped by transmission type.*/

			var transports = new List<Transport>()
			{
				new Scooter("HondaForza", "Sports",
						new("Four stroke", 5, 1.6, "1P639FMB"),
						new("Automatic", 3, "Honda"),
						new(2, "45AS345A", 150)),

				new Scooter("Lifan", "Urban",
						new("Two stroke", 4.9, 0.5, "56TRG67Y"),
						new("Automatic", 3, "Yamaha"),
						new(2, "46HU342D", 160)),

				new Scooter("Vespa Primavera", "Sports",
						new("Four stroke", 12.7, 0.6, "12JH56F"),
						new("Automatic", 3, "Vespa"),
						new(2, "76RT345Y", 120)),

				new Scooter("Vespa Sprint", "Urban",
						new("Four stroke", 11, 0.125, "456RT67T"),
						new("Automatic", 5, "Vespa"),
						new(2, "90TYU78I", 150)),

				new Scooter("Minsk Vesna", "Retro",
						new("Four stroke", 7.6, 0.125, "43SDE5Y"),
						new("Automatic", 4, "Paton"),
						new(2, "76RT345Y", 110)),

				new Truck("Mercedes Benz Actros", "Jumbo",
						new("Six-cylinder", 394, 7.8, "OM 501 LA"),
						new("Automatic", 12, "Mercedes-Benz"),
						new(8, "8577GTH12W", 25000)),

				new Truck("Citroen Jumper", "Fridge",
						new("HDI", 130, 9.6, "56TY787"),
						new("Manual", 10, "Citroen"),
						new(8, "JO8754E", 3500)),

				new Truck("Renault Master", "Van",
						new("Common Rail", 150, 2.3, "LK81178"),
						new("Manual", 10, "Renault"),
						new(8, "HR39FOS", 3000)),

				new Truck("Foton Auman", "Van",
						new("Cummins", 150, 6.7, "THRT001"),
						new("Manual", 10, "Beiqi Foton Motor Ltd"),
						new(8, "JO8754E", 5000)),

				new Truck("Mitsubishi Fuso Canter", "Van",
						new("MITSUBISHI FUSO", 180, 4.89, "4M50-5AT5"),
						new("Manual", 10, "Mitsubishi"),
						new(8, "LO5454V", 4875)),

				new Car("Peugeot307", "Hatchback", 5,
						new("Petrol", 175, 5, "EW10 16-valve I4,"),
						new("Automatic", 6, "Aisin Seiki"),
						new(4, "9870GRT56R", 608)),

				new Car("Ford Fiesta", "Hatchback", 5,
						new("Petrol", 160, 1.3, "DDK9166"),
						new("Automatic", 5, "Ford"),
						new(4, "XS045V2", 400)),

				new Car("BMW Z4", "Cabriolet", 2,
						new("18i sDrive", 156, 2, "MBB3099"),
						new("Manual", 6, "BMW"),
						new(4, "14GY5V8", 270)),

				new Car("Audi Q5 ", "Hatchback", 5,
						new("Q5 2.0 TDI", 143, 2, "BM722A2"),
						new("Manual", 6, "Audi"),
						new(4, "30JNSV0", 600)),

				new Car("Lexus RX400", "Hatchback", 5,
						new("RX 400h Prestige", 211, 3.3, "LEX45R"),
						new("Automatic", 5, "Lexus"),
						new(4, "K98UB65", 500)),

				new Bus("Mercedes Benz Tourismo", 1, 35,
						new("6-cylinder", 428, 5.2, "OM 936.971"),
						new("Automatic", 6, "Mercedes-Benz"),
						new(6, "8569GRT56Q", 19000)),

				new Bus("Scania A80", 1, 51,
						new("DC 12 13", 380, 4.8, "AS728K"),
						new("Automatic", 6, "Scania"),
						new(8, "DE45RF67T", 16000)),

				new Bus("Neoplan Tourliner SHD", 1, 49,
						new("MAN D2066 LOH 04", 350, 7.7, "MN85100"),
						new("Automatic", 5, "Neoplan"),
						new(8, "AAKO67T", 18000)),

				new Bus("Volvo 9700", 1, 59,
						new("DOOSAN INFRACORE DV11S", 5.5, 350, "KL56B0N"),
						new("Automatic", 5, "Volvo"),
						new(8, "OOPO64T", 19000)),

				new Bus("Daewoo BX212 Royal", 1, 43,
						new("Volvo D8K", 430, 5, "KL56B0N"),
						new("Automatic", 6, "Daewoo"),
						new(8, "JOPO64T", 18000))
			};

			//Complete information about all vehicles with an engine capacity greater than 1.5 liters;

			var listOfTransportSelectByEngieneVolume = transports.Where(p => (p.EngineInformation.Volume > 1.5)).ToList();

			LogerXML.Log(Transport.GetTransportInformationXML(listOfTransportSelectByEngieneVolume),
						@"D:\projects\dotnet\Testing_Foundations_with_.NET\OOP\List of transports with engime volume less 1.5.xml");

			// Engine type, serial number and power for all buses and trucks;

			var listOfBusAndTuck = transports.OfType<Bus>().Union<Transport>(transports.OfType<Truck>()).ToList();
			
			LogerXML.Log(Transport.GetTransportEngineInformationXML(listOfBusAndTuck),
						@"D:\projects\dotnet\Testing_Foundations_with_.NET\OOP\List of engines buses and trucks.xml");

			//Complete information about all vehicles, grouped by transmission type.

			LogerXML.Log(Transport.GetTransportInformationXMLSortByTransmission(transports),
						@"D:\projects\dotnet\Testing_Foundations_with_.NET\OOP\List of transports sort by transmission.xml");
		}
	}
}