using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCore.Intermediate
{
    public abstract class FourLeggedAnimal
    {
        public virtual string Describe()
        {
            return "Not much is known about this four legged animal!";
        }

        // must
        public abstract void Cry(); // only definition
    }

    public class Dog : FourLeggedAnimal
    {
        //public override string Describe()
        //{
        //    string result = base.Describe();
        //    result += " In fact, it's a dog!";
        //    return result;
        //}
        public override void Cry()
        {
            Console.WriteLine("Wal Wal");
        }
    }
    public class Cat : FourLeggedAnimal
    {
        //public override string Describe()
        //{
        //    string result = base.Describe();
        //    result += " In fact, it's a dog!";
        //    return result;
        //}
        public override void Cry()
        {
            Console.WriteLine("Meow, Meow");
        }
    }
}
