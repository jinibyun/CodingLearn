using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleAdoNet
{
    public class _04DeleteRecord : BaseClass
    {
        public override void Test()
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection(connectionString);

                // writing sql query  
                // SqlCommand cm = new SqlCommand("delete from student4 where id = 101", con);
                var sql = "delete from student4 where id = @id";
                SqlCommand cm = new SqlCommand(sql, con);
                cm.Parameters.Add("@id", SqlDbType.Int).Value = 101;

                // Opening Connection  
                con.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();
                Console.WriteLine("Record Deleted Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }
}
