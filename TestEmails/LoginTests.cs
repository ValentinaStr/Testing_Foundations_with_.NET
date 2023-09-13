using EmailWebDriver.GMail;
using EmailWebDriver.Model;

namespace TestEmails
{
	[TestClass]
	public class LoginTests : BaseTest
	{
		[TestMethod]
		public void CheckTheAbilityToLoginPositive()
		{
			var homePage = new HomePageGMail(driver);
			var loginPage = homePage.OpenLoginPage();
			MainPageGMail mainPage = loginPage.Login(userGmail);
			var emailName = mainPage.GetEmailNameFromAccount();
			Assert.IsTrue(emailName.Contains(userGmail.Email), "Login with correct data");
		}



		[TestMethod]
		[DataRow("Couldn’t find your Google Account", "Login with incorrect email")]
		public void CheckTheAbilityToLoginWithWrongEmailNegative(string wrongMessage, string testMessage)
		{
			var homePage = new HomePageGMail(driver);
			var loginPage = homePage.OpenLoginPage();

			loginPage.InputEmailInLogin(userGmailWithIncorrectEmail.Email);
			var receivedWrongMessage = loginPage.CheckWrongOrEmptyEmail();

			Assert.AreEqual(wrongMessage, receivedWrongMessage, testMessage);
		}

		[TestMethod]
		[DataRow("Enter an email or phone number", "Login with empty email")]
		public void CheckTheAbilityToLoginWithEmptyEmailNegative(string wrongMessage, string testMessage)
		{
			var homePage = new HomePageGMail(driver);
			var loginPage = homePage.OpenLoginPage();

			loginPage.InputEmailInLogin(userGmailWithEmptyEmail.Email);
			var receivedWrongMessage = loginPage.CheckWrongOrEmptyEmail();

			Assert.AreEqual(wrongMessage, receivedWrongMessage, testMessage);
		}

		[TestMethod]
		[DataRow("Wrong password. Try again or click Forgot password to reset it.", "Login with incorrect password")]
		public void CheckTheAbilityToLoginWithWrongPasswordNegative(string wrongMessage, string testMessage)
		{
			var homePage = new HomePageGMail(driver);
			var loginPage = homePage.OpenLoginPage();

			loginPage.InputEmailInLogin(userGmailWithIncorrectPassword.Email);
			loginPage.InputPasswordInLogin(userGmailWithIncorrectPassword.Password);

			var receivedWrongMessage = loginPage.CheckWrongOrEmptyPassword();
			Assert.AreEqual(wrongMessage, receivedWrongMessage, testMessage);
		}

		[TestMethod]
		[DataRow("Enter a password", "Login with empty password")]
		public void CheckTheAbilityToLoginWithEmptyPasswordNegative(string wrongMessage, string testMessage)
		{
			var homePage = new HomePageGMail(driver);
			var loginPage = homePage.OpenLoginPage();

			loginPage.InputEmailInLogin(userGmailWithEmptyPassword.Email);
			loginPage.InputPasswordInLogin(userGmailWithEmptyPassword.Password);

			var receivedWrongMessage = loginPage.CheckWrongOrEmptyPassword();
			Assert.AreEqual(wrongMessage, receivedWrongMessage, testMessage);
		}
	}
}