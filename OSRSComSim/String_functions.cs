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
            int multiply = 1;
            if (str.Contains("-")) multiply = -1; //I know this is wrong way... 
            return multiply * Int32.Parse(Regex.Match(str, @"\d+").Value);
        }

        public static string getOnlyLetters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z]", "");
        }

        public static bool HasNoSpecialChars(string yourString)
        {
            return !yourString.Any(ch => !Char.IsLetterOrDigit(ch));
        }
    }
}
