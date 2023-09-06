using OpenQA.Selenium;

namespace EmailWebDriver.MailMicrosoft
{
    public class LetterHotmail : BasePage
    {
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