using System;

namespace XUnitFramework
{
	public class WasRun : TestCase
	{
		public bool MethodWasRun { get; private set; }
		public string Log { get; private set; }

		public WasRun(string name)
			:base(name)
		{
			Log = "";
		}

		public override void SetUp()
		{
			MethodWasRun = false;
			Log = "SetUp";
		}

		public void TestMethod()
		{
			MethodWasRun = true;
			Log += "TestMethod";
		}

		public void TestBrokenMethod()
		{
			throw new Exception();
		}

		public override void TearDown()
		{
			Log += "TearDown";
		}
	}
}
