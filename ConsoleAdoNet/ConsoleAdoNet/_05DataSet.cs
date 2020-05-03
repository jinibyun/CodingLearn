using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleAdoNet
{
    public class _05DataSet : BaseClass
    {
        public override void Test()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter sde = new SqlDataAdapter("Select * from student", con);
                DataSet ds = new DataSet();
                sde.Fill(ds);
                DataRowCollection drc = ds.Tables[0].Rows;
                
                if(drc != null)
                {
                    foreach(DataRow member in drc)
                    {
                        Console.WriteLine(member["id"] == DBNull.Value ? 0 : int.Parse(member["id"].ToString()));
                    }
                }
            }
        }
    }
}
