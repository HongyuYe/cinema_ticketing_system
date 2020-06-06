using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class hall
    {
        private string h_id;
        private string h_name;
        private string h_type;//厅类型
        private int num_of_seats;

        public string H_id
        {
            set { h_id = value; }
            get { return h_id; }
        }

        public string H_name
        {
            set { h_name = value; }
            get { return h_name; }
        }

        public int Num_of_seats
        {
            set { num_of_seats = value; }
            get { return num_of_seats; }
        }

        public string H_type
        {
            set { h_type = value; }
            get { return h_type; }
        }


    }
}
