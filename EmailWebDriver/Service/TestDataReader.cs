using System.Reflection;
using System.Resources;

namespace EmailWebDriver.Service
{
	internal class TestDataReader
	{
		public static string GetTestData(string mail, string keyName)
		{
			var resManager = GetResourceManager(mail);
			return resManager.GetString(keyName);
		}

		private static ResourceManager GetResourceManager(string resourses)
		{	
			return new ResourceManager($"EmailWebDriver.Resources.{resourses}", Assembly.GetExecutingAssembly());
		}
	}
}