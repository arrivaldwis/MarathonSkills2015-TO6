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
    public partial class registerEventConfirmation : UserControl
    {
        ICallback parent;
        string email, role;

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public registerEventConfirmation(string email, string role)
        {
            InitializeComponent();
            this.email = email;
            this.role = role;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            parent.aksi("LOGINMENU", this.email, this.role, "");
        }
    }
}
