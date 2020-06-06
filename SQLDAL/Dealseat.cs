using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDAL
{
    public class Dealseat
    {
        public Dealseat() { }

        //根据seat_id 和h_id，查询座位所在的行和列
        public Model.seat Getseat(string Seat_id, string H_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from seat where Seat_id=@Seat_id and H_id=@H_id");

            SqlParameter[] parameters ={
                                      new SqlParameter("@Seat_id",SqlDbType.VarChar,20),
                                      new SqlParameter("@H_id",SqlDbType.VarChar,20)
                                      };
            parameters[0].Value = Seat_id;
            parameters[1].Value = H_id;

            Model.seat model = new Model.seat();
            DataTable dt = SqlDbHelper.ExecuteDataTable(strSql.ToString(), CommandType.Text, parameters);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Seat_id"] != null && dt.Rows[0]["Seat_id"].ToString() != "")
                {
                    model.Seat_id = dt.Rows[0]["Seat_id"].ToString();
                }
                if (dt.Rows[0]["H_id"] != null && dt.Rows[0]["H_id"].ToString() != "")
                {
                    model.H_id = dt.Rows[0]["H_id"].ToString();
                }

                if (dt.Rows[0]["Row"] != null && dt.Rows[0]["Row"].ToString() != "")
                {
                    model.Row = int.Parse(dt.Rows[0]["Row"].ToString());
                }
                if (dt.Rows[0]["Column"] != null && dt.Rows[0]["Column"].ToString() != "")
                {
                    model.Column = int.Parse(dt.Rows[0]["Column"].ToString());
                }

                return model;

            }
            else
            {
                return null;
            }
        }


    }
}
