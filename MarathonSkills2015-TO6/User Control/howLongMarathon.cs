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
    public partial class howLongMarathon : UserControl
    {
        ICallback parent;
        DataClasses1DataContext data = new DataClasses1DataContext();

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public howLongMarathon()
        {
            InitializeComponent();
            getData();
        }

        private void getData()
        {
            foreach (var a in data.Speeds)
            {
                //Speed
                this.panel1 = new System.Windows.Forms.Panel();
                this.pictureBox2 = new System.Windows.Forms.PictureBox();
                this.label4 = new System.Windows.Forms.Label();

                // 
                // panel1
                // 
                this.panel1.Controls.Add(this.label4);
                this.panel1.Controls.Add(this.pictureBox2);
                this.panel1.Location = new System.Drawing.Point(3, 3);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(248, 71);
                this.panel1.TabIndex = 0;
                // 
                // pictureBox2
                // 
                this.pictureBox2.Location = new System.Drawing.Point(3, 3);
                this.pictureBox2.Name = "pictureBox2";
                this.pictureBox2.Size = new System.Drawing.Size(70, 65);
                this.pictureBox2.TabIndex = 0;
                this.pictureBox2.TabStop = false;
                this.pictureBox2.ImageLocation = Environment.CurrentDirectory + "/Resources/" + a.Image;
                this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pictureBox2.Tag = a.Name;
                this.pictureBox2.Click += pictureBox2_Click;
                // 
                // label4
                // 
                this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
                this.label4.AutoSize = true;
                this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
                this.label4.Location = new System.Drawing.Point(79, 26);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(152, 20);
                this.label4.TabIndex = 11;
                this.label4.Text = a.Name;
                this.label4.Tag = a.Name;
                this.label4.Click += label4_Click;
                this.flowLayoutPanel1.Controls.Add(this.panel1);
            }

            foreach (var a in data.Distances)
            {
                //Distance
                this.panel2 = new System.Windows.Forms.Panel();
                this.label5 = new System.Windows.Forms.Label();
                this.pictureBox3 = new System.Windows.Forms.PictureBox();

                // 
                // panel2
                // 
                this.panel2.Controls.Add(this.label5);
                this.panel2.Controls.Add(this.pictureBox3);
                this.panel2.Location = new System.Drawing.Point(3, 3);
                this.panel2.Name = "panel2";
                this.panel2.Size = new System.Drawing.Size(248, 71);
                this.panel2.TabIndex = 0;
                // 
                // label5
                // 
                this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
                this.label5.AutoSize = true;
                this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
                this.label5.Location = new System.Drawing.Point(79, 26);
                this.label5.Name = "label5";
                this.label5.Size = new System.Drawing.Size(152, 20);
                this.label5.TabIndex = 11;
                this.label5.Text = a.Name;
                this.label5.Tag = a.Name;
                this.label5.Click += label5_Click;
                // 
                // pictureBox3
                // 
                this.pictureBox3.Location = new System.Drawing.Point(3, 3);
                this.pictureBox3.Name = "pictureBox3";
                this.pictureBox3.Size = new System.Drawing.Size(70, 65);
                this.pictureBox3.TabIndex = 0;
                this.pictureBox3.TabStop = false;
                this.pictureBox3.ImageLocation = Environment.CurrentDirectory + "/Resources/" + a.Image;
                this.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pictureBox3.Tag = a.Name;
                this.pictureBox3.Click += pictureBox3_Click;
                this.flowLayoutPanel2.Controls.Add(this.panel2);
            }
        }

        void pictureBox3_Click(object sender, EventArgs e)
        {
            PictureBox l = (PictureBox)sender;
            calculate("distance", l.Tag.ToString());
        }

        void label5_Click(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            calculate("distance", l.Tag.ToString());
        }

        void label4_Click(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            calculate("speed", l.Tag.ToString());
        }

        void pictureBox2_Click(object sender, EventArgs e)
        {
            PictureBox l = (PictureBox)sender;
            calculate("speed", l.Tag.ToString());
        }

        private void calculate(string menu, string name)
        {
            if (menu == "speed")
            {
                var speed = data.Speeds.Where(x => x.Name.Equals(name)).First();
                pictureBox1.ImageLocation = Environment.CurrentDirectory + "/Resources/" + speed.Image;
                string[] splitSpeed = speed.Speed1.Split('k');
                double jam = 42 / double.Parse(splitSpeed[0]);
                //double menit = (42 % double.Parse(splitSpeed[0])) * 60;

                label1.Text = name;
                label3.Text = "The top speed of a " + speed.Name + " is " + speed.Speed1 + ". It would take " + jam.ToString("F2") + " hour(s) to complete a 42km marathon.";
            }
            else
            {
                var distance = data.Distances.Where(x => x.Name.Equals(name)).First();
                pictureBox1.ImageLocation = Environment.CurrentDirectory + "/Resources/" + distance.Image;
                string[] splitSpeed = distance.Length.Split('m');
                double length = 42 / (double.Parse(splitSpeed[0]) / 1000);

                label1.Text = name;
                label3.Text = "The length of a " + distance.Name + " is " + distance.Length + ". It would take " + length.ToString("F0") + " of them to cover the track of a 42km marathon.";
            }
        }
    }
}
