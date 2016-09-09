using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarathonSkills2015_TO6.Additional.Class;
using Microsoft.Reporting.WinForms;

namespace MarathonSkills2015_TO6.Additional
{
    public partial class addTop5Runner : Form
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        List<List<RunnerInformationItem>> reportSeries = new List<List<RunnerInformationItem>>();
        List<string> eventName = new List<string>();
        bool flag = false;

        public addTop5Runner()
        {
            InitializeComponent();
        }

        private void addTop5Runner_Load(object sender, EventArgs e)
        {
            var countryList = data.Countries.Join(data.Marathons,
                c => c.CountryCode, m => m.CountryCode, (c, m) => new
                {
                    CountryName = c.CountryName,
                    CountryCode = c.CountryCode
                });

            cbCountry.DataSource = countryList;
            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryCode";

            var marathonList = data.Countries.Join(data.Marathons,
                c => c.CountryCode, m => m.CountryCode, (c, m) => new
                {
                    MarathonId = m.MarathonId,
                    MarathonName = m.MarathonName,
                    CountryCode = c.CountryCode
                }).Where(m => m.CountryCode == countryList.First().CountryCode);

            cbMarathonName.DataSource = marathonList;
            cbMarathonName.DisplayMember = "MarathonName";
            cbMarathonName.ValueMember = "MarathonId";

            var eventList = data.Countries.Join(data.Marathons,
                c => c.CountryCode, m => m.CountryCode, (c, m) => new
                {
                    MarathonId = m.MarathonId,
                    MarathonName = m.MarathonName,
                    CountryCode = c.CountryCode
                }).Where(m => m.CountryCode == countryList.First().CountryCode).Join(data.Events,
                m => m.MarathonId, ev => ev.MarathonId, (m, ev) => new
                {
                    EventId = ev.EventId,
                    EventName = ev.EventName,
                    MarathonId = m.MarathonId
                }).Where(m => m.MarathonId == marathonList.First().MarathonId);

            cbEvent.DataSource = eventList;
            cbEvent.DisplayMember = "EventName";
            cbEvent.ValueMember = "EventId";

            cbOption.Items.Clear();

            cbOption.DataSource = new List<Combo> { 
                new Combo { Text = "Fastest Top 5", Value = "fast" },
                new Combo { Text = "Latest Top 5", Value = "last" }
            };

            cbOption.DisplayMember = "Text";
            cbOption.ValueMember = "Value";

            var runnerCountryList = data.Countries.Join(data.Runners,
                c => c.CountryCode, r => r.CountryCode, (c, r) => new
                {
                    CountryCode = c.CountryCode,
                    CountryName = c.CountryName,
                    RunnerId = r.RunnerId
                }).Join(data.Registrations,
                c => c.RunnerId, reg => reg.RunnerId, (c, reg) => new
                {
                    CountryCode = c.CountryCode,
                    CountryName = c.CountryName,
                    RunnerId = c.RunnerId,
                    RegistrationId = reg.RegistrationId
                }).Join(data.RegistrationEvents,
                c => c.RegistrationId, regev => regev.RegistrationId, (c, regev) => new
                {
                    RegistrationId = c.RegistrationId,
                    RunnerId = c.RunnerId,
                    CountryCode = c.CountryCode,
                    CountryName = c.CountryName,
                    RegistrationEventId = regev.RegistrationEventId,
                    EventId = regev.EventId,
                    RaceTime = regev.RaceTime
                }).Where(c => c.EventId == eventList.First().EventId).Where(c => c.RaceTime != null).GroupBy(c => c.CountryName).Select(c => c.First());

            cbRunnerCountry.DataSource = runnerCountryList;
            cbRunnerCountry.DisplayMember = "CountryName";
            cbRunnerCountry.ValueMember = "CountryCode";

            var genderList = data.Genders.Select(c => new
            {
                Gender = c.Gender1,
                GenderCode = c.Gender1
            });

            cbRunnerGender.DataSource = genderList;
            cbRunnerGender.DisplayMember = "Gender";
            cbRunnerGender.ValueMember = "GenderCode";

            refreshReport();

            flag = true;
        }

        private void refreshReport()
        {
            this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer1.RefreshReport();
        }

        private List<RunnerInformationItem> allRunnerData(string eventId, string countryCode, string category, string gender)
        {
            List<RunnerInformationItem> reportData = new List<RunnerInformationItem>();

            if (category == "fast")
            {
                var result = data.Users.Join(data.Runners, u => u.Email, ru => ru.Email, (u, ru) => new
                {
                    RunnerName = u.FirstName + ' ' + u.LastName,
                    RunnerId = ru.RunnerId,
                    RoleId = u.RoleId,
                    CountryCode = ru.CountryCode,
                    Gender = ru.Gender
                }).Where(r => r.RoleId == 'R').Where(r => r.CountryCode == countryCode).Where(r => r.Gender == gender).Select(r => new
                {
                    RunnerName = r.RunnerName,
                    RunnerId = r.RunnerId,
                    Gender = r.Gender,
                    RoleId = r.RoleId,
                    CountryCode = r.CountryCode
                }).Join(data.Registrations, ru => ru.RunnerId, reg => reg.RunnerId, (ru, reg) => new
                {
                    RunnerId = ru.RunnerId,
                    RunnerName = ru.RunnerName,
                    Gender = ru.Gender,
                    RegistrationId = reg.RegistrationId
                }).Join(data.RegistrationEvents, reg => reg.RegistrationId, re => re.RegistrationId, (reg, re) => new
                {
                    RunnerId = reg.RunnerId,
                    RunnerName = reg.RunnerName,
                    RegistrationId = reg.RegistrationId,
                    Gender = reg.Gender,
                    RegistrationEventId = re.RegistrationEventId,
                    RaceTime = re.RaceTime,
                    EventId = re.EventId
                }).Where(r => r.RaceTime != null).Where(r => r.EventId == eventId).OrderBy(r => r.RaceTime).Take(5);

                foreach (var a in result)
                {
                    RunnerInformationItem obj = new RunnerInformationItem();
                    obj.RunnerId = a.RunnerId;
                    obj.RunnerName = a.RunnerName;
                    obj.RaceTime = Convert.ToInt32(a.RaceTime);
                    reportData.Add(obj);
                }
            }
            else
            {
                var result = data.Users.Join(data.Runners, u => u.Email, ru => ru.Email, (u, ru) => new
                {
                    RunnerName = u.FirstName + ' ' + u.LastName,
                    RunnerId = ru.RunnerId,
                    RoleId = u.RoleId,
                    CountryCode = ru.CountryCode,
                    Gender = ru.Gender
                }).Where(r => r.RoleId == 'R').Where(r => r.CountryCode == countryCode).Where(r => r.Gender == gender).Select(r => new
                {
                    RunnerName = r.RunnerName,
                    RunnerId = r.RunnerId,
                    Gender = r.Gender,
                    RoleId = r.RoleId,
                    CountryCode = r.CountryCode
                }).Join(data.Registrations, ru => ru.RunnerId, reg => reg.RunnerId, (ru, reg) => new
                {
                    RunnerId = ru.RunnerId,
                    RunnerName = ru.RunnerName,
                    Gender = ru.Gender,
                    RegistrationId = reg.RegistrationId
                }).Join(data.RegistrationEvents, reg => reg.RegistrationId, re => re.RegistrationId, (reg, re) => new
                {
                    RunnerId = reg.RunnerId,
                    RunnerName = reg.RunnerName,
                    RegistrationId = reg.RegistrationId,
                    Gender = reg.Gender,
                    RegistrationEventId = re.RegistrationEventId,
                    RaceTime = re.RaceTime,
                    EventId = re.EventId
                }).Where(r => r.RaceTime != null).Where(r => r.EventId == eventId).OrderByDescending(r => r.RaceTime).Take(5);

                foreach (var a in result)
                {
                    RunnerInformationItem obj = new RunnerInformationItem();
                    obj.RunnerId = a.RunnerId;
                    obj.RunnerName = a.RunnerName;
                    obj.RaceTime = Convert.ToInt32(a.RaceTime);
                    reportData.Add(obj);
                }
            }
            return reportData;
        }

        private DataTable convertToDatatable<T>(List<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
                else
                    table.Columns.Add(prop.Name, prop.PropertyType);
            }

            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        private void cbEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            var runnerCountryList = data.Countries.Join(data.Runners, c => c.CountryCode, r => r.CountryCode, (c, r) => new { CountryCode = c.CountryCode, CountryName = c.CountryName, RunnerId = r.RunnerId }).Join(data.Registrations, c => c.RunnerId, reg => reg.RunnerId, (c, reg) => new { CountryCode = c.CountryCode, CountryName = c.CountryName, RunnerId = c.RunnerId, RegistrationId = reg.RegistrationId }).Join(data.RegistrationEvents, c => c.RegistrationId, regev => regev.RegistrationId, (c, regev) => new { RegistrationId = c.RegistrationId, RunnerId = c.RunnerId, CountryCode = c.CountryCode, CountryName = c.CountryName, RegistrationEventId = regev.RegistrationEventId, EventId = regev.EventId, RaceTime = regev.RaceTime }).Where(c => c.EventId == cbEvent.SelectedValue.ToString()).Where(c => c.RaceTime != null).GroupBy(c => c.CountryName).Select(c => c.First());
            cbRunnerCountry.DataSource = runnerCountryList;
            cbRunnerCountry.DisplayMember = "CountryName";
            cbRunnerCountry.ValueMember = "CountryCode";
        }

        private void loadReport()
        {
            txtListWinner.Clear();

            for (int i = 0; i < eventName.Count; i++)
            {
                txtListWinner.AppendText("Event #" + (i + 1) + ". " + eventName[i].ToString());
                txtListWinner.AppendText(Environment.NewLine);
                for (int j = 0; j < reportSeries[i].Count; j++)
                {
                    txtListWinner.AppendText("Rank " + (j + 1) + " : " + reportSeries[i][j].RunnerName.ToString());
                    txtListWinner.AppendText(Environment.NewLine);
                }
                txtListWinner.AppendText(Environment.NewLine);
            }

            object[,] arrData = new object[5, 6];

            for (int i = 0; i < eventName.Count; i++)
            {
                arrData[i, 0] = eventName[i].ToString();
            }

            for (int i = 0; i < reportSeries.Count; i++)
            {
                for (int j = 0; j < reportSeries[i].Count; j++)
                {
                    arrData[j, i] = reportSeries[i][j].RaceTime;
                }
            }

            List<ReportData> listReportData = new List<ReportData>();

            for (int i = 0; i < reportSeries.Count; i++)
            {
                for (int j = 0; j < reportSeries[i].Count; j++)
                {
                    listReportData.Add(new ReportData(eventName[i].ToString(), (j + 1).ToString(), reportSeries[i][j].RaceTime));
                }
            }

            DataTable dt = new DataTable();
            dt = convertToDatatable(listReportData);
            dt.TableName = "ReportData";

            ReportDataSource rptdataSource = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rptdataSource);

            refreshReport();
        }

        int counter = 1;

        private void btnAddSeries_Click(object sender, EventArgs e)
        {
            if (counter <= 5)
            {
                string EventName = cbEvent.SelectedItem.ToString();
                if (cbRunnerCountry.Items.Count > 0)
                {
                    string RunnerCountry = cbRunnerCountry.SelectedItem.ToString();
                    List<RunnerInformationItem> series1 = allRunnerData(cbEvent.SelectedValue.ToString(), cbRunnerCountry.SelectedValue.ToString(), cbOption.SelectedValue.ToString(), cbRunnerGender.SelectedValue.ToString());

                    txtListSeries.Text += counter.ToString() + ". GET " + ((Combo)cbOption.SelectedItem).Text + " for " + EventName.Substring(EventName.IndexOf("EventName") + 12, EventName.IndexOf("MarathonId") - (EventName.IndexOf("EventName") + 14)) + " GROUP BY Country = " + RunnerCountry.Substring(RunnerCountry.IndexOf("CountryName") + 14, RunnerCountry.IndexOf("RegistrationEventId") - (RunnerCountry.IndexOf("CountryName") + 16)) + " AND Gender = " + cbRunnerGender.SelectedValue.ToString();
                    txtListSeries.AppendText(Environment.NewLine);
                    txtListSeries.AppendText(Environment.NewLine);
                    counter++;

                    reportSeries.Add(series1);
                    eventName.Add(EventName.Substring(EventName.IndexOf("EventName") + 12, EventName.IndexOf("MarathonId") - (EventName.IndexOf("EventName") + 14)) + " - " + cbRunnerGender.Text);

                    loadReport();
                }
                else
                {
                    MessageBox.Show("No Data Marathon!");
                }
            }
            else
            {
                MessageBox.Show("Maximum series is 5");
            }
        }
        bool flag2 = false;

        private void cbMarathonName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag2 == true)
            {
                var eventList = data.Marathons.Where(m => m.CountryCode == cbCountry.SelectedValue).Where(m => m.MarathonId == Convert.ToInt32(cbMarathonName.SelectedValue.ToString())).Join(data.Events, m => m.MarathonId, ev => ev.MarathonId, (m, ev) => new { EventId = ev.EventId, EventName = ev.EventName, MarathonId = m.MarathonId }).Where(m => m.MarathonId == Convert.ToInt32(cbMarathonName.SelectedValue.ToString()));

                if (eventList.FirstOrDefault() != null)
                {
                    cbEvent.DataSource = eventList;
                    cbEvent.DisplayMember = "EventName";
                    cbEvent.ValueMember = "EventId";
                }
                else
                {
                    MessageBox.Show("No event found in this marathon");
                }

                var runnerCountryList = data.Countries.Join(data.Runners, c => c.CountryCode, r => r.CountryCode, (c, r) => new { CountryCode = c.CountryCode, CountryName = c.CountryName, RunnerId = r.RunnerId }).Join(data.Registrations, c => c.RunnerId, reg => reg.RunnerId, (c, reg) => new { CountryCode = c.CountryCode, CountryName = c.CountryName, RunnerId = c.RunnerId, RegistrationId = reg.RegistrationId }).Join(data.RegistrationEvents, c => c.RegistrationId, regev => regev.RegistrationId, (c, regev) => new { RegistrationId = c.RegistrationId, RunnerId = c.RunnerId, CountryCode = c.CountryCode, CountryName = c.CountryName, RegistrationEventId = regev.RegistrationEventId, EventId = regev.EventId, RaceTime = regev.RaceTime }).Where(c => c.EventId == eventList.First().EventId).Where(c => c.RaceTime != null).GroupBy(c => c.CountryName).Select(c => c.First());
                cbRunnerCountry.DataSource = runnerCountryList;
                cbRunnerCountry.DisplayMember = "CountryName";
                cbRunnerCountry.ValueMember = "CountryCode";
            }
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == true)
            {
                var marathonList = data.Countries.Join(data.Marathons, c => c.CountryCode, m => m.CountryCode, (c, m) => new { MarathonId = m.MarathonId, MarathonName = m.MarathonName, CountryCode = c.CountryCode }).Where(m => m.CountryCode == cbCountry.SelectedValue);

                cbMarathonName.DataSource = marathonList;
                cbMarathonName.DisplayMember = "MarathonName";
                cbMarathonName.ValueMember = "MarathonId";

                var eventList = data.Marathons.Where(m => m.CountryCode == cbCountry.SelectedValue).Join(data.Events, m => m.MarathonId, ev => ev.MarathonId, (m, ev) => new { EventId = ev.EventId, EventName = ev.EventName, MarathonId = m.MarathonId }).Where(m => m.MarathonId == marathonList.First().MarathonId);

                if (eventList.FirstOrDefault() != null)
                {
                    cbEvent.DataSource = eventList;
                    cbEvent.DisplayMember = "EventName";
                    cbEvent.ValueMember = "EventId";
                }
                else
                {
                    MessageBox.Show("No event found in this marathon");
                }

                var runnerCountryList = data.Countries.Join(data.Runners, c => c.CountryCode, r => r.CountryCode, (c, r) => new { CountryCode = c.CountryCode, CountryName = c.CountryName, RunnerId = r.RunnerId }).Join(data.Registrations, c => c.RunnerId, reg => reg.RunnerId, (c, reg) => new { CountryCode = c.CountryCode, CountryName = c.CountryName, RunnerId = c.RunnerId, RegistrationId = reg.RegistrationId }).Join(data.RegistrationEvents, c => c.RegistrationId, regev => regev.RegistrationId, (c, regev) => new { RegistrationId = c.RegistrationId, RunnerId = c.RunnerId, CountryCode = c.CountryCode, CountryName = c.CountryName, RegistrationEventId = regev.RegistrationEventId, EventId = regev.EventId, RaceTime = regev.RaceTime }).Where(c => c.EventId == eventList.First().EventId).Where(c => c.RaceTime != null).GroupBy(c => c.CountryName).Select(c => c.First());
                cbRunnerCountry.DataSource = runnerCountryList;
                cbRunnerCountry.DisplayMember = "CountryName";
                cbRunnerCountry.ValueMember = "CountryCode";

                flag2 = true;
            }
        }
    }
}
