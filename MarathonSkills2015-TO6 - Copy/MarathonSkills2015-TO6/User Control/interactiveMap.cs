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
    public partial class interactiveMap : UserControl
    {
        ICallback parent;
        DataClasses1DataContext db = new DataClasses1DataContext();

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public interactiveMap()
        {
            InitializeComponent();
        }

        public void getData(string menu, string ck)
        {
            if (menu == "ck")
            {
                flowLayoutPanel1.Controls.Clear();
                var getCk = db.InteractiveMaps.Where(x => x.Checkpoint.Equals(ck)).FirstOrDefault();
                label4.Text = ck;
                label3.Text = "Landmark:";
                label5.Text = getCk.Landmark;
                label7.Text = "Services Provided:";
                string[] split = getCk.Facility.Split(',');
                label5.Visible = true;
                label7.Visible = true;
                flowLayoutPanel1.Visible = true;

                for (int i = 0; i<split.Count(); i++)
                {

                    this.panel2 = new System.Windows.Forms.Panel();
                    this.pictureBox5 = new System.Windows.Forms.PictureBox();
                    this.label1 = new System.Windows.Forms.Label();// 
                    // panel2
                    // 
                    this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
                    this.panel2.Controls.Add(this.label1);
                    this.panel2.Controls.Add(this.pictureBox5);
                    this.panel2.Location = new System.Drawing.Point(3, 3);
                    this.panel2.Name = "panel2";
                    this.panel2.Size = new System.Drawing.Size(239, 58);
                    this.panel2.TabIndex = 16;
                    // 
                    // pictureBox5
                    // 
                    this.pictureBox5.Anchor = System.Windows.Forms.AnchorStyles.Top;
                    this.pictureBox5.Location = new System.Drawing.Point(6, 7);
                    this.pictureBox5.Name = "pictureBox5";
                    this.pictureBox5.Size = new System.Drawing.Size(42, 43);
                    this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    this.pictureBox5.TabIndex = 25;
                    this.pictureBox5.TabStop = false;

                    if (i == 0)
                    {
                        if (split[i] == "1")
                        {
                            this.pictureBox5.ImageLocation = Environment.CurrentDirectory + "/Resources/map-icon-drinks.png";
                        }
                    }
                    else if (i == 1)
                    {
                        if (split[i] == "1")
                        {
                            this.pictureBox5.ImageLocation = Environment.CurrentDirectory + "/Resources/map-icon-energy-bars.png";
                        }
                    }
                    else if (i == 2)
                    {
                        if (split[i] == "1")
                        {
                            this.pictureBox5.ImageLocation = Environment.CurrentDirectory + "/Resources/map-icon-information.png";
                        }
                    }
                    else if (i == 3)
                    {
                        if (split[i] == "1")
                        {
                            this.pictureBox5.ImageLocation = Environment.CurrentDirectory + "/Resources/map-icon-medical.png";
                        }
                    }
                    else if (i == 4)
                    {
                        if (split[i] == "1")
                        {
                            this.pictureBox5.ImageLocation = Environment.CurrentDirectory + "/Resources/map-icon-toilets.png";
                        }
                    }

                    // 
                    // label1
                    // 
                    this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
                    this.label1.AutoSize = true;
                    this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.label1.Location = new System.Drawing.Point(54, 7);
                    this.label1.Name = "label1";
                    this.label1.Size = new System.Drawing.Size(50, 18);
                    this.label1.TabIndex = 26;

                    if (i == 0)
                    {
                        if (split[i] == "1")
                        {
                            this.label1.Text = "Drinks";
                        }
                    }
                    else if (i == 1)
                    {
                        if (split[i] == "1")
                        {
                            this.label1.Text = "Energy Bar";
                        }
                    }
                    else if (i == 2)
                    {
                        if (split[i] == "1")
                        {
                            this.label1.Text = "Information";
                        }
                    }
                    else if (i == 3)
                    {
                        if (split[i] == "1")
                        {
                            this.label1.Text = "Medical";
                        }
                    }
                    else if (i == 4)
                    {
                        if (split[i] == "1")
                        {
                            this.label1.Text = "Toilets";
                        }
                    }

                    this.flowLayoutPanel1.Controls.Add(this.panel2);
                }
            }
            else
            {
                var getMarathon = db.Events.Where(x => x.EventId.Equals(ck)).FirstOrDefault();
                label4.Text = "Race Start";
                label3.Text = getMarathon.EventName;
                label5.Visible = false;
                label7.Visible = false;
                flowLayoutPanel1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getData("ck", "Checkpoint 1");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            getData("ck", "Checkpoint 2");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getData("ck", "Checkpoint 3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            getData("ck", "Checkpoint 4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            getData("ck", "Checkpoint 5");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            getData("ck", "Checkpoint 6");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getData("ck", "Checkpoint 7");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            getData("ck", "Checkpoint 8");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            getData("marathon", "15_5FM");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            getData("marathon", "15_5HM");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            getData("marathon", "15_5FR");
        }
    }
}
