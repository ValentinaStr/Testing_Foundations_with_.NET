using BasicOf.NET;

namespace Tests_Basic_of_.NET_and_C_
{
	[TestClass]
	public class UnitTest1
	{
		[TestInitialize]
		public void TestInitialize()
		{
			Number_conversion.Resalt = "";
		}

		[TestMethod]
		public void ConvertToBinary()
		{
			Assert.AreEqual("11010", Number_conversion.Conversation(26, 2));
		}

		[TestMethod]
		public void ConvertTovigesimalSystem()
		{
			Assert.AreEqual("30", Number_conversion.Conversation(60, 20));
		}

		[TestMethod]
		public void ConvertZero()
		{
			Assert.AreEqual("00", Number_conversion.Conversation(0, 8));
		}

		[TestMethod]
		public void ConvertNegativeNumber()
		{
			Assert.AreEqual("-11010", Number_conversion.Conversation(-26,2));
		}
	}
}