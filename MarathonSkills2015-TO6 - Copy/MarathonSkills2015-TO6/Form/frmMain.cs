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
        long events = DateTime.Parse("2015-09-05 06:00").Ticks;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan time = TimeSpan.FromTicks(events - DateTime.Now.Ticks);
            label3.Text = time.Days+" days "+time.Hours+" hours and "+time.Minutes+" minutes until the race starts";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmDetail a = new frmDetail("SPONSORRUNNER");
            a.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmDetail a = new frmDetail("FINDOUTMORE");
            a.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmDetail a = new frmDetail("LOGINSCREEN");
            a.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDetail a = new frmDetail("CHECKRUNNER");
            a.ShowDialog();
        }
    }
}
