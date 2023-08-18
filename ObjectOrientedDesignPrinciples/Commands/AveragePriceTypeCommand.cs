using ObjectOrientedDesignPrinciples.Interface;

namespace ObjectOrientedDesignPrinciples.Commands
{
	internal class AveragePriceTypeCommand : ICommand
	{
		public Garage Garage { get; set; }
		public AveragePriceTypeCommand(Garage garage)
		{
			Garage = garage;
		}
		public void Execute()
		{
			Garage.GetListOfBrend();

			Console.WriteLine("Choose an available Brend");
			var brand = Console.ReadLine().ToUpper();
			var brandCars = Garage.Cars.Where(x => x.Brand == brand).ToList();

			if (brandCars.Any())
			{
				Console.WriteLine($"Average price of {brand} cars is {brandCars.Average(x => x.UnitPrice)}");
			}
			else
			{
				Console.WriteLine($"There is no {brand} brand in garage.");
			}
		}
	}
}