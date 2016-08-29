using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using MarathonSkills2015_TO6.Class;

namespace MarathonSkills2015_TO6.User_Control
{
    public partial class runnerRegistration : UserControl
    {
        ICallback parent;
        DataClasses1DataContext data = new DataClasses1DataContext();

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public runnerRegistration()
        {
            InitializeComponent();
            getData();
        }

        private void getData()
        {
            foreach (var a in data.Genders)
            {
                cbGender.Items.Add(a.Gender1);
            }

            foreach (var a in data.Countries)
            {
                cbCountry.Items.Add(a.CountryName);
            }

            cbGender.SelectedIndex = 0;
            cbCountry.SelectedIndex = 0;
        }

        private void insertData()
        {
            User u = new User();
            u.Email = txtEmail.Text;
            u.Password = txtPassword.Text;
            u.FirstName = txtFirstname.Text;
            u.LastName = txtLastname.Text;
            u.RoleId = 'R';

            try
            {
                data.Users.InsertOnSubmit(u);
                data.SubmitChanges();

                Runner r = new Runner();
                r.Email = txtEmail.Text;
                r.Gender = cbGender.Text;
                r.DateOfBirth = dtDOB.Value;
                r.CountryCode = data.Countries.Where(x => x.CountryName.Equals(cbCountry.Text)).Select(x => x.CountryCode).First();

                try
                {
                    data.Runners.InsertOnSubmit(r);
                    data.SubmitChanges();

                    string runnerId = data.Runners.Where(x => x.Email == txtEmail.Text).Select(x => x.RunnerId).First().ToString();
                    parent.aksi("REGISTEREVENT", runnerId, "R", txtEmail.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sorry, this runner already registered!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry, this runner already registered!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "" || txtFirstname.Text != "" || txtLastname.Text != "" || txtPassword.Text != "" || txtPasswordAgain.Text != "")
            {
                validation v = new validation();
                String val = v.emailPassVal(txtEmail, txtPassword, txtPasswordAgain);
                if (val == "sukses")
                {
                    double time = (DateTime.Parse("2015-09-05 06:00") - dtDOB.Value).TotalDays;

                    if (Math.Round(time / 365) >= 10)
                    {
                        insertData();
                    }
                    else
                    {
                        MessageBox.Show("Runner must at least 10 years!");
                    }
                }
                else
                {
                    MessageBox.Show(val);
                }
            }
            else
            {
                MessageBox.Show("Please complete the form!");
            }
        }
    }
}
