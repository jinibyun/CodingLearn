using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Intermediate
{
    // Abstract Class
    public abstract class FourLeggedAnimal
    {
        //non abstract method can be declared in an abstract class
        public virtual string Describe()
        {
            return "Not much is known about this four legged animal!";
        }
        
        // Abstract Method ★★★
        // abstractu method forces its derived class to override the method.
        // abstract class can have abstract method
        // No implementation, only definition allowed
        public abstract string Cry();
    }

    public class Dog : FourLeggedAnimal
    {
<<<<<<< HEAD
        public override string Cry()
        {
            return "Bark Bark";
            //throw new NotImplementedException();
        }

        public override string Describe()
        {
            string result = base.Describe();
            result += " In fact, it's a dog!";
            return result;
=======
        //public override string Describe()
        //{
        //    string result = base.Describe();
        //    result += " In fact, it's a dog!";
        //    return result;
        //}
        public override void Cry()
        {
            throw new NotImplementedException();
>>>>>>> origin/master
        }
    }
}
