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
			driver = DriverSinglton.GetDriver(Environment.GetEnvironmentVariable("Browser")); //"Chrome" , "Firefox" , Edge
			logger = new FileLogger();
		}

		[TestCleanup]
		public void ClassCleanup()
		{
			if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed)
			{
				var fileName = $"{DateTime.Now:yyyyMMdd-HHmmss}.png";
				string screenshotPath = Path.Combine("C:/ProgramData/Jenkins/.jenkins/workspace/Framework", fileName);
				driver.GetScreenshot().SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);

				logger.LogError(testContext.TestName.ToString() + " / Failed");
			}
			else
			{
				logger.LogInfo(testContext.TestName.ToString() + " / Passed");
			}

			DriverSinglton.ClosedDriver();
		}
	}
}