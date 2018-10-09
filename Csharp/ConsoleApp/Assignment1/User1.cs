using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Assignment1
{
    class User1
    {
        public string Name;
        public string Location;
        public int Age;
        public void GetUserDetails()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Location: {0}", Location);
            Console.WriteLine("Age: {0}", Age);
        }
    }
}
