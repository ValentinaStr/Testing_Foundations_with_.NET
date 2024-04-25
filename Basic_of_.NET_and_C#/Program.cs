namespace BasicOf.NET
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			int number = NumberConversion.CheckNumberToConvert();
			int notation = NumberConversion.CheckNotationToConvert();

			Console.WriteLine($"{number} in the number system the base {notation} is {NumberConversion.Conversation(number, notation)}.");
		}
	}
}