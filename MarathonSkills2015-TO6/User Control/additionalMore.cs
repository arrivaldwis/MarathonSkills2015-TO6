using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarathonSkills2015_TO6.Additional;

namespace MarathonSkills2015_TO6.User_Control
{
    public partial class additionalMore : UserControl
    {
        ICallback parent;

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public additionalMore()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            addRunnersReport a = new addRunnersReport();
            a.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addRunnerSpeed a = new addRunnerSpeed();
            a.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addTop5Runner a = new addTop5Runner();
            a.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            addEmployeeReport a = new addEmployeeReport();
            a.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addRunnerDetailInformation a = new addRunnerDetailInformation();
            a.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
