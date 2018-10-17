using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Assignment
{
    class CsharpTest2
    {
        public void Test2()
        {
            Console.WriteLine("== Assignment2 Start ==");
            // 1. For Loop
            // Loop 1 through 100, get sum only for odd number. 

            Console.WriteLine("***1. For Loop ***");
            int sum1 = 0;

            for (int n = 1; n < 100; n++)
            {
                if (n % 2 != 0)
                {
                    sum1 = sum1 + n;

                }
            }

            Console.WriteLine("For Loop Sum(1- 100 odd number) -->" + sum1);
            //Console.ReadLine();

            // 2. While Loop
            // Implement #1 using while loop

            Console.WriteLine("*** 2. while Loop ***");
            int sum2 = 0;
            int count = 1;

            while (count < 100)
            {
                if (count % 2 != 0)
                {
                    sum2 = sum2 + count;

                }
                count++;
            }

            Console.WriteLine("While Loop Sum(1- 100 odd number) -->" + sum2);
            //Console.ReadLine();

            // 3. Loop using foreach statement and Console.WriteLine
            // However, show number only once. eg. There are three 9, it should NOT duplicate	

            Console.WriteLine("*** 3. foreach ***");
            int[] oddArray = new int[] { 1, 3, 3, 3, 5, 7, 9, 9, 9, 11, 11, 13, 15, 17, 17, 19, 21 };

            var no_dupes = oddArray.Distinct();

            foreach (int i in no_dupes)
                Console.WriteLine(i + ",");

            // 4. var keyword and dynamic keyword
            // Both are being used define data type. Research on them and write example
            // Then, explain difference between them

            Console.WriteLine("*** 4. var keyword and dynamic keyword ***");
            Console.WriteLine("A variable declared as var can only be used locally");
            Console.WriteLine("dynamic variables can be passed in as params to function");

            var name1 = "Jane K";
            //name1 = 11; Error

            dynamic name2 = "Jane K";
            name2 = 22; // No Error

            // 5. Switch statement. Research on them and write example

            Console.WriteLine("*** 5. switch ***");

            //Console.Write("Please enter month!! ");

            //int month = int.Parse(Console.ReadLine());

            int month = 10;
                                          
            switch (month)
            {
                case 12:
                case 1:
                case 2:
                    Console.WriteLine("Winter!");
                    break;
                case 3:
                case 4:
                case 5:
                    Console.WriteLine("Spring!");
                    break;
                case 6:
                case 7:
                case 8:
                    Console.WriteLine("Summer!");
                    break;
                case 9:
                case 10:
                case 11:
                    Console.WriteLine("Autumn!");
                    break;
                default:
                    Console.WriteLine("Input Error !!");
                    break;
            }


             // 6. What is ref keyword in parameter of method? What is out keyword in parameter of method?
            // Research on them. Write example

            Console.WriteLine("*** 6. ref and out ***");
            Console.WriteLine("The keywords ref and out are used to pass arguments within a method or function ");
            Console.WriteLine("Both indicate that an argument / parameter is passed by reference.");
            Console.WriteLine("Ref:The parameter or argument must be initialized first before it is passed to ref.");
            Console.WriteLine("Out:It is not compulsory to initialize a parameter or argument before it is passed to an out.");

            int i2 = 1;
            Console.WriteLine("Previous value of integer i(ref):" + i2.ToString());
            string test1 = GetNextName(ref i2);
            Console.WriteLine("Current value of integer i(ref):" + i2.ToString());

            int i3 = 0;
            Console.WriteLine("Previous value of integer i(out):" + i3.ToString());
            string test2 = GetNextNameByOut(out i3);
            Console.WriteLine("Current value of integer i(out):" + i3.ToString());

            //Console.ReadLine();

            // 7. params keyword
            // I want to call method this way:
            // using params keyword, define method TestParams()
            //methodTest.TestParams("abc", "xyz", "www", "http", "This", "That");

            Console.WriteLine("*** 7. params keyword ***");
            string[] names = { "abc", "xyz", "www", "http", "This", "That" };
            TestParams("James","Linda");
            TestParams("Joy");
            TestParams(names);
            //Console.ReadLine();


            // 8. ? operator
            // using ? operator, rewrite below with one line
            //bool IsDeveloper = true;
            //if (someVariable == "developer")
            //{
            //    IsDeveloper = true;
            //}
            //else
            //{
            //    IsDeveloper = false;
            //}

            Console.WriteLine("*** 8. ? operator ***");
            bool IsDeveloper = true;
            string someVariable = null;
            IsDeveloper = (someVariable == "developer") ? true : false;

            Console.WriteLine("IsDeveloper : " + IsDeveloper);
            //Console.ReadLine();

            // 9. using ?? operator, rewrite below with one line

            Console.WriteLine("*** 9. ?? operator ***");
            DateTime? dt1 = null;
            //if (dt1 == null)
            //{
            //    dt1 = DateTime.Now;
            //}

            dt1= dt1?? DateTime.Now;
            Console.WriteLine("DateTime : " + dt1);
            //Console.ReadLine();

            // 10. Define Class Elements about following Product class
            //public class Product(
            Console.WriteLine("**10. product class***");
            // 1. Define member 5 fields
            // One of them. Define 4 more with private access modifier
            //private string productName;

            // 2.
            // Define constructor and initialize above 5 field with parameter


            // 3. Let's define there are two kinds of product status: InStock, OutofStock
            // Define these two as enum type


            // 4. 5 field should be accessed through public property. Define 5 public property with get and set

            // 5. Define three method
            // 5-1. first method should return string array with no parameter. Any method signature would be fine


            // 5-2. second method and third method should be overloaded
            // both methods should return price as float type.
            // One method should have parameter type of string 
            // Other method should have parameter type of string and type of datetime

            // 11. Once Product class is defined, then another class should call this product class to call three method and use property. Calling logic should be inside "program.cs" (This could be another class)
            // Let's make it this way

            // just below AssingmentTest() method. And call this method for testing
            //private static void AssignmentTest2()
            //{
            //    var product = new Product();
            //    // call property or method
            //}



        }
        public static string GetNextName(ref int id)
        {
            string returnText = "Next-" + id.ToString();
            id += 1;
            return returnText;
        }

        public static string GetNextNameByOut(out int id)
        {
            id = 1;
            string returnText = "Next-" + id.ToString();
            return returnText;
        }

        public static void  TestParams(params string[] people)
        {
            foreach(string person in people)
                Console.WriteLine("{0}", person);

        }
        


    }
}
    
