using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace EmailWebDriver.GMail
{
	public class HomePageGMail : BasePage
	{
		[FindsBy(How = How.XPath, Using = "//a[@data-action='sign in']")]
		public readonly IWebElement loginPage;

		//private readonly By loginPageLocator = By.XPath("//a[@data-action='sign in']");


		public HomePageGMail(WebDriver driver) : base(driver)
		{
			driver.Url = "https://www.google.com/intl/ru/gmail/about/";
		}

		public LoginPageGMail OpenLoginPage()
		{
			loginPage.Click();
			return new LoginPageGMail(driver);
		}
	}
}