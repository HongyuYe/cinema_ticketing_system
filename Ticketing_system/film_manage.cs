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
    public partial class film_manage : Form
    {


        #region 变量

        BLL.Dealfilm dealfilm = new BLL.Dealfilm();
        Model.film model = new Model.film();
        int f_id;
        string f_name;
        string length;
        string f_type;
        int price;

        #endregion


        public film_manage()
        {
            InitializeComponent();
    
        }


        private void film_manage_Load(object sender, EventArgs e)
        {
            Fill();
        }


        private void Fill()         //填充数据
        {
            dataGridView1.DataSource = dealfilm.Getallfilm();
        }



        #region 增加电影信息
        private void button2_Click(object sender, EventArgs e)
        {
            addfilm f = new addfilm();
            f.ShowDialog();
            Fill();
        }
        #endregion



        #region 修改电影信息
        private void button4_Click(object sender, EventArgs e)    //这里要显示原有数据，点击行数之后panel3.Show();
        {
            try
            {
                f_id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请选择有效数据行！");
                return;
            }

            modefyfilm f = new modefyfilm();
            f.f_id = f_id;
            f.textBox13.Text = (string)dataGridView1.CurrentRow.Cells[1].Value;
            f.textBox12.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            f.textBox11.Text = (string)dataGridView1.CurrentRow.Cells[3].Value;
            f.textBox8.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            f.ShowDialog();
            Fill();

        }




        #endregion



        #region 菜单栏操作
        private void ad_exit(object sender, EventArgs e)
        {
            login login1 = new login();
            login1.Show();
            this.Hide();
        }

        private void 会员管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mem_manage mem_m1 = new mem_manage();
            mem_m1.Show();
        }

        private void 营业情况ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selling selling1 = new selling();
            selling1.Show();
        }
        #endregion



        #region 档期管理按钮事件

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                f_id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                f_name = (string)dataGridView1.CurrentRow.Cells[1].Value;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请选择有效数据行！");
                return;
            }

            film_scedule fi_1 = new film_scedule();
            fi_1.f_id = f_id;
            fi_1.filmnamebox.Text = f_name;
            fi_1.ShowDialog();
            Fill();
        }

        #endregion



        #region 查询按钮事件

        private void button1_Click(object sender, EventArgs e)
        {

            f_name = textBox2.Text.Trim();


            if (f_name == "")
                Fill();
            else
            {
                string strWhere = "f_name like '%" + f_name + "%'";
                dataGridView1.DataSource = dealfilm.GetFilmList(strWhere);

            }

        }

        #endregion



        #region 删除按钮事件
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                f_id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请选择有效数据行！");
                return;
            }

            if (dealfilm.Deletefilm(f_id))
            {
                MessageBox.Show("删除成功!");
                Fill();
            }
            else {
                MessageBox.Show("删除失败!");
                Fill();
            }

        }

        #endregion



    }
}
