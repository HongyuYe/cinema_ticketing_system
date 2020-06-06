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
    public partial class Pay_MemberLogin : Form
    {
        public Pay_MemberLogin()
        {
            InitializeComponent();
        }


        BLL.Dealmember dealmember = new BLL.Dealmember();
        Model.member model = new Model.member();
        string member_id;
        string password;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
            {
                MessageBox.Show("请填写完整!");
            }
            else
            {
                member_id = textBox1.Text.Trim();
                password = textBox2.Text.Trim();
                if (dealmember.Login(member_id, password))
                {
                    model = dealmember.GetOnemember(member_id);
                    MemberHelper.Level = model.Level;
                    MemberHelper.Use = true;
                    MemberHelper.Name = member_id;
                    MessageBox.Show("验证成功!");
                    this.Close();
                }
                else
                    MessageBox.Show("验证失败!");
            }
        }
    }
}
