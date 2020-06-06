using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Dealfilm_schedule
    {
        SQLDAL.Dealfilm_schedule dealfilm_schedule = new SQLDAL.Dealfilm_schedule();
        
        //增加电影场次
        public bool Addfilm_schedule(Model.film_schedule model)
        {
            return dealfilm_schedule.Addfilm_schedule(model);

        }

        //增加电影场次，返回schedule_id
        public int Addfilm_schedule2(Model.film_schedule model)
        {
            return dealfilm_schedule.Addfilm_schedule2(model);

        }


        //删除电影场次安排
        public bool Deletefilm_schedule(int Schedule_id)
        {
            return dealfilm_schedule.Deletefilm_schedule(Schedule_id);
        }


        //更新电影场次安排
        public bool Updatefilm_schedule(Model.film_schedule model)
        {
            return dealfilm_schedule.Updatefilm_schedule(model);

        }



        //按电影名或日期查询   （电影订票界面的表1）
        public DataTable Getfilm_table(DateTime Date, string F_name)
        {
            return dealfilm_schedule.Getfilm_table(Date, F_name);

        }


        //根据电影f_id和时间，查询该电影该日期所有场次安排信息(电影订票表2)
        public DataTable Getfilm_schedule1(int F_id, DateTime Date)
        {
            return dealfilm_schedule.Getfilm_schedule1(F_id, Date);

        }

        //根据电影f_id和h_type及日期，查询该电影该日期某影厅类型下的所有场次安排信息(电影订票表3)
        public DataTable Getfilm_schedule2(int F_id, DateTime Date, string H_type)
        {

            return dealfilm_schedule.Getfilm_schedule2(F_id, Date, H_type);

        }

        //根据电影场次号Schedule_id, f_id查询电影场次信息
        public Model.film_schedule GetModel1(int Schedule_id)
        {

            return dealfilm_schedule.GetModel1(Schedule_id);

        }


        //根据电影f_id，查询该电影的所有场次安排信息
        public DataTable Getfilm_schedule3(int F_id,DateTime Date)
        {
            return dealfilm_schedule.Getfilm_schedule3(F_id, Date);


        }

        //根据查询条件，获取所查的电影档期安排列表
        public DataTable GetFilm_scheduleList(string strWhere)
        {
            return dealfilm_schedule.GetFilm_scheduleList(strWhere);

        }

        //根据日期获取所查的电影档期安排列表
        public DataTable GetFilmByDate_scheduleList(DateTime Date)
        {
            return dealfilm_schedule.GetFilmByDate_scheduleList(Date);
        }


        //根据F_id,日期获取所查的电影档期安排列表
        public DataTable GetFilmByidDate_scheduleList(int F_id, DateTime Date)
        {
            return dealfilm_schedule.GetFilmByidDate_scheduleList(F_id, Date);
        }



        //根据日期Date查询该日期的电影档期安排表

        public DataTable Getfilm_schedule2(DateTime Date)
        {
            return dealfilm_schedule.Getfilm_schedule2(Date);

        }

   

        //根据电影f_id，Date,Time,H_id查询该电影的Schedule_id
        public int Getfilm_scheduleid(int F_id, DateTime Date, string Time, String H_id)
        {
            return dealfilm_schedule.Getfilm_scheduleid(F_id, Date, Time, H_id);
        
        }

    }
}
