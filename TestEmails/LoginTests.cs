using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using EmailWebDriver.GMail;
using SeleniumExtras.PageObjects;

namespace TestEmails
{
	[TestClass]
	public class LoginTests
	{
		private WebDriver driver;

		[TestInitialize]
		public void BeforeTest()
		{
			driver = new ChromeDriver();
		}

		[TestCleanup]
		public void ClassCleanup()
		{
			driver.Close();
		}

		[TestMethod]
		[DataRow("viktoriyaselenium", "123Viktoriya321")]
		public void CheckTheAbilityToLoginPositive(string email, string password)
		{
			var homePage = new HomePageGMail(driver);
			PageFactory.InitElements(driver, homePage);
			homePage.loginPage.Click();
			var loginPage = new LoginPageGMail(driver);
			PageFactory.InitElements(driver, loginPage);
			loginPage.loginEmail.SendKeys(email);
			loginPage.loginEmailNextButton.Click();
			loginPage.loginPassword.SendKeys(password);
			loginPage.loginPassowrdNextButton.Click();

			MainPageGMail mail001 = new MainPageGMail(driver);
			var emailName = mail001.GetEmail();
			Assert.IsTrue(emailName.Contains(email));
		}

		[TestMethod]
		[DataRow("hjyjsyk", "123Viktoriya321", "Couldn’t find your Google Account")]
		[DataRow("", "123Viktoriya321", "Enter an email or phone number")]
		public void CheckTheAbilityToLoginWithWrongEmailNegative(string email, string password, string message)
		{
			HomePageGMail home = new HomePageGMail(driver);
			LoginPageGMail loginPage = home.OpenLoginPage();
			loginPage.InputEmailInLogin(email);
			Thread.Sleep(1000);
			var wrongMessage = loginPage.CheckWrongOrEmptyEmail();
			Assert.AreEqual(message, wrongMessage);
		}

		[TestMethod]
		[DataRow("viktoriyaselenium", "123321", "Wrong password. Try again or click Forgot password to reset it.")]
		[DataRow("viktoriyaselenium", "", "Enter a password")]
		public void CheckTheAbilityToLoginWithWrongPasswordNegative(string email, string password, string message)
		{
			HomePageGMail home = new HomePageGMail(driver);
			LoginPageGMail loginPage = home.OpenLoginPage();
			loginPage.InputEmailInLogin(email);
			loginPage.InputPasswordInLogin(password);
			var wrongMessage = loginPage.CheckWrongOrEmptyPassword();
			Assert.AreEqual(message, wrongMessage);
		}
	}
}