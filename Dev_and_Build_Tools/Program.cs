namespace Dev_and_Build_Tools
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Please write a text");

			string text = Console.ReadLine();

			Console.WriteLine($"Lenght unequal consecutive characters is {CheckText.GetLenghtUnequalConsecutiveCharacters(text)}.");

			var lenghtEqualNumber = CheckText.GetLenghtEqualConsecutiveNumber(text);

			Console.WriteLine($"Maximum number of consecutive identical digits {lenghtEqualNumber}");

			var lenghtEqualLettersOfTheLatinAlphabet = CheckText.GetLenghtEqualConsecutiveLettersOfTheLatinAlphabet(text);

			Console.WriteLine($"The maximum number of consecutive identical letters of the Latin alphabet is {lenghtEqualLettersOfTheLatinAlphabet}");

		}
	}
}