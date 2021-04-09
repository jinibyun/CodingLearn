using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqLearn.Data;
namespace LinqLearn
{
    public class _02linqMethod
    {
        public void Test()
        {
            //Method syntax (also known as fluent syntax)

            // Student collection
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };

            // LINQ Method Syntax to find out teenager students
            var result = studentList.Where(s => s.Age > 12 && s.Age < 20)
                                              .ToList<Student>();

            foreach (var m in result)
            {
                Console.WriteLine(m.StudentName);
            }
        }
    }
}
