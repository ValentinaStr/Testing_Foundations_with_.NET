using OOP.TypesOfTransport;

namespace OOP
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			/*Using the object model from the Collections job, extend the functionality by adding event handlers for the following events:

			InitializationException - an exception in case of impossibility to initialize the model.
			AddException - an exception if it is impossible to add a model;
			GetAutoByParameterException - for the getAutoByParameter(string parameter, string value) method -
				an exception if the model cannot be found by the specified parameter. For example: an attempt to find a car by a non-existent parameter.
			UpdateAutoException - an exception in case of impossibility to replace auto. For example: an attempt to replace a car with a non-existent identifier (ID).
			RemoveAutoException - an exception if it is impossible to remove an auto. For example: an attempt to delete a car with a non-existent identifier (ID).*/

			var transports = new List<Transport>()
			{
				new Scooter(123451, "HondaForza", "Sports",
						new("Four stroke", 5, 1.6, "1P639FMB"),
						new("Automatic", 3, "Honda"),
						new(2, "45AS345A", 150)),

				new Scooter(123461, "Lifan", "Urban",
						new("Two stroke", 4.9, 0.5, "56TRG67Y"),
						new("Automatic", 3, "Yamaha"),
						new(2, "46HU342D", 160)),

				new Scooter(145874,"Vespa Primavera", "Sports",
						new("Four stroke", 12.7, 0.6, "12JH56F"),
						new("Automatic", 3, "Vespa"),
						new(2, "76RT345Y", 120)),

				new Scooter(789456, "Vespa Sprint", "Urban",
						new("Four stroke", 11, 0.125, "456RT67T"),
						new("Automatic", 5, "Vespa"),
						new(2, "90TYU78I", 150)),

				new Scooter(145236, "Minsk Vesna", "Retro",
						new("Four stroke", 7.6, 0.125, "43SDE5Y"),
						new("Automatic", 4, "Paton"),
						new(2, "76RT345Y", 110)),

				new Truck(245126, "Mercedes Benz Actros", "Jumbo",
						new("Six-cylinder", 394, 7.8, "OM 501 LA"),
						new("Automatic", 12, "Mercedes-Benz"),
						new(8, "8577GTH12W", 25000)),

				new Truck(698325, "Citroen Jumper", "Fridge",
						new("HDI", 130, 9.6, "56TY787"),
						new("Manual", 10, "Citroen"),
						new(8, "JO8754E", 3500)),

				new Truck(632656, "Renault Master", "Van",
						new("Common Rail", 150, 2.3, "LK81178"),
						new("Manual", 10, "Renault"),
						new(8, "HR39FOS", 3000)),

				new Truck(852369, "Foton Auman", "Van",
						new("Cummins", 150, 6.7, "THRT001"),
						new("Manual", 10, "Beiqi Foton Motor Ltd"),
						new(8, "JO8754E", 5000)),

				new Truck(123478, "Mitsubishi Fuso Canter", "Van",
						new("MITSUBISHI FUSO", 180, 4.89, "4M50-5AT5"),
						new("Manual", 10, "Mitsubishi"),
						new(8, "LO5454V", 4875)),

				new Car(524896, "Peugeot307", "Hatchback", 5,
						new("Petrol", 175, 5, "EW10 16-valve I4,"),
						new("Automatic", 6, "Aisin Seiki"),
						new(4, "9870GRT56R", 608)),

				new Car(183469, "Ford Fiesta", "Hatchback", 5,
						new("Petrol", 160, 1.3, "DDK9166"),
						new("Automatic", 5, "Ford"),
						new(4, "XS045V2", 400)),

				new Car(102504, "BMW Z4", "Cabriolet", 2,
						new("18i sDrive", 156, 2, "MBB3099"),
						new("Manual", 6, "BMW"),
						new(4, "14GY5V8", 270)),

				new Car(159023, "Audi Q5 ", "Hatchback", 5,
						new("Q5 2.0 TDI", 143, 2, "BM722A2"),
						new("Manual", 6, "Audi"),
						new(4, "30JNSV0", 600)),

				new Car(693025, "Lexus RX400", "Hatchback", 5,
						new("RX 400h Prestige", 211, 3.3, "LEX45R"),
						new("Automatic", 5, "Lexus"),
						new(4, "K98UB65", 500)),

				new Bus(523653, "Mercedes Benz Tourismo", 1, 35,
						new("6-cylinder", 428, 5.2, "OM 936.971"),
						new("Automatic", 6, "Mercedes-Benz"),
						new(6, "8569GRT56Q", 19000)),

				new Bus(302659, "Scania A80", 1, 51,
						new("DC 12 13", 380, 4.8, "AS728K"),
						new("Automatic", 6, "Scania"),
						new(8, "DE45RF67T", 16000)),

				new Bus(205060, "Neoplan Tourliner SHD", 1, 49,
						new("MAN D2066 LOH 04", 350, 7.7, "MN85100"),
						new("Automatic", 5, "Neoplan"),
						new(8, "AAKO67T", 18000)),

				new Bus(506326, "Volvo 9700", 1, 59,
						new("DOOSAN INFRACORE DV11S", 5.5, 350, "KL56B0N"),
						new("Automatic", 5, "Volvo"),
						new(8, "OOPO64T", 19000)),

				new Bus(695015, "Daewoo BX212 Royal", 1, 43,
						new("Volvo D8K", 430, 5, "KL56B0N"),
						new("Automatic", 6, "Daewoo"),
						new(8, "JOPO64T", 18000))
			};

			var garage = new Garage(transports);

			try
			{
				var Incorrect = new Car(122, "Peugeot307", "Hatchback", 5,
						new("Petrol", 175, 5, "EW10 16-valve I4,"),
						new("Automatic", 6, "Aisin Seiki"),
						new(4, "9870GRT56R", 608));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.ResetColor();
			}

			try
			{
				garage.AddTransport(new Bus(695015, "Daewoo BX212 Royal", 1, 43,
						new("Volvo D8K", 430, 5, "KL56B0N"),
						new("Automatic", 6, "Daewoo"),
						new(8, "JOPO64T", 18000)));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.ResetColor();
			}

			try
			{
				foreach (Transport t in garage.GetAutoByParameter("TrailerType", "Van"))
				{
					Console.WriteLine(t.GetStringWithAllInformation());
				};
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.ResetColor();
			}

			try
			{
				garage.UpdateAuto(50636, new Bus(333333, "Volvo 9700", 1, 59,
							new("DOOSAN INFRACORE DV11S", 5.5, 350, "KL56B0N"),
							new("Automatic", 5, "Volvo"),
							new(8, "OOPO64T", 19000)));

				garage.UpdateAuto(500000, new Bus(333333, "Volvo 9700", 1, 59,
							new("DOOSAN INFRACORE DV11S", 5.5, 350, "KL56B0N"),
							new("Automatic", 5, "Volvo"),
							new(8, "OOPO64T", 19000)));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.ResetColor();
			}

			try
			{
				garage.RemoveAuto(69515);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.ResetColor();
			}
		}
	}
}