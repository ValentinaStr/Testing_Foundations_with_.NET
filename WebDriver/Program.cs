using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverEmail.MailMicrosoft;
using WebDriverEmail.GMail;

namespace WebDriverEmail
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var firstMail = "viktoriyaselenium";
			var password1 = "123Viktoriya321";
			var secondMail = "viktoriyaselenium@outlook.com";

			WebDriver driver = new ChromeDriver();
			var homePageGmail = new HomePageGMail(driver);

			LoginPageGMail loginPage001 = homePageGmail.OpenLoginPage();
			loginPage001.InputEmailInLogin(firstMail);
			loginPage001.InputPasswordInLogin(password1);

			MainPageGMail mail001 = new MainPageGMail(driver);
			var letter = mail001.OpenPageLetterGMail();
			letter.CreateNewLetterAndSend(secondMail, "vvvvv", "eeeee");
			Thread.Sleep(1000);
			//WebDriver driverM = new ChromeDriver();

			var homePage = new HomePageHotmail(driver);
			var loginPage = homePage.OpenLoginPage();
			loginPage.InputEmailInLogin(secondMail);
			loginPage.InputPasswordInLogin(password1);

			var mainPage = new MainPageHotmail(driver);
			var lett = mainPage.OpenNewUnreadLetterFrom();
			//Console.WriteLine(mainPage.CheckNewLetteText());
			lett.AnswerLetter("007");
			
			//WebDriver driver1 = new ChromeDriver();
			Thread.Sleep(1000);
			var homePageGl = new HomePageGMail(driver);

			LoginPageGMail loginPage00 = homePageGl.OpenLoginPage();
			loginPage00.InputEmailInLogin(firstMail);
			loginPage00.InputPasswordInLogin(password1);
			MainPageGMail mail00 = new MainPageGMail(driver);
			mail00.OpenFirstLetter();
			var newNik =  mail00.GetTextDraftLetter();

			mail00.SwithToFrame();
			var frame = new AccountFrameGmail(driver);
			var setting =  frame.OpenAccountManagement();
			var persinfo = setting.OpenPersonalInfo();
			persinfo.ChangeNik("d[pl");

			persinfo.ReturnToAccountSetting();
			var t = setting.GetNik();
			//Console.WriteLine(setting.GetNik());

			driver.Close();




		}
	}
}