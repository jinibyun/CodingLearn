using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // basic
            // 1. DataType
            Console.WriteLine("=================== Data Type ================");
            var dt = new DataType();
            dt.Test();

            // 2. Variable And Constant
            Console.WriteLine("=================== Variable & Constant ================");
            var vnc = new VariableAndConstant();
            vnc.Test();

            // 3. Array
            Console.WriteLine("=================== Array ================");
            var arr = new ArrayTest();
            arr.Test();

            // 4. String
            Console.WriteLine("=================== String ================");
            var strTest = new StringTest();
            strTest.Test();

            // 5. Enum
            Console.WriteLine("=================== Enum ================");
            var enumTest = new EnumTest();
            enumTest.Test();

            // 6. Operator
            
        }
    }
}
