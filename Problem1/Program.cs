using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Problem1
{
    /// <summary>
    /// If we list all the natural numbers below 10 that are multiples of 3 or 
    /// 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    /// 
    /// Find the sum of all the multiples of 3 or 5 below 1000.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = Enumerable.Range(1, 999).Where(x => x%3 == 0 || x%5 == 0).Sum(x => x);
            stopwatch.Stop();
            Console.WriteLine(string.Format("The result is {0}.", result));
            Console.WriteLine(string.Format("The calculation took {0} ms.", stopwatch.ElapsedMilliseconds));
            Console.WriteLine(string.Empty);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }
    }
}
