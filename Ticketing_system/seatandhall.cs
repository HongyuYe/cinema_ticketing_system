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
    public partial class seatandhall : Form
    {
        public seatandhall()
        {
            InitializeComponent();
           

        }


        #region 菜单栏操作
        private void 售票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            film_booting film_b1 = new film_booting();
            film_b1.Show();
        }

        private void 电影信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            film_manage film_m1 = new film_manage();
            film_m1.Show();
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

        private void 管理员操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            login login1 = new login();
            login1.Show();
            this.Hide();
        }
        #endregion



        #region 变量

    
        int num = 0; //选座个数
        public int F_id;
        public int Schedule_id;
        public string H_type;
        public string Date;
        public string filmtime;
        public string F_name;
        public string H_name;
        public int price;
        public string level;
        int row, column;
        int chang, kuan;  //座位高、宽
        int jiege; //座位间隔

        BLL.DealTicket dealticket = new BLL.DealTicket();
        Model.ticket ticketmodel = new Model.ticket();
        SeatKJ.UserControl1[,] pb = new SeatKJ.UserControl1[8, 10];

        #endregion


        private void seatandhall_Load(object sender, EventArgs e)
        {
            AddSeat();
        }


        #region 动态添加座位

        public void AddSeat()
        {

            BLL.Dealseat_empty dealseat_empty = new BLL.Dealseat_empty();

            if (H_name == "3号影厅")
            {
                row = 8;
                column = 10;
                chang = kuan = 35;
                jiege = 50;
            }
            else {
                row = 6;
                column = 10;
                chang = kuan = 45;
                jiege = 60;
            }
            for (int i = 0; i < row; i++)
                for (int j = 0; j < column; j++)
                {
                    pb[i, j] = new SeatKJ.UserControl1();
                    pb[i, j].Seat_id = (i * 10 + j + 1).ToString();

                    if (dealseat_empty.SeatIs_empty(Schedule_id, pb[i, j].Seat_id))            //判断座位是否为空
                    {
                        pb[i, j].BackColor = Color.Yellow;                          //可选设为黄色
                        pb[i, j].IsSelected = "0";
                        pb[i, j].Click += new System.EventHandler(pb_Yellow_Click);//为可选座位绑定到一个单击事件
                    }

                    else
                    {
                        pb[i, j].BackColor = Color.Red;                            //不可选设为红色
                    }
                    pb[i, j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    pb[i, j].Location = new System.Drawing.Point(70 + j * jiege, 90 + i * jiege);

                    pb[i, j].Name = (i * 10 + j + 1).ToString();
                    pb[i, j].Size = new System.Drawing.Size(chang, kuan);
                    pb[i, j].TabStop = false;

                    pb[i, j].label1.Text = (i * 10 + j + 1).ToString();
                    pb[i, j].label1.ForeColor = Color.Black;
                    pb[i, j].label1.Location = new System.Drawing.Point(5, 5);


                    this.panel1.Controls.Add(pb[i, j]);
                }


        }


        #endregion




        #region 可选座位Click事件

        public void pb_Yellow_Click(object sender, EventArgs e)
        {
            SeatKJ.UserControl1 pb = (SeatKJ.UserControl1)sender;

            if (pb.IsSelected == "0")
            {
                pb.BackColor = Color.Pink;
                pb.IsSelected = "1";
            }
            else
            {
                pb.BackColor = Color.Yellow;
                pb.IsSelected = "0";
            }
        }

        #endregion




        #region 确认选座Click事件

        private void button1_Click(object sender, EventArgs e)
        {


            num = 0;
            foreach (Control con in panel1.Controls)      //计算选座个数
            {
                if (con is SeatKJ.UserControl1)
                {
                    SeatKJ.UserControl1 pb = (SeatKJ.UserControl1)con;
                    if (pb.IsSelected == "1")
                        num++;
                }
            }

            textBox7.Text = F_name;
            textBox6.Text = H_name;
            textBox11.Text = Date;
            textBox10.Text = filmtime;
            textBox9.Text = num.ToString();
            if (MemberHelper.Use == true)
            {
                switch (MemberHelper.Level)
                {
                    case "黄金会员": textBox5.Text = ((int)(0.8 * (price * num))).ToString(); break;
                    case "白金会员": textBox5.Text = ((int)(0.6 * (price * num))).ToString(); break;
                }
                label12.Text = MemberHelper.Level;
            }
            else
                textBox5.Text = (price * num).ToString();
            groupBox3.Show();

        }

        #endregion




        #region 确认购票Click事件

        private void button2_Click(object sender, EventArgs e)
        {

            foreach (Control con in panel1.Controls)
            {
                if (con is SeatKJ.UserControl1)
                {
                    SeatKJ.UserControl1 pb = (SeatKJ.UserControl1)con;
                    if (pb.IsSelected == "1")                //确认选座
                    {
                        Model.seat_empty model = new Model.seat_empty();
                        model.Schedule_id = Schedule_id;
                        model.Seat_id = pb.Seat_id;
                        BLL.Dealseat_empty dealseat_empty = new BLL.Dealseat_empty();
                        if (dealseat_empty.Updateseat_empty(model))
                        {
                            pb.Click -= new System.EventHandler(pb_Yellow_Click);
                            pb.BackColor = Color.Red;
                            pb.IsSelected = "0";
                        }

                        ticketmodel.F_id = this.F_id;                               //购票成功 打印ticket信息，录入数据库 
                        ticketmodel.Schedule_id = this.Schedule_id;
                        ticketmodel.Deal_time = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        ticketmodel.Seat_id = pb.Seat_id;
                        if (MemberHelper.Use == true)
                        {
                            ticketmodel.Customer_id = MemberHelper.Name;      //若通过会员验证，则Costomer_id =会员卡号
                        }
                        else
                            ticketmodel.Customer_id = "000000";                //不是会员则Costomer_id = 000000(非会员)

                        ticketmodel.Price = Convert.ToInt32(Convert.ToDouble(textBox5.Text) / Convert.ToDouble(textBox9.Text));

                        dealticket.Addticket(ticketmodel);

                    }
                }
            }


            groupBox3.Hide();
          


        }

        #endregion




        #region 取消购票Click事件

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox3.Hide();
        }

        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            Pay_MemberLogin f = new Pay_MemberLogin();
            f.ShowDialog();
            if (MemberHelper.Use == true)
            {
                label12.Text = MemberHelper.Level;
                switch (MemberHelper.Level) {
                    case "黄金会员": textBox5.Text = ((int)(0.8 * (price * num))).ToString(); break;
                    case "白金会员": textBox5.Text = ((int)(0.6 * (price * num))).ToString(); break;
                }
               // MemberHelper.Use = false;
                groupBox3.Refresh();
            }
        }
 
        
    }
}
