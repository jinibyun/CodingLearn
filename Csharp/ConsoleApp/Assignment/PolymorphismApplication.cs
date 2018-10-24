using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Assignment
{
    class Printdata
    {
        public void print(int i)
        {
            Console.WriteLine("Printing int: {0}", i);
        }
        public void print(double f)
        {
            Console.WriteLine("Printing float: {0}", f);
        }
       public void print(string s)
        {
            Console.WriteLine("Printing string: {0}", s);
        }
        
    }

    abstract class Shape
    {
        public abstract int area();
    }

    class Rectangle : Shape
    {
        private int length;
        private int width;

        public Rectangle(int a = 0, int b = 0)
        {
            length = a;
            width = b;
        }
        public override int area()
        {
            Console.WriteLine("Rectangle class area :");
            return (width * length);
        }
    }
    
}
