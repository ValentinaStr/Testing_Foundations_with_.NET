using OpenQA.Selenium;
using EmailWebDriver;
using NUnit.Framework.Internal;
using NUnit.Framework.Interfaces;

namespace NUnitTestProject
{
	[TestFixture]
	public abstract class BaseTest 
	{
		protected WebDriver driver;
		private TestContext? testContext;
		public FileLogger logger;
		

		public TestContext TestContext
		{
			get { return testContext; }
			set { testContext = value; }
		}

		[SetUp]
		public void BeforeTest()
		{
			driver = DriverSinglton.GetDriver(Environment.GetEnvironmentVariable("Browser")); //"Chrome" , "Firefox" , Edge
			logger = new FileLogger();
		}
		

		[TearDown]
		public void ClassCleanup()
		{
			if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
			{
				var fileName = $"{DateTime.Now:yyyyMMdd-HHmmss}.png";
				string screenshotPath = Path.Combine("C:\\ProgramData\\Jenkins\\.jenkins\\workspace\\FrameworkNUnit\\RES", fileName);
				driver.GetScreenshot().SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);

				logger.LogError(TestContext.CurrentContext.Test.FullName + " / Failed");
			}
			else
			{
				logger.LogError(TestContext.CurrentContext.Test.FullName + " / Passed");
			}
			DriverSinglton.ClosedDriver();
		}
	}
}