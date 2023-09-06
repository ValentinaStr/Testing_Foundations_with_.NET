using OpenQA.Selenium;

namespace EmailWebDriver.GMail
{
	public class PersonalInfoGmail : BasePage
	{
		private readonly By profileNameLocator = By.XPath("//div[@id='c13']");
		private readonly By changeLocator = By.XPath("//button[@class='VfPpkd-Bz112c-LgbsSe yHy1rc eT1oJ mN1ivc P9Zld']");
		private readonly By changeNikLocator = By.XPath("//input[@class='VfPpkd-fmcmS-wGMbrd CtvUB']");
		private readonly By enterNewNikLocator = By.XPath("//button[@class='VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc LQeN7 wMI9H']");
		private readonly By accountSetting = By.XPath("//a[@id='sdgBod']");
		public PersonalInfoGmail(WebDriver driver) : base(driver)
		{
		}

		public void ChangeNik(string newNik)
		{
			FindElementWithWaiter(profileNameLocator).Click();
			FindElementsWithWaiter(changeLocator)[1].Click();
			FindElementWithWaiter(changeNikLocator).Clear();
			FindElementWithWaiter(changeNikLocator).SendKeys(newNik);
			FindElementWithWaiter(enterNewNikLocator).Click();
		}

		public void ReturnToAccountSetting()
		{
			FindElementWithWaiter(accountSetting).Click();
		}
	}
}