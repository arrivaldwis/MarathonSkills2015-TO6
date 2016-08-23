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
    public partial class findOutMore : UserControl
    {
        ICallback parent;

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public findOutMore()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parent.aksi("LISTOFCHARITIES", "", "", "");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            parent.aksi("ABOUTMARATHONSKILLS", "", "", "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parent.aksi("HOWLONGMARATHON", "", "", "");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            parent.aksi("PREVIOUSRACERESULT", "", "", "");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            add a = new add();
            a.ShowDialog();
        }

        private void findOutMore_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            parent.aksi("BMICALCULATOR", "", "", "");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            parent.aksi("BMRCALCULATOR", "", "", "");
        }
    }
}
