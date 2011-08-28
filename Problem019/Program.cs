using System;
using System.Diagnostics;

namespace Problem019
{
    /// <summary>
    /// You are given the following information, but you may prefer to do some research for yourself.
    ///
    ///    1 Jan 1900 was a Monday.
    ///
    ///    Thirty days has September,
    ///    April, June and November.
    ///    All the rest have thirty-one,
    ///    Saving February alone,
    ///    Which has twenty-eight, rain or shine.
    ///    And on leap years, twenty-nine.
    ///
    ///    A leap year occurs on any year divisible by 4, but not on a century unless it is divisible by 400.
    ///
    /// How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
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
            var dayOfTheWeek = 2; //sunday == 0, 1-Jan-1901 was a Tuesday so init to 2.
            var year = 1901;
            var month = 1; //1-based indexing here
            var sundayCount = 0;
            while (year <= 2000)
            {
                if (dayOfTheWeek == 0)
                    sundayCount++;
                switch (month)
                {
                    //Thirty days has September, April, June and November.
                    case 9:
                    case 4:
                    case 6:
                    case 11:
                        dayOfTheWeek += 30;
                        break;
                    //All the rest have thirty-one,
                    default:
                        dayOfTheWeek += 31;
                        break;
                    //Saving February alone, Which has twenty-eight, rain or shine.
                    //And on leap years, twenty-nine.
                    case 2:
                        //A leap year occurs on any year evenly divisible by 4,
                        //but not on a century unless it is divisible by 400.
                        if (year % 4 == 0)
                        {
                            if (year % 100 == 0)
                            {
                                if (year % 400 == 0)
                                {
                                    dayOfTheWeek += 29;
                                }
                                else
                                {
                                    dayOfTheWeek += 28;
                                }
                            }
                            else
                            {
                                dayOfTheWeek += 29;
                            }
                        }
                        else
                        {
                            dayOfTheWeek += 28;
                        }
                        break;
                }
                dayOfTheWeek %= 7;
                month++;
                if (month > 12)
                {
                    month = 1;
                    year++;
                }
            }

            return sundayCount;
        }
    }
}
