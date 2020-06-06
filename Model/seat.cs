using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class seat
    {
        private string seat_id;
        private string h_id;
        private int row;
        private int column;

        public string Seat_id
        {
            set { seat_id = value; }
            get { return seat_id; }

        }
        public string H_id
        {
            set { h_id = value; }
            get { return h_id; }
        }

        public int Row
        {
            set { row = value; }
            get { return row; }
        }
        public int Column
        {
            set { column = value; }
            get { return column; }
        }


    }
}
