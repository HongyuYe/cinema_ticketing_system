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
    public class DealTicket
    {
        //增加一条售票记录

        public bool Addticket(Model.ticket model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into ticket(");
            strSql.Append(" F_id,Schedule_id,Deal_time,Seat_id,Customer_id,Price)");
            strSql.Append(" values(");
            strSql.Append(" @F_id,@Schedule_id,@Deal_time,@Seat_id,@Customer_id,@Price)");

            SqlParameter[] parameters ={
                                     new SqlParameter("@F_id",SqlDbType.Int),
                                     new SqlParameter("@Schedule_id",SqlDbType.Int),
                                     new SqlParameter("@Deal_time",SqlDbType.DateTime),
                                     new SqlParameter("@Seat_id",SqlDbType.VarChar,20),
                                     new SqlParameter("@Customer_id",SqlDbType.VarChar,20),
                                     new SqlParameter("@Price",SqlDbType.Int)
                                     };

            parameters[0].Value = model.F_id;
            parameters[1].Value = model.Schedule_id;
            parameters[2].Value = model.Deal_time;
            parameters[3].Value = model.Seat_id;
            parameters[4].Value = model.Customer_id;
            parameters[5].Value = model.Price;

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

             //查询每日电影票房
        public DataTable GetTicket_Number(DateTime deal_time)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select F_name, Count(Ticket_id) as Number,Count(ticket_id) as Number2 from film,ticket");
            strSql.Append(" where film.F_id=ticket.F_id and Deal_time=@Deal_time");
            strSql.Append(" group by F_name");
            strSql.Append(" order by Number desc");

            SqlParameter[] parameters = { new SqlParameter("@Deal_time", SqlDbType.Date) };
            parameters[0].Value = deal_time;

            return SqlDbHelper.ExecuteDataTable(strSql.ToString(),CommandType.Text,parameters);
           // 这里 你输入了deal_time 然后让他给parameters[0]  但是你没有传入这个参数 这是另一个重载的方法 要传入参数 刚才那个不用

        }




        
    }
}
