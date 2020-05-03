using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleAdoNet
{
    public class _07StoredProcOutput : BaseClass
    {
        public override void Test()
        {
            /*
            CREATE PROC uspSPwithOUTPUT  
            @v_title_id varchar(10)  
            , @v_output int OUTPUT  
            AS  
            UPDATE titles SET price = price * 2  
            WHERE title_id = @v_title_id  
  
            SET @v_output = (SELECT @@ROWCOUNT) -- affected row count
            */

            string titleId = "BU1032";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("uspSPwithOUTPUT", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    var param1 = new SqlParameter("@v_title_id", SqlDbType.VarChar, 6 );
                    param1.Direction = ParameterDirection.Input;
                    param1.Value = titleId;
                    cmd.Parameters.Add(param1);

                    var param2 = new SqlParameter("@v_output", SqlDbType.Int);
                    param2.Direction = ParameterDirection.Output;                  
                    cmd.Parameters.Add(param2);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    var outputRecord = cmd.Parameters["@v_output"].Value != null ? int.Parse(cmd.Parameters["@v_output"].Value.ToString()) : -1;

                    Console.WriteLine(outputRecord);
                }

                
            }
        }
    }
}
