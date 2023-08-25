using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Locators
{
	public class Program
	{
		public static void Main(string[] args)
		{
			WebDriver driver = new ChromeDriver();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
			driver.Url = "https://www.bbc.com/sport";
			driver.Manage().Window.Maximize();

			//agree to advertising cookies on frame

			driver.SwitchTo().Frame("sp_message_iframe_783538");
			driver.FindElement(By.XPath("//button[@title='I agree']")).Click();

			//agree to second cookies

			Thread.Sleep(1000);
			driver.FindElement(By.XPath("//button[text()='Yes, I agree']")).Click();

			//Open Home Page

			driver.FindElement(By.LinkText("BBC Homepage")).Click();

			//Open Search Page

			driver.FindElement(By.ClassName("ux-v5")).Click();

			//Get list of main menu

			var listLinksMenu = driver.FindElements(By.XPath("//ul[@class='ssrcss-ls269v-ChameleonGlobalNavigationLinkList-En e16i5fd20']//li[contains(@class,'GlobalNavigationProduct')]"));

			Console.WriteLine("List of main menu:");

			foreach (var item in listLinksMenu)
			{
				var te = item.Text;
				Console.WriteLine(item.Text);
			}

			//Open Sport Page

			var sportPage = listLinksMenu.Where(p => p.Text == "Sport").FirstOrDefault();
			sportPage.Click();

			//Open Weather Page

			driver.FindElement(By.LinkText("Weather")).Click();

			//Get weather for selected city

			string city = "Minsk";

			driver.FindElement(By.XPath("//input[@aria-description='Enter a city']")).SendKeys(city + Keys.Enter);
			driver.FindElement(By.XPath($"//ul[@id='location-list']//span[contains(text(),'{city}')]")).Click();

			var weatherToday = driver.FindElement(By.Id("daylink-0")).Text;
			var weatherTodayFormat = weatherToday.Replace("\n", " ").Replace('\r', ' ').Replace(',', ' ').Replace("  ", " ");

			Console.WriteLine($"The weather in {city} {weatherTodayFormat}");

			driver.Close();
		}
	}
}