using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ticketing_system
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t_id = textBox1.Text.Trim();
            string password = this.textBox2.Text.Trim();
            if (t_id == "" || password == "")
            {
                MessageBox.Show("用户名或密码不能为空！");
                textBox1.Focus();
                return;
            }
            else
            {
                BLL.Dealticketing_seller dealticketing_seller = new BLL.Dealticketing_seller();
                
                if (dealticketing_seller.Login(Convert.ToInt32(t_id), password))
                {
                    SellerHelper.Id = textBox1.Text.Trim();              //用SellerHelper记录id与密码
                    SellerHelper.Password = textBox2.Text.Trim();
                    this.Hide();
                    main f = new main();
                    f.Show();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误，请重新输入！", "错误");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Focus();
                }
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
