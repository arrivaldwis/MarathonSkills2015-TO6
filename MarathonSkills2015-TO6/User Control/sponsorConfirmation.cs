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
    public partial class sponsorConfirmation : UserControl
    {
        ICallback parent;

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public sponsorConfirmation(string detail, string amount, string charity)
        {
            InitializeComponent();
            label2.Text = detail;
            lblTotAmount.Text = amount;
            lblCharity.Text = charity;
        }

        public sponsorConfirmation()
        {
            InitializeComponent();
        }

        private void sponsorConfirmation_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            parent.aksi("BACKSPONSORCONFIRM", "", "", "");
        }
    }
}
