using EFCoreConsole.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreConsole
{
    public class CodeFirstApporach
    {
        public void GetData()
        {
            using (var context = new SchoolContext())
            {
                // explanation
                // What is difference between IQueryable and IEnumerable

                var lstStudents = context.Students.ToList<Student>();
                foreach (var member in lstStudents)
                {
                    Console.WriteLine(string.Format("Student Id: {0}, Student Name: {1}", member.StudentID, member.StudentName));
                }
            }
        }

        public void GetData(string stdName)
        {
            using (var context = new SchoolContext())
            {
                var studentsWithSameName = context.Students.Where(s => s.StudentName == stdName).Any() ? context.Students.Where(s => s.StudentName == stdName).ToList<Student>() : null;

                var found = 0;
                if (studentsWithSameName != null)
                {
                    found = studentsWithSameName.Count;
                }
                Console.WriteLine("Studnent found: " + found);

                // explanation
                // Difference Between Eager Loading and Lazy Loading
                // ref: https://www.itorian.com/2013/06/what-is-eager-loading-and-what-is-lazy.html
                // Eager Loading: It loads the related data in scalar and navigation properties along with query result at first shot.
                // Lazy Loading:  EF loads only the data for the primary object in the LINQ query (the Friend) and leaves the Contact object.
                // Lazy loading brings in the related data on an as-needed basis

                // Eager Loading                
                var gradeName = "no grade";
                var studentWithGrade = context.Students
                           .Where(s => s.StudentName == stdName)
                           .Include(s => s.Grade)
                           .FirstOrDefault();
                if (studentWithGrade != null)
                {
                    gradeName = studentWithGrade.Grade != null ? studentWithGrade.Grade.GradeName : "no grade";
                    Console.WriteLine(studentWithGrade.StudentName + " : " + gradeName);
                }
            }
        }

        public void GetDataUsingRawSQL()
        {
            using (var context = new SchoolContext())
            {
                var lstStudents = context.Students.FromSqlRaw("");
                foreach (var member in lstStudents)
                {
                    Console.WriteLine(string.Format("Student Id: {0}, Student Name: {1}", member.StudentID, member.StudentName));
                }
                // var student = context.Students.FromSql("Select StudentId, StudentName, StandardId, RowVersion from Student where StudentId = 1").ToList();

                //TODO: Create stored proc and call using FromSql
            }
        }

        public void DeleteData(int stdId)
        {
            if (stdId < 1) throw new Exception("student id should be greater than zero");
            using (var context = new SchoolContext())
            {
                // First and FirstOrDefault
                var std = context.Students.FirstOrDefault<Student>();

                if (std != null)
                {
                    context.Students.Remove(std);
                    // or
                    // context.Remove<Student>(std);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("No student has been found");
                }
            }
        }

        public void UpdateData(int stdId, string stdName)
        {
            if (stdId < 1) throw new Exception("student id should be greater than zero");
            if (string.IsNullOrEmpty(stdName)) throw new Exception("student name cannot be null");

            using (var context = new SchoolContext())
            {
                var std = context.Students.Where(x => x.StudentID == stdId).FirstOrDefault<Student>();

                if (std != null)
                {
                    std.StudentName = stdName;
                    context.SaveChanges();
                }
            }
        }

        public void AddData(string stdName)
        {
            if (string.IsNullOrEmpty(stdName)) throw new Exception("student name cannot be null");

            using (var context = new SchoolContext())
            {
                var std = new Student()
                {
                    StudentName = stdName,
                    DateOfBirth = DateTime.Parse("1999-12-12")
                };
                context.Students.Add(std);
                // or
                // context.Add<Student>(std);

                context.SaveChanges();
            }
        }

        public void AddData(string stdName, StudentAddress stdAddress)
        {
            if (string.IsNullOrEmpty(stdName)) throw new Exception("student name cannot be null");

            // TODO : validation of stdAddress

            using (var context = new SchoolContext())
            {
                var std = new Student()
                {
                    StudentName = stdName,
                    DateOfBirth = DateTime.Parse("1999-12-12"),
                    StudentAddresses = new List<StudentAddress>() { stdAddress }
                };


                context.Students.Add(std);

                context.SaveChanges();
            }
        }

        public void ExecuteSqlCommand()
        {
            using (var context = new SchoolContext())
            {
                // TODO: using second parameter to pass database parameter to database

                //Insert command
                int noOfRowInsert = context.Database.ExecuteSqlCommand("insert into students(studentname) values('Robert')");

                //Update command
                int noOfRowUpdate = context.Database.ExecuteSqlCommand("Update students set studentname ='Mark' where studentname = 'Robert'");

                //Delete command
                int noOfRowDeleted = context.Database.ExecuteSqlCommand("delete from students where studentname = 'Mark'");
            }
        }

        public void TransactionSupport()
        {
            using (var context = new SchoolContext())
            {
                using (IDbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // process 1
                        context.Students.Add(new Student()
                        {
                            StudentName = "CCC"
                        });

                        // process 2
                        context.Courses.Add(new Course() { CourseName = "DDD" });


                        context.SaveChanges();

                        // pretend something happens here!!
                        // throw new Exception();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error occurred.");
                    }
                }
            }
        }
    }
}
