using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            AssignmentTest2();
            Console.ReadKey();
        }

        public static void Test()
        {
            // Assingments can be composed of several classes and several files
            // It is up to you, but please work on them under folder named "Assignment" on visual studio project for easier access later

            // 1. For Loop
            // Loop 1 through 100, get sum only for odd number. 
            int oddSum1 = 0;
            for (int i = 0; i < 100; i++)
            {
                if (i % 2 != 0)
                {
                    oddSum1 += i;
                }
            }
            Console.WriteLine("Q1. Odd sum from 1 to 100: " + oddSum1);
            Console.WriteLine("\n");


            // 2. While Loop
            // Implement #1 using while loop

            int oddSum2 = 0;
            int countQ2 = 0;
            while (countQ2 < 100)
            {
                if (countQ2 % 2 != 0)
                {
                    oddSum2 += countQ2;
                }
                countQ2++;
            }
            Console.WriteLine("Q2. Odd sum from 1 to 100: " + oddSum2);
            Console.WriteLine("\n");

            // 3. Loop using foreach statement and Console.WriteLine
            // However, show number only once. eg. There are three 9, it should NOT duplicate	
            int[] oddArray = new int[] { 1, 3, 3, 3, 5, 7, 9, 9, 9, 11, 11, 13, 15, 17, 17, 19, 21 };
            int[] dpArray = new int[oddArray.Length];
            int countQ3 = 0;
            foreach (int i in oddArray)
            {
                if (!dpArray.Contains(i))
                {
                    Console.WriteLine("Q3 print odd number without duplicate: " + i);
                    dpArray[countQ3] = i;
                    countQ3++;
                }
            }
            Console.WriteLine("\n");

            //3-2 Using List
            List<int> dpList = new List<int>();
            foreach (int i in oddArray)
            {
                if (!dpList.Contains(i))
                {
                    Console.WriteLine("Q3-2 print odd number without duplicate: " + i);
                    dpList.Add(i);
                }
            }
            Console.WriteLine("\n");


            // 4. var keyword and dynamic keyword
            // Both are being used define data type. Research on them and write example
            // Then, explain difference between them

            // var: 
            // it is an implicitly typed variable that is inferred by the compiler.
            // it cannot assign another different type not same with the original variable type.

            // dynamic:
            // its type will be keeped as "dynamic" continually.
            // it is not resolved until runtime.

            var q4Var = 15;
            // q4Var = "Asdf";  compile error since the data types do not match
            Console.WriteLine("Q4 var keyword and dynamic keyword");
            Console.WriteLine("var's type: " + q4Var.GetType() + "with" + q4Var);
            dynamic q4Dynamic = 20;
            Console.WriteLine("dynamic's first type: " + q4Dynamic.GetType() + " with " + q4Dynamic);
            q4Dynamic = "Asdf";
            Console.WriteLine("dynamic's second type: " + q4Dynamic.GetType() + " with " + q4Dynamic);
            Console.WriteLine("\n");


            // 5. Switch statement. Research on them and write example

            // Switch statement compares a variable with each cases' value.
            // If a case value and the variable's value match, execute the stements in the case.
            // When there is default, the statements in the default will be run.
            // Multiple cases can share the same statements if the cases except the last case do not have any statements including break. (See case 'N' and 'Z')
            Console.WriteLine("Q5. Switch statement");

            SortedDictionary<String, char> q5People = new SortedDictionary<string, char>();
            q5People.Add("John", 'M');
            q5People.Add("Jane", 'F');
            q5People.Add("James", 'N');
            q5People.Add("Jonathan", 'Z');
            q5People.Add("Jose", 'D');

            foreach (var p in q5People)
            {
                StringBuilder q5StringBuilder = new StringBuilder(p.Key + " is ");
                switch (p.Value)
                {
                    case 'M':
                        q5StringBuilder.Append("a male ");
                        break;
                    case 'F':
                        q5StringBuilder.Append("a female ");
                        break;
                    case 'N':
                    case 'Z':
                        q5StringBuilder.Append("a neutral ");
                        break;
                    default:
                        q5StringBuilder.Append("not a ");
                        break;
                }
                q5StringBuilder.Append("person.");
                Console.WriteLine(q5StringBuilder.ToString());
            }
            Console.WriteLine("\n");


            // 6. What is ref keyword in parameter of method? What is out keyword in parameter of method?
            // Research on them. Write example

            // ref
            // Method with ref keyword receives a reference instead of its value.
            // When the value of the ref argument is affected, and the real ref variable is changed.
            // The ref arguments must be initialized before they pass the method parameter.
            int q6a = 0;
            int q6b = 0;
            int q6c;
            Q6MethodTest(q6a, ref q6b, out q6c);
            Console.WriteLine("Q6a common parameter: " + q6a);
            Console.WriteLine("Q6b ref parameter: " + q6b);
            Console.WriteLine("Q6c out parameter: " + q6c);
            Console.WriteLine("\n");


            // 7. params keyword
            // I want to call method this way:
            // using params keyword, define method TestParams()
            Q7ParamsTest("abc", "xyz", "www", "http", "This", "That");
            Console.WriteLine("\n");


            // 8. ? operator
            // using ? operator, rewrite below with one line
            bool IsDeveloper = true;
            /*
            if (jobPosition1 == "developer")
            {
                IsDeveloper = true;
            }
            else
            {
                IsDeveloper = false;
            }*/
            Console.WriteLine("Q8. ? operator");
            string jobPosition1 = "developer";
            IsDeveloper = (jobPosition1 == "developer") ? true : false;
            Console.WriteLine(jobPosition1 + " is developer: " + IsDeveloper);

            string jobPosition2 = "engineer";
            IsDeveloper = (jobPosition2 == "developer") ? true : false;
            Console.WriteLine(jobPosition2 + " is developer: " + IsDeveloper);
            Console.WriteLine("\n");


            // 9. ?? operator
            // using ?? operator, rewrite below with one line
            DateTime? dt1 = null;
            /*
            if (dt1 == null)
            {
                dt1 = DateTime.Now;
            }*/
            dt1 = dt1 ?? DateTime.Now;
            Console.WriteLine("Q9. ?? operator with DateTime: " + dt1.ToString());
            Console.WriteLine("\n");



        }

        // 10. Define Class Elements about following Product class
        public class Product
        {
            // 1. Define member 5 fields
            // One of them. Define 4 more with private access modifier
            private string productName;
            private string productCategory;
            private string productCompany;
            private DateTime productManufactureDate;
            private float productPrice;

            // 2.
            // Define constructor and initialize above 5 field with parameter
            public Product(string name, string category, string company, DateTime date, float price)
            {
                productName = name;
                productCategory = category;
                productCompany = company;
                productManufactureDate = date;
                productPrice = price;
            }


            // 3. Let's define there are two kinds of product status: InStock, OutofStock
            // Define these two as enum type
            public enum StockStatus
            {
                InStock,
                OutofStock
            }

            // 4. 5 field should be accessed through public property. Define 5 public property with get and set
            public string Name
            {
                get { return productName; }
                set { productName = value; }
            }
            public string Category
            {
                get { return productCategory; }
                set { productCategory = value; }
            }
            public string Company
            {
                get { return productCompany; }
                set { productCompany = value; }
            }
            public DateTime Date
            {
                get { return productManufactureDate; }
                set { productManufactureDate = value; }
            }
            public float Price
            {
                get { return productPrice; }
                set { productPrice = value; }
            }


            // 5. Define three method
            // 5-1. first method should return string array with no parameter. Any method signature would be fine
            public string[] getDetail()
            {
                string[] detail = new string[5];
                detail[0] = "Name: " + productName;
                detail[1] = "Category: " + productCategory;
                detail[2] = "Company: " + productCompany;
                detail[3] = "Manufacture Date: " + productManufactureDate;
                detail[4] = "Price: " + productPrice;
                return detail;
            }


            // 5-2. second method and third method should be overloaded
            // both methods should return price as float type.
            // One method should have parameter type of string 
            // Other method should have parameter type of string and type of datetime

            public float getPrice(string country)
            {
                float taxRate = 0;
                switch (country)
                {
                    case "Canada":
                        taxRate = 0.13f;
                        break;
                    case "Korea":
                        taxRate = 0.08f;
                        break;
                    case "China":
                        taxRate = 0.09f;
                        break;
                    default:
                        taxRate = 0.2f;
                        break;
                }
                return productPrice * (1 + taxRate);
            }

            public float getPrice(string country, DateTime date)
            {
                float taxRate = 0;
                switch (country)
                {
                    case "Canada":
                        taxRate = 0.13f;
                        break;
                    case "Korea":
                        taxRate = 0.08f;
                        break;
                    case "China":
                        taxRate = 0.09f;
                        break;
                    default:
                        taxRate = 0.2f;
                        break;
                }

                float discountRate = 0;
                if (date > productManufactureDate + new TimeSpan(365, 0, 0, 0))
                {
                    discountRate = 0.5f;
                }

                return productPrice * (1 + taxRate) * (1 - discountRate);
            }

        }
        // Q6 Method
        // it recieves a normal argument, ref argument and out argument
        public static void Q6MethodTest(int a, ref int b, out int c)
        {
            a = 1000;
            b = 2000;
            c = 3000;
        }

        // Q7 Method
        // param
        // params keyword
        public static void Q7ParamsTest(params string[] values)
        {
            StringBuilder sb = new StringBuilder("Q7. Test Params method: ");
            foreach (var member in values)
            {
                sb.Append(member + ", ");
            }
            sb.Remove(sb.Length - 2, 2);
            Console.WriteLine(sb);
        }

        // 11. Once Product class is defined, then another class should call this product class to call three method and use property. Calling logic should be inside "program.cs" (This could be another class)
        // Let's make it this way

        // just below AssingmentTest() method. And call this method for testing
        private static void AssignmentTest2()
        {
            Console.WriteLine("Q10-11    Product class test");
            var product = new Product("Galaxy 23", "SmartPhone", "Samsung", new DateTime(2018, 1, 23), 1111.11f);

            // call property or method
            Console.WriteLine("Check Properties");
            Console.WriteLine("Name: " + product.Name);
            Console.WriteLine("Company: " + product.Company);
            Console.WriteLine("Category: " + product.Category);
            Console.WriteLine("Date: " + product.Date);
            Console.WriteLine("Price: $" + product.Price);

            Console.WriteLine("\nCheck Methods");
            Console.WriteLine(product.getDetail());
            Console.WriteLine("Canada Price: $" + product.getPrice("Canada"));
            Console.WriteLine("Korea Price: $" + product.getPrice("Korea"));
            Console.WriteLine("Japan Price: $" + product.getPrice("Japan"));
            Console.WriteLine("Canada Price when " + DateTime.Now.ToShortDateString() + ": $" + product.getPrice("Canada", DateTime.Now));
            Console.WriteLine("Canada Price when " + (product.Date + new TimeSpan(365, 0, 0, 0)).ToShortDateString() + ": $" + product.getPrice("Canada", product.Date + new TimeSpan(366, 0, 0, 0)));

        }
    }


}