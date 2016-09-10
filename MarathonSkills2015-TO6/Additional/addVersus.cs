using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarathonSkills2015_TO6.Additional
{
    public partial class addVersus : Form
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        List<string> filter1 = new List<string>();
        List<string> filter2 = new List<string>();
        List<string> filter3 = new List<string>();
        List<short> filter3int = new List<short>();
        public addVersus()
        {
            InitializeComponent();
        }

        private void cbAge1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAge1.SelectedIndex == 0)
            {
                listBox1.DataSource = data.Countries.Select(x => x.CountryName);
            }
            else if (cbAge1.SelectedIndex == 1)
            {
                listBox1.DataSource = data.Charities.Select(x => x.CharityName);
            }
            else if (cbAge1.SelectedIndex == 2)
            {
                listBox1.DataSource = data.EventTypes.Select(x => x.EventTypeName);
            }
            else if (cbAge1.SelectedIndex == 3)
            {
                listBox1.DataSource = data.Genders.Select(x => x.Gender1);
            }
            else if (cbAge1.SelectedIndex == 4)
            {
                listBox1.DataSource = data.Marathons.Select(x => x.YearHeld);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                listBox2.DataSource = data.Countries.Select(x => x.CountryName);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                listBox2.DataSource = data.Charities.Select(x => x.CharityName);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                listBox2.DataSource = data.EventTypes.Select(x => x.EventTypeName);
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                listBox2.DataSource = data.Genders.Select(x => x.Gender1);
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                listBox2.DataSource = data.Marathons.Select(x => x.YearHeld);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                listBox3.DataSource = data.EventTypes.Select(x => x.EventTypeName);
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                listBox3.DataSource = data.Genders.Select(x => x.Gender1);
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                listBox3.DataSource = data.Marathons.Select(x => x.YearHeld);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            string filName1 = cbAge1.Text.Trim();
            string filName2 = comboBox1.Text.Trim();
            string filName3 = comboBox2.Text.Trim();

            if(cbAge1.SelectedIndex == 4)
            {
                filName1 = "Marathon";
            }

            if(comboBox1.SelectedIndex == 4)
            {
                filName2 = "Marathon";
            }

            if(comboBox2.SelectedIndex == 2)
            {
                filName3 = "Marathon";
            }

            if (listBox2.Items.Count > 0)
            {
                dataGridView1.Columns.Add(cbAge1.Text, cbAge1.Text);
                dataGridView1.Columns.Add(comboBox1.Text, comboBox1.Text);
                if (comboBox2.SelectedIndex != 2)
                {
                    for (int k = 0; k < filter3.Count; k++)
                    {
                        dataGridView1.Columns.Add(filter3[k], filter3[k]);
                    }
                }
                else
                {
                    for (int k = 0; k < filter3int.Count; k++)
                    {
                        dataGridView1.Columns.Add(filter3int[k] + "", filter3int[k] + "");
                    }
                }

                for (int i = 0; i < filter1.Count; i++)
                {
                    var row1 = filter1[i];

                    for (int j = 0; j < filter2.Count; j++)
                    {
                        DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i].Clone();
                        var row2 = filter2[j];
                        row.Cells[0].Value = filter1[i];
                        row.Cells[1].Value = filter2[j];

                        if (cbAge1.SelectedIndex == 0)
                        {
                            var getData = data.Countries.Where(x => x.CountryName.Equals(row1));

                            if (listBox2.Items.Count > 0)
                            {
                                int h = 2;
                                if (comboBox2.SelectedIndex != 2)
                                {
                                    for (int l = 0; l < filter3.Count; l++)
                                    {
                                        var countRunner = data.Runners.Where(
                                               x => x.Country.CountryName.Equals(filter1[i])
                                                    ).Count();
                                        row.Cells[h].Value = countRunner;
                                        h++;
                                    }
                                }
                                else
                                {
                                    for (int l = 0; l < filter3int.Count; l++)
                                    {
                                        var countRunner = data.Runners.Where(
                                               x => x.Country.CountryName.Equals(filter1[i])
                                                    ).Count();
                                        row.Cells[h].Value = countRunner;
                                        h++;
                                    }
                                }
                            }
                        }
                        else if (cbAge1.SelectedIndex == 1)
                        {
                            var getData = data.Charities.Where(x => x.CharityName.Equals(row1));
                        }
                        else if (cbAge1.SelectedIndex == 2)
                        {
                            var getData = data.EventTypes.Where(x => x.EventTypeName.Equals(row1));
                        }
                        else if (cbAge1.SelectedIndex == 3)
                        {
                            var getData = data.Genders.Where(x => x.Gender1.Equals(row1));
                        }
                        else if (cbAge1.SelectedIndex == 4)
                        {
                            var getData = data.Marathons.Where(x => x.YearHeld.Equals(row1));
                        }

                        dataGridView1.Rows.Add(row);
                    }
                }
            }
            else
            {
                for (int i = 0; i < filter1.Count; i++)
                {
                    if (comboBox2.SelectedIndex != 2)
                    {
                        for (int k = 0; k < filter3.Count; k++)
                        {
                            MessageBox.Show(filter1[i] + " - " + filter3[k]);
                        }
                    }
                    else
                    {
                        for (int k = 0; k < filter3int.Count; k++)
                        {
                            MessageBox.Show(filter1[i] + " - " + filter3int[k]);
                        }
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter1 = listBox1.SelectedItems.Cast<string>().ToList();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter2 = listBox2.SelectedItems.Cast<string>().ToList();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != 2)
            {
                filter3 = listBox3.SelectedItems.Cast<string>().ToList();
            }
            else
            {
                filter3int = listBox3.SelectedItems.Cast<short>().ToList();
            }
        }
    }
}
