using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarathonSkills2015_TO6
{
    public partial class Form1 : Form
    {
        long eventTime = DateTime.Parse("2015-09-05 06:00").Ticks;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            long now = DateTime.Now.Ticks;
            TimeSpan t = TimeSpan.FromTicks(eventTime - now);
            lblCountDown.Text = t.Days + " days " + t.Hours + " hours and " + t.Minutes + " until the race starts";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmDetail m = new frmDetail("SPONSORRUNNER", "");
            m.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmDetail m = new frmDetail("FINDOUTMORE", "");
            m.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmDetail m = new frmDetail("LOGINSCREEN", "");
            m.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDetail m = new frmDetail("CHECKRUNNER", "");
            m.ShowDialog();
        }
    }
}
