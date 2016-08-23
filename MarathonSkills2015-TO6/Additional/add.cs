using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;

namespace MarathonSkills2015_TO6.Additional
{
    public partial class add : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        List<short> years;
        List<AgeCriteria> ageCriterias = new List<AgeCriteria>();
        List<short> marathonYears = new List<short>();
        List<Event> allEvent = new List<Event>();
        List<Event> selectedEvent = new List<Event>();
        int year = DateTime.Parse("2015-09-05 06:00").Year;
        Title tt;

        SpeechSynthesizer speech = new SpeechSynthesizer();
        string letter = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string numeric = "0123456789";
        string symbol = "$@!*&";
        string rndWord;

        public add()
        {
            InitializeComponent();
            getData();
        }

        class AgeCriteria
        {
            public int AgeMin { get; set; }
            public int AgeMax { get; set; }
            public string Label { get; set; }

            public AgeCriteria(string min, string max)
            {
                if (min == "Under")
                {
                    AgeMin = 0;
                    AgeMax = int.Parse(max) - 1;
                    Label = "Under " + max;
                }
                else if (min == "Over")
                {
                    AgeMin = int.Parse(max) + 1;
                    AgeMax = int.MaxValue;
                    Label = "Over " + max;
                }
                else
                {
                    AgeMin = int.Parse(min);
                    AgeMax = int.Parse(max);

                    if (AgeMin > AgeMax)
                    {
                        throw new Exception("Age Criteria 1 must lower than Age Criteria 2!");
                    }
                    Label = min + " to " + max;
                }
            }
        }

        private void getData()
        {
            var marathon = db.EventTypes;
            allEvent = db.Events.ToList();
            marathonYears = db.Marathons.Select(x => x.YearHeld.Value).ToList();

            foreach (var a in marathon)
            {
                cbMarathonName.Items.Add(a.EventTypeName);
            }

            cbAge1.Items.Add("Under");
            cbAge1.Items.Add("Over");

            for (int i = 18; i <= 60; i++)
            {
                cbAge1.Items.Add(i);
            }

            for (int i = 18; i <= 70; i++)
            {
                cbAge2.Items.Add(i);
            }

            years = db.Marathons.Select(x => x.YearHeld.Value).ToList();

            foreach (var year in years)
            {
                listBox2.Items.Add(year);
            }

            listBox2.SelectedIndex = 0;

            comboBox4.Items.Add("Column");
            comboBox4.Items.Add("Line");
            comboBox4.SelectedIndex = 0;
        }

        void refreshList()
        {
            listBox1.Items.Clear();
            ageCriterias = ageCriterias.OrderBy(x => x.AgeMin).ToList();
            foreach (var ageItem in ageCriterias)
            {
                listBox1.Items.Add(ageItem.Label);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ageCriterias.Count == 5)
                {
                    MessageBox.Show("The maximum criteria is 5!");
                    return;
                }

                var newAgeCriteria = new AgeCriteria(cbAge1.SelectedItem.ToString(), cbAge2.SelectedItem.ToString());
                var checks = ageCriterias.Where(x => (newAgeCriteria.AgeMin >= x.AgeMin && newAgeCriteria.AgeMin <= x.AgeMax) ||
                    (newAgeCriteria.AgeMax >= x.AgeMin && newAgeCriteria.AgeMax <= x.AgeMax) ||
                    (newAgeCriteria.AgeMin <= x.AgeMin && newAgeCriteria.AgeMax >= x.AgeMax)).Count();

                if (checks > 0)
                {
                    MessageBox.Show("Age criteria already exist!");
                    return;
                }

                ageCriterias.Add(newAgeCriteria);
                refreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getEvents();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == 0)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    chart1.Series[i].ChartType = SeriesChartType.Column;
                }
            }
            else if (comboBox4.SelectedIndex == 1)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    chart1.Series[i].ChartType = SeriesChartType.Line;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Criteria list must be chosen");
            }
            else
            {
                ageCriterias.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                refreshList();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                button4.Enabled = false;
                generate();
                speech.Rate = -4;
                panel2.Visible = true;
            }
            else
            {
                MessageBox.Show("Please select the criteria and generate!");
            }
        }

        private Image GetImage(int width, int height, String text)
        {
            Image img = new Bitmap(text.Length * 20 + 45, 55);
            Random rand = new Random();
            int rotate;

            Color bgcolor = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            SolidBrush sb = new SolidBrush(Color.FromArgb(bgcolor.ToArgb() ^ 0xffffff));
            Graphics graph = Graphics.FromImage(img);
            var hs = (HatchStyle[])Enum.GetValues(typeof(HatchStyle));

            for (int i = 0; i < hs.Length; i++)
            {
                using (HatchBrush hbr = new HatchBrush(hs[i], bgcolor))
                using (HatchBrush hbr2 = new HatchBrush(hs[i], bgcolor))
                {
                    graph.FillRectangle(hbr, new Rectangle(i * rand.Next(0, 3), rand.Next(4, 7), width, height));
                }
            }

            FontFamily[] ff = new FontFamily[]{
                new FontFamily("Arial"),
                new FontFamily("Calibri"),
                new FontFamily("Times New Roman"),
                new FontFamily("Jokerman"),
            };

            Font font;
            for (int i = 0; i < text.Length; i++)
            {
                rotate = rand.Next(0, 30);
                Matrix mtr = new Matrix();
                mtr.RotateAt(rotate, new Point(i * 22 + 10, 10));
                graph.Transform = mtr;
                font = new Font(ff[rand.Next(0, ff.Length - 1)], rand.Next(14, 20), FontStyle.Bold);
                graph.DrawString((rand.Next(0, 1) == 1 ? Char.ToUpper(text[i]) : text[i]).ToString(), font, sb, new Point(i * 22 + 20, 20));
                mtr.RotateAt(-rotate, new Point(i * 22 + 10, 10));
            }

            return img;

        }

        private void generate()
        {
            Random rand = new Random();
            string rdword = "";
            int length = rand.Next(4, 6);
            for (int i = 0; i < length; i++)
            {
                switch (rand.Next(1, 4))
                {
                    case 1: rdword += letter[rand.Next(0, letter.Length - 1)]; break;
                    case 2: rdword += symbol[rand.Next(0, symbol.Length - 1)]; break;
                    case 3: rdword += numeric[rand.Next(0, numeric.Length - 1)]; break;
                }
            }

            rndWord = rdword;
            pictureBox1.Image = GetImage(280, 89, rndWord);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            generate();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            speech.Speak(rndWord);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (rndWord == textBox1.Text)
            {
                button4.Enabled = true;
                panel2.Visible = false;
                generate();
                textBox1.Text = "";
                exportExcel();
            }
            else
            {
                MessageBox.Show("Wrong Captcha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportExcel()
        {
            string chart;
            int b = 7, c = 6, j = 2;
            char alpha = 'B';
            int yearMarathon = 2011;

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add();
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Cells[1, 1] = "";
            xlWorkSheet.Range["A6"].Value = "";

            var events = selectedEvent.ToList();

            for (var g = 0; g < listBox2.SelectedItems.Count; g++)
            {
                var yearss = marathonYears[listBox2.SelectedIndices[g]];
                var acara = events.Where(x => x.Marathon.YearHeld == yearss).ToList();

                if (acara.Count() > 0)
                {
                    xlWorkSheet.Range[alpha + "6"].Value = yearss;
                    xlWorkSheet.get_Range("B6", alpha + "6").BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, (Excel.XlColorIndex)1, ColorTranslator.ToOle(Color.Black), Type.Missing);
                    alpha++;
                }
            }

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                c++;
                xlWorkSheet.Cells[c, 1].Value = listBox1.Items[i].ToString();
                xlWorkSheet.get_Range("A6", "A" + c).BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, (Excel.XlColorIndex)1, ColorTranslator.ToOle(Color.Black), Type.Missing);
            }

            xlWorkSheet.get_Range("A1", "C4").Merge();
            xlWorkSheet.Shapes.AddPicture(Environment.CurrentDirectory + "/Resources/logo-2015-full-colour.png", MsoTriState.msoFalse, MsoTriState.msoCTrue, 5, 2, 140, 60);

            xlWorkSheet.get_Range("D1", "V4").Merge();
            xlWorkSheet.get_Range("D1", "V4").Font.Size = 20;
            xlWorkSheet.get_Range("D1", "V4").Font.Bold = true;
            xlWorkSheet.get_Range("D1", "V4").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlWorkSheet.get_Range("D1", "D1").Value = " Marathon Skills 2015 - Runner Report";

            xlWorkSheet.get_Range("A6", "F6").Font.Bold = true;
            xlWorkSheet.get_Range("A6", "A11").Font.Bold = true;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                alpha = 'B';
                for (var g = 0; g < listBox2.SelectedItems.Count; g++)
                {
                    var yearss = marathonYears[listBox2.SelectedIndices[g]];
                    var ar = events.Where(x => x.Marathon.YearHeld == yearss).ToList();
                    if (ar.Count > 0)
                    {
                        chart = listBox1.Items[i].ToString();
                        if (listBox1.Items[i].ToString().Contains("Under"))
                        {
                            string a = chart.Split(' ')[1];
                            xlWorkSheet.Cells[b, j] = (int)db.RegistrationEvents.Where(x => x.Event.EventType.EventTypeName.Equals(cbMarathonName.Text) && x.Event.EventName.Equals(ar.First().EventName) && (year - x.Registration.Runner.DateOfBirth.Value.Year < int.Parse(a))).Select(x => x.Registration.Runner.RunnerId).Count();
                        }
                        else if (listBox1.Items[i].ToString().Contains("Over"))
                        {
                            string a = chart.Split(' ')[1];
                            xlWorkSheet.Cells[b, j] = (int)db.RegistrationEvents.Where(x => x.Event.EventType.EventTypeName.Equals(cbMarathonName.Text) && x.Event.EventName.Equals(ar.First().EventName) && (year - x.Registration.Runner.DateOfBirth.Value.Year > int.Parse(a))).Select(x => x.Registration.Runner.RunnerId).Count();
                        }
                        else
                        {
                            string awal = chart.Split('t', 'o')[0];
                            string akhir = chart.Split('t', 'o')[2];
                            xlWorkSheet.Cells[b, j] = (int)db.RegistrationEvents.Where(x => x.Event.EventType.EventTypeName.Equals(cbMarathonName.Text) && x.Event.EventName.Equals(ar.First().EventName) && (year - x.Registration.Runner.DateOfBirth.Value.Year >= int.Parse(awal)) && (year - x.Registration.Runner.DateOfBirth.Value.Year < int.Parse(akhir))).Select(x => x.Registration.Runner.RunnerId).Count();
                        }

                        xlWorkSheet.get_Range("A" + b, alpha + b.ToString()).BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, (Excel.XlColorIndex)1, ColorTranslator.ToOle(Color.Black), Type.Missing);
                        j++;
                        alpha++;
                        yearMarathon++;
                    }
                }
                b++;
                j = 2;
                yearMarathon = 2011;
            }

            Excel.Range chartRange;
            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = xlCharts.Add(10, 180, 330, 210);
            Excel.Chart chartPage = myChart.Chart;

            chartPage.HasTitle = true;
            chartPage.ChartTitle.Text = "Runner in " + cbMarathonName.Text;

            alpha--;
            b--;

            chartRange = xlWorkSheet.get_Range("A3", alpha + b.ToString());
            chartPage.SetSourceData(chartRange, Excel.XlRowCol.xlRows);

            if (comboBox4.SelectedIndex == 0)
            {
                chartPage.ChartType = Excel.XlChartType.xlColumnClustered;
            }
            else
            {
                chartPage.ChartType = Excel.XlChartType.xlLine;
            }

            chartPage.ApplyDataLabels(Excel.XlDataLabelsType.xlDataLabelsShowValue, false, true, true, false, false, true, false, true, true);

            string path = Application.StartupPath + "\\Runner Report.xls";

            xlWorkBook.SaveAs(path);
            xlWorkBook.Close(true);
            xlApp.Quit();

            Process.Start(Application.StartupPath + "\\Runner Report.xls");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            button4.Enabled = true;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemChanged();
        }

        private void itemChanged()
        {
            if (listBox2.SelectedItems.Count == 0)
            {
                return;
            }

            var events = new List<Event>();

            if (listBox1.Items.Count > 0)
            {
                events = db.Events.Where(x => x.EventType.EventTypeName.Equals(cbMarathonName.Text)).ToList();
            }
            else
            {
                events = db.Events.ToList();
            }

            selectedEvent = events;
        }

        private void getEvents()
        {
            itemChanged();

            string chart;

            tt = new Title();
            tt.Name = "ChartArea1";

            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

            chart1.Series.Clear();

            if (listBox1.Items.Count > 0)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    chart = listBox1.Items[i].ToString();
                    if (listBox1.Items[i].ToString().Contains("Under"))
                    {
                        string a = chart.Split(' ')[1];
                        chart1.Series.Add("Under " + a);
                    }
                    else if (listBox1.Items[i].ToString().Contains("Over"))
                    {
                        string a = chart.Split(' ')[1];
                        chart1.Series.Add("Over " + a);
                    }
                    else
                    {
                        string awal = chart.Split('t', 'o')[0];
                        string akhir = chart.Split('t', 'o')[2];
                        chart1.Series.Add(awal + " to " + akhir);
                    }

                    for (var j = 0; j < listBox2.SelectedItems.Count; j++)
                    {
                        var yearss = marathonYears[listBox2.SelectedIndices[j]];
                        var b = selectedEvent.Where(x => x.Marathon.YearHeld == yearss).ToList();

                        chart = listBox1.Items[i].ToString();
                        if (b.Count() > 0)
                        {
                            if (listBox1.Items[i].ToString().Contains("Under"))
                            {
                                string a = chart.Split(' ')[1];
                                chart1.Series["Under " + a].Points.AddXY(b.First().Marathon.YearHeld + "", (int)db.RegistrationEvents.Where(x => x.Event.EventType.EventTypeName.Equals(cbMarathonName.Text) && x.Event.EventName.Equals(b.First().EventName) && (year - x.Registration.Runner.DateOfBirth.Value.Year < int.Parse(a))).Select(x => x.Registration.Runner.RunnerId).Count());
                                chart1.Series["Under " + a].IsValueShownAsLabel = true;
                            }
                            else if (listBox1.Items[i].ToString().Contains("Over"))
                            {
                                string a = chart.Split(' ')[1];
                                chart1.Series["Over " + a].Points.AddXY(b.First().Marathon.YearHeld + "", (int)db.RegistrationEvents.Where(x => x.Event.EventType.EventTypeName.Equals(cbMarathonName.Text) && x.Event.EventName.Equals(b.First().EventName) && (year - x.Registration.Runner.DateOfBirth.Value.Year > int.Parse(a))).Select(x => x.Registration.Runner.RunnerId).Count());
                                chart1.Series["Over " + a].IsValueShownAsLabel = true;
                            }
                            else
                            {
                                string awal = chart.Split('t', 'o')[0];
                                string akhir = chart.Split('t', 'o')[2];
                                chart1.Series[awal + " to " + akhir].Points.AddXY(b.First().Marathon.YearHeld + "", (int)db.RegistrationEvents.Where(x => x.Event.EventType.EventTypeName.Equals(cbMarathonName.Text) && x.Event.EventName.Equals(b.First().EventName) && (year - x.Registration.Runner.DateOfBirth.Value.Year >= int.Parse(awal)) && (year - x.Registration.Runner.DateOfBirth.Value.Year < int.Parse(akhir))).Select(x => x.Registration.Runner.RunnerId).Count());
                                chart1.Series[awal + " to " + akhir].IsValueShownAsLabel = true;
                            }
                        }
                    }
                }

                chart1.Titles.Clear();
                chart1.Titles.Add(tt);
                chart1.Titles[tt.Name].Text = "Runners in " + cbMarathonName.Text;
                chart1.Titles[tt.Name].DockedToChartArea = tt.Name;
                chart1.Titles[tt.Name].IsDockedInsideChartArea = false;
            }
            else
            {
                MessageBox.Show("Please select the criteria!");
            }
        }

        private void add3_Load(object sender, EventArgs e)
        {
        }
    }
}
