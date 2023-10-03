using EmaiGmailHotmail.Util;
using EmaiGmailHotmail.Model;


namespace EmaiGmailHotmail.Service
{
	public class LetterCreator
	{
		public static string termLetter = RandomStringGenerator.GenerateRandomString(5);
		public static string textLetter = RandomStringGenerator.GenerateRandomString(10);
		public static string textAnswerLetter = RandomStringGenerator.GenerateRandomString(3);

		public static Letter CreateLetter()
		{
			return new Letter(termLetter, textLetter);
		}

		public static Letter CreateAnswerLetter()
		{
			return new Letter(textAnswerLetter);
		}
	}
}