using System;
using System.Diagnostics;
using System.Linq;

namespace Problem004
{
    /// <summary>
    /// A palindromic number reads the same both ways. The largest palindrome 
    /// made from the product of two 2-digit numbers is 9009 = 91  99.
    ///
    /// Find the largest palindrome made from the product of two 3-digit numbers
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
            var result = 0;

            for(var x = 999; x > 99; x--)
            {
                for (var y = 999; y > 99; y--)
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
}
