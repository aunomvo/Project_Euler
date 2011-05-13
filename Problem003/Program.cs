using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Problem003
{
    /// <summary>
    /// The prime factors of 13195 are 5, 7, 13 and 29.
    ///
    /// What is the largest prime factor of the number 600851475143 ?
    /// </summary>
    class Program
    {
        private const ulong CompositeNum = 600851475143;

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
            var result = CompositeNum;

            var primes = new List<int>{2};

            while(true)
            {
                if (primes.Contains((int)result))
                    return (int) result;
                else
                {
                    var foundDivisor = false;
                    foreach(var prime in primes)
                    {
                        if (result % (ulong) prime == 0)
                        {
                            result = result/(ulong) prime;
                            foundDivisor = true;
                            break;
                        }
                    }

                    if(!foundDivisor)
                        GetMorePrimes(primes);
                }
            }
        }

        private static void GetMorePrimes(List<int> primes)
        {
            var maxPrime = primes.Max();
            var newPrimes = new List<int>();
            var range = Enumerable.Range(2, maxPrime * maxPrime * maxPrime * maxPrime);
            var cursor = 2;
            while (cursor * cursor < (maxPrime * maxPrime * maxPrime * maxPrime))
            {
                newPrimes.Add(cursor);
                int cursor1 = cursor;
                range = range.Where(x => x%cursor1 != 0);
                cursor = range.Min();
            }
            foreach(var p in newPrimes)
            {
                if (!primes.Contains(p))
                    primes.Add(p);
            }
        }
    }
}
