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

        static bool is_member;

        static public bool Is_member
        {
            get { return is_member; }
            set { is_member = value; }
        }

        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t_id = textBox1.Text.Trim();
            string password = this.textBox2.Text.Trim();
            is_member = false;
            if (t_id == "" || password == "")
            {
                MessageBox.Show("用户名或密码不能为空！");
                textBox1.Focus();
                return;
            }
            else
            {
                BLL.Dealticketing_seller dealticketing_seller = new BLL.Dealticketing_seller();

                if (dealticketing_seller.Login(Convert.ToInt32(t_id), password)) //判断是否为管理员
                {
                    SellerHelper.Id = textBox1.Text.Trim();              //用SellerHelper记录id与密码
                    SellerHelper.Password = textBox2.Text.Trim();
                    this.Hide();
                    main f = new main();
                    f.Show();
                }
                else
                {
                    BLL.Dealmember dealmember = new BLL.Dealmember();
                    Model.member model = new Model.member();

                    if (dealmember.Login(t_id, password)) //判断是否为会员
                    {
                        is_member = true;
                        model = dealmember.GetOnemember(t_id);
                        MemberHelper.Level = model.Level;
                        MemberHelper.Use = true;
                        MemberHelper.Name = t_id;
                        this.Hide();
                        film_booking film_b1 = new film_booking();
                        film_b1.Show();
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mem_register mem_r1 = new mem_register();
            mem_r1.Show();

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
