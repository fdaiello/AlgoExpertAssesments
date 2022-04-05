using System;
using System.Text.RegularExpressions;

namespace AlgoExpertAssesments
{
    class Program
    {
        static void Main(string[] args)
        {
            TestGlobMatching();
        }
        public static void TestGlobMatching()
        {
            string filename;
            string pattenr;

            filename = "abcdef.net";
            pattenr = "abcde?";

            Console.WriteLine(GlobMatching(filename, pattenr));
            Console.WriteLine("Expected: false");

            filename = "abcdefg";
            pattenr = "a*e?g";

            Console.WriteLine(GlobMatching(filename, pattenr));
            Console.WriteLine("Expected: true");

            filename = "abcdefg";
            pattenr = "*";

            Console.WriteLine(GlobMatching(filename, pattenr));
            Console.WriteLine("Expected: true");

            filename = "abcdef";
            pattenr = "abcde?";

            Console.WriteLine(GlobMatching(filename, pattenr));
            Console.WriteLine("Expected: true");


            filename = "asfde";
            pattenr = "a?f?g";

            Console.WriteLine(GlobMatching(filename, pattenr));
            Console.WriteLine("Expected: false");


        }
        /*
         *   Return True or False - if filename matches pattner
         *   * - match any char, any lenght
         *   ? - matches any char, exact 1 position
         */
        public static bool GlobMatching(string fileName, string pattern)
        {

            // Convert global patter no Regex
            var regPatter = '^' + pattern.Replace("?", "\\S").Replace("*", "[a-zA-Z1-9]*") + '$';

            // Check if regex
            return Regex.IsMatch(fileName, regPatter);
        }
    }
}
