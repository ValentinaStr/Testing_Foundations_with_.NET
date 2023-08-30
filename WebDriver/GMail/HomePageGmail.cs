using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace WebDriverEmail.GMail
{
	public class HomePageGMail : BasePage
	{
		private readonly By loginPageLocator = By.XPath("//a[@data-action='sign in']");


		public HomePageGMail(WebDriver driver) : base(driver)
		{
			GoToUrl("https://www.google.com/intl/ru/gmail/about/");
		}

		public LoginPageGMail OpenLoginPage()
		{
			FindElementWithWaiter(loginPageLocator).Click();
			return new LoginPageGMail(driver);
		}
	}
}