using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MarathonSkills2015_TO6.User_Control
{
    public partial class runnerManagement : UserControl
    {
        ICallback parent;
        DataClasses1DataContext db = new DataClasses1DataContext();
        DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
        List<Registration> runners = new List<Registration>();
        List<RegistrationStatus> status;
        List<Event> events;

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public runnerManagement()
        {
            InitializeComponent();
            getData();
        }

        public void getData()
        {
            btnEdit.Text = "Edit";
            btnEdit.Name = "btnEdit";
            btnEdit.HeaderText = "Edit";
            btnEdit.UseColumnTextForButtonValue = true;

            status = db.RegistrationStatus.ToList();
            events = db.Events.Where(x => x.MarathonId == 5).ToList();

            comboBox1.Items.Add("All");
            foreach (var a in status)
            {
                comboBox1.Items.Add(a.RegistrationStatus1);
            }

            foreach (var a in events)
            {
                comboBox2.Items.Add(a.EventName);
            }

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;

            searchData();
            dataGridView1.Columns.Insert(4, btnEdit);
        }

        public void searchData()
        {
            var selectedEvent = events[comboBox2.SelectedIndex];
            runners = db.Registrations.Where(x => x.RegistrationEvents.Select(y => y.EventId).Contains(selectedEvent.EventId) &&
                                x.RegistrationEvents.Where(z => z.Event.EventName.Equals(comboBox2.Text)).Count() > 0 &&
                                x.RegistrationEvents.Where(z => z.Event.Marathon.MarathonName.Equals("Marathon Skills 2015")).Count() > 0).ToList();

            var users = db.Registrations.Where(
                            x => x.RegistrationEvents.Select(y => y.EventId).Contains(selectedEvent.EventId) &&
                                x.RegistrationEvents.Where(z => z.Event.EventName.Equals(comboBox2.Text)).Count() > 0 &&
                                x.RegistrationEvents.Where(z => z.Event.Marathon.MarathonName.Equals("Marathon Skills 2015")).Count() > 0).Select(
                            x => new
                            {
                                FirstName = x.Runner.User.FirstName,
                                LastName = x.Runner.User.LastName,
                                Email = x.Runner.User.Email,
                                Status = x.RegistrationStatus.RegistrationStatus1
                            });

            if (comboBox1.SelectedIndex > 0)
            {
                var selectedStatus = status[comboBox1.SelectedIndex - 1];
                runners = runners.Where(x => x.RegistrationStatusId == selectedStatus.RegistrationStatusId).ToList();
            }

            if (comboBox1.SelectedIndex > 0)
            {
                var user = users.Where(x => x.Status.Equals(comboBox1.Text));

                if (user.Count() <= 0)
                {
                    MessageBox.Show("Sorry, no runners data found");
                }

                if (comboBox3.SelectedIndex == 0)
                {
                    dataGridView1.DataSource = user.OrderBy(x => x.FirstName);
                    runners = runners.OrderBy(x => x.Runner.User.FirstName).ToList();
                }
                else if (comboBox3.SelectedIndex == 1)
                {
                    dataGridView1.DataSource = user.OrderBy(x => x.LastName);
                    runners = runners.OrderBy(x => x.Runner.User.LastName).ToList();
                }
                else if (comboBox3.SelectedIndex == 2)
                {
                    dataGridView1.DataSource = user.OrderBy(x => x.Email);
                    runners = runners.OrderBy(x => x.Runner.User.Email).ToList();
                }
                else if (comboBox3.SelectedIndex == 3)
                {
                    dataGridView1.DataSource = user.OrderBy(x => x.Status);
                    runners = runners.OrderBy(x => x.RegistrationStatus.RegistrationStatus1).ToList();
                }

                label9.Text = user.Count().ToString();
            }
            else
            {
                var user = users;

                if (user.Count() <= 0)
                {
                    MessageBox.Show("Sorry, no runners data found");
                }

                if (comboBox3.SelectedIndex == 0)
                {
                    dataGridView1.DataSource = user.OrderBy(x => x.FirstName);
                    runners = runners.OrderBy(x => x.Runner.User.FirstName).ToList();
                }
                else if (comboBox3.SelectedIndex == 1)
                {
                    dataGridView1.DataSource = user.OrderBy(x => x.LastName);
                    runners = runners.OrderBy(x => x.Runner.User.LastName).ToList();
                }
                else if (comboBox3.SelectedIndex == 2)
                {
                    dataGridView1.DataSource = user.OrderBy(x => x.Email);
                    runners = runners.OrderBy(x => x.Runner.User.Email).ToList();
                }
                else if (comboBox3.SelectedIndex == 3)
                {
                    dataGridView1.DataSource = user.OrderBy(x => x.Status);
                    runners = runners.OrderBy(x => x.RegistrationStatus.RegistrationStatus1).ToList();
                }

                label9.Text = user.Count().ToString();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            searchData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                textBox1.Text += "\"" + dataGridView1[1, i].Value.ToString() + " " + dataGridView1[2, i].Value.ToString() + "\" <" + dataGridView1[3, i].Value.ToString() + ">; ";
            }

            panel2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog()
            {
                Title = "Save CSV File",
                Filter = "CSV File | *.csv"
            };

            if(saveDialog.ShowDialog() != DialogResult.OK) {
                return;
            }

            string filename = saveDialog.FileName;

            var csv = "First Name, Last Name, Emai, Gender, Country, Date of Birth, Registration Status, Race Events\n";

            foreach(var a in runners) {

                var events = "\"";

                foreach(var b in a.RegistrationEvents) {
                    events += b.Event.EventName+",";
                }

                events += "\"";

                csv += String.Format("{0},{1},{2},{3},{4},{5},{6},{7}\n",
                    a.Runner.User.FirstName,
                    a.Runner.User.LastName,
                    a.Runner.User.Email,
                    a.Runner.Gender,
                    a.Runner.Country.CountryName,
                    a.Runner.DateOfBirth.Value.ToShortDateString(),
                    a.RegistrationStatus.RegistrationStatus1,
                    events);
            }

            var fileStream = new StreamWriter(filename);
            fileStream.Write(csv);
            fileStream.Close();

            MessageBox.Show("CSV Saved! Location: "+filename);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                string runner = runners[e.RowIndex].RegistrationId.ToString();
                parent.aksi("MANAGERUNNER", runner, "", "");
            }
        }
    }
}
