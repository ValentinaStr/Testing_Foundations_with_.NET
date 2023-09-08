﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EmailWebDriver.GMail
{
	public class LetterGMail : BasePage
	{
		[FindsBy(How = How.XPath, Using = "//input[@peoplekit-id='BbVjBd']")]
		public readonly IWebElement newLetterAddress;

		[FindsBy(How = How.XPath, Using = "//input[@name='subjectbox']")]
		public readonly IWebElement newLetterTerm;

		[FindsBy(How = How.XPath, Using = "//div[@class='Am Al editable LW-avf tS-tW']")]
		public readonly IWebElement newLetterText;

		[FindsBy(How = How.XPath, Using = "//td[@class='gU Up']")]
		public readonly IWebElement sendNewLetter;

		[FindsBy(How = How.XPath, Using = "//div[@class='bBe']")]
		public readonly IWebElement closeddDalogUnsendMail;

		public readonly By unsendMail = By.Id("link_undo");

		public LetterGMail(WebDriver driver) : base(driver)
		{
			PageFactory.InitElements(driver, this);
		}

		public void CreateNewLetterAndSend(string adress, string term, string text)
		{
			InputNewLetterAddress(adress);
			InputNewLetterTerm(term);
			InputTextNewLetter(text);
			SendNewLetter();
			CheckSendingLetter();
		}

		public void CreateNewLetter(string adress, string term, string text)
		{
			InputNewLetterAddress(adress);
			InputNewLetterTerm(term);
			InputTextNewLetter(text);
		}

		public void InputNewLetterAddress(string address)
		{
			SendKeyElementWithWaiter(newLetterAddress, address);
		}
		public void InputNewLetterTerm(string term)
		{
			SendKeyElementWithWaiter(newLetterTerm, term);
		}
		public void InputTextNewLetter(string text)
		{
			SendKeyElementWithWaiter(newLetterText, text);
		}
		public void SendNewLetter()
		{
			ClickElementWithWaiter(sendNewLetter);
		}
		public void CheckSendingLetter()
		{
			WeitInvisibility(unsendMail);
			ClickElementWithWaiter(closeddDalogUnsendMail);
		}
	}
}