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
            // data type : built-in data type  value type, reference type
            //             user-defined 
            // memory:  stack  heap
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

            // Char(value type)/String(reference type)
            char c = 'A';
            string s = "Hello";

            Console.WriteLine(s);

            // DateTime  2011-10-30 12:35  (reference type)
            DateTime dt = new DateTime(2011, 10, 30, 12, 35, 0);

            // Min and Max

            // Nullable(값이 없음 의미 nothing 을 의미 empty 가 아님)  
            // Value 가 null 값을 갖게 하는 방법 int?
            int? ivalue = null;
            ivalue = 101;

            bool? bvalue = null;
            // normally, it uses with HasValue property
            Console.WriteLine(bvalue.HasValue);

            //int? to int
            Nullable<int> j = null; //euqal to int? j
            j = 10;
            int k = j.Value;

            Console.WriteLine(k);
        }
    }
}
