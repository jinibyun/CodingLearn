using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Beginner
{
    public class MethodTest
    {
        // pass by value : copy가 넘어감
        public void TestPassByValue(int a)
        {
            a *= 2;
        }

        // pass by ref : memory 가 넘어감
        // you have to initialize ref value.

        public double TestPassByRef(ref int a, ref double b)
        {
            return ++a * ++b;
        }

        // pass by out : ref 랑 비슷하나 default value 가 필요 없다
        public bool TestPassByOut(int a, int b, out int c, out int d)
        {
            c = a + b;
            d = a - b;
            return true;
        }

        // optional or default parameter
        public int TestDefaultParam(int a, int b, string calcType = "+")
        {
            switch (calcType)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    return a / b;
                default:
                    throw new ArithmeticException();
            }
        }

        // params keyword : parameter 숫자를 제한하지 않음 
        public long TestParams(params int[] values)
        {
            long sum = 0L;
            foreach(var member in values)
            {
                sum += member;
            }
            return sum;
        }
    }
}
