using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Problem079
{
    /// <summary>
    /// A common security method used for online banking is to ask the user for
    /// three random characters from a passcode. For example, if the passcode
    /// was 531278, they may ask for the 2nd, 3rd, and 5th characters; the
    /// expected reply would be: 317.
    ///
    /// The text file, keylog.txt, contains fifty successful login attempts.
    ///
    /// Given that the three characters are always asked for in order, analyse
    /// the file so as to determine the shortest possible secret passcode of
    /// unknown length.
    /// </summary>
    class Program
    {
        private static string[] m_Keylog = new[]
        {
            "319", "680", "180", "690", "129", "620", "762", "689", "762", "318",
            "368", "710", "720", "710", "629", "168", "160", "689", "716", "731",
            "736", "729", "316", "729", "729", "710", "769", "290", "719", "680",
            "318", "389", "162", "289", "162", "718", "729", "319", "790", "680",
            "890", "362", "319", "760", "316", "729", "380", "319", "728", "716"
        };

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

        private class KeylogPhoneme
        {
            public readonly char Name;
            public List<char> Leftbag = new List<char>();
            public List<char> Rightbag = new List<char>();

            public KeylogPhoneme(char name)
            {
                Name = name;
            }
        }

        private static int SolveProblem()
        {
            m_Keylog = m_Keylog.Distinct().ToArray();

            var keylogParseResults = new Dictionary<char, KeylogPhoneme>();
            foreach (var keylogEntry in m_Keylog)
            {
                KeylogPhoneme phoneme;

                if (!keylogParseResults.ContainsKey(keylogEntry[0]))
                    keylogParseResults.Add(keylogEntry[0], new KeylogPhoneme(keylogEntry[0]));
                phoneme = keylogParseResults[keylogEntry[0]];
                phoneme.Rightbag.Add(keylogEntry[1]);
                phoneme.Rightbag.Add(keylogEntry[2]);

                if (!keylogParseResults.ContainsKey(keylogEntry[1]))
                    keylogParseResults.Add(keylogEntry[1], new KeylogPhoneme(keylogEntry[1]));
                phoneme = keylogParseResults[keylogEntry[1]];
                phoneme.Leftbag.Add(keylogEntry[0]);
                phoneme.Rightbag.Add(keylogEntry[2]);

                if (!keylogParseResults.ContainsKey(keylogEntry[2]))
                    keylogParseResults.Add(keylogEntry[2], new KeylogPhoneme(keylogEntry[2]));
                phoneme = keylogParseResults[keylogEntry[2]];
                phoneme.Leftbag.Add(keylogEntry[0]);
                phoneme.Leftbag.Add(keylogEntry[1]);
            }

            foreach (var phoneme in keylogParseResults.Values)
            {
                phoneme.Rightbag = phoneme.Rightbag.Distinct().ToList();
                phoneme.Leftbag = phoneme.Leftbag.Distinct().ToList();
            }

            return
                int.Parse(
                new string(
                keylogParseResults.Values
                    .OrderBy(x => x.Leftbag.Count)
                    .Select(x => x.Name).ToArray()));
        }
    }
}
