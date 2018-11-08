using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Spatial;
using System.Linq;

namespace EFTutorials
{
    internal class Program
    {
        /*
        NOTE: These examples is based on site http://www.entityframeworktutorial.net
        Based on it, more and concrete explanation and examples will be added
        */
        private static void Main(string[] args)
        {
            // two versions: Insert, Update and Delete
            // AddUpdateDeleteEntityInConnectedScenario();  // 
            // AddUpdateEntityInDisconnectedScenario();     // DB context 밖에서 정의된 클래스들을 직접 관리

            // LinqToEntitiesQueries();       // LINQ(Language INtegrated Query)  C# language is used as like writing Query
            // DB 뿐만 아니라 모든 Collection타입에서도 이용할 수 있음. 효율적이고 짧음
            // FindEntity();
            // LazyLoading();
            // ExplicitLoading();       // skipped
            // ExecuteRawSQLusingSqlQuery();
            // ExecuteSqlCommand();

            //// DynamicProxy(); // skip it

            // ReadDataUsingStoredProcedure();

            // ChangeTracker(); // skip it
            // SpatialDataType(); // skip it
            // EntityEntry();
            // OptimisticConcurrency();
             TransactionSupport();
            SetEntityState();

            Console.ReadLine();
        }


        /*
        Entity Framework builds and executes INSERT, UPDATE, and DELETE statements 
        for the entities whose EntityState is Added, Modified, or Deleted 
        when the DbContext.SaveChanges() method is called. 
        In the connected scenario, an instance of DbContext keeps track of all the entities and so, 
        it automatically sets an appropriate EntityState to each entity 
        whenever an entity is created, modified, or deleted.
        */
        public static void AddUpdateDeleteEntityInConnectedScenario()
        {
            Console.WriteLine("*** AddUpdateDeleteEntityInConnectedScenario Starts ***");

            using (var context = new SchoolDBEntities())    // using을 사용하면 declare된 context가 마지막괄호 나갈 때 Garbage Collecter에 의해 destruction됨.
            {
                //Log DB commands to console
                context.Database.Log = Console.WriteLine;   // Action type

                //Add a new student and address
                var newStudent = context.Students.Add(
                    new Student()
                    {
                        StudentName = "Maria",
                        StudentAddress = new StudentAddress()
                        {             // Student에 F12눌러보면 
                            Address1 = "1, Harbourside",
                            City = "Jersey City",
                            State = "NJ"
                        }
                    }
                 );
                context.SaveChanges(); // Executes Insert command

                //Edit student name
                newStudent.StudentName = "Tom";
                context.SaveChanges(); // Executes Update command

                //Remove student
                context.Students.Remove(newStudent);
                context.SaveChanges(); // Executes Delete command
            }

            Console.WriteLine("*** AddUpdateDeleteEntityInConnectedScenario Ends ***");
        }


        /*
        the DbContext is not aware of disconnected entities 
        because entities were added or modified out of the scope of the current DbContext instance. 
        So, you need to attach the disconnected entities to a context with appropriate EntityState 
        in order to perform CUD (Create, Update, Delete) operations to the database. 
        */
        public static void AddUpdateEntityInDisconnectedScenario()
        {
            Console.WriteLine("*** AddUpdateEntityInDisconnectedScenario Starts ***");

            // disconnected entities
            var newStudent = new Student() { StudentName = "Bill" };
            var existingStudent = new Student() { StudentID = 10, StudentName = "Chris" };

            using (var context = new SchoolDBEntities())
            {
                //Log DB commands to console
                context.Database.Log = Console.WriteLine;

                context.Entry(newStudent).State = newStudent.StudentID == 0 ? EntityState.Added : EntityState.Modified;
                context.Entry(existingStudent).State = existingStudent.StudentID == 0 ? EntityState.Added : EntityState.Modified;

                context.SaveChanges(); // Executes Delete command
            }

            Console.WriteLine("*** AddUpdateEntityInDisconnectedScenario Ends ***");
        }

        /*
        Entity framework supports three types of queries: 
        1) LINQ-to-Entities
        2) Entity SQL 
        3) Native SQL 

        For testing, some students information is being inserted by calling method
        For Entity SQL and Native SQL, ref: http://www.entityframeworktutorial.net/Querying-with-EDM.aspx
       
        */
        public static void LinqToEntitiesQueries()
        {
            Console.WriteLine("*** LinqToEntitiesQueries Starts  ***");

            using (var context = new SchoolDBEntities())
            {
                // For testing
                string[] studentNames = new string[] { "Jini", "King", "Queen", "Jack", "Jack" };
                AddStudents(studentNames);

                //Log DB commands to console
                //context.Database.Log = Console.WriteLine;

                //Retrieve students whose name is Bill - Linq-to-Entities Query Syntax
                //Linq Query라고 함. 다른 한 방법인 Linq Expression이 조금 더 강력함
                var students = (from s in context.Students
                                where s.StudentName == "Jini"
                                select s).ToList();

                // 위의 것과 같음. 
                /*
                List<Student> stResult = new List<Student>();
                foreach (var s in context.Students)
                {
                    if (s.StudentName == "Jini")
                    {
                        stResult.Add(s);
                    }
                }
                */

                foreach (var member in students)
                {
                    Console.WriteLine(member.StudentName);
                }

                // Linq Expression
                //Retrieve students with the same name - Linq-to-Entities Method Syntax
                var studentsWithSameName = context.Students
                    .GroupBy(s => s.StudentName)
                    .Where(g => g.Count() > 1)
                    .Select(g => g.Key);

                Console.WriteLine("Students with same name");
                foreach (var stud in studentsWithSameName)
                {
                    Console.WriteLine(stud);
                }

                //Retrieve students of standard 1
                var standard1Students = context.Students
                    .Where(s => s.StandardId == 1)
                    .ToList();



                foreach (var member in standard1Students)
                {
                    Console.WriteLine(member.StudentName);
                }
            }

            Console.WriteLine("*** LinqToEntitiesQueries Ends ***");
        }

        /*
        For LINQ Extension Methods confirmation 
        ref: http://www.entityframeworktutorial.net/querying-entity-graph-in-entity-framework.aspx
        */
        public static void FindEntity()
        {

            Console.WriteLine("*** FindEntity Starts  ***");

            using (var context = new SchoolDBEntities())
            {
                // context.Database.Log = Console.WriteLine;

                var stud = context.Students.Find(7);    //만약 해당되는 Primary Key가 없으면 Null값이 stud에 들어가게 되고 그 다음 학생이름출력에 Null에러가 뜸
                //Null 에러 예방
                if (stud != null)
                {
                    Console.WriteLine(stud.StudentName + " found");
                }
                else
                {
                    Console.WriteLine("student cannot be found");
                }
                // Null 에러 뜰 수 있음
                Console.WriteLine(stud.StudentName + " found");
            }

            Console.WriteLine("*** FindEntity Ends ***");
        }

        /*
        Loading Related Entities
        3 kinds of Loading to memory (from database) in EF when querying over tables
        1. Eager Loading
            loads related entities as part of the query, so that we don't need to execute a separate query 
            for related entities. Eager loading is achieved using the Include() method.
            See example: http://www.entityframeworktutorial.net/eager-loading-in-entity-framework.aspx
        2. Lazy Loading
            Lazy loading is delaying the loading of related data, until you specifically request for it.
            See example below
            Default: Lazy Loading set to true
        3. Explicit Loading
            Even with lazy loading disabled (in EF 6), it is still possible to lazily load related entities, 
            but it must be done with an explicit call. Use the Load() method to load related entities explicitly.
            See example below
        Lazy Loading: 필요할 때마다 추가로 쿼리를 실행해서 그때 그때 필요한 데이터만 가져옮.
        Eager Loading: 관련된 Table들의 모든 데이터를 한번에 미리 다 가져옮.
        */
        public static void LazyLoading()
        {
            Console.WriteLine("*** LazyLoading Starts ***");

            using (var context = new SchoolDBEntities())
            {
                context.Database.Log = Console.Write;

                // FirstOrDefault는 null체크 자동으로 해줌
                // context이용하는 건 기본적으로 lazy loading임
                Student student = context.Students.Where(s => s.StudentID == 1).FirstOrDefault<Student>();  

                Console.WriteLine("*** Retrieve standard from the database ***");
                Standard std = student.Standard;
            }

            Console.WriteLine("*** LazyLoading Ends ***");
        }

        // skipped in the class
        public static void ExplicitLoading()
        {
            Console.WriteLine("*** ExplicitLoading Starts ***");

            using (var context = new SchoolDBEntities())
            {
                context.Database.Log = Console.Write;

                Student std = context.Students
                    .Where(s => s.StudentID == 1)
                    .FirstOrDefault<Student>();

                //Loading Standard for Student (seperate SQL query)
                context.Entry(std).Reference(s => s.Standard).Load();

                //Loading Courses for Student (seperate SQL query)
                context.Entry(std).Collection(s => s.Courses).Load();
            }

            Console.WriteLine("*** ExplicitLoading Ends ***");
        }

        // 비추천
        // 회사에서 아래와 같이 사용하고 있으면 수준이 낮은 회사라고 생각하면 됨
        // 그냥 이것도 된다고 보면 됨
        // 비추천인 이유는 Security도 안좋고 문자열 속도에 영향을 줌 (너무 길어지니까)
        // 그나마 굳이 쓴다면 Stored_Procedure 사용하는 것 정도가 괜찮음. Security 안나쁘고 짧고.
        public static void ExecuteRawSQLusingSqlQuery()
        {
            Console.WriteLine("*** ExecuteRawSQLusingSqlQuery Starts ***");

            using (var context = new SchoolDBEntities())
            {
                context.Database.Log = Console.Write;

                var studentList = context.Students.SqlQuery("Select * from Student").ToList<Student>();

                var student = context.Students.SqlQuery("Select StudentId, StudentName, StandardId, RowVersion from Student where StudentId = 1").ToList();
            }

            Console.WriteLine("*** ExecuteRawSQLusingSqlQuery Ends ***");
        }
        // 비추천
        // 클라이언트가 절대 sql구문을 볼 수 없게 해야함
        public static void ExecuteSqlCommand()
        {
            Console.WriteLine("*** ExecuteSqlCommand Starts ***");

            using (var context = new SchoolDBEntities())
            {
                context.Database.Log = Console.Write;

                //Insert command
                int noOfRowInsert = context.Database.ExecuteSqlCommand("insert into student(studentname) values('Robert')");

                //Update command
                int noOfRowUpdate = context.Database.ExecuteSqlCommand("Update student set studentname ='Mark' where studentname = 'Robert'");

                //Delete command
                int noOfRowDeleted = context.Database.ExecuteSqlCommand("delete from student where studentname = 'Mark'");
            }

            Console.WriteLine("*** ExecuteSqlCommand Ends ***");
        }

        public static void DynamicProxy()
        {
            Console.WriteLine("*** DynamicProxy Starts ***");

            using (var context = new SchoolDBEntities())
            {
                var student = context.Students.Where(s => s.StudentName == "Bill")
                        .FirstOrDefault<Student>();

                Console.WriteLine("Proxy Type: {0}", student.GetType().Name);
                Console.WriteLine("Underlying Entity Type: {0}", student.GetType().BaseType);

                //Disable Proxy creation
                context.Configuration.ProxyCreationEnabled = false;

                Console.WriteLine("Proxy Creation Disabled");

                var student1 = context.Students.Where(s => s.StudentName == "Steve")
                        .FirstOrDefault<Student>();

                Console.WriteLine("Entity Type: {0}", student1.GetType().Name);
            }

            Console.WriteLine("*** DynamicProxy Ends ***");
        }


        /*
        Before executing it, proper information should be on
        Student, Course and StudentCourse table

        For Insert, Update and Delete stored proc, please check it out with 
        http://www.entityframeworktutorial.net/EntityFramework5/CRUD-using-stored-procedures.aspx
        */
        public static void ReadDataUsingStoredProcedure()
        {
            Console.WriteLine("*** ReadDataUsingStoredProcedure Starts ***");

            using (var context = new SchoolDBEntities())
            {
                // context.Database.Log = Console.Write;
                //get all the courses of student whose id is 1
                var courses = context.GetCoursesByStudentId(5);
                //Set Course entity as return type of GetCoursesByStudentId function
                //Open ModelBrowser -> Function Imports -> Right click on GetCoursesByStudentId and Edit
                //Change Returns a Collection of to Course Entity from Complex Type
                //uncomment following lines
                foreach(Course cs in courses)
                {
                    Console.WriteLine(cs.CourseName);
                }
            }

            Console.WriteLine("*** ReadDataUsingStoredProcedure Ends ***");
        }


        /*
        Entity Framework supports automatic change tracking of the loaded entities during the life-time of the context. 
        The DbChangeTracker class gives you all the information about current entities being tracked by the context.
        */
        public static void ChangeTracker()
        {
            Console.WriteLine("*** ChangeTracker Starts ***");

            using (var context = new SchoolDBEntities())
            {
                context.Configuration.ProxyCreationEnabled = false;

                var student = context.Students.Add(new Student() { StudentName = "Mili" });
                DisplayTrackedEntities(context);

                Console.WriteLine("Retrieve Student");
                var existingStudent = context.Students.Find(1);

                DisplayTrackedEntities(context);

                Console.WriteLine("Retrieve Standard");
                var standard = context.Standards.Find(1);

                DisplayTrackedEntities(context);

                Console.WriteLine("Editing Standard");
                standard.StandardName = "Grade 5";

                DisplayTrackedEntities(context);

                Console.WriteLine("Remove Student");
                context.Students.Remove(existingStudent);
                DisplayTrackedEntities(context);
            }

            Console.WriteLine("*** ChangeTracker Ends ***");
        }

        private static void DisplayTrackedEntities(SchoolDBEntities context)
        {
            Console.WriteLine("Context is tracking {0} entities.", context.ChangeTracker.Entries().Count());
            DbChangeTracker changeTracker = context.ChangeTracker;
            var entries = changeTracker.Entries();
            foreach (var entry in entries)
            {
                Console.WriteLine("Entity Name: {0}", entry.Entity.GetType().FullName);
                Console.WriteLine("Status: {0}", entry.State);
            }
        }

        public static void SpatialDataType()
        {
            Console.WriteLine("*** SpatialDataType Starts ***");

            using (var context = new SchoolDBEntities())
            {
                context.Database.Log = Console.Write;
                //Add Location using System.Data.Entity.Spatial.DbGeography
                context.Courses.Add(new Course() { CourseName = "New Course from SpatialDataTypeDemo", Location = DbGeography.FromText("POINT(-122.360 47.656)") });

                context.SaveChanges();
            }

            Console.WriteLine("*** SpatialDataTypeDemo Ends ***");
        }

        public static void EntityEntry()
        {
            Console.WriteLine("*** EntityEntry Starts ***");

            using (var context = new SchoolDBEntities())
            {
                //get student whose StudentId is 1
                var student = context.Students.Find(5);

                //edit student name
                student.StudentName = "Monica";

                //get DbEntityEntry object for student entity object
                var entry = context.Entry(student);

                //get entity information e.g. full name
                Console.WriteLine("Entity Name: {0}", entry.Entity.GetType().FullName);

                //get current EntityState
                Console.WriteLine("Entity State: {0}", entry.State);

                Console.WriteLine("********Property Values********");

                foreach (var propertyName in entry.CurrentValues.PropertyNames)
                {
                    Console.WriteLine("Property Name: {0}", propertyName);

                    //get original value
                    var orgVal = entry.OriginalValues[propertyName];
                    Console.WriteLine("     Original Value: {0}", orgVal);

                    //get current values
                    var curVal = entry.CurrentValues[propertyName];
                    Console.WriteLine("     Current Value: {0}", curVal);
                }
            }

            Console.WriteLine("*** EntityEntryDemo Ends ***");
        }

        /*
        In Entity Framework, the SaveChanges() method internally creates a transaction 
        and wraps all INSERT, UPDATE and DELETE operations under it. 
        Multiple SaveChanges() calls, create separate transactions, perform CRUD operations and then commit each transaction.

        NOTE: To see more clearly, test one context at a time
        */
        public static void TransactionSupport()
        {
            Console.WriteLine("*** TransactionSupport Starts ***");

            /*
             -- Entity Framework 설명 중에 TransactionSupport부분을 위해 썼음.

                BEGIN TRAN [SACTION]	-- TRANSACTION이라 써도 됨. All done / All cancel	-> All commmit / All rollback
                						-- Transaction 내에서 하나라도 에러 뜨면 Transaction내 모든 것을 취소시킴.
                						-- 돈거래, 계좌 돈출금 등등에서 쓰임
                	INSERT INTO CART...
                	DELETE FROM INVENTORY
                	INSERT INTO DELIVERY
                	UPDATE MEMBER
                	UPDATE MEMBERPOINT
                	if @@error = 0
                		COMMIT TRANSACTION
                	else
                		COMMIT ROLLBACK

             
             */

            using (var context = new SchoolDBEntities())
            {
                Console.WriteLine("Built-in Transaction");
                //Log DB commands to console
                context.Database.Log = Console.WriteLine;

                //Add a new student and address
                context.Students.Add(new Student() { StudentName = "Kapil" });

                var existingStudent = context.Students.Find(5);
                //Edit student name
                existingStudent.StudentName = "Alex";

                context.SaveChanges(); // Executes Insert & Update command under one transaction
            }

            Console.WriteLine("External Transaction");
            using (var context = new SchoolDBEntities())
            {
                context.Database.Log = Console.Write;

                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Students.Add(new Student()
                        {
                            StudentName = "Arjun"
                        });
                        context.SaveChanges();

                        context.Courses.Add(new Course() { CourseName = "Entity Framework" });
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error occurred.");
                    }
                }
            }

            Console.WriteLine("*** TransactionSupport Ends ***");
        }

        public static void SetEntityState()
        {
            Console.WriteLine("*** SetEntityState Starts ***");

            var student = new Student()
            {
                StudentID = 1, // root entity with key
                StudentName = "Bill",
                StandardId = 1,
                Standard = new Standard()   //Child entity (with key value)
                {
                    StandardId = 1,
                    StandardName = "Grade 1"
                },
                Courses = new List<Course>() {
                    new Course(){  CourseName = "Machine Language" }, //Child entity (empty key)
                    new Course(){  CourseId = 2 } //Child entity (with key value)
                }
            };

            using (var context = new SchoolDBEntities())
            {
                context.Entry(student).State = EntityState.Modified;

                foreach (var entity in context.ChangeTracker.Entries())
                {
                    Console.WriteLine("{0}: {1}", entity.Entity.GetType().Name, entity.State);
                }
            }

            Console.WriteLine("*** SetEntityState Ends ***");
        }

        /*
        FYI,
        
        ref: https://blogs.msdn.microsoft.com/marcelolr/2010/07/16/optimistic-and-pessimistic-concurrency-a-simple-explanation/
        */
        public static void OptimisticConcurrency()
        {
            Console.WriteLine("*** OptimisticConcurrency Starts ***");

            Student student = null;

            using (var context = new SchoolDBEntities())
            {
                student = context.Students.First();
            }

            //Edit student name
            student.StudentName = "Robin";

            using (var context = new SchoolDBEntities())
            {
                context.Database.Log = Console.Write;

                try
                {
                    context.Entry(student).State = EntityState.Modified;
                    context.SaveChanges();

                    Console.WriteLine("Student saved successfully.");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine("Concurrency Exception Occurred.");
                }
            }

            Console.WriteLine("*** OptimisticConcurrency Ends ***");
        }




        private static void AddStudents(string[] studentNames)
        {
            using (var context = new SchoolDBEntities())
            {
                foreach (var member in studentNames)
                {
                    var newStudent = context.Students.Add(
                        new Student()
                        {
                            StudentName = member
                        }
                     );
                    context.SaveChanges(); // Executes Insert command
                }
            }
        }


    }
}
