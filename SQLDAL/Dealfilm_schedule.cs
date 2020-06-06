using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDAL
{
    public class Dealfilm_schedule
    {
        public Dealfilm_schedule() { }

        //增加电影场次
        public bool Addfilm_schedule(Model.film_schedule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into film_schedule(");
            strSql.Append(" F_id,Date,Time,H_id)");
            strSql.Append(" values (");
            strSql.Append(" @F_id,@Date,@Time,@H_id); select @Schedule_id=@@IDENTITY; ");

            SqlParameter[] parameters ={
                                       new SqlParameter("@F_id",SqlDbType.Int),
                                      new SqlParameter("@Date",SqlDbType.Date),
                                     new SqlParameter("@Time",SqlDbType.VarChar,20),
                                     new SqlParameter("@H_id",SqlDbType.VarChar,20),
                                     new SqlParameter("@Schedule_id", SqlDbType.Int) 
                                      };

            parameters[0].Value = model.F_id;
            parameters[1].Value = model.Date;
            parameters[2].Value = model.Time;
            parameters[3].Value = model.H_id;
            parameters[4].Direction = ParameterDirection.Output;


            int rows = Convert.ToInt32(SqlDbHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters));
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        //增加电影场次,返回schedule_id
        public int Addfilm_schedule2(Model.film_schedule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into film_schedule(");
            strSql.Append(" F_id,Date,Time,H_id)");
            strSql.Append(" values (");
            strSql.Append(" @F_id,@Date,@Time,@H_id); select @Schedule_id=@@IDENTITY; ");

            SqlParameter[] parameters ={
                                       new SqlParameter("@F_id",SqlDbType.Int),
                                      new SqlParameter("@Date",SqlDbType.Date),
                                     new SqlParameter("@Time",SqlDbType.VarChar,20),
                                     new SqlParameter("@H_id",SqlDbType.VarChar,20),
                                     new SqlParameter("@Schedule_id", SqlDbType.Int) 
                                      };

            parameters[0].Value = model.F_id;
            parameters[1].Value = model.Date;
            parameters[2].Value = model.Time;
            parameters[3].Value = model.H_id;
            parameters[4].Direction = ParameterDirection.Output;


            int rows = Convert.ToInt32(SqlDbHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters));
            
            return Convert.ToInt32(parameters[4].Value);
            
            
          

        }


        //删除电影场次安排
        public bool Deletefilm_schedule(int Schedule_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from film_schedule");
            strSql.Append(" where Schedule_id=@Schedule_id ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@Schedule_id",SqlDbType.Int),
                                      

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



        //更新电影场次安排
        public bool Updatefilm_schedule(Model.film_schedule model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update film_schedule set");
            strSql.Append(" F_id=@F_id,");
            strSql.Append(" Date=@Date,");
            strSql.Append(" Time=@Time,");
            strSql.Append(" H_id=@H_id");
            strSql.Append(" where Schedule_id=@Schedule_id ");

            SqlParameter[] parameters ={
                                      new SqlParameter("@F_id",SqlDbType.Int),
                                      new SqlParameter("@Date",SqlDbType.Date),
                                      new SqlParameter("@Time",SqlDbType.VarChar,20),
                                      new SqlParameter("@H_id",SqlDbType.VarChar,20),
                                      new SqlParameter("@Schedule_id",SqlDbType.Int),
                                     
                                      };
            parameters[0].Value = model.F_id;
            parameters[1].Value = model.Date;
            parameters[2].Value = model.Time;
            parameters[3].Value = model.H_id;
            parameters[4].Value = model.Schedule_id;


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



        //按电影名或日期查询   （电影订票界面的表1）
        public DataTable Getfilm_table(DateTime Date, string F_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select Date,film.F_id,F_name,Length,Price");
            strSql.Append(" from film, film_schedule where film.F_id=film_schedule.F_id");
            strSql.Append(" and film_schedule.Date=@Date  and  film.F_name=@F_name");

            SqlParameter[] parameters ={
                                      new SqlParameter("@Date",SqlDbType.Date),
                                      new SqlParameter("@F_name",SqlDbType.VarChar,20)
                                      };
            parameters[0].Value = Date; ;
            parameters[1].Value = F_name;

            return SqlDbHelper.ExecuteDataTable(strSql.ToString(), CommandType.Text, parameters);


        }


        //根据电影f_id和时间，查询该电影该日期所有场次安排信息(电影订票表2)
        public DataTable Getfilm_schedule1(int F_id, DateTime Date)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select F_id,F_name,Time,H_type");
            strSql.Append("  from (select F_id,,F_name,Time,H_type,Date from  film_schedule,film, hall ");
            strSql.Append("  where film.F_id=film_schedule.F_id and film_schedule.H_id=hall.H_id) as table(F_id,,F_name,Time,H_type,Date)");
            strSql.Append("  where table.F_id=@F_id and table.Date=@Date ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@F_id",SqlDbType.Int),
                                      new SqlParameter("@Date",SqlDbType.Date)
                                      };
            parameters[0].Value = F_id;
            parameters[1].Value = Date;

            return SqlDbHelper.ExecuteDataTable(strSql.ToString(), CommandType.Text, parameters);


        }

        //根据电影f_id和h_type及日期，查询该电影该日期某影厅类型下的所有场次安排信息(电影订票表3)
        public DataTable Getfilm_schedule2(int F_id, DateTime Date, string H_type)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" select F_id,F_name,Time,H_type");
            strSql.Append("  from (select F_id,,F_name,Time,H_type,Date from  film_schedule,film, hall ");
            strSql.Append("  where film.F_id=film_schedule.F_id and film_schedule.H_id=hall.H_id) as table(F_id,,F_name,Time,H_type,Date)");
            strSql.Append("  where table.F_id=@F_id and table.Date=@Date and table.H_type=@H_type ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@F_id",SqlDbType.Int),
                                      new SqlParameter("@Date",SqlDbType.DateTime),
                                      new SqlParameter("@H_type",SqlDbType.VarChar,20)
                                      };
            parameters[0].Value = F_id;
            parameters[1].Value = Date;
            parameters[2].Value = H_type;


            return SqlDbHelper.ExecuteDataTable(strSql.ToString(), CommandType.Text, parameters);


        }








        //根据电影场次号Schedule_id查询电影场次信息
        public Model.film_schedule GetModel1(int Schedule_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select top 1 Schedule_id,F_id,Date,Time,H_id");
            strSql.Append(" from film_schedule where Schedule_id=@Schedule_id ");

            SqlParameter[] parameters ={
                                      new SqlParameter("@Schedule_id",SqlDbType.Int)                                   
                                      };
            parameters[0].Value = Schedule_id;


            Model.film_schedule model = new Model.film_schedule();
            DataTable dt = SqlDbHelper.ExecuteDataTable(strSql.ToString(), CommandType.Text, parameters);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Schedule_id"] != null && dt.Rows[0]["Schedule_id"].ToString() != "")
                {
                    model.Schedule_id = int.Parse(dt.Rows[0]["Schedule_id"].ToString());
                }
                if (dt.Rows[0]["F_id"] != null && dt.Rows[0]["F_id"].ToString() != "")
                {
                    model.F_id = int.Parse(dt.Rows[0]["F_id"].ToString());
                }
                if (dt.Rows[0]["Date"] != null && dt.Rows[0]["Date"].ToString() != "")
                {
                    model.Date = DateTime.Parse(dt.Rows[0]["Date"].ToString());

                }
                if (dt.Rows[0]["Time"] != null && dt.Rows[0]["Time"].ToString() != "")
                {
                    model.Time = dt.Rows[0]["Time"].ToString();

                }
                if (dt.Rows[0]["H_id"] != null && dt.Rows[0]["H_id"].ToString() != "")
                {
                    model.H_id = dt.Rows[0]["H_id"].ToString();
                }

                return model;
            }
            else
            {
                return null;
            }

        }


        //根据电影f_id，查询该电影的所有场次安排信息
        public DataTable Getfilm_schedule3(int F_id,DateTime Date)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select Schedule_id,F_name,Time,H_name,H_type ");
            strSql.Append(" from film,film_schedule,hall ");
            strSql.Append(" where film.F_id=film_schedule.F_id and ");
            strSql.Append(" hall.H_id=film_schedule.H_id and ");
            strSql.Append(" film.F_id=@F_id and Date=@Date ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@F_id",SqlDbType.Int),
                                      new SqlParameter("@Date",SqlDbType.DateTime)
                                      };
            parameters[0].Value = F_id;
            parameters[1].Value = Date;

            return SqlDbHelper.ExecuteDataTable(strSql.ToString(), CommandType.Text, parameters);


        }

        //根据查询条件，获取所查的电影档期安排列表
        public DataTable GetFilm_scheduleList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select film.f_id,F_name,Date,Time,hall.H_name");
            strSql.Append(" from film,film_schedule,hall where film.F_id=film_schedule.F_id and hall.H_id=film_schedule.H_id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" order by Date desc");
            return SqlDbHelper.ExecuteDataTable(strSql.ToString());


        }

        //根据日期获取所查的电影档期安排列表
        public DataTable GetFilmByDate_scheduleList(DateTime Date)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select film.f_id,F_name,Date,Time,hall.H_name");
            strSql.Append(" from film,film_schedule,hall where film.F_id=film_schedule.F_id and hall.H_id=film_schedule.H_id and Date=@Date ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@Date",SqlDbType.Date)
                                      };
            parameters[0].Value = Date;

            return SqlDbHelper.ExecuteDataTable(strSql.ToString(), CommandType.Text, parameters);

        }

        //根据F_id,日期获取所查的电影档期安排列表
        public DataTable GetFilmByidDate_scheduleList(int F_id,DateTime Date)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select film.f_id,F_name,Date,Time,hall.H_name");
            strSql.Append(" from film,film_schedule,hall where film.F_id=film_schedule.F_id and hall.H_id=film_schedule.H_id and Date=@Date and film.F_id=@F_id ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@Date",SqlDbType.Date),
                                      new SqlParameter("@F_id",SqlDbType.Int)
                                      };
            parameters[0].Value = Date;
            parameters[1].Value = F_id;

            return SqlDbHelper.ExecuteDataTable(strSql.ToString(), CommandType.Text, parameters);

        }




        //根据日期Date查询该日期的电影档期安排表

        public DataTable Getfilm_schedule2(DateTime Date)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select Schedule_id,F_id,Date,Time,H_id");
            strSql.Append(" from film_schedule where Date=@Date");
            SqlParameter[] parameters ={
                                      new SqlParameter("@Date",SqlDbType.Date)
                                      };
            parameters[0].Value = Date;

            return SqlDbHelper.ExecuteDataTable(strSql.ToString(), CommandType.Text, parameters);


        }


        //根据电影f_id，Date,Time,H_id查询该电影的Schedule_id
        public int Getfilm_scheduleid(int F_id,DateTime Date , string Time , String H_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select Schedule_id ");
            strSql.Append(" from film_schedule where F_id=@F_id and Date=@Date and Time=@Time and H_id=@H_id ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@F_id",SqlDbType.Int),
                                      new SqlParameter("@Date",SqlDbType.DateTime),
                                      new SqlParameter("@Time",SqlDbType.VarChar,20),
                                      new SqlParameter("@H_id",SqlDbType.VarChar,20)
                                      };
            parameters[0].Value = F_id;
            parameters[1].Value = Date;
            parameters[2].Value = Time;
            parameters[3].Value = H_id;

            return Convert.ToInt32(SqlDbHelper.ExecuteScalar(strSql.ToString(), CommandType.Text, parameters));


        }


    }
}
