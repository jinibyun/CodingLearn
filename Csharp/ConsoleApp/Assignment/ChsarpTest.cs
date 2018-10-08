using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Assignment
{
    public class ChsarpTest
    {
        public void Test()
        {
            Console.WriteLine("===Assignment Start===");
            
            
                // 1. string & stringBuilder		
                Console.WriteLine("\n\n===== 1. string & stringBuilder ======\n\n");

                StringBuilder strBldr = new StringBuilder("During the development of the .NET Framework");
                strBldr.Append("the class libraries were originally written");
                strBldr.Append("using a managed code compiler system called");
                strBldr.Append("Simple Managed C (SMC)");
                Console.WriteLine(strBldr.ToString());
                Console.WriteLine("\n\n=======================================\n\n");


                // 2. double array
                Console.WriteLine("\n\n===== 2. double array ========\n\n");

                double[] arr1 = new double[13] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
                for (int i = 0; i < arr1.Length; i++)
                {
                    Console.WriteLine(arr1[i]);
                }
                Console.WriteLine("\n\n===============================\n\n");

                // 3. string Methods
                Console.WriteLine("===== 3. string method ======");
                string s2 = "   South and North Korea will be reunited very soon   ";

                //1)SubString - 문자열의 위치를 이용하여 문자열 컨트롤

                Console.WriteLine(s2.Substring(1, 10));
                Console.WriteLine(s2.Substring(15));

                //2)Split - 지정된 문자를 기준으로 문자열을 분리

                char[] sp = { ' ' };
                string[] spstring = s2.Split(sp);
                for (int i = 0; i < spstring.Length; i++)
                {
                    Console.WriteLine(spstring[i]);
                }
                Console.WriteLine("\n\n_________________________________________\n\n");

                string[] result = s2.Split(new char[] { ' ' });
                for (int i = 0; i < result.Length; i++)
                {
                    Console.WriteLine(i + "번째 배열 ==> " + result[i]);
                }

                //3)indexOf - 특정문자의 인덱스값 찾기 
                //   text.indexOf(searchText)
                Console.WriteLine(s2.IndexOf("o"));


                //4)Substring + indexOf 이용하여 문자열 자르기
                Console.WriteLine(s2.Substring(0, s2.IndexOf("w")));


                //5)Replace 를 이용하여 문자를 변경
                Console.WriteLine(s2.Replace("S", "H"));

                //6)ToUpper,ToLower사용하기 대문자변환,소문자변환
                Console.WriteLine(s2.ToUpper());
                Console.WriteLine(s2.ToLower());

                //7)Trim으로 문자열 앞뒤 공백제거
                Console.WriteLine(s2.Trim());


                // 4. Type Conversion
                Console.WriteLine("\n\n===== 4. Type Conversion ======\n\n");

                //Implicit Conversion 예시1
                int x = 21;
                int y = 5;

                double b = (double)x / y;
                Console.WriteLine(b);


                //Implicit Conversion 예시2
                double c = 12.45;
                int d = 10;
                c = c + d;

                Console.WriteLine(c);


                int e;
                double f = 10.7;
                e = (int)f;

                Console.WriteLine(e);


                //Using the Convert Class
                int g = 15;
                string s1 = g.ToString();

                Console.WriteLine(s1);

                Console.WriteLine("\n\n===============================\n\n");



                // 5. int Type
                Console.WriteLine("===== 5. int type ======");


                // assinment: 
                // 1. what is maximum or minimum of int type. Use some method of int type. eg. int.METHODNAME()
                Console.WriteLine("최소값 = {0}, 최대값 = {1}", int.MinValue, int.MaxValue);
                Console.WriteLine("__________________________________________");


                // 2. What does int.Parse() method do? show example

                //C#에서는 데이터 타입을 쉽게 변환 할 수 있도록 하는 문법을 제공해 줍니다.
                //C#에서 String 타입에 문자열을 int형으로 변환하는 방법입니다.
                //int.Parse를 이용하여 아래와 같이 사용하면 됩니다.

                int h = int.Parse("12345");


                Console.WriteLine(h);

                Console.WriteLine("__________________________________________");

                // 3. What is the difference between int.Parse() and int.TryParse()? show example.

                String str1 = "1a2";
                int number1;
                if (int.TryParse(str1, out number1))
                {
                    Console.WriteLine(number1);
                }
                else
                {
                    Console.WriteLine("fail");
                }


                Console.WriteLine("__________________________________________");
                // 4. Above rule can be applied to float type as well. show examples

                float j = float.Parse("123.45");
                Console.WriteLine(j);

                String str = "1a2";
                float number;
                if (float.TryParse(str, out number))
                {
                    Console.WriteLine(number);
                }
                else
                {
                    Console.WriteLine("fail");
                }


                // 6. datetime Type
                Console.WriteLine("\n\n===== 6. DateTime type ======\n\n");


                DateTime today = DateTime.Now;
                Console.WriteLine(string.Format("{0:M/d/yyyy}", today));
                Console.WriteLine(string.Format("{0:d/M/yyyy HH:mm:ss}", today));

                Console.WriteLine(today.ToLongDateString());
                Console.WriteLine(today.ToLongTimeString());
                Console.WriteLine(today.ToShortDateString());
                Console.WriteLine(today.ToShortTimeString());



                DateTime utcTime = today.ToUniversalTime();


                string s = DateTime.UtcNow.ToString("o");
                Console.WriteLine(s);


                s = DateTime.UtcNow.ToString("s",
                    System.Globalization.CultureInfo.InvariantCulture) + "Z";
                Console.WriteLine(s);


                s = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
                Console.WriteLine(s);




                // 7. c# operator
                Console.WriteLine("\n\n===== 7. c# operator ======\n\n");

                // Example 1: Basic Assignment Operator
                int firstNumber, secondNumber;
                // Assigning a constant to variable
                firstNumber = 10;
                Console.WriteLine("First Number = {0}", firstNumber);

                // Assigning a variable to another variable
                secondNumber = firstNumber;
                Console.WriteLine("Second Number = {0}", secondNumber);

                //  Example 2: Arithmetic Operators
                double firstNumber1 = 14.40, secondNumber1 = 4.60, result1;
                int num1 = 26, num2 = 4, rem;

                // Addition operator
                result1 = firstNumber1 + secondNumber1;
                Console.WriteLine("{0} + {1} = {2}", firstNumber1, secondNumber1, result1);

                // Subtraction operator
                result1 = firstNumber1 - secondNumber1;
                Console.WriteLine("{0} - {1} = {2}", firstNumber1, secondNumber1, result1);

                // Multiplication operator
                result1 = firstNumber1 * secondNumber1;
                Console.WriteLine("{0} * {1} = {2}", firstNumber1, secondNumber1, result1);

                // Division operator
                result1 = firstNumber1 / secondNumber1;
                Console.WriteLine("{0} / {1} = {2}", firstNumber1, secondNumber1, result1);

                // Modulo operator
                rem = num1 % num2;
                Console.WriteLine("{0} % {1} = {2}", num1, num2, rem);

                //3.Example 3: Relational Operators
                bool result2;
                int firstNumber2 = 10, secondNumber2 = 20;

                result2 = (firstNumber2 == secondNumber2);
                Console.WriteLine("{0} == {1} returns {2}", firstNumber2, secondNumber2, result2);

                result2 = (firstNumber2 > secondNumber2);
                Console.WriteLine("{0} > {1} returns {2}", firstNumber2, secondNumber2, result2);

                result2 = (firstNumber2 < secondNumber2);
                Console.WriteLine("{0} < {1} returns {2}", firstNumber2, secondNumber2, result2);

                result2 = (firstNumber2 >= secondNumber2);
                Console.WriteLine("{0} >= {1} returns {2}", firstNumber2, secondNumber2, result2);

                result2 = (firstNumber2 <= secondNumber2);
                Console.WriteLine("{0} <= {1} returns {2}", firstNumber2, secondNumber2, result2);

                result2 = (firstNumber2 != secondNumber2);
                Console.WriteLine("{0} != {1} returns {2}", firstNumber2, secondNumber2, result2);

                //Example 4: Logical Operators
                bool result3;
                int firstNumber3 = 10, secondNumber3 = 20;

                // OR operator
                result3 = (firstNumber3 == secondNumber3) || (firstNumber3 > 5);
                Console.WriteLine(result3);

                // AND operator
                result3 = (firstNumber3 == secondNumber3) && (firstNumber3 > 5);
                Console.WriteLine(result3);

                //Example 5: Unary Operators
                int number4 = 10, result4;
                bool flag = true;

                result4 = +number4;
                Console.WriteLine("+number4 = " + result4);

                result4 = -number4;
                Console.WriteLine("-number4 = " + result4);

                result4 = ++number4;
                Console.WriteLine("++number4 = " + result4);

                result4 = --number4;
                Console.WriteLine("--number4 = " + result4);

                Console.WriteLine("!flag = " + (!flag));

                //Example 6: Post and Pre Increment operators in C#
                int number5 = 10;

                Console.WriteLine((number5++));
                Console.WriteLine((number5));

                Console.WriteLine((++number5));
                Console.WriteLine((number5));

                //Example 7: Ternary Operator
                int number6 = 10;
                string result6;

                result6 = (number6 % 2 == 0) ? "Even Number" : "Odd Number";
                Console.WriteLine("{0} is {1}", number6, result6);

                //Example 8: Bitwise and Bit Shift Operator
                int firstNumber7 = 10;
                int secondNumber7 = 20;
                int result7;

                result7 = ~firstNumber7;
                Console.WriteLine("~{0} = {1}", firstNumber7, result7);

                result7 = firstNumber7 & secondNumber7;
                Console.WriteLine("{0} & {1} = {2}", firstNumber7, secondNumber7, result7);

                result7 = firstNumber7 | secondNumber7;
                Console.WriteLine("{0} | {1} = {2}", firstNumber7, secondNumber7, result7);

                result7 = firstNumber7 ^ secondNumber7;
                Console.WriteLine("{0} ^ {1} = {2}", firstNumber7, secondNumber7, result7);

                result7 = firstNumber7 << 2;
                Console.WriteLine("{0} << 2 = {1}", firstNumber7, result7);

                result7 = firstNumber7 >> 2;
                Console.WriteLine("{0} >> 2 = {1}", firstNumber7, result7);

                //Example 9: Compound Assignment Operator
                int number8 = 10;

                number8 += 5;
                Console.WriteLine(number8);

                number8 -= 3;
                Console.WriteLine(number8);

                number8 *= 2;
                Console.WriteLine(number8);

                number8 /= 3;
                Console.WriteLine(number8);

                number8 %= 3;
                Console.WriteLine(number8);

                number8 &= 10;
                Console.WriteLine(number8);

                number8 |= 14;
                Console.WriteLine(number8);

                number8 ^= 12;
                Console.WriteLine(number8);

                number8 <<= 2;
                Console.WriteLine(number8);

                number8 >>= 3;
                Console.WriteLine(number8);

                Console.ReadKey();

    
        }
    }
}
