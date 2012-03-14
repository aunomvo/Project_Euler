using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problem004
{
    /// <summary>
    /// A palindromic number reads the same both ways. The largest palindrome 
    /// made from the product of two 2-digit numbers is 9009 = 91  99.
    ///
    /// Find the largest palindrome made from the product of two 3-digit numbers
    /// </summary>
    static class Program
    {
        static void Main()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var result = SolveProblem(3);
            stopwatch.Stop();

            Console.WriteLine(string.Format("The result is {0}.", result));
            Console.WriteLine(string.Format("The calculation took {0} ms.", stopwatch.ElapsedMilliseconds));
            Console.WriteLine(string.Empty);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }

        internal static int SolveProblem(int digits)
        {
            var result = 0;

            var max = 9;
            for (var i = 1; i < digits; i++ )
            {
                max *= 10;
                max += 9;
            }

            var min = 9;
            for (var i = 1; i < digits - 1; i++)
            {
                min *= 10;
                min += 9;
            }

            for (var x = max; x > min; x--)
            {
                for (var y = max; y > min; y--)
                {
                    var temp = x * y;
                    var tempstr = temp.ToString();
                    if (tempstr.Substring(0, tempstr.Length / 2) != new string(tempstr.Reverse().ToArray()).Substring(0, tempstr.Length / 2))
                        continue; //not palindrome
                    if (temp > result)
                        result = temp;
                }
            }

            return result;
        }
    }

    [TestClass]
    public class TestProblem001
    {
        [TestMethod]
        public void TestSolveProblemEasy()
        {
            Assert.AreEqual(9009, Program.SolveProblem(2));
        }

        [TestMethod]
        public void TestSolveProblemFull()
        {
            Assert.AreEqual(906609, Program.SolveProblem(3));
        }
    }
}
