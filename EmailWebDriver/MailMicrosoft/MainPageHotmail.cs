using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EmailWebDriver.MailMicrosoft
{
	public class MainPageHotmail : BasePage
	{
		[FindsBy(How = How.XPath, Using = "//div[contains(@aria-label,'Unread Viktoriya Selenium')][1]")]
		public IWebElement newLetter { get; set; }

		public MainPageHotmail(WebDriver driver) : base(driver)
		{
			PageFactory.InitElements(driver, this);
		}

		public LetterHotmail OpenNewUnreadLetterFrom()
		{
			ClickElementWithWaiter(newLetter);
			//newLetter.Click();
			return new LetterHotmail(driver);
		}
	}
}