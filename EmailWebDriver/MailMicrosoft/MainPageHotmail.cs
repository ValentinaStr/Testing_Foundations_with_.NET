using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EmailWebDriver.MailMicrosoft
{
	public class MainPageHotmail : BasePage
	{
		[FindsBy(How = How.XPath, Using = "//div[contains(@aria-label,'Unread Viktoriya Selenium')][1]")]
		public IWebElement newLetter { get; set; }

		private readonly By newLetterLocator = By.XPath("//div[contains(@aria-label,'Unread Viktoriya Selenium')]");

		public MainPageHotmail(WebDriver driver) : base(driver)
		{
		}

		public LetterHotmail OpenNewUnreadLetterFrom()
		{
			FindElementsWithWaiter(newLetterLocator)[0].Click();
			return new LetterHotmail(driver);
		}
	}
}