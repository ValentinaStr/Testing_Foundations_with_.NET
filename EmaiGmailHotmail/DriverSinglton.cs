using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace EmaiGmailHotmail
{
	public class DriverSinglton
	{
		private static WebDriver driver;

		private DriverSinglton() { }

		public static WebDriver GetDriver(string browserName)
		{
			if (driver == null)
			{
				switch (browserName)
				{
					case "Chrome":
						new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
						driver = new ChromeDriver();
						driver.Manage().Window.Maximize();
						break;
					case "Firefox":
						new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
						driver = new FirefoxDriver();
						driver.Manage().Window.Maximize();
						break;
					case "Edge":
						new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
						driver = new EdgeDriver();
						driver.Manage().Window.Maximize();
						break;
					default:
						new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
						driver = new ChromeDriver();
						driver.Manage().Window.Maximize();
						break;
				}
			}
			return driver;
		}

		public static void ClosedDriver()
		{
			driver.Quit();
			driver = null;
		}
	}
}