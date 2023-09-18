using EmailWebDriver.GMail;
using EmailWebDriver.Model;
using EmailWebDriver.Service;
using EmailWebDriver.Util;

namespace TestEmails
{
	[TestClass]
	public class LoginTests : BaseTest
	{
		public static User user = UserCreator.CreateUsers("ResourceGmail");
		public static User userWithIncorrectEmail = new User(RandomStringGenerator.GenerateRandomString(6), user.Password);
		public static User userWithIncorrectPassword = new User(user.Email, RandomStringGenerator.GenerateRandomString(6));
		public static User userWithEmptyPassword = new User(user.Email, string.Empty);
		public static User userWithEmptyEmail = new User(string.Empty, user.Password);

		[TestMethod]
		[TestCategory("SmokeTests")]
		public void CheckTheAbilityToLoginPositive()
		{
			var homePage = new HomePageGMail(driver);
			var loginPage = homePage.OpenLoginPage();
			MainPageGMail mainPage = loginPage.Login(user);
			var emailName = mainPage.GetEmailNameFromAccount();
			Assert.IsTrue(emailName.Contains(user.Email), "Login with correct data");
		}

		[TestMethod]
		[DataRow("Couldn’t find your Google Account", "Login with incorrect email")]
		public void CheckTheAbilityToLoginWithWrongEmailNegative(string wrongMessage, string testMessage)
		{
			var homePage = new HomePageGMail(driver);
			var loginPage = homePage.OpenLoginPage();

			loginPage.InputEmailInLogin(userWithIncorrectEmail.Email);
			var receivedWrongMessage = loginPage.CheckWrongOrEmptyEmail();

			Assert.AreEqual(wrongMessage, receivedWrongMessage, testMessage);
		}

		[TestMethod]
		[DataRow("Enter an email or phone number", "Login with empty email")]
		public void CheckTheAbilityToLoginWithEmptyEmailNegative(string wrongMessage, string testMessage)
		{
			var homePage = new HomePageGMail(driver);
			var loginPage = homePage.OpenLoginPage();

			loginPage.InputEmailInLogin(userWithEmptyEmail.Email);
			var receivedWrongMessage = loginPage.CheckWrongOrEmptyEmail();

			Assert.AreEqual(wrongMessage, receivedWrongMessage, testMessage);
		}

		[TestMethod]
		[DataRow("Wrong password. Try again or click Forgot password to reset it.", "Login with incorrect password")]
		public void CheckTheAbilityToLoginWithWrongPasswordNegative(string wrongMessage, string testMessage)
		{
			var homePage = new HomePageGMail(driver);
			var loginPage = homePage.OpenLoginPage();

			loginPage.InputEmailInLogin(userWithIncorrectPassword.Email);
			loginPage.InputPasswordInLogin(userWithIncorrectPassword.Password);

			var receivedWrongMessage = loginPage.CheckWrongOrEmptyPassword();
			Assert.AreEqual(wrongMessage, receivedWrongMessage, testMessage);
		}

		[TestMethod]
		[DataRow("Enter a password", "Login with empty password")]
		public void CheckTheAbilityToLoginWithEmptyPasswordNegative(string wrongMessage, string testMessage)
		{
			var homePage = new HomePageGMail(driver);
			var loginPage = homePage.OpenLoginPage();

			loginPage.InputEmailInLogin(userWithEmptyPassword.Email);
			loginPage.InputPasswordInLogin(userWithEmptyPassword.Password);

			var receivedWrongMessage = loginPage.CheckWrongOrEmptyPassword();
			Assert.AreEqual(wrongMessage, receivedWrongMessage, testMessage);
		}
	}
}