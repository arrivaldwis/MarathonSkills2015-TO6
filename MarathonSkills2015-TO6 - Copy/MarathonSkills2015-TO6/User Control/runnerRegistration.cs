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
        DataClasses1DataContext db = new DataClasses1DataContext();

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public runnerRegistration()
        {
            InitializeComponent();
            getData();
        }

        public void getData()
        {
            foreach (var a in db.Genders)
            {
                comboBox1.Items.Add(a.Gender1);
            }

            foreach (var a in db.Countries)
            {
                comboBox2.Items.Add(a.CountryName);
            }

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        public void insertData()
        {
            User r = new User();
            r.Email = textBox1.Text;
            r.Password = textBox2.Text;
            r.RoleId = 'R';
            r.FirstName = textBox4.Text;
            r.LastName = textBox5.Text;

            try
            {
                db.Users.InsertOnSubmit(r);
                db.SubmitChanges();

                Runner ra = new Runner();
                ra.Email = textBox1.Text;
                ra.Gender = comboBox1.Text;
                ra.DateOfBirth = dateTimePicker1.Value;
                ra.CountryCode = db.Countries.Where(x => x.CountryName.Equals(comboBox2.Text)).Select(x => x.CountryCode).FirstOrDefault();

                try
                {
                    db.Runners.InsertOnSubmit(ra);
                    db.SubmitChanges();
                    MessageBox.Show("success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "" || textBox5.Text != "")
            {
                try
                {
                    string email = new MailAddress(textBox1.Text).Address;
                    if (email.IndexOfAny(".".ToCharArray()) != -1)
                    {
                        if (!email.Contains("..") || !email.Contains("@.") || !email.Contains(".@") || !email.Contains("._."))
                        {
                            if (!email.EndsWith("."))
                            {
                                if (textBox2.Text.Length >= 6 && textBox2.Text.Any(x => char.IsDigit(x)) && textBox2.Text.Any(x => char.IsUpper(x)) && textBox2.Text.IndexOfAny("!@#$%^*_".ToCharArray()) != -1)
                                {
                                    if (textBox2.Text == textBox3.Text)
                                    {
                                        double calc = (DateTime.Now - dateTimePicker1.Value).TotalDays;

                                        if (Math.Round(calc / 365) >= 10)
                                        {
                                            insertData();
                                        }
                                        else
                                        {
                                            MessageBox.Show("At least 10 years old");
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please complete the form!");
            }
        }
    }
}
