using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using SeleniumExtras.WaitHelpers;

namespace EmailWebDriver
{
	public abstract class BasePage
	{
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

		public void WeitInvisibility(By nameLocator)
		{
			wait.Until(ExpectedConditions.InvisibilityOfElementLocated(nameLocator));
		}

		protected ReadOnlyCollection<IWebElement> FindElementsWithWaiter(By nameLocator)
		{
			return wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(nameLocator));
		}

		
		public void AcceptAlert()
		{
			driver.SwitchTo().Alert().Accept();
		}

		public string GetTextAlert()
		{
			return driver.SwitchTo().Alert().Text;
		}

		public void DismissAlert()
		{
			driver.SwitchTo().Alert().Dismiss();
		}
	}
}