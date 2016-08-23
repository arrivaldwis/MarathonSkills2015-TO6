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
    public partial class listOfCharities : UserControl
    {
        ICallback parent;
        DataClasses1DataContext data = new DataClasses1DataContext();

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public listOfCharities()
        {
            InitializeComponent();
            getData();
        }

        private void getData()
        {
            var getCharities = data.Charities;

            foreach (var a in getCharities)
            {
                this.panel1 = new System.Windows.Forms.Panel();
                this.pictureBox1 = new System.Windows.Forms.PictureBox();
                this.label3 = new System.Windows.Forms.Label();
                this.label4 = new System.Windows.Forms.Label();

                // 
                // panel1
                // 
                this.panel1.Controls.Add(this.label3);
                this.panel1.Controls.Add(this.label4);
                this.panel1.Controls.Add(this.pictureBox1);
                this.panel1.Location = new System.Drawing.Point(3, 3);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(686, 100);
                this.panel1.TabIndex = 0;
                // 
                // pictureBox1
                // 
                this.pictureBox1.Location = new System.Drawing.Point(9, 7);
                this.pictureBox1.Name = "pictureBox1";
                this.pictureBox1.Size = new System.Drawing.Size(115, 88);
                this.pictureBox1.TabIndex = 0;
                this.pictureBox1.TabStop = false;
                this.pictureBox1.ImageLocation = Environment.CurrentDirectory + "/Resources/" + a.CharityLogo;
                this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                // 
                // label3
                // 
                this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
                this.label3.Location = new System.Drawing.Point(136, 37);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(547, 58);
                this.label3.TabIndex = 13;
                this.label3.Text = a.CharityDescription;
                this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.label3.Click += new System.EventHandler(this.label3_Click);
                // 
                // label4
                // 
                this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
                this.label4.AutoSize = true;
                this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
                this.label4.Location = new System.Drawing.Point(135, 7);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(134, 24);
                this.label4.TabIndex = 12;
                this.label4.Text = a.CharityName;
                this.label4.Click += new System.EventHandler(this.label4_Click);

                this.flowLayoutPanel1.Controls.Add(this.panel1);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
