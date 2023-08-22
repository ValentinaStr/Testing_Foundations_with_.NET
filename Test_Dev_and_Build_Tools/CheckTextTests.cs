using Dev_and_Build_Tools;

namespace Test_Dev_and_Build_Tools
{
	[TestClass]
	public class CheckTextTests
	{
		[TestMethod]
		[DataRow(" ", 1, "Check stirng with one space")]
		[DataRow("a", 1, "Check stirng with one symbol")]
		[DataRow("asd ffg", 5, "Check stirng with long unequal consecutive characters at the beginning")]
		[DataRow("asdffg2sedr", 7, "Check stirng with long unequal consecutive characters at the end")]
		[DataRow("   123456   ", 8, "Check stirng with long unequal consecutive characters in the middle")]
		[DataRow("1234567890", 10, "Check stirng with unequal symbols")]
		[DataRow("/////////////", 1, "Check stirng with the equal symbols")]
		public void GetLenghtUnequalConsecutiveCharactersPositive(string text, int expectedResult, string message)
		{
			var actualResalt = CheckText.GetLenghtUnequalConsecutiveCharacters(text);
			Assert.AreEqual(expectedResult, actualResalt, message);
		}

		[TestMethod]
		[DataRow("", 0, "Check empty stirng")]
		[DataRow(null, 0, "Check null")]
		public void GetLenghtUnequalConsecutiveCharactersNegative(string text, int expectedResult, string message)
		{
			var actualResalt = CheckText.GetLenghtUnequalConsecutiveCharacters(text);
			Assert.AreEqual(expectedResult, actualResalt, message);
		}

		[TestMethod]
		[DataRow("0", 0, "Check stirng with one number")]
		[DataRow("  44444ftgvbh4 uk0td5", 5, "Check stirng with long equal numbers at the beginning")]
		[DataRow("asd .ff g2sedr 5555555", 7, "Check stirng with long equal numbers the end")]
		[DataRow("111   ggg/// 1111 ggg   ", 4, "Check stirng with long equal numbers in the middle")]
		[DataRow("1234567890", 0, "Check stirng with unequal numbers")]
		[DataRow("0000000000000", 13, "Check stirng with the equal numbers")]
		public void CheckLenghtEqualConsecutiveNumberPositive(string text, int expectedResult, string message)
		{
			var actualResalt = CheckText.GetLenghtEqualConsecutiveNumber(text);
			Assert.AreEqual(expectedResult, actualResalt, message);
		}

		[TestMethod]
		[DataRow("", 0, "Check empty stirng")]
		[DataRow(null, 0, "Check null")]
		[DataRow("wertgfdedrf", 0, "Check stirng with letters")]
		public void CheckLenghtEqualConsecutiveNumberNegative(string text, int expectedResult, string message)
		{
			var actualResalt = CheckText.GetLenghtEqualConsecutiveNumber(text);
			Assert.AreEqual(expectedResult, actualResalt, message);
		}

		[TestMethod]
		[DataRow("a", 0, "Check stirng with one symbol")]
		[DataRow(" rrrrrrr 44444ftgvbh4 uk0td5", 7, "Check stirng with long equal letters of the latin alphabet at the beginning")]
		[DataRow("asd .ff g2sedr YYYYYYYYY", 9, "Check stirng with long equal letters of the latin alphabet the end")]
		[DataRow("1drffff11   gggggg/// 1111 ggg   ", 6, "Check stirng with long equal letters of the latin alphabet in the middle")]
		[DataRow("wertyuio", 0, "Check stirng with unequal letters of the latin alphabet")]
		[DataRow("MMMMMMMMMMM", 11, "Check stirng with the equal letters of the latin alphabet")]
		public void CheckLettersOfTheLatinAlphabetPositive(string text, int expectedResult, string message)
		{
			var actualResalt = CheckText.GetLenghtEqualConsecutiveLettersOfTheLatinAlphabet(text);
			Assert.AreEqual(expectedResult, actualResalt, message);
		}

		[TestMethod]
		[DataRow("", 0, "Check empty stirng")]
		[DataRow(null, 0, "Check null")]
		[DataRow("1234567890", 0, "Check stirng with numbers")]
		public void CheckLenghtEqualLettersOfTheLatinAlphabetrNegative(string text, int expectedResult, string message)
		{
			var actualResalt = CheckText.GetLenghtEqualConsecutiveLettersOfTheLatinAlphabet(text);
			Assert.AreEqual(expectedResult, actualResalt, message);
		}
	}
}