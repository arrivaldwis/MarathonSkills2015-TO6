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
    public partial class sponsorshipConfirmation : UserControl
    {
        ICallback parent;

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public sponsorshipConfirmation(string runner, string charity, string amount)
        {
            InitializeComponent();
            label4.Text = runner;
            label2.Text = charity;
            label6.Text = amount;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            parent.aksi("BACKSPONSORCONFIRM","","","");
        }
    }
}
