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


		private readonly By newLetterTextLocator = By.XPath("//div[@aria-label='Message body']");
        private readonly By createAnswerLocator = By.XPath("//button[@aria-label='Reply']");
        private readonly By sendAnswerLocator = By.XPath("//button[@aria-label='Send']");
        private readonly By textAnswerLocator = By.XPath("//div[@role='textbox']");
        public LetterHotmail(WebDriver _driver) : base(_driver)
        {
        }

        public string CheckNewLetterText()
        {
            return FindElementWithWaiter(newLetterTextLocator).Text;
        }

        public void AnswerLetter(string textAnswer)
        {
            FindElementWithWaiter(createAnswerLocator).Click();
            FindElementWithWaiter(textAnswerLocator).Click();
            driver.FindElement(textAnswerLocator).SendKeys(textAnswer);
            FindElementWithWaiter(sendAnswerLocator).Click();
            FindElementWithWaiter(createAnswerLocator);
            driver.Navigate().Refresh();
            try { driver.SwitchTo().Alert().Dismiss(); }
            catch { Console.WriteLine("!!!!!!!"); }
        }
    }
}