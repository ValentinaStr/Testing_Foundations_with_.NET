using ObjectOrientedDesignPrinciples.Interface;

namespace ObjectOrientedDesignPrinciples.Commands
{
	public class CountTypesCommand : ICommand
	{
		public Garage Garage { get; set; }
		public CountTypesCommand(Garage garage)
		{
			Garage = garage;
		}

		void ICommand.Execute()
		{
			Console.WriteLine($"There are {Garage.Cars.Select(x => x.Brand).Distinct().ToList().Count} brends cars in the garage");
		}
	}
}