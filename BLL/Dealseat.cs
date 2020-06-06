using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Dealseat
    {
        SQLDAL.Dealseat dealseat = new SQLDAL.Dealseat();

        //根据seat_id 和h_id，查询座位所在的行和列
        public Model.seat Getseat(string Seat_id, string H_id)
        {
            return dealseat.Getseat(Seat_id, H_id);            
        }

    }
}
