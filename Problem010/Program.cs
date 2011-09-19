using System;
using System.Diagnostics;

namespace Problem010
{
    /// <summary>
    /// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
    /// 
    /// Find the sum of all the primes below two million.    
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
        
        private static ulong SolveProblem()
        {
            var sieve = new PrimeSieve(2000000);

            ulong retval = 0;
            for(ulong i = 2; i < 2000000; i++)
            {
                if (sieve.IsPrime((int)i))
                    retval = retval + i;
            }

            return retval;
        }
    }

    class PrimeSieve
    {
        private readonly byte[] m_Data;

        public PrimeSieve(int maxSize)
        {
            m_Data = new byte[maxSize/8 + 1];

            for (var i = 0; i < m_Data.Length; i++)
                m_Data[i] = 0xFF;

            ClearPrime(0);
            ClearPrime(1);

            for (var i = 2; i < maxSize; i++)
            {
                if(!IsPrime(i))
                    continue;
                for(var j = i+i; j < maxSize; j += i)
                    ClearPrime(j);
            }
        }

        public bool IsPrime(int num)
        {
            return ((m_Data[num/8]>>(num%8)) & 0x01) == 1;
        }

        public void ClearPrime(int num)
        {
            var index = num/8;
            byte value = m_Data[index];
            var bit = (byte)(0x01 << (num%8));
            value &= (byte)~bit;
            m_Data[index] = value;
        }
    }
}
