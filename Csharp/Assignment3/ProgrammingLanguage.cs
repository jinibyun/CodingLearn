using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    public abstract class ProgrammingLanguage
    {
        //Q2
        //Name, Version Property and GetInfo() method which return some data type of string.
        private string name;
        private double version;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Version
        {
            get { return version; }
            set { version = value;  }
        }

        public virtual string GetInfo()
        {
            return "Programming Language:" + name + "\nversion: " + version;
        }

        public abstract string GetSupportedPlatform();
    }
}
