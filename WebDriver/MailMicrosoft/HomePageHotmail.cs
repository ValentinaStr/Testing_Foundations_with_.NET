using OpenQA.Selenium;

namespace WebDriverEmail.MailMicrosoft
{
	public class HomePageHotmail : BasePage
	{
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