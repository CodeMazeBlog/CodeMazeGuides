using CodeMazeGuides.Sample.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMazeGuides.Sample.DelegatesTests
{
	public class FuncDelegatesTest
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void ComputeRandom()
		{
			string randomNo = FuncDelegates.computeRandom();
			Console.WriteLine(randomNo);
			Assert.True(true);
		}

		[Test]
		public void Cube()
		{
			int cubeValue = FuncDelegates.Cube(3);
		//	Console.WriteLine(randomNo);
			Assert.AreEqual(27, cubeValue);
		}

		[Test]
		public void DisplayStdInfo()
		{
			string stdInfo = FuncDelegates.displayStdInfo("Michelle Ezra", 8);
			Console.WriteLine(stdInfo);
			Assert.True(true);
		}
	}
}
