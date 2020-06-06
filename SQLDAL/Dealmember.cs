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
    public class Dealmember
    {
        public Dealmember() { }

        //增加会员
        public bool Addmember(Model.member model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into member(");
            strSql.Append(" Member_id,Name,Password,Level)");
            strSql.Append(" values (");
            strSql.Append(" @Member_id,@Name,@Password,@Level)");

            SqlParameter[] parameters ={
                                new SqlParameter("@Member_id",SqlDbType.VarChar,20),
                                new SqlParameter("@Name",SqlDbType.VarChar,20),
                                new SqlParameter("@Password",SqlDbType.VarChar,20),
                                new SqlParameter("@Level",SqlDbType.VarChar,20)
                                
                                       };
            parameters[0].Value = model.Member_id;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.Level;



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
        //删除会员
        public bool Deletemember(string Member_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from member ");
            strSql.Append(" where Member_id=@Member_id");

            SqlParameter[] parameters = { 
                                        new SqlParameter("@Member_id",SqlDbType.VarChar,20)
                                        };
            parameters[0].Value = Member_id;

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


        //根据查询条件，查询会员列表
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select Member_id,Name,Level");
            strSql.Append(" from member");
            if (strWhere.Trim() != "")
                strSql.Append(" where " + strWhere);
            strSql.Append(" order by Member_id desc");
            return SqlDbHelper.ExecuteDataTable(strSql.ToString());
        }




        //根据会员号，查询某个会员信息
        public Model.member GetOnemember(string Member_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select top 1 Member_id,Name,Password,Level");
            strSql.Append(" from member where Member_id=@Member_id");
            SqlParameter[] parameters ={
                                     new SqlParameter("@Member_id",SqlDbType.VarChar,20)
                                     };
            parameters[0].Value = Member_id;

            Model.member model = new Model.member();
            DataTable dt = SqlDbHelper.ExecuteDataTable(strSql.ToString(), CommandType.Text, parameters);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Member_id"] != null && dt.Rows[0]["Member_id"].ToString() != "")
                {
                    model.Member_id = dt.Rows[0]["Member_id"].ToString();
                }
                if (dt.Rows[0]["Name"] != null && dt.Rows[0]["Name"].ToString() != "")
                {
                    model.Name = dt.Rows[0]["Name"].ToString();
                }
                if (dt.Rows[0]["Password"] != null && dt.Rows[0]["Password"].ToString() != "")
                {
                    model.Password = dt.Rows[0]["Password"].ToString();
                }
                if (dt.Rows[0]["Level"] != null && dt.Rows[0]["Level"].ToString() != "")
                {
                    model.Level = dt.Rows[0]["Level"].ToString();
                }


                return model;

            }
            else
            {
                return null;
            }

        }


        //根据等级，查询某种等级所有会员
        public DataTable Getmember_level(string Level)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select Member_id,Name,Password,Level");
            strSql.Append(" from member where Level=@Level");
            strSql.Append(" order by Member_id desc");

            return SqlDbHelper.ExecuteDataTable(strSql.ToString());

        }

        //查询所有会员信息
        public DataTable GetMember()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select member_id,name,level from member");

            return SqlDbHelper.ExecuteDataTable(strSql.ToString());

        }

        //更改会员信息(更改密码，更改等级)
        public bool Updatemember_passwd(Model.member model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update [member] set");
            strSql.Append(" Name=@Name,");
            strSql.Append(" Password=@Password,");
            strSql.Append(" Level=@Level");

            strSql.Append(" where Member_id=@Member_id");

            SqlParameter[] parameters ={
                                      new SqlParameter("@Name",SqlDbType.VarChar,20),
                                      new SqlParameter("@Password",SqlDbType.VarChar,20),
                                      new SqlParameter("@Level",SqlDbType.VarChar,20),
                                     
                                      new SqlParameter("@Member_id",SqlDbType.VarChar,20)
                                      };
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.Level;

            parameters[3].Value = model.Member_id;

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



        //判断Member_id，判断原密码是否正确
        public bool Login(string member_id, string password)
        {
            string strSql = " select count(1) from [member] where Member_id=@Member_id and Password=@Password";
            SqlParameter[] parameters ={
                                          new SqlParameter("@Member_id",SqlDbType.VarChar,20),
                                          new SqlParameter("@Password",SqlDbType.VarChar,20)
                                        
                                          };
            parameters[0].Value = member_id;
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

        //根据Member_id修改密码
        public bool Updatemember_passwd2(string member_id,string password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update [member] set");
            strSql.Append(" Password=@Password");
            strSql.Append(" where Member_id=@Member_id");

            SqlParameter[] parameters ={
                                      new SqlParameter("@Password",SqlDbType.VarChar,20),
                                      new SqlParameter("@Member_id",SqlDbType.VarChar,20)
                                      };

            parameters[0].Value = password;
            parameters[1].Value = member_id;

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


    }

}
