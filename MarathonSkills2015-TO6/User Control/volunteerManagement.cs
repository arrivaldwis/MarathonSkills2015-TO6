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
    public partial class volunteerManagement : UserControl
    {
        ICallback parent;
        DataClasses1DataContext data = new DataClasses1DataContext();

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public volunteerManagement()
        {
            InitializeComponent();
            getData();
        }

        private void getData()
        {
            cbSort.SelectedIndex = 0;
            refreshData();
        }

        private void refreshData()
        {
            var volunteer = data.Volunteers.Select(x => new
            {
                x.FirstName,
                x.LastName,
                x.Country.CountryName,
                x.Gender
            });

            if (cbSort.SelectedIndex == 0)
            {
                dataGridView1.DataSource = volunteer.OrderBy(x => x.FirstName);
            }
            else if (cbSort.SelectedIndex == 1)
            {
                dataGridView1.DataSource = volunteer.OrderBy(x => x.LastName);
            }
            else if (cbSort.SelectedIndex == 2)
            {
                dataGridView1.DataSource = volunteer.OrderBy(x => x.CountryName);
            }
            else if (cbSort.SelectedIndex == 3)
            {
                dataGridView1.DataSource = volunteer.OrderBy(x => x.Gender);
            }

            lblVolunteers.Text = volunteer.Count().ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parent.aksi("IMPORTVOLUNTEER", "", "", "");
        }
    }
}
