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
            Console.WriteLine("== Assignment Start ==");
            // 1. string & stringBuilder		
            Console.WriteLine("===== 1. string & stringBuilder ======");

            string s = "During the development of the .NET Framework";
            s += "the class libraries were originally written";
            s += "using a managed code compiler system called";
            s += "Simple Managed C (SMC)";

            // assignment: change above using StringBuilder
            // 1. StringBuilder class is in different namespace. Therefore, you will have to type "using System.Text" very top of the line.
            // 2. namespace is contatiner where multiple classes reside. Please search c# namespace

            StringBuilder sb = new StringBuilder();
            sb.Append("During the development of the.NET Framework");
            sb.Append("the class libraries were originally written");
            sb.Append("using a managed code compiler system called");
            sb.Append("Simple Managed C (SMC)");

            Console.WriteLine("String Builders ==> " + sb);

            // 2. double array
            Console.WriteLine("===== 2. double array ======");
            // assignment: define array type of double, size of 13. Initialize any double value. Then use for-loop statement to print out 13 values.

            double[] dob = new double[13];

            
            for (int i = 0; i < 13; i++)
            {
                dob[i] = i + 3.14;
                   Console.WriteLine("double array: "+dob[i]);
            }

            //Console.ReadLine();

            // 3. string type has very useful methods which is used very often.
            Console.WriteLine("===== 3. string method ======");
            string s2 = "   South and North Korea will be reunited very soon   ";
            // assignment: using s2 variables, test all methods of string. e.g Console.WriteLine(s2.Trim()); Console.WriteLine(s2.substring(3,6)); ...

            Console.WriteLine("string trim is");
            Console.WriteLine(s2.Trim());

            Console.WriteLine("string substring is");
            Console.WriteLine(s2.Substring(3, 6));


            // 4. Type Conversion
            Console.WriteLine("===== 4. Type Conversion ======");
            // assingment use the link -->  https://code-maze.com/csharp-basics-type-conversion/ and print out the result. (copy and paste is fine)

            Console.WriteLine("===== 4-1.Implict Conversion ======");

            int x = 21;
            int y = 5;
            double b = x / y;

            Console.WriteLine("21 / 5 = " + b);

            Console.WriteLine("===== 4-2.Explict Conversion ======");

            int x1 = 21;
            int y1 = 5;

            double b1 = (double)x1 / y1;

            Console.WriteLine("21 / 5 = " + b1);

            Console.WriteLine("===== 4-3.Using the Convert class ======");

            int c = 15;
            string s1 = Convert.ToString(c);
            Console.WriteLine("string 15 is " + s1);

            // 5. int Type
            Console.WriteLine("===== 5. int type ======");
            // assinment: 
            // 5-1. what is maximum or minimum of int type. Use some method of int type. eg. int.METHODNAME()
            Console.WriteLine("5.1 Int has a maximum value or a minimum value it can represent");
            Console.WriteLine("maximum value:  " + int.MaxValue);
            Console.WriteLine("mminimum value: " + int.MinValue);


            // 5.2. What does int.Parse() method do? show example
            Console.WriteLine("5.2 It is used to convert a string representation of number to an integer");   
            string s3 = "1234";
            int value = int.Parse(s3);
            Console.WriteLine("int.Parse() is " +value);

            // 5.3. What is the difference between int.Parse() and int.TryParse()? show example.
            Console.WriteLine("5.3 In case of the string can’t be converted the int.Parse() throws an exceptions" +
            "where as int.TryParse() return a bool value, false");
            //string val = null;
            //int value1 = int.Parse(val); ArgumentNullException 
            Console.WriteLine("int.Parse() threw ArgumentNullException");
            
            string val = null;
            int result;
            bool ifSucess = int.TryParse(val, out result);
            Console.WriteLine("int.TryParse() ok!! " + result);

            // 5.4. Above rule can be applied to float type as well. show examples
            //string val1 = "1234.56F";
            //int value1 = int.Parse(val1); FormatException
            Console.WriteLine("5.4 int.Parse() threw Format Exception,");

            string val1 = "1234.56F";
            int result1;
            bool ifSucess1 = int.TryParse(val1, out result1);
            Console.WriteLine("int.TryParse() ok!! " + result1);

            // 6. datetime Type
            Console.WriteLine("===== 6. DateTime type ======");
            // assignment: Exercise all methods of DateTime and show result using Console.WriteLine
            // datetime.now datetime.parsel
            DateTime dt;

            dt = DateTime.Now;
            Console.WriteLine(dt);
            //DateTime.Parse("2018-10-09 am .ToString("yyyy-MM-dd HH:mm:ss"));

            //Console.ReadLine();

            // 7. c# operator
            Console.WriteLine("===== 7. c# operator ======");
            // assignment: go to https://www.programiz.com/csharp-programming/operators#compound-assignment 
            // print out the result. (Copy and Paste is fine)
            int number = 15;

            number += 3;
            Console.WriteLine(number);


            number -= 5;
            Console.WriteLine(number);

            number *= 3;
            Console.WriteLine(number);

            number /= 2;
            Console.WriteLine(number);

            number %= 3;
            Console.WriteLine(number);

            number &= 10;
            Console.WriteLine(number);

            number |= 12;
            Console.WriteLine(number);

            number ^= 14;
            Console.WriteLine(number);

            number <<= 2;
            Console.WriteLine(number);

            number >>= 3;
            Console.WriteLine(number);

            //Console.ReadLine();


            // 8. access modifier
            Console.WriteLine("===== 8. c# access modifier ======");
            // assignment: go to https://www.tutlane.com/tutorial/csharp/csharp-access-modifiers-public-private-protected-internal   
            // print out the result  . (Copy and Paste is fine)
            // NOTE: You may need to create another class file for testing
            // NOTE: among six modifiers, just skip "protected internal" and "private protected"

            //8-1 Public Access Modifier

            Console.WriteLine("** Public Access Modifier Test **");
            User1 u1 = new User1();
            u1.Name = "Suresh Dasari";
            u1.Location = "Hyderabad";
            u1.Age = 32;
            u1.GetUserDetails();
            Console.WriteLine("\nPress Enter Key to Exit..");
            Console.ReadLine();

            //8-2 Private Access Modifier
            Console.WriteLine("** Private Access Modifier Test **");
            User2 u2 = new User2();
            //u2.Name = "Suresh Dasari";
            //u2.Location = "Hyderabad";
            //u2.Age = 32;
            //u2.GetUserDetails();
            Console.WriteLine("Error");
            Console.ReadLine();

            //8-3 Interal Access Modifier
            Console.WriteLine("** Internal Access Modifier Test **");
            User3 u3 = new User3();
            u3.Name = "Suresh Dasari";
            u3.Location = "Hyderabad";
            u3.Age = 32;
            u3.GetUserDetails();
            Console.WriteLine("\nPress Enter Key to Exit..");
            Console.ReadLine();
                                      
        }
    }
}
