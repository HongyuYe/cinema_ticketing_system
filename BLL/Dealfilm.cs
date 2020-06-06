using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Dealfilm
    {
        SQLDAL.Dealfilm dealfilm = new SQLDAL.Dealfilm();


        public bool Addfilm(Model.film model)   //增加一条电影信息
        {
            return dealfilm.Addfilm(model);

        }


        //删除一条电影信息记录
        public bool Deletefilm(int F_id)
        {
            return dealfilm.Deletefilm(F_id);

        }



        //更新一条电影信息
        public bool Updatefilm(Model.film model)
        {
            return dealfilm.Updatefilm(model);

        }


        //根据查询条件获取所查询的电影列表
        public DataTable GetFilmList(string strWhere)
        {
            return dealfilm.GetFilmList(strWhere);

        }

        //根据电影编号，获取电影信息
        public Model.film Getfilm(int F_id)
        {
            return dealfilm.Getfilm(F_id);

        }

        //查询全部电影，返回列表
        public DataTable Getallfilm()
        {
            return dealfilm.Getallfilm();
        }

         //根据日期、姓名(匹配)，查询电影信息，去掉相同数据（distinct）
        public DataTable GetfilmListByDate(DateTime Date,string strWhere)
        {
            return dealfilm.GetfilmListByDate(Date,strWhere);
        }

    }
}
