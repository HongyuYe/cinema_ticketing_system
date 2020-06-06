using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ticketing_seller
    {
        private int t_id;
        private string name;
        private string password;
        private int super_seller;//是否为超级管理员，1为超级管理员，0为普通管理员

        public int T_id
        {
            set { t_id = value; }
            get { return t_id; }
        }
        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public string Password
        {
            set { password = value; }
            get { return password; }
        }

        public int Super_seller
        {
            set { super_seller = value; }
            get { return super_seller; }
        }
    }
}
