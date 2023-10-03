using EmaiGmailHotmail.Model;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EmaiGmailHotmail.MailMicrosoft
{
	public class LoginPageHotmail : BasePage
	{

		[FindsBy(How = How.XPath, Using = "//input[@type='email']")]
		public IWebElement loginEmail;

		[FindsBy(How = How.Id, Using = "idSIButton9")]
		public IWebElement loginNextButton;

		[FindsBy(How = How.XPath, Using = "//input[@type='password']")]
		public IWebElement loginPassword;

		[FindsBy(How = How.Id, Using = "idBtn_Back")]
		public IWebElement notStaySignedIn;

		public LoginPageHotmail(WebDriver driver) : base(driver)
		{
			PageFactory.InitElements(driver, this);
		}

		public MainPageHotmail Login(User user)
		{
			InputEmailInLogin(user.Email);
			InputPasswordInLogin(user.Password);
			return new MainPageHotmail(driver);
		}
		public void InputEmailInLogin(string email)
		{
			SendKeyElementWithWaiter(loginEmail, email);
			ClickElementWithWaiter(loginNextButton);
		}
		public void InputPasswordInLogin(string password)
		{
			SendKeyElementWithWaiter(loginPassword, password);
			ClickElementWithWaiter(loginNextButton);
			ClickElementWithWaiter(notStaySignedIn);
		}
	}
}