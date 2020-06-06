using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class film
    {
        private int f_id; //电影ID
        private string f_name;//电影名
        private int length;//电影时长
        private string f_type;//电影类型
        private int price;//电影票价



        public int F_id
        {
            set { f_id = value; }
            get { return f_id; }
        }

        public string F_name
        {
            set { f_name = value; }
            get { return f_name; }
        }

        public int Length
        {
            set { length = value; }
            get { return length; }
        }

        public string F_type
        {
            set { f_type = value; }
            get { return f_type; }
        }
        public int Price
        {
            set { price = value; }
            get { return price; }
        }


    }
}
