namespace ObjectOrientedDesignPrinciples
{
	public class Car
	{
		private int quantity;
		private double unitPrice;
		public string Brand { get; set; }
		public string Model { get; set; }

		public int Quantity
		{
			get => quantity;
			set
			{
				if (value < 0)
				{
					throw new Exception("Quantity must be a positive number.");
				}

				quantity = value;
			}
		}

		public double UnitPrice
		{
			get => unitPrice;
			set
			{
				if (value < 0)
				{
					throw new Exception("UnitPrice must be a positive number.");
				}

				unitPrice = value;
			}
		}

		public Car()
		{
			Console.WriteLine("\n Enter cars details:");

			Console.Write("Brand = ");
			Brand = Console.ReadLine().ToUpper();

			Console.Write("Model = ");
			Model = Console.ReadLine();

			Console.Write("Quantity = ");
			Quantity = (int)ContersStringToDouble(Console.ReadLine());

			Console.Write("Unit Price = ");
			UnitPrice = ContersStringToDouble(Console.ReadLine());
		}

		public double ContersStringToDouble(string str)
		{
			try
			{
				var num = Convert.ToDouble(str);
				return num;
			}
			catch
			{
				Console.WriteLine("The entered data is incorrect");
				Environment.Exit(0);
				return 0;
			}
		}

		public string CheckSringEmpty(string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				Console.WriteLine("The entered data is incorrect");
				Environment.Exit(0);
				return " ";
			}

			return str;
		}
	}
}