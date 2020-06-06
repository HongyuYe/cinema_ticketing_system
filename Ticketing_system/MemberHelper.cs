using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing_system
{
    public class MemberHelper
    {
        static private string name;

        static public string Name
        {
            get { return name; }
            set { name = value; }
        }
        static private string pass;

        static public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
       static private bool use;

        static public bool Use
        {
            get { return use; }
            set { use = value; }
        }

        static private string level;

        static public string Level
        {
            get { return level; }
            set { level = value; }
        }
    }
}
