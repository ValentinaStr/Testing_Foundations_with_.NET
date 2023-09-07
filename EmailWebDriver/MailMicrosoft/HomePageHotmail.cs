using OpenQA.Selenium;
using EmailWebDriver;
using SeleniumExtras.PageObjects;

namespace EmailWebDriver.MailMicrosoft
{
	public class HomePageHotmail : BasePage
	{
		[FindsBy(How = How.LinkText, Using = "Sign in")]
		public readonly IWebElement logIn;

		private readonly By loginLocator = By.LinkText("Sign in");

		public HomePageHotmail(WebDriver driver) : base(driver)
		{
			GoToUrl("https://outlook.live.com/mail/0/");
		}

		public LoginPageHotmail OpenLoginPage()
		{
			FindElementWithWaiter(loginLocator).Click();
			return new LoginPageHotmail(driver);
		}
	}
}