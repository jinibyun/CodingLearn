using LinqLearn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqLearn
{
    public class _03linqOperator
    {
        public void Test()
        {
            // 1. order by desc
            Console.WriteLine("=============== order by ==============");
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 19, StandardID = 1 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 , StandardID = 1 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25, StandardID = 2  } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 25, StandardID = 2 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };

            var result = studentList.OrderByDescending(s => s.StudentName);

            foreach (var m in result)
            {
                Console.WriteLine(m.StudentName);
            }

            // 2. group by
            Console.WriteLine("=============== group by ==============");

            var groupedResult = from s in studentList
                                group s by s.Age;

            //iterate each group        
            foreach (var ageGroup in groupedResult)
            {
                Console.WriteLine("Age Group: {0}", ageGroup.Key); //Each group has a key 

                foreach (Student s in ageGroup) // Each group has inner collection
                    Console.WriteLine("Student Name: {0}", s.StudentName);
            }

            // 3. inner join
            Console.WriteLine("=============== join ==============");
            IList<Standard> standardList = new List<Standard>() {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };

            var innerJoin = from s in studentList // outer sequence
                            join st in standardList //inner sequence 
                            on s.StandardID equals st.StandardID // key selector 
                            select new
                            { // result selector 
                                StudentName = s.StudentName,
                                StandardName = st.StandardName
                            };

            foreach (var m in innerJoin)
            {
                Console.WriteLine(m.StudentName + " : " + m.StandardName);
            }

            // 3-1. left outer join
            Console.WriteLine("=============== left outer join ==============");
            var studentsWithStandard = from stad in standardList
                                       join s in studentList
                                       on stad.StandardID equals s.StandardID
                                       into sg
                                       from std_grp in sg
                                       orderby stad.StandardName, std_grp.StudentName
                                       select new
                                       {
                                           StudentName = std_grp.StudentName,
                                           StandardName = stad.StandardName
                                       };


            foreach (var group in studentsWithStandard)
            {
                Console.WriteLine("{0} is in {1}", group.StudentName, group.StandardName);
            }

            // 4. select
            Console.WriteLine("=============== select ==============");
            var selectResult = studentList.Select(s => new {
                Name = s.StudentName,
                Age = s.Age
            });

            foreach (var m in selectResult)
            {
                Console.WriteLine(m.Name + " : " + m.Age);
            }

            // 5. intersect, except
            // Intersect, except and union extension method requires two collections.
            // note: The Intersect, except and union operator is Not Supported in C# & VB.Net Query syntax.
            Console.WriteLine("=============== intersect & except & union ==============");
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            IList<string> strList2 = new List<string>() { "Four", "Five", "Six", "Seven", "Eight" };

            var result2 = strList1.Intersect(strList2);

            Console.WriteLine("=============== intersect ==============");
            foreach (string str in result2)
                Console.WriteLine(str);

            var result3 = strList1.Except(strList2);

            Console.WriteLine("=============== except ==============");
            foreach (string str in result3)
                Console.WriteLine(str);

            Console.WriteLine("=============== union ==============");
            var result4 = strList1.Union(strList2);

            foreach (string str in result4)
                Console.WriteLine(str);

            // 6. skip and skipwhile
            Console.WriteLine("=============== skip & skipwhile ==============");
            Console.WriteLine("=============== skip ==============");
            var newList = strList1.Skip(2);

            foreach (var str in newList)
                Console.WriteLine(str);

            Console.WriteLine("=============== skipwhile ==============");
            var resultList = strList1.SkipWhile(s => s.Length < 4);

            foreach (string str in resultList)
                Console.WriteLine(str);

            // 7. take and takewhile
            Console.WriteLine("=============== take & takewhile ==============");
            Console.WriteLine("=============== take ==============");
            var newList5 = strList1.Take(2);

            foreach (var str in newList5)
                Console.WriteLine(str);

            Console.WriteLine("=============== takewhile ==============");
            var newList6 = strList1.TakeWhile(s => s.Length > 4);

            foreach (string str in newList6)
                Console.WriteLine(str);

            // 8. nested query
            Console.WriteLine("=============== nested query ==============");
            var nestedQueries = from s in studentList
                                where s.Age > 18 && s.StandardID ==
                                    (from std in standardList
                                     where std.StandardName == "Standard 1"
                                     select std.StandardID).FirstOrDefault()
                                select s;

            nestedQueries.ToList().ForEach(s => Console.WriteLine(s.StudentName));
        }
    }
}
