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
        DataClasses1DataContext data = new DataClasses1DataContext();

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public interactiveMap()
        {
            InitializeComponent();
        }

        private void getData(string ck, string menu)
        {
            panel1.Visible = true;
            if (menu == "ck")
            {
                var map = data.InteractiveMaps.Where(x => x.Checkpoint.Equals(ck)).First();
                string[] service = map.Facility.Split(',');
                label2.Text = "Landmark:";
                label1.Text = map.Checkpoint;
                label3.Text = map.Landmark;
                label3.Visible = true;
                label5.Visible = true;
                flowLayoutPanel1.Visible = true;
                flowLayoutPanel1.Controls.Clear();

                for (int i = 0; i < service.Count(); i++)
                {
                    this.panel2 = new System.Windows.Forms.Panel();
                    this.pictureBox2 = new System.Windows.Forms.PictureBox();
                    this.label4 = new System.Windows.Forms.Label();

                    // 
                    // panel2
                    // 
                    this.panel2.Controls.Add(this.label4);
                    this.panel2.Controls.Add(this.pictureBox2);
                    this.panel2.Location = new System.Drawing.Point(3, 3);
                    this.panel2.Name = "panel2";
                    this.panel2.Size = new System.Drawing.Size(184, 57);
                    this.panel2.TabIndex = 0;
                    // 
                    // pictureBox2
                    // 
                    this.pictureBox2.Location = new System.Drawing.Point(3, 3);
                    this.pictureBox2.Name = "pictureBox2";
                    this.pictureBox2.Size = new System.Drawing.Size(50, 51);
                    this.pictureBox2.TabIndex = 0;
                    this.pictureBox2.TabStop = false;
                    this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                    if (i == 0)
                    {
                        if (service[i] == "1")
                        {
                            this.pictureBox2.ImageLocation = Environment.CurrentDirectory + "/Resources/map-icon-drinks.png";
                        }
                    }
                    else if (i == 1)
                    {
                        if (service[i] == "1")
                        {
                            this.pictureBox2.ImageLocation = Environment.CurrentDirectory + "/Resources/map-icon-energy-bars.png";
                        }
                    }
                    else if (i == 2)
                    {
                        if (service[i] == "1")
                        {
                            this.pictureBox2.ImageLocation = Environment.CurrentDirectory + "/Resources/map-icon-information.png";
                        }
                    }
                    else if (i == 3)
                    {
                        if (service[i] == "1")
                        {
                            this.pictureBox2.ImageLocation = Environment.CurrentDirectory + "/Resources/map-icon-medical.png";
                        }
                    }
                    else if (i == 4)
                    {
                        if (service[i] == "1")
                        {
                            this.pictureBox2.ImageLocation = Environment.CurrentDirectory + "/Resources/map-icon-toilets.png";
                        }
                    }

                    // 
                    // label4
                    // 
                    this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.label4.Location = new System.Drawing.Point(59, 3);
                    this.label4.Name = "label4";
                    this.label4.Size = new System.Drawing.Size(122, 51);
                    this.label4.TabIndex = 4;
                    this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                    if (i == 0)
                    {
                        if (service[i] == "1")
                        {
                            this.label4.Text = "Drinks";
                        }
                    }
                    else if (i == 1)
                    {
                        if (service[i] == "1")
                        {
                            this.label4.Text = "Energy Bar";
                        }
                    }
                    else if (i == 2)
                    {
                        if (service[i] == "1")
                        {
                            this.label4.Text = "Information";
                        }
                    }
                    else if (i == 3)
                    {
                        if (service[i] == "1")
                        {
                            this.label4.Text = "Medical";
                        }
                    }
                    else if (i == 4)
                    {
                        if (service[i] == "1")
                        {
                            this.label4.Text = "Toilets";
                        }
                    }

                    this.flowLayoutPanel1.Controls.Add(this.panel2);
                }

            }
            else
            {
                var getMarathon = data.Events.Where(x => x.EventTypeId.Equals(ck) && x.MarathonId == 5).Select(x => x.EventName).First();

                label1.Text = "Race Start";
                label2.Text = getMarathon;
                label3.Visible = false;
                label5.Visible = false;
                flowLayoutPanel1.Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getData("Checkpoint 1", "ck");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getData("Checkpoint 2", "ck");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getData("Checkpoint 3", "ck");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            getData("Checkpoint 4", "ck");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            getData("Checkpoint 5", "ck");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            getData("Checkpoint 6", "ck");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            getData("FM", "marathon");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            getData("HM", "marathon");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            getData("FR", "marathon");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            getData("Checkpoint 7", "ck");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            getData("Checkpoint 8", "ck");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            getData("FM", "marathon");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            getData("HM", "marathon");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            getData("FR", "marathon");
        }
    }
}
