using System;
using XUnitFramework;

namespace XUnitFrameWork.Test.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			//RunTest("TestTemplateMethod");
			//RunTest("TestResult");
			//RunTest("TestFailedResult");
			//RunTest("TestFailedResultFormatting");
			//RunTest("TestSuite");

			//RunTestSuite();

			RunTestSuiteWhichCreatedFromTestCaseClass();
		}

		static void RunTestSuiteWhichCreatedFromTestCaseClass()
		{
			var suite = new TestSuite();
			suite.CreateTestSuiteFor(typeof(TestCaseFixture));
			var result = new TestResult();
			suite.Run(result);

			System.Console.WriteLine(result.Summary());
		}

		static void RunTestSuite()
		{
			var suite = new TestSuite();
			suite.Add(new TestCaseFixture("TestTemplateMethod"));
			suite.Add(new TestCaseFixture("TestResult"));
			suite.Add(new TestCaseFixture("TestFailedResult"));
			suite.Add(new TestCaseFixture("TestFailedResultFormatting"));
			suite.Add(new TestCaseFixture("TestSuite"));
			suite.Add(new TestCaseFixture("TestDetectingWhetherMethodIsTestOrNot"));
			suite.Add(new TestCaseFixture("TestGettingTestMethodsOfTestCaseClass"));
			suite.Add(new TestCaseFixture("TestCreatingTestSuiteForTestCase"));
			var result = new TestResult();
			suite.Run(result);

			System.Console.WriteLine(result.Summary());
		}

		static void RunTest(string testName)
		{
			var testCase = new TestCaseFixture(testName);
			var testResult = new TestResult();
			testCase.Run(testResult);
			System.Console.WriteLine(testResult.Summary());
		}
	}
}
