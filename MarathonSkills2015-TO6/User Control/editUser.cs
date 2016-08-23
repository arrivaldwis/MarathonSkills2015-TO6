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
    public partial class editUser : UserControl
    {
        ICallback parent;
        DataClasses1DataContext data = new DataClasses1DataContext();
        string email;

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public editUser()
        {
            InitializeComponent();
        }

        public editUser(string email)
        {
            InitializeComponent();
            this.email = email;
            getData();
        }

        private void getData()
        {
            var roles = data.Roles;
            foreach (var a in roles)
            {
                cbRole.Items.Add(a.RoleName);
            }

            cbRole.SelectedIndex = 0;

            var user = data.Users.Where(x => x.Email.Equals(this.email)).First();
            lblEmail.Text = user.Email;
            txtFirstname.Text = user.FirstName;
            txtLastname.Text = user.LastName;
            cbRole.Text = data.Roles.Where(x => x.RoleId.Equals(user.RoleId)).Select(x => x.RoleName).First().ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lblEmail.Text == "" || txtFirstname.Text == "" || txtLastname.Text == "")
            {
                MessageBox.Show("Please complete the form!");
            }
            else
            {
                if (txtPassword.Text != "" && txtPasswordAgain.Text != "")
                {
                    if (txtPassword.Text.Length > 5 && txtPassword.Text.Any(c => char.IsUpper(c)) && txtPassword.Text.Any(c => char.IsDigit(c)) && txtPassword.Text.IndexOfAny("!@#$%^_*".ToCharArray()) != -1)
                    {
                        if (txtPassword.Text == txtPasswordAgain.Text)
                        {
                            //Action Insert
                            var u = data.Users.Where(x => x.Email.Equals(this.email)).First();
                            u.FirstName = txtFirstname.Text;
                            u.LastName = txtLastname.Text;
                            u.Password = txtPassword.Text;
                            u.RoleId = data.Roles.Where(x => x.RoleName.Equals(cbRole.Text)).Select(x => x.RoleId).First();
                            data.SubmitChanges();
                            MessageBox.Show("User updated!");
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
                    //Action Insert
                    var u = data.Users.Where(x => x.Email.Equals(this.email)).First();
                    u.FirstName = txtFirstname.Text;
                    u.LastName = txtLastname.Text;
                    u.RoleId = data.Roles.Where(x => x.RoleName.Equals(cbRole.Text)).Select(x => x.RoleId).First();
                    data.SubmitChanges();

                    MessageBox.Show("User updated!");
                }
            }
        }
    }
}
