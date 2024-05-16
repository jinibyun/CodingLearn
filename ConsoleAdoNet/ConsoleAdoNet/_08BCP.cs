using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleAdoNet
{
    public class _08BCP : BaseClass
    {
        /*
        Create table BCPTest
        (
            EmployeeID int,
            Name varchar(50)
        )
        */

        public override void Test()
        {
            // 1. preparation : 메모리 상의 table 을 만든다.
            var dt = new DataTable();
            dt.Columns.Add("EmployeeID");
            dt.Columns.Add("Name");

            // 메모리 상의 table 에 임시로 값을 입력
            for (var i = 1; i <= 1000000; i++)
                dt.Rows.Add(i + 1, "Name " + i + 1);

          
            // 2. actual bulk copy
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    using (var sqlBulk = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction)) // , SqlBulkCopyOptions.KeepIdentity
                    {
                        sqlBulk.BatchSize = 100000;
                        sqlBulk.NotifyAfter = 100000;
                        sqlBulk.SqlRowsCopied += (sender, eventArgs) => Console.WriteLine("Wrote " + eventArgs.RowsCopied + " records.");
                        sqlBulk.DestinationTableName = "BCPTest";
                        sqlBulk.WriteToServer(dt);
                    }

                    transaction.Commit(); // "100 %" insert
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // "100 %" cancel
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
