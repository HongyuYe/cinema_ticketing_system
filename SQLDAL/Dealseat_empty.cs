using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDAL
{
    public class Dealseat_empty
    {
        public Dealseat_empty() { }

        //增加座位信息(当安排好场次的时候，就可以增加座位信息 is_empty=1)
        public bool Add(Model.seat_empty model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into seat_empty(");
            strSql.Append(" Schedule_id,Seat_id,Is_empty)");
            strSql.Append(" values(");
            strSql.Append(" @Schedule_id,@Seat_id,@Is_empty)");



            SqlParameter[] parameters ={
                                      
                                     new  SqlParameter("@Schedule_id",SqlDbType.Int),
                                     new SqlParameter("@Seat_id",SqlDbType.VarChar,20),
                                     new SqlParameter("@Is_empty",SqlDbType.Int)
                     };


            parameters[0].Value = model.Schedule_id;
            parameters[1].Value = model.Seat_id;
            parameters[2].Value = model.Is_empty;

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


        //查询座位是否为空
        public bool SeatIs_empty(int Schedule_id, string Seat_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select is_empty from [seat_empty] ");
            strSql.Append("where Schedule_id=@Schedule_id and Seat_id=@Seat_id ");
            SqlParameter[] parameters ={
                                     new  SqlParameter("@Schedule_id",SqlDbType.Int),
                                     new SqlParameter("@Seat_id",SqlDbType.VarChar,20)
                                      };
            parameters[0].Value = Schedule_id;
            parameters[1].Value = Seat_id;
            //parameters[4].Value = 0;
            String is_empty = Convert.ToString(SqlDbHelper.ExecuteScalar(strSql.ToString(), CommandType.Text, parameters));
            if (is_empty == "1")
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        //删除一条记录
        public bool Deleteseat_empty(int Schedule_id, string Seat_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from seat_empty");
            strSql.Append(" where  Schedule_id=@Schedule_id and Seat_id=@Seat_id");
            SqlParameter[] parameters ={
                                      
                                     new  SqlParameter("@Schedule_id",SqlDbType.Int),
                                     new SqlParameter("@Seat_id",SqlDbType.VarChar,20)
                                      };

            parameters[0].Value = Schedule_id;
            parameters[1].Value = Seat_id;

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

             //删除一个场次的所有座位
        public bool Deleteseat_emptyall(int Schedule_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from seat_empty");
            strSql.Append(" where  Schedule_id=@Schedule_id");
            SqlParameter[] parameters ={                                    
                                     new  SqlParameter("@Schedule_id",SqlDbType.Int)
                                      };

            parameters[0].Value = Schedule_id;
     

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

        //更新一条记录（当票售出后，可将is_empty更改为0）
        public bool Updateseat_empty(Model.seat_empty model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update seat_empty set");
            strSql.Append(" is_empty= 0");
            strSql.Append(" where Schedule_id=@Schedule_id and Seat_id=@Seat_id");
            SqlParameter[] parameters ={      
                                      new  SqlParameter("@Schedule_id",SqlDbType.Int),
                                      new SqlParameter("@Seat_id",SqlDbType.VarChar,20)
                                      };
  
            parameters[0].Value = model.Schedule_id;
            parameters[1].Value = model.Seat_id;

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




    }
}
