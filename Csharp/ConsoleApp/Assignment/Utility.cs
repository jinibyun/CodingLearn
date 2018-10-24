using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Assignment
{
    public static class Utility
    {
       
        //static Static Class()
        //{

        //}

        // usage: Utility (helper) classes often contain public static methods
        public static bool isScriptLanguage(string lan)
        {
            bool done;

            switch (lan)
            {
                case "Java":
                    Console.WriteLine("Java is not a script language");
                    done = false;
                    break;
                case "JavaScript":
                    Console.WriteLine("Javascript is a script language");
                    done = true;
                    break;
                default:
                    Console.WriteLine("This is not a script language");
                    done = false;
                    break;
            }

            return done;
        }

        public static DateTime GetYearOfCreation(string lan)
        {
            DateTime dt = DateTime.Today;
            DateTime calcYear;

            switch (lan)
            {
                case "Csharp":

                    calcYear = dt.AddYears(-1994);
                    Console.WriteLine("Csharp years: ");
                    break;
                case "Java":
                    Console.WriteLine("Java years: ");
                    calcYear = dt.AddYears(-2000);
                    break;
                default:
                    calcYear = dt.AddYears(-2018);
                    break;
            }
            
            return calcYear;
        }











        //public bool GetYearOfCreation(Datetime lan1)
        //{
        //    return true;
        //}

    }
}
