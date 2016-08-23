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
    public partial class addUser : UserControl
    {
        ICallback parent;
        DataClasses1DataContext data = new DataClasses1DataContext();

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public addUser()
        {
            InitializeComponent();
            getData();
        }

        private void getData()
        {
            foreach (var a in data.Roles)
            {
                cbRole.Items.Add(a.RoleName);
            }

            cbRole.SelectedIndex = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || txtFirstname.Text == "" || txtLastname.Text == "")
            {
                MessageBox.Show("Please complete the form!");
            }
            else
            {
                try
                {
                    string email = new MailAddress(txtEmail.Text).Address;
                    if (email.IndexOfAny(".".ToCharArray()) != -1)
                    {
                        if (!email.Contains("..") || email.Contains(".@") ||
                            email.Contains("@.") || email.Contains("._."))
                        {
                            if (!email.EndsWith("."))
                            {
                                if (txtPassword.Text != "" && txtPasswordAgain.Text != "")
                                {
                                    if (txtPassword.Text.Length > 5 && txtPassword.Text.Any(c => char.IsUpper(c)) && txtPassword.Text.Any(c => char.IsDigit(c)) && txtPassword.Text.IndexOfAny("!@#$%^*".ToCharArray()) != -1)
                                    {
                                        if (txtPassword.Text == txtPasswordAgain.Text)
                                        {
                                            User u = new User();
                                            u.Email = txtEmail.Text;
                                            u.FirstName = txtFirstname.Text;
                                            u.LastName = txtLastname.Text;
                                            u.Password = txtPassword.Text;
                                            u.RoleId = data.Roles.Where(x => x.RoleName.Equals(cbRole.Text)).Select(x => x.RoleId).First();
                                            try
                                            {
                                                data.Users.InsertOnSubmit(u);
                                                data.SubmitChanges();
                                                MessageBox.Show("Success, User registered!");
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show("Sorry, user already registered!");
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
                                    MessageBox.Show("Password can't blank!");
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
    }
}
