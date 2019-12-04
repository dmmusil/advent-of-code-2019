using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            const int lower = 245182, upper = 790572;
            var validPassword = new List<int>();
            for (int i = lower; i <= upper; i++)
            {
                if (i.IsValidPassword())
                {
                    validPassword.Add(i);
                }
            }

            System.Console.WriteLine(validPassword.Count);
        }


    }
    public static class IntExtensions
    {
        public static bool IsValidPassword(this int input)
        {
            var str = input.ToString();
            var valid = false;
            var digits = new Dictionary<char, int>();
            for (int i = 1; i < str.Length; i++)
            {
                var prev = str[i - 1];
                var current = str[i];
                if (prev == current) valid = true;
                if (current < prev)
                {
                    valid = false;
                    break;
                }
            }

            foreach (char c in str)
            {
                if (digits.ContainsKey(c))
                {
                    digits[c]++;
                }
                else { digits.Add(c, 1); }
            }

            valid = valid && digits.Any(kvp => kvp.Value == 2);

            return valid;
        }
    }
}
