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
    public partial class modefyfilm : Form
    {
        public modefyfilm()
        {
            InitializeComponent();
        }

        public int f_id;

        BLL.Dealfilm dealfilm = new BLL.Dealfilm();
        Model.film model = new Model.film();


        #region 修改电影信息
        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox13.Text.Trim() == "" || textBox12.Text.Trim() == "" || textBox11.Text.Trim() == "" || textBox8.Text.Trim() == "")
                MessageBox.Show("请填写完整电影信息!");
            else
            {
                model.F_id = f_id;
                model.F_name = textBox13.Text.Trim();
                model.Length = Convert.ToInt32(textBox12.Text.Trim());
                model.F_type = textBox11.Text.Trim();
                model.Price = Convert.ToInt32(textBox8.Text.Trim());
                if (dealfilm.Updatefilm(model))
                {
                    MessageBox.Show("修改成功!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("修改失败!");
                    this.Close();
                }
            }

        }

        #endregion

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
