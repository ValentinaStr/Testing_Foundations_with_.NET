using EmailWebDriver.GMail;
using EmailWebDriver.Model;
using EmailWebDriver.Service;
using EmailWebDriver.Util;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace NUnitTestProject
{
	[TestFixture]
	public class LoginTests : BaseTest
	{
		public static User user = UserCreator.CreateUsers("ResourceGmail");
		public static User userWithIncorrectEmail = new User(RandomStringGenerator.GenerateRandomString(6), user.Password);
		public static User userWithIncorrectPassword = new User(user.Email, RandomStringGenerator.GenerateRandomString(6));
		public static User userWithEmptyPassword = new User(user.Email, string.Empty);
		public static User userWithEmptyEmail = new User(string.Empty, user.Password);

		[Test]
		[Category("SmokeTests")]
		public void CheckTheAbilityToLoginPositive()
		{
			var homePage = new HomePageGMail(driver);
			var loginPage = homePage.OpenLoginPage();
			MainPageGMail mainPage = loginPage.Login(user);
			var emailName = mainPage.GetEmailNameFromAccount();
			Assert.IsTrue(emailName.Contains(user.Email), "Login with correct data");
		}

		[Test]
		[Category("")]
		[TestCase(ExpectedResult = "Couldn’t find your Google Account", TestName = "Login with incorrect email")]
		public string CheckTheAbilityToLoginWithWrongEmailNegative()
		{
			var homePage = new HomePageGMail(driver);
			var loginPage = homePage.OpenLoginPage();

			loginPage.InputEmailInLogin(userWithIncorrectEmail.Email);
			var receivedWrongMessage = loginPage.CheckWrongOrEmptyEmail();

			return receivedWrongMessage;
		}

		[Test]
		[TestCase(ExpectedResult = "Enter an email or phone number", TestName = "Login With Empty Email Negative")]
		public string CheckTheAbilityToLoginWithEmptyEmailNegative()
		{
			var homePage = new HomePageGMail(driver);
			var loginPage = homePage.OpenLoginPage();

			loginPage.InputEmailInLogin(userWithEmptyEmail.Email);
			var receivedWrongMessage = loginPage.CheckWrongOrEmptyEmail();

			return receivedWrongMessage;
		}

		[Test]
		[TestCase("Wrong password. Try again or click Forgot password to reset it.", "Login with incorrect password", TestName = "Login with incorrect password")]
		public void CheckTheAbilityToLoginWithWrongPasswordNegative(string wrongMessage, string testMessage)
		{
			var homePage = new HomePageGMail(driver);
			var loginPage = homePage.OpenLoginPage();

			loginPage.InputEmailInLogin(userWithIncorrectPassword.Email);
			loginPage.InputPasswordInLogin(userWithIncorrectPassword.Password);

			var receivedWrongMessage = loginPage.CheckWrongOrEmptyPassword();
			Assert.That(receivedWrongMessage, Is.EqualTo(wrongMessage), testMessage);
		}

		[Test]
		[TestCase("Enter a password", "Login with empty password", TestName = "Login with empty password")]
		public void CheckTheAbilityToLoginWithEmptyPasswordNegative(string wrongMessage, string testMessage)
		{
			var homePage = new HomePageGMail(driver);
			var loginPage = homePage.OpenLoginPage();

			loginPage.InputEmailInLogin(userWithEmptyPassword.Email);
			loginPage.InputPasswordInLogin(userWithEmptyPassword.Password);

			var receivedWrongMessage = loginPage.CheckWrongOrEmptyPassword();
			Assert.That(receivedWrongMessage, Is.EqualTo(wrongMessage), testMessage);
		}
	}
}