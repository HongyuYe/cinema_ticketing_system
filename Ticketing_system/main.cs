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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }
       
        #region 5大模块
        private void p4(object sender, MouseEventArgs e)
        {
            selling selling1 = new selling();
            selling1.Show();
        }
        private void p2(object sender, MouseEventArgs e)
        {
            film_manage film_m1 = new film_manage();
            film_m1.Show();
        }

        private void p3(object sender, MouseEventArgs e)
        {
            mem_manage mem_m1 = new mem_manage();
            mem_m1.Show();
        }

        private void p5(object sender, MouseEventArgs e)
        {
            BLL.Dealticketing_seller dealticket_seller = new BLL.Dealticketing_seller();
            string id1 = SellerHelper.Id;
            int id2 = Convert.ToInt32(id1);

            if (dealticket_seller.getSuper_seller(id2))//判断是否为超级管理员
            {
                adim_manage ai_m1 = new adim_manage();
                ai_m1.Show();
            }
            else
            {
                MessageBox.Show("权限不够");
            }
        }

        private void p1(object sender, MouseEventArgs e)
        {
            film_booking film_b1 = new film_booking();
            film_b1.Show();
        }
        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
