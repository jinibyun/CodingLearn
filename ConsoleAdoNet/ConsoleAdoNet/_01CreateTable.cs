using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleAdoNet
{
    public class _01CreateTable : BaseClass
    {

        public override void Test()
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection(connectionString);
                
                // Opening Connection  
                con.Open();

                // writing sql query  
                string sql = "create table student4(id int not null, " +  
                                                   "name varchar(100), " + 
                                                   "email varchar(50), " +
                                                   "join_date date)";

                SqlCommand cm = new SqlCommand(sql, con);



                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Table created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
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
