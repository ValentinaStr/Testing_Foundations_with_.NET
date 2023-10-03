using EmaiGmailHotmail.Model;
using EmaiGmailHotmail.GMail;
using EmaiGmailHotmail.Service;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace TaskWebDriver
{
	[TestFixture]
	public class LoginTests : BaseTest
	{
		public static User user = UserCreator.CreateUsers("ResourceGmail");
		public static User userWithIncorrectEmail = UserCreator.CreateUsersWithIncorrectEmail("ResourceGmail");
		public static User userWithIncorrectPassword = UserCreator.CreateUsersWithIncorrectPassword("ResourceGmail");
		public static User userWithEmptyPassword = UserCreator.CreateUsersWithEmptyPassword("ResourceGmail");
		public static User userWithEmptyEmail = UserCreator.CreateUsersWithEmptyEmail("ResourceGmail");

		[TestCase(TestName = "Check The Ability To Login Positive")]
		[Category("SmokeTests")]
		public void CheckTheAbilityToLoginPositive()
		{
			var homePage = new HomePageGMail(driver);
			var loginPage = homePage.OpenLoginPage();
			MainPageGMail mainPage = loginPage.Login(user);
			var emailName = mainPage.GetEmailNameFromAccount();
			Assert.IsTrue(emailName.Contains(user.Email), "Login with correct data");
		}

		[Category("Login")]
		[TestCase(ExpectedResult = "Couldn’t find your Google Account", TestName = "Login with incorrect email Negative")]
		public string CheckTheAbilityToLoginWithWrongEmailNegative()
		{
			var homePage = new HomePageGMail(driver);
			var loginPage = homePage.OpenLoginPage();

			loginPage.InputEmailInLogin(userWithIncorrectEmail.Email);
			var receivedWrongMessage = loginPage.CheckWrongOrEmptyEmail();

			return receivedWrongMessage;
		}

		[Category("Login")]
		[TestCase(ExpectedResult = "Enter an email or phone number", TestName = "Login With Empty Email Negative")]
		public string CheckTheAbilityToLoginWithEmptyEmailNegative()
		{
			var homePage = new HomePageGMail(driver);
			var loginPage = homePage.OpenLoginPage();

			loginPage.InputEmailInLogin(userWithEmptyEmail.Email);
			var receivedWrongMessage = loginPage.CheckWrongOrEmptyEmail();

			return receivedWrongMessage;
		}

		[Category("Login")]
		[TestCase("Wrong password. Try again or click Forgot password to reset it.", "Login with incorrect password", TestName = "Login with incorrect password Negative")]
		public void CheckTheAbilityToLoginWithWrongPasswordNegative(string wrongMessage, string testMessage)
		{
			var homePage = new HomePageGMail(driver);
			var loginPage = homePage.OpenLoginPage();

			loginPage.InputEmailInLogin(userWithIncorrectPassword.Email);
			loginPage.InputPasswordInLogin(userWithIncorrectPassword.Password);

			var receivedWrongMessage = loginPage.CheckWrongOrEmptyPassword();
			Assert.That(receivedWrongMessage, Is.EqualTo(wrongMessage), testMessage);
		}

		[Category("Login")]
		[TestCase("Enter a password", "Login with empty password", TestName = "Login with empty password Negative")]
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