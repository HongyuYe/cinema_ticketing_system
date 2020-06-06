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
    public partial class addfilm : Form
    {
        public addfilm()
        {
            InitializeComponent();
        }

        #region 添加电影

        private void button6_Click(object sender, EventArgs e)
        {
            BLL.Dealfilm dealfilm = new BLL.Dealfilm();
            Model.film model = new Model.film();

            if (textBox5.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox1.Text.Trim() == "")
                MessageBox.Show("请完整填写电影信息!");
            else
            {
                model.F_name = textBox5.Text.Trim();
                model.Length = Convert.ToInt32(textBox4.Text.Trim());
                model.F_type = textBox3.Text.Trim();
                model.Price = Convert.ToInt32(textBox1.Text.Trim());

                if (dealfilm.Addfilm(model))
                {
                    MessageBox.Show("添加电影成功!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("添加电影失败!");
                    this.Close();
                }
            
            }

        }

        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
