using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SQLDAL
{
    ///<summary>
    ///针对SQL SERVER 数据库操作的通用类
    ///</summary>
    public class SqlDbHelper
    {
        //1 连接字符串的设置和属性
        private static string connString =
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public static string ConnectionString
        {
            get { return connString; }
            set { connString = value; }
        }

        //2 对数据库进行非连接的查询操作方法，用于获得多条查询记录 
        public static DataTable ExecuteDataTable(string commandText, CommandType commandType, SqlParameter[] parameters)
        {
            DataTable data = new DataTable();//实例化DataTable，用于装载查询结果集
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;//设置command的CommandType为指定的CommandType
                    //如果同时传入了参数，则添加这些参数
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    //通过包含查询SQL的SqlCommand实例来实例化SqlDataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);  //填充DataTable
                }
            }
            return data;
        }

        //2 重载编写ExecuteDataTable()，以方便不同参数时的调用
        public static DataTable ExecuteDataTable(string commandText)
        {
            return ExecuteDataTable(commandText, CommandType.Text, null);
        }
        public static DataTable ExecuteDataTable(string commandText, CommandType commandType)
        {
            return ExecuteDataTable(commandText, commandType, null);
        }

        //3 编写ExecuteReader()，对数据库进行有连接操作，获取多条记录
        public static SqlDataReader ExecuteReader(string commandText,
               CommandType commandType, SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand(commandText, connection);
            command.CommandType = commandType;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        //3 重载编写ExecuteReader()，以方便不同参数时的调用
        public static SqlDataReader ExecuteReader(string commandText)
        {
            return ExecuteReader(commandText,
               CommandType.Text, null);
        }
        public static SqlDataReader ExecuteReader(string commandText, CommandType commandType)
        {
            return ExecuteReader(commandText, commandType, null);
        }

        //4 编写ExecuteScalar(),获得从数据库检索单个值
        public static Object ExecuteScalar(string commandText,
                    CommandType commandType, SqlParameter[] parameters)
        {
            Object result = null;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    //设置command的CommandType为指定的CommandType
                    command.CommandType = commandType;
                    //如果同时传入了参数，则添加这些参数
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    connection.Open();
                    result = command.ExecuteScalar();
                }
            }
            return result;
        }

        //4 重载编写ExecuteScalar(),以方便不同参数时的调用
        public static object ExecuteScalar(string commandText)
        {
            return ExecuteScalar(commandText, CommandType.Text, null);
        }
        public static Object ExecuteScalar(string commandText, CommandType commandType)
        {
            return ExecuteScalar(commandText, commandType, null);
        }

        //5 编写ExecuteNonQuery()，实现对数据库的更新
        public static int ExecuteNonQuery(string commandText,
                        CommandType commandType, SqlParameter[] parameters)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    //设置command的CommandType为指定的CommandType
                    command.CommandType = commandType;
                    //如果同时传入了参数，则添加这些参数
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    connection.Open();
                    count = command.ExecuteNonQuery();
                }
            }
            return count;
        }

        //5 重载编写ExecuteNonQuery(),以方便不同参数时的调用
        public static int ExecuteNonQuery(string commandText)
        {
            return ExecuteNonQuery(commandText, CommandType.Text, null);
        }
        public static int ExecuteNonQuery(string commandText, CommandType commandType)
        {
            return ExecuteNonQuery(commandText, commandType, null);
        }
    }
}
