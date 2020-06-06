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
    public class Dealticketing_seller
    {
        public Dealticketing_seller() { }

        //增加售票员
        public bool AddTicketing_seller(Model.ticketing_seller model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into ticketing_seller(");
            strSql.Append(" Name,Password,Super_seller)");
            strSql.Append(" values (");
            strSql.Append(" @Name,@Password,@Super_seller)");

            SqlParameter[] parameters ={
                         new SqlParameter("@Name",SqlDbType.VarChar,20),
                         new SqlParameter("@Password",SqlDbType.VarChar,20),
                         new SqlParameter("@Super_seller",SqlDbType.Int)

                                     };
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.Super_seller;

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


        //根据管理员登陆ID获取super_seller的值判断其是否是超级管理员

        public DataTable getSuper_seller(int t_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select Super_seller from ticketing_seller where T_id=" + t_id);
            return SqlDbHelper.ExecuteDataTable(strSql.ToString());



        }




        //删除售票员
        public bool Deleteticketing_seller(int T_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from ticketing_seller");
            strSql.Append(" where T_id=@T_id");

            SqlParameter[] parameters = { new SqlParameter("@T_id", SqlDbType.Int) };
            parameters[0].Value = T_id;

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



        //根据查询条件，获取售票员列表
        public DataTable Getseller(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select T_id,Name,Password,Super_seller");
            strSql.Append(" from ticketing_seller");
            if (strWhere.Trim() != "")
                strSql.Append(" where " + strWhere);
            // strSql.Append(" order by T_id desc");

            return SqlDbHelper.ExecuteDataTable(strSql.ToString());
        }



        //更改售票员信息
        public bool Updateseller_password(Model.ticketing_seller model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" update ticketing_seller set");
            strSql.Append(" Name=@Name,");
            strSql.Append(" Password=@Password,");
            strSql.Append(" Super_seller=@Super_seller");
            strSql.Append(" where T_id=@T_id ");

            SqlParameter[] parameters ={
                                      new SqlParameter("@Name",SqlDbType.VarChar,20),
                                      new SqlParameter("@Password",SqlDbType.VarChar,20),
                                      new SqlParameter("@Super_seller",SqlDbType.Int),
                                      new SqlParameter("@T_id",SqlDbType.Int)

                                      };
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.Super_seller;
            parameters[3].Value = model.T_id;

            int rows = SqlDbHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
            if (rows == 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

            
        //判断售票员登录账号ID，密码是否正确
        public bool Login(int t_id, string password)
        {
            string strSql = " select count(1) from [ticketing_seller] where T_id=@T_id and Password=@Password";
            SqlParameter[] parameters ={
                                          new SqlParameter("@T_id",SqlDbType.Int),
                                          new SqlParameter("@Password",SqlDbType.VarChar,20)
                                        
                                          };
            parameters[0].Value = t_id;
            parameters[1].Value = password;

            int n = Convert.ToInt32(SqlDbHelper.ExecuteScalar(strSql, CommandType.Text, parameters));
            if (n == 1)
            {
                return true;
            }
            else
            {
                return false;
            }



        }


        //查询售票员信息
        public DataTable Getallseller()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select T_id,Name,Password,Super_seller from ticketing_seller");

            return SqlDbHelper.ExecuteDataTable(strSql.ToString());

        }



    }
}
