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
                // Creating Connection  
                con = new SqlConnection(connectionString);

                // writing sql query  
                SqlCommand cm = new SqlCommand("Select * from student", con);

                // Opening Connection  
                con.Open();

                // Executing the SQL query  
                SqlDataReader sdr = cm.ExecuteReader();

                // Iterating Data  
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["id"] + " " + sdr["name"] + " " + sdr["email"]); // Displaying Record  
                }

                sdr.Close();
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
