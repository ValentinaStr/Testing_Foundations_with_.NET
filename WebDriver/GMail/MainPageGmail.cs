using OpenQA.Selenium;

namespace WebDriverEmail.GMail
{
	public class MainPageGMail : BasePage
	{
		private readonly By accountLocator = By.XPath("//a[@class='gb_d gb_xa gb_A']");
		private readonly By newLetterCreateLocator = By.XPath("//div[@class='T-I T-I-KE L3']");
		private readonly By textIncommingLetterLocator = By.XPath("//div[contains(@style,'font-family:Aptos,Aptos_EmbeddedFont')]");

		public MainPageGMail(WebDriver driver) : base(driver)
		{

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