using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleAdoNet
{
    public class _03RetrieveRecord : BaseClass
    {
        public override void Test()
        {
            SqlConnection con = null;
            try
            {
                string sql = "Select * from student";
                // Creating Connection  
                con = new SqlConnection(connectionString);

                // writing sql query  
                SqlCommand cm = new SqlCommand(sql, con);

                // Opening Connection  
                con.Open();

                // Executing the SQL query  
                SqlDataReader sdr = cm.ExecuteReader();

                // Data Record Read
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["id"] + " " + sdr["name"] + " " + sdr["email"]); // Displaying Record  
                }

                // NOTE: Always close
                sdr.Close();

                // How to get single value such as count, min, max, avg, sum
                sql = "SELECT count(*) from student";
                cm.CommandText = sql;
                var scalarValue = cm.ExecuteScalar();

                if(scalarValue != null)
                {
                    Console.WriteLine(string.Format("Student Table Count: {0}", int.Parse(scalarValue.ToString())));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }
    }
}
