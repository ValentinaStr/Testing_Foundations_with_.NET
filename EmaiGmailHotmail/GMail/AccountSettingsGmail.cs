using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EmaiGmailHotmail.GMail
{
	public class AccountSettingsGmail : BasePage
	{
		[FindsBy(How = How.XPath, Using = "//a[@href='personal-info']/descendant::div[@class='GiKO7c']")] 
		public readonly IWebElement perconalInfo;

		[FindsBy(How = How.XPath, Using = "//h1[@class='XY0ASe']")]
		public readonly IWebElement getNameAndNik;

		public AccountSettingsGmail(WebDriver driver) : base(driver)
		{
			PageFactory.InitElements(driver, this);
		}

		public PersonalInfoGmail OpenPersonalInfo()
		{
			ClickElementWithWaiter(perconalInfo);
			return new PersonalInfoGmail(driver);
		}

		public string GetNik()
		{
			return GetTextFromElementWithWaiter(getNameAndNik);
		}
	}
}