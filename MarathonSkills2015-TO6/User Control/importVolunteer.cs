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
    public partial class importVolunteer : UserControl
    {
        ICallback parent;
        DataClasses1DataContext data = new DataClasses1DataContext();

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public importVolunteer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName.Contains("csv"))
                {
                    txtFile.Text = openFileDialog1.FileName;
                }
                else
                {
                    MessageBox.Show("only csv file format!");
                    txtFile.Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtFile.Text == "")
            {
                MessageBox.Show("CSV File is required!");
                return;
            }

            if (txtFile.Text != "")
            {
                var fileStream = new StreamReader(txtFile.Text);
                bool isFirstLine = true;
                var validations = new String[] { "VolunteerId", "FirstName", "LastName", "CountryCode", "Gender" };
                while (!fileStream.EndOfStream)
                {
                    var line = fileStream.ReadLine();
                    if (isFirstLine)
                    {
                        var cols = line.Split(',');
                        for (var i = 0; i < validations.Length; i++)
                        {
                            if (cols.Length < i || validations[i] != cols[i])
                            {
                                MessageBox.Show("CSV field not meet requirements!");
                                return;
                            }
                        }

                        isFirstLine = false;
                        continue;
                    }

                    var db = line.Split(',');
                    var volunteerID = int.Parse(db[0]);
                    var volunteer = data.Volunteers.Where(x => x.VolunteerId.Equals(volunteerID)).FirstOrDefault();

                    var isExist = true;
                    if (volunteer == null)
                    {
                        isExist = false;
                    }
                    else
                    {
                        volunteer.VolunteerId = volunteerID;
                        volunteer.FirstName = db[1];
                        volunteer.LastName = db[2];
                        volunteer.CountryCode = db[3];
                        volunteer.Gender = db[4] == "M" ? "Male" : "Female";
                    }

                    if (!isExist)
                    {
                        Volunteer v = new Volunteer();
                        v.VolunteerId = volunteerID;
                        v.FirstName = db[1];
                        v.LastName = db[2];
                        v.CountryCode = db[3];
                        v.Gender = db[4] == "M" ? "Male" : "Female";
                        try
                        {
                            data.Volunteers.InsertOnSubmit(v);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    data.SubmitChanges();
                }

                MessageBox.Show("Volunteer data imported!");

            }
        }
    }
}
