namespace Dev_and_Build_Tools
{
	public class CheckText
	{
		public static int GetLenghtUnequalConsecutiveCharacters(string text)
		{
			int count = 1;
			int result = 1;

			if (string.IsNullOrEmpty(text)) result = 0;

			for (int i = 1; i < text.Length; i++)
			{
				if (text[i] == text[i - 1]) count = 0;
				count++;
				result = Math.Max(result, count);
			}
			return result;
		}
	}
}
