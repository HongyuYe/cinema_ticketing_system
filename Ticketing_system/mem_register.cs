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
    public partial class mem_register : Form
    {
        public mem_register()
        {
            InitializeComponent();
        }

        BLL.Dealmember dealmember = new BLL.Dealmember();

        private void button1_Click(object sender, EventArgs e)
        {
            string member_id = textBox1.Text.Trim();
            string password = this.textBox2.Text.Trim();
            string name = textBox3.Text.Trim();
            string level = null;

            if (member_id == "" || name == "" || password == "")
            {
                MessageBox.Show("卡号或姓名或密码不能为空！");
                textBox1.Focus();
                return;
            }
            else
            {
                Model.member model = new Model.member();
                model.Member_id = member_id;
                model.Name = name;
                model.Password = password;
                model.Level = "黄金会员";
                if (dealmember.Addmember(model))
                {
                    MessageBox.Show("注册成功");
                }
                else
                    MessageBox.Show("注册失败");
            }
        }

            private void mem_register_Load(object sender, EventArgs e)
        {

        }
    }
}
