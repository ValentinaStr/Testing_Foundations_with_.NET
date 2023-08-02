using Dev_and_Build_Tools;

namespace Test_Dev_and_Build_Tools
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void CheckEmptyStirng()
		{
			string text = "";
			Assert.AreEqual(0, CheckText.GetLenghtUnequalConsecutiveCharacters(text));
		}

		[TestMethod]
		public void CheckStirngWithOneLetter()
		{
			string text = "a";
			Assert.AreEqual(1, CheckText.GetLenghtUnequalConsecutiveCharacters(text));
		}

		[TestMethod]
		public void CheckStirngLongtAtTheBeginning()
		{
			string text = "asdffg";
			Assert.AreEqual(4, CheckText.GetLenghtUnequalConsecutiveCharacters(text));
		}

		[TestMethod]
		public void CheckStirngrlongAtTheEnd()
		{
			string text = "asdffgwsedr";
			Assert.AreEqual(7, CheckText.GetLenghtUnequalConsecutiveCharacters(text));
		}

		[TestMethod]
		public void CheckStirngWithDifferentCharacters()
		{
			string text = "1234567890";
			Assert.AreEqual(text.Length, CheckText.GetLenghtUnequalConsecutiveCharacters(text));
		}

		[TestMethod]
		public void CheckStirngWithTheEqualCharacters()
		{
			string text = "111111111";
			Assert.AreEqual(1, CheckText.GetLenghtUnequalConsecutiveCharacters(text));
		}
	}
}