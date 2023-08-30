using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverEmail.MailMicrosoft;
using WebDriverEmail.GMail;

namespace SendLetterTest
{
	[TestClass]
	public class UnitTest1
	{
		private WebDriver driver;

		[TestInitialize]
		public void BeforeTest()
		{
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
		}

		[TestCleanup]
		public void ClassCleanup()
		{
			driver.Close();
		}

		[TestMethod]
		[DataRow("viktoriyaselenium", "123Viktoriya321",
			"viktoriyaselenium@outlook.com", "123Viktoriya321", "Hi from me", "Do you want new NikName?")]
		public void CheckGetLetter(string firstEmail, string firstPassword, string secondEmail, string secondPassord, string termLetter, string textLetter)
		{
			HomePageGMail homePageGMail = new HomePageGMail(driver);
			LoginPageGMail loginPageGMail = homePageGMail.OpenLoginPage();
			loginPageGMail.Login(firstEmail, firstPassword);
			MainPageGMail mainPageGMail = new MainPageGMail(driver);
			var letter = mainPageGMail.OpenPageLetterGMail();
			letter.CreateNewLetterAndSend(secondEmail, termLetter, textLetter);

			Thread.Sleep(1050);

			var homePageHotmail = new HomePageHotmail(driver);
			var loginPageHotmail = homePageHotmail.OpenLoginPage();
			loginPageHotmail.InputEmailInLogin(secondEmail);
			loginPageHotmail.InputPasswordInLogin(secondPassord);
			
			MainPageHotmail mainPageHotmail = new MainPageHotmail(driver);
			var lett = mainPageHotmail.OpenNewUnreadLetterFrom();

			Assert.IsNotNull(lett);
			Assert.AreEqual(textLetter, lett.CheckNewLetterText());
		}

		[TestMethod]
		[DataRow("viktoriyaselenium", "123Viktoriya321",
				"viktoriyaselenium@outlook.com", "123Viktoriya321",
				"Hi from winter ", "How you?",
				"fines")]
		public void CheckGetAnswerLetter(string firstEmail, string firstPassword,
									string secondEmail, string secondPassword,
									string termLetter, string textLetter,
									string textAnswerLetter)
		{
			HomePageGMail homePageGMail = new HomePageGMail(driver);
			LoginPageGMail loginPageGMail = homePageGMail.OpenLoginPage();
			loginPageGMail.Login(firstEmail, firstPassword);
			MainPageGMail mainPageGMail = new MainPageGMail(driver);
			var letter = mainPageGMail.OpenPageLetterGMail();
			letter.CreateNewLetterAndSend(secondEmail, termLetter, textLetter);

			Thread.Sleep(100);

			var homePageHotMail = new HomePageHotmail(driver);
			var loginPageHotMail = homePageHotMail.OpenLoginPage();
			loginPageHotMail.InputEmailInLogin(secondEmail);
			loginPageHotMail.InputPasswordInLogin(secondPassword);

			MainPageHotmail mainPageHotmail = new MainPageHotmail(driver);
			var letterAnswer = mainPageHotmail.OpenNewUnreadLetterFrom();
			letterAnswer.AnswerLetter(textAnswerLetter);
			Thread.Sleep(100);
			
			HomePageGMail homeGMail = new HomePageGMail(driver);
			LoginPageGMail loginPageGmail = homeGMail.OpenLoginPage();
			loginPageGmail.Login(firstEmail, firstPassword);
			MainPageGMail mainPageGmail = new MainPageGMail(driver);
			mainPageGmail.OpenFirstLetter();
			var newNick = mainPageGmail.GetTextDraftLetter();
			driver.Close();
			Assert.AreEqual(textAnswerLetter, newNick);
		}

		[TestMethod]
		[DataRow("viktoriyaselenium", "123Viktoriya321",
			"viktoriyaselenium@outlook.com", "123Viktoriya321", "Hi", "Do you need new NikName?", "bylochka")]
		public void CheckGetLetterChangeNikDMail(string firstEmail, string firstPassword,
									string secondEmail, string secondPassord,
									string termLetter, string textLetter,
									string textAnswerLetter)
		{
			HomePageGMail homeGmail = new HomePageGMail(driver);
			LoginPageGMail loginPageGmail = homeGmail.OpenLoginPage();
			loginPageGmail.Login(firstEmail, firstPassword);
			MainPageGMail mainPageDmail = new MainPageGMail(driver);
			var letter = mainPageDmail.OpenPageLetterGMail();
			letter.CreateNewLetterAndSend(secondEmail, termLetter, textLetter);

			Thread.Sleep(1000);
			var homePageHotmail = new HomePageHotmail(driver);
			var loginPageHotmail = homePageHotmail.OpenLoginPage();
			loginPageHotmail.InputEmailInLogin(secondEmail);
			loginPageHotmail.InputPasswordInLogin(secondPassord);
			MainPageHotmail mainPageHotmail = new MainPageHotmail(driver);
			var lett = mainPageHotmail.OpenNewUnreadLetterFrom();
			lett.AnswerLetter(textAnswerLetter);

			Thread.Sleep(1000);
			HomePageGMail homeGMail = new HomePageGMail(driver);
			LoginPageGMail loginPageGMail = homeGMail.OpenLoginPage();
			loginPageGMail.Login(firstEmail, firstPassword);
			MainPageGMail mainPageGMail = new MainPageGMail(driver);
			mainPageGMail.OpenFirstLetter();
			var newNik = mainPageGMail.GetTextDraftLetter();
			mainPageGMail.SwithToFrame();
			var frame = new AccountFrameGmail(driver);
			var setting = frame.OpenAccountManagement();
			var persinfo = setting.OpenPersonalInfo();
			persinfo.ChangeNik(newNik);

			persinfo.ReturnToAccountSetting();
			var actualNik = setting.GetNik();

			Assert.IsTrue(actualNik.Contains($"({textAnswerLetter})"));

		}
	}
}