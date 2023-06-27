namespace BasicOf.NET
{
	public class Number_conversion
	{
		public static string Resalt;
		private static string Values = "0123456789ABCDEFGHIJ";

		public static string Conversation(int number, int exponentiation)
		{
			int res = Math.Abs(number) % exponentiation;
			Resalt = Values[res] + Resalt;

			if (Math.Abs(number) / exponentiation < exponentiation)
			{
				if (number < 0)
				{
					return Resalt = "-" + Values[Math.Abs(number) / exponentiation] + Resalt;
				}

				return Resalt = Values[Math.Abs(number) / exponentiation] + Resalt;
			}
			return Conversation(number / exponentiation, exponentiation);
		}

		public static int CheckNumberToConvert()
		{
			Console.WriteLine("Enter an integer in decimal system");
			string number = Console.ReadLine();
			try
			{
				Convert.ToInt32(number);
			}
			catch
			{
				Console.WriteLine("The entered number is not correct. Try again. ");
				return CheckNumberToConvert();
			}
			return Convert.ToInt32(number);
		}

		public static int CheckNotationToConvert()
		{
			Console.WriteLine("Enter an notation from 2-20");

			string notation = Console.ReadLine();

			if (string.IsNullOrEmpty(notation) == false && 1 < Convert.ToInt32(notation) && Convert.ToInt32(notation) < 21)
			{
				try
				{
					Convert.ToInt32(notation);
				}
				catch
				{
					Console.WriteLine("The entered notation is not correct. Try again. ");
					CheckNotationToConvert();
				}
			}
			else
			{
				Console.WriteLine("The entered notation is not integer. Try again.");
				return CheckNotationToConvert();
			}
			return Convert.ToInt32(notation);
		}
	}
}
