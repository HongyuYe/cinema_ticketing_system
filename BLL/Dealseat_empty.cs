using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Dealseat_empty
    {
        SQLDAL.Dealseat_empty dealseat_empty = new SQLDAL.Dealseat_empty();

        //增加座位信息(当安排好场次的时候，就可以增加座位信息 is_empty=1)
        public bool Add(Model.seat_empty model){

            return dealseat_empty.Add(model);

        }


        //查询座位是否为空
        public bool SeatIs_empty(int Schedule_id, string Seat_id)
        {
            return dealseat_empty.SeatIs_empty(Schedule_id, Seat_id);

        }


        //删除一条记录
        public bool Deleteseat_empty(int Schedule_id, string Seat_id)
        {
            return dealseat_empty.Deleteseat_empty(Schedule_id, Seat_id);


        }

        //删除一个场次的所有座位
        public bool Deleteseat_emptyall(int Schedule_id)
        {
            return dealseat_empty.Deleteseat_emptyall(Schedule_id);
        }

        //更新一条记录（当票售出后，可将is_empty更改为0）
        public bool Updateseat_empty(Model.seat_empty model)
        {

            return dealseat_empty.Updateseat_empty(model);

        }


    }
}
