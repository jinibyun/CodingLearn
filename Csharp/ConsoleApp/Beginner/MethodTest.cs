using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Beginner
{
    public class MethodTest
    {
        // pass by value
        public void TestPassByValue(int a)
        {
            a *= 2;
        }

        // data를 return할 때 새 메모리에 결과값을 카피해서 넘김.
        // int i = 7;
        // Sum(i);
        // i를 넘기는 게 아니라 i값을 또다른 메모리에 카피해서 넘기는 것.
        // Sum 메쏘드 안에서 부여받은 i를 어떻게 지지고 볶든 실제 i에는 영향이 전혀 안감.

        // 그러나 가끔 copy가 아니라 실제 memory를 넘기는 경우가 있음. By ref
        // 메모리가 넘어가는 방식은 메모리 주소를 넘기는 것.
        // 그러면 만약 주어진 값이 변경되면 실제 변수도 변경됨.

        // pass by ref
        public double TestPassByRef(ref int a, ref double b)
        {
            return ++a * ++b;
        }

        // pass by out
        // out으로 c와 d의 값도 배출함. 이런 점에선 ref와 비슷..
        // 더 flexible하기 때문에 ref보다 더 많이 쓰임.

        // ★★★★★
        // 인터뷰 문제: ref와 out의 차이점?
        // 답: ref값을 넘길 때 ref값들은 초기값이 있어야함.
        //      out은 초기값 없어도 됨.
        // when you pass the ref value, the value has to be initialized.
        // but the values do not need to be initialized when use 'out' keyword.
        public bool TestPassByOut(int a, int b, out int c, out int d)
        {
            c = a + b;
            d = a - b;
            return true;
        }

        // optional or default parameter
        // if calcType doesn't have any value, and the default value "+" will be assigned.
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
            foreach (var member in values)
            {
                sum += member;
            }
            return sum;
        }
    }
}
