using System;
using System.Collections.Generic;
using System.Linq;

namespace XUnitFramework
{
	public class TestSuite
	{
		public List<TestCase> Tests { get; private set; }

		public TestSuite()
		{
			Tests = new List<TestCase>();
		}

		public void Add(TestCase testCase)
		{
			Tests.Add(testCase);
		}

		public void CreateTestSuiteFor(Type testCaseType)
		{
			var testMethodsNames = GetTestMethodsNames(testCaseType);
			foreach (var testMethodName in testMethodsNames)
			{
				var ctor = testCaseType.GetConstructor(new Type[] { typeof(string) });
				var testCase = (TestCase)ctor.Invoke(new object[] { testMethodName });

				Tests.Add(testCase);
			}
		}

		public void Run(TestResult result)
		{
			foreach (var testCase in Tests)
				testCase.Run(result);
		}

		public bool IsTestMethod(string methodName)
		{
			return methodName.StartsWith("Test");
		}

		public List<string> GetTestMethodsNames(Type testCaseType)
		{
			var methodsNames = GetAllMethodsNames(testCaseType);

			return methodsNames.Where(IsTestMethod).ToList();
		}

		private IEnumerable<string> GetAllMethodsNames(Type testCaseType)
		{
			var methodsInfos = testCaseType.GetMethods();

			return methodsInfos.Select(methodInfo => methodInfo.Name).ToList();
		}
	}
}
