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
        DataClasses1DataContext db = new DataClasses1DataContext();

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public howLongMarathon()
        {
            InitializeComponent();
            getData();
        }

        public void getData()
        {
            foreach (var a in db.Speeds)
            {
                this.panel1 = new System.Windows.Forms.Panel();
                this.pictureBox2 = new System.Windows.Forms.PictureBox();
                this.label3 = new System.Windows.Forms.Label();

                // 
                // panel1
                // 
                this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
                this.panel1.Controls.Add(this.label3);
                this.panel1.Controls.Add(this.pictureBox2);
                this.panel1.Location = new System.Drawing.Point(3, 3);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(247, 88);
                this.panel1.TabIndex = 8;
                // 
                // pictureBox2
                // 
                this.pictureBox2.ImageLocation = Environment.CurrentDirectory+"/Resources/" + a.Image;
                this.pictureBox2.Location = new System.Drawing.Point(3, 3);
                this.pictureBox2.Name = "pictureBox2";
                this.pictureBox2.Size = new System.Drawing.Size(91, 81);
                this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                this.pictureBox2.TabIndex = 34;
                this.pictureBox2.Text = a.Name;
                this.pictureBox2.Tag = a.Name;
                this.pictureBox2.Click += pictureBox2_Click;
                this.pictureBox2.TabStop = false;
                // 
                // label3
                // 
                this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label3.Location = new System.Drawing.Point(100, 3);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(144, 81);
                this.label3.TabIndex = 36;
                this.label3.Text = a.Name;
                this.label3.Tag = a.Name;
                this.label3.Click += label3_Click;
                this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.flowLayoutPanel1.Controls.Add(this.panel1);
            }

            foreach (var a in db.Distances)
            {
                this.panel2 = new System.Windows.Forms.Panel();
                this.label4 = new System.Windows.Forms.Label();
                this.pictureBox3 = new System.Windows.Forms.PictureBox();
                // 
                // panel2
                // 
                this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
                this.panel2.Controls.Add(this.label4);
                this.panel2.Controls.Add(this.pictureBox3);
                this.panel2.Location = new System.Drawing.Point(3, 3);
                this.panel2.Name = "panel2";
                this.panel2.Size = new System.Drawing.Size(247, 88);
                this.panel2.TabIndex = 8;
                // 
                // label4
                // 
                this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label4.Location = new System.Drawing.Point(100, 3);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(144, 81);
                this.label4.TabIndex = 36;
                this.label4.Text = a.Name;
                this.label4.Tag = a.Name;
                this.label4.Click += label4_Click;
                this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // pictureBox3
                // 
                this.pictureBox3.ImageLocation = Environment.CurrentDirectory + "/Resources/" + a.Image;
                this.pictureBox3.Location = new System.Drawing.Point(3, 3);
                this.pictureBox3.Name = "pictureBox3";
                this.pictureBox3.Size = new System.Drawing.Size(91, 81);
                this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                this.pictureBox3.TabIndex = 34;
                this.pictureBox3.TabStop = false;
                this.pictureBox3.Tag = a.Name;
                this.pictureBox3.Click += pictureBox3_Click;
                this.flowLayoutPanel2.Controls.Add(this.panel2);
            }
        }

        void pictureBox2_Click(object sender, EventArgs e)
        {
            PictureBox a = (PictureBox)sender;
            calculate("speed", a.Tag.ToString());
        }

        void label3_Click(object sender, EventArgs e)
        {
            Label a = (Label)sender;
            calculate("speed", a.Tag.ToString());
        }

        void pictureBox3_Click(object sender, EventArgs e)
        {
            PictureBox a = (PictureBox)sender;
            calculate("distance", a.Tag.ToString());
        }

        void label4_Click(object sender, EventArgs e)
        {
            Label a = (Label)sender;
            calculate("distance", a.Tag.ToString());
        }

        public void calculate(string menu, string name)
        {
            if (menu == "speed")
            {
                var speed = db.Speeds.Where(x => x.Name.Equals(name)).FirstOrDefault();
                pictureBox1.ImageLocation = Environment.CurrentDirectory + "/Resources/" + speed.Image;
                string[] splitSpeed = speed.Speed1.Split('k');
                double jam = 42 / double.Parse(splitSpeed[0]);

                label2.Text = speed.Name;
                label5.Text = String.Format("The top speed of a {0} is {1}. It would take {2} hour(s) to complete a 42km marathon.", 
                    speed.Name, speed.Speed1, jam.ToString("F2"));
            }
            else
            {
                var distance = db.Distances.Where(x => x.Name.Equals(name)).FirstOrDefault();
                pictureBox1.ImageLocation = Environment.CurrentDirectory + "/Resources/" + distance.Image;
                string[] splitDistance = distance.Length.Split('m');
                double jam = 42 / (double.Parse(splitDistance[0]) / 1000);

                label2.Text = distance.Name;
                label5.Text = String.Format("The length of a {0} is {1}. It would take {2} of them to cover the track of a 42km marathon.",
                    distance.Name, distance.Length, jam.ToString("F0"));
            }
        }
    }
}
