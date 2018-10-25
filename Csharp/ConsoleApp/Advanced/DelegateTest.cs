using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Advanced
{
    // delegate is a "type" which contain "method memory address"
    // It enables to pass method itself as a parameter to another method
    delegate int MyDelegate(string s);
    delegate void RunDelegate(int i);
    delegate void Procedure();
    delegate void AnonymousDelegate(string text);

    public class DelegateTest
    {
        public void Test1()
        {
            // m Contains to pointer to method
            MyDelegate m = new MyDelegate(StringToInt);

            // passing delegate == passing method pointer
            Run(m);

        }

        public void Test2()
        {
            RunDelegate run = new RunDelegate(RunThis);            // formal way
            run(1024);

            //run = new RunDelegate(RunThat);
            // omit new RunDelegate 
            run = RunThat; // no parenthesis () // it is the same way as the above. Don't need to declare ** = new blabla();
            run(1024);
        }

        public void Test3()
        {
            Procedure someProcs = null; // it is also possible
            someProcs += new Procedure(Method1);
            someProcs += new Procedure(Method2);            
            someProcs();
            someProcs -= Method2;
            someProcs();

        }

        //★★★★★
        public void Test4(string p1)
        {
            // they are all same belows

            // Anonymous delegate : short way to write delegate.
            //AnonymousDelegate anonDelegate = new AnonymousDelegate(
            //delegate(string text) {
            //    Console.WriteLine(text);
            //});

            // Instead above, we use clearer way: Action or Func (These are built-in delegate)

            // ★ Action type: delegate which takes only on parameter and no return value

            // anonymouse method        
            //Action<string> anonDelegate = delegate (string text)
            //{
            //    Console.WriteLine(text);
            //};
            // much more clearer way: Lambda expression with "go to" operator
            // Action<string> anonDelegate = text => Console.WriteLine(text);     // any name is ok. text is not a keyword
            //  parameter    => "go to"    implementation


            // ★★★
            // Labmda Expression
            // much much much more clearer way: Lambda expression with "goes to" operator
             AnonymousDelegate anonDelegate = text => Console.WriteLine(text);

            // same as the below. it is more explicity, but use the above. it is for a reference
            // text is the parameter name.
            AnonymousDelegate anonDelegate2 = (text) => { Console.WriteLine(text); };
            anonDelegate(p1);
        }

        private int StringToInt(string s)
        {
            return int.Parse(s);
        }

        private void Run(MyDelegate m)
        {
            int i = m("789"); // m.Invoke("789");
            Console.WriteLine(i);
        }

        private void RunThis(int val)
        {
            Console.WriteLine("{0}", val);
        }

        private void RunThat(int value)
        {
            Console.WriteLine("0x{0:X}", value);
        }

        private void Method1()
        {
            Console.WriteLine("Method 1");
        }

        private void Method2()
        {
            Console.WriteLine("Method 2");
        }

        private void Method3()
        {
            Console.WriteLine("Method 3");
        }

    }
}
