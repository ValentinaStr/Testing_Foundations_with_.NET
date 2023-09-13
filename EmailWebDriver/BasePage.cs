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
		private const int waitTime = 30;

		public BasePage(WebDriver driver)
		{
			this.driver = driver;
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
		}

		protected void GoToUrl(string url)
		{
			driver.Url = url;
			try
			{
				AcceptAlert();
			}
			catch { }
		}
		
		public void ClickElementWithWaiter(IWebElement webElement)
		{
			wait.Until(ExpectedConditions.ElementToBeClickable(webElement)).Click();
		}

		public void ClearElementWithWaiter(IWebElement webElement)
		{
			wait.Until(driver => webElement.Displayed);
			webElement.Clear();
		}

		public void SendKeyElementWithWaiter(IWebElement webElement, string text)
		{
			wait.Until(ExpectedConditions.ElementToBeClickable(webElement)).SendKeys(text);
		}

		public void ElementIsClickable(IWebElement webElement)
		{
			wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
		}

		public string GetTextFromElementWithWaiter(IWebElement webElement)
		{
			wait.Until(driver => webElement.Displayed);
			var r = webElement.Text;
			return webElement.Text;
		}

		public void  SwithToFrame(String nameFrame)
		{
			driver.SwitchTo().Frame(nameFrame);
		}

		public void RefreshPage()
		{
			driver.Navigate().Refresh();
		}

		public void SwithToWindow(int numberWindow)
		{
			var windowHandles = driver.WindowHandles;
			driver.SwitchTo().Window(windowHandles[numberWindow]);
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