using System.Text.RegularExpressions;

namespace Dev_and_Build_Tools
{
	public class CheckText
	{
		public static int GetLenghtUnequalConsecutiveCharacters(string text)
		{
			int count = 1;
			int result = 1;

			if (string.IsNullOrEmpty(text))
			{
				return 0;
			}

			for (int i = 1; i < text.Length; i++)
			{
				if (text[i] == text[i - 1])
				{
					count = 0;
				}

				count++;
				result = Math.Max(result, count);
			}

			return result;
		}

		public static int GetLenghtEqualConsecutiveNumber(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return 0;
			}

			var textOnlyNumber = string.Join("", text.Select(c => char.IsDigit(c) ? c : ' '));
			var textOnlyNymberWithoutSpaces = Regex.Replace(textOnlyNumber, " {2,}", " ").Trim();
			return GetLenghtEqualConsecutiveCharacters(textOnlyNymberWithoutSpaces);
		}

		public static int GetLenghtEqualConsecutiveLettersOfTheLatinAlphabet(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return 0;
			}

			var textLatinAlphabet = string.Join("", text.ToUpper().Select(c => c = (c >= 'A' && c <= 'Z') ? c : ' '));
			var textLatinAlphabetWithoutSpaces = Regex.Replace(textLatinAlphabet, " {2,}", " ").Trim();
			return GetLenghtEqualConsecutiveCharacters(textLatinAlphabetWithoutSpaces);
		}

		private static int GetLenghtEqualConsecutiveCharacters(string text)
		{
			var result = 1;
			var count = 1;

			if (string.IsNullOrEmpty(text))
			{
				return 0;
			}

			for (int i = 1; i < text.Length; i++)
			{
				if (text[i - 1] != text[i])
				{
					count = 0;

				}
				count += 1;
				result = Math.Max(result, count);
			}

			return result == 1 ? 0 : result;
		}
	}
}