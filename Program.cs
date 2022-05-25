using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace logical
{
    public static class LogicalCalculator
    {
        public static bool Calc()
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"(^\d+)", RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
            string left = "";
            string right = "";
            MatchCollection matches = regex.Matches(input);
            if (regex.IsMatch(input))
            {
                foreach (var item in matches)
                {
                    left += item.ToString();
                }
            }
            else throw new Exception("Wrong expression.");
            input = regex.Replace(input, "");
            regex = new Regex(@"\d+$");
            if (regex.IsMatch(input))
            {
                matches = regex.Matches(input);
                foreach (var item in matches)
                {
                    right += item.ToString();
                }
            }
            else throw new Exception("Wrong expression.");
            input = regex.Replace(input, "");
            bool res = false;
            switch (input)
            {
                case ">": res = Convert.ToInt32(left) > Convert.ToInt32(right); break;
                case ">=": res = Convert.ToInt32(left) >= Convert.ToInt32(right); break;
                case "<=": res = Convert.ToInt32(left) <= Convert.ToInt32(right); break;
                case "==": res = Convert.ToInt32(left) == Convert.ToInt32(right); break;
                case "!=": res = Convert.ToInt32(left) != Convert.ToInt32(right); break;
                case "<": res = Convert.ToInt32(left) < Convert.ToInt32(right); break;
                default: throw new Exception("Wrong expression.");
            }
            return res;

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            bool f = LogicalCalculator.Calc();
            Console.WriteLine(f);
            Console.ReadLine();
        }
    }
}
