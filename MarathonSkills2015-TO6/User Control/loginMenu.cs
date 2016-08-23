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
        DataClasses1DataContext data = new DataClasses1DataContext();
        string email, role, runnerId;

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public loginMenu()
        {
            InitializeComponent();
        }

        public loginMenu(string email, string role)
        {
            InitializeComponent();
            this.email = email;
            this.role = role;

            if (this.role == "R")
            {
                label2.Text = "Runner Menu";
                this.runnerId = data.Runners.Where(x => x.Email.Equals(this.email)).Select(x => x.RunnerId).First().ToString();
            }

            setMenu();
        }

        private void setMenu()
        {
            if (this.role == "C")
            {
                label2.Text = "Coordinator Menu";
                button1.Text = "Runners";
                button6.Text = "Sponsorships";
                button2.Visible = false;
                button3.Visible = false;
                button5.Visible = false;
            }
            else if (this.role == "A")
            {
                label2.Text = "Administrator Menu";
                button1.Text = "Users";
                button6.Text = "Volunteers";
                button2.Text = "Charities";
                button5.Text = "Inventory";
                button3.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.role == "R")
            {
                panel1.Visible = true;
            }
            else
            {
                parent.aksi("TIMESHEETMANAGEMENT", "", "", "");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.role == "R")
            {
                parent.aksi("REGISTEREVENT", this.runnerId, "", "");
            }
            else if (this.role == "C")
            {
                parent.aksi("RUNNERMANAGEMENT", "", "", "");
            }
            else
            {
                parent.aksi("USERMANAGEMENT", "", "", "");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.role == "R")
            {
                parent.aksi("MYRACERESULT", this.runnerId, "", "");
            }
            else if (this.role == "C")
            {
                parent.aksi("SPONSORSHIPOVERVIEW", "", "", "");
            }
            else
            {
                parent.aksi("VOLUNTEERMANAGEMENT", "", "", "");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.role == "R")
            {
                parent.aksi("EDITPROFILE", this.runnerId, "0", "");
            }
            else
            {
                parent.aksi("MANAGECHARITIES", "", "", "");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.role == "R")
            {
                parent.aksi("MYSPONSORSHIP", this.runnerId, "", "");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
    }
}
