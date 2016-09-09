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
    public partial class addRunnerSpeed : Form
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        List<Runner> allRuners = new List<Runner>();
        List<short> marathonYears = new List<short>();
        List<EventType> eventTypes = new List<EventType>();

        public addRunnerSpeed()
        {
            InitializeComponent();
            getData();
        }

        private void getData()
        {
            var marType = data.EventTypes;
            allRuners = data.Runners.ToList();
            eventTypes = data.EventTypes.ToList();
            marathonYears = data.Marathons.Select(x => x.YearHeld.Value).ToList();

            cbMarathonType.Items.Add("All");

            foreach (var a in marType)
            {
                cbMarathonType.Items.Add(a.EventTypeName);
            }

            cbMarathonType.SelectedIndex = 0;
            getMarathonYear();
        }

        private void getMarathonYear()
        {
            lbMarathonYear.Items.Clear();
            var marYear = data.Marathons.Select(x => x.YearHeld).Distinct();
            foreach (var a in marYear)
            {
                lbMarathonYear.Items.Add(a);
            }
        }

        List<Runner> selectedRunner = new List<Runner>();
        private void getRunner()
        {
            if (lbMarathonYear.SelectedItems.Count == 0)
            {
                return;
            }

            var events = new List<Event>();

            if (cbMarathonType.SelectedIndex > 0)
            {
                events = data.EventTypes.Where(x => x.EventTypeName == cbMarathonType.Text).SelectMany(x => x.Events).ToList();
            }
            else
            {
                events = data.Events.ToList();
            }

            var runners = allRuners;

            for (var i = 0; i < lbMarathonYear.SelectedItems.Count; i++)
            {
                var years = marathonYears[lbMarathonYear.SelectedIndices[i]];

                runners = runners.Where(x => x.Registrations.Where(y => y.RegistrationEvents.Where(z => events.Contains(z.Event) && z.Event.Marathon.YearHeld == years && z.RaceTime != null).Count() > 0).Count() > 0).ToList();
            }

            lbRunner.Items.Clear();
            selectedRunner = runners.OrderBy(x => x.User.FirstName).ToList();

            foreach (var a in selectedRunner)
            {
                lbRunner.Items.Add(string.Format("{0} {1}", a.User.FirstName, a.User.LastName));
            }
        }

        private void Bindchart(string fullname)
        {
            chart1.Series.Clear();

            for (var i = 0; i < lbRunner.SelectedItems.Count; i++)
            {
                var runner = selectedRunner[lbRunner.SelectedIndices[i]];
                Series seriesChart = chart1.Series.Add(runner.User.FirstName + " " + runner.User.LastName);
                seriesChart.ChartType = SeriesChartType.Line;
                seriesChart.MarkerStyle = MarkerStyle.Circle;
                seriesChart.MarkerSize = 10;
                seriesChart.BorderWidth = 3;

                int inpo = 0;
                for (var j = 0; j < lbMarathonYear.SelectedItems.Count; j++)
                {
                    var year = marathonYears[lbMarathonYear.SelectedIndices[j]];
                    var data = runner.Registrations.SelectMany(x => x.RegistrationEvents).Where(x => x.Event.Marathon.YearHeld == year).ToList();

                    foreach (var a in data)
                    {
                        double average = 0;
                        if (cbMarathonType.SelectedIndex > 0)
                        {
                            if (a.Event.EventType.EventTypeName != cbMarathonType.Text)
                            {
                                continue;
                            }
                        }

                        if (a.Event.EventTypeId == "FM")
                        {
                            average = 42 / ((double)a.RaceTime.Value / (double)3600);
                        }
                        else if (a.Event.EventTypeId == "HM")
                        {
                            average = 21 / ((double)a.RaceTime.Value / (double)3600);
                        }
                        else
                        {
                            average = 5 / ((double)a.RaceTime.Value / (double)3600);
                        }

                        seriesChart.Points.AddXY(year, average);
                        seriesChart.Points[inpo].ToolTip = "Event: " + a.Event.EventName + "\nEvent Type: " + a.Event.EventType.EventTypeName + "\nAverage: " + average.ToString("F2") + " km/h";
                        inpo++;
                    }
                }
            }
        }

        private void cbMarathonType_SelectedIndexChanged(object sender, EventArgs e)
        {
            getMarathonYear();
        }

        private void lbMarathonYear_SelectedIndexChanged(object sender, EventArgs e)
        {

            getRunner();
        }

        private void lbRunner_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bindchart(lbRunner.Text);
        }
    }
}
