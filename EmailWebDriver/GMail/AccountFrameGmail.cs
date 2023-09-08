using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EmailWebDriver.GMail
{
	public class AccountFrameGmail : BasePage
	{
		[FindsBy(How = How.XPath, Using = "//span[@class='oREknc vZvJBb']")]
		public IWebElement accountManagement;
		public AccountFrameGmail(WebDriver driver) : base(driver)
		{
			PageFactory.InitElements(driver, this);
		}

		public AccountSettingsGmail OpenAccountManagement()
		{
			ClickElementWithWaiter(accountManagement);
			SwithToWindow(1);
			return new AccountSettingsGmail(driver);
		}
	}
}