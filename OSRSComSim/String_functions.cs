using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OSRSComSim
{
    static class String_functions
    {
        public static int getFirstNumberFromString(string str)
        {
            return Int32.Parse(Regex.Match(str, @"\d+").Value);
        }

        public static bool HasNoSpecialChars(string yourString)
        {
            return !yourString.Any(ch => !Char.IsLetterOrDigit(ch));
        }
    }
}
