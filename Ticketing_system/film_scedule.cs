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
    public partial class film_scedule : Form
    {


        #region 变量

        public int f_id;
        int Schedule_id;
        DateTime datetime;
        string time;
        string h_id;
        BLL.Dealfilm_schedule dealschedule = new BLL.Dealfilm_schedule();
        Model.film_schedule model = new Model.film_schedule();

        #endregion

        public film_scedule()
        {
            InitializeComponent();
        }

        
        private void film_scedule_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()         //填充数据
        {
            string strWhere;
            strWhere = " film.f_id = " + f_id;
            dataGridView1.DataSource = dealschedule.GetFilm_scheduleList(strWhere);
        }


        private void AddScheduleButton_Click(object sender, EventArgs e)
        {
            panel2.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel3.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }



        #region 删除电影排期

        private void DelButton_Click(object sender, EventArgs e)   //选择该行，才能进行删除操作， MessageBox.Show("确定删除？");
        {
            int delSchedule_id;
            try
            {
                f_id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                datetime = (DateTime)dataGridView1.CurrentRow.Cells[2].Value;
                time = (String)dataGridView1.CurrentRow.Cells[3].Value;
                switch ((String)dataGridView1.CurrentRow.Cells[4].Value)
                {
                    case "1号影厅": h_id = "001"; break;
                    case "2号影厅": h_id = "002"; break;
                    case "3号影厅": h_id = "003"; break;

                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请选择有效数据行！");
                return;
            }
            if (MessageBox.Show(" 确定删除？", "询问", MessageBoxButtons.YesNo,
                  MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            delSchedule_id = dealschedule.Getfilm_scheduleid(f_id, datetime, time, h_id);   //读取排期原来值显示在修改panel中

            

            BLL.Dealseat_empty dealseat_empty = new BLL.Dealseat_empty();
            if (dealseat_empty.Deleteseat_emptyall(delSchedule_id)&&dealschedule.Deletefilm_schedule(delSchedule_id))   //删除排期对应的座位信息以及删除排期
            {
                Fill();
                MessageBox.Show("删除成功！");
            }
            else
            {
                Fill();
                MessageBox.Show("删除失败！");
            }
        }
      
        #endregion




        #region 修改档期按钮事件

        private void ModefyButton_Click(object sender, EventArgs e)  //选择该行，才能修改，然后 panel3.show();
        {
          
 
            try
            {
                f_id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                datetime = (DateTime)dataGridView1.CurrentRow.Cells[2].Value;
                time = (String)dataGridView1.CurrentRow.Cells[3].Value;
                switch ((String)dataGridView1.CurrentRow.Cells[4].Value)
                {
                    case "1号影厅": h_id = "001"; break;
                    case "2号影厅": h_id = "002"; break;
                    case "3号影厅": h_id = "003"; break;

                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请选择有效数据行！");
                return;
            }
          

            Schedule_id = dealschedule.Getfilm_scheduleid(f_id, datetime, time, h_id);   //读取排期原来值显示在修改panel中
            model = dealschedule.GetModel1(Schedule_id);
            comboBox3.Text = model.H_id;
            DatePicker2.Value = model.Date; 
            string[] time1 = model.Time.Split(':');
            comboBox6.Text = time1[0];
            comboBox7.Text  = time1[1];
            panel3.Show();


        }
       
        #endregion




        #region 查询当天所有档期按钮事件(所有电影)

        private void GetInfoButton_Click(object sender, EventArgs e)
        {
            
            DateTime searchDate = Convert.ToDateTime(DatePicker1.Value.ToShortDateString());
            dataGridView1.DataSource = dealschedule.GetFilmByidDate_scheduleList(f_id,searchDate);
        }

        #endregion




        #region 增加排期

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox8.SelectedIndex < 0 || comboBox2.SelectedIndex < 0 || comboBox1.SelectedIndex < 0)
                MessageBox.Show("请填写完整排期信息!");
            else
            {
                model.F_id = f_id;
                model.H_id = comboBox8.Text;
                string hour = comboBox2.Text;
                string minute = comboBox1.Text;
                DateTime date = Convert.ToDateTime(DatePicker3.Value.ToShortDateString());   //获取datatime并使时间部分为0
                model.Date = date;
                model.Time = hour + ":" + minute;


                BLL.Dealseat_empty dealseat_empty = new BLL.Dealseat_empty();
                Model.seat_empty emptymodel = new Model.seat_empty();
                emptymodel.Is_empty = 1;
                emptymodel.Schedule_id = dealschedule.Addfilm_schedule2(model);   //插入film_schedule表并获得schedule_id


                if (model.H_id == "001" || model.H_id == "002") //根据schedule_id和h_id生成seat_empty表的座位数据 Is_empty的值为1
                {
                    for (int i = 1; i <= 60; i++)
                    {
                        emptymodel.Seat_id = i.ToString();
                        dealseat_empty.Add(emptymodel);
                    }

                }
                else
                {
                    for (int i = 1; i <= 80; i++)
                    {
                        emptymodel.Seat_id = i.ToString();
                        dealseat_empty.Add(emptymodel);
                    }
                }

                MessageBox.Show("添加排期成功!");
                Fill();
            }

        }
        #endregion




        #region 修改排期确定

        private void button8_Click(object sender, EventArgs e)
        {
            
            if (comboBox3.SelectedIndex < 0 || comboBox6.SelectedIndex < 0 || comboBox7.SelectedIndex < 0)
                MessageBox.Show("请填写完整排期信息!");
            else
            {
                string newhall_id = comboBox3.Text;
                DateTime date = Convert.ToDateTime(DatePicker2.Value.ToShortDateString());
                model.Date = date;
                string hour = comboBox6.Text;
                string minute = comboBox7.Text;
                model.Time = hour + ":" + minute;

                BLL.Dealseat_empty dealseat_empty = new BLL.Dealseat_empty();
                Model.seat_empty emptymodel = new Model.seat_empty();

                if (model.H_id != newhall_id)
                {
                    if (model.H_id != "003" && newhall_id != "003") {
                        model.H_id = newhall_id;                   
                    }
                    else if (model.H_id != "003" && newhall_id == "003")
                    {
                        model.H_id = newhall_id;
                        emptymodel.Schedule_id = Schedule_id;
                        emptymodel.Is_empty = 1;
                        for (int i = 61; i <= 80; i++)
                        { 
                            emptymodel.Seat_id = i.ToString();
                            dealseat_empty.Add(emptymodel);
                        }
                     }
                    else {
                        model.H_id = newhall_id;
                        for (int i = 61; i <= 80; i++)
                           dealseat_empty.Deleteseat_empty(Schedule_id, i.ToString());
    
                    }    
                }
                dealschedule.Updatefilm_schedule(model);

            }

            Fill();
            MessageBox.Show("修改成功!");
        }

        #endregion




        #region 查询当天电影档期(单部电影)

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime searchDate = Convert.ToDateTime(DatePicker1.Value.ToShortDateString());
            dataGridView1.DataSource = dealschedule.GetFilmByDate_scheduleList(searchDate);
        }

        #endregion





    }
}
