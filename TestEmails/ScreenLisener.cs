/*using EmailWebDriver;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace TestEmails
{
	public class ScreenLisener : ITestListener
	{
		protected WebDriver driver;
		public void TestStarted(ITest test)
		{
			driver = DriverSinglton.GetDriver("Chrome"); //"Chrome" , "Firefox" , Edge
		}

		public void TestFinished(ITestResult result)
		{
			DriverSinglton.ClosedDriver();
		}

		public void TestFailed(ITestResult result)
		{
			var fileName = $"{result.EndTime}_{DateTime.Now:yyyyMMdd-HHmmss}.jpg";
			Screenshot chot = driver.GetScreenshot();
			chot.SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
		}

		public void TestOutput(TestOutput output)
		{
			throw new NotImplementedException();
		}

		public void SendMessage(TestMessage message)
		{
			throw new NotImplementedException();
		}
	}
}*/

