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
    public partial class sponsorOverview : UserControl
    {
        ICallback parent;
        DataClasses1DataContext data = new DataClasses1DataContext();

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public sponsorOverview()
        {
            InitializeComponent();
            cbRunner.SelectedIndex = 0;
            refreshData();
        }

        private void refreshData()
        {
            flowLayoutPanel1.Controls.Clear();

            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();

            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(738, 28);
            this.panel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label6.Location = new System.Drawing.Point(566, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 16);
            this.label6.TabIndex = 81;
            this.label6.Text = "Total Amount";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label4.Location = new System.Drawing.Point(119, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 80;
            this.label4.Text = "Charity Name";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label3.Location = new System.Drawing.Point(5, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 79;
            this.label3.Text = "Logo";

            this.flowLayoutPanel1.Controls.Add(this.panel1);

            var charities = data.Charities.Where(x => x.Registrations.First().RegistrationEvents.First().Event.Marathon.MarathonId == 5).Select(x => x);

            if (cbRunner.SelectedIndex == 0)
            {
                charities = charities.OrderBy(x => x.CharityName);
            }
            else
            {
                charities = charities.OrderByDescending(x => x.Registrations.Sum(y => y.Sponsorships.Sum(z => z.Amount)));
            }

            foreach (var a in charities)
            {
                this.panel2 = new System.Windows.Forms.Panel();
                this.pictureBox1 = new System.Windows.Forms.PictureBox();
                this.label8 = new System.Windows.Forms.Label();
                this.label9 = new System.Windows.Forms.Label();

                // 
                // panel2
                // 
                this.panel2.Controls.Add(this.label9);
                this.panel2.Controls.Add(this.label8);
                this.panel2.Controls.Add(this.pictureBox1);
                this.panel2.Location = new System.Drawing.Point(3, 37);
                this.panel2.Name = "panel2";
                this.panel2.Size = new System.Drawing.Size(738, 85);
                this.panel2.TabIndex = 1;
                // 
                // pictureBox1
                // 
                this.pictureBox1.Location = new System.Drawing.Point(8, 9);
                this.pictureBox1.Name = "pictureBox1";
                this.pictureBox1.Size = new System.Drawing.Size(100, 65);
                this.pictureBox1.TabIndex = 0;
                this.pictureBox1.TabStop = false;
                this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pictureBox1.ImageLocation = Environment.CurrentDirectory + "/Resources/" + a.CharityLogo;
                // 
                // label8
                // 
                this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
                this.label8.AutoSize = true;
                this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
                this.label8.Location = new System.Drawing.Point(118, 28);
                this.label8.Name = "label8";
                this.label8.Size = new System.Drawing.Size(196, 24);
                this.label8.TabIndex = 10;
                this.label8.Text = a.CharityName;
                // 
                // label9
                // 
                this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
                this.label9.AutoSize = true;
                this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
                this.label9.Location = new System.Drawing.Point(565, 28);
                this.label9.Name = "label9";
                this.label9.Size = new System.Drawing.Size(116, 24);
                this.label9.TabIndex = 11;
                this.label9.Text = a.Registrations.Sum(y => y.Sponsorships.Sum(z => z.Amount)).ToString("c");
                this.flowLayoutPanel1.Controls.Add(this.panel2);
            }

            lblCharities.Text = charities.Count().ToString();
            lblTotSponsorship.Text = charities.Sum(x => x.Registrations.Sum(y => y.Sponsorships.Sum(z => z.Amount))).ToString("c");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            refreshData();
        }
    }
}
