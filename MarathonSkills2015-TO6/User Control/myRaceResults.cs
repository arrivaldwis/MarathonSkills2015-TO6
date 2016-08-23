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
    public partial class myRaceResults : UserControl
    {
        ICallback parent;
        DataClasses1DataContext data = new DataClasses1DataContext();
        string runnerId, timeNew;
        int prevTime = 0;

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public myRaceResults()
        {
            InitializeComponent();
        }

        public myRaceResults(string runnerId)
        {
            InitializeComponent();
            this.runnerId = runnerId;
            getData();
        }

        private void getData()
        {
            var getRegId = data.Registrations.Where(x => x.RunnerId.Equals(this.runnerId)).Select(x => x.RegistrationId).First();
            var getRunner = data.Runners.Where(x => x.RunnerId.Equals(this.runnerId)).First();
            lblGender.Text = getRunner.Gender;

            var getRank = data.RegistrationEvents.Where(x => x.Registration.RegistrationId.Equals(getRegId)).OrderBy(x => x.RaceTime);

            int eventYear = DateTime.Parse("2015-09-05 06:00").Year;
            int runnerYear = getRunner.DateOfBirth.Value.Year;
            int now = eventYear - runnerYear;

            if (now > 9 && now < 18)
            {
                lblAge.Text = "Under 18";
            }
            else if (now >= 18 && now < 30)
            {
                lblAge.Text = "18 to 29";
            }
            else if (now >= 30 && now < 40)
            {
                lblAge.Text = "30 to 39";
            }
            else if (now >= 40 && now < 56)
            {
                lblAge.Text = "40 to 55";
            }
            else if (now >= 56 && now < 71)
            {
                lblAge.Text = "56 to 70";
            }
            else if (now > 70)
            {
                lblAge.Text = "Over 70";
            }

            foreach (var a in getRank)
            {
                if (a.RaceTime != null)
                {
                    int i = 0, j = 0, minAge = 0, maxAge = 0;
                    string rankCat = "", ovRank = "", ovRank2 = "", ganda = "";
                    var nows = DateTime.Now;
                    int time = Int32.Parse(a.RaceTime.ToString());

                    TimeSpan times = TimeSpan.FromSeconds(time);
                    timeNew = times.Hours + "h " + times.Minutes + "m " + times.Seconds + "s";

                    var getOvRank = data.RegistrationEvents.Where(
                            x => x.Event.Marathon.MarathonName.Equals(a.Event.Marathon.MarathonName) &&
                                x.Event.EventType.EventTypeName.Equals(a.Event.EventType.EventTypeName) &&
                                x.RaceTime != null && x.RaceTime != 0
                        ).OrderBy(x => x.RaceTime);

                    foreach (var b in getOvRank)
                    {
                        if (prevTime == 0)
                        {
                            prevTime = Int32.Parse(b.RaceTime.ToString());
                            j++;
                        }
                        else
                        {
                            if (prevTime == Int32.Parse(b.RaceTime.ToString()))
                            {
                                prevTime = Int32.Parse(b.RaceTime.ToString());
                                ganda = "1";
                            }
                            else
                            {
                                prevTime = Int32.Parse(b.RaceTime.ToString());
                                j++;
                            }
                        }

                        if (ganda == "")
                        {
                            ovRank = j + "";
                        }
                        else
                        {
                            ganda = "";
                            ovRank = (j++) + "";
                        }

                        if (b.Registration.RegistrationId.Equals(getRegId))
                        {
                            ovRank2 = ovRank + "";
                        }
                    }

                    if (lblAge.Text == "Under 18")
                    {
                        var rank = getOvRank.Where(x => x.Registration.Runner.Gender.Equals(lblGender.Text) &&
                                (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year < 18)).OrderBy(x => x.RaceTime);

                        foreach (var b in rank)
                        {
                            if (prevTime == 0)
                            {
                                prevTime = Int32.Parse(b.RaceTime.ToString());
                                i++;
                            }
                            else
                            {
                                if (prevTime == Int32.Parse(b.RaceTime.ToString()))
                                {
                                    prevTime = Int32.Parse(b.RaceTime.ToString());
                                    ganda = "1";
                                }
                                else
                                {
                                    prevTime = Int32.Parse(b.RaceTime.ToString());
                                    i++;
                                }
                            }

                            if (b.Registration.RegistrationId.Equals(getRegId))
                            {
                                if (ganda == "")
                                {
                                    rankCat = i + "";
                                }
                                else
                                {
                                    ganda = "";
                                    rankCat = (i++) + "";
                                }
                            }
                        }
                    }
                    else if (lblAge.Text == "Over 70")
                    {
                        var rank = getOvRank.Where(x => x.Registration.Runner.Gender.Equals(lblGender.Text) &&
                                (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year > 70)).OrderBy(x => x.RaceTime);

                        foreach (var b in rank)
                        {
                            if (prevTime == 0)
                            {
                                prevTime = Int32.Parse(b.RaceTime.ToString());
                                i++;
                            }
                            else
                            {
                                if (prevTime == Int32.Parse(b.RaceTime.ToString()))
                                {
                                    prevTime = Int32.Parse(b.RaceTime.ToString());
                                    ganda = "1";
                                }
                                else
                                {
                                    prevTime = Int32.Parse(b.RaceTime.ToString());
                                    i++;
                                }
                            }

                            if (b.Registration.RegistrationId.Equals(getRegId))
                            {
                                if (ganda == "")
                                {
                                    rankCat = i + "";
                                }
                                else
                                {
                                    ganda = "";
                                    rankCat = (i++) + "";
                                }
                            }
                        }
                    }
                    else
                    {
                        if (lblAge.Text == "18 to 29")
                        {
                            minAge = 18;
                            maxAge = 30;
                        }
                        else if (lblAge.Text == "30 to 39")
                        {
                            minAge = 30;
                            maxAge = 40;
                        }
                        else if (lblAge.Text == "40 to 55")
                        {
                            minAge = 40;
                            maxAge = 56;
                        }
                        else if (lblAge.Text == "56 to 70")
                        {
                            minAge = 56;
                            maxAge = 71;
                        }

                        var rank = getOvRank.Where(x => x.Registration.Runner.Gender.Equals(lblGender.Text) &&
                                (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year >= minAge) && (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year < maxAge)).OrderBy(x => x.RaceTime);

                        foreach (var b in rank)
                        {
                            if (prevTime == 0)
                            {
                                prevTime = Int32.Parse(b.RaceTime.ToString());
                                i++;
                            }
                            else
                            {
                                if (prevTime == Int32.Parse(b.RaceTime.ToString()))
                                {
                                    prevTime = Int32.Parse(b.RaceTime.ToString());
                                    ganda = "1";
                                }
                                else
                                {
                                    prevTime = Int32.Parse(b.RaceTime.ToString());
                                    i++;
                                }
                            }

                            if (b.Registration.RegistrationId.Equals(getRegId))
                            {
                                if (ganda == "")
                                {
                                    rankCat = i + "";
                                }
                                else
                                {
                                    ganda = "";
                                    rankCat = (i++) + "";
                                }
                            }
                        }
                    }

                    ListViewItem lv = new ListViewItem(a.Event.Marathon.MarathonName);
                    lv.SubItems.Add(a.Event.EventType.EventTypeName);
                    lv.SubItems.Add(timeNew);
                    lv.SubItems.Add("#" + ovRank2);
                    lv.SubItems.Add("#" + rankCat);
                    listView1.Items.Add(lv);
                }
                else
                {
                    ListViewItem lv = new ListViewItem(a.Event.Marathon.MarathonName);
                    lv.SubItems.Add(a.Event.EventType.EventTypeName);
                    lv.SubItems.Add("Not Finished");
                    listView1.Items.Add(lv);
                }
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void myRaceResults_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            parent.aksi("PREVIOUSRACERESULT", "", "", "");
        }
    }
}
