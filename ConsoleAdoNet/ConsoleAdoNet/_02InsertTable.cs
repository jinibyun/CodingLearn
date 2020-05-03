using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleAdoNet
{
    public class _02InsertTable : BaseClass
    {
        public override void Test()
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection(connectionString);

                // writing sql query  
                string sql = "insert into student  " + 
                             "(id, name, email, join_date) values " + 
                             "('101', 'Ronald Trump', 'ronald@example.com', '1/12/2017')";
                SqlCommand cm = new SqlCommand(sql, con);  

                // Opening Connection  
                con.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Record Inserted Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }
    }
}
