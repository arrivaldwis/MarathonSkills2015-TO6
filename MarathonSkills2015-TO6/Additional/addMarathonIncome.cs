using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MarathonSkills2015_TO6.Additional
{
    public partial class addMarathonIncome : Form
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        List<Registration> selectedRegistration = new List<Registration>();
        List<Sponsorship> selectedSponsorship = new List<Sponsorship>();
        List<short> marathonYears = new List<short>();
        Title tt;

        public addMarathonIncome()
        {
            InitializeComponent();
            getMarathonYear();
        }

        private void addMarathonIncome_Load(object sender, EventArgs e)
        {

        }

        private void getMarathonYear()
        {
            marathonYears = data.Marathons.Select(x => x.YearHeld.Value).ToList();

            listBox2.Items.Clear();
            var marYear = data.Marathons.Select(x => x.YearHeld).Distinct();
            foreach (var a in marYear)
            {
                listBox2.Items.Add(a);
            }

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            cbMarathonName.SelectedIndex = 0;
        }

        private void itemChanged()
        {
            if (listBox2.SelectedItems.Count == 0)
            {
                return;
            }

            if (comboBox1.SelectedIndex == 0)
            {
                var reg = new List<Registration>();

                reg = data.Registrations.ToList();

                selectedRegistration = reg;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                var spon = new List<Sponsorship>();

                spon = data.Sponsorships.ToList();

                selectedSponsorship = spon;
            }
            else
            {
                //All income
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemChanged();
        }

        private void generateTable()
        {
            int counter = -1;
            dataGridView1.DataSource = data.Marathons.Select(
                x => new
                {
                    MarathonName = marathonYears[(counter+1)] == x.YearHeld?x.MarathonName:"2015",
                    FullMarathon = data.Registrations.Where(y => y.RegistrationEvents.Where(z => z.Event.Marathon.YearHeld == x.YearHeld).Count() > 0).Where(y=>y.RegistrationEvents.Where(z=>z.Event.EventType.EventTypeName.Equals("Full Marathon")).Count()>0).Count(),
                    FunRun = data.Registrations.Where(y => y.RegistrationEvents.Where(z => z.Event.Marathon.YearHeld == x.YearHeld).Count() > 0).Where(y=>y.RegistrationEvents.Where(z=>z.Event.EventType.EventTypeName.Equals("5km Fun Run")).Count()>0).Count(),
                    HalfMarathon = data.Registrations.Where(y => y.RegistrationEvents.Where(z => z.Event.Marathon.YearHeld == x.YearHeld).Count() > 0).Where(y => y.RegistrationEvents.Where(z => z.Event.EventType.EventTypeName.Equals("Half Marathon")).Count() > 0).Count()
                });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            generateTable();

            tt = new Title();
            tt.Name = "ChartArea1";

            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

            chart1.Series.Clear();

            if (listBox2.Items.Count > 0)
            {
                int val = 0;
                List<string> eventTypes = new List<string>();
                List<string> genders = new List<string>();

                eventTypes = data.EventTypes.Select(x => x.EventTypeName).ToList();
                genders = data.Genders.Select(x => x.Gender1).ToList();

                if (comboBox4.SelectedIndex == 0)
                {
                    val = data.EventTypes.Count();
                }
                else
                {
                    val = data.Genders.Count();
                }

                for (int i = 0; i < val; i++)
                {
                    if (comboBox4.SelectedIndex == 0)
                    {
                        chart1.Series.Add(eventTypes[i]);
                    }
                    else
                    {
                        chart1.Series.Add(genders[i]);
                    }

                    for (var j = 0; j < listBox2.SelectedItems.Count; j++)
                    {
                        var yearss = marathonYears[listBox2.SelectedIndices[j]];
                        if (comboBox1.SelectedIndex == 0)
                        {
                            var b = selectedRegistration.Where(x => x.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).ToList();
                            if (b.Count() > 0)
                            {
                                if (comboBox4.SelectedIndex == 0)
                                {
                                    if (cbMarathonName.SelectedIndex == 0)
                                    {
                                        int sum = (int)data.Registrations.Where(x => x.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.RegistrationEvents.Where(s => s.Event.EventType.EventTypeName.Equals(eventTypes[i])).Count()>0).Sum(x=>x.Cost);
                                        chart1.Series[eventTypes[i]].Points.AddXY(b.First().RegistrationEvents.First().Event.Marathon.YearHeld + "", sum);
                                        chart1.Series[eventTypes[i]].IsValueShownAsLabel = true;
                                    }
                                    else if (cbMarathonName.SelectedIndex == 1)
                                    {
                                        chart1.Series[eventTypes[i]].Points.AddXY(b.First().RegistrationEvents.First().Event.Marathon.YearHeld + "", (int)data.Registrations.Where(x => x.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.RegistrationEvents.Where(s => s.Event.EventType.EventTypeName.Equals(eventTypes[i])).Count() > 0).Select(x => x.Cost).Count());
                                        chart1.Series[eventTypes[i]].IsValueShownAsLabel = true;
                                    }
                                }
                                else if (comboBox4.SelectedIndex == 1)
                                {
                                    if (cbMarathonName.SelectedIndex == 0)
                                    {
                                        chart1.Series[genders[i]].Points.AddXY(b.First().RegistrationEvents.First().Event.Marathon.YearHeld + "", (int)data.Registrations.Where(x => x.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.RegistrationEvents.Where(s => s.Registration.Runner.Gender.Equals(genders[i])).Count() > 0).Sum(x => x.Cost));
                                        chart1.Series[genders[i]].IsValueShownAsLabel = true;
                                    }
                                    else if (cbMarathonName.SelectedIndex == 1)
                                    {
                                        chart1.Series[genders[i]].Points.AddXY(b.First().RegistrationEvents.First().Event.Marathon.YearHeld + "", (int)data.Registrations.Where(x => x.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.RegistrationEvents.Where(s => s.Registration.Runner.Gender.Equals(genders[i])).Count() > 0).Select(x => x.Cost).Count());
                                        chart1.Series[genders[i]].IsValueShownAsLabel = true;
                                    }
                                }
                            }
                        }
                        else if (comboBox1.SelectedIndex == 1)
                        {
                            var b = selectedRegistration.Where(x => x.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).ToList();
                            if (b.Count() > 0)
                            {
                                if (comboBox4.SelectedIndex == 0)
                                {
                                    if (cbMarathonName.SelectedIndex == 0)
                                    {
                                        chart1.Series[eventTypes[i]].Points.AddXY(b.First().RegistrationEvents.First().Event.Marathon.YearHeld + "", (int)data.Sponsorships.Where(x => x.Registration.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.Registration.RegistrationEvents.Where(s => s.Event.EventType.EventTypeName.Equals(eventTypes[i])).Count() > 0).Sum(x => x.Amount));
                                        chart1.Series[eventTypes[i]].IsValueShownAsLabel = true;
                                    }
                                    else if (cbMarathonName.SelectedIndex == 1)
                                    {
                                        chart1.Series[eventTypes[i]].Points.AddXY(b.First().RegistrationEvents.First().Event.Marathon.YearHeld + "", (int)data.Sponsorships.Where(x => x.Registration.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.Registration.RegistrationEvents.Where(s => s.Event.EventType.EventTypeName.Equals(eventTypes[i])).Count() > 0).Select(x => x.Amount).Count());
                                        chart1.Series[eventTypes[i]].IsValueShownAsLabel = true;
                                    }
                                }
                                else if (comboBox4.SelectedIndex == 1)
                                {
                                    if (cbMarathonName.SelectedIndex == 0)
                                    {
                                        chart1.Series[genders[i]].Points.AddXY(b.First().RegistrationEvents.First().Event.Marathon.YearHeld + "", (int)data.Sponsorships.Where(x => x.Registration.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.Registration.RegistrationEvents.Where(s => s.Registration.Runner.Gender.Equals(genders[i])).Count() > 0).Sum(x => x.Amount));
                                        chart1.Series[genders[i]].IsValueShownAsLabel = true;
                                    }
                                    else if (cbMarathonName.SelectedIndex == 1)
                                    {
                                        chart1.Series[genders[i]].Points.AddXY(b.First().RegistrationEvents.First().Event.Marathon.YearHeld + "", (int)data.Sponsorships.Where(x => x.Registration.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.Registration.RegistrationEvents.Where(s => s.Registration.Runner.Gender.Equals(genders[i])).Count() > 0).Select(x => x.Amount).Count());
                                        chart1.Series[genders[i]].IsValueShownAsLabel = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            var a = selectedRegistration.Where(x => x.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).ToList();
                            var b = selectedRegistration.Where(x => x.RegistrationEvents.Where(y => y.Event.Marathon.MarathonId == yearss).Count() > 0).ToList();

                            if (a.Count() > 0)
                            {
                                if (b.Count() > 0)
                                {
                                    if (comboBox4.SelectedIndex == 0)
                                    {
                                        if (cbMarathonName.SelectedIndex == 0)
                                        {
                                            chart1.Series[eventTypes[i]].Points.AddXY(a.First().RegistrationEvents.First().Event.Marathon.YearHeld + "", (int)
                                                (data.Registrations.Where(x => x.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.RegistrationEvents.Where(s => s.Event.EventType.EventTypeName.Equals(eventTypes[i])).Count() > 0).Select(x => x.Cost).Sum(x => x)) +
                                                data.Sponsorships.Where(x => x.Registration.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.Registration.RegistrationEvents.Where(s => s.Event.EventType.EventTypeName.Equals(eventTypes[i])).Count() > 0).Select(x => x.Amount).Sum(x => x));
                                            chart1.Series[eventTypes[i]].IsValueShownAsLabel = true;
                                        }
                                        else if (cbMarathonName.SelectedIndex == 1)
                                        {
                                            chart1.Series[eventTypes[i]].Points.AddXY(a.First().RegistrationEvents.First().Event.Marathon.YearHeld + "", (int)
                                                (data.Registrations.Where(x => x.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.RegistrationEvents.Where(s => s.Event.EventType.EventTypeName.Equals(eventTypes[i])).Count() > 0).Select(x => x.Cost).Count()) +
                                                data.Sponsorships.Where(x => x.Registration.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.Registration.RegistrationEvents.Where(s => s.Event.EventType.EventTypeName.Equals(eventTypes[i])).Count() > 0).Select(x => x.Amount).Count());
                                            chart1.Series[eventTypes[i]].IsValueShownAsLabel = true;
                                        }
                                    }
                                    else
                                    {
                                        if (cbMarathonName.SelectedIndex == 0)
                                        {
                                            chart1.Series[genders[i]].Points.AddXY(a.First().RegistrationEvents.First().Event.Marathon.YearHeld + "", (int)
                                                (data.Registrations.Where(x => x.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.RegistrationEvents.Where(s => s.Event.EventType.EventTypeName.Equals(eventTypes[i])).Count() > 0).Select(x => x.Cost).Sum(x => x)) +
                                                data.Sponsorships.Where(x => x.Registration.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.Registration.RegistrationEvents.Where(s => s.Registration.Runner.Gender.Equals(genders[i])).Count() > 0).Select(x => x.Amount).Sum(x => x));
                                            chart1.Series[genders[i]].IsValueShownAsLabel = true;
                                        }
                                        else if (cbMarathonName.SelectedIndex == 1)
                                        {
                                            chart1.Series[genders[i]].Points.AddXY(a.First().RegistrationEvents.First().Event.Marathon.YearHeld + "", (int)
                                                (data.Registrations.Where(x => x.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.RegistrationEvents.Where(s => s.Event.EventType.EventTypeName.Equals(eventTypes[i])).Count() > 0).Select(x => x.Cost).Count()) +
                                                data.Sponsorships.Where(x => x.Registration.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.Registration.RegistrationEvents.Where(s => s.Registration.Runner.Gender.Equals(genders[i])).Count() > 0).Select(x => x.Amount).Count());
                                            chart1.Series[genders[i]].IsValueShownAsLabel = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (comboBox2.SelectedIndex == 0)
                {
                    if (comboBox4.SelectedIndex == 0)
                    {
                        for (int i = 0; i < eventTypes.Count; i++)
                        {
                            chart1.Series[i].ChartType = SeriesChartType.Column;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < genders.Count; i++)
                        {
                            chart1.Series[i].ChartType = SeriesChartType.Column;
                        }
                    }
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    if (comboBox4.SelectedIndex == 0)
                    {
                        for (int i = 0; i < eventTypes.Count; i++)
                        {
                            chart1.Series[i].ChartType = SeriesChartType.Line;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < genders.Count; i++)
                        {
                            chart1.Series[i].ChartType = SeriesChartType.Line;
                        }
                    }
                }

                chart1.Titles.Clear();
                chart1.Titles.Add(tt);
                eventTypes.Clear();
                genders.Clear();
            }
            else
            {
                MessageBox.Show("Please select the criteria!");
            }
        }
    }
}
