using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagement.CORE.Extensions
{
    public static class StringExtensions
    {
        public static bool AllLetters(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            char[] array = value.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (!char.IsLetter(array[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static string FirstCharToLower(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            return char.ToLower(str[0]) + str.Substring(1);
        }

        public static string ToSnakeCase(this string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            if (text.Length < 2)
            {
                return text;
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(char.ToLowerInvariant(text[0]));
            for (int i = 1; i < text.Length; i++)
            {
                char c = text[i];
                if (char.IsUpper(c))
                {
                    stringBuilder.Append('_');
                    stringBuilder.Append(char.ToLowerInvariant(c));
                }
                else
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString();
        }
    }
}
