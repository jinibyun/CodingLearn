using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Assignment
{
    public class CsharpTest
    {
        public void Test()
        {
            // 1. string & stringBuilder		
            Console.WriteLine("===== 1. string & stringBuilder ======");
            //string s = "During the development of the .NET Framework";
            //s += "the class libraries were originally written";
            //s += "using a managed code compiler system called";
            //s += "Simple Managed C (SMC)";

            // assignment: change above using StringBuilder
            // 1. StringBuilder class is in different namespace. Therefore, you will have to type "using System.Text" very top of the line.
            // 2. namespace is contatiner where multiple classes reside. Please search c# namespace

            StringBuilder s = new StringBuilder("During the development of the .NET Framework");
            s.Append(" the class libraries were originally written");
            s.Append(" using a managed code compiler system called");
            s.Append(" Simple Managed C (SMC)");
            Console.WriteLine(s);


            // 2. double array
            Console.WriteLine("\n===== 2. double array ======");
            // assignment: define array type of double, size of 13. Initialize any double value. Then use for-loop statement to print out 13 values.

            double[] darray = new double[13];
            double dvalue = 0.0d;
            int i;
            for (i = 0; i < 13; i++)
            {
                dvalue = i * 1.01;
                darray[i] = dvalue;
                Console.WriteLine(darray[i]);
            }

            // 3. string type has very useful methods which is used very often.
            Console.WriteLine("\n===== 3. string method ======");
            string s2 = "   South and North Korea will be reunited very soon   ";
            // assignment: using s2 variables, test all methods of string. e.g Console.WriteLine(s2.Trim()); Console.WriteLine(s2.substring(3,6)); ...

            char[] c = { ' ', 'S', 'o', 'u', 't', 'h' };
            Console.WriteLine(s2.Trim(c));
            Console.WriteLine(s2.Replace(" ", ""));
            Console.WriteLine(s2.Substring(13, 5));
            Console.WriteLine(s2.ToLower());
            Console.WriteLine(s2.ToUpper());

            // 4. Type Conversion
            Console.WriteLine("\n===== 4. Type Conversion ======");
            // assingment use the link -->  https://code-maze.com/csharp-basics-type-conversion/ and print out the result. (copy and paste is fine)

            int x = 10;
            int y = 3;
            double z1 = (double)x / y;
            double z2 = x / y;
            Console.WriteLine(z1);
            Console.WriteLine(z2);

            // 5. int Type
            Console.WriteLine("\n===== 5. int type ======");
            // assinment: 
            // 1. what is maximum or minimum of int type. Use some method of int type. eg. int.METHODNAME()
            // 2. What does int.Parse() method do? show example
            // 3. What is the difference between int.Parse() and int.TryParse()? show example.
            // 4. Above rule can be applied to float type as well. show examples

            Console.WriteLine(int.MaxValue);
            Console.WriteLine(int.MinValue);

            string str = "123456789";
            string str2 = "abcdefghi";
            string str3 = "1.234";
            int q;

            Console.WriteLine(int.Parse(str));
            Console.WriteLine(int.TryParse(str2, out q));   //Usually for user input
            Console.WriteLine(float.Parse(str3));

            // 6. datetime Type
            Console.WriteLine("\n===== 6. DateTime type ======");
            // assignment: Exercise all methods of DateTime and show result using Console.WriteLine
            DateTime today = new DateTime(2018, 10, 7);
            Console.WriteLine(today);


            // 7. c# operator
            Console.WriteLine("\n===== 7. c# operator ======");
            // assignment: go to https://www.programiz.com/csharp-programming/operators#compound-assignment 
            // print out the result. (Copy and Paste is fine)
            int num = 4;
            int num1 = num ^ 7;
            int num2 = num << 3;
            int num3 = num >> 2;
            Console.WriteLine(num);
            Console.WriteLine(num1);     //100 ^ 111 = 011 = 3 
            Console.WriteLine(num2);    //100 << 1 = 1000 = 8
            Console.WriteLine(num3);    //100 >> 2 = 0001 = 1


            // 8. access modifier
            Console.WriteLine("\n===== 7. c# access modifier ======");

            // assignment: go to https://www.tutlane.com/tutorial/csharp/csharp-access-modifiers-public-private-protected-internal   
            // print out the result  . (Copy and Paste is fine)
            // NOTE: You may need to create another class file for testing
            // NOTE: among six modifiers, just skip "protected internal" and "private protected"   

        }//End of Test
    }   
}

