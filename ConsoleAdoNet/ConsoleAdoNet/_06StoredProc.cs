using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleAdoNet
{
    public class _06StoredProc : BaseClass
    {
        public override void Test()
        {
            /*
            CREATE PROC [dbo].[uspGetTitleWithPrice]
            @v_price int
            AS
            BEGIN
	            SELECT * FROM titles 
	            WHERE price <= @v_price
            END 
            */

            int price = 10;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("uspGetTitleWithPrice", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    // 1
                    // cmd.Parameters.AddWithValue("@v_price", price);

                    // 2
                    var param1 = new SqlParameter("@v_price", SqlDbType.Int);
                    param1.Value = price;
                    cmd.Parameters.Add(param1);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    var title = "";
                    while (reader.Read())
                    {
                        title = reader["title"] != DBNull.Value ? reader["title"].ToString() : "";
                        Console.WriteLine(title);
                    }
                }

                
            }
        }
    }
}
