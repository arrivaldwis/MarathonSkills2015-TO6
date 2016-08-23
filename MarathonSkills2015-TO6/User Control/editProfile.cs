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
    public partial class editProfile : UserControl
    {
        ICallback parent;
        DataClasses1DataContext db = new DataClasses1DataContext();
        string runnerId;
        string menu;

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public editProfile(string runnerId, string menu)
        {
            InitializeComponent();
            this.runnerId = runnerId;
            this.menu = menu;
            getData();
        }

        public editProfile()
        {
            InitializeComponent();
        }

        private void getData()
        {
            foreach (var a in db.Genders)
            {
                cbGender.Items.Add(a.Gender1);
            }

            foreach (var a in db.Countries)
            {
                cbCountry.Items.Add(a.CountryName);
            }

            cbGender.SelectedIndex = 0;
            cbCountry.SelectedIndex = 0;

            var getRunner = db.Runners.Where(x => x.RunnerId.Equals(this.runnerId)).First();

            lblEmail.Text = getRunner.Email;
            txtFirstname.Text = getRunner.User.FirstName;
            txtLastname.Text = getRunner.User.LastName;
            cbGender.Text = getRunner.Gender;
            dtDOB.Value = getRunner.DateOfBirth.Value;
            cbCountry.Text = db.Countries.Where(x => x.CountryCode.Equals(getRunner.CountryCode)).Select(x => x.CountryName).First();

            if (this.menu == "1")
            {
                var reg = db.RegistrationStatus;

                foreach (var a in reg)
                {
                    cbRegStatus.Items.Add(a.RegistrationStatus1);
                }

                label11.Visible = true;
                cbRegStatus.Visible = true;

                cbRegStatus.Text = db.RegistrationStatus.Where(x => x.RegistrationStatusId.Equals(db.Registrations.Where(a => a.RunnerId.Equals(getRunner.RunnerId)).Select(b => b.RegistrationStatusId).First())).Select(x => x.RegistrationStatus1).First();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lblEmail.Text == "" || txtFirstname.Text == "" || txtLastname.Text == "")
            {
                MessageBox.Show("Please complete the form!");
            }
            else
            {
                try
                {
                    string email = new MailAddress(lblEmail.Text).Address;
                    if (email.IndexOfAny(".".ToCharArray()) != -1)
                    {
                        if (!email.Contains("..") || email.Contains(".@") || email.Contains("@.") || email.Contains("._."))
                        {
                            if (!email.EndsWith("."))
                            {
                                if (txtPassword.Text != "" && txtPasswordAgain.Text != "")
                                {
                                    if (txtPassword.Text.Length > 5 && txtPassword.Text.Any(c => char.IsUpper(c)) && txtPassword.Text.Any(c => char.IsDigit(c)) && txtPassword.Text.IndexOfAny("!@#$%^*".ToCharArray()) != -1)
                                    {
                                        if (txtPassword.Text == txtPasswordAgain.Text)
                                        {
                                            double calc = (DateTime.Now - DateTime.Parse(dtDOB.Value.ToString())).TotalDays;

                                            if (Math.Round(calc / 365) >= 10)
                                            {
                                                var u = db.Users.Where(x => x.Email.Equals(lblEmail.Text)).First();
                                                u.FirstName = txtFirstname.Text;
                                                u.LastName = txtLastname.Text;
                                                u.Password = txtPassword.Text;
                                                u.RoleId = 'R';
                                                db.SubmitChanges();

                                                var r = db.Runners.Where(x => x.Email.Equals(lblEmail.Text)).First();
                                                r.Gender = cbGender.Text;
                                                r.DateOfBirth = dtDOB.Value;
                                                r.CountryCode = db.Countries.Where(x => x.CountryName.Equals(cbCountry.Text)).Select(x => x.CountryCode).First().ToString();
                                                db.SubmitChanges();

                                                if (this.menu == "1")
                                                {
                                                    var ra = db.Registrations.Where(x => x.RegistrationId.Equals(db.Registrations.Where(a => a.RunnerId.Equals(db.Runners.Where(b => b.Email.Equals(lblEmail.Text)).Select(c => c.RunnerId).First())).Select(d => d.RegistrationId).First())).First();
                                                    ra.RegistrationStatusId = db.RegistrationStatus.Where(x => x.RegistrationStatus1.Equals(cbRegStatus.Text)).Select(x => x.RegistrationStatusId).First();
                                                    db.SubmitChanges();
                                                }

                                                MessageBox.Show("Runner Registration updated!");
                                            }
                                            else
                                            {
                                                MessageBox.Show("at least 10 years!");
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
                                    double calc = (DateTime.Now - DateTime.Parse(dtDOB.Value.ToString())).TotalDays;

                                    if (Math.Round(calc / 365) >= 10)
                                    {
                                        var u = db.Users.Where(x => x.Email.Equals(lblEmail.Text)).First();
                                        u.FirstName = txtFirstname.Text;
                                        u.LastName = txtLastname.Text;
                                        u.RoleId = 'R';
                                        db.SubmitChanges();

                                        var r = db.Runners.Where(x => x.Email.Equals(lblEmail.Text)).First();
                                        r.Gender = cbGender.Text;
                                        r.DateOfBirth = dtDOB.Value;
                                        r.CountryCode = db.Countries.Where(x => x.CountryName.Equals(cbCountry.Text)).Select(x => x.CountryCode).First().ToString();
                                        db.SubmitChanges();

                                        if (this.menu == "1")
                                        {
                                            var ra = db.Registrations.Where(x => x.RegistrationId.Equals(db.Registrations.Where(a => a.RunnerId.Equals(db.Runners.Where(b => b.Email.Equals(lblEmail.Text)).Select(c => c.RunnerId).First())).Select(d => d.RegistrationId).First())).First();
                                            ra.RegistrationStatusId = db.RegistrationStatus.Where(x => x.RegistrationStatus1.Equals(cbRegStatus.Text)).Select(x => x.RegistrationStatusId).First();
                                            db.SubmitChanges();
                                        }

                                        MessageBox.Show("Runner Registration updated!");
                                    }
                                    else
                                    {
                                        MessageBox.Show("at least 10 years!");
                                    }
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
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
