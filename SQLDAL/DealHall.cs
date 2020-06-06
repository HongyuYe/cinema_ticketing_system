using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDAL
{
    public class DealHall
    {
        public DealHall() { }

        //根据h_id,查询放映厅情况
        public Model.hall GetHall(string H_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select top 1 H_id,H_name,H_type,Num_of_seats");
            strSql.Append(" from hall where H_id=@H_id");

            SqlParameter[] parameters = { new SqlParameter("@H_id", SqlDbType.VarChar, 20) };
            parameters[0].Value = H_id;

            Model.hall model = new Model.hall();
            DataTable dt = SqlDbHelper.ExecuteDataTable(strSql.ToString(), CommandType.Text, parameters);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["H_id"] != null && dt.Rows[0]["H_id"].ToString() != "")
                {
                    model.H_id = dt.Rows[0]["H_id"].ToString();
                }
                if (dt.Rows[0]["H_name"] != null && dt.Rows[0]["H_name"].ToString() != "")
                {
                    model.H_name = dt.Rows[0]["H_name"].ToString();
                }
                if (dt.Rows[0]["H_type"] != null && dt.Rows[0]["H_type"].ToString() != "")
                {
                    model.H_type = dt.Rows[0]["H_type"].ToString();
                }
                if (dt.Rows[0]["Num_of_seats"] != null && dt.Rows[0]["Num_of_seats"].ToString() != "")
                {
                    model.Num_of_seats = int.Parse(dt.Rows[0]["Num_of_seats"].ToString());
                }

                return model;

            }
            else
            {
                return null;
            }
        }

        //增加放映厅
        /* public bool Addhall(Model.hall model)
         {
             StringBuilder strSql = new StringBuilder();
             strSql.Append(" insert into hall(");
             strSql.Append(" H_name,H_type,Num_of_seats)");
             strSql.Append(" values (");
             strSql.Append(" @H_name,@H_type,@Num_of_seats)");

             SqlParameter[] parameters ={
                                      new SqlParameter("@H_name",SqlDbType.VarChar,20),
                                       new SqlParameter("@H_type",SqlDbType.VarChar,20),
                                      new SqlParameter("@Num_of_seats",SqlDbType.Int,20)
                                      
                                       };
             parameters[0].Value = model.H_name;
             parameters[1].Value = model.H_type;
             parameters[2].Value = model.Num_of_seats;


             int rows = SqlDbHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
             if (rows > 0)
             {
                 return true;
             }
             else
             {
                 return false;
             }

         }


         //删除放映厅
         public bool Delete(int H_id)
         {
             StringBuilder strSql = new StringBuilder();
             strSql.Append("delete from hall");
                 strSql.Append("where H_id=@H_id");
                 SqlParameter[] parameters ={
                                       new SqlParameter("@H_id",SqlDbType.VarChar,100)

                                       };
                 parameters[0].Value = H_id;
                 int rows = SqlDbHelper.ExecuteNonQuery(strSql.ToString(),CommandType.Text,parameters);
                 if (rows > 0)
                 {
                     return true;
                 }
                 else {
                     return false;
                 }

         }*/







    }
}
