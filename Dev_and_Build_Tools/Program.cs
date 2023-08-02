namespace Dev_and_Build_Tools
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Please write a text");

			string text = Console.ReadLine();

			Console.WriteLine($"Lenght unequal consecutive characters is {CheckText.GetLenghtUnequalConsecutiveCharacters(text)}.");
		}
	}
}