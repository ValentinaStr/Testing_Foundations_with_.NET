using OpenQA.Selenium;
using EmailWebDriver;

namespace TestEmails
{
	public abstract class BaseTest
	{
		protected WebDriver driver;

		private TestContext testContext;

		public FileLogger logger;
		

		public TestContext TestContext
		{
			get { return testContext; }
			set { testContext = value; }
		}


		[TestInitialize]
		public void BeforeTest()
		{
			driver = DriverSinglton.GetDriver("Chrome"); //"Chrome" , "Firefox" , Edge
			logger = new FileLogger();
		}

		[TestCleanup]
		public void ClassCleanup()
		{
			if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed)
			{
				string testTime = DateTime.Now.ToString("yyyyMMdd-HHmmss");
				string screenshotName = "FailedTest_" + testTime + ".Jpeg";
				string screenshotPath = Path.Combine(TestContext.TestResultsDirectory, screenshotName);
				Screenshot TakeScreenshot = driver.GetScreenshot();
				TakeScreenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Jpeg);

				logger.LogError(testContext.TestName.ToString());
			}
			else
			{
				logger.LogInfo(testContext.TestName.ToString());
			}

			DriverSinglton.ClosedDriver();
		}
	}
}