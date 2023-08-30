using OpenQA.Selenium;

namespace WebDriverEmail.GMail
{
	public class AccountFrameGmail : BasePage
	{
		private readonly By accountManagementLocator = By.XPath("//span[@class='oREknc vZvJBb']");
		public AccountFrameGmail(WebDriver driver) : base(driver)
		{

		}

		public AccountSettingsGmail OpenAccountManagement()
		{
			FindElementWithWaiter(accountManagementLocator).Click();
			var windowHandles = driver.WindowHandles;
			driver.SwitchTo().Window(windowHandles[1]);
			return new AccountSettingsGmail(driver);
		}
	}
}