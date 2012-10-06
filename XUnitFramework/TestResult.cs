namespace XUnitFramework
{
	public class TestResult
	{
		private int _runCount;
		private int _errorCount;

		public TestResult()
		{
			_runCount = 0;
			_errorCount = 0;
		}

		public void TestStarted()
		{
			_runCount++;
		}

		public void TestFailed()
		{
			_errorCount++;
		}

		public string Summary()
		{
			return string.Format("{0} run, {1} failed", _runCount, _errorCount);
		}
	}
}
