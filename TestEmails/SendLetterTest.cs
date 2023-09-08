using EmailWebDriver.MailMicrosoft;
using EmailWebDriver.GMail;

namespace TestEmails
{
	[TestClass]
	public class SendLetterTest : BaseTest
	{
		[TestMethod]
		[DataRow("viktoriyaselenium", "123Viktoriya321",
				"viktoriyaselenium@outlook.com", "123Viktoriya321",
				"Hi from me", "Do you want new NikName?")]
		public void CheckGetLetter(string firstEmail, string firstPassword,
									string secondEmail, string secondPassword,
									string termLetter, string textLetter)
		{
			var homePageGmail = new HomePageGMail(driver);
			var loginPageGmail = homePageGmail.OpenLoginPage();
			var mainPage = loginPageGmail.Login(firstEmail, firstPassword);
			var newLetter = mainPage.OpenNewLetterToCreate();
			newLetter.CreateNewLetterAndSend(secondEmail, termLetter, textLetter);

			var homePageHotmail = new HomePageHotmail(driver);
			var loginPageHotmail = homePageHotmail.OpenLoginPage();
			var mainPageHotmail = loginPageHotmail.Login(secondEmail, secondPassword);
			var unreadLetter = mainPageHotmail.newLetter.Displayed;

			var letterNew = mainPageHotmail.OpenNewUnreadLetterFrom();
			var textGetLetter = letterNew.GetNewLetterText();

			Assert.IsTrue(unreadLetter);
			Assert.AreEqual(textLetter, textGetLetter);
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
			var homePageGmail = new HomePageGMail(driver);
			var loginPageGmail = homePageGmail.OpenLoginPage();
			var mainPage = loginPageGmail.Login(firstEmail, firstPassword);
			var newLetter = mainPage.OpenNewLetterToCreate();
			newLetter.CreateNewLetterAndSend(secondEmail, termLetter, textLetter);

			var homePageHotmail = new HomePageHotmail(driver);
			var loginPageHotmail = homePageHotmail.OpenLoginPage();
			var mainPageHotmail = loginPageHotmail.Login(secondEmail, secondPassword);

			var newUnreadLetter = mainPageHotmail.OpenNewUnreadLetterFrom();
			newUnreadLetter.AnswerLetter(textAnswerLetter);

			var homePageGmailAnswer = new HomePageGMail(driver);
			var loginPageGmailAnswer = homePageGmailAnswer.OpenLoginPage();
			var mainPageAnswer = loginPageGmailAnswer.Login(firstEmail, firstPassword);

			mainPageAnswer.OpenFirstIncomingLetter();
			var newNick = mainPageAnswer.GetTextDraftLetter();

			Assert.AreEqual(textAnswerLetter, newNick);
		}

		[TestMethod]
		[DataRow("viktoriyaselenium", "123Viktoriya321",
				"viktoriyaselenium@outlook.com", "123Viktoriya321", "Hi", "Do you need new NikName?", "bylochka")]
		public void CheckGetLetterChangeNikMail(string firstEmail, string firstPassword,
										string secondEmail, string secondPassword,
										string termLetter, string textLetter,
										string textAnswerLetter)
		{
			var homePageGmail = new HomePageGMail(driver);
			var loginPageGmail = homePageGmail.OpenLoginPage();
			var mainPage = loginPageGmail.Login(firstEmail, firstPassword);
			var newLetter = mainPage.OpenNewLetterToCreate();
			newLetter.CreateNewLetterAndSend(secondEmail, termLetter, textLetter);

			var homePageHotmail = new HomePageHotmail(driver);
			var loginPageHotmail = homePageHotmail.OpenLoginPage();
			var mainPageHotmail = loginPageHotmail.Login(secondEmail, secondPassword);

			var newUnreadLetter = mainPageHotmail.OpenNewUnreadLetterFrom();
			newUnreadLetter.AnswerLetter(textAnswerLetter);

			var homePageGmailAnswer = new HomePageGMail(driver);
			var loginPageGmailAnswer = homePageGmailAnswer.OpenLoginPage();
			var mainPageAnswer = loginPageGmailAnswer.Login(firstEmail, firstPassword);

			mainPageAnswer.OpenFirstIncomingLetter();
			var newNick = mainPageAnswer.GetTextDraftLetter();
			var accountFrame = mainPageAnswer.SwithToAccountFrame();

			var accountSetting = accountFrame.OpenAccountManagement();
			var persinfo = accountSetting.OpenPersonalInfo();
			persinfo.ChangeNik(newNick);

			persinfo.ReturnToAccountSetting();

			driver.Navigate().Refresh();
			var actualNik = accountSetting.GetNik();

			Assert.IsTrue(actualNik.Contains($"({textAnswerLetter})"));
		}

	}
}