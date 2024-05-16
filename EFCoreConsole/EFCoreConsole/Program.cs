/*
NOTE: To install EF package, ref : https://www.entityframeworktutorial.net/efcore/install-entity-framework-core.aspx 

For more information about how to use "dotnet ef..." Refer to ReadMe.txt
*/

using EFCoreConsole.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.
            // pre-requiste: go to EFCoreConsole\instnwnd.sql and copy and paste into SSMS to create database first
            DataBaseFirstApproach();

            // 2. 
            //CodeFirstApporach();

        }

        private static void DataBaseFirstApproach()
        {
            var obj = new DatabaseFirst();
            // 1. Add
            // obj.AddData(5, "NorthEast");

            // 2. Update
            //obj.UpdateData(5, "NorthEast-Update");

            // 3. Delete
            // obj.DeleteData(5);

            // 4. Query
            // obj.GetData();

            // 5. Query
            obj.GetData("Eastern");

            // 6. Raw SQL
            // obj.GetDataUsingRawSQL();

            // 7. Execute SQL (INSERT, UPDATE and DELETE) using Raw SQL
            //obj.ExecuteSqlCommand();

            // 8. Transaction Support
            // obj.TransactionSupport();

        }

        private static void CodeFirstApporach()
        {
            //var obj = new CodeFirstApporach();

            // 1. Add
            // obj.AddData("Steve");

            //// 1-1 
            //var stdAddress = new StudentAddress()
            //{
            //    Address1 = "1 King",
            //    City = "Toronto",
            //};
            //obj.AddData("Jini", stdAddress);

            // 2. Update
            // obj.UpdateData(1, "Jini");

            //// 3. Delete
            // obj.DeleteData(1);

            // 4. Query
            // obj.GetData();

            //// 5. Query
            // obj.GetData("Jini");

            //// 6. Raw SQL (SELECT)
            // obj.GetDataUsingRawSQL();

            //// 7. Execute SQL (INSERT, UPDATE and DELETE) using Raw SQL
            //obj.ExecuteSqlCommand();

            //// 8. Transaction Support
            //obj.TransactionSupport();
        }
    }
}
