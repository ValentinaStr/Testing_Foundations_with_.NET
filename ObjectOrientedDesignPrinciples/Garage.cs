namespace ObjectOrientedDesignPrinciples
{
	public class Garage
	{
		static Garage? _instance;
		public List<Car> Cars { get; set; }

		private Garage()
		{
			Cars = new List<Car>();
		}

		public static Garage GetGarage()
		{
			_instance ??= new Garage();
			return _instance;
		}

		public void AddCars()
		{
			Console.WriteLine("\nPlease press any button to add a car model to the garage or press <Enter> to finish adding");
			while (Console.ReadKey().Key != ConsoleKey.Enter)
			{
				AddCarsModel();
				AddCars();
			}
		}

		public void AddCarsModel()
		{
			var car = new Car();
			Cars.Add(car);
		}

		public void GetListOfBrend()
		{
			Console.Write("Available brands are: ");
			var listBrend = Cars.Select(x => x.Brand).Distinct().ToList();
			foreach (var brend in listBrend)
			{
				Console.Write($"{brend}   ");
			}
		}
	}
}