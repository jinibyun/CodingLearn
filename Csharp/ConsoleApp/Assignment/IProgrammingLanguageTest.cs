using ConsoleApp.Advanced;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Assignment
{
    public class Description
    {
        public override string ToString()
        {
            return "Thank You";
        }
    }

    
    public interface IProgrammingLanguage
    {
        void GetInfo(string imsg);
        void Gift(Description d);
        void Credit(Description d);
    }

        public class Python : IProgrammingLanguage
        {

        public void GetInfo(string message)
        {
            Console.WriteLine("{0}{1}", DateTime.Now.ToLocalTime(), message);
        }

        public void Gift(Description d)
        {
            Console.WriteLine(string.Format("This is a gift for PyThon.....{0}", d.ToString()));
        }

        public void Credit(Description d)
        {
            Console.WriteLine(string.Format("This is a credit for Python.....{0}", d.ToString()));
        }
        
    }

    public class Ruby : IProgrammingLanguage
    {
        public void GetInfo(string message)
        {
            Console.WriteLine("{0}{1}", DateTime.Now.ToLocalTime(), message);
        }

        public void Gift(Description d)
        {
            throw new NotImplementedException();
        }

        public void Credit(Description d)
        {
            Console.WriteLine(string.Format("This is a credit for Ruby.....{0}", d.ToString()));
        }
    }

    public class Pearl : IProgrammingLanguage
    {
        public void GetInfo(string message)
        {
            Console.WriteLine("{0}{1}", DateTime.Now.ToLocalTime(), message);
        }

        public void Gift(Description d)
        {
            throw new NotImplementedException();
        }

        public void Credit(Description d)
        {
            Console.WriteLine(string.Format("This is a credit fot Pearl.....{0}", d.ToString()));
        }
    }
}
