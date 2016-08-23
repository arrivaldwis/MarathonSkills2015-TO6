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
    public partial class checkRunner : UserControl
    {
        ICallback parent;

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public checkRunner()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parent.aksi("LOGINSCREEN", "", "", "");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            parent.aksi("RUNNERREGISTRATION", "", "", "");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            parent.aksi("LOGINSCREEN", "", "", "");
        }
    }
}
