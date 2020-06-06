using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DealTicket
    {
        SQLDAL.DealTicket dealticket = new SQLDAL.DealTicket();
        public bool Addticket(Model.ticket model)
        {

            return dealticket.Addticket(model);

        }

        public DataTable GetTicketNumber(DateTime deal_time)
        {
            return dealticket.GetTicket_Number(deal_time);
        }
    }
}
