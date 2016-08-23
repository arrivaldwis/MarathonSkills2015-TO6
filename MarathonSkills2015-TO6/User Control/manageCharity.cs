using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarathonSkills2015_TO6.User_Control
{
    public partial class manageCharity : UserControl
    {
        ICallback parent;
        DataClasses1DataContext data = new DataClasses1DataContext();

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public manageCharity()
        {
            InitializeComponent();
            getData();
        }

        private void getData()
        {
            foreach (var a in data.Charities)
            {
                this.panel2 = new System.Windows.Forms.Panel();
                this.pictureBox1 = new System.Windows.Forms.PictureBox();
                this.label6 = new System.Windows.Forms.Label();
                this.label7 = new System.Windows.Forms.Label();
                this.button1 = new System.Windows.Forms.Button();

                // 
                // panel2
                // 
                this.panel2.Controls.Add(this.button1);
                this.panel2.Controls.Add(this.label7);
                this.panel2.Controls.Add(this.label6);
                this.panel2.Controls.Add(this.pictureBox1);
                this.panel2.Location = new System.Drawing.Point(3, 36);
                this.panel2.Name = "panel2";
                this.panel2.Size = new System.Drawing.Size(737, 100);
                this.panel2.TabIndex = 1;
                // 
                // pictureBox1
                // 
                this.pictureBox1.Location = new System.Drawing.Point(9, 8);
                this.pictureBox1.Name = "pictureBox1";
                this.pictureBox1.Size = new System.Drawing.Size(100, 83);
                this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                this.pictureBox1.TabIndex = 0;
                this.pictureBox1.TabStop = false;
                this.pictureBox1.ImageLocation = Environment.CurrentDirectory + "/Resources/" + a.CharityLogo;
                // 
                // label6
                // 
                this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label6.Location = new System.Drawing.Point(120, 8);
                this.label6.Name = "label6";
                this.label6.Size = new System.Drawing.Size(155, 83);
                this.label6.TabIndex = 2;
                this.label6.Text = a.CharityName;
                // 
                // label7
                // 
                this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label7.Location = new System.Drawing.Point(340, 8);
                this.label7.Name = "label7";
                this.label7.Size = new System.Drawing.Size(325, 83);
                this.label7.TabIndex = 3;
                this.label7.Text = a.CharityDescription;
                // 
                // button1
                // 
                this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
                this.button1.BackColor = System.Drawing.Color.White;
                this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button1.ForeColor = System.Drawing.Color.Black;
                this.button1.Location = new System.Drawing.Point(671, 24);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(54, 32);
                this.button1.TabIndex = 72;
                this.button1.Text = "Edit";
                this.button1.UseVisualStyleBackColor = false;
                this.button1.Tag = a.CharityName;
                this.button1.Click += button1_Click;
                this.flowLayoutPanel1.Controls.Add(this.panel2);
            }
        }

        void button1_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            parent.aksi("ADDEDITCHARITIES", b.Tag.ToString(), "", "");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            parent.aksi("ADDEDITCHARITIES", "", "", "");
        }
    }
}
