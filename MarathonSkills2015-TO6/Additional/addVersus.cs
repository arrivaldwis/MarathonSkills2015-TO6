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
        public addVersus()
        {
            InitializeComponent();
        }

        private void cbAge1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbAge1.SelectedIndex == 0)
            {
                listBox1.DataSource = data.Countries.Select(x=>x.CountryName);
            } else if (cbAge1.SelectedIndex == 1)
            {
                listBox1.DataSource = data.Charities.Select(x=>x.CharityName);
            }
            else if (cbAge1.SelectedIndex == 2)
            {
                listBox1.DataSource = data.EventTypes.Select(x=>x.EventTypeName);
            }
            else if (cbAge1.SelectedIndex == 3)
            {
                listBox1.DataSource = data.Genders.Select(x=>x.Gender1);
            }
            else if (cbAge1.SelectedIndex == 4)
            {
                listBox1.DataSource = data.Marathons.Select(x=>x.YearHeld);
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
    }
}
