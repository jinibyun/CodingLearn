using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Beginner
{
    public class DataType
    {
        public void Test()
        {
            // ref: https://www.programiz.com/csharp-programming/variables-primitive-data-types

            // Bool
            bool b = true;
            Console.WriteLine(b);

            // Numeric
            short sh = -32768;
            int i = 2147483647;
            long l = 1234L;      // L suffix
            float f = 123.45F;   // F suffix
            double d1 = 123.45;
            double d2 = 123.45D; // D suffix
            decimal d = 123.45M; // M suffix

            // Char/String
            char c = 'A';
            string s = "Hello";
            Console.WriteLine(s);

            // DateTime  2011-10-30 12:35
            DateTime dt = new DateTime(2011, 10, 30, 12, 35, 0);

            // Min and Max

            // Nullable
            int? ivalue = null;
            ivalue = 101;

            bool? bvalue = null;
            //Normally, it uses with HasValue Property
            Console.WriteLine(bvalue.HasValue);

            //int? to int
            int? j = null;     //equal to int? j = null;
            j = 10;
            int k = j.Value;

            Console.WriteLine(k);
        }
    }
}
