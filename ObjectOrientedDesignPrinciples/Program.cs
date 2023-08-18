namespace ObjectOrientedDesignPrinciples
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var myGarage = Garage.GetGarage();
			myGarage.AddCars();

			var invoker = new Invoker(myGarage);
			var command = invoker.SetCommand();
			command.Execute();
		}
	}
}