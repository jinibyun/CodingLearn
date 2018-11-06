using ConsoleApp.Intermediate;
using System;
using System.Collections.Generic;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        public static void Test()
        {

            // 1. Exercise indexer on file CodingLearn\Csharp\ConsoleApp\Intermediate\ClassTest_Indexer.cs
            // Then create another one simliar to this case on same file
            // 1-1. On client class (Program.cs) use it

            Console.WriteLine("--------Q1 Indexer----------");

            // declare string indexer and print it
            ClassTest_Indexer indexer = new ClassTest_Indexer();
            for (int i = 0; i < 4; i++)
            {
                Console.Write(indexer[i] + " ");
            }
            Console.WriteLine();

            // edit values in the indexer
            indexer[1] = "lazy";
            indexer[3] = "dog";

            // print all values including changed values
            for (int i = 0; i < 4; i++)
            {
                Console.Write(indexer[i] + " ");
            }
            Console.WriteLine();

            // int indexer
            Integer_Indexer intIndexer = new Integer_Indexer();
            for (int i = 0; i < 10; i++)
            {
                Console.Write(intIndexer[i] + " ");
            }
            Console.WriteLine();

            // edit values and print
            for (int i = 0; i < 10; i++)
            {
                intIndexer[i] = i * i;
                Console.Write(intIndexer[i] + " ");
            }
            Console.WriteLine();



            // 2. You are supposed to create a class regarding "ProgrammingLanguage", "Java", "Csharp" and "JavaScript"
            // All programming lanauge (Java, Csharp and Javascript) have following common things:
            // Name, Version Property and GetInfo() method which return some data type of string.
            // 2-1. "ProgrammingLanguage" is base class 

            //ProgrammingLanguage p1 = new ProgrammingLanguage();
            //Console.WriteLine(p1.GetInfo());

            // 2-2. "Java" and "Csharp" are derived class of ProgrammingLanguage
            Csharp csharp = new Csharp();
            Console.WriteLine(csharp.GetInfo());
            Java java = new Java();
            Console.WriteLine(java.GetInfo());

            // 2-3. "JavaScript" is derived class of Java
            // Each language should override GetInfo() return different information
            // JavaScript class has another overloaded method of GetInfo() method, In short, it should override and overload GetInfo method
            // 2-4. On client class (Program.cs) use it

            JavaScript js = new JavaScript();
            Console.WriteLine(js.GetInfo());
            Console.WriteLine(js.GetInfo("Java Script", 100));

            // 3. Once defined above, make "ProgrammingLanguage" abstract class and define another abstract method named "GetSupportedPlatform()"
            // It should return Enum type (You need to define following enumeration)
            // Each derived class must implement it because it is abstract method.
            // In case of Java and JavaScript class, it can be defined virtual and override keyword as well
            // 3-1. On client class (Program.cs) use it

            Console.WriteLine(csharp.GetSupportedPlatform());
            Console.WriteLine(java.GetSupportedPlatform());
            Console.WriteLine(js.GetSupportedPlatform());

            // 4. Once defined above, Create IProgrammingLangulage interface similar to "ProgrammingLanguage" abstract class. In this case, all method should NOT have any public access modifier
            // and only definiton. Make them correct (two methods and two properties)


            // 5. Make another three classes: Python, Ruby and Perl and let them inherit IProgrammingLangulage interface and implement two methods as well
            // It must be built successfully.
            // 5-1. On client class (Program.cs) use it

            Python python = new Python();
            Ruby ruby = new Ruby();
            Perl perl = new Perl();


            // 6. Use IProgrammingLangulage to call two methods.
            // If somecondition then use Python's method, else If other condition, then use Ruby's one, else use Perl's method
            // 6-1. On client class (Program.cs) use it
            Console.WriteLine("Please write a programming language name between Python, Ruby and Perl:");
            string q6 = Console.ReadLine();
            switch (q6.ToLower())
            {
                case "python":
                    Console.WriteLine(python.GetInfo());
                    break;
                case "ruby":
                    Console.WriteLine(ruby.GetInfo());
                    break;
                case "perl":
                    Console.WriteLine(perl.GetInfo());
                    break;
                default:
                    Console.WriteLine("There is no such ");
                    break;
            }

            // 7. Define static class named "Utility" and there define following two methods
            // 7-1. One static method: IsScriptLanguage()  : return type is boolean and parameter is one type of string. If one parameter(such as "Java"), then it will return true of false.
            // Implement any logic inside using switch statement
            Console.WriteLine("Please type any scriptlanguage:");
            string q71 = Console.ReadLine();
            if (Utility.IsScriptLanguage(q71))
            {
                Console.WriteLine(q71 + " is a script lanuage.");
            }
            else
            {
                Console.WriteLine(q71 + " is not a script lanuage.");
            }
            // 7-2. One non-static method: GetYearOfCreation(): return type is datetime and parameter is one type of string. If one parameter (such as "Csharp"), then it will return created date of language
            // Implement any logic inside using switch statement
            // 7-3. On client class (Program.cs) use it

            Console.WriteLine("Please type any language to see its developed date:");
            string q72 = Console.ReadLine();
            Console.WriteLine(Utility.GetYearOfCreation(q72).ToShortDateString());

            // 8. Research on Polymorphism example in c#, and use it (Copy and paste is allowed)
            // ref: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/polymorphism

            // Polymorphism at work #1: a Rectangle, Triangle and Circle
            // can all be used whereever a Shape is expected. No cast is
            // required because an implicit conversion exists from a derived 
            // class to its base class.
            var shapes = new List<Shape>
            {
                new Rectangle(),
                new Triangle(),
                new Circle()
            };

            // Polymorphism at work #2: the virtual method Draw is
            // invoked on each of the derived classes, not the base class.
            foreach (var shape in shapes)
            {
                shape.DescribeShape();
            }

            // it calls the derived class's method
            Rectangle rectangle2 = new Rectangle();
            Shape shape2 = (Shape) rectangle2;
            shape2.DescribeShape();



        }
        public enum Platform
        {
            windows = 1,
            linux = 2,
            unix = 3,
            android = 4,
            iOS = 5
        }

        public class Integer_Indexer
        {
            private int[] integers = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            public int this[int intNum]
            {
                get
                {
                    return integers[intNum];
                }
                set
                {
                    integers[intNum] = value;
                }
            }
        }

        // Polymorphism Example
        // ref: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/polymorphism
        public class Shape
        {
            // A few example members
            public int Height { get; set; }
            public int Width { get; set; }

            // Virtual method
            public virtual void DescribeShape()
            {
                Console.WriteLine("Base Shape");
            }
        }

        class Circle : Shape
        {
            public override void DescribeShape()
            {
                Console.WriteLine("Circle");
            }
        }
        class Rectangle : Shape
        {
            public override void DescribeShape()
            {
                Console.WriteLine("Rectangle");
            }
        }
        class Triangle : Shape
        {
            public override void DescribeShape()
            {
                Console.WriteLine("Triangle");
            }
        }

    }
}
