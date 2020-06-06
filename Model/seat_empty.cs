using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class seat_empty
    {

        private int schedule_id;
        private string seat_id;
        private int is_empty;//1表示座位为空，0表示座位不为空




        public int Schedule_id
        {
            set { schedule_id = value; }
            get { return schedule_id; }
        }

        public string Seat_id
        {
            set { seat_id = value; }
            get { return seat_id; }
        }
        public int Is_empty
        {
            set { is_empty = value; }
            get { return is_empty; }

        }

    }
}
