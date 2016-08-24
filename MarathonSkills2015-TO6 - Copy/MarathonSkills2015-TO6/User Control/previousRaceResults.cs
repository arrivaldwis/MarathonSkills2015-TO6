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
        DataClasses1DataContext db = new DataClasses1DataContext();
        string country = "Brazil";
        int prevTime = 0;
        string timeNew = "";
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

        public void getData()
        {
            foreach (var a in db.Marathons)
            {
                if (a.MarathonId == 1)
                {
                    country = "United Kingdom";
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
                else
                {
                    country = "Brazil";
                }

                comboBox2.Items.Add(a.YearHeld + " - " + country);
            }

            foreach (var a in db.EventTypes)
            {
                comboBox1.Items.Add(a.EventTypeName);
            }

            comboBox3.Items.Add("Any");
            foreach (var a in db.Genders)
            {
                comboBox3.Items.Add(a.Gender1);
            }

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            searchData();
        }

        public void searchData()
        {
            int j = 0, minAge = 0, maxAge = 0;
            string ovRank = "", ovRank2 = "", ganda = "";
            int getTotalRunnerFinished = 0, raceTime = 0;
            var nows = DateTime.Now;

            listView1.Items.Clear();

            var getOvRank = db.RegistrationEvents.Where(
                            x => x.Event.Marathon.MarathonName.Equals(marathonName) &&
                                x.Event.EventType.EventTypeName.Equals(comboBox1.Text)
                            ).OrderBy(x => x.RaceTime);

            if (getOvRank != null)
            {
                if (comboBox4.SelectedIndex > 0)
                {
                    if (comboBox3.SelectedIndex == 0)
                    {
                        if (comboBox4.Text == "Under 18")
                        {
                            getOvRank = getOvRank.Where(
                                x => (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year < 18)
                                    ).OrderBy(x => x.RaceTime);
                        }
                        else if (comboBox4.Text == "Over 70")
                        {
                            getOvRank = getOvRank.Where(
                                x => (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year > 70)
                                    ).OrderBy(x => x.RaceTime);
                        }
                        else
                        {
                            if (comboBox4.SelectedIndex == 2)
                            {
                                minAge = 18;
                                maxAge = 30;
                            }
                            else if (comboBox4.SelectedIndex == 3)
                            {
                                minAge = 30;
                                maxAge = 40;
                            }
                            else if (comboBox4.SelectedIndex == 4)
                            {
                                minAge = 40;
                                maxAge = 56;
                            }
                            else if (comboBox4.SelectedIndex == 5)
                            {
                                minAge = 56;
                                maxAge = 71;
                            }

                            getOvRank = getOvRank.Where(
                                x => (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year >= minAge) &&
                                    (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year < maxAge)
                                    ).OrderBy(x => x.RaceTime);
                        }
                    }
                    else
                    {
                        if (comboBox4.Text == "Under 18")
                        {
                            getOvRank = getOvRank.Where(
                                x => x.Registration.Runner.Gender.Equals(comboBox3.Text) &&
                                    (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year < 18)
                                    ).OrderBy(x => x.RaceTime);
                        }
                        else if (comboBox4.Text == "Over 70")
                        {
                            getOvRank = getOvRank.Where(
                                x => x.Registration.Runner.Gender.Equals(comboBox3.Text) &&
                                    (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year > 70)
                                    ).OrderBy(x => x.RaceTime);
                        }
                        else
                        {
                            if (comboBox4.SelectedIndex == 2)
                            {
                                minAge = 18;
                                maxAge = 30;
                            }
                            else if (comboBox4.SelectedIndex == 3)
                            {
                                minAge = 30;
                                maxAge = 40;
                            }
                            else if (comboBox4.SelectedIndex == 4)
                            {
                                minAge = 40;
                                maxAge = 56;
                            }
                            else if (comboBox4.SelectedIndex == 5)
                            {
                                minAge = 56;
                                maxAge = 71;
                            }

                            getOvRank = getOvRank.Where(
                                x => x.Registration.Runner.Gender.Equals(comboBox3.Text) &&
                                    (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year >= minAge) &&
                                    (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year < maxAge)
                                    ).OrderBy(x => x.RaceTime);
                        }
                    }
                }
                else
                {
                    if (comboBox3.SelectedIndex == 0)
                    {
                        getOvRank = getOvRank.OrderBy(x => x.RaceTime);
                    }
                    else
                    {
                        getOvRank = getOvRank.Where(
                                x => x.Registration.Runner.Gender.Equals(comboBox3.Text)
                                ).OrderBy(x => x.RaceTime);
                    }
                }

                foreach (var b in getOvRank)
                {
                    if (b.RaceTime != null)
                    {
                        if (b.RaceTime != 0)
                        {
                            int time = int.Parse(b.RaceTime.ToString());
                            TimeSpan times = TimeSpan.FromSeconds(time);
                            timeNew = times.Hours + "h " + times.Minutes + "m " + times.Seconds + "s";

                            if (prevTime == 0)
                            {
                                prevTime = int.Parse(b.RaceTime.ToString());
                                j++;
                            }
                            else
                            {
                                if (prevTime == int.Parse(b.RaceTime.ToString()))
                                {
                                    prevTime = int.Parse(b.RaceTime.ToString());
                                    ganda = "1";
                                }
                                else
                                {
                                    prevTime = int.Parse(b.RaceTime.ToString());
                                    j++;
                                }
                            }

                            getTotalRunnerFinished++;
                            raceTime += int.Parse(b.RaceTime.ToString());
                            ListViewItem lv;

                            if (ganda == "")
                            {
                                lv = new ListViewItem(j + "");
                            }
                            else
                            {
                                lv = new ListViewItem((j++) + "");
                                ganda = "";
                            }

                            lv.SubItems.Add(timeNew);
                            lv.SubItems.Add(b.Registration.Runner.User.FirstName + " " + b.Registration.Runner.User.LastName);
                            lv.SubItems.Add(b.Registration.Runner.CountryCode);
                            listView1.Items.Add(lv);
                        }
                    }
                }

                if (getTotalRunnerFinished > 0)
                {
                    double average = raceTime / getTotalRunnerFinished;
                    TimeSpan avg = TimeSpan.FromSeconds(average);

                    label2.Text = getOvRank.Count().ToString();
                    label5.Text = getTotalRunnerFinished.ToString();
                    label7.Text = avg.Hours + "h " + avg.Minutes + "m " + avg.Seconds + "s";
                }
                else
                {
                    label2.Text = "0";
                    label5.Text = "0";
                    label7.Text = "0h 0m 0s";
                    MessageBox.Show("No data found!");
                }

                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            else
            {
                MessageBox.Show("No data found!");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            marathonName = db.Marathons.Where(x => x.YearHeld.Equals(comboBox2.Text.Substring(0, 4))).Select(x => x.MarathonName).FirstOrDefault();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            searchData();
        }
    }
}
