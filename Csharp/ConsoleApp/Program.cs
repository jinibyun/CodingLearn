using ConsoleApp.Advanced;
using ConsoleApp.Assignment;
using ConsoleApp.Beginner;
using ConsoleApp.Intermediate;
using System;
using System.Collections.Generic;
using System.Linq;
using static ConsoleApp.Assignment.CsharpTest3;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //A.Basic - Syntax
            //Basic();

            // B. Intermediate - OOP 3 Characteristics & Other things of class
            //Intermediate_OOP3Characteristics();
            //Intermediate_OtherThings();

            // C. Advanced
            Advanced();     

            //D.Assignment
            //AssignmentTest();
        }

        private static void AssignmentTest()
        {
            // Assignment1
            //Console.WriteLine("=================== Assignment1 Test ================");
            //var csharpTest = new CsharpTest();
            //csharpTest.Test();

            // Assignment2
            //var csharpTest2 = new CsharpTest2();
            //csharpTest2.Test2();

            //Console.WriteLine("=================== Class Product ================");
            //var product = new Product("Sonata", 30000, 10,"Green",'C');
            //Console.WriteLine(string.Format("{0}:{1}:{2}:{3}:{4}", product.Name, product.Price, product.Qty,product.Color,product.KindofProduct));
            //Console.WriteLine(product.GetCustomerData());
            //Console.WriteLine(product.GetStatusData());
            //Console.WriteLine(product.TotalPrice());
            //// overloading method

            //Console.WriteLine(product.TotalPrice("Sonata", 25000F));
            //Console.WriteLine(product.TotalPrice("Sorento", 350000F, DateTime.Today ));
            //Console.ReadLine();

            // Assignment3

            Console.WriteLine("== Assignm3 Start ==");
            var csharpTest3 = new CsharpTest3();
            Console.WriteLine("***1. Indexer  ***");

            var assgnTest = new AssignTest_Indexer();
            Console.WriteLine("Your pet's name is  " + assgnTest[4]);       // monky
            assgnTest[4] = "minky";
            Console.WriteLine("No, my pet's name is  " + assgnTest[4]);       //minky          
                                                                              //Console.ReadLine();
            Console.WriteLine("***2-3. inheritance ***");
            Csharp csharp = new Csharp(Platform.windows);
            csharp.name = "Csharp";
            csharp.version = "6.0";
            Console.WriteLine(csharp.getInfo() + " ,  Cost is " + "$" + csharp.Cost());

            HTML html = new HTML(Platform.windows);
            html.name = "HTML";
            html.version = "5.0";
            Console.WriteLine(html.getInfo() + " ,  Cost is " + "$" + html.Cost());

            ProgrammingLanguage language = new CSS(Platform.linux);

            language.name = "Javascript";
            language.version = "1.8.5";
            language = new Javascript(language);

            Console.WriteLine(language.getInfo() + "$" + language.Cost());

            //Console.ReadLine();

            Console.WriteLine("*** 4-6. Interface ***");
            Description des = new Description();

            //Python script = new Python();
            string opt = "A";

            IProgrammingLanguage script = new Python();

            if (opt == "A")
            {
                script = new Python();
                script.GetInfo("Python");
            }

            else if (opt == "B")
            {
                script = new Ruby();
                script.GetInfo("Ruby");
            }
            else if (opt == "C")
            {
                script = new Pearl();
                script.GetInfo("Pearl");
            }

            script.Gift(des);
            script.Credit(des);

            //Console.ReadLine();

            Console.WriteLine("*** 7. Static and Non-Static ***");
            Console.WriteLine(Utility.isScriptLanguage("JavaScript"));
            Console.WriteLine(Utility.GetYearOfCreation("Csharp").Year + "years");
            //Console.ReadLine();

            Console.WriteLine("***8. Polymorphism ***");
            Console.WriteLine("*** overloading ***");
            Printdata p = new Printdata();

            p.print(5);
            p.print(500.263);
            p.print("Hello C#");
            //Console.ReadLine();

            Console.WriteLine("*** overriding ***");
            Rectangle r = new Rectangle(10, 7);
            double a = r.area();
            Console.WriteLine("Area: {0}", a);
            Console.ReadLine();
        
    }

        private static void Advanced()
        {
            // 1. Generic Class Test
            Console.WriteLine("============= Generic Class =============");
            MyStack<int> numberStack = new MyStack<int>();
            numberStack.Push(1);
            numberStack.Push(2);
            var result = numberStack.Pop();
            Console.WriteLine(result);

            MyStack<string> nameStack = new MyStack<string>();
            nameStack.Push("This");
            nameStack.Push("That");
            var result2 = numberStack.Pop();
            Console.WriteLine(result2);

            // 2. Net framework support built-in generic type
            Console.WriteLine("============= .NET Generic Class: List =========");
            List<string> nameList = new List<string>();
            nameList.Add("John");
            nameList.Add("Jane");

            foreach (var member in nameList)
            {
                Console.WriteLine(member);
            }

            List<decimal> decimalList = new List<decimal>();
            decimalList.Add(1.345M);
            decimalList.Add(-92.12M);

            foreach (var member in decimalList)
            {
                Console.WriteLine(member);
            }

            Console.WriteLine("============= .NET Generic Class: Dictionary =========");
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic["aaa"] = 100;
            dic["bbb"] = 90;

            foreach (var member in dic)
            {
                Console.WriteLine(dic[member.Key]);
            }

            Console.WriteLine("============= .NET Generic Class: LinkedList =========");
            LinkedList<string> linked = new LinkedList<string>();
            linked.AddLast("cat");
            linked.AddLast("dog");
            linked.AddLast("man");
            linked.AddFirst("first"); // faster inserting, removing then List, but slower than access. Vice Versa
            foreach (var item in linked)
            {
                Console.WriteLine(item);
            }

            // Generic Constraint 
            // Go to File "GenericClass.cs" where just definition is explained

            // 3. Interface
            Console.WriteLine("============= Interface =============");
            Document doc = new Document();
            IMachine machine = new MultiFunctionPrinter();
            if (!true) // it will be decided at runtime
            {
                machine = new OldFashionedPrinter();
            }
            machine.Print(doc);
            machine.Fax(doc);
            machine.Scan(doc);

            // what can be defined: method, property, member, ...
            // 1. difference between class and interface
            // 2. difference between abstract class and interface
            // 3. similarity between abstract class and interface
            // 4. why interface?

            // 4. delegate  : Method의  address를 가지고 있는 DATA TYPE
            Console.WriteLine("============= delegate =============");
            var delegateTest = new DelegateTest();
            delegateTest.Test1();
            delegateTest.Test2();
            delegateTest.Test3();
            delegateTest.Test4("anonymous"); // anonymous delegate (Lambda Expression)            

            // 5. Event  : delegate type으로 정의된 
            Console.WriteLine("============= event =============");
            var publisher = new Publisher();
            // Event Handling  : event + delegate + event handler
            // publisher.ButtonClicked += new ButtonClickedHandler(Publisher_ButtonClicked);            
            // antoher way 1
            // publisher.ButtonClicked += Publisher_ButtonClicked;
            // antoher way 2: anonymouse method: other method does not need to be defined
            // publisher.ButtonClicked += delegate () { Console.WriteLine("Event Subscribed"); };
            // another way 3: lambda expression: very similar to anonymous method but a bit more convinient way(goto Operator)
            publisher.ButtonClicked += () => { Console.WriteLine("Event Subscribed"); };

            publisher.Test();

            // 6. Lambda expression
            // explained above with anonymous
            // It is used in LINQ 
            // a bit more
            /*
            () => Write("No");
            (p) => Write(p);
            (s, e) => Write(e);
            (string s, int i) => Write(s, i); 
            */

            // 7. Extension Method
            // Similar to static method, but it is more flexible and powerful to extend functions in existing class without changing existing class
            Console.WriteLine("============= Extension Method =============");
            string s = "This is a Test";
            string s2 = s.ToChangeCase();
            bool found = s.Found('z');
            Console.WriteLine(s2);
            Console.WriteLine(found);

            // Extension method with very common case
            List<int> nums = new List<int> { 55, 44, 33, 66, 11 };

            // Where extension method
            var v = nums.Where(p => p % 3 == 0);
            List<int> arr = v.ToList<int>();
            arr.ForEach(n => Console.WriteLine(n));

            // 8. async and await
            /*
            Asynchronous Programming
            1. async: let compiler to know that the method has await
            2. more than one "await" can be included. Actually no awit is allowed, but warning comes up.
            3. awiat generally is used with Task<T> object
            4. Compiler will add necessary code for main thread "NOT" to stop 
            5. await Task<T>, when finished Task, then await continue to process next line. At this time, 
            6. NOTE: After finishing Task, await gurantee that it will make back to "original" thread from Task (regardless of other thread or same thread)
 
            Go to "WinformApp" application to testing
            */

            // 9. Net built-in collection and LINQ Basic
            // Pre-requisite: understanding of anonymouse type, yield return, lambda expression, extension method
        }

        private static void Intermediate_OOP3Characteristics()
        {
            // 1. Class basic 1
            //Console.WriteLine("=================== Class basic 1 ================");
            //var classTest = new ClassTest_Basic1("Jini", 32, 'F');
            //Console.WriteLine(string.Format("{0}:{1}:{2}", classTest.Name, classTest.Age, classTest.Gender));
            //Console.WriteLine(classTest.GetCustomerData());

            // event
            // event subscription : +=
            //classTest.NameChanged += ClassTest_NameChanged;
            //classTest.BalanceChanged += ClassTest_BalanceChanged;
            //classTest.Name = "Jane";

            // overloading method
            //Console.WriteLine(classTest.Foo(1D));
            //Console.WriteLine(classTest.Foo(1));
            //Console.WriteLine(classTest.Foo(1F, 2));
            //Console.WriteLine(classTest.Foo(2, 1F));

            // 2. Class basic 2 Encapsulation
            Console.WriteLine("======== OOP characteristic 1 of 3: Encapsulation ======");
            var classTest_Basic2 = new ClassTest_Basic2 { CurrentPrice = 50, SharesOwned = 100, BenchmarkPrice = 49.99M };
            Console.WriteLine(classTest_Basic2.Worth);
            Console.WriteLine(classTest_Basic2.BenchmarkPrice);
            Console.WriteLine(classTest_Basic2.BenchmarkShare);

            // 3. Property: Indexer
            Console.WriteLine("=================== Property: Indexer  ================");
            var classTest2 = new ClassTest_Indexer();
            Console.WriteLine(classTest2[3]);       // fox
            classTest2[3] = "kangaroo";
            Console.WriteLine(classTest2[3]);       // kangaroo           
            Console.ReadLine();
            // partial class and partial method
            // only explanation

            // 4. Class Inheritance
            Console.WriteLine("====== OOP characteristic 2 of 3: Class Inheritance  ======");
            Stock msft = new Stock { SharesOwned = 1000, Name ="aaa"  };

            Console.WriteLine(msft.Name);         // MSFT
            Console.WriteLine(msft.SharesOwned);  // 1000

            House mansion = new House { Name = "Mansion", Mortgage = 250000 };

            Console.WriteLine(mansion.Name);      // Mansion
            Console.WriteLine(mansion.Mortgage);  // 250000

            // 5. Reference Conversion
            Console.WriteLine("=================== Reference Conversion  ================");

            // Upcast & Downcast
            // An upcast creates a base class reference from a subclass reference:
            Stock msft2 = new Stock();
            Asset a = msft2;

            // After the upcast, the two variables still references the same Stock object:
            Console.WriteLine(a == msft2);  // True

            // A downcast operation creates a subclass reference from a base class reference.
            Stock msft3 = new Stock();
            Asset a2 = msft3;                      // Upcast
            Stock s2 = (Stock)a2;                  // Downcast
            Console.WriteLine(s2.SharesOwned);   // <No error>
            Console.WriteLine(s2 == a2);          // True
            Console.WriteLine(s2 == msft3);       // True

            // A downcast requires an explicit cast because it can potentially fail at runtime:
            House h = new House();
            Asset a3 = h;               // Upcast always succeeds
            // Stock s3 = (Stock)a3;       // ERROR: Downcast fails: a3 is not a Stock 

            // TEST: is and as operator

            // 6. virtaul Function
            Console.WriteLine("========== virtual function, sealed, abstract ========");
            var manager = new Manager(70000, "xyz@test.com", "Jini");
            Console.WriteLine(manager.ToString());

            // sealed class
            var subManager = new SubManager(5000, "john@test.com", "John");
            Console.WriteLine(subManager.ToString());

            // 7. abstract class
            Dog dog = new Dog();
            Console.WriteLine(dog.Describe());

            // 8. Polymorphism
            // A variable of type x can refer to an object that subclasses x.
            // The Display method below accepts an Asset. This means means we can pass it any subtype:
            Console.WriteLine("========= OOP characteristic 3 of 3: Class Polymorphism ========");
            Display(new Stock2 { Name = "MSFT", SharesOwned = 1000 });
            Display(new House2 { Name = "Mansion", Mortgage = 100000 });
        }

        private static void ClassTest_BalanceChanged(object sender, EventArgs e)
        {
            Console.WriteLine("====Event Test===");
            Console.WriteLine((decimal)sender);
            Console.WriteLine("====Event Test===");
        }
        private static void Intermediate_OtherThings()
        {
            // 1. Static Class
            Console.WriteLine("========= Static Class / Instance Class ========");
            Console.WriteLine(StaticClass.i);
            Console.WriteLine(StaticClass.sum(1, 1));
            Console.WriteLine(NonStaticClass.sum(2, 2));
            Console.WriteLine((new NonStaticClass().devide(9, 3)));


        }

        private static void Display(Asset2 asset)
        {
            Console.WriteLine(asset.Name);
        }

        private static void Basic()
        {
            // 1. DataType
            //Console.WriteLine("=================== Data Type ================");
            //var dt = new DataType();
            //dt.Test();

            // 2. Variable And Constant
            //Console.WriteLine("=================== Variable & Constant ================");
            //var vnc = new VariableAndConstant();
            //vnc.Test();

            // 3. Array
            //Console.WriteLine("=================== Array ================");
            //var arr = new ArrayTest();
            //arr.Test();

            //// 4. String
            //Console.WriteLine("=================== String ================");
            //var strTest = new StringTest();
            //strTest.Test();

            //// 5. Enum 정수형 data의 변환 (value type) class 바깥에 설정
            //Console.WriteLine("=================== Enum ================");
            //var enumTest = new EnumTest();
            //enumTest.Test();

            //// 6. Operator
            //Console.WriteLine("=================== Operator ================");
            //var operatorTest = new OperatorTest();
            //operatorTest.Test();

            //// 7. If
            //Console.WriteLine("=================== If ================");
            //var ifTest = new IfTest();
            //ifTest.Test();
            //Console.ReadLine();
            //// 8. loop
            //Console.WriteLine("=================== Loop ================");
            //var loopTest = new LoopTest();
            //loopTest.Test();
            //Console.ReadLine();
            //// 9. yield keword: when collection data can be returned one by one in turn
            //Console.WriteLine("=================== yield return ================");
            //var yieldReturnTest = new yieldTest();
            //yieldReturnTest.Test();

            //// 10. Exception
            //Console.WriteLine("=================== Exception ================");
            //var exceptionTest = new ExceptionTest();
            //exceptionTest.Test(0, 0);

            //// 11. Struct
            //Console.WriteLine("=================== Struct ================");
            //var structTest = new StructTest();
            //structTest.ToString();

            //// 12. Nullable
            //Console.WriteLine("=================== Nullable ================");
            //var nullableTest = new NullableTest();
            //nullableTest.Test(null, null, DateTime.Now, null);
            //
            //// 13. Method
            Console.WriteLine("=================== Method ================");
            var methodTest = new MethodTest();
            //// 13-1
            int val = 1000;
            methodTest.TestPassByValue(val);
            Console.WriteLine("variable val's value is not changed: {0}", val);
            //// 13-2
            int x = 1;
            double y = 1.0;
            double ret = methodTest.TestPassByRef(ref x, ref y);
            Console.WriteLine("variable val's value is actually changed: x: {0} y: {1}", x, y);
            Console.ReadLine();
            //// 13-3
            int c, d;
            bool bret = methodTest.TestPassByOut(10, 20, out c, out d);
            Console.WriteLine("variable val's value is actually changed: c: {0} d: {1}", c, d);

            //// differenc between ref keyword and out keyword 

            //// 13-4.
            var returnValue = methodTest.TestDefaultParam(1, 2);
            Console.WriteLine("Default parameter test: " + returnValue);

            //// 13-5.            
            var returnParamsValue = methodTest.TestParams(1, 2, 3, 4);
            Console.WriteLine("params keyword test: " + returnParamsValue);
            Console.ReadLine();

        }

        private static void ClassTest_NameChanged(object sender, EventArgs e)
        {
            var obj = (ClassTest_Basic1)sender;
            Console.WriteLine(obj.GetCustomerData());
        }

    }
}
