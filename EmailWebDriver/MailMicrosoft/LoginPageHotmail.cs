using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EmailWebDriver.MailMicrosoft
{
    public class LoginPageHotmail : BasePage
    {

		[FindsBy(How = How.XPath, Using = "//input[@type='email']")]
		public IWebElement loginEmail { get; set; }

		[FindsBy(How = How.Id, Using = "idSIButton9")]
		public IWebElement loginNextButton { get; set; }

		[FindsBy(How = How.XPath, Using = "//input[@type='password'")]
		public IWebElement loginPassword { get; set; }

		[FindsBy(How = How.Id, Using = "idBtn_Back")]
		public IWebElement notStaySignedIn { get; set; }


		/*private readonly By loginEmail = By.XPath("//input[@type='email']");
        private readonly By loginPassword = By.XPath("//input[@type='password']");
        private readonly By loginEmailPasswordNextButton = By.Id("idSIButton9");
        private readonly By notStaySignedIn = By.Id("idBtn_Back");*/

        public LoginPageHotmail(WebDriver driver) : base(driver)
        {

        }

        /*public MainPageHotmail Login(string email, string password)
        {
            InputEmailInLogin(email);
            InputPasswordInLogin(password);
            return new MainPageHotmail(driver);
        }
        public void InputEmailInLogin(string email)
        {
            FindElementWithWaiter(loginEmail).SendKeys(email);
            FindElementWithWaiter(loginEmailPasswordNextButton).Click();
        }
        public void InputPasswordInLogin(string password)
        {
            FindElementWithWaiter(loginPassword).SendKeys(password);
            FindElementWithWaiter(loginEmailPasswordNextButton).Click();
            FindElementWithWaiter(notStaySignedIn).Click();
        }*/
    }
}