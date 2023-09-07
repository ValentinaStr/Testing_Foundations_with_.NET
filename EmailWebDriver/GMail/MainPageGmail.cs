using OpenQA.Selenium;

namespace EmailWebDriver.GMail
{
	public class MainPageGMail : BasePage
	{
		private readonly By accountLocator = By.XPath("//a[@class='gb_d gb_Aa gb_D']");
		private readonly By newLetterCreateLocator = By.XPath("//div[@class='T-I T-I-KE L3']");
		private readonly By textIncommingLetterLocator = By.XPath("//div[contains(@style,'font-family:Aptos,Aptos_EmbeddedFont')]");

		private readonly string nameAccountFrame = "account";

		public MainPageGMail(WebDriver driver) : base(driver)
		{

		}

		public AccountFrameGmail SwithToFrame()
		{
			FindElementWithWaiter(accountLocator).Click();
			Thread.Sleep(100);
			driver.SwitchTo().Frame(nameAccountFrame);
			return new AccountFrameGmail(driver);
		}

		public string GetEmail()
		{
			return FindElementWithWaiter(accountLocator).GetAttribute("aria-label");
		}
		public LetterGMail OpenPageLetterGMail()
		{
			FindElementWithWaiter(newLetterCreateLocator).Click();
			return new LetterGMail(driver);
		}

		public void OpenFirstLetter()
		{
			FindElementsWithWaiter(By.XPath("//tr[@role='row']"))[0].Click();
		}

		public string GetTextDraftLetter()
		{
			return FindElementWithWaiter(textIncommingLetterLocator).Text;
		}
	}
}