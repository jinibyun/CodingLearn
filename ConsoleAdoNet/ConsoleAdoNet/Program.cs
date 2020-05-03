using System;
using System.Configuration;

namespace ConsoleAdoNet
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass obj = null;

            // obj = new _01CreateTable();
            // obj = new _02InsertTable();
            // obj = new _03RetrieveRecord();
            // obj = new _04DeleteRecord();
            obj = new _05DataSet();
            obj.Test();

        }
    }
}
