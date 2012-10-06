using System;

namespace XUnitFramework
{
	public abstract class TestCase
	{
		protected string Name;

		public TestCase(string name)
		{
			Name = name;
		}

		public abstract void SetUp();

		public abstract void TearDown();

		public void Run(TestResult result)
		{
			result.TestStarted();
			SetUp();
			try
			{
				var methodInfo = GetType().GetMethod(Name);
				methodInfo.Invoke(this, new object[] { });
			}
			catch (Exception)
			{
				result.TestFailed();
			}
			TearDown();
		}
	}
}
