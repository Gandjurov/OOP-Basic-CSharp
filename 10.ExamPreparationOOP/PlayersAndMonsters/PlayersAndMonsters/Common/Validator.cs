using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Common
{
    public class Validator
    {
        public static void ThrowIfStringIsNullOrEmpty(string str, string message = null)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfNumberIsOrNegative(int number, string message = null)
        {
            if (number < 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
