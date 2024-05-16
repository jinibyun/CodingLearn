using System;
using System.Collections.Generic;
using System.Data;
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
                int id = 102;
                string name = "Jini Byun";
                string email = "jinibyun@example.com";
                string join_date = "1/12/2017";

                // Creating Connection  
                con = new SqlConnection(connectionString);

                // writing sql query  

                // 1.no parameterized
                //string sql = "insert into student4 " +
                //             "(id, name, email, join_date) values " +
                //             "(101, 'Ronald Trump', 'ronald@example.com', '1/12/2017')";
                //SqlCommand cm = new SqlCommand(sql, con);

                // 2. parameterized
                string sql = "insert into student  " +
                             "(id, name, email, join_date) values " +
                             "(@id, @name, @email, @jon_date)"; // @: parameter

                SqlCommand cm = new SqlCommand(sql, con);
                cm.Parameters.Add("@id", SqlDbType.Int).Value = id;
                //SqlParameter param1 = cm.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                //param1.Value = id;

                cm.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                cm.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                cm.Parameters.Add("@jon_date", SqlDbType.Date).Value = join_date;

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
                con.Dispose();
            }
        }
    }
}
