using ConsoleApp.Beginner;
using ConsoleApp.Intermediate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // A. BASIC
            // Basic();

            // B. INTERMEDIATE
            Intermediate();

            // C. Advanced
            // Advanced();          
        }

        private static void Advanced()
        {
            throw new NotImplementedException();
        }

        

        private static void Intermediate()
        {
            // 1. Class 1
            Console.WriteLine("=================== Class basic ================");
            var classTest = new ClassTest1("Jini", 32, 'F');
            Console.WriteLine(string.Format("{0}:{1}:{2}", classTest.Name, classTest.Age, classTest.Gender));
            Console.WriteLine(classTest.GetCustomerData());

            // event
            classTest.NameChanged += ClassTest_NameChanged;
            classTest.Name = "Jane";

            // overloading method
            Console.WriteLine(classTest.Foo(1D));
            Console.WriteLine(classTest.Foo(1));
            Console.WriteLine(classTest.Foo(1F, 2));
            Console.WriteLine(classTest.Foo(2, 1F));

            // 2. Class 2
            Console.WriteLine("=================== Indexer  ================");
            var classTest2 = new ClassTest2();
            Console.WriteLine(classTest2[3]);       // fox
            classTest2[3] = "kangaroo";
            Console.WriteLine(classTest2[3]);       // kangaroo

            // 3. partial class and partial method
            // only explanation

            // 4. Class Inheritance
            Console.WriteLine("=================== Class Inheritance  ================");
            Stock msft = new Stock { Name = "MSFT", SharesOwned = 1000 };

            Console.WriteLine(msft.Name);         // MSFT
            Console.WriteLine(msft.SharesOwned);  // 1000

            House mansion = new House { Name = "Mansion", Mortgage = 250000 };

            Console.WriteLine(mansion.Name);      // Mansion
            Console.WriteLine(mansion.Mortgage);  // 250000

            // 5. Polymorphism
            // A variable of type x can refer to an object that subclasses x.
            // The Display method below accepts an Asset. This means means we can pass it any subtype:
            Console.WriteLine("=================== Class Polymorphism  ================");
            Display(new Stock2 { Name = "MSFT", SharesOwned = 1000 });
            Display(new House2 { Name = "Mansion", Mortgage = 100000 });

            // 6. Reference Conversion
            Console.WriteLine("=================== Reference Conversion  ================");
            
            // An upcast creates a base class reference from a subclass reference:
            Stock msft2 = new Stock();
            Asset a = msft;                 // Upcast

            // After the upcast, the two variables still references the same Stock object:
            Console.WriteLine(a == msft);	// True

        }

        private static void Display(Asset2 asset)
        {
            Console.WriteLine(asset.Name);
        }

        private static void Basic()
        {
            // 1. DataType
            Console.WriteLine("=================== Data Type ================");
            var dt = new DataType();
            dt.Test();

            // 2. Variable And Constant
            Console.WriteLine("=================== Variable & Constant ================");
            var vnc = new VariableAndConstant();
            vnc.Test();

            // 3. Array
            Console.WriteLine("=================== Array ================");
            var arr = new ArrayTest();
            arr.Test();

            // 4. String
            Console.WriteLine("=================== String ================");
            var strTest = new StringTest();
            strTest.Test();

            // 5. Enum
            Console.WriteLine("=================== Enum ================");
            var enumTest = new EnumTest();
            enumTest.Test();

            // 6. Operator
            Console.WriteLine("=================== Operator ================");
            var operatorTest = new OperatorTest();
            operatorTest.Test();

            // 7. If
            Console.WriteLine("=================== If ================");
            var ifTest = new IfTest();
            ifTest.Test();

            // 8. loop
            Console.WriteLine("=================== Loop ================");
            var loopTest = new LoopTest();
            loopTest.Test();

            // 9. yield keword: when collection data can be returned one by one in turn
            Console.WriteLine("=================== yield return ================");
            var yieldReturnTest = new yieldTest();
            yieldReturnTest.Test();

            // 10. Exception
            Console.WriteLine("=================== Exception ================");
            var exceptionTest = new ExceptionTest();
            exceptionTest.Test(0, 0);

            // 11. Struct
            Console.WriteLine("=================== Struct ================");
            var structTest = new StructTest();
            structTest.ToString();

            // 12. Nullable
            Console.WriteLine("=================== Nullable ================");
            var nullableTest = new NullableTest();
            nullableTest.Test(null, null, DateTime.Now, null);

            // 13. Method
            Console.WriteLine("=================== Method ================");
            var methodTest = new MethodTest();
            // 13-1
            int val = 1000;
            methodTest.TestPassByValue(val);
            Console.WriteLine("variable val's value is not changed: {0}", val);
            // 13-2
            int x = 1;
            double y = 1.0;
            double ret = methodTest.TestPassByRef(ref x, ref y);
            Console.WriteLine("variable val's value is actually changed: x: {0} y: {1}", x, y);
            // 13-3
            int c, d;
            bool bret = methodTest.TestPassByOut(10, 20, out c, out d);
            Console.WriteLine("variable val's value is actually changed: c: {0} d: {1}", c, d);

            // differenc between ref keyword and out keyword 

            // 13-4.
            var returnValue = methodTest.TestDefaultParam(1, 2);
            Console.WriteLine("Default parameter test: " + returnValue);

            // 13-5.            
            var returnParamsValue = methodTest.TestParams(1, 2, 3, 4);
            Console.WriteLine("params keyword test: " + returnParamsValue);
        }

        private static void ClassTest_NameChanged(object sender, EventArgs e)
        {
            var obj = (ClassTest1)sender;
            Console.WriteLine(obj.GetCustomerData());
        }
    }
}
