using System;
using System.Diagnostics;
using System.Linq;

namespace Problem006
{
    /// <summary>
    /// The sum of the squares of the first ten natural numbers is,
    ///    1^2 + 2^2 + ... + 10^2 = 385
    /// The square of the sum of the first ten natural numbers is,
    ///    (1 + 2 + ... + 10)^2 = 55^2 = 3025
    /// Hence the difference between the sum of the squares of the first ten 
    /// natural numbers and the square of the sum is 3025 - 385 = 2640.
    ///
    /// Find the difference between the sum of the squares of the first one 
    /// hundred natural numbers and the square of the sum.
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
            var sumOfSquares = Enumerable.Range(1, 100).Select(x => x*x).Sum();
            var squareOfSums = Enumerable.Range(1, 100).Sum()*Enumerable.Range(1, 100).Sum();
            return squareOfSums - sumOfSquares;
        }
    }
}
