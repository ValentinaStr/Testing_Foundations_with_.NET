using BasicOf.NET;

namespace Tests_Basic_of_.NET_and_C_
{
	[TestClass]
	public class UnitTest1
	{
		[TestInitialize]
		public void TestInitialize()
		{
			NumberConversion.Resalt = "";
		}

		[TestMethod]
		public void ConvertToBinary()
		{
			Assert.AreEqual("11010", NumberConversion.Conversation(26, 2));
		}

		[TestMethod]
		public void ConvertTovigesimalSystem()
		{
			Assert.AreEqual("30", NumberConversion.Conversation(60, 20));
		}

		[TestMethod]
		public void ConvertZero()
		{
			Assert.AreEqual("00", NumberConversion.Conversation(0, 8));
		}

		[TestMethod]
		public void ConvertNegativeNumber()
		{
			Assert.AreEqual("-11010", NumberConversion.Conversation(-26,2));
		}
	}
}