using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqLearn
{
    public class _01linqQuery
    {
        public void Test()
        {
            // string collection
            IList<string> stringList = new List<string>() {
                "C# Tutorials",
                "VB.NET Tutorials",
                "Learn C++",
                "MVC Tutorials" ,
                "Java"
            };

            // LINQ Query Syntax
            var result = from s in stringList
                         where s.Contains("Tutorials")
                         select s;

            foreach(var m in result)
            {
                Console.WriteLine(m);
            }
        }
    }
}
