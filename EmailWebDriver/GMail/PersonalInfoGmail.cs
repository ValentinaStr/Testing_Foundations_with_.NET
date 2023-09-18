using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EmailWebDriver.GMail
{
	public class PersonalInfoGmail : BasePage
	{
		[FindsBy(How = How.XPath, Using = "//a[contains(@href,'profile/name?continue')]")]
		public readonly IWebElement profileName;

		[FindsBy(How = How.XPath, Using = "//div[@data-index='1']/descendant::button[@class='VfPpkd-Bz112c-LgbsSe yHy1rc eT1oJ mN1ivc P9Zld']")]
		public readonly IWebElement change;

		[FindsBy(How = How.XPath, Using = "//input[@class='VfPpkd-fmcmS-wGMbrd CtvUB']")]
		public readonly IWebElement changeNik;

		[FindsBy(How = How.XPath, Using = "//button[@class='UywwFc-LgbsSe UywwFc-LgbsSe-OWXEXe-dgl2Hf wMI9H']")]
		public readonly IWebElement enterNewNik;

		[FindsBy(How = How.XPath, Using = "//a[@id='sdgBod']")]
		public readonly IWebElement accountSetting;

		public PersonalInfoGmail(WebDriver driver) : base(driver)
		{
			PageFactory.InitElements(driver, this);
		}

		public void ChangeNik(string newNik)
		{
			ClickElementWithWaiter(profileName);
			ClickElementWithWaiter(change);
			ClearElementWithWaiter(changeNik);
			SendKeyElementWithWaiter(changeNik, newNik);
			ClickElementWithWaiter(enterNewNik);
		}

		public void ReturnToAccountSetting()
		{
			ClickElementWithWaiter(accountSetting);
		}
	}
}