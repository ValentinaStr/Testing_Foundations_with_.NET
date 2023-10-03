using EmaiGmailHotmail.Model;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EmaiGmailHotmail.GMail
{
	public class LoginPageGMail : BasePage
	{
		[FindsBy(How = How.Id, Using = "identifierId")]
		public readonly IWebElement loginEmail;

		[FindsBy(How = How.XPath, Using = "//div[@id='identifierNext']")]
		public readonly IWebElement loginEmailNextButton;

		[FindsBy(How = How.XPath, Using = "//input[@type='password']")]
		public readonly IWebElement loginPassword;

		[FindsBy(How = How.XPath, Using = "//div[@id='passwordNext']")]
		public readonly IWebElement loginPassowrdNextButton;

		[FindsBy(How = How.XPath, Using = "//div[@class='o6cuMc Jj6Lae']")]
		public readonly IWebElement wrongOrEmptyLogin;

		[FindsBy(How = How.XPath, Using = "//div[@class='OyEIQ uSvLId']")]
		public readonly IWebElement wrongOrEmptyPassword;

		public LoginPageGMail(WebDriver driver) : base(driver)
		{
			PageFactory.InitElements(driver, this);
		}

		public MainPageGMail Login(User user)
		{
			RefreshCookies();
			InputEmailInLogin(user.Email);
			InputPasswordInLogin(user.Password);
			return new MainPageGMail(driver);
		}

		public void RefreshCookies()
		{
			driver.Manage().Cookies.DeleteAllCookies();
			driver.Navigate().Refresh();
			Thread.Sleep(100);
		}

		public void InputEmailInLogin(string email)
		{
			SendKeyElementWithWaiter(loginEmail, email);
			ClickElementWithWaiter(loginEmailNextButton);
		}
		public void InputPasswordInLogin(string password)
		{
			SendKeyElementWithWaiter(loginPassword, password);
			ClickElementWithWaiter(loginPassowrdNextButton);
		}

		public string CheckWrongOrEmptyEmail()
		{
			return GetTextFromElementWithWaiter(wrongOrEmptyLogin);
		}

		public string CheckWrongOrEmptyPassword()
		{
			return GetTextFromElementWithWaiter(wrongOrEmptyPassword);
		}
	}
}