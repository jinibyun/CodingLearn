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

                List<student> students = new List<student>();

                // Data Record Read
                while (sdr.Read())
                {
                    // untyped
                    string id = sdr["id"] != null ? sdr["id"].ToString() : "";
                    string name = sdr["name"] != null ? sdr["name"].ToString() : "";
                    string email = sdr["email"] != null ? sdr["email"].ToString() : "";

                    Console.WriteLine(id + " " + name + " " + email); // Displaying Record 

                    // typed
                    students.Add(new student { 
                         id = sdr["id"] != null ? int.Parse(sdr["id"].ToString()) : -1,
                         name = sdr["name"] != null ? sdr["name"].ToString() : "",
                         email = sdr["email"] != null ? sdr["email"].ToString() : "",
                         join_date = sdr["join_date"] != null ? DateTime.Parse(sdr["join_date"].ToString()) : DateTime.MinValue
                    });
                }

                foreach(var member in students)
                {
                    // TODO
                }

                // NOTE: Must close
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
                con.Dispose();
            }
        }
    }
}
