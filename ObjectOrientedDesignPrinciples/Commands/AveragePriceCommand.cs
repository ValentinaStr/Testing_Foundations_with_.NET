using ObjectOrientedDesignPrinciples.Interface;

namespace ObjectOrientedDesignPrinciples.Commands
{
	public class AveragePriceCommand : ICommand
	{
		public Garage Garage { get; set; }
		public AveragePriceCommand(Garage garage)
		{
			Garage = garage;
		}

		public void Execute()
		{
			Console.WriteLine($"\nAverage price of cars in the garage is {Garage.Cars.Average(x => x.UnitPrice)}");
		}
	}
}