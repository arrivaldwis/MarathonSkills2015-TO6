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
        DataClasses1DataContext db = new DataClasses1DataContext();
        string timeNew, runnerId;
        int prevTime = 0;
        string country = "Brazil";

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public myRaceResults(string runnerId)
        {
            InitializeComponent();
            this.runnerId = runnerId;
            getData();
        }

        public void getData()
        {
            var getRegId = db.Registrations.Where(x => x.RunnerId.Equals(this.runnerId)).Select(x => x.RegistrationId).FirstOrDefault();

            if (getRegId != null)
            {
                string age = "";
                var getRunner = db.Runners.Where(x => x.RunnerId.Equals(this.runnerId)).FirstOrDefault();
                label2.Text = getRunner.Gender;

                double date = (DateTime.Parse("2015-09-05 06:00") - getRunner.DateOfBirth.Value).TotalDays;
                double now = Math.Round(date / 365);

                if (now > 9 && now < 18)
                {
                    age = "Under 18";
                }
                else if (now >= 18 && now < 30)
                {
                    age = "18 to 29";
                }
                else if (now >= 30 && now < 40)
                {
                    age = "30 to 39";
                }
                else if (now >= 40 && now < 56)
                {
                    age = "40 to 55";
                }
                else if (now >= 56 && now < 71)
                {
                    age = "56 to 70";
                }
                else if (now > 70)
                {
                    age = "Over 70";
                }

                label6.Text = age;

                var getRank = db.RegistrationEvents.Where(x => x.RegistrationId.Equals(getRegId)).OrderBy(x=>x.RaceTime);

                foreach (var a in getRank)
                {
                    if (a.RaceTime != null)
                    {
                        int i = 0, j = 0, minAge = 0, maxAge = 0;
                        string rankCat = "", ovRank = "", ovRank2 = "", ganda = "";
                        var nows = DateTime.Now;
                        int time = int.Parse(a.RaceTime.ToString());

                        TimeSpan times = TimeSpan.FromSeconds(time);
                        timeNew = times.Hours + "h " + times.Minutes + "m " + times.Seconds + "s";

                        var getOvRank = db.RegistrationEvents.Where(
                            x => x.Event.Marathon.MarathonName.Equals(a.Event.Marathon.MarathonName) &&
                                x.Event.EventType.EventTypeName.Equals(a.Event.EventType.EventTypeName) &&
                                x.RaceTime != null && x.RaceTime != 0
                            ).OrderBy(x => x.RaceTime);

                        foreach (var b in getOvRank)
                        {
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

                            if (ganda == "")
                            {
                                ovRank = j + "";
                            }
                            else
                            {
                                ganda = "";
                                ovRank = (j++) +"";
                            }

                            if (b.RegistrationId.Equals(getRegId))
                            {
                                ovRank2 = ovRank + "";
                            }
                        }

                        if (label6.Text == "Under 18")
                        {
                            var rank = getOvRank.Where(
                                x => x.Registration.Runner.Gender.Equals(label2.Text) &&
                                    (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year < 18)
                                    ).OrderBy(x => x.RaceTime);

                            foreach (var b in rank)
                            {
                                if (prevTime == 0)
                                {
                                    prevTime = int.Parse(b.RaceTime.ToString());
                                    i++;
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
                                        i++;
                                    }
                                }

                                if (b.RegistrationId.Equals(getRegId))
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
                        else if (label6.Text == "Over 70")
                        {
                            var rank = getOvRank.Where(
                                x => x.Registration.Runner.Gender.Equals(label2.Text) &&
                                    (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year > 70)
                                    ).OrderBy(x => x.RaceTime);

                            foreach (var b in rank)
                            {
                                if (prevTime == 0)
                                {
                                    prevTime = int.Parse(b.RaceTime.ToString());
                                    i++;
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
                                        i++;
                                    }
                                }

                                if (b.RegistrationId.Equals(getRegId))
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
                            if (label6.Text == "18 to 29")
                            {
                                minAge = 18;
                                maxAge = 30;
                            }
                            else if (label6.Text == "30 to 39")
                            {
                                minAge = 30;
                                maxAge = 40;
                            }
                            else if (label6.Text == "40 to 55")
                            {
                                minAge = 40;
                                maxAge = 56;
                            }
                            else if (label6.Text == "56 to 70")
                            {
                                minAge = 56;
                                maxAge = 71;
                            }

                            var rank = getOvRank.Where(
                                x => x.Registration.Runner.Gender.Equals(label2.Text) &&
                                    (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year >= minAge) &&
                                    (nows.Year - x.Registration.Runner.DateOfBirth.Value.Year < maxAge)
                                    ).OrderBy(x => x.RaceTime);

                            foreach (var b in rank)
                            {
                                if (prevTime == 0)
                                {
                                    prevTime = int.Parse(b.RaceTime.ToString());
                                    i++;
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
                                        i++;
                                    }
                                }

                                if (b.RegistrationId.Equals(getRegId))
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

                        if(a.Event.Marathon.MarathonId == 1) {
                            country = "United Kingdom";
                        } else if(a.Event.Marathon.MarathonId == 2) {
                            country = "Vietnam";
                        } else if(a.Event.Marathon.MarathonId == 3) {
                            country = "Germany";
                        } else if(a.Event.Marathon.MarathonId == 4) {
                            country = "Japan";
                        }

                        ListViewItem lv = new ListViewItem(a.Event.Marathon.YearHeld + " " + country);
                        lv.SubItems.Add(a.Event.EventName);
                        lv.SubItems.Add(timeNew);
                        lv.SubItems.Add("#"+ovRank2);
                        lv.SubItems.Add("#"+rankCat);
                        listView1.Items.Add(lv);
                    }
                    else
                    {
                        ListViewItem lv = new ListViewItem(a.Event.Marathon.YearHeld + " " + country);
                        lv.SubItems.Add(a.Event.EventName);
                        lv.SubItems.Add("Not Finished");
                        listView1.Items.Add(lv);
                    }
                }

                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
    }
}
