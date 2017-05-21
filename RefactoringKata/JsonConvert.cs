using System;
using System.Text;

namespace RefactoringKata
{
    public class JsonConvert
    {
        public static string JasonString(string key, object value)
        {
            if (value is int || value is double)
            {
                return string.Format("\"{0}\": {1}, ", key, value);
            }
            return string.Format("\"{0}\": \"{1}\", ", key, value);
        }

        public static void RemoveLastCharacter(StringBuilder sb)
        {
            sb.Remove(sb.Length - 2, 2);
        }
    }
}