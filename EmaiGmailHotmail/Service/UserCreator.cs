using EmaiGmailHotmail.Model;
using EmaiGmailHotmail.Util;

namespace EmaiGmailHotmail.Service
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

		public static User CreateUsersWithEmptyEmail(string resourses)
		{
			userName = "";
			userPassword = TestDataReader.GetTestData(resourses, "Password");
			return new User(userName, userPassword);
		}

		public static User CreateUsersWithEmptyPassword(string resourses)
		{
			userName = TestDataReader.GetTestData(resourses, "Email");
			userPassword = "";
			return new User(userName, userPassword);
		}

		public static User CreateUsersWithIncorrectEmail(string resourses)
		{
			userName = RandomStringGenerator.GenerateRandomString(6);
			userPassword = TestDataReader.GetTestData(resourses, "Password");
			return new User(userName, userPassword);
		}

		public static User CreateUsersWithIncorrectPassword(string resourses)
		{
			userName = TestDataReader.GetTestData(resourses, "Email");
			userPassword = RandomStringGenerator.GenerateRandomString(6);
			return new User(userName, userPassword);
		}
	}
}