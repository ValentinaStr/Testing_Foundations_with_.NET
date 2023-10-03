using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EmaiGmailHotmail.GMail
{
	public class HomePageGMail : BasePage
	{
		[FindsBy(How = How.XPath, Using = "//a[@data-action='sign in']")]
		public readonly IWebElement loginPage;

		public HomePageGMail(WebDriver driver) : base(driver)
		{
			PageFactory.InitElements(driver, this);
			GoToUrl("https://www.google.com/intl/ru/gmail/about/");
		}

		public LoginPageGMail OpenLoginPage()
		{
			ClickElementWithWaiter(loginPage);
			return new LoginPageGMail(driver);
		}
	}
}