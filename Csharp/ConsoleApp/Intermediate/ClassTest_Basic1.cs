﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Intermediate
{
    public class ClassTest_Basic1
    {
        // class's element
        // 1. Method 2. Property  3. Field  4. Event  5.Enum  6.Constant

        // other consideration
        // access modifier

        // member or member field
        private string name;
        private int age;
        private readonly string gender;

        // difference between readonly varialbes and constant

        // event 
        public event EventHandler NameChanged;
        public event EventHandler BalanceChanged;

        // Constructor
        // 1. same as class name   2. must be public   3. no return type
        // ??making method into an object and it also initializes??
        public ClassTest_Basic1(string pname, int page, char pgender = 'M')
        {
            name = pname;
            age = page;
            gender = pgender == 'M' ? "Male" :"Female";

        }

        // Property
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    if (NameChanged != null)
                    {
                        NameChanged(this, EventArgs.Empty);
                    }

                    if (BalanceChanged != null)
                    {
                        decimal balance = 1000M;
                        BalanceChanged(balance, new EventArgs());
                    }
                }
            }
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        //read only property
        public string Gender
        {
            get { return this.gender; }
        }

        // Method
        public string GetCustomerData()
        {
            string data = string.Format("Name: {0} (Age: {1} Gender: {2})",
                        this.Name, this.Age, this.Gender);
            return data;
        }

        // Method Overloading
        // same signature method 
        // Condition: Either number of parameter or type must be different
        public string Foo(int x)
        {
            return string.Format("returning integer: {0}", x);
        }
        public string Foo(double x)
        {
            return string.Format("returning double: {0}", x);
        }

        public string Foo(int x, float y)
        {
            return string.Format("returning integer and float: {0},{1}", x, y);
        }
        public string Foo(float x, int y)
        {
            return string.Format("returning float and integer: {0},{1}", x, y);
        }
        
        // difference between overloading and overriding
    }
}
