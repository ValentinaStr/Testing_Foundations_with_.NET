using EmailWebDriver.Model;
using EmailWebDriver.Util;

namespace EmailWebDriver.Service
{
    public class UserCreator
	{
		public static string userNameGmail = "viktoriyaselenium";
		public static string userPasswordGmail = "123Viktoriya321";

		public static string userNameHotmail = "viktoriyaselenium";
		public static string userPasswordHotmail = "123Viktoriya321";

		public static User CreateUserGmail()
		{
			return new User(userNameGmail, userPasswordGmail);
		}

		public static User CreateUserHotmail()
		{
			return new User(userNameHotmail, userPasswordHotmail);
		}

		public static User CreateUserEmptyEmailGmail()
		{
			return new User("", userPasswordGmail);
		}

		public static User CreateUserEmptyPasswordGmail()
		{
			return new User(userNameGmail, "");
		}

		public static User CreateUserIncorrectEmailGmail()
		{
			return new User(RandomStringGenerator.GenerateRandomString(6), userPasswordGmail);
		}

		public static User CreateUserIncorrectPasswordGmail()
		{
			return new User(userNameGmail, RandomStringGenerator.GenerateRandomString(6));
		}

		public static User CreateUserEmptyEmailHotmail()
		{
			return new User("", userPasswordHotmail);
		}

		public static User CreateUserEmptyPasswordHotmail()
		{
			return new User(userNameHotmail, "");
		}

		public static User CreateUserIncorrectEmailHotmail()
		{
			return new User(RandomStringGenerator.GenerateRandomString(6), userPasswordHotmail);
		}

		public	static User CreateUserIncorrectPasswordHotmail()
		{
			return new User(userNameHotmail, RandomStringGenerator.GenerateRandomString(6));
		}
	}
}