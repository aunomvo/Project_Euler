using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Problem007
{
    /// <summary>
    /// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can 
    /// see that the 6th prime is 13.
    ///
    /// What is the 10001st prime number?
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
            var primes = new List<int> {2, 3, 5, 7, 11, 13};
            for (var i = 15; primes.Count < 10001; i += 2)
            {
                var i1 = i;
                if(primes.TrueForAll(x => i1%x != 0))
                    primes.Add(i1);
            }
            return primes.Max();
        }
    }
}
