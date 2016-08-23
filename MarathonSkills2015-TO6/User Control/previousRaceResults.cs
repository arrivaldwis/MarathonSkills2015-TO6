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
    public partial class previousRaceResults : UserControl
    {
        ICallback parent;
        DataClasses1DataContext data = new DataClasses1DataContext();
        string marathonName = "";

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public previousRaceResults()
        {
            InitializeComponent();
            getData();
        }

        private void getData()
        {
            var marathon = data.Marathons;
            var events = data.EventTypes;
            var gender = data.Genders;

            foreach (var a in marathon)
            {
                string country = "";
                if (a.MarathonId == 1)
                {
                    country = "Great Britain";
                }
                else if (a.MarathonId == 2)
                {
                    country = "Vietnam";
                }
                else if (a.MarathonId == 3)
                {
                    country = "Germany";
                }
                else if (a.MarathonId == 4)
                {
                    country = "Japan";
                }
                else if (a.MarathonId == 5)
                {
                    country = "Brazil";
                }

                cbMarathon.Items.Add(a.YearHeld + " - " + country);
            }

            foreach (var a in events)
            {
                cbRaceEvent.Items.Add(a.EventTypeName);
            }

            cbGender.Items.Add("Any");
            foreach (var a in gender)
            {
                cbGender.Items.Add(a.Gender1);
            }

            cbMarathon.SelectedIndex = 0;
            cbRaceEvent.SelectedIndex = 0;
            cbGender.SelectedIndex = 0;
            cbAgeCategory.SelectedIndex = 0;

            searchData();
        }

        private void searchData()
        {
            listView1.Items.Clear();
            int i = 0, prevTime = 0, minAge = 0, maxAge = 0;
            string ganda = "";
            var getTotalRunnerFinished = 0;
            var getAllRaceTime = 0;
            var getRaceTime = 0;
            DateTime nows = DateTime.Now;

            getTotalRunnerFinished = 0;

            var getTotalRunner = data.RegistrationEvents.Where(
                x => x.Event.Marathon.MarathonName.Equals(marathonName) &&
                x.Event.EventType.EventTypeName.Equals(cbRaceEvent.Text)).OrderBy(x => x.RaceTime);

            if (cbAgeCategory.Text == "18 to 29")
            {
                minAge = 18;
                maxAge = 30;
            }
            else if (cbAgeCategory.Text == "30 to 39")
            {
                minAge = 30;
                maxAge = 40;
            }
            else if (cbAgeCategory.Text == "40 to 55")
            {
                minAge = 40;
                maxAge = 56;
            }
            else if (cbAgeCategory.Text == "56 to 70")
            {
                minAge = 56;
                maxAge = 71;
            }

            if (cbGender.SelectedIndex == 0)
            {
                if (cbAgeCategory.SelectedIndex == 0)
                {
                    getTotalRunner = getTotalRunner.OrderBy(x => x.RaceTime);
                }
                else if (cbAgeCategory.SelectedIndex == 1)
                {
                    getTotalRunner = getTotalRunner.Where(x => (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year < 18)).OrderBy(x => x.RaceTime);
                }
                else if (cbAgeCategory.SelectedIndex == 6)
                {
                    getTotalRunner = getTotalRunner.Where(x => (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year > 70)).OrderBy(x => x.RaceTime);
                }
                else
                {
                    getTotalRunner = getTotalRunner.Where(x => (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year >= minAge) && (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year < maxAge)).OrderBy(x => x.RaceTime);
                }
            }
            else
            {
                if (cbAgeCategory.SelectedIndex == 0)
                {
                    getTotalRunner = getTotalRunner.Where(x => x.Registration.Runner.Gender.Equals(cbGender.Text)).OrderBy(x => x.RaceTime);
                }
                else if (cbAgeCategory.SelectedIndex == 1)
                {
                    getTotalRunner = getTotalRunner.Where(x => (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year < 18)).Where(x => x.Registration.Runner.Gender.Equals(cbGender.Text)).OrderBy(x => x.RaceTime);
                }
                else if (cbAgeCategory.SelectedIndex == 6)
                {
                    getTotalRunner = getTotalRunner.Where(x => (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year > 70)).Where(x => x.Registration.Runner.Gender.Equals(cbGender.Text)).OrderBy(x => x.RaceTime);
                }
                else
                {
                    getTotalRunner = getTotalRunner.Where(x => (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year >= minAge) && (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year < maxAge)).Where(x => x.Registration.Runner.Gender.Equals(cbGender.Text)).OrderBy(x => x.RaceTime);
                }
            }

            foreach (var a in getTotalRunner)
            {
                if (a.RaceTime != null)
                {
                    if (a.RaceTime != 0)
                    {
                        if (prevTime == 0)
                        {
                            prevTime = Int32.Parse(a.RaceTime.ToString());
                            i++;
                        }
                        else
                        {
                            if (prevTime == Int32.Parse(a.RaceTime.ToString()))
                            {
                                prevTime = Int32.Parse(a.RaceTime.ToString());
                                ganda = "1";
                            }
                            else
                            {
                                prevTime = Int32.Parse(a.RaceTime.ToString());
                                i++;
                            }
                        }

                        getTotalRunnerFinished++;
                        getRaceTime = Int32.Parse(a.RaceTime.ToString());
                        getAllRaceTime += Int32.Parse(a.RaceTime.ToString());

                        TimeSpan time = TimeSpan.FromSeconds(getRaceTime);
                        ListViewItem lv;

                        if (ganda == "")
                        {
                            lv = new ListViewItem(i + "");
                        }
                        else
                        {
                            lv = new ListViewItem((i++) + "");
                            ganda = "";
                        }

                        lv.SubItems.Add(time.Hours + "h " + time.Minutes + "m " + time.Seconds + "s");
                        lv.SubItems.Add(a.Registration.Runner.User.FirstName + " " + a.Registration.Runner.User.LastName);
                        lv.SubItems.Add(a.Registration.Runner.Country.CountryCode);
                        listView1.Items.Add(lv);
                    }
                }
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            if (getTotalRunnerFinished > 0)
            {
                getAllRaceTime = getAllRaceTime / getTotalRunnerFinished;
                TimeSpan time = TimeSpan.FromSeconds(getAllRaceTime);
                lblTotRunner.Text = getTotalRunner.Count().ToString();
                lblRunnerFinished.Text = getTotalRunner.Where(x => (x.RaceTime != null) && (x.RaceTime != 0)).Count().ToString();
                lblRaceTime.Text = time.Hours + "h " + time.Minutes + "m " + time.Seconds + "s";
            }
            else
            {
                lblTotRunner.Text = "0";
                lblRunnerFinished.Text = "0";
                lblRaceTime.Text = "0h 0m 0s";
                MessageBox.Show("No data found!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            searchData();
        }

        private void cbMarathon_SelectedIndexChanged(object sender, EventArgs e)
        {
            marathonName = data.Marathons.Where(x => x.YearHeld.Equals(cbMarathon.Text.Substring(0, 4))).Select(x => x.MarathonName).First().ToString();
        }
    }
}
