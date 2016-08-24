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
        DataClasses1DataContext db = new DataClasses1DataContext();

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public listOfCharities()
        {
            InitializeComponent();
            getData();
        }

        public void getData()
        {
            foreach (var a in db.Charities)
            {
                this.panel1 = new System.Windows.Forms.Panel();
                this.label2 = new System.Windows.Forms.Label();
                this.label4 = new System.Windows.Forms.Label();
                this.pictureBox1 = new System.Windows.Forms.PictureBox();

                // 
                // panel1
                // 
                this.panel1.Controls.Add(this.label2);
                this.panel1.Controls.Add(this.pictureBox1);
                this.panel1.Controls.Add(this.label4);
                this.panel1.Location = new System.Drawing.Point(3, 3);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(749, 100);
                this.panel1.TabIndex = 0;
                // 
                // label2
                // 
                this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
                this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label2.Location = new System.Drawing.Point(134, 28);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(612, 67);
                this.label2.TabIndex = 13;
                this.label2.Text = a.CharityDescription;
                // 
                // label4
                // 
                this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
                this.label4.AutoSize = true;
                this.label4.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label4.Location = new System.Drawing.Point(133, 4);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(65, 24);
                this.label4.TabIndex = 11;
                this.label4.Text = a.CharityName;
                // 
                // pictureBox1
                // 
                this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
                this.pictureBox1.ImageLocation = Environment.CurrentDirectory + "/Resources/"+ a.CharityLogo;
                this.pictureBox1.Location = new System.Drawing.Point(4, 4);
                this.pictureBox1.Name = "pictureBox1";
                this.pictureBox1.Size = new System.Drawing.Size(123, 91);
                this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                this.pictureBox1.TabIndex = 12;
                this.pictureBox1.TabStop = false;
                this.flowLayoutPanel1.Controls.Add(this.panel1);
            }
        }
    }
}
