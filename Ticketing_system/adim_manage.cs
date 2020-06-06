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
    public partial class adim_manage : Form
    {
        public adim_manage()
        {
            InitializeComponent();
        }
        BLL.Dealticketing_seller dealticket_seller = new BLL.Dealticketing_seller();
        private static int passwordColIndex = 2;//密码列

        private void adim_manage_Load(object sender, EventArgs e)
        {
            Fill();
        }


        private void Fill()//填充数据
        {
            dataGridView1.DataSource = dealticket_seller.Getallseller();
        }

        public void ClearPanel() //清空panel数据
        {
            textBox7.Text = "";
            textBox6.Text = "";
        }


        #region 菜单栏操作
        private void 售票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            film_booting film_m1 = new film_booting();
            film_m1.ShowDialog();
        }

        private void 电影信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            film_manage film_m1 = new film_manage();
            film_m1.ShowDialog();
        }

        private void 会员管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mem_manage mem_m1 = new mem_manage();
            mem_m1.ShowDialog();
        }

        private void 营业情况ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selling selling1 = new selling();
            selling1.ShowDialog();

        }

        private void 管理员操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login login1 = new login();
            login1.ShowDialog();
            this.Hide();

        }
        #endregion

        private void button1_Click(object sender, EventArgs e)//添加售票员
        {


            ClearPanel();
            panel3.Show();
            Fill();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Hide();
        }

        private void button3_Click(object sender, EventArgs e)//删除售票员
        {

            int T_id;
            try
            {
                T_id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请选择有效数据行");
                return;
            }
            if (MessageBox.Show(" 确定要删除吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            if (dealticket_seller.Deleteticketing_seller(T_id))
            {
                MessageBox.Show("删除成功");
                Fill();
            }
            else
            {
                MessageBox.Show("删除失败");
                Fill();
            }



        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel3.Hide();
        }

        public int t_id;
        public string name;
        public string password;
        public int super_seller;

        private void button2_Click(object sender, EventArgs e)//修改按钮
        {


            try
            {
                t_id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请选择有效的数据行");
                return;
            }

            panel1.Show();

            textBox8.Text = (string)dataGridView1.CurrentRow.Cells[1].Value;//导入原值
            textBox1.Text = (string)dataGridView1.CurrentRow.Cells[2].Value;//导入原值

            try
            {
                if ((int)dataGridView1.CurrentRow.Cells[3].Value == 0) //导入原值
                {
                    comboBox2.SelectedIndex = 0;
                }
                else
                {
                    comboBox2.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {

            }


        }



        private void button8_Click(object sender, EventArgs e)//更新售票员信息
        {
            string name;
            string password;
            int super;
            int t_id;
            Model.ticketing_seller model = new Model.ticketing_seller();
            if (textBox8.Text.Trim() == "" || textBox1.Text.Trim() == "" || comboBox2.SelectedIndex < 0)
            {
                MessageBox.Show("请填写完整的信息");
                textBox8.Focus();
                return;

            }
            else
            {

                name = textBox8.Text.Trim();
                password = textBox1.Text.Trim();
                t_id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                if (comboBox2.SelectedIndex == 0)
                {
                    super = 0;
                }
                else
                {
                    super = 1;
                }

                model.Name = name;
                model.Password = password;
                model.Super_seller = super;
                model.T_id = t_id;
                if (dealticket_seller.Updateseller_password(model))
                {
                    MessageBox.Show("更新成功");
                    panel1.Hide();
                    Fill();
                }
                else
                {
                    MessageBox.Show("更新失败");
                    panel1.Hide();
                }


            }
        }


        private void button5_Click_1(object sender, EventArgs e)
        {
            panel1.Hide();
        }



        private void button7_Click(object sender, EventArgs e) //添加管理员
        {
            name = textBox7.Text.Trim();
            password = textBox6.Text.Trim();


            if (name == " " || password == " ")
            {
                MessageBox.Show("用户名和密码不能为空");
                textBox7.Focus();
                return;
            }
            else if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("请选择身份！");
            }
            else
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    super_seller = 0;
                }
                else
                {
                    super_seller = 1;
                }
                Model.ticketing_seller model = new Model.ticketing_seller();
                model.Name = name;
                model.Password = password;
                model.Super_seller = super_seller;
                if (dealticket_seller.AddTicketing_seller(model))
                {
                    MessageBox.Show("添加成功");
                    Fill();

                    panel3.Hide();



                }
                else
                {
                    MessageBox.Show("添加失败");
                    panel3.Hide();
                }
            }

        }



        private void button4_Click(object sender, EventArgs e)//查询按钮
        {

            int t_id;
            string name;
            string strWhere;
            name = textBox4.Text.Trim();


            if (textBox3.Text.Trim() == "" && name == "")
            {
                //MessageBox.Show("请输入完整的信息");
                //return;
                 Fill();
            }
            if (textBox3.Text.Trim() == "") //如果工号为空，只查询姓名
            {
                strWhere = " name like '%" + textBox4.Text + "%'";

            }
            else if (textBox4.Text.Trim() == "")//如果姓名为空，只查询工号
            {

                t_id = int.Parse(textBox3.Text);
                strWhere = " t_id like '%" + t_id + "%'";
            }
            else//工号姓名都不为空
            {
                t_id = int.Parse(textBox3.Text);
                strWhere = "name like '%" + textBox4.Text + "%'" + "  and t_id like '%" + t_id + "%'";

            }
            dataGridView1.DataSource = dealticket_seller.Getseller(strWhere);
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("未找到符合条件的数据");

                Fill();
            }

        }

    

  

        //添加事件1
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int i = this.dataGridView1.CurrentCell.ColumnIndex;
            if (i == passwordColIndex)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.UseSystemPasswordChar = true;    //密码换*
                }
            }
        }
        //添加事件2
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string s = e.Value as string;
            if (e.ColumnIndex == passwordColIndex)
            {
                e.Value = "".PadLeft(s.Length, '*');    //按照密码位数补齐*号
            }
        }

    }
}
