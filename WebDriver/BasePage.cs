using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using SeleniumExtras.WaitHelpers;

namespace WebDriverEmail
{
	public abstract class BasePage
	{
		private readonly By accountLocator = By.XPath("//a[@class='gb_d gb_xa gb_A']");
		private readonly string nameAccountFrame = "account";

		protected WebDriver driver;
		protected WebDriverWait wait;
		const int WAITTIME = 20;

		public BasePage(WebDriver driverC)
		{
			driver = driverC;
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAITTIME));
		}

		protected void GoToUrl(string url)
		{
			driver.Url = url;
		}

		public IWebElement FindElementWithWaiter(By nameLocator)
		{
			return wait.Until(ExpectedConditions.ElementIsVisible(nameLocator));
		}

		protected ReadOnlyCollection<IWebElement> FindElementsWithWaiter(By nameLocator)
		{
			return wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(nameLocator));
		}

		public void SwithToFrame()
		{
			FindElementWithWaiter(accountLocator).Click();
			Thread.Sleep(100);
			driver.SwitchTo().Frame(nameAccountFrame);
		}
	}
}