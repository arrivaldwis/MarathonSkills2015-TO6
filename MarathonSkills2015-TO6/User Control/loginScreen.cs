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
    public partial class loginScreen : UserControl
    {
        ICallback parent;
        DataClasses1DataContext data = new DataClasses1DataContext();

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public loginScreen()
        {
            InitializeComponent();
        }

        private void login(char role)
        {
            var login = data.Users.Where(x => x.Email.Equals(txtEmail.Text) && x.Password.Equals(txtPassword.Text) && x.RoleId.Equals(role)).FirstOrDefault();
            if (login != null)
            {
                parent.aksi("LOGINMENU", txtEmail.Text, role.ToString(), "");
            }
            else
            {
                MessageBox.Show("Email/Password wrong!");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "" && txtPassword.Text != "")
            {
                panel1.Visible = true;
            }
            else
            {
                MessageBox.Show("Please complete the form!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            login('R');
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login('C');
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login('A');
        }
    }
}
