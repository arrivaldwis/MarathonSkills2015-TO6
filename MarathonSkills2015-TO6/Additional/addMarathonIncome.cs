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

            var reg = new List<Registration>();

            reg = data.Registrations.ToList();

            selectedRegistration = reg;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemChanged();
        }

        private void generateTable()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            dataGridView1.Columns.Add("marathon", "Marathon Name");
            if(comboBox4.SelectedIndex == 0)
            {
                foreach(var a in data.EventTypes)
                {
                    dataGridView1.Columns.Add(a.EventTypeName, a.EventTypeName);
                }
            } else if(comboBox4.SelectedIndex == 1)
            {
                foreach (var a in data.Genders)
                {
                    dataGridView1.Columns.Add(a.Gender1, a.Gender1);
                }
            }

            for(int i=0; i<listBox2.SelectedItems.Count; i++)
            {
                var yearss = marathonYears[listBox2.SelectedIndices[i]];
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i].Clone();
                row.Cells[0].Value = data.Marathons.Where(x => x.YearHeld == yearss).Select(x => x.MarathonName).FirstOrDefault().ToString();
                int inc = 1;

                if (comboBox1.SelectedIndex == 0)
                {
                    var getData = data.Registrations.Where(x => x.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0);
                    if (cbMarathonName.SelectedIndex == 0)
                    {
                        if (comboBox4.SelectedIndex == 0)
                        {
                            foreach (var a in data.EventTypes)
                            {
                                var sum = getData.Where(x => x.RegistrationEvents.Where(y => y.Event.EventType.EventTypeName.Equals(a.EventTypeName)).Count() > 0).Select(x => x.Cost);
                                try
                                {
                                    row.Cells[inc].Value = String.Format("{0:C}",sum.Sum(x => x));
                                }
                                catch (Exception ex)
                                {
                                    row.Cells[inc].Value = 0;
                                }
                                inc++;
                            }
                        }
                        else if (comboBox4.SelectedIndex == 1)
                        {
                            foreach (var a in data.Genders)
                            {
                                var sum = getData.Where(x => x.RegistrationEvents.Where(y => y.Registration.Runner.Gender.Equals(a.Gender1)).Count() > 0).Select(x => x.Cost);
                                try
                                {
                                    row.Cells[inc].Value = String.Format("{0:C}", sum.Sum(x => x));
                                }
                                catch (Exception ex)
                                {
                                    row.Cells[inc].Value = 0;
                                }
                                inc++;
                            }
                        }
                    }
                    else if (cbMarathonName.SelectedIndex == 1)
                    {
                        if (comboBox4.SelectedIndex == 0)
                        {
                            foreach (var a in data.EventTypes)
                            {
                                row.Cells[inc].Value = getData.Where(x => x.RegistrationEvents.Where(y => y.Event.EventType.EventTypeName.Equals(a.EventTypeName)).Count() > 0).Count();
                                inc++;
                            }
                        }
                        else if (comboBox4.SelectedIndex == 1)
                        {
                            foreach (var a in data.Genders)
                            {
                                row.Cells[inc].Value = getData.Where(x => x.RegistrationEvents.Where(y => y.Registration.Runner.Gender.Equals(a.Gender1)).Count() > 0).Count();
                                inc++;
                            }
                        }
                    }
                } else if(comboBox1.SelectedIndex == 1)
                {
                    var getData = data.Sponsorships.Where(x => x.Registration.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0);
                    if (cbMarathonName.SelectedIndex == 0)
                    {
                        if (comboBox4.SelectedIndex == 0)
                        {
                            foreach (var a in data.EventTypes)
                            {
                                var sum = getData.Where(x => x.Registration.RegistrationEvents.Where(y => y.Event.EventType.EventTypeName.Equals(a.EventTypeName)).Count() > 0).Select(x => x.Amount);
                                try
                                {
                                    row.Cells[inc].Value = String.Format("{0:C}", sum.Sum(x => x));
                                }
                                catch (Exception ex)
                                {
                                    row.Cells[inc].Value = 0;
                                }
                                inc++;
                            }
                        }
                        else if (comboBox4.SelectedIndex == 1)
                        {
                            foreach (var a in data.Genders)
                            {
                                var sum = getData.Where(x => x.Registration.RegistrationEvents.Where(y => y.Registration.Runner.Gender.Equals(a.Gender1)).Count() > 0).Select(x => x.Amount);
                                try
                                {
                                    row.Cells[inc].Value = String.Format("{0:C}", sum.Sum(x => x));
                                }
                                catch (Exception ex)
                                {
                                    row.Cells[inc].Value = 0;
                                }
                                inc++;
                            }
                        }
                    }
                    else if (cbMarathonName.SelectedIndex == 1)
                    {
                        if (comboBox4.SelectedIndex == 0)
                        {
                            foreach (var a in data.EventTypes)
                            {
                                row.Cells[inc].Value = getData.Where(x => x.Registration.RegistrationEvents.Where(y => y.Event.EventType.EventTypeName.Equals(a.EventTypeName)).Count() > 0).Count();
                                inc++;
                            }
                        }
                        else if (comboBox4.SelectedIndex == 1)
                        {
                            foreach (var a in data.Genders)
                            {
                                row.Cells[inc].Value = getData.Where(x => x.Registration.RegistrationEvents.Where(y => y.Registration.Runner.Gender.Equals(a.Gender1)).Count() > 0).Count();
                                inc++;
                            }
                        }
                    }
                } else
                {
                    var getData = data.Sponsorships.Where(x => x.Registration.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0);
                    var getData2 = data.Registrations.Where(x => x.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0);

                    if (cbMarathonName.SelectedIndex == 0)
                    {
                        if (comboBox4.SelectedIndex == 0)
                        {
                            foreach (var a in data.EventTypes)
                            {
                                var sumReg = getData2.Where(x => x.RegistrationEvents.Where(y => y.Event.EventType.EventTypeName.Equals(a.EventTypeName)).Count() > 0).Select(x => x.Cost);
                                var sum = getData.Where(x => x.Registration.RegistrationEvents.Where(y => y.Event.EventType.EventTypeName.Equals(a.EventTypeName)).Count() > 0).Select(x => x.Amount);
                                try
                                {
                                    row.Cells[inc].Value = String.Format("{0:C}", (sum.Sum(x => x) + sumReg.Sum(x=>x)));
                                }
                                catch (Exception ex)
                                {
                                    row.Cells[inc].Value = 0;
                                }
                                inc++;
                            }
                        }
                        else if (comboBox4.SelectedIndex == 1)
                        {
                            foreach (var a in data.Genders)
                            {
                                var sumReg = getData2.Where(x => x.RegistrationEvents.Where(y => y.Registration.Runner.Gender.Equals(a.Gender1)).Count() > 0).Select(x => x.Cost);
                                var sum = getData.Where(x => x.Registration.RegistrationEvents.Where(y => y.Registration.Runner.Gender.Equals(a.Gender1)).Count() > 0).Select(x => x.Amount);
                                try
                                {
                                    row.Cells[inc].Value = String.Format("{0:C}", (sum.Sum(x => x) + sumReg.Sum(x => x)));
                                }
                                catch (Exception ex)
                                {
                                    row.Cells[inc].Value = 0;
                                }
                                inc++;
                            }
                        }
                    }
                    else if (cbMarathonName.SelectedIndex == 1)
                    {
                        if (comboBox4.SelectedIndex == 0)
                        {
                            foreach (var a in data.EventTypes)
                            {
                                int sumReg = getData2.Where(x => x.RegistrationEvents.Where(y => y.Event.EventType.EventTypeName.Equals(a.EventTypeName)).Count() > 0).Count();
                                int sum = getData.Where(x => x.Registration.RegistrationEvents.Where(y => y.Event.EventType.EventTypeName.Equals(a.EventTypeName)).Count() > 0).Count();
                                row.Cells[inc].Value = sumReg + sum;
                                inc++;
                            }
                        }
                        else if (comboBox4.SelectedIndex == 1)
                        {
                            foreach (var a in data.Genders)
                            {
                                int sumReg = getData2.Where(x => x.RegistrationEvents.Where(y => y.Registration.Runner.Gender.Equals(a.Gender1)).Count() > 0).Count();
                                int sum = getData.Where(x => x.Registration.RegistrationEvents.Where(y => y.Registration.Runner.Gender.Equals(a.Gender1)).Count() > 0).Count();
                                row.Cells[inc].Value = sumReg + sum;
                                inc++;
                            }
                        }
                    }
                }

                dataGridView1.Rows.Add(row);
            }
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
                                        var sum = data.Registrations.Where(x => x.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.RegistrationEvents.Where(s => s.Event.EventType.EventTypeName.Equals(eventTypes[i])).Count()>0).Select(x=>x.Cost);
                                        try {
                                            chart1.Series[eventTypes[i]].Points.AddXY(b.First().RegistrationEvents.First().Event.Marathon.YearHeld + "", sum.Sum(x => x));
                                        } catch (Exception ex)
                                        {
                                            chart1.Series[eventTypes[i]].Points.AddXY(b.First().RegistrationEvents.First().Event.Marathon.YearHeld + "", 0);
                                        }
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
                                        var sum = data.Registrations.Where(x => x.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.RegistrationEvents.Where(s => s.Registration.Runner.Gender.Equals(genders[i])).Count() > 0).Select(x=>x.Cost);
                                        try
                                        {
                                            chart1.Series[genders[i]].Points.AddXY(b.First().RegistrationEvents.First().Event.Marathon.YearHeld + "", sum.Sum(x => x));
                                        }
                                        catch (Exception ex)
                                        {
                                            chart1.Series[genders[i]].Points.AddXY(b.First().RegistrationEvents.First().Event.Marathon.YearHeld + "", 0);
                                        }
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
                                        var sum = data.Sponsorships.Where(x => x.Registration.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.Registration.RegistrationEvents.Where(s => s.Event.EventType.EventTypeName.Equals(eventTypes[i])).Count() > 0).Select(x => x.Amount);
                                        try
                                        {
                                            chart1.Series[eventTypes[i]].Points.AddXY(b.First().RegistrationEvents.First().Event.Marathon.YearHeld + "", sum.Sum(x => x));
                                        }
                                        catch (Exception ex)
                                        {
                                            chart1.Series[eventTypes[i]].Points.AddXY(b.First().RegistrationEvents.First().Event.Marathon.YearHeld + "", 0);
                                        }
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
                                        var sum = data.Sponsorships.Where(x => x.Registration.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.Registration.RegistrationEvents.Where(s => s.Registration.Runner.Gender.Equals(genders[i])).Count() > 0).Select(x => x.Amount);
                                        try
                                        {
                                            chart1.Series[genders[i]].Points.AddXY(b.First().RegistrationEvents.First().Event.Marathon.YearHeld + "", sum.Sum(x => x));
                                        }
                                        catch (Exception ex)
                                        {
                                            chart1.Series[genders[i]].Points.AddXY(b.First().RegistrationEvents.First().Event.Marathon.YearHeld + "", 0);
                                        }
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
                            var b = selectedRegistration.Where(x => x.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).ToList();

                            if (a.Count() > 0)
                            {
                                if (b.Count() > 0)
                                {
                                    if (comboBox4.SelectedIndex == 0)
                                    {
                                        if (cbMarathonName.SelectedIndex == 0)
                                        {
                                            int sumTot = 0, sumSponTot = 0;
                                            var sum = data.Registrations.Where(x => x.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.RegistrationEvents.Where(s => s.Event.EventType.EventTypeName.Equals(eventTypes[i])).Count() > 0).Select(x => x.Cost);
                                            var sumSpon = data.Sponsorships.Where(x => x.Registration.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.Registration.RegistrationEvents.Where(s => s.Event.EventType.EventTypeName.Equals(eventTypes[i])).Count() > 0).Select(x => x.Amount);

                                            try {
                                                sumTot = Decimal.ToInt32(sum.Sum(x => x));
                                            } catch (Exception ex)
                                            {
                                                sumTot = 0;
                                            }

                                            try
                                            {
                                                sumSponTot = Decimal.ToInt32(sumSpon.Sum(x => x));
                                            }
                                            catch (Exception ex)
                                            {
                                                sumSponTot = 0;
                                            }

                                            chart1.Series[eventTypes[i]].Points.AddXY(a.First().RegistrationEvents.First().Event.Marathon.YearHeld + "", (int) sumTot + sumSponTot);
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
                                            int sumTot = 0, sumSponTot = 0;
                                            var sum = data.Registrations.Where(x => x.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.RegistrationEvents.Where(s => s.Event.EventType.EventTypeName.Equals(eventTypes[i])).Count() > 0).Select(x => x.Cost);
                                            var sumSpon = data.Sponsorships.Where(x => x.Registration.RegistrationEvents.Where(y => y.Event.Marathon.YearHeld == yearss).Count() > 0).Where(z => z.Registration.RegistrationEvents.Where(s => s.Registration.Runner.Gender.Equals(genders[i])).Count() > 0).Select(x => x.Amount);

                                            try
                                            {
                                                sumTot = Decimal.ToInt32(sum.Sum(x => x));
                                            }
                                            catch (Exception ex)
                                            {
                                                sumTot = 0;
                                            }

                                            try
                                            {
                                                sumSponTot = Decimal.ToInt32(sumSpon.Sum(x => x));
                                            }
                                            catch (Exception ex)
                                            {
                                                sumSponTot = 0;
                                            }

                                            chart1.Series[genders[i]].Points.AddXY(a.First().RegistrationEvents.First().Event.Marathon.YearHeld + "", (int) sumTot + sumSponTot);
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
