using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EmailWebDriver.GMail
{
	public class AccountFrameGmail : BasePage
	{
		[FindsBy(How = How.XPath, Using = "//span[@class='oREknc vZvJBb']")]
		public IWebElement accountManagement { get; set; }

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