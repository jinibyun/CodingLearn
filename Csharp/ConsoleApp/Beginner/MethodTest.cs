using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Beginner
{
    public class MethodTest
    {
        // pass by value 카피본이 넘어감
        public void TestPassByValue(int a)
        {
            a *= 2;
        }

        // pass by ref 실제 메모리주소 자체가 넘어감
      
        public double TestPassByRef(ref int a, ref double b)
        {
            return ++a * ++b;
        }

        // pass by out 
        
        public bool TestPassByOut(int a, int b, out int c, out int d)   //메모리위치자체 값을 바꿔서 c,d를 계산해서 내보냈다. 
        {
            c = a + b;
            d = a - b;
            return true;    //리턴값 3개 쓸수있다.
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

        // params keyword
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
