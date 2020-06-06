using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing_system
{
    public class SellerHelper
    {
        static string id;

        static public string Id
        {
            get { return id; }
            set { id = value; }
        }
        static string password;

        static public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
