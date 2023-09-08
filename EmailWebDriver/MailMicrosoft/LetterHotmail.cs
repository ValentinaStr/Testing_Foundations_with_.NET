using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EmailWebDriver.MailMicrosoft
{
	public class LetterHotmail : BasePage
	{
		[FindsBy(How = How.XPath, Using = "//div[@aria-label='Message body']")]
		public readonly IWebElement newLetterText;

		[FindsBy(How = How.XPath, Using = "//button[@aria-label='Reply']")]
		public readonly IWebElement createAnswer;

		[FindsBy(How = How.XPath, Using = "//button[@aria-label='Send']")]
		public readonly IWebElement sendAnswer;

		[FindsBy(How = How.XPath, Using = "//div[@role='textbox']")]
		public readonly IWebElement textAnswer;

		public LetterHotmail(WebDriver _driver) : base(_driver)
		{
			PageFactory.InitElements(driver, this);
		}

		public string GetNewLetterText()
		{
			return GetTextFromElementWithWaiter(newLetterText);
		}

		public void AnswerLetter(string text)
		{
			ClickElementWithWaiter(createAnswer);
			SendKeyElementWithWaiter(textAnswer, text);
			ClickElementWithWaiter(sendAnswer);
			ElementIsClickable(createAnswer);
			RefreshPage();
			Thread.Sleep(1000);
			try
			{
				DismissAlert();
			}
			catch { }
		}
	}
}