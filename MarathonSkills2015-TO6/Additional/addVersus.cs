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
    public partial class addVersus : Form
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        int rowFilter1 = 0;
        int rowFilter2 = 0;
        int coloumnFilter = 0;

        List<string> filter1 = new List<string>();
        List<string> filter2 = new List<string>();
        List<string> colFilters = new List<string>();

        List<string> filter1Data = new List<string>();
        List<string> filter2Data = new List<string>();
        List<string> colFiltersData = new List<string>();


        public addVersus()
        {
            InitializeComponent();
        }

        private void cbAge1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = cbRowFilter1.SelectedIndex;
            rowFilter1 = index;

            cbRowFilter2.SelectedIndex = 0;
            cbColFilter.SelectedIndex = 0;

            listBox1.Items.Clear();
            switch (index)
            {
                case 0:
                    filter1Data = data.Countries.OrderBy(x => x.CountryName).Select(x => x.CountryCode).ToList();
                    listBox1.Items.AddRange(data.Countries.OrderBy(x => x.CountryName).Select(x => x.CountryName).ToArray());
                    break;
                case 1:
                    filter1Data = data.Charities.OrderBy(x => x.CharityName).Select(x => x.CharityId.ToString()).ToList();
                    listBox1.Items.AddRange(data.Charities.OrderBy(x => x.CharityName).Select(x => x.CharityName).ToArray());
                    break;
                case 2:
                    filter1Data = data.EventTypes.OrderBy(x => x.EventTypeName).Select(x => x.EventTypeId.ToString()).ToList();
                    listBox1.Items.AddRange(data.EventTypes.OrderBy(x => x.EventTypeName).Select(x => x.EventTypeName).ToArray());
                    break;
                case 3:
                    filter1Data = data.Genders.OrderBy(x => x.Gender1).Select(x => x.Gender1).ToList();
                    listBox1.Items.AddRange(data.Genders.OrderBy(x => x.Gender1).Select(x => x.Gender1).ToArray());
                    break;
                case 4:
                    filter1Data = data.Marathons.OrderBy(x => x.YearHeld).Select(x => x.YearHeld.ToString()).ToList();
                    listBox1.Items.AddRange(data.Marathons.OrderBy(x => x.YearHeld).Select(x => x.YearHeld.ToString()).ToArray());
                    break;
            }

            for (var a = 0; a < (listBox1.Items.Count > 10 ? 10 : listBox1.Items.Count); a++)
            {
                listBox1.SelectedIndices.Add(a);
            }
        }

        bool isValid()
        {
            if (listBox1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Row Filter 1 must selected at least 1 fields");
                return false;
            }

            if (listBox1.SelectedItems.Count > 10)
            {
                MessageBox.Show("Maximal selected data is 10 in Row Filter 1");
                return false;
            }

            if (rowFilter2 != -1)
            {
                if (listBox2.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Row Filter 1 must selected at least 1 fields");
                    return false;
                }

                if (listBox2.SelectedItems.Count > 10)
                {
                    MessageBox.Show("Maximal selected data is 10 in Row Filter 1");
                    return false;
                }
            }

            if (listBox3.SelectedItems.Count == 0)
            {
                MessageBox.Show("Column Filter must selected at least 1 fields");
                return false;
            }

            if (listBox3.SelectedItems.Count > 10)
            {
                MessageBox.Show("Maximal selected data is 10 in Column Filter");
                return false;
            }

            return true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            rowFilter2 = -1;

            cbColFilter.SelectedIndex = 0;

            if (cbRowFilter2.SelectedIndex == 0)
                return;

            if (cbRowFilter2.SelectedIndex - 1 == cbRowFilter1.SelectedIndex)
            {
                MessageBox.Show("Can't select this filter, choose other data!");
                cbRowFilter2.SelectedIndex = 0;
                return;
            }

            var index = cbRowFilter2.SelectedIndex - 1;
            rowFilter2 = index;

            switch (index)
            {
                case 0:
                    filter2Data = data.Countries.OrderBy(x => x.CountryName).Select(x => x.CountryCode).ToList();
                    listBox2.Items.AddRange(data.Countries.OrderBy(x => x.CountryName).Select(x => x.CountryName).ToArray());
                    break;
                case 1:
                    filter2Data = data.Charities.OrderBy(x => x.CharityName).Select(x => x.CharityId.ToString()).ToList();
                    listBox2.Items.AddRange(data.Charities.OrderBy(x => x.CharityName).Select(x => x.CharityName).ToArray());
                    break;
                case 2:
                    filter2Data = data.EventTypes.OrderBy(x => x.EventTypeName).Select(x => x.EventTypeId.ToString()).ToList();
                    listBox2.Items.AddRange(data.EventTypes.OrderBy(x => x.EventTypeName).Select(x => x.EventTypeName).ToArray());
                    break;
                case 3:
                    filter2Data = data.Genders.OrderBy(x => x.Gender1).Select(x => x.Gender1).ToList();
                    listBox2.Items.AddRange(data.Genders.OrderBy(x => x.Gender1).Select(x => x.Gender1).ToArray());
                    break;
                case 4:
                    filter2Data = data.Marathons.OrderBy(x => x.YearHeld).Select(x => x.YearHeld.ToString()).ToList();
                    listBox2.Items.AddRange(data.Marathons.OrderBy(x => x.YearHeld).Select(x => x.YearHeld.ToString()).ToArray());
                    break;
            }


            for (var a = 0; a < (listBox2.Items.Count > 10 ? 10 : listBox2.Items.Count); a++)
            {
                listBox2.SelectedIndices.Add(a);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            coloumnFilter = -1;

            if (cbColFilter.SelectedIndex == 0)
                return;

            if (cbColFilter.SelectedIndex == cbRowFilter1.SelectedIndex - 1 ||
                cbColFilter.SelectedIndex == cbRowFilter2.SelectedIndex - 2)
            {
                MessageBox.Show("Can't select this filter, choose other data!");
                cbColFilter.SelectedIndex = 0;
                return;
            }

            var index = cbColFilter.SelectedIndex - 1;
            coloumnFilter = index;

            switch (index)
            {
                case 0:
                    colFiltersData = data.EventTypes.OrderBy(x => x.EventTypeName).Select(x => x.EventTypeId.ToString()).ToList();
                    listBox3.Items.AddRange(data.EventTypes.OrderBy(x => x.EventTypeName).Select(x => x.EventTypeName).ToArray());
                    break;
                case 1:
                    colFiltersData = data.Genders.OrderBy(x => x.Gender1).Select(x => x.Gender1).ToList();
                    listBox3.Items.AddRange(data.Genders.OrderBy(x => x.Gender1).Select(x => x.Gender1).ToArray());
                    break;
                case 2:
                    colFiltersData = data.Marathons.OrderBy(x => x.YearHeld).Select(x => x.YearHeld.ToString()).ToList();
                    listBox3.Items.AddRange(data.Marathons.OrderBy(x => x.YearHeld).Select(x => x.YearHeld.ToString()).ToArray());
                    break;
            }


            for (var a = 0; a < (listBox3.Items.Count > 10 ? 10 : listBox3.Items.Count); a++)
            {
                listBox3.SelectedIndices.Add(a);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!isValid())
                return;

            filter1.Clear();
            for (var i = 0; i < listBox1.SelectedIndices.Count; i++)
            {
                filter1.Add(filter1Data[listBox1.SelectedIndices[i]]);
            }

            filter2.Clear();
            for (var i = 0; i < listBox2.SelectedIndices.Count; i++)
            {
                filter2.Add(filter2Data[listBox2.SelectedIndices[i]]);
            }

            colFilters.Clear();
            for (var i = 0; i < listBox3.SelectedIndices.Count; i++)
            {
                colFilters.Add(colFiltersData[listBox3.SelectedIndices[i]]);
            }

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = getColumnName(rowFilter1) });
            if (rowFilter2 != -1)
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = getColumnName(rowFilter2) });
            }

            foreach (var item in listBox3.SelectedItems)
            {
                if (!dataGridView1.Columns.Contains(item.ToString()))
                {
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = item.ToString() });
                }
            }

            var datas = data.RegistrationEvents.Where(x => true);
            var results = new List<Result>();

            for (var i = 0; i < filter1.Count; i++)
            {
                var rowFilterIndex1 = filter1[i];
                var subData1 = filterData(datas, rowFilter1, rowFilterIndex1);

                if (rowFilter2 != -1)
                {
                    for (var j = 0; j < filter2.Count; j++)
                    {
                        var rowFilterIndex2 = filter2[j];
                        var result = new Result();
                        result.Filter1 = listBox1.SelectedItems[i].ToString();
                        result.Filter2 = listBox2.SelectedItems[j].ToString();
                        var subData2 = filterData(subData1, rowFilter2, rowFilterIndex2);


                        for (var k = 0; k < colFilters.Count; k++)
                        {
                            var coloumnFilterIndex = colFilters[k];
                            var key = listBox3.SelectedItems[k].ToString();
                            var subData3 = filterData(subData2, coloumnFilter + 2, coloumnFilterIndex);
                            result.Data.Add(key, subData3.Count());
                        }
                        results.Add(result);
                    }
                }
                else
                {
                    var result = new Result();
                    result.Filter1 = listBox1.SelectedItems[i].ToString();

                    for (var k = 0; k < colFilters.Count; k++)
                    {
                        var coloumnFilterIndex = colFilters[k];
                        var key = listBox3.SelectedItems[k].ToString();
                        var subData3 = filterData(subData1, coloumnFilter + 2, coloumnFilterIndex);
                        result.Data.Add(key, subData3.AsQueryable().Count());
                    }
                    results.Add(result);
                }
            }

            dataGridView1.Rows.Clear();
            foreach (var resultItem in results)
            {
                var row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell { Value = resultItem.Filter1 });
                if (rowFilter2 != -1)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = resultItem.Filter2 });
                }
                foreach (var key in resultItem.Data.Keys)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = resultItem.Data[key] });
                }
                dataGridView1.Rows.Add(row);
            }

            chart1.Series.Clear();
            if (cbXLabel.SelectedIndex == 0)
            {
                foreach (var resultItem in results)
                {
                    var name = "";
                    if (rowFilter2 != -1)
                    {
                        name = resultItem.Filter1 + " - " + resultItem.Filter2;
                    }
                    else
                    {
                        name = resultItem.Filter1;
                    }
                    var series = chart1.Series.Add(name);
                    series.ToolTip = "#SERIESNAME - #VALX : #VAL";
                    series.Label = "#VAL";
                    foreach (var key in resultItem.Data.Keys)
                    {
                        series.Points.AddXY(key, resultItem.Data[key]);
                    }
                }
            }
            else
            {
                foreach (var item in listBox3.SelectedItems)
                {
                    var series = chart1.Series.Add(item.ToString());
                    series.ToolTip = "#SERIESNAME - #VALX : #VAL";
                    series.Label = "#VAL";
                    foreach (var resultItem in results)
                    {
                        foreach (var key in resultItem.Data.Keys)
                        {
                            if (item.ToString() == key)
                            {
                                if (rowFilter2 != -1)
                                {
                                    series.Points.AddXY(resultItem.Filter1 + " - " + resultItem.Filter2, resultItem.Data[key]);
                                }
                                else
                                {
                                    series.Points.AddXY(resultItem.Filter1, resultItem.Data[key]);
                                }
                            }
                        }
                    }
                }
            }
        }

        string getColumnName(int index)
        {
            switch (index)
            {
                case 0:
                    return "Country";
                case 1:
                    return "Charity";
                case 2:
                    return "Event Type";
                case 3:
                    return "Gender";
                case 4:
                    return "Year";
            }

            return "";
        }

        private IQueryable<RegistrationEvent> filterData(IQueryable<RegistrationEvent> data, int filterIndex, string rowFilter)
        {
            switch (filterIndex)
            {
                case 0:
                    data = data.Where(x => x.Registration.Runner.CountryCode == rowFilter);
                    break;
                case 1:
                    var charityId = int.Parse(rowFilter);
                    data = data.Where(x => x.Registration.CharityId == charityId);
                    break;
                case 2:
                    data = data.Where(x => x.Event.EventTypeId == rowFilter);
                    break;
                case 3:
                    data = data.Where(x => x.Registration.Runner.Gender == rowFilter);
                    break;
                case 4:
                    var year = int.Parse(rowFilter);
                    data = data.Where(x => x.Event.Marathon.YearHeld == year);
                    break;
            }
            return data;
        }

        class Result
        {
            public string Filter1 { get; set; }
            public string Filter2 { get; set; }
            public Dictionary<string, int> Data { get; set; }

            public Result()
            {
                Data = new Dictionary<string, int>();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //add data 
            xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, dataGridView1.ColumnCount]].Merge();
            xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, dataGridView1.ColumnCount]] = "Versus Report";
            xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, dataGridView1.ColumnCount]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, dataGridView1.ColumnCount]].Font.Bold = "True";
            xlWorkSheet.Cells[2, 1] = "";

            xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[dataGridView1.RowCount + 2, dataGridView1.ColumnCount]].Borders.Weight = Excel.XlBorderWeight.xlThin;
            var col = 0;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                ++col;
                xlWorkSheet.Cells[2, col].Font.Bold = "True";
                xlWorkSheet.Cells[2, col] = column.HeaderText;
            }

            var row = 3;
            foreach (DataGridViewRow dgRow in dataGridView1.Rows)
            {
                col = 0;
                foreach (DataGridViewCell cell in dgRow.Cells)
                {
                    xlWorkSheet.Cells[row, ++col] = cell.Value;
                }
                row++;
            }

            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(0, (dataGridView1.RowCount + 2) * 13.3, 400, 250);
            Excel.Chart chartPage = myChart.Chart;
            myChart.Select();

            chartPage.HasTitle = true;
            chartPage.ChartTitle.Text = "Report";
            chartPage.ChartType = Excel.XlChartType.xlColumnClustered;
            Excel.SeriesCollection seriesCols = (Excel.SeriesCollection)chartPage.SeriesCollection();

            if (cbXLabel.SelectedIndex == 0)
            {
                foreach (DataGridViewRow dgRow in dataGridView1.Rows)
                {
                    Excel.Series newSeries = seriesCols.NewSeries();

                    if (rowFilter2 != -1)
                    {
                        newSeries.Name = dgRow.Cells[0].Value == null ? string.Empty : dgRow.Cells[0].Value.ToString() + " - " + dgRow.Cells[1].Value == null ? string.Empty : dgRow.Cells[1].Value.ToString();
                    }
                    else
                    {
                        newSeries.Name = dgRow.Cells[0].Value == null ? string.Empty : dgRow.Cells[0].Value.ToString();
                    }

                    List<int> values = new List<int>();
                    List<string> xValues = new List<string>();
                    for (var i = rowFilter2 != -1 ? 2 : 1; i < dgRow.Cells.Count; i++)
                    {
                        xValues.Add(dgRow.Cells[i].OwningColumn.HeaderText);
                        values.Add(int.Parse(dgRow.Cells[i].Value == null ? "0" : dgRow.Cells[i].Value.ToString()));
                    }
                    newSeries.ApplyDataLabels(Excel.XlDataLabelsType.xlDataLabelsShowValue, false, true, false, false, false, true, false);
                    newSeries.XValues = xValues.ToArray();
                    newSeries.Values = values.ToArray();

                    releaseObject(newSeries);
                }
            }
            else
            {
                foreach (var item in listBox3.SelectedItems)
                {
                    Excel.Series newSeries = seriesCols.NewSeries();
                    newSeries.Name = item.ToString();

                    List<int> values = new List<int>();
                    List<string> xValues = new List<string>();
                    foreach (DataGridViewRow dgRow in dataGridView1.Rows)
                    {
                        if (rowFilter2 != -1)
                        {
                            try
                            {
                                xValues.Add(dgRow.Cells[0].Value == null ? string.Empty : dgRow.Cells[0].Value.ToString() + " - " + dgRow.Cells[1].Value == null ? string.Empty : dgRow.Cells[1].Value.ToString());
                                values.Add(int.Parse(dgRow.Cells[2 + listBox3.SelectedItems.IndexOf(item)].Value == null ? "0" : dgRow.Cells[2 + listBox3.SelectedItems.IndexOf(item)].Value.ToString()));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            xValues.Add(dgRow.Cells[0].Value == null ? string.Empty : dgRow.Cells[0].Value.ToString());
                            values.Add(int.Parse(dgRow.Cells[1 + listBox3.SelectedItems.IndexOf(item)].Value == null ? "0" : dgRow.Cells[1 + listBox3.SelectedItems.IndexOf(item)].Value.ToString()));
                        }
                    }
                    newSeries.ApplyDataLabels(Excel.XlDataLabelsType.xlDataLabelsShowValue, false, true, false, false, false, true, false);
                    newSeries.XValues = xValues.ToArray();
                    newSeries.Values = values.ToArray();

                    releaseObject(newSeries);
                }
            }

            var ofd = new SaveFileDialog()
            {
                Title = "Save Excel File",
                Filter = "Excel File | *.xlsx"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                xlWorkBook.SaveAs(ofd.FileName, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                xlWorkBook.Close(false, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                Process.Start(new ProcessStartInfo(ofd.FileName));
            }
            else
            {
                xlWorkBook.Close(false, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void addVersus_Load(object sender, EventArgs e)
        {
            cbRowFilter1.SelectedIndex = 0;
            cbRowFilter2.SelectedIndex = 0;
            cbColFilter.SelectedIndex = 0;
            cbXLabel.SelectedIndex = 0;
        }
    }
}
