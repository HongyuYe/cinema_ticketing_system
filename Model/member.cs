using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class member
    {
        private string member_id;
        private string name;
        private string password;
        private string level;


        public string Member_id
        {
            set { member_id = value; }
            get { return member_id; }

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

        public string Level
        {
            set { level = value; }
            get { return level; }
        }


    }
}
