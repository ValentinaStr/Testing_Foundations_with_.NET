using EmailWebDriver.MailMicrosoft;
using EmailWebDriver.GMail;
using EmailWebDriver.Model;
using EmailWebDriver.Service;

namespace TestEmails
{
	[TestClass]
	public class SendLetterTest : BaseTest
	{
		/*private User userGmail = UserCreator.CreateUsers("ResourceGmail");
		private User userHotmail = UserCreator.CreateUsers("ResourceHotmail");
		private Letter letter = LetterCreator.CreateLetter();
		private Letter ansverLetter = LetterCreator.CreateAnswerLetter();

		[TestMethod]
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
			var unreadLetter = mainPageHotmail.newLetter.Displayed;

			var letterNew = mainPageHotmail.OpenNewUnreadLetterFrom();
			var textGetLetter = letterNew.GetNewLetterText();

			Assert.IsTrue(unreadLetter);
			Assert.AreEqual(letter.Text, textGetLetter);
		}

		[TestMethod]
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

			Assert.AreEqual(ansverLetter.Text, newLetterText);
		}

		[TestMethod]
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
		}*/
	}
}