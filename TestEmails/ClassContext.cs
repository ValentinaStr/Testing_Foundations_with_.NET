using OpenQA.Selenium;

namespace TestEmails
{
	public class ClassContext
	{
		private TestContext testContext;

		public TestContext TestContext
		{
			get { return testContext; }
			set { testContext = value; }
		}

		public void GetScreenshot(WebDriver driver)
		{
			string testTime = DateTime.Now.ToString("yyyyMMdd-HHmmss");
			string screenshotName = "FailedTest_" + testTime + ".Jpeg";
			string screenshotPath = Path.Combine(TestContext.TestResultsDirectory, screenshotName);
			Screenshot TakeScreenshot = driver.GetScreenshot();
			TakeScreenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Jpeg);
		}
	}
}