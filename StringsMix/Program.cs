//https://www.codewars.com/kata/5629db57620258aa9d000014/train/csharp
/* Given two strings s1 and s2, we want to visualize how different the two strings are. 
 * We will only take into account the lowercase letters (a to z). 
 * The task is to produce a string in which each lowercase letters of s1 or s2 appears as many times 
 * as its maximum if this maximum is strictly greater than 1; these letters will be prefixed by the 
 * number of the string where they appear with their maximum value and :. 
 * If the maximum is in s1 as well as in s2 the prefix is =:.
 */

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringsMix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Mix("Are they here", "yes, they are here"));
        }

        public static string Mix(string s1, string s2)
        {
            var group1 = s1.Where(x => char.IsLower(x)).GroupBy(x => x);
            var group2 = s2.Where(x => char.IsLower(x)).GroupBy(x => x);

            Console.WriteLine("hello world");

            var stringMixList = new List<StringMix>();

            foreach (var group in group1)
            {
                var StringMix = new StringMix();

                StringMix.Letter = group.Key;

                if (group.Count() > group2.Where(x => x.Key.Equals(group.Key)).Select(x => x.Count()).FirstOrDefault())
                {
                    StringMix.Occurences = group.Count();
                    StringMix.Frequency = StringMix.FrequencyCheck.String1;
                }

                if (group.Count() < group2.Where(x => x.Key.Equals(group.Key)).Select(x => x.Count()).FirstOrDefault())
                {
                    StringMix.Occurences = group2.Where(x => x.Key.Equals(group.Key)).Select(x => x.Count()).FirstOrDefault();
                    StringMix.Frequency = StringMix.FrequencyCheck.String2;
                }

                if (group.Count() == group2.Where(x => x.Key.Equals(group.Key)).Select(x => x.Count()).FirstOrDefault())
                {
                    StringMix.Occurences = group.Count();
                    StringMix.Frequency = StringMix.FrequencyCheck.Equal;
                }

                stringMixList.Add(StringMix);
            }

            foreach (var group in group2)
            {
                var StringMix = new StringMix();

                StringMix.Letter = group.Key;

                if (!stringMixList.Select(x => x.Letter).Contains(group.Key))
                {
                    StringMix.Occurences = group.Count();
                    StringMix.Frequency = StringMix.FrequencyCheck.String2;

                    stringMixList.Add(StringMix);
                }
            }

            string output = "";

            foreach (var stringMix in stringMixList
                .Where(x => x.Occurences > 1)
                .OrderByDescending(x => x.Occurences)
                .ThenBy(x => (int)x.Frequency)
                .ThenBy(x => x.Letter))
            {
                output += stringMix.OutputFormattedFrequency() + "/";
            }

            output = output.TrimEnd('/');

            return output;
        }

        public class StringMix
        {
            public enum FrequencyCheck
            {
                String1,
                String2,
                Equal
            }

            public char Letter { get; set; }
            public int Occurences { get; set; }
            public FrequencyCheck Frequency { get; set; }

            public string FormatFrequency()
            {
                if (Frequency.Equals(FrequencyCheck.String1)) return "1";
                if (Frequency.Equals(FrequencyCheck.String2)) return "2";
                if (Frequency.Equals(FrequencyCheck.Equal)) return "=";

                throw new InvalidDataException();
            }

            public string FormatLetterOccurence()
            {
                string output = "";

                for (int i = 0; i < Occurences; i++)
                {
                    output += Letter;
                }

                return output;
            }

            public string OutputFormattedFrequency()
            {
                return FormatFrequency() + ":" + FormatLetterOccurence();
            }
        }
    }
}