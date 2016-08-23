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
        DataClasses1DataContext data = new DataClasses1DataContext();
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

        private void getData()
        {
            btnEdit.Name = "btnEdit";
            btnEdit.Text = "Edit";
            btnEdit.HeaderText = "Edit";
            btnEdit.UseColumnTextForButtonValue = true;

            status = data.RegistrationStatus.ToList();
            events = data.Events.Where(x => x.MarathonId == 5).ToList();

            cbStatus.Items.Add("All");
            foreach (var a in status)
            {
                cbStatus.Items.Add(a.RegistrationStatus1);
            }

            foreach (var a in events)
            {
                cbRaceEvent.Items.Add(a.EventName);
            }

            cbRaceEvent.SelectedIndex = 0;
            cbSort.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;

            refreshData();
            dataGridView1.Columns.Insert(4, btnEdit);
        }

        private void refreshData()
        {
            var selectedEvent = events[cbRaceEvent.SelectedIndex];
            runners = data.Registrations.Where(x => x.RegistrationEvents.Select(y => y.EventId).Contains(selectedEvent.EventId) &&
                                x.RegistrationEvents.Where(z => z.Event.EventName.Equals(cbRaceEvent.Text)).Count() > 0 &&
                                x.RegistrationEvents.Where(z => z.Event.Marathon.MarathonName.Equals("Marathon Skills 2015")).Count() > 0).ToList();

            var users = data.Registrations.Where(
                            x => x.RegistrationEvents.Select(y => y.EventId).Contains(selectedEvent.EventId) &&
                                x.RegistrationEvents.Where(z => z.Event.EventName.Equals(cbRaceEvent.Text)).Count() > 0 &&
                                x.RegistrationEvents.Where(z => z.Event.Marathon.MarathonName.Equals("Marathon Skills 2015")).Count() > 0).Select(
                            x => new
                            {
                                FirstName = x.Runner.User.FirstName,
                                LastName = x.Runner.User.LastName,
                                Email = x.Runner.User.Email,
                                Status = x.RegistrationStatus.RegistrationStatus1
                            });

            if (cbStatus.SelectedIndex > 0)
            {
                var selectedStatus = status[cbStatus.SelectedIndex - 1];
                runners = runners.Where(x => x.RegistrationStatusId == selectedStatus.RegistrationStatusId).ToList();
            }

            if (cbStatus.SelectedIndex > 0)
            {
                var user = users.Where(x => x.Status.Equals(cbStatus.Text));

                if (user.Count() <= 0)
                {
                    MessageBox.Show("Sorry, no runners data found");
                }

                if (cbSort.SelectedIndex == 0)
                {
                    dataGridView1.DataSource = user.OrderBy(x => x.FirstName);
                    runners = runners.OrderBy(x => x.Runner.User.FirstName).ToList();
                }
                else if (cbSort.SelectedIndex == 1)
                {
                    dataGridView1.DataSource = user.OrderBy(x => x.LastName);
                    runners = runners.OrderBy(x => x.Runner.User.LastName).ToList();
                }
                else if (cbSort.SelectedIndex == 2)
                {
                    dataGridView1.DataSource = user.OrderBy(x => x.Email);
                    runners = runners.OrderBy(x => x.Runner.User.Email).ToList();
                }
                else if (cbSort.SelectedIndex == 3)
                {
                    dataGridView1.DataSource = user.OrderBy(x => x.Status);
                    runners = runners.OrderBy(x => x.RegistrationStatus.RegistrationStatus1).ToList();
                }

                lblTotRunner.Text = user.Count().ToString();
            }
            else
            {
                var user = users;

                if (user.Count() <= 0)
                {
                    MessageBox.Show("Sorry, no runners data found");
                }

                if (cbSort.SelectedIndex == 0)
                {
                    dataGridView1.DataSource = user.OrderBy(x => x.FirstName);
                    runners = runners.OrderBy(x => x.Runner.User.FirstName).ToList();
                }
                else if (cbSort.SelectedIndex == 1)
                {
                    dataGridView1.DataSource = user.OrderBy(x => x.LastName);
                    runners = runners.OrderBy(x => x.Runner.User.LastName).ToList();
                }
                else if (cbSort.SelectedIndex == 2)
                {
                    dataGridView1.DataSource = user.OrderBy(x => x.Email);
                    runners = runners.OrderBy(x => x.Runner.User.Email).ToList();
                }
                else if (cbSort.SelectedIndex == 3)
                {
                    dataGridView1.DataSource = user.OrderBy(x => x.Status);
                    runners = runners.OrderBy(x => x.RegistrationStatus.RegistrationStatus1).ToList();
                }

                lblTotRunner.Text = user.Count().ToString();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog()
            {
                Title = "Save CSV File",
                Filter = "CSV File | *.csv"
            };

            if (saveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string fileName = saveDialog.FileName;
            var csv = "First Name, Last Name, Email, Gender, Country, Date of Birth, Registration Status, Race Events\n";

            foreach (var a in runners)
            {
                var events = "\"";
                foreach (var b in a.RegistrationEvents)
                {
                    events += b.Event.EventName + ",";
                }

                events += "\"";

                csv += string.Format("{0},{1},{2},{3},{4},{5},{6},{7}\n",
                    a.Runner.User.FirstName,
                    a.Runner.User.LastName,
                    a.Runner.User.Email,
                    a.Runner.Gender1.Gender1,
                    a.Runner.Country.CountryName,
                    a.Runner.DateOfBirth.Value.ToShortDateString(),
                    a.RegistrationStatus.RegistrationStatus1,
                    events
                );
            }

            var fileStream = new StreamWriter(fileName);
            fileStream.Write(csv);
            fileStream.Close();

            MessageBox.Show("CSV saved! Location: " + fileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                textBox1.Text += "\"" + dataGridView1[1, i].Value.ToString() + " " + dataGridView1[2, i].Value.ToString() + "\" <" + dataGridView1[3, i].Value.ToString() + ">; ";
            }

            panel1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
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
