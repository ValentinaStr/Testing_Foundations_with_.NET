using System.Text;

namespace EmaiGmailHotmail.Util
{
	public static class RandomStringGenerator
	{
		private static Random random = new Random();

		private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

		public static string GenerateRandomString(int length)
		{
			var stringResalt = new StringBuilder();

			while (length > 0)
			{
				var indexrandom = random.Next(chars.Length - 1);
				stringResalt.Append(chars[indexrandom]);
				length--;
			}

			return stringResalt.ToString();
		}
	}
}