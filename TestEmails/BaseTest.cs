using OpenQA.Selenium;
using EmailWebDriver;

namespace TestEmails
{
	public abstract class BaseTest
	{
		protected WebDriver driver;
		
		[TestInitialize]
		public void BeforeTestOnChrome()
		{
			driver = DriverSinglton.GetDriver("Chrome");
		}

		[TestCleanup]
		public void ClassCleanup()
		{
			DriverSinglton.ClosedDriver();
		}
	}
}