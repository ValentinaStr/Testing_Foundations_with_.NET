﻿using OpenQA.Selenium;
//using SeleniumExtras.WaitHelpers;

namespace EmailWebDriver.GMail
{
	public class LetterGMail : BasePage
	{ 
		private readonly By newLetterAddressLocator = By.XPath("//input[@peoplekit-id='BbVjBd']");
		private readonly By newLetterTermLocator = By.XPath("//input[@name='subjectbox']");
		private readonly By newLetterTextLocator = By.XPath("//div[@class='Am Al editable LW-avf tS-tW']");
		private readonly By sendNewLetterLocator = By.XPath("//td[@class='gU Up']");
		public LetterGMail(WebDriver driver) : base(driver)
		{
		}
		public void CreateNewLetterAndSend(string adress, string term, string text)
		{
			InputNewLetterAddress(adress);
			InputNewLetterTerm(term);
			InputTextNewLetter(text);
			SendNewLetter();
		}

		public void CreateNewLetter(string adress, string term, string text)
		{
			InputNewLetterAddress(adress);
			InputNewLetterTerm(term);
			InputTextNewLetter(text);
		}

		public void InputNewLetterAddress(string address)
		{
			FindElementWithWaiter(newLetterAddressLocator).SendKeys(address);
		}
		public void InputNewLetterTerm(string term)
		{
			FindElementWithWaiter(newLetterTermLocator).SendKeys(term);
		}
		public void InputTextNewLetter(string text)
		{
			FindElementWithWaiter(newLetterTextLocator).SendKeys(text);
		}
		public void SendNewLetter()
		{
			FindElementWithWaiter(sendNewLetterLocator).Click();
			By nameLocator = By.Id("link_undo");
			WeitInvisibility(nameLocator);
			FindElementWithWaiter(By.XPath("//div[@class='bBe']")).Click();
		}
	}
}