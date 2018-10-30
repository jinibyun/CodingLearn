using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Assignment
{
    class CsharpTest3
    {
        // 1. Exercise indexer on file CodingLearn\Csharp\ConsoleApp\Intermediate\ClassTest_Indexer.cs
        // Then create another one simliar to this case on same file
        // 1-1. On client class (Program.cs) use it
        public class AssignTest_Indexer
        {
            string[] words = "My pet's name is monky".Split();

            public string this[int wordNum]      // indexer
            {
                get { return words[wordNum]; }
                set { words[wordNum] = value; }
            }
        }

        // 2. You are supposed to create a class regarding "ProgrammingLanguage", "Java", "Csharp" and "JavaScript"
        // All programming lanauge (Java, Csharp and Javascript) have following commong things:
        // Name, Version Property and GetInfo() method which return some data type of string.
        // 2-1. "ProgrammingLanguage" is base class 
        // 2-2. "Java" and "Csharp" are derived class of ProgrammingLanguage
        // 2-3. "JavaScript" is derived class of Java
        // Each language should override GetInfo() return different information
        // JavaScript class has another overloaded method of GetInfo() method, In short, it should override and overload GetInfo method
        // 2-4. On client class (Program.cs) use it


        // 3. Once defined above, make "ProgrammingLanguage" abstract class and define another abstract method named "GetSupportedPlatform()"
        // It should return Enum type (You need to define following enumeration)
        //public enum Platform
        //{
        //    windows = 1,
        //    linux = 2,
        //    unix = 3,
        //    android = 4,
        //    iOS = 5
        //}

        // Each derived class must implement it because it is abstract method.
        // In case of Java and JavaScript class, it can be defined virtual and override keyword as well
        // 3-1. On client class (Program.cs) use it

        public abstract class ProgrammingLanguage
        {
            public string name = "";
            public string version = "";
            private Platform type;

            public virtual string getInfo()
            {
                return "Programming Language : " + name + version;
            }

            public abstract double Cost();

            public void setType(Platform type)
            {
                this.type = type;
            }

            public Platform GetSurportedPlatform()
            {
                return this.type;
            }
        }

        public enum Platform
        {
            windows = 1,
            linux = 2,
            unix = 3,
            android = 4,
            iOS = 5
        }

        public class Csharp : ProgrammingLanguage
        {
            public Csharp(Platform pType)
            {
                setType(pType);
            }

            public override string getInfo()
            {
                return "Programming Language : " + name + version;
            }

            public override double Cost()
            {
                return 100;
            }
        }

        public class HTML : ProgrammingLanguage
        {
            public HTML(Platform pType)
            {
                setType(pType);
            }
            public override double Cost()
            {
                return 150;
            }

        }

        public class CSS : ProgrammingLanguage
        {
            public CSS(Platform pType)
            {
                setType(pType);
            }
            public override double Cost()
            {
                return 200;
            }

        }

        public abstract class Java : ProgrammingLanguage
        {
        }

        public class Javascript : Java
        {
            ProgrammingLanguage language;

            public Javascript(ProgrammingLanguage language)
            {
                this.language = language;

            }

            public override string getInfo()

            {
                return language.getInfo() + ",From Java";
            }

            public override double Cost()
            {
                double cost = language.Cost();
                if (GetSurportedPlatform() == Platform.windows) cost += 100;
                else if (GetSurportedPlatform() == Platform.linux) cost += 200;
                else if (GetSurportedPlatform() == Platform.android) cost += 150;
                return cost;
            }

        }

        // 4. Once defined above, Create IProgrammingLangulage interface similar to "ProgrammingLanguage" abstract class. In this case, all method should NOT have any public access modifier
        // and only definiton. Make them correct (two methods and two properties)


        // 5. Make another three classes: Python, Ruby and Perl and let them inherit IProgrammingLangulage interface and implement two methods as well
        // It must be built successfully.
        // 5-1. On client class (Program.cs) use it

        // 6. Use IProgrammingLangulage to call two methods.
        // If somecondition then use Python's method, else If other condition, then use Ruby's one, else use Perl's method
        // 6-1. On client class (Program.cs) use it

        public class Description
        {
            public override string ToString()
            {
                return "Thank You";
            }
        }


        public interface IProgrammingLanguage
        {
            void GetInfo(string imsg);
            void Gift(Description d);
            void Credit(Description d);
        }

        public class Python : IProgrammingLanguage
        {

            public void GetInfo(string message)
            {
                Console.WriteLine("{0}{1}", DateTime.Now.ToLocalTime(), message);
            }

            public void Gift(Description d)
            {
                Console.WriteLine(string.Format("This is a gift for PyThon.....{0}", d.ToString()));
            }

            public void Credit(Description d)
            {
                Console.WriteLine(string.Format("This is a credit for Python.....{0}", d.ToString()));
            }

        }

        public class Ruby : IProgrammingLanguage
        {
            public void GetInfo(string message)
            {
                Console.WriteLine("{0}{1}", DateTime.Now.ToLocalTime(), message);
            }

            public void Gift(Description d)
            {
                throw new NotImplementedException();
            }

            public void Credit(Description d)
            {
                Console.WriteLine(string.Format("This is a credit for Ruby.....{0}", d.ToString()));
            }
        }

        public class Pearl : IProgrammingLanguage
        {
            public void GetInfo(string message)
            {
                Console.WriteLine("{0}{1}", DateTime.Now.ToLocalTime(), message);
            }

            public void Gift(Description d)
            {
                throw new NotImplementedException();
            }

            public void Credit(Description d)
            {
                Console.WriteLine(string.Format("This is a credit fot Pearl.....{0}", d.ToString()));
            }
        }

        // 7. Define static class named "Utility" and there define following two methods
        // 7-1. One static method: IsScriptLanguage()  : return type is boolean and parameter is one type of string. If one parameter(such as "Java"), then it will return true of false.
        // Implement any logic inside using switch statement
        // 7-2. One non-static method: GetYearOfCreation(): return type is datetime and parameter is one type of string. If one parameter (such as "Csharp"), then it will return created date of language
        // Implement any logic inside using switch statement
        // 7-3. On client class (Program.cs) use it
        public static class Utility
        {
            public static bool isScriptLanguage(string lan)
            {
                bool done;

                switch (lan)
                {
                    case "Java":
                        Console.WriteLine("Java is not a script language");
                        done = false;
                        break;
                    case "JavaScript":
                        Console.WriteLine("Javascript is a script language");
                        done = true;
                        break;
                    default:
                        Console.WriteLine("This is not a script language");
                        done = false;
                        break;
                }

                return done;
            }

            public static DateTime GetYearOfCreation(string lan)
            {
                DateTime dt = DateTime.Today;
                DateTime calcYear;

                switch (lan)
                {
                    case "Csharp":

                        calcYear = dt.AddYears(-1994);
                        Console.WriteLine("Csharp years: ");
                        break;
                    case "Java":
                        Console.WriteLine("Java years: ");
                        calcYear = dt.AddYears(-2000);
                        break;
                    default:
                        calcYear = dt.AddYears(-2018);
                        break;
                }
                return calcYear;
            }
        }

        // 8. Research on Polymorphism example in c#, and use it (Copy and paste is allowed)

        public class Printdata
        {
            public void print(int i)
            {
                Console.WriteLine("Printing int: {0}", i);
            }
            public void print(double f)
            {
                Console.WriteLine("Printing float: {0}", f);
            }
            public void print(string s)
            {
                Console.WriteLine("Printing string: {0}", s);
            }

        }

        public abstract class Shape
        {
            public abstract int area();
        }

        public class Rectangle : Shape
        {
            private int length;
            private int width;

            public Rectangle(int a = 0, int b = 0)
            {
                length = a;
                width = b;
            }
            public override int area()
            {
                Console.WriteLine("Rectangle class area :");
                return (width * length);
            }
        }
    }
}
    

