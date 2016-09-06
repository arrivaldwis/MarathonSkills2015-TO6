using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace MarathonSkills2015_TO6.Additional
{
    public partial class addEmployeeReport : Form
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn();

        public addEmployeeReport()
        {
            InitializeComponent();
            getData();
        }

        private void getData()
        {
            btnDetail.Name = "btnDetail";
            btnDetail.Text = "View Detail";
            btnDetail.HeaderText = "View Detail";
            btnDetail.UseColumnTextForButtonValue = true;
        }

        private void refreshData()
        {
            var getData = data.Timesheets.Where(x => x.Staff.Position.PositionName.Equals(textBox1.Text)).Select(x => new
            {
                Year = x.StartDateTime.Value.Year,
                Position = x.Staff.Position.PositionName,
                StartDateTime = x.StartDateTime
            }).GroupBy(x => x.Year);

            if (getData.Count() > 0)
            {
                dataGridView1.DataSource = getData.Select(x => new
                {
                    Year = x.Key,
                    Male = data.Staffs.Where(
                        y => y.Gender.Equals("Male") &&
                             y.Position.PositionName.Equals(x.First().Position) &&
                             y.Timesheets.Where(z => z.StartDateTime.Value.Year.Equals(x.Key)
                        ).Count() > 0).Count().ToString(),
                    Female = data.Staffs.Where(
                        y => y.Gender.Equals("Female") &&
                             y.Position.PositionName.Equals(x.First().Position) &&
                             y.Timesheets.Where(z => z.StartDateTime.Value.Year.Equals(x.Key)
                        ).Count() > 0).Count().ToString(),
                    PaidHours = data.Timesheets.Where(
                        y => y.Staff.Position.PositionName.Equals(x.First().Position) &&
                            (y.StartDateTime.Value.Year.Equals(x.Key))
                        ).Sum(y => (y.EndDateTime.Value - y.StartDateTime.Value).Hours).ToString() + " hours",
                    PaymentAmount = String.Format("{0:C}", data.Timesheets.Where(
                        y => y.Staff.Position.PositionName.Equals(x.First().Position) &&
                            (y.StartDateTime.Value.Year.Equals(x.Key))
                        ).Sum(y => y.PayAmount).Value),
                    AgeRange = data.Staffs.Where(
                        y => y.Position.PositionName.Equals(x.First().Position)).Where(
                        z => z.Timesheets.Where(t => t.StartDateTime.Value.Year.Equals(x.Key)).Count() > 0
                        ).Select(y => (x.First().Year - y.DateOfBirth.Year)).Min() + " - " + data.Staffs.Where(
                        y => y.Position.PositionName.Equals(x.First().Position)).Where(
                        z => z.Timesheets.Where(t => t.StartDateTime.Value.Year.Equals(x.Key)).Count() > 0
                        ).Select(y => (x.First().Year - y.DateOfBirth.Year)).Max()
                });

                label2.Text = textBox1.Text;
                label2.Visible = true;

                dataGridView1.Columns.Insert(6, btnDetail);

                int a = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (a % 2 == 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Cyan;
                    }
                    a++;
                }

            }
            else
            {
                MessageBox.Show("Position Name doesn’t exists");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t != null)
            {
                if (t.Text.Length >= 3)
                {
                    string[] arr = getPositionName(t.Text);

                    AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                    collection.AddRange(arr);

                    textBox1.AutoCompleteCustomSource = collection;
                }
            }
        }

        private string[] getPositionName(string text)
        {
            var user = data.Positions.Where(x => x.PositionName.Contains(text) && x.PayPeriod.Equals("Hourly")).Select(x => x.PositionName);
            return user.ToArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            string year = dataGridView1[0, row].Value.ToString();

            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnDetail")
            {
                addDetailEmployee a = new addDetailEmployee(year, label2.Text);
                a.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                exportExcel();
            }
            else
            {
                MessageBox.Show("Please search position name first!");
            }
        }

        private void exportExcel()
        {
            int b = 4, c = 4, j = 1;
            char alpha = 'A';

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add();
            var collection = new Excel.Worksheet[data.Positions.Count()-1];

            int k = 0;
            foreach (var a in data.Positions.Where(x => x.PayPeriod.Equals("Hourly")))
            {
                collection[k] = xlWorkBook.Worksheets.Add();
                collection[k].Name = a.PositionName;

                if (a.PositionName.Equals(textBox1.Text))
                {
                    var thisWorksheet = collection[k];
                    thisWorksheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    thisWorksheet.Cells[1, 1] = "";
                    thisWorksheet.Range["A3"].Value = "";

                    for (var g = 0; g < dataGridView1.Columns.Count - 1; g++)
                    {
                        var yearss = dataGridView1.Columns[g].Name;

                        thisWorksheet.Range[alpha + "3"].Value = yearss;
                        thisWorksheet.get_Range("A3", alpha + "3").HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        thisWorksheet.get_Range("A3", alpha + "3").BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, (Excel.XlColorIndex)1, ColorTranslator.ToOle(Color.Black), Type.Missing);
                        alpha++;
                    }

                    thisWorksheet.get_Range("A1", "V2").Merge();
                    thisWorksheet.get_Range("A1", "V2").Font.Size = 20;
                    thisWorksheet.get_Range("A1", "V2").Font.Bold = true;
                    thisWorksheet.get_Range("A1", "V2").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    thisWorksheet.get_Range("A1", "V2").HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    thisWorksheet.get_Range("A1", "D1").Value = textBox1.Text;

                    thisWorksheet.get_Range("A3", "F3").Font.Bold = true;

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        alpha = 'A';
                        for (var g = 0; g < dataGridView1.Columns.Count - 1; g++)
                        {
                            thisWorksheet.Cells[b, j] = dataGridView1[g, i].Value.ToString();
                            thisWorksheet.get_Range("A" + b, alpha + b.ToString()).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            thisWorksheet.get_Range("A" + b, alpha + b.ToString()).BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, (Excel.XlColorIndex)1, ColorTranslator.ToOle(Color.Black), Type.Missing);
                            j++;
                            alpha++;
                        }
                        b++;
                        j = 1;
                    }

                    Excel.Range chartRange;
                    Excel.ChartObjects xlCharts = (Excel.ChartObjects)thisWorksheet.ChartObjects(Type.Missing);
                    Excel.ChartObject myChart = xlCharts.Add(10, 140, 330, 210);
                    Excel.Chart chartPage = myChart.Chart;

                    chartPage.HasTitle = true;
                    chartPage.ChartTitle.Text = "Payment Amount";

                    alpha--;
                    b--;

                    chartRange = thisWorksheet.get_Range("E3", "E4:E" + b.ToString());
                    chartPage.SetSourceData(thisWorksheet.get_Range("E4:E" + b.ToString()), Excel.XlRowCol.xlColumns);
                    chartPage.SeriesCollection(1).Name = "Payment Amount";
                    chartPage.SeriesCollection(1).XValues = thisWorksheet.get_Range("A4:A" + b.ToString());

                    chartPage.ChartType = Excel.XlChartType.xlLineMarkers;

                    chartPage.ApplyDataLabels(Excel.XlDataLabelsType.xlDataLabelsShowValue, false, true, true, false, false, true, false, true, true);
                }
                k++;
            }

            string path = Application.StartupPath + "\\Employee Report.xls";

            xlWorkBook.SaveAs(path);
            xlWorkBook.Close(true);
            xlApp.Quit();

            Process.Start(Application.StartupPath + "\\Employee Report.xls");
        }
    }
}
