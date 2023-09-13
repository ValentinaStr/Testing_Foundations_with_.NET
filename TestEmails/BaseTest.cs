using OpenQA.Selenium;
using EmailWebDriver;
using EmailWebDriver.Model;
using EmailWebDriver.Service;

namespace TestEmails
{
	public abstract class BaseTest
	{
		protected WebDriver driver;

		public static User userGmail;
		public static User userGmailWithIncorrectEmail;
		public static User userGmailWithEmptyEmail;
		public static User userGmailWithIncorrectPassword;
		public static User userGmailWithEmptyPassword;


		[TestInitialize]
		public void BeforeTestOnChrome()
		{
			driver = DriverSinglton.GetDriver("Chrome");

			userGmail = UserCreator.CreateUserGmail();
			userGmailWithIncorrectEmail = UserCreator.CreateUserIncorrectEmailGmail();
			userGmailWithEmptyEmail = UserCreator.CreateUserEmptyEmailGmail();
			userGmailWithIncorrectPassword = UserCreator.CreateUserIncorrectPasswordGmail();
			userGmailWithEmptyPassword = UserCreator.CreateUserEmptyPasswordGmail();
		}

		[TestCleanup]
		public void ClassCleanup()
		{
			DriverSinglton.ClosedDriver();
		}
	}
}