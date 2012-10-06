using XUnitFramework;

namespace XUnitFrameWork.Test.Console
{
	public class DummyTestCase : TestCase
	{
		public DummyTestCase(string name)
			: base(name)
		{ }

		public override void SetUp()
		{ }

		public void TestFirst()
		{ }

		public void TestSecond()
		{ }

		public void NotTestMethod()
		{ }

		public override void TearDown()
		{ }
	}
}
