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
        DataClasses1DataContext db = new DataClasses1DataContext();

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public loginScreen()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox2.Text != "")
            {
                panel2.Visible = true;
            }
            else
            {
                MessageBox.Show("Please complete the form!");
            }
        }

        public void login(string role)
        {
            var user = db.Users.Where(x => x.Email.Equals(textBox1.Text) && x.Password.Equals(textBox2.Text) && x.RoleId.Equals(role)).FirstOrDefault();
            if (user != null)
            {
                parent.aksi("LOGINMENU", user.Email, role, "");
            }
            else
            {
                MessageBox.Show("Email/Password wrong!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login("R");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login("C");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            login("A");
        }
    }
}
