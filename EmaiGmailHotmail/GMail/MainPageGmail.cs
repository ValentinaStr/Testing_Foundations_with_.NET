using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EmaiGmailHotmail.GMail
{
	public class MainPageGMail : BasePage
	{
		[FindsBy(How = How.XPath, Using = "//a[@class='gb_d gb_Da gb_H']")]
		public readonly IWebElement account;

		[FindsBy(How = How.XPath, Using = "//div[@class='T-I T-I-KE L3']")]
		public readonly IWebElement newLetterCreate;

		[FindsBy(How = How.XPath, Using = "//div[contains(@style,'font-family:Aptos,Aptos')]")]
		public readonly IWebElement textIncommingLetter;

		[FindsBy(How = How.XPath, Using = "//tr[@role='row'][1]")]
		public readonly IWebElement firstIncomingLetter;

		private readonly string nameAccountFrame = "account";

		public MainPageGMail(WebDriver driver) : base(driver)
		{
			PageFactory.InitElements(driver, this);
		}

		public AccountFrameGmail SwithToAccountFrame()
		{
			ClickElementWithWaiter(account);
			SwithToFrame(nameAccountFrame);
			return new AccountFrameGmail(driver);
		}

		public string GetEmailNameFromAccount()
		{
			ElementIsClickable(account);
			return account.GetAttribute("aria-label");
		}
		public LetterGMail OpenNewLetterToCreate()
		{
			ClickElementWithWaiter(newLetterCreate);
			return new LetterGMail(driver);
		}

		public void OpenFirstIncomingLetter()
		{
			ClickElementWithWaiter(firstIncomingLetter);
		}

		public string GetTextDraftLetter()
		{
			return GetTextFromElementWithWaiter(textIncommingLetter);
		}
	}
}