using ConsoleApp.Assignment;
using ConsoleApp.Beginner;
using ConsoleApp.Intermediate;
using ConsoleApp.Advanced;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        // starting
        static void Main(string[] args)
        {
            // A. Basic - Syntax
            //Basic();

            // B. Intermediate - OOP 3 Characteristics & Other things of class

            //Intermediate_OOP3Characteristics();
            //Intermediate_OtherThings();
            // C. Advanced
            Advanced();

            // D. Assignment
            // AssignmentTest();


            Console.ReadKey();
        }

        private static void AssignmentTest()
        {
            var cshsarpTest = new ChsarpTest();
            cshsarpTest.Test();
        }

        private static void Advanced()
        {
            // 1. Generic Class Test
            // Generic class is Template
            // it is similar with Inheritance, but a little bit different
            // parameterized class
            // any class can be put into <>
            // 'T' is from "Type", but actually you can define anything. "SFgreagea" is available too.
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
            // Interview Question ★★★★★
            // Interface is Type? Yes    (Class, Enum, Delegate are type)
            // 
            // This is to replace using Inheritance
            // Inheritance is strongly dependant or strongly tight
            // If inheritances are used too many in a class, then it's very complex to fix all related calsses later
            // So Interface is used
            // Interface has only definitions, not implementations
            // If a class inherits an Interface, the class must implements the definitions that defined in the Interface
            // Abstract class is between Interface and non-abstract Class
            // Interface cannot use New keyword
            // Interface: definition;   Class: implementation
            // Interface can do multiple inheritance
            // Class inheritance is only Single Inheritance available

            Console.WriteLine("============= Interface =============");
            Document doc = new Document();
            // IMachine machine2 = new IMachine(); //Interface cannot be initialized like this!!
            IMachine machine = new MultiFunctionPrinter();  // upcasting 경력있는 사람들은 일부러 이렇게 씀. 그 이유는 아래 예와 같은 조건에 따라서 다른 타입으로 initialize 하려고.
            bool isModern = false;
            if (isModern) // it will be decided at runtime
            {
                machine = new MultiFunctionPrinter();
            }
            else
            {
                machine = new OldFashionedPrinter();
            }
            // 뭘로 정의되든 interface 안의 method를 쓸 수 있다.
            machine.Print(doc);
            machine.Fax(doc);
            machine.Scan(doc);

            // what can be defined: method, property, member, ...
            // 1. difference between class and interface
            // 2. difference between abstract class and interface
            // 3. similarity between abstract class and interface
            // 4. why interface?

            // ★★
            // 4. delegate      (Reference type)
            Console.WriteLine("============= delegate =============");
            var delegateTest = new DelegateTest();
            delegateTest.Test1();
            delegateTest.Test2();
            delegateTest.Test3();
            delegateTest.Test4("anonymous"); // anonymous delegate (Lambda Expression)            

            // ★★
            // one object publishes an event, and another object which is subscribing the first object receive the event
            // 5. Event
            Console.WriteLine("============= event =============");
            var publisher = new Publisher();
            // Event Handling
            //  The followings are all same
            // publisher.ButtonClicked += new ButtonClickedHandler(Publisher_ButtonClicked);  
            // antoher way 1
            // publisher.ButtonClicked += Publisher_ButtonClicked;
            // antoher way 2: anonymouse method: other method does not need to be defined
            // publisher.ButtonClicked += delegate () { Console.WriteLine("Event Subscribed"); }; //그냥 메쏘드 선언없이 implement 실행
            // another way 3: lambda expression: very similar to anonymous method but a bit more convinient way
            publisher.ButtonClicked += () => { Console.WriteLine("Event Subscribed"); };
            // () means there is no parameter in the delegate. if there's any parameter, we can put a variable name in the breakits.
            // please see the Lambda Expression

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

            // ★★
            // 7. Extension Method
            // 만들어지게 된 계기: 메쏘드 50개를 가진 클래스가 있고 거기서 메쏘드 1개 더 추가하려는데 애매할 때
            //(inheritance는 클라이언트 코드도 바꿔야 되서 별로고.. 그냥 추가하자니 ..)
            // .NET도 버전업하면서 기존의 코드를 확장할 때 Extension Method로 코드 새로 추가함.
            //
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
            var v = nums.Where(p => p % 3 == 0);    // p => p % 3 ==0 는 delegate임. 커서를 Where 위에 두면 인수로 delegate가 들어가는 걸 볼 수 있음.
            // var v = nums.Where(p => { return p % 3 == 0;  });
            // ★★ Interview question: What is different between Action and Func?
            // Action은 void 리턴이고 Func는 아무거나 리턴 가능 (general T). Senior Developer 인터뷰 문제
            List<int> arr = v.ToList<int>();
            arr.ForEach(n => Console.WriteLine(n));     // 람다는 foreach에 좋음. delegate를 쓴다 하면 자체적으로 안에 for root가 돈다고 생각하면 됨.

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

        private static void Publisher_ButtonClicked()
        {
            Console.WriteLine("Event Subsribed");
        }

        private static void Intermediate_OOP3Characteristics()
        {
            // Frequent interview question about OOP    ★★★
            // 1. Encapsulation (클래스 입장에서 숨길만한 건 숨기는 것. Access modifier를 public으로만 하지 않는 것.)
            // 2. Inheritance
            // 3. Polymorphism(다형성)
            // 


            // 1. Class basic 1
            Console.WriteLine("=================== Class basic 1 ================");
            var classTest = new ClassTest_Basic1("Jini", 32, 'F');
            Console.WriteLine(string.Format("{0}:{1}:{2}", classTest.Name, classTest.Age, classTest.Gender));
            Console.WriteLine(classTest.GetCustomerData());

            // event
            // ★★★★★
            // 아래 예제의 사람이름이 바뀌면 ClassTest_NameChanged라는 이벤트를 call해주는 것이다. 그 이벤트를 보려면 F12눌러서 참고
            // event subscription : +=
            classTest.NameChanged += ClassTest_NameChanged;
            classTest.BalanceChanged += ClassTest_BalanceChanged;   //임시로 name이 바뀌면 이것도 호출되게 설정했음. classTest 클래스 코드 참고
            classTest.Name = "Jane";    // 이름이 바뀌는 순간 위의 Event들이 호출됨


            // overloading method
            Console.WriteLine(classTest.Foo(1D));
            Console.WriteLine(classTest.Foo(1));
            Console.WriteLine(classTest.Foo(1F, 2));
            Console.WriteLine(classTest.Foo(2, 1F));

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

            // partial class and partial method
            // only explanation

            // 4. Class Inheritance
            Console.WriteLine("====== OOP characteristic 2 of 3: Class Inheritance  ======");
            // Stock and House classes inherit Asset class in the example
            // Super class: Asset
            // only Single Inheritance available
            // Interface can multiple inheritance
            // Sub class: Stock, House
            // In .Net, they call them Base Class and Derived class instead of the above names.
            // Parent class and Child class are OK too.
            Stock msft = new Stock { Name = "MSFT", SharesOwned = 1000 };

            Console.WriteLine(msft.Name);         // MSFT
            Console.WriteLine(msft.SharesOwned);  // 1000

            House mansion = new House { Name = "Mansion", Mortgage = 250000 };

            Console.WriteLine(mansion.Name);      // Mansion
            Console.WriteLine(mansion.Mortgage);  // 250000

            // 5. Reference Conversion
            Console.WriteLine("=================== Reference Conversion  ================");

            // Upcast & Downcast
            // An upcast creates a base class reference from a subclass reference:
            // Upcase is always success, but not Downcase
            Stock msft2 = new Stock();
            Asset a = msft2;

            // Interview Question ★★★
            // In this case, what is the type of a?         Asset
            // It always follows the data type which the object declared with.


            // After the upcast, the two variables still references the same Stock object: ★★★
            Console.WriteLine(a == msft2);  // True

            // A downcast operation creates a subclass reference from a base class reference.
            // Success or Fail depending on the situation
            Stock msft3 = new Stock();
            Asset a2 = msft3;                      // Upcast
            Stock s2 = (Stock)a2;                  // Downcast              if  Asset a2 = new Asset(), then it cannot Downcast
            Console.WriteLine(s2.SharesOwned);   // <No error>
            Console.WriteLine(s2 == a2);          // True
            Console.WriteLine(s2 == msft3);       // True

            // A downcast requires an explicit cast because it can potentially fail at runtime:
            House h = new House();
            Asset a3 = h;               // Upcast always succeeds
                                        // Stock s3 = (Stock)a3;       // ERROR: Downcast fails: a3 is not a Stock 

            // TEST: is and as operator

            // Explane the difference between Overload and Override ★★★★★ Interview question
            // Overload:
            // To overload, when the methods's signatures and return types are same, the parameter types or the number of parameter must be different.
            //
            // The array of parameters
            // 
            // Override:
            // When we have two classes which are related by inheriatance, redefining the method or property is Override
            // virtual, override are required to override. sealed is also used

            // 6. virtaul Function  ★
            // virtual = overridable
            // C#에서는 derived class에서 base class의 method를 기본적으로 override할 수 없다.(Java는 가능)
            // virtual을 Base class method에 붙여야 Derived class에서 override할 수 있다. (필수는 아님. 그대로 쓸 수도 있음)
            // Derived class에서 Method를 override할 때는 Derived class method에 override를 붙여야 한다. (권장)
            Console.WriteLine("========== virtual function, sealed, abstract ========");
            var manager = new Manager(70000, "xyz@test.com", "Jini");
            Console.WriteLine(manager.ToString());

            // sealed class
            // A를 상속한 B가 있고 B를 상속한 C가 있을 때
            // B가 method를 override하면서 sealed도 하고 싶다면 그냥 sealed만 해도 된다.
            var subManager = new SubManager(5000, "john@test.com", "John");
            Console.WriteLine(subManager.ToString());

            // 7. abstract class ★
            // abstract class can have either non asbtract and abstract methods
            // abstract method is to force their derived class override the method
            Dog dog = new Dog();
            Console.WriteLine(dog.Describe());
            Console.WriteLine(dog.Cry());

            // 8. Polymorphism ★★★
            // A variable of type x can refer to an object that subclasses x.
            // The Display method below accepts an Asset. This means means we can pass it any subtype:
            Console.WriteLine("========= OOP characteristic 3 of 3: Class Polymorphism ========");
            Display(new Stock2 { Name = "MSFT", SharesOwned = 1000 });  // upcast Stock to Asset
            Display(new House2 { Name = "Mansion", Mortgage = 100000 });


        }

        // Interview question ★★★★★
        // How do you olverload by overriding?
        // Here is the example
        class Employee
        {
            public virtual void GetBenefit() { }
        }

        // derived class
        class FullStackDeveloper : Employee
        {
            // override
            public override void GetBenefit()
            {
                base.GetBenefit();
            }
            // overload
            public void GetBenefit(int i)
            {

            }
        }

        private static void ClassTest_BalanceChanged(object sender, EventArgs e)
        {
            Console.WriteLine("===== EVENT HANDLING =====");
            Console.WriteLine((decimal)sender);
            Console.WriteLine("==========================");
            // default... when it was automatically generated
            //throw new NotImplementedException();
        }

        private static void Intermediate_OtherThings()
        {
            // 1. Static Class
            // Static is generated in Stack memory, not heap memory
            // Utilities are usually used as static
            // new Class() format is non-static, so stored in heap memory
            // static means almost 'shared'
            Console.WriteLine("========= Static Class / Instance Class ========");
            Console.WriteLine(StaticClass.i);
            Console.WriteLine(StaticClass.sum(1, 1));
            Console.WriteLine(NonStaticClass.sum(2, 2));    // sum method is static in the example
            Console.WriteLine((new NonStaticClass().devide(9, 3))); //devide method is non static in the example


        }

        private static void Display(Asset2 asset)
        {
            Console.WriteLine(asset.Name);
        }

        private static void Basic()
        {
            //// 1. DataType
            //Console.WriteLine("=================== Data Type ================");
            //var dt = new DataType();
            //dt.Test();

            //// 2. Variable And Constant
            //Console.WriteLine("=================== Variable & Constant ================");
            //var vnc = new VariableAndConstant();
            //vnc.Test();

            //// 3. Array
            //Console.WriteLine("=================== Array ================");
            //var arr = new ArrayTest();
            //arr.Test();

            //// 4. String
            //Console.WriteLine("=================== String ================");
            //var strTest = new StringTest();
            //strTest.Test();

            // 5. Enum
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

            //// 8. loop
            //Console.WriteLine("=================== Loop ================");
            //var loopTest = new LoopTest();
            //loopTest.Test();

            //// 9. yield keword: when collection data can be returned one by one in turn
            //// Very important. It is used a lot. ★★★★★
            //Console.WriteLine("=================== yield return ================");
            //var yieldReturnTest = new yieldTest();
            //yieldReturnTest.Test();

            //// 10. Exception
            //Console.WriteLine("=================== Exception ================");
            //var exceptionTest = new ExceptionTest();
            //exceptionTest.Test(0, 0);

            //// 11. Struct
            // ★★★★★ 클래스와 비슷한데 value type임. 나중에 검색
            //Console.WriteLine("=================== Struct ================");
            //var structTest = new StructTest();
            //structTest.ToString();

            //// 12. Nullable
            //Console.WriteLine("=================== Nullable ================");
            //var nullableTest = new NullableTest();
            //nullableTest.Test(null, null, DateTime.Now, null);

            //// 13. Method
            Console.WriteLine("=================== Method ================");
            var methodTest = new MethodTest();
            //// 13-1 pass by value
            int val = 1000;
            methodTest.TestPassByValue(val);

            Console.WriteLine("variable val's value is not changed: {0}", val);

            // 13-2 pass by ref
            int x = 1;
            double y = 1.0;
            double ret = methodTest.TestPassByRef(ref x, ref y);
            Console.WriteLine("variable val's value is actually changed: x: {0} y: {1}", x, y);

            Console.WriteLine(x);
            Console.WriteLine(y);

            // 13-3 out
            int c, d;
            bool bret = methodTest.TestPassByOut(10, 20, out c, out d);
            Console.WriteLine("variable val's value is actually changed: c: {0} d: {1}", c, d);

            // differenc between ref keyword and out keyword 

            // 13-4.
            // when you move the cursur on the method, it said (int a, int b, [string calcType = "+"])
            // [] means the input value is optional.
            var returnValue = methodTest.TestDefaultParam(1, 2);
            Console.WriteLine("Default parameter test: " + returnValue);
            var returnValue2 = methodTest.TestDefaultParam(1, 2, "-----");

            // 13-5.            
            // params int[] values 는 value가 몇 개이던지 int이기만 하면 다 받아줌. 10개든 100개든
            var returnParamsValue = methodTest.TestParams(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            Console.WriteLine("params keyword test: " + returnParamsValue);
        }

        private static void ClassTest_NameChanged(object sender, EventArgs e)
        {
            var obj = (ClassTest_Basic1)sender;
            Console.WriteLine(obj.GetCustomerData());
        }
    }
}
