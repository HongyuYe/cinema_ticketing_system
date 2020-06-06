using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ticket
    {
        private int ticket_id;
        private int f_id;
        private int schedule_id;
        private string seat_id;
        private string customer_id;
        private DateTime deal_time;
        private int price;

        public int Ticket_id
        {
            set { ticket_id = value; }
            get { return ticket_id; }
        }
        public int F_id
        {
            set { f_id = value; }
            get { return f_id; }
        }

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

        public string Customer_id
        {
            set { customer_id = value; }
            get { return customer_id; }
        }

        public DateTime Deal_time
        {
            set { deal_time = value; }
            get { return deal_time; }
        }

        public int Price
        {
            set { price = value; }
            get { return price; }
        }

    }
}
