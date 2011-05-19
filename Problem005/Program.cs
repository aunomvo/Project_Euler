using System;
using System.Diagnostics;

namespace Problem005
{
    /// <summary>
    /// 2520 is the smallest number that can be divided by each of the numbers 
    /// from 1 to 10 without any remainder.
    ///
    /// What is the smallest positive number that is evenly divisible by all of
    /// the numbers from 1 to 20?
    /// </summary>
    class Program
    {
        static void Main()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var result = SolveProblem();
            stopwatch.Stop();

            Console.WriteLine(string.Format("The result is {0}.", result));
            Console.WriteLine(string.Format("The calculation took {0} ms.", stopwatch.ElapsedMilliseconds));
            Console.WriteLine(string.Empty);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }

        private static int SolveProblem()
        {
            //from primes and perfect power numbers (e.g. x^n) in the range of 1 to 20
            return 2*2*2*2*3*3*5*7*11*13*17*19;
        }
    }
}