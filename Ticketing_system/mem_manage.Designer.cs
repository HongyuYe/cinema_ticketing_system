namespace Ticketing_system
{
    partial class mem_manage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mem_manage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.levelcombo = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ModifyPsdButton = new System.Windows.Forms.Button();
            this.cardbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.passwordbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.namebox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.GetinfoButton = new System.Windows.Forms.Button();
            this.DelButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.售票ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.电影信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.营业情况ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.管理员操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.levelcombo);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.ModifyPsdButton);
            this.panel1.Controls.Add(this.cardbox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.passwordbox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.namebox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.UpdateButton);
            this.panel1.Controls.Add(this.GetinfoButton);
            this.panel1.Controls.Add(this.DelButton);
            this.panel1.Controls.Add(this.AddButton);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 453);
            this.panel1.TabIndex = 0;
            // 
            // levelcombo
            // 
            this.levelcombo.FormattingEnabled = true;
            this.levelcombo.Items.AddRange(new object[] {
            "黄金会员",
            "白金会员"});
            this.levelcombo.Location = new System.Drawing.Point(662, 382);
            this.levelcombo.Name = "levelcombo";
            this.levelcombo.Size = new System.Drawing.Size(80, 20);
            this.levelcombo.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.textBox6);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.textBox5);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(234, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 175);
            this.panel2.TabIndex = 25;
            this.panel2.Visible = false;
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.Location = new System.Drawing.Point(154, 127);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(60, 28);
            this.button7.TabIndex = 34;
            this.button7.Text = "取  消";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(36, 127);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(60, 28);
            this.button6.TabIndex = 26;
            this.button6.Text = "确  认";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(84, 87);
            this.textBox6.Name = "textBox6";
            this.textBox6.PasswordChar = '*';
            this.textBox6.Size = new System.Drawing.Size(130, 21);
            this.textBox6.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 30;
            this.label8.Text = "新密码：";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(84, 50);
            this.textBox5.Name = "textBox5";
            this.textBox5.PasswordChar = '*';
            this.textBox5.Size = new System.Drawing.Size(130, 21);
            this.textBox5.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "原密码：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(94, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "修改密码";
            // 
            // ModifyPsdButton
            // 
            this.ModifyPsdButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ModifyPsdButton.Location = new System.Drawing.Point(767, 97);
            this.ModifyPsdButton.Name = "ModifyPsdButton";
            this.ModifyPsdButton.Size = new System.Drawing.Size(75, 34);
            this.ModifyPsdButton.TabIndex = 24;
            this.ModifyPsdButton.Text = "修改密码";
            this.ModifyPsdButton.UseVisualStyleBackColor = true;
            this.ModifyPsdButton.Click += new System.EventHandler(this.ModifyPsdButton_Click);
            // 
            // cardbox
            // 
            this.cardbox.Location = new System.Drawing.Point(464, 382);
            this.cardbox.Name = "cardbox";
            this.cardbox.Size = new System.Drawing.Size(130, 21);
            this.cardbox.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(414, 382);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "卡 号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(611, 384);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "身  份：";
            // 
            // passwordbox
            // 
            this.passwordbox.Location = new System.Drawing.Point(270, 381);
            this.passwordbox.Name = "passwordbox";
            this.passwordbox.Size = new System.Drawing.Size(130, 21);
            this.passwordbox.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 381);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "密  码：";
            // 
            // namebox
            // 
            this.namebox.Location = new System.Drawing.Point(62, 381);
            this.namebox.Name = "namebox";
            this.namebox.Size = new System.Drawing.Size(130, 21);
            this.namebox.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 381);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "姓  名：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(4, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(748, 321);
            this.dataGridView1.TabIndex = 13;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "member_id";
            this.Column2.HeaderText = "卡   号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "name";
            this.Column1.HeaderText = "会员名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Level";
            this.Column3.HeaderText = "身   份";
            this.Column3.Name = "Column3";
            // 
            // UpdateButton
            // 
            this.UpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.UpdateButton.Location = new System.Drawing.Point(767, 42);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 32);
            this.UpdateButton.TabIndex = 11;
            this.UpdateButton.Text = "升  级";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // GetinfoButton
            // 
            this.GetinfoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GetinfoButton.Location = new System.Drawing.Point(767, 420);
            this.GetinfoButton.Name = "GetinfoButton";
            this.GetinfoButton.Size = new System.Drawing.Size(75, 21);
            this.GetinfoButton.TabIndex = 9;
            this.GetinfoButton.Text = "查  询";
            this.GetinfoButton.UseVisualStyleBackColor = true;
            this.GetinfoButton.Click += new System.EventHandler(this.GetinfoButton_Click);
            // 
            // DelButton
            // 
            this.DelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DelButton.Location = new System.Drawing.Point(767, 320);
            this.DelButton.Name = "DelButton";
            this.DelButton.Size = new System.Drawing.Size(75, 34);
            this.DelButton.TabIndex = 8;
            this.DelButton.Text = "删  除";
            this.DelButton.UseVisualStyleBackColor = true;
            this.DelButton.Click += new System.EventHandler(this.DelButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddButton.Location = new System.Drawing.Point(767, 381);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 22);
            this.AddButton.TabIndex = 6;
            this.AddButton.Text = "增  加";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BackgroundImage")));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.售票ToolStripMenuItem,
            this.电影信息ToolStripMenuItem,
            this.营业情况ToolStripMenuItem,
            this.管理员操作ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(854, 29);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 售票ToolStripMenuItem
            // 
            this.售票ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.售票ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.售票ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.售票ToolStripMenuItem.Name = "售票ToolStripMenuItem";
            this.售票ToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.售票ToolStripMenuItem.Text = "订票";
            this.售票ToolStripMenuItem.Click += new System.EventHandler(this.售票ToolStripMenuItem_Click);
            // 
            // 电影信息ToolStripMenuItem
            // 
            this.电影信息ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.电影信息ToolStripMenuItem.Name = "电影信息ToolStripMenuItem";
            this.电影信息ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.电影信息ToolStripMenuItem.Text = "电影信息";
            this.电影信息ToolStripMenuItem.Click += new System.EventHandler(this.电影信息ToolStripMenuItem_Click);
            // 
            // 营业情况ToolStripMenuItem
            // 
            this.营业情况ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.营业情况ToolStripMenuItem.Name = "营业情况ToolStripMenuItem";
            this.营业情况ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.营业情况ToolStripMenuItem.Text = "营业情况";
            this.营业情况ToolStripMenuItem.Click += new System.EventHandler(this.营业情况ToolStripMenuItem_Click);
            // 
            // 管理员操作ToolStripMenuItem
            // 
            this.管理员操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.管理员操作ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.管理员操作ToolStripMenuItem.Name = "管理员操作ToolStripMenuItem";
            this.管理员操作ToolStripMenuItem.Size = new System.Drawing.Size(102, 25);
            this.管理员操作ToolStripMenuItem.Text = "管理员操作";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(107, 24);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // mem_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 453);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mem_manage";
            this.Text = "电影订票系统";
            this.Load += new System.EventHandler(this.mem_manage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button GetinfoButton;
        private System.Windows.Forms.Button DelButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 售票ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 电影信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 营业情况ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 管理员操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passwordbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox namebox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cardbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ModifyPsdButton;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ComboBox levelcombo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}