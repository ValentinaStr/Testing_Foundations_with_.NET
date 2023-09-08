using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace EmailWebDriver
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
						driver = new ChromeDriver();
						driver.Manage().Window.Maximize();
						break;
					case "Firefox":
						driver = new FirefoxDriver();
						driver.Manage().Window.Maximize();
						break;
					default:
						driver = new ChromeDriver();
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