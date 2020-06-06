using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class film_schedule //档期场次安排表
    {
        private int schedule_id;//场次号id
        private int f_id;//电影ID
        private DateTime date;//放映日期
        private string time;//放映时间
        private string h_id;//放映厅ID

        public int Schedule_id
        {
            set { schedule_id = value; }
            get { return schedule_id; }
        }

        public int F_id
        {
            set { f_id = value; }
            get { return f_id; }
        }

        public DateTime Date
        {
            set { date = value; }
            get { return date; }
        }
        public string Time
        {
            set { time = value; }
            get { return time; }
        }
        public string H_id
        {
            set { h_id = value; }
            get { return h_id; }
        }


    }
}
