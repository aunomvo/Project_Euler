﻿using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Problem012
{
    /// <summary>
    /// The sequence of triangle numbers is generated by adding the natural 
    /// numbers. So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28.
    /// The first ten terms would be:
    /// 
    ///     1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...
    /// 
    /// Let us list the factors of the first seven triangle numbers:
    /// 
    ///    1: 1
    ///    3: 1,3
    ///    6: 1,2,3,6
    ///    10: 1,2,5,10
    ///    15: 1,3,5,15
    ///    21: 1,3,7,21
    ///    28: 1,2,4,7,14,28
    /// 
    /// We can see that 28 is the first triangle number to have over five divisors.
    /// 
    /// What is the value of the first triangle number to have over five hundred divisors?
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
            var triangleNum = 1;
            for (int i = 2; DivisorCount(triangleNum) <= 500; i++)
            {
                triangleNum += i;
            }

            return triangleNum;
        }

        private static int DivisorCount(int num)
        {
            PopulatePrimes(num);
            var retval = 1;

            var primeFactors = s_Primes.Where(x => x < num && num % x == 0).ToList();

            foreach (var factor in primeFactors)
            {
                int i;
                for (i = 1; num % Math.Pow(factor, i) == 0; i++)
                    ;
                retval *= i;
            }

            return retval;
        }

        private static List<int> s_Primes = new List<int>();
        
        private static void PopulatePrimes(int upTo)
        {
            if(upTo <= s_Primes.DefaultIfEmpty().Max())
                return;
            var bitArray = new BitArray(upTo*100);
            bitArray[0] = false;
            bitArray[1] = false;
            for (var i = 2; i < bitArray.Length; i++)
                if (bitArray[i])
                    for (var j = i * 2; j < bitArray.Length; j += i)
                        bitArray[j] = false;
            s_Primes = bitArray.Cast<bool>().Select((x, y) => new { x, y }).Where(x => x.x).Select(x => x.y).ToList();
        }
    }
}
