using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Intermediate
{
    public class Employee
    {
        public decimal _salary;
        public string Name;
        public virtual decimal Salary { get { return 0M; } }
    }

    public class Manager : Employee
    {
        public Manager()
        {

        }
        public Manager(decimal salary, string email, string name)
        {
            _salary = salary;
            Email = email;
            Name = name;
        }
        public string Email { get; set; }

        public override decimal Salary { get { return _salary; } }

        public override string ToString()
        {
            return string.Format("{0}'s saraly is {1}", this.Name, this.Salary);
        }
    }

    public class SubManager2 : Manager
    {
        public override decimal Salary { get { return _salary; } }
    }

    // sealed
    public sealed class SubManager: Manager
    {
        public SubManager(decimal salary, string email, string name):base(salary, email, name)
        {

        }
    }

    //public sealed class SubSubManager : SubManager
    //{
    //    public SubSubManager(decimal salary, string email, string name) : base(salary, email, name)
    //    {

    //    }
    //}
}
