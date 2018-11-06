using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    public static class Utility
    {
        public static bool IsScriptLanguage(string language)
        {
            switch (language.ToLower())
            {
                case "javascript":
                case "php":
                case "perl":
                case "ruby":
                case "python":
                    return true;
                default:
                    return false;
            }
        }

        public static DateTime GetYearOfCreation(string lanugae)
        {
            DateTime date;
            switch (lanugae.ToLower())
            {
                case "csharp":
                case "c#":
                    date = new DateTime(2002, 1, 1);
                    break;
                case "java":
                    date = new DateTime(1996, 1, 23);
                    break;
                case "javascript":
                    date = new DateTime(1995, 5, 10);
                    break;
                case "perl":
                    date = new DateTime(1987, 12, 18);
                    break;
                case "ruby":
                    date = new DateTime(1996, 12, 25);
                    break;
                case "python":
                    date = new DateTime(1989, 12, 1);
                    break;
                default:
                    date = new DateTime();
                    break;
            }
            return date; 
        }
    }
}
