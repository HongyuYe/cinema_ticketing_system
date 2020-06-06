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
    public partial class film_booting : Form
    {

        BLL.Dealfilm dealfilm = new BLL.Dealfilm();
        BLL.Dealfilm_schedule dealfilm_schedule = new BLL.Dealfilm_schedule();
        DateTime Date;
        String strWhere;
        int F_id;
        
        public film_booting()
        {
            InitializeComponent();
        }

        #region 菜单栏操作
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

        private void 管理员操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login login1 = new login();
            login1.Show();
            this.Hide();
        }
        #endregion


        private void Fill()         //填充数据
        {
            strWhere = "F_name like '%" + namebox.Text.Trim() +"%'";
            Date = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
            dataGridView1.DataSource = dealfilm.GetfilmListByDate(Date,strWhere);
        }



         private void GetinfoButton_Click(object sender, EventArgs e)
         {
                Fill();
                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.DataSource = null;

         }

         private void film_booting_Load(object sender, EventArgs e)
         {
             Fill();
         }

         private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {
              F_id = (int)dataGridView1.CurrentRow.Cells[1].Value;
              Date = ((DateTime)dataGridView1.CurrentRow.Cells[0].Value);
              dataGridView2.DataSource = dealfilm_schedule.Getfilm_schedule3(F_id,Date);   

             
         }

         private void SellButton_Click(object sender, EventArgs e)
         {
             try
             {
                 seatandhall f = new seatandhall();
                 f.F_id = (int)dataGridView1.CurrentRow.Cells[1].Value;
                 f.Schedule_id = (int)dataGridView2.CurrentRow.Cells[0].Value;
                 f.H_type = (String)dataGridView2.CurrentRow.Cells[4].Value;
                 f.Date = ((DateTime)dataGridView1.CurrentRow.Cells[0].Value).ToShortDateString();
                 f.filmtime = (String)dataGridView2.CurrentRow.Cells[2].Value;
                 f.F_name = (String)dataGridView2.CurrentRow.Cells[1].Value;
                 f.H_name = (String)dataGridView2.CurrentRow.Cells[3].Value;
                 f.price = (int)dataGridView1.CurrentRow.Cells[5].Value;
                 f.ShowDialog();
                 MemberHelper.Use = false;

             }
             catch (System.Exception ex)
             {
                 MessageBox.Show("请选择有效数据行！");
                 return;
             }
     

         }
        

        
    }
}
