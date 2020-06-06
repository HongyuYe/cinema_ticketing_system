using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DealHall
    {
        SQLDAL.DealHall dealhall = new SQLDAL.DealHall();
        public Model.hall GetHall(string H_id)
        {
            return dealhall.GetHall(H_id);
        }

     
    }
}
