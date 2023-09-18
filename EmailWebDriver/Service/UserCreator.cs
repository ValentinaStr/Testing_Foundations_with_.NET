using EmailWebDriver.Model;

namespace EmailWebDriver.Service
{
	public class UserCreator
	{
		public static string userName;
		public static string userPassword;

		public static User CreateUsers(string resourses)
		{
			userName = TestDataReader.GetTestData(resourses, "Email");
			userPassword = TestDataReader.GetTestData(resourses, "Password");
			return new User(userName, userPassword);
		}
	}
}