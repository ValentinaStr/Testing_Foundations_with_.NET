using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EmailWebDriver.GMail
{
	public class AccountSettingsGmail : BasePage
	{
		[FindsBy(How = How.XPath, Using = "//a[@href='personal-info']")]
		public readonly IWebElement perconalInfo;

		[FindsBy(How = How.XPath, Using = "//h1[@class='XY0ASe']")]
		public readonly IWebElement getNameAndNik;


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