using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Assignment
{
    class CsharpTest3
    {
        public void Test3()
        {
            Console.WriteLine("== Assignm3 Start ==");
            // 1. Exercise indexer on file CodingLearn\Csharp\ConsoleApp\Intermediate\ClassTest_Indexer.cs
            // Then create another one simliar to this case on same file
            // 1-1. On client class (Program.cs) use it


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

            // 4. Once defined above, Create IProgrammingLangulage interface similar to "ProgrammingLanguage" abstract class. In this case, all method should NOT have any public access modifier
            // and only definiton. Make them correct (two methods and two properties)


            // 5. Make another three classes: Python, Ruby and Perl and let them inherit IProgrammingLangulage interface and implement two methods as well
            // It must be built successfully.
            // 5-1. On client class (Program.cs) use it

            // 6. Use IProgrammingLangulage to call two methods.
            // If somecondition then use Python's method, else If other condition, then use Ruby's one, else use Perl's method
            // 6-1. On client class (Program.cs) use it

            // 7. Define static class named "Utility" and there define following two methods
            // 7-1. One static method: IsScriptLanguage()  : return type is boolean and parameter is one type of string. If one parameter(such as "Java"), then it will return true of false.
            // Implement any logic inside using switch statement
            // 7-2. One non-static method: GetYearOfCreation(): return type is datetime and parameter is one type of string. If one parameter (such as "Csharp"), then it will return created date of language
            // Implement any logic inside using switch statement
            // 7-3. On client class (Program.cs) use it


            // 8. Research on Polymorphism example in c#, and use it (Copy and paste is allowed)
        }
    }

}

