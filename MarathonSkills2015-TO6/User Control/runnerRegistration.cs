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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry, this runner already registered!");
            }

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

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "" || txtFirstname.Text != "" || txtLastname.Text != "" || txtPassword.Text != "" || txtPasswordAgain.Text != "")
            {
                try
                {
                    string email = new MailAddress(txtEmail.Text).Address;
                    if (email.IndexOfAny(".".ToCharArray()) != -1)
                    {
                        if (!email.Contains("..") || email.Contains(".@") || email.Contains("@.") || email.Contains("._."))
                        {
                            if (!email.EndsWith("."))
                            {
                                if (txtPassword.Text.Length >= 5 && txtPassword.Text.Any(x => char.IsDigit(x)) && txtPassword.Text.Any(x => char.IsUpper(x) && txtPassword.Text.IndexOfAny("!@#$%^".ToCharArray()) != -1))
                                {
                                    if (txtPassword.Text == txtPasswordAgain.Text)
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
                                        MessageBox.Show("Password not match!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Password not meet requirement!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Email not valid!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Email not valid!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email not valid!");
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Email not valid!");
                }
            }
            else
            {
                MessageBox.Show("Please complete the form!");
            }
        }
    }
}
