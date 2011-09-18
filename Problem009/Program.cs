using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Problem009
{
    /// <summary>
    /// A Pythagorean triplet is a set of three natural numbers, c > b > a, for which,
    /// 
    ///     a^2 + b^2 = c^2
    /// 
    /// For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
    /// 
    /// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    /// Find the product abc.
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
            for(var c = 997; c > 333; c--)
            {
                for(var b = 999 - c; b > 1; b--)
                {
                    var a = 1000 - (b + c);
                    if (a * a + b * b == c * c)
                        return a*b*c;
                }
            }
            return 0;
        }
    }
}
