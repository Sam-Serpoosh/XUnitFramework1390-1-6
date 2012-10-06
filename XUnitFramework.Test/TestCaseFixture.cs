using NUnit.Framework;

namespace XUnitFramework.Test
{
	[TestFixture]
	public class TestCaseFixture
	{
		[Test]
		public void TestRunning()
		{
			var test = new WasRun("TestMethod");
			test.Run();
			Assert.IsTrue(test.MethodWasRun);
		}

		[Test]
		public void TestSetUp()
		{
			var test = new WasRun("TestMethod");
			test.Run();
			Assert.IsTrue(test.WasSetUp);
		}
	}
}
