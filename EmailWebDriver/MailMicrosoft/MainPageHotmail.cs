using OpenQA.Selenium;

namespace EmailWebDriver.MailMicrosoft
{
    public class MainPageHotmail : BasePage
    {

        private readonly By newLetterLocator = By.XPath("//div[contains(@aria-label,'Unread Viktoriya Selenium')]");
        private readonly By newLetterTextLocator = By.XPath("//div[@aria-label='Message body']");
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