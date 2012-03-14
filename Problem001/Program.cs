using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problem001
{
    /// <summary>
    /// If we list all the natural numbers below 10 that are multiples of 3 or 
    /// 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    /// 
    /// Find the sum of all the multiples of 3 or 5 below 1000.
    /// </summary>
    static class Program
    {
        static void Main()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var result = SolveProblem(1000);
            stopwatch.Stop();

            Console.WriteLine(string.Format("The result is {0}.", result));
            Console.WriteLine(string.Format("The calculation took {0} ms.", stopwatch.ElapsedMilliseconds));
            Console.WriteLine(string.Empty);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }

        internal static int SolveProblem(int max)
        {
            return Enumerable.Range(1, max - 1).Where(x => x%3 == 0 || x%5 == 0).Sum();
        }
    }

    [TestClass]
    public class TestProblem001
    {
        [TestMethod]
        public void TestSolveProblemEasy()
        {
            Assert.AreEqual(23, Program.SolveProblem(10));
        }

        [TestMethod]
        public void TestSolveProblemFull()
        {
            Assert.AreEqual(233168, Program.SolveProblem(1000));
        }
    }
}
