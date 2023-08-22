using ObjectOrientedDesignPrinciples.Commands;
using ObjectOrientedDesignPrinciples.Interface;

namespace ObjectOrientedDesignPrinciples
{
	public class Invoker
	{
		public Garage RealGarage { get; set; }
		public ICommand command;

		public Invoker(Garage myGarage)
		{
			RealGarage = myGarage;
		}

		public void GetInformation()
		{
			command.Execute();
		}

		public ICommand SetCommand()
		{
			if (RealGarage.Cars.Any())
			{
				Console.Write("\nChoose command:\n	Count types	Count all	Average price	Average price type	Exit\n");

				switch (Console.ReadLine())
				{
					case "Count types":
						return new CountTypesCommand(RealGarage);

					case "Count all":
						return new CountAllCommand(RealGarage);

					case "Average price":
						return new AveragePriceCommand(RealGarage);

					case "Average price type":
						return new AveragePriceTypeCommand(RealGarage);

					case "Exit":
						Environment.Exit(0);
						return null;

					default:
						Console.WriteLine("Your command is wrong. Please try again");
						return SetCommand();
				}
			}
			else
			{
				Console.WriteLine("Garage is empty");
				Environment.Exit(0);
				return null;
			}
		}
	}
}