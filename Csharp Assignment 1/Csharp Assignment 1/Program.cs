using System;
using System.Text;

namespace Csharp_Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        public static void Test()
        {
            #region 1. string & stringBuilder
            // 1. string & stringBuilder		
            Console.WriteLine("===== 1. string & stringBuilder ======");

            //string s = "During the development of the .NET Framework";
            //s += "the class libraries were originally written";
            //s += "using a managed code compiler system called";
            //s += "Simple Managed C (SMC)";

            // assignment: change above using StringBuilder
            // 1. StringBuilder class is in different namespace. Therefore, you will have to type "using System.Text" very top of the line.
            // 2. namespace is contatiner where multiple classes reside. Please search c# namespace

            // create a new StringBuilder object and append sentences into it.
            StringBuilder sb = new StringBuilder();
            sb.Append("During the development of the .NET Framework");
            sb.Append("the class libraries were originally written");
            sb.Append("using a managed code compiler system called");
            sb.Append("Simple Managed C (SMC)");

            // print the stringbuilder object's  
            Console.WriteLine(sb);

            #endregion

            #region 2. double array
            // 2. double array
            Console.WriteLine("===== 2. double array ======");
            // assignment: define array type of double, size of 13. Initialize any double value. Then use for-loop statement to print out 13 values.

            double[] dbArray = new double[13];
            Random random = new Random();
            for (int i = 0; i < dbArray.Length; i++)
            {
                dbArray[i] = random.NextDouble() * 100;
            }

            for (int i = 0; i < dbArray.Length; i++)
            {
                Console.WriteLine($"{i}: {dbArray[i]:N2}");
            }

            Console.WriteLine("\n\n");
            #endregion

            #region 3. string type has very useful methods which is used very often.

            // 3. string type has very useful methods which is used very often.
            Console.WriteLine("===== 3. string method ======");
            string s2 = "   South and North Korea will be reunited very soon   ";
            // assignment: using s2 variables, test all methods of string. e.g Console.WriteLine(s2.Trim()); Console.WriteLine(s2.substring(3,6)); ...

            // ref: https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2

            // Clone
            // 	Returns a reference to this instance of String.
            var s2clone = s2.Clone();
            Console.WriteLine("Clone: {0}", s2clone);
            Console.WriteLine();

            // Compare
            Console.WriteLine("Compare 1: {0}", string.Compare(s2, (string)s2clone));   // output: 0
            s2clone = "  abcd123";
            Console.WriteLine("Compare 2: {0}", s2.CompareTo(s2clone));  // output: -1
            Console.WriteLine();

            // Concat
            Console.WriteLine("Concat: {0}", string.Concat(s2, s2clone));
            Console.WriteLine();

            // Copy
            string s2copy = string.Copy(s2);
            Console.WriteLine("Copy: {0}", s2copy);
            Console.WriteLine();

            // Equals
            Console.WriteLine("Equals 1: {0}", string.Equals(s2, s2copy));
            Console.WriteLine("Equals 2: {0}", string.Equals(s2, s2clone));
            Console.WriteLine();

            // Format
            Console.WriteLine(string.Format("s2 format: {0}", s2).ToString());
            Console.WriteLine();

            // ToLower
            Console.WriteLine("ToLower : {0}", s2.ToLower());
            Console.WriteLine();

            // ToUpper
            Console.WriteLine("ToUpper : {0}", s2.ToUpper());
            Console.WriteLine();


            // Trim
            Console.WriteLine("Trim : {0}", s2.Trim());
            Console.WriteLine();

            // Substring
            Console.WriteLine("Substring(19, 5) : {0}", s2.Substring(19, 5));
            Console.WriteLine();

            // Startwith
            Console.WriteLine("Startwith(' ') : {0}", s2.StartsWith(' '));
            Console.WriteLine("Startwith('a') : {0}", s2.StartsWith('a'));
            Console.WriteLine();

            // Split

            Console.WriteLine("Split: ");
            string[] split = s2.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < split.Length; i++)
            {
                Console.WriteLine(split[i].ToString());
            }
            Console.WriteLine();

            // Replace
            Console.WriteLine("Replace : {0}", s2.Replace(' ', '_'));
            Console.WriteLine();

            // Remove
            Console.WriteLine("Remove : {0}", s2.Remove(18, 5));
            Console.WriteLine();

            // Pad
            Console.WriteLine("PadLeft : {0}", s2.PadLeft(100));
            Console.WriteLine();

            // LastIndexOf
            Console.WriteLine("LastIndexOf 's' : {0}", s2.LastIndexOf('s'));
            Console.WriteLine();

            // IndexOfAny
            Console.WriteLine("IndexOfAny 'a', 'b', 'c': {0}", s2.IndexOfAny(new char[] { 'a' }));
            Console.WriteLine();

            // Insert
            Console.WriteLine("Insert : {0}", s2.Insert(20, "★★★"));
            Console.WriteLine();

            // EndsWith
            Console.WriteLine("EndsWith '.' : {0}", s2.EndsWith('.'));
            Console.WriteLine();

            // Contains
            Console.WriteLine("Contains 'K' : {0}", s2.Contains('K'));
            Console.WriteLine("\n\n");


            #endregion

            #region 4. Type Conversion

            // 4. Type Conversion
            Console.WriteLine("===== 4. Type Conversion ======");
            // assingment use the link -->  https://code-maze.com/csharp-basics-type-conversion/ and print out the result. (copy and paste is fine)

            // Implicit Conversion
            Console.WriteLine("\nImplicit Conversion");
            double b = 12.45;
            int a = 10;
            b = b + a;

            Console.WriteLine("double + int into double: {0}, type: {1}", b, b.GetType());

            int c = 21;
            int d = 5;
            double e = c / d;
            
            Console.WriteLine("int + int into double: {0}, type: {1}", e, e.GetType());

            // Explicit Conversion
            Console.WriteLine("\nExplicit Conversion");

            int x = 21;
            int y = 5;

            double z = (double)x / y;

            Console.WriteLine("int + int into double: {0}, type: {1}", z, z.GetType());

            
            // Using the Convert Class
            Console.WriteLine("\nUsing the Convert Class");
            int intValue = 15;
            string stringOb = Convert.ToString(intValue);
            Console.WriteLine("Convert int type value to string type: {0}", stringOb);  //same as intValue.ToString()

            Console.WriteLine("\n\n");


            #endregion

            #region 5. int Type
            // 5. int Type
            Console.WriteLine("===== 5. int type ======");
            // assinment: 
            // 1. what is maximum or minimum of int type. Use some method of int type. eg. int.METHODNAME()
            // 2. What does int.Parse() method do? show example
            // 3. What is the difference between int.Parse() and int.TryParse()? show example.
            // 4. Above rule can be applied to float type as well. show examples

            // question 1
            Console.WriteLine("Maximum of int: " + int.MaxValue);
            Console.WriteLine("Minimum of int: " + int.MinValue);

            // question 2
            // int.Parse() converts the string representation of a number to int type.
            // if the string object contains any leter which is not a number or the number is out of the int type range, it thorws an error.
            Console.WriteLine("int.Parse(): " + int.Parse("5448562"));

            // question 3
            // int.TryParse() convers the string representation of a number to int type and returns the boolean value if it succeeded.
            int intTryParseResult;
            Console.WriteLine("int.TryParse() when succeds: " + int.TryParse("456456", out intTryParseResult));
            Console.WriteLine("out int value of int.TryParse(): " + intTryParseResult);

            int intTryParseResultFail;
            Console.WriteLine("int.TryParse() when fails: " + int.TryParse("456456fds", out intTryParseResultFail));
            Console.WriteLine("out int value of int.TryParse(): " + intTryParseResultFail);


            // question 4
            // float
            Console.WriteLine();
            Console.WriteLine("Maximum of float: " + float.MaxValue);
            Console.WriteLine("Minimum of float: " + float.MinValue);
            Console.WriteLine("float.Parse(): " + float.Parse("5151.51516"));

            //  float TryParse
            float floatTryParseResult;
            Console.WriteLine("float.TryParse(): " + float.TryParse("54.1111", out floatTryParseResult));
            Console.WriteLine("out float value of float.TryParse(): " + floatTryParseResult);

            int floatTryParseResultFail;
            Console.WriteLine("int.TryParse() when fails: " + int.TryParse("456456f.1561.565", out floatTryParseResultFail));
            Console.WriteLine("out int value of int.TryParse(): " + floatTryParseResultFail);



            Console.WriteLine("\n\n");
            #endregion

            #region  6. datetime Type
            // 6. datetime Type
            Console.WriteLine("===== 6. DateTime type ======");
            // assignment: Exercise all methods of DateTime and show result using Console.WriteLine

            DateTime date1 = new DateTime(2018, 10, 07, 5, 00, 00);
            DateTime date2 = new DateTime(2011, 2, 28, 2, 44, 33);
            TimeSpan ts1 = new TimeSpan(10000, 10, 10, 10); // days; hours; minutes; seconds;
            
            Console.WriteLine("Date1: " + date1);
            Console.WriteLine("Date2: " + date2);
            Console.WriteLine("yyyy/MM/dd HH:mm:ss format: " + date1.ToString("yyyy/MM/dd HH:mm:ss"));
            Console.WriteLine("TimeSpan: " + ts1);

            Console.WriteLine("Add(TimeSpan): " + date1.Add(ts1));
            Console.WriteLine("AddYears(10000): " + date1.AddYears(1000));
            Console.WriteLine("AddMonths(13): " + date1.AddMonths(13));
            Console.WriteLine("AddDays(365): " + date1.AddDays(365));
            Console.WriteLine("AddHours(10000): " + date2.AddHours(10000));
            Console.WriteLine("AddMinutes(123456): " + date1.AddMinutes(123456));
            Console.WriteLine("AddSeconds(36000): " + date1.AddSeconds(36000));
            Console.WriteLine("AddTicks(10000): " + date1.AddTicks(10000));
            Console.WriteLine("CompareTo(date1): " + date1.CompareTo(date1));
            Console.WriteLine("CompareTo(date2): " + date1.CompareTo(date2));
            Console.WriteLine("Subtract(date2): " + date1.Subtract(date2));
            Console.WriteLine("LocalTime(): " + date1.ToLocalTime());
            Console.WriteLine("ToFileTime(): " + date1.ToFileTime());
            Console.WriteLine("ToLongDateString: " + date1.ToLongDateString());
            Console.WriteLine("ToShortDateString: " + date1.ToShortDateString());


            Console.WriteLine("\n\n");
            #endregion

            #region 7. c# operator
            // 7. c# operator
            Console.WriteLine("===== 7. c# operator ======");
            // assignment: go to https://www.programiz.com/csharp-programming/operators#compound-assignment 
            // print out the result. (Copy and Paste is fine)

            /*
             +=	Addition Assignment	x += 5	x = x + 5
             -=	Subtraction Assignment	x -= 5	x = x - 5
             *=	Multiplication Assignment	x *= 5	x = x * 5
             /=	Division Assignment	x /= 5	x = x / 5
             %=	Modulo Assignment	x %= 5	x = x % 5
             &=	Bitwise AND Assignment	x &= 5	x = x & 5
             |=	Bitwise OR Assignment	x |= 5	x = x | 5
             ^=	Bitwise XOR Assignment	x ^= 5	x = x ^ 5
             <<=	Left Shift Assignment	x <<= 5	x = x << 5
             >>=	Right Shift Assignment	x >>= 5	x = x >> 5
             =>	Lambda Operator	x => x*x	Returns x*x
             */

            int number = 10;

            number += 5;
            Console.WriteLine(number);  // number = 15;

            number -= 3;
            Console.WriteLine(number);  // number = 12

            number *= 2;
            Console.WriteLine(number);  // number = 24

            number /= 3;
            Console.WriteLine(number);  // number = 8

            number %= 3;
            Console.WriteLine(number);  // number = 2

            number &= 10;
            Console.WriteLine(number);  // number = (binary) 0010 & 1010 = 0010 = (decimal) 2

            number |= 14;
            Console.WriteLine(number);  // number = (binary) 0010 | 1110 = 1110 = (decimal) 14

            number ^= 12;
            Console.WriteLine(number);  // number = (binary) 1110 ^ 1100 = 0010 = (decimal) 2
            
            number <<= 2;
            Console.WriteLine(number);  // number = 0010 << 2 = 1000 = (decimal) 8

            number >>= 3;
            Console.WriteLine(number);  // number = 1000 >> 3 = 0001 = (decimal) 1

            Console.WriteLine("\n\n");
            #endregion

            #region 8. access modifier
            // 8. access modifier
            Console.WriteLine("===== 7. c# access modifier ======");
            // assignment: go to https://www.tutlane.com/tutorial/csharp/csharp-access-modifiers-public-private-protected-internal   
            // print out the result  . (Copy and Paste is fine)
            // NOTE: You may need to create another class file for testing
            // NOTE: among six modifiers, just skip "protected internal" and "private protected"

            // public
            // it is accessible from anywhere
            Console.WriteLine("1. public user");
            PpublicUser u1 = new PpublicUser();

            u1.Name = "Suresh Dasari";
            u1.Location = "Hyderabad";
            u1.Age = 32;
            u1.GetUserDetails();
            Console.WriteLine("\n");

            // private
            // Access is denied because it is limited to the containg type only
            Console.WriteLine("2. private user");
            PrivateUser u2 = new PrivateUser();
            //u2.Name = "Suresh Dasari";
            //u2.Location = "Hyderabad";
            //u2.Age = 32;
            //u2.GetUserDetails();
            Console.WriteLine("\n");

            // protected
            // Access is denied because it is limited to the containg type or the types derieved from the containning class
            Console.WriteLine("3. protected user");
            ProtectedUser u3 = new ProtectedUser();
            //u3.Name = "Suresh Dasari";
            //u3.Location = "Hyderabad";
            //u3.Age = 32;
            //u3.GetUserDetails();
            Console.WriteLine("\n");

            // internal
            // It is limited to current assembly
            Console.WriteLine("4. internal user");
            InternalUser u4 = new InternalUser();
            u4.Name = "Suresh Dasari";
            u4.Location = "Hyderabad";
            u4.Age = 32;
            u4.GetUserDetails();
            Console.WriteLine("\n");

            #endregion
        }

        // User class for Question 8
        //public modifier is used to specify that access is not restricted, 
        //so the defined type or member can be accessed by any other code in current assembly or another assembly that references it.
        class PpublicUser
        {

            public string Name;

            public string Location;

            public int Age;

            public void GetUserDetails()

            {

                Console.WriteLine("Name: {0}", Name);

                Console.WriteLine("Location: {0}", Location);

                Console.WriteLine("Age: {0}", Age);

            }
        }

        //private modifier is used to specify that access is limited to the containing type
        //so the defined type or member can only be accessed by the code in same class or structure.
        class PrivateUser
        {

            private string Name;

            private string Location;

            private int Age;

            private void GetUserDetails()

            {

                Console.WriteLine("Name: {0}", Name);

                Console.WriteLine("Location: {0}", Location);

                Console.WriteLine("Age: {0}", Age);

            }
        }

        // protected modifier is used to specify that access is limited to the containing type
        //or types derived from the containing class so the type or member can only be accessed by code in the same class or in a derived class.
        class ProtectedUser
        {

            protected string Name;

            protected string Location;

            protected int Age;

            protected void GetUserDetails()

            {

                Console.WriteLine("Name: {0}", Name);

                Console.WriteLine("Location: {0}", Location);

                Console.WriteLine("Age: {0}", Age);

            }
        }

        //internal modifier is used to specify that access is limited to current assembly 
        //so the type or member can be accessed by any code in the same assembly, but not from other assembly.
        class InternalUser
        {

            internal string Name;

            internal string Location;

            internal int Age;

            internal void GetUserDetails()

            {

                Console.WriteLine("Name: {0}", Name);

                Console.WriteLine("Location: {0}", Location);

                Console.WriteLine("Age: {0}", Age);

            }
        }

    }

}
