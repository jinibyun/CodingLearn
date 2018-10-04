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
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/value-types

            // Bool
            bool b = true;  // '=' means 'Assign the value to the object'

            // Numeric
            short sh = -32768;
            int i = 2147483647;
            long l = 1234L;      // L suffix    
            //if L is not included, the value will be assigned as 'int' first, 
            //and then it will be assigned as 'long' again. It is inefficient.
            // 요약: 명시적으로 넣어주는 게 value를 잠깐 다른 데이터형으로 저장하는 쓸데없는 과정을 줄여줘서 효율적

            float f = 123.45F;   // F suffix    float니까 float로 넣어달라고 명시하는 것.
            double d1 = 123.45;     // can get the double size of float. double float
            double d2 = 123.45D; // D suffix
            decimal d = 123.45M; // M suffix

            // Char/String
            char c = 'A';
            string s = "Hello";
            // string is Reference Type
            // String can be used... 앨리야스로 주어짐


            // DateTime  2011-10-30 12:35
            // it is Reference Type
            DateTime dt = new DateTime(2011, 10, 30, 12, 35, 0);

            // Min and Max

            // Nullable
            // Null 넣으려면 물음표 반드시 써야함
            // integer인데 null도 넣을까? 라는 의미..?
            // null은 empty가 아님. nothing, 아무것도 아님이라는 뜻임.
            int? ivalue = null;
            ivalue = 101;

            bool? bvalue = null;
            // normally, it uses with HasValue Property
            Console.WriteLine(bvalue.HasValue); // shows false. cause it is null
            bvalue = false;
            Console.WriteLine(bvalue.HasValue); // shows true;


            //int? to int
            Nullable<int> j = null; // equal to int? j
            j = 10;
            int k = j.Value;

            Console.WriteLine(k);

            // value type data는 처음의 '}'앞에 모두 삭제됨.
        }
    }
}
