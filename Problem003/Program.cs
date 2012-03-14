using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problem003
{
    /// <summary>
    /// The prime factors of 13195 are 5, 7, 13 and 29.
    ///
    /// What is the largest prime factor of the number 600851475143 ?
    /// </summary>
    static class Program
    {
        internal const ulong CompositeNum = 600851475143;

        static void Main()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var result = SolveProblem(CompositeNum);
            stopwatch.Stop();

            Console.WriteLine(string.Format("The result is {0}.", result));
            Console.WriteLine(string.Format("The calculation took {0} ms.", stopwatch.ElapsedMilliseconds));
            Console.WriteLine(string.Empty);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }

        internal static int SolveProblem(ulong compositeNum)
        {
            var temp = compositeNum;
            for(ulong i = 3; i * i < temp; i += 2)
            {
                if (temp % i == 0)
                    temp /= i;
            }

            return (int) temp;
        }
    }

    [TestClass]
    public class TestProblem001
    {
        [TestMethod]
        public void TestSolveProblemEasy()
        {
            Assert.AreEqual(29, Program.SolveProblem(13195));
        }

        [TestMethod]
        public void TestSolveProblemFull()
        {
            Assert.AreEqual(6857, Program.SolveProblem(Program.CompositeNum));
        }
    }
}
