using EmailWebDriver.GMail;

namespace TestEmails
{
	[TestClass]
	public class LoginTests : BaseTest
	{
		[TestMethod]
		[DataRow("viktoriyaselenium", "123Viktoriya321","Login with correct data")]
		public void CheckTheAbilityToLoginPositive(string email, string password, string testMessage)
		{
			var homePage = new HomePageGMail(driver);
			var loginPage = homePage.OpenLoginPage();

			MainPageGMail mainPage = loginPage.Login(email, password);
			var emailName = mainPage.GetEmailNameFromAccount();

			Assert.IsTrue(emailName.Contains(email),testMessage);
		}

		[TestMethod]
		[DataRow("hjyjsyk", "Couldn’t find your Google Account", "Login with incorrect email")]
		[DataRow("", "Enter an email or phone number", "Login with empty email")]
		public void CheckTheAbilityToLoginWithWrongEmailNegative(string email, string wrongMessage, string testMessage)
		{
			var homePage = new HomePageGMail(driver);
			var loginPage = homePage.OpenLoginPage();

			loginPage.InputEmailInLogin(email);
			var receivedWrongMessage = loginPage.CheckWrongOrEmptyEmail();
			
			Assert.AreEqual(wrongMessage, receivedWrongMessage, testMessage);
		}

		[TestMethod]
		[DataRow("viktoriyaselenium", "123321", "Wrong password. Try again or click Forgot password to reset it.", "Login with incorrect password")]
		[DataRow("viktoriyaselenium", "", "Enter a password", "Login with empty password")]
		public void CheckTheAbilityToLoginWithWrongPasswordNegative(string email, string password, string wrongMessage, string testMessage)
		{
			var homePage = new HomePageGMail(driver);
			var loginPage = homePage.OpenLoginPage();

			loginPage.InputEmailInLogin(email);
			loginPage.InputPasswordInLogin(password);
			
			var receivedWrongMessage = loginPage.CheckWrongOrEmptyPassword();
			Assert.AreEqual(wrongMessage, receivedWrongMessage, testMessage);
		}
	}
}