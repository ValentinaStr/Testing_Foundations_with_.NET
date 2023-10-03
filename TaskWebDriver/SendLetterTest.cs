using EmaiGmailHotmail.Model;
using EmaiGmailHotmail.GMail;
using EmaiGmailHotmail.Service;
using EmaiGmailHotmail.MailMicrosoft;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace TaskWebDriver
{
	[TestFixture]
	public class SendLetterTest : BaseTest
	{
		private User userGmail = UserCreator.CreateUsers("ResourceGmail");
		private User userHotmail = UserCreator.CreateUsers("ResourceHotmail");
		private Letter letter = LetterCreator.CreateLetter();
		private Letter ansverLetter = LetterCreator.CreateAnswerLetter();

		[Category("Send Letter")]
		[TestCase(TestName = "Check Get Letter")]
		public void CheckGetLetter()
		{
			var homePageGmail = new HomePageGMail(driver);
			var loginPageGmail = homePageGmail.OpenLoginPage();
			var mainPage = loginPageGmail.Login(userGmail);
			var newLetter = mainPage.OpenNewLetterToCreate();
			newLetter.CreateNewLetterAndSend(userHotmail, letter);

			var homePageHotmail = new HomePageHotmail(driver);
			var loginPageHotmail = homePageHotmail.OpenLoginPage();
			var mainPageHotmail = loginPageHotmail.Login(userHotmail);

			var letterNew = mainPageHotmail.OpenNewUnreadLetterFrom();
			var textGetLetter = letterNew.GetNewLetterText();

			Assert.That(letter.Text, Is.EqualTo(textGetLetter));
		}

		[Test]
		[Category("Send Letter")]
		public void CheckGetAnswerLetter()
		{
			var homePageGmail = new HomePageGMail(driver);
			var loginPageGmail = homePageGmail.OpenLoginPage();
			var mainPage = loginPageGmail.Login(userGmail);
			var newLetter = mainPage.OpenNewLetterToCreate();
			newLetter.CreateNewLetterAndSend(userHotmail, letter);

			var homePageHotmail = new HomePageHotmail(driver);
			var loginPageHotmail = homePageHotmail.OpenLoginPage();
			var mainPageHotmail = loginPageHotmail.Login(userHotmail);
			Thread.Sleep(1000);
			var newUnreadLetter = mainPageHotmail.OpenNewUnreadLetterFrom();
			newUnreadLetter.AnswerLetter(ansverLetter);

			var homePageGmailAnswer = new HomePageGMail(driver);
			var loginPageGmailAnswer = homePageGmailAnswer.OpenLoginPage();
			var mainPageAnswer = loginPageGmailAnswer.Login(userGmail);

			mainPageAnswer.OpenFirstIncomingLetter();
			var newLetterText = mainPageAnswer.GetTextDraftLetter();

			Assert.That(newLetterText, Is.EqualTo(ansverLetter.Text));
		}

		[Category("Send Letter")]
		[TestCase(TestName = "Check Get Letter Change NikMail")]
		public void CheckGetLetterChangeNikMail()
		{
			var homePageGmail = new HomePageGMail(driver);
			var loginPageGmail = homePageGmail.OpenLoginPage();
			var mainPage = loginPageGmail.Login(userGmail);
			var newLetter = mainPage.OpenNewLetterToCreate();
			newLetter.CreateNewLetterAndSend(userHotmail, letter);

			var homePageHotmail = new HomePageHotmail(driver);
			var loginPageHotmail = homePageHotmail.OpenLoginPage();
			var mainPageHotmail = loginPageHotmail.Login(userHotmail);
			Thread.Sleep(1000);
			var newUnreadLetter = mainPageHotmail.OpenNewUnreadLetterFrom();
			newUnreadLetter.AnswerLetter(ansverLetter);

			var homePageGmailAnswer = new HomePageGMail(driver);
			var loginPageGmailAnswer = homePageGmailAnswer.OpenLoginPage();
			var mainPageAnswer = loginPageGmailAnswer.Login(userGmail);

			mainPageAnswer.OpenFirstIncomingLetter();
			Thread.Sleep(1000);
			var newNick = mainPageAnswer.GetTextDraftLetter();
			var accountFrame = mainPageAnswer.SwithToAccountFrame();

			var accountSetting = accountFrame.OpenAccountManagement();
			var persinfo = accountSetting.OpenPersonalInfo();
			persinfo.ChangeNik(newNick);

			persinfo.ReturnToAccountSetting();

			driver.Navigate().Refresh();
			var actualNik = accountSetting.GetNik();

			Assert.IsTrue(actualNik.Contains($"({ansverLetter.Text})"));
		}
	}
}