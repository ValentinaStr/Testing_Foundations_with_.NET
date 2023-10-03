using NUnit.Framework.Internal;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using EmaiGmailHotmail;
using EmaiGmailHotmail.Util;

namespace TaskWebDriver
{
	[TestFixture]
	public abstract class BaseTest
	{
		protected WebDriver driver;
		protected TestLogger logger;
		protected string screenshotPath;
		
		[SetUp]
		public void BeforeTest()
		{
			driver = DriverSinglton.GetDriver(Environment.GetEnvironmentVariable("Browser")); //"Chrome" , "Firefox" , "Edge"
			screenshotPath = Path.Combine(Environment.GetEnvironmentVariable("WorkSpase") ?? AppDomain.CurrentDomain.BaseDirectory,
										$"{DateTime.Now:yyyyMMdd-HHmmss}.png");
			logger = new TestLogger();
		}

		[TearDown]
		public void ClassCleanup()
		{
			if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
			{
				driver.GetScreenshot().SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
				logger.LogError(TestContext.CurrentContext.Test.FullName + " / Failed");
			}
			else
			{
				logger.LogInfo(TestContext.CurrentContext.Test.FullName + " / Passed");
			}

			DriverSinglton.ClosedDriver();
			driver.Dispose();
		}
	}
}