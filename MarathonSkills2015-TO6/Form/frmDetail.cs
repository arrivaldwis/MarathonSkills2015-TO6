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
        DataClasses1DataContext data = new DataClasses1DataContext();
        long eventTime = DateTime.Parse("2015-09-05 06:00").Ticks;
        string back = "";
        string email, role, runnerId, regId;
        string logIn = "";

        public frmDetail()
        {
            InitializeComponent();
        }

        public frmDetail(string obj1, string obj2)
        {
            InitializeComponent();
            aksi(obj1, obj2, "", "");
        }

        private void lblCountDown_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            long now = DateTime.Now.Ticks;
            TimeSpan t = TimeSpan.FromTicks(eventTime - now);
            lblCountDown.Text = t.Days + " days " + t.Hours + " hours and " + t.Minutes + " until the race starts";
        }

        public void aksi(string obj1, string obj2, string obj3, string obj4)
        {
            panel3.Controls.Clear();
            if (obj1 == "SPONSORRUNNER")
            {
                sponsorRunner s = new sponsorRunner();
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
            }
            else if (obj1 == "SPONSORCONFIRM")
            {
                sponsorConfirmation s = new sponsorConfirmation(obj2, obj3, obj4);
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
            }
            else if (obj1 == "FINDOUTMORE")
            {
                findOutMore s = new findOutMore();
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
            }
            else if (obj1 == "LISTOFCHARITIES")
            {
                listOfCharities s = new listOfCharities();
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "FINDOUTMOREBACK";
            }
            else if (obj1 == "ADDITIONALMORE")
            {
                additionalMore s = new additionalMore();
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "FINDOUTMOREBACK";
            }
            else if (obj1 == "PREVIOUSRACERESULT")
            {
                previousRaceResults s = new previousRaceResults();
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "FINDOUTMOREBACK";
            }
            else if (obj1 == "HOWLONGMARATHON")
            {
                howLongMarathon s = new howLongMarathon();
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "FINDOUTMOREBACK";
            }
            else if (obj1 == "INTERACTIVEMAP")
            {
                interactiveMap s = new interactiveMap();
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "ABOUTMARATHONSKILLSBACK";
            }
            else if (obj1 == "ABOUTMARATHONSKILLS")
            {
                aboutMarathonSkills s = new aboutMarathonSkills();
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "FINDOUTMOREBACK";
            }
            else if (obj1 == "BMICALCULATOR")
            {
                BMICalculator s = new BMICalculator();
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "FINDOUTMOREBACK";
            }
            else if (obj1 == "BMRCALCULATOR")
            {
                BMRCalculator s = new BMRCalculator();
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "FINDOUTMOREBACK";
            }
            else if (obj1 == "LOGINSCREEN")
            {
                loginScreen s = new loginScreen();
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
            }
            else if (obj1 == "CHECKRUNNER")
            {
                checkRunner s = new checkRunner();
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
            }
            else if (obj1 == "RUNNERREGISTRATION")
            {
                runnerRegistration s = new runnerRegistration();
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "CHECKRUNNERBACK";
            }
            else if (obj1 == "MANAGERUNNER")
            {
                regId = obj2;
                manageRunner s = new manageRunner(obj2);
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "RUNNERMANAGEMENTBACK";
            }
            else if (obj1 == "LOGINMENU")
            {
                logIn = "1";
                this.email = obj2;
                this.role = obj3;

                if (role == "R")
                {
                    this.runnerId = data.Runners.Where(x => x.Email.Equals(this.email)).Select(x => x.RunnerId).First().ToString();
                }

                loginMenu s = new loginMenu(obj2, obj3);
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
            }
            else if (obj1 == "REGISTEREVENT")
            {
                logIn = "1";

                if (this.email == "")
                {
                    this.email = obj4;
                    this.role = obj3;
                }

                registerEvent s = new registerEvent(obj2);
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "LOGINMENUBACK";
            }
            else if (obj1 == "IMPORTVOLUNTEER")
            {
                logIn = "1";
                importVolunteer s = new importVolunteer();
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "VOLUNTEERMANAGEMENTBACK";
            }
            else if (obj1 == "VOLUNTEERMANAGEMENT")
            {
                logIn = "1";
                volunteerManagement s = new volunteerManagement();
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "LOGINMENUBACK";
            }
            else if (obj1 == "RUNNERMANAGEMENT")
            {
                logIn = "1";
                runnerManagement s = new runnerManagement();
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "LOGINMENUBACK";
            }
            else if (obj1 == "MYSPONSORSHIP")
            {
                logIn = "1";
                mySponsorship s = new mySponsorship(obj2);
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "LOGINMENUBACK";
            }
            else if (obj1 == "MYRACERESULT")
            {
                logIn = "1";
                myRaceResults s = new myRaceResults(obj2);
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "LOGINMENUBACK";
            }
            else if (obj1 == "SPONSORSHIPOVERVIEW")
            {
                logIn = "1";
                sponsorOverview s = new sponsorOverview();
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "LOGINMENUBACK";
            }
            else if (obj1 == "MANAGECHARITIES")
            {
                logIn = "1";
                manageCharity s = new manageCharity();
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "LOGINMENUBACK";
            }
            else if (obj1 == "ADDEDITCHARITIES")
            {
                logIn = "1";
                addEditCharity s = new addEditCharity(obj2);
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "MANAGECHARITIESBACK";
            }
            else if (obj1 == "EDITUSER")
            {
                logIn = "1";
                editUser s = new editUser(obj2);
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "USERMANAGEMENTBACK";
            }
            else if (obj1 == "ADDUSER")
            {
                logIn = "1";
                addUser s = new addUser();
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "USERMANAGEMENTBACK";
            }
            else if (obj1 == "USERMANAGEMENT")
            {
                logIn = "1";
                userManagement s = new userManagement();
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "LOGINMENUBACK";
            }
            else if (obj1 == "EDITPROFILE")
            {
                logIn = "1";
                editProfile s = new editProfile(obj2, obj3);
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);

                if (obj3 == "1")
                {
                    back = "MANAGERUNNERBACK";
                }
                else
                {
                    back = "LOGINMENUBACK";
                }
            }
            else if (obj1 == "CERTIFICATEPREVIEW")
            {
                logIn = "1";
                certificatePreview s = new certificatePreview(obj2);
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "MANAGERUNNERBACK";
            }
            else if (obj1 == "REGISTEREVENTCONFIRMATION")
            {
                logIn = "1";
                registerEventConfirmation s = new registerEventConfirmation(obj2, obj3);
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
            }
            else if (obj1 == "BACKSPONSORCONFIRM")
            {
                this.Hide();
            }

            if (logIn != "")
            {
                btnLogout.Visible = true;
            }
        }

        private void frmDetail_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            if (back == "")
            {
                this.Hide();
            }
            else if (back == "FINDOUTMOREBACK")
            {
                findOutMore s = new findOutMore();
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "";
            }
            else if (back == "CHECKRUNNERBACK")
            {
                checkRunner s = new checkRunner();
                s.Dock = DockStyle.Fill;
                s.setParent(this);
                panel3.Controls.Add(s);
                back = "";
            }
            else if (back == "LOGINMENUBACK")
            {
                loginMenu a = new loginMenu(this.email, this.role);
                a.Dock = DockStyle.Fill;
                a.setParent(this);
                panel3.Controls.Add(a);
                back = "";
            }
            else if (back == "RUNNERMANAGEMENTBACK")
            {
                runnerManagement a = new runnerManagement();
                a.Dock = DockStyle.Fill;
                a.setParent(this);
                panel3.Controls.Add(a);
                back = "LOGINMENUBACK";
            }
            else if (back == "VOLUNTEERMANAGEMENTBACK")
            {
                volunteerManagement a = new volunteerManagement();
                a.Dock = DockStyle.Fill;
                a.setParent(this);
                panel3.Controls.Add(a);
                back = "LOGINMENUBACK";
            }
            else if (back == "MANAGECHARITIESBACK")
            {
                manageCharity a = new manageCharity();
                a.Dock = DockStyle.Fill;
                a.setParent(this);
                panel3.Controls.Add(a);
                back = "LOGINMENUBACK";
            }
            else if (back == "USERMANAGEMENTBACK")
            {
                userManagement a = new userManagement();
                a.Dock = DockStyle.Fill;
                a.setParent(this);
                panel3.Controls.Add(a);
                back = "LOGINMENUBACK";
            }
            else if (back == "MANAGERUNNERBACK")
            {
                manageRunner a = new manageRunner(regId);
                a.Dock = DockStyle.Fill;
                a.setParent(this);
                panel3.Controls.Add(a);
                back = "RUNNERMANAGEMENTBACK";
            }
            else if (back == "ABOUTMARATHONSKILLSBACK")
            {
                aboutMarathonSkills a = new aboutMarathonSkills();
                a.Dock = DockStyle.Fill;
                a.setParent(this);
                panel3.Controls.Add(a);
                back = "FINDOUTMOREBACK";
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
