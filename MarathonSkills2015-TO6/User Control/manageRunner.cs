using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarathonSkills2015_TO6.Properties;

namespace MarathonSkills2015_TO6.User_Control
{
    public partial class manageRunner : UserControl
    {
        ICallback parent;
        DataClasses1DataContext data = new DataClasses1DataContext();
        string regId;

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public manageRunner()
        {
            InitializeComponent();
        }

        public manageRunner(string regId)
        {
            InitializeComponent();
            this.regId = regId;
            getData();
        }

        public void getData()
        {
            base.Refresh();
            var runner = data.Runners.Where(x => x.Registrations.First().RegistrationId.Equals(regId));
            var user = runner.First().User;

            lblEmail.Text = user.Email;
            lblFirstName.Text = user.FirstName;
            lblLastName.Text = user.LastName;

            lblGender.Text = runner.First().Gender;
            lblDOB.Text = runner.First().DateOfBirth.Value.ToShortDateString();
            lblCountry.Text = runner.First().Country.CountryName;
            lblCharity.Text = data.Registrations.First().Charity.CharityName;
            lblTargetRaise.Text = data.Registrations.First().SponsorshipTarget.ToString("n");
            lblRaceKit.Text = data.Registrations.First().RaceKitOption.RaceKitOption1;

            var events = "";
            var reg = data.Registrations.Where(x => x.RegistrationId.Equals(regId));

            foreach (var a in reg.First().RegistrationEvents)
            {
                events += a.Event.EventName + ",";
            }

            lblRaceEvents.Text = events;

            var picture = new List<PictureBox>() {
                pictureBox1,
                pictureBox2,
                pictureBox3,
                pictureBox4
            };

            for (var i = 0; i < reg.First().RegistrationStatusId; i++)
            {
                picture[i].Image = Resources.tick_icon;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var runner = data.Runners.Where(x => x.Registrations.First().RegistrationId.Equals(regId)).First();
            parent.aksi("EDITPROFILE", runner.RunnerId.ToString(), "1", "");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            parent.aksi("CERTIFICATEPREVIEW", this.regId, "", "");
        }
    }
}
