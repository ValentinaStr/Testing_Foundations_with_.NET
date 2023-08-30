using OpenQA.Selenium;

namespace WebDriverEmail.GMail
{
	public class LoginPageGMail : BasePage
	{
		private readonly By loginEmaillocator = By.Id("identifierId");
		private readonly By loginEmailNextButtonLocator = By.XPath("//div[@id='identifierNext']");
		private readonly By loginPasswordLocator = By.XPath("//input[@type='password']");
		private readonly By loginPassowrdNextButtonLocator = By.XPath("//div[@id='passwordNext']");
		private readonly By wrongOrEmptyLoginLocator = By.XPath("//div[@class='o6cuMc Jj6Lae']");
		private readonly By wrongOrEmptyPasswordLocator = By.XPath("//div[@class='OyEIQ uSvLId']");

		public LoginPageGMail(WebDriver driver) : base(driver)
		{
		}

		public MainPageGMail Login(string email, string password)
		{
			RefreshCookies();
			InputEmailInLogin(email);
			InputPasswordInLogin(password);
			return new MainPageGMail(driver);
		}

		public void RefreshCookies()
		{
			driver.Manage().Cookies.DeleteAllCookies();
			driver.Navigate().Refresh();
			Thread.Sleep(100);
		}

		public void InputEmailInLogin(string email)
		{
			driver.FindElement(loginEmaillocator).SendKeys(email);
			FindElementWithWaiter(loginEmailNextButtonLocator).Click();
		}
		public void InputPasswordInLogin(string password)
		{
			FindElementWithWaiter(loginPasswordLocator).SendKeys(password);
			FindElementWithWaiter(loginPassowrdNextButtonLocator).Click();
		}

		public string CheckWrongOrEmptyEmail()
		{
			FindElementWithWaiter(wrongOrEmptyLoginLocator);
			return driver.FindElement(wrongOrEmptyLoginLocator).Text;
		}

		public string CheckWrongOrEmptyPassword()
		{
			FindElementWithWaiter(wrongOrEmptyPasswordLocator);
			return driver.FindElement(wrongOrEmptyPasswordLocator).Text;
		}
	}
}