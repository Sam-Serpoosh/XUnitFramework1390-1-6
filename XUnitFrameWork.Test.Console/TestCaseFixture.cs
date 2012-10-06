using NUnit.Framework;
using XUnitFramework;
using TestCase = XUnitFramework.TestCase;

namespace XUnitFrameWork.Test.Console
{
	public class TestCaseFixture : TestCase
	{
		private TestResult _result;

		public TestCaseFixture(string name)
			: base(name)
		{ }

		public override void SetUp()
		{
			_result = new TestResult();
		}

		public void TestTemplateMethod()
		{
			var test = new WasRun("TestMethod");
			test.Run(_result);
			Assert.AreEqual("SetUpTestMethodTearDown", test.Log);
		}

		public void TestResult()
		{
			var test = new WasRun("TestMethod");
			test.Run(_result);
			Assert.AreEqual("1 run, 0 failed", _result.Summary());
		}

		public void TestFailedResult()
		{
			var test = new WasRun("TestBrokenMethod");
			test.Run(_result);
			Assert.AreEqual("1 run, 1 failed", _result.Summary());
		}

		public void TestFailedResultFormatting()
		{
			_result.TestStarted();
			_result.TestFailed();
			Assert.AreEqual("1 run, 1 failed", _result.Summary());
		}

		public void TestSuite()
		{
			var suite = new TestSuite();
			suite.Add(new WasRun("TestMethod"));
			suite.Add(new WasRun("TestBrokenMethod"));
			suite.Run(_result);
			Assert.AreEqual("2 run, 1 failed", _result.Summary());
		}

		public void TestDetectingWhetherMethodIsTestOrNot()
		{
			var suite = new TestSuite();
			var notTestMethodName = "ThisIsNotTestMethod";
			Assert.IsFalse(suite.IsTestMethod(notTestMethodName));

			var testMethodName = "TestMethod";
			Assert.IsTrue(suite.IsTestMethod(testMethodName));
		}

		public void TestGettingTestMethodsOfTestCaseClass()
		{
			var suite = new TestSuite();
			var testMethodNames = suite.GetTestMethodsNames(typeof(DummyTestCase));

			Assert.AreEqual(2, testMethodNames.Count);
			Assert.IsTrue(testMethodNames.Contains("TestFirst"));
			Assert.IsTrue(testMethodNames.Contains("TestSecond"));
		}

		public void TestCreatingTestSuiteForTestCase()
		{
			var suite = new TestSuite();
			suite.CreateTestSuiteFor(typeof(DummyTestCase));

			Assert.AreEqual(2, suite.Tests.Count);
		}

		public override void TearDown()
		{ }
	}
}
