using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EmailWebDriver.MailMicrosoft
{
	public class HomePageHotmail : BasePage
	{
		[FindsBy(How = How.LinkText, Using = "Sign in")]
		public readonly IWebElement logIn;

		public HomePageHotmail(WebDriver driver) : base(driver)
		{
			PageFactory.InitElements(driver, this);
			driver.Url = "https://outlook.live.com/mail/0/";
		}

		public LoginPageHotmail OpenLoginPage()
		{
			ClickElementWithWaiter(logIn);
			return new LoginPageHotmail(driver);
		}
	}
}