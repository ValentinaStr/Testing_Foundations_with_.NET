using OpenQA.Selenium;

namespace WebDriverEmail.GMail
{
	public class AccountSettingsGmail : BasePage
	{
		private readonly By perconalInfoLocator = By.XPath("//a[@href='personal-info']");
		private readonly By getNameAndNikLocator = By.XPath("//h1[@class='XY0ASe']");

		public AccountSettingsGmail(WebDriver driver) : base(driver)
		{

		}

		public PersonalInfoGmail OpenPersonalInfo()
		{
			FindElementsWithWaiter(perconalInfoLocator)[1].Click();
			return new PersonalInfoGmail(driver);
		}

		public string GetNik()
		{
			return FindElementsWithWaiter(getNameAndNikLocator)[0].Text;
		}

	}
}