using ObjectOrientedDesignPrinciples.Interface;

namespace ObjectOrientedDesignPrinciples.Commands
{
	public class CountAllCommand : ICommand
	{
		public Garage Garage { get; set; }
		public CountAllCommand(Garage garage)
		{
			Garage = garage;
		}
		public void Execute()
		{
			Console.WriteLine($"There are {Garage.Cars.Sum(x => x.Quantity)} cars in garage");
		}
	}
}