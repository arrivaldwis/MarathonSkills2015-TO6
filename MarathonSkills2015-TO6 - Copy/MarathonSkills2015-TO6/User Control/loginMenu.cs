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
    public partial class loginMenu : UserControl
    {
        ICallback parent;
        string runnerId, email, role;
        DataClasses1DataContext db = new DataClasses1DataContext();

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public loginMenu(string email, string role)
        {
            InitializeComponent();
            this.email = email;
            this.role = role;
            getData();
        }

        public void getData()
        {
            if (this.role == "C")
            {
                button1.Text = "Runners";
                button2.Text = "Sponsorship";
                button3.Visible = false;
                button4.Visible = false;
                button6.Visible = false;
            }
            else if (this.role == "A")
            {
                button1.Text = "Users";
                button2.Text = "Volunteer";
                button4.Text = "Charities";
                button3.Text = "Inventory";
                button6.Visible = false;
            }

            if (this.role == "R")
            {
                this.runnerId = db.Runners.Where(x => x.Email.Equals(this.email)).Select(x => x.RunnerId).FirstOrDefault().ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.role == "R")
            {
                parent.aksi("REGISTEREVENT", this.email, "", "");
            }
            else if (this.role == "C")
            {
                parent.aksi("RUNNERMANAGEMENT", "", "", "");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.role == "R")
            {
                parent.aksi("EDITPROFILE", this.runnerId, "", "");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.role == "R")
            {
                parent.aksi("MYRACERESULTS", this.runnerId, "", "");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.role == "R")
            {
                parent.aksi("MYSPONSORSHIP", this.runnerId, "", "");
            }
        }
    }
}
