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
    public partial class certificatePreview : UserControl
    {
        ICallback parent;
        string regId;
        List<Event> events = new List<Event>();
        DataClasses1DataContext data = new DataClasses1DataContext();

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public certificatePreview()
        {
            InitializeComponent();
        }

        public certificatePreview(string regId)
        {
            InitializeComponent();
            this.regId = regId;
            getData();
        }

        string raceTime(double racetime)
        {
            var second = racetime % 60;
            var minutes = (racetime - second) / 60;
            var minute = minutes % 60;
            var hour = (minutes - minute) / 60;

            return String.Format("{0}h {1:00}m {2:00}s", hour, minute, second);
        }

        string ageCategory(DateTime from, DateTime dob)
        {
            var old = (from - dob).TotalDays / 365;

            if (old < 18)
            {
                return "Under 18";
            }
            else if (old < 30)
            {
                return "18 to 29";
            }
            else if (old < 40)
            {
                return "30 to 39";
            }
            else if (old < 56)
            {
                return "40 to 55";
            }
            else if (old < 70)
            {
                return "56 to 70";
            }
            else
            {
                return "Over 70";
            }
        }

        string categoryRank(string eventID, double racetime, DateTime dob, string gender)
        {
            var allRunners = data.RegistrationEvents.ToList().Where(x => x.EventId == eventID &&
                x.RaceTime != null && x.RaceTime != 0 &&
                ageCategory(DateTime.Now, x.Registration.Runner.DateOfBirth.Value) == ageCategory(DateTime.Now, dob) &&
                x.Registration.Runner.Gender == gender).OrderBy(x => x.RaceTime).ToList();

            var rank = 1;
            var incrementRank = 1;
            var previousRaceTime = 0;

            foreach (var item in allRunners)
            {
                if (previousRaceTime == 0)
                {
                    previousRaceTime = item.RaceTime.Value;
                }

                if (previousRaceTime == racetime)
                {
                    return "# " + rank;
                }

                if (previousRaceTime != item.RaceTime.Value)
                {
                    rank = incrementRank;
                }

                previousRaceTime = item.RaceTime.Value;
                incrementRank++;
            }

            return "# " + rank;
        }

        private void getData()
        {
            var regis = data.Registrations.Where(x => x.RegistrationId.Equals(this.regId));
            events = data.RegistrationEvents.Where(
                        x => x.Registration.Runner.Email == regis.First().Runner.Email &&
                             x.Event.MarathonId == 4 && x.RaceTime != null && x.RaceTime > 0
                        ).Select(x => x.Event).ToList();

            var eevents = data.Events.Where(x => x.MarathonId == 4).Select(x => x.EventName).ToList();

            foreach (var i in eevents)
            {
                cbRaceEvent.Items.Add(i);
            }

            cbRaceEvent.SelectedIndex = 0;

            if (events.Count() < 0)
            {
                MessageBox.Show("No events data for this runner in Marathon SKills 2014");
            }
        }

        private void cbRaceEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            var regis = data.Registrations.Where(x => x.RegistrationId.Equals(this.regId));
            var selectedEvent = cbRaceEvent.SelectedIndex;
            var eventId = data.Events.Where(x => x.EventName.Equals(cbRaceEvent.Text)).Select(x => x.EventId).First();
            var regEvent = data.RegistrationEvents.Where(x => x.Registration.Runner.Email == regis.First().Runner.Email && x.EventId == eventId).SingleOrDefault();

            if (regEvent != null)
            {
                var runner = regEvent.Registration.Runner;
                var user = runner.User;
                label2.Text = string.Format("Congratulation {0} {1} for running in the {4}. You ran a time of {2} and got a rank of {3}!",
                     user.FirstName, user.LastName, raceTime(regEvent.RaceTime.Value), categoryRank(regEvent.EventId, regEvent.RaceTime.Value, runner.DateOfBirth.Value, runner.Gender), regEvent.Event.EventName);
                label7.Text = string.Format("You also raised $ {0:n} for {1}!", regEvent.Registration.Sponsorships.Sum(x => x.Amount), regEvent.Registration.Charity.CharityName);
            }
            else
            {
                label2.Text = "No record";
                label7.Text = "";
                MessageBox.Show("No events data for this runner in Marathon SKills 2014");
            }
        }
    }
}
