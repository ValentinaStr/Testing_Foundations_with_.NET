using System.Reflection;
using System.Resources;

namespace EmaiGmailHotmail.Service
{
	public class TestDataReader
	{
		public static string GetTestData(string mail, string keyName)
		{
			var resManager = GetResourceManager(mail);
			return resManager.GetString(keyName);
		}

		private static ResourceManager GetResourceManager(string resourses)
		{	
			return new ResourceManager($"EmaiGmailHotmail.Resources.{resourses}", Assembly.GetExecutingAssembly());
		}
	}
}