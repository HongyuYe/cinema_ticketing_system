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
    public partial class mem_manage : Form
    {
        public mem_manage()
        {
            InitializeComponent();
            
        }

        BLL.Dealmember dealmember = new BLL.Dealmember();

        private void mem_manage_Load(object sender, EventArgs e)
        {
            Fill();
        }


        private void Fill()         //填充数据
        {
            dataGridView1.DataSource = dealmember.GetMember();
        }


    
        #region 菜单栏操作
        private void 售票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            film_booking film_m1 = new film_booking();
            film_m1.Show();
        }
        private void 电影信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            film_manage film_m1 = new film_manage();
            film_m1.Show();
        }
        private void 营业情况ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selling selling1 = new selling();
            selling1.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login login1 = new login();
            login1.Show();
            this.Hide();
        }
        #endregion


        #region 添加会员事件

        private void AddButton_Click(object sender, EventArgs e)
        {
            string member_id = cardbox.Text.Trim();
            string name = namebox.Text.Trim();
            string password = this.passwordbox.Text.Trim();
            string level = null;

            if (member_id == "" || name == "" || password == "")
            {
                MessageBox.Show("卡号或姓名或密码不能为空！");
                cardbox.Focus();
                return;
            }
            else if (levelcombo.SelectedIndex < 0)
            {
                MessageBox.Show("你没有选择身份");
            }
            else
            {

                if (levelcombo.SelectedIndex == 0)
                {
                    level = "黄金会员";

                }
                else
                {
                    level = "白金会员";

                }

                Model.member model = new Model.member();
                model.Member_id = member_id;
                model.Name = name;
                model.Password = password;
                model.Level = level;
                if (dealmember.Addmember(model))
                {
                    MessageBox.Show("添加成功");
                    Fill();
                }
                else
                    MessageBox.Show("添加失败");
            }
        }

        #endregion


        #region 升级按钮事件

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            string member_id;
            try
            {
                member_id = (String)dataGridView1.CurrentRow.Cells[0].Value;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请选择有效数据行！");
                return;
            }

            Model.member model = new Model.member();
            model = dealmember.GetOnemember(member_id);
            if (model.Level == "白金会员")
            {
                MessageBox.Show("已经是白金会员！");
            }
            else if (model.Level == "黄金会员")
            {
                if (MessageBox.Show(" 要升级为白金会员吗？", "询问", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;

                model.Level = "白金会员";
                if (dealmember.Updatemember_passwd(model))
                {
                    MessageBox.Show("升级成功！");
                    Fill();
                }

            }
        }

        #endregion


        #region 删除按钮事件

        private void DelButton_Click(object sender, EventArgs e)
        {
            string member_id;
            try
            {
                member_id = (String)dataGridView1.CurrentRow.Cells[0].Value;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请选择有效数据行！");
                return;
            }
            if (MessageBox.Show(" 确定要删除吗？", "询问", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            if (dealmember.Deletemember(member_id))
            {
                MessageBox.Show("删除成功！");
            }
            else
            {
                MessageBox.Show("删除失败！");
            }
            Fill();
        }

        #endregion


        #region 查询按钮事件

        private void GetinfoButton_Click(object sender, EventArgs e)
        {
            string member_id = cardbox.Text.Trim();
            string name = namebox.Text.Trim();
            string password = this.passwordbox.Text.Trim();
            string strwhere;
            string level;

            if (member_id == "" && name == "" && levelcombo.SelectedIndex < 0)
            {
                MessageBox.Show("没有查询条件！");
                cardbox.Focus();
                return;
            }
            else if (levelcombo.SelectedIndex < 0)
            {   //没有选择身份的查询
                if (member_id == "")
                {
                    strwhere = "name like '%" + namebox.Text + "%'";
                }
                else if (name == "")
                {
                    strwhere = "member_id like '%" + cardbox.Text + "%'";
                }
                else
                {
                    strwhere = "name like '%" + namebox.Text + "%' and member_id like '%" + cardbox.Text + "%'";
                }

            }
            else
            {


                if (levelcombo.SelectedIndex == 0)    
                    level = "黄金会员";
                else
                    level = "白金会员";

                if (member_id == "" && name == "")
                {
                    strwhere = "level = '" + level + "'";
                }
                else if (member_id == "")
                {
                    strwhere = "name like '%" + namebox.Text + "%'" + " and level = '" + level + "'";
                }
                else if (name == "")
                {
                    strwhere = "member_id like '%" + cardbox.Text + "%'" + " and level = '" + level + "'";
                }
                else
                {
                    strwhere = "name like '%" + namebox.Text + "%'" + " and member_id like '%" + cardbox.Text + "%'" + " and level = '" + level + "'";
                }

            }

            dataGridView1.DataSource = dealmember.GetList(strwhere);

        }

      #endregion


        #region 修改密码按钮事件

        private void ModifyPsdButton_Click(object sender, EventArgs e)
        {
            panel2.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string member_id;
            string oldpassword;
            string newpassword;
            try
            {
                member_id = (String)dataGridView1.CurrentRow.Cells[0].Value;            
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请选择有效数据行！");
                return;
            }

            if (textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "")
                MessageBox.Show("请输入原密码和新密码!");
            else
            {
                oldpassword = textBox5.Text.Trim();                //member_id和原密码匹配正确，则修改新密码
                if (dealmember.Login(member_id, oldpassword))
                {

                    newpassword = textBox6.Text.Trim();
                    if (dealmember.Updatemember_passwd2(member_id, newpassword))
                    {
                        MessageBox.Show("修改成功!");
                    }
                    else
                        MessageBox.Show("修改失败!");
                }
                else
                    MessageBox.Show("原密码不正常!");

                panel2.Hide();
                Fill();
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }


        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
