using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarathonSkills2015_TO6.User_Control;

namespace MarathonSkills2015_TO6
{
    public partial class frmDetail : Form, ICallback
    {
        long events = DateTime.Parse("2015-09-05 06:00").Ticks;
        string back = "";
        string email, runnerId, role;
        DataClasses1DataContext db = new DataClasses1DataContext();
        int login = 0;

        public frmDetail(string obj1)
        {
            InitializeComponent();
            aksi(obj1, "", "", "");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan time = TimeSpan.FromTicks(events - DateTime.Now.Ticks);
            label3.Text = time.Days + " days " + time.Hours + " hours and " + time.Minutes + " minutes until the race starts";
        }

        public void aksi(string obj1, string obj2, string obj3, string obj4)
        {
            panel3.Controls.Clear();
            if (obj1 == "SPONSORRUNNER")
            {
                sponsorRunner r = new sponsorRunner();
                r.Dock = DockStyle.Fill;
                r.setParent(this);
                panel3.Controls.Add(r);
            }
            else if (obj1 == "SPONSORCONFIRM")
            {
                sponsorshipConfirmation r = new sponsorshipConfirmation(obj2,obj3,obj4);
                r.Dock = DockStyle.Fill;
                r.setParent(this);
                panel3.Controls.Add(r);
            }
            else if (obj1 == "FINDOUTMORE")
            {
                findOutMore r = new findOutMore();
                r.Dock = DockStyle.Fill;
                r.setParent(this);
                panel3.Controls.Add(r);
            }
            else if (obj1 == "INTERACTIVEMAP")
            {
                interactiveMap r = new interactiveMap();
                r.Dock = DockStyle.Fill;
                r.setParent(this);
                panel3.Controls.Add(r);
                back = "ABOUTMARATHONSKILLSBACK";
            }
            else if (obj1 == "LISTOFCHARITIES")
            {
                listOfCharities r = new listOfCharities();
                r.Dock = DockStyle.Fill;
                r.setParent(this);
                panel3.Controls.Add(r);
                back = "FINDOUTMOREBACK";
            }
            else if (obj1 == "HOWLONGMARATHON")
            {
                howLongMarathon r = new howLongMarathon();
                r.Dock = DockStyle.Fill;
                r.setParent(this);
                panel3.Controls.Add(r);
                back = "FINDOUTMOREBACK";
            }
            else if (obj1 == "ABOUTMARATHONSKILLS")
            {
                aboutMarathonSkills r = new aboutMarathonSkills();
                r.Dock = DockStyle.Fill;
                r.setParent(this);
                panel3.Controls.Add(r);
                back = "FINDOUTMOREBACK";
            }
            else if (obj1 == "PREVIOUSRACERESULTS")
            {
                previousRaceResults r = new previousRaceResults();
                r.Dock = DockStyle.Fill;
                r.setParent(this);
                panel3.Controls.Add(r);
                back = "FINDOUTMOREBACK";
            }
            else if (obj1 == "MANAGERUNNER")
            {
                manageRunner r = new manageRunner(obj2);
                r.Dock = DockStyle.Fill;
                r.setParent(this);
                panel3.Controls.Add(r);
                back = "RUNNERMANAGEMENTBACK";
            }
            else if (obj1 == "CHECKRUNNER")
            {
                checkRunner r = new checkRunner();
                r.Dock = DockStyle.Fill;
                r.setParent(this);
                panel3.Controls.Add(r);
            }
            else if (obj1 == "RUNNERREGISTRATION")
            {
                runnerRegistration r = new runnerRegistration();
                r.Dock = DockStyle.Fill;
                r.setParent(this);
                panel3.Controls.Add(r);
            }
            else if (obj1 == "LOGINSCREEN")
            {
                loginScreen r = new loginScreen();
                r.Dock = DockStyle.Fill;
                r.setParent(this);
                panel3.Controls.Add(r);
            }
            else if (obj1 == "LOGINMENU")
            {
                if (obj3 == "R")
                {
                    this.runnerId = db.Runners.Where(x => x.Email.Equals(obj2)).Select(x => x.RunnerId).FirstOrDefault().ToString();
                }

                this.email = obj2;
                this.role = obj3;
                login = 1;
                loginMenu r = new loginMenu(obj2, obj3);
                r.Dock = DockStyle.Fill;
                r.setParent(this);
                panel3.Controls.Add(r);
            }
            else if (obj1 == "REGISTEREVENT")
            {
                login = 1;
                registerEvent r = new registerEvent(obj2);
                r.Dock = DockStyle.Fill;
                r.setParent(this);
                panel3.Controls.Add(r);
                back = "LOGINMENUBACK";
            }
            else if (obj1 == "MYRACERESULTS")
            {
                login = 1;
                myRaceResults r = new myRaceResults(obj2);
                r.Dock = DockStyle.Fill;
                r.setParent(this);
                panel3.Controls.Add(r);
                back = "LOGINMENUBACK";
            }
            else if (obj1 == "MYSPONSORSHIP")
            {
                login = 1;
                mySponsorship r = new mySponsorship(obj2);
                r.Dock = DockStyle.Fill;
                r.setParent(this);
                panel3.Controls.Add(r);
                back = "LOGINMENUBACK";
            }
            else if (obj1 == "RUNNERMANAGEMENT")
            {
                login = 1;
                runnerManagement r = new runnerManagement();
                r.Dock = DockStyle.Fill;
                r.setParent(this);
                panel3.Controls.Add(r);
                back = "LOGINMENUBACK";
            }
            else if (obj1 == "EDITPROFILE")
            {
                login = 1;
                editProfile r = new editProfile(obj2, "0");
                r.Dock = DockStyle.Fill;
                r.setParent(this);
                panel3.Controls.Add(r);
                back = "LOGINMENUBACK";
            }
            else if (obj1 == "REGISTEREVENTCONFIRM")
            {
                login = 1;
                registerEventConfirmation r = new registerEventConfirmation(this.email, this.role);
                r.Dock = DockStyle.Fill;
                r.setParent(this);
                panel3.Controls.Add(r);
            }
            else if (obj1 == "BACKSPONSORCONFIRM")
            {
                this.Hide();
            }

            if (login == 1)
            {
                button4.Visible = true;
            }
            else
            {
                button4.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (back == "")
            {
                this.Hide();
            }
            else
            {
                panel3.Controls.Clear();
                if (back == "FINDOUTMOREBACK")
                {
                    findOutMore r = new findOutMore();
                    r.Dock = DockStyle.Fill;
                    r.setParent(this);
                    panel3.Controls.Add(r);
                    back = "";
                }
                else if (back == "LOGINMENUBACK")
                {
                    login = 1;
                    loginMenu r = new loginMenu(this.email, this.role);
                    r.Dock = DockStyle.Fill;
                    r.setParent(this);
                    panel3.Controls.Add(r);
                    back = "";
                }
                else if (back == "RUNNERMANAGEMENTBACK")
                {
                    login = 1;
                    runnerManagement r = new runnerManagement();
                    r.Dock = DockStyle.Fill;
                    r.setParent(this);
                    panel3.Controls.Add(r);
                    back = "LOGINMENUBACK";
                }
                else if (back == "ABOUTMARATHONSKILLSBACK")
                {
                    login = 1;
                    aboutMarathonSkills r = new aboutMarathonSkills();
                    r.Dock = DockStyle.Fill;
                    r.setParent(this);
                    panel3.Controls.Add(r);
                    back = "FINDOUTMOREBACK";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
