using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticketing_system
{
    public partial class selling : Form
    {
        public selling()
        {
            InitializeComponent();
        }
        private void selling_Load(object sender, EventArgs e)
        {
            Fill();
        }
        BLL.DealTicket dealticket = new BLL.DealTicket();
        DateTime datet = new DateTime();
        private void Fill()         //填充hi数据
        {

            datet = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
            dataGridView1.DataSource = dealticket.GetTicketNumber(datet);
            //输出票房排名
            int rank1 = 0;
            int lastselling = 0;
            int tmp;
            foreach (DataGridViewRow row in dataGridView1.Rows)//对所有行进行操作
            {
                tmp = (int)row.Cells[1].Value;
                if (tmp == lastselling)
                {
                    row.Cells[2].Value = rank1;
                    lastselling = (int)row.Cells[1].Value;
                }
                else
                {
                    rank1 = rank1 + 1;
                    lastselling = (int)row.Cells[1].Value;
                    row.Cells[2].Value = rank1;
                }
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Fill();
        }


    }
}
