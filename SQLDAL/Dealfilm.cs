using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace SQLDAL
{
    public class Dealfilm   //对电影信息有增加、删除、修改、查询操作
    {
        public Dealfilm() { }

        public bool Addfilm(Model.film model)   //增加一条电影信息
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into film(F_name,Length,F_type,Price)");
            strSql.Append(" values (@F_name,@Length,@F_type,@Price); select @@IDENTITY");

            SqlParameter[] parameters ={
                                           new SqlParameter("@F_name",SqlDbType.VarChar,20),
                                           new SqlParameter("@Length",SqlDbType.Int),
                                           new SqlParameter("@F_type",SqlDbType.VarChar,20),
                                           new SqlParameter("@Price",SqlDbType.Int),
                                           

                                      };
            parameters[0].Value = model.F_name;
            parameters[1].Value = model.Length;
            parameters[2].Value = model.F_type;
            parameters[3].Value = model.Price;


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


        //删除一条电影信息记录
        public bool Deletefilm(int F_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from film");
            strSql.Append(" where F_id=@F_id");
            SqlParameter[] parameters = { new SqlParameter("@F_id", SqlDbType.Int) };
            parameters[0].Value = F_id;
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



        //更新一条电影信息
        public bool Updatefilm(Model.film model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update film set");
            strSql.Append(" F_name=@F_name,");
            strSql.Append(" Length=@Length,");
            strSql.Append(" F_type=@F_type,");
            strSql.Append(" Price=@Price");
            strSql.Append(" where F_id=@F_id");

            SqlParameter[] parameters ={
                                      new SqlParameter("@F_name",SqlDbType.VarChar,20),
                                      new SqlParameter("@Length",SqlDbType.Int),
                                       new SqlParameter("@F_type",SqlDbType.VarChar,20),
                                       new SqlParameter("@Price",SqlDbType.Int),
                                      new SqlParameter("@F_id",SqlDbType.Int)

                                      };
            parameters[0].Value = model.F_name;
            parameters[1].Value = model.Length;
            parameters[2].Value = model.F_type;
            parameters[3].Value = model.Price;
            parameters[4].Value = model.F_id;


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


        //根据查询条件获取所查询的电影列表
        public DataTable GetFilmList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select F_id,F_name,Length,F_type,Price");
            strSql.Append(" from [film]");
            if (strWhere.Trim() != "")
                strSql.Append(" where " + strWhere);
            strSql.Append(" order by F_id desc");
            return SqlDbHelper.ExecuteDataTable(strSql.ToString());

        }




        //根据电影编号，获取电影信息
        public Model.film Getfilm(int F_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select top 1 F_id,F_name,Length,F_type,Price ");
            strSql.Append(" from film where F_id=@F_id");

            SqlParameter[] parameters = { new SqlParameter("@F_id", SqlDbType.Int) };
            parameters[0].Value = F_id;
            Model.film model = new Model.film();
            DataTable dt = SqlDbHelper.ExecuteDataTable(strSql.ToString(), CommandType.Text, parameters);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["F_id"] != null && dt.Rows[0]["F_id"].ToString() != "")
                {
                    model.F_id = int.Parse(dt.Rows[0]["F_id"].ToString());
                }
                if (dt.Rows[0]["F_name"] != null && dt.Rows[0]["F_name"].ToString() != "")
                {
                    model.F_name = dt.Rows[0]["F_name"].ToString();
                }
                if (dt.Rows[0]["Length"] != null && dt.Rows[0]["Length"].ToString() != "")
                {
                    model.Length = int.Parse(dt.Rows[0]["Length"].ToString());
                }
                if (dt.Rows[0]["F_type"] != null && dt.Rows[0]["F_type"].ToString() != "")
                {
                    model.F_type = dt.Rows[0]["F_type"].ToString();
                }
                if (dt.Rows[0]["Price"] != null && dt.Rows[0]["Price"].ToString() != "")
                {
                    model.Price = int.Parse(dt.Rows[0]["Price"].ToString());
                }


                return model;

            }
            else
            {
                return null;
            }


        }

        //查询所有电影信息
        public DataTable Getallfilm()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select f_id,f_name,length,f_type,price from film");

            return SqlDbHelper.ExecuteDataTable(strSql.ToString());

        }

        //根据日期、姓名(匹配),查询电影信息，去掉相同数据（distinct）
        public DataTable GetfilmListByDate(DateTime Date,string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct Date,film.F_id,F_name,length,F_type,price ");
            strSql.Append("  from film,film_schedule ");
            strSql.Append("  where film.F_id = film_schedule.F_id and Date=@Date ");
            if (strWhere.Trim() != "")
                strSql.Append(" and " + strWhere);
            SqlParameter[] parameters ={
                                      new SqlParameter("@Date",SqlDbType.DateTime)
                                        };

            parameters[0].Value = Date;

            return SqlDbHelper.ExecuteDataTable(strSql.ToString(),CommandType.Text, parameters);

        }



    }
}
