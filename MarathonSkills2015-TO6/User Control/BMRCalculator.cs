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
    public partial class BMRCalculator : UserControl
    {
        ICallback parent;
        string gender = "M";
        double BMR;

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public BMRCalculator()
        {
            InitializeComponent();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            gender = "M";
            panel1.BackColor = Color.Gray;
            panel2.BackColor = Color.Gainsboro;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            gender = "M";
            panel1.BackColor = Color.Gray;
            panel2.BackColor = Color.Gainsboro;
        }

        private void panel2_Click(object sender, EventArgs e)
        {

            gender = "F";
            panel1.BackColor = Color.Gainsboro;
            panel2.BackColor = Color.Gray;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            gender = "F";
            panel1.BackColor = Color.Gainsboro;
            panel2.BackColor = Color.Gray;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Any(x => char.IsLetter(x)))
            {
                textBox1.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Any(x => char.IsLetter(x)))
            {
                textBox2.Text = "";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Any(x => char.IsLetter(x)))
            {
                textBox3.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Equals("") || textBox2.Equals("") || textBox3.Text.Equals("") || gender.Equals(""))
            {
                MessageBox.Show("Please complete form!");
            }
            else
            {
                if (gender == "M")
                {
                    BMR = 66 + (13.7 * double.Parse(textBox2.Text)) + (5 * double.Parse(textBox1.Text)) - (6.8 * double.Parse(textBox3.Text));
                }
                else
                {
                    BMR = 655 + (9.6 * double.Parse(textBox2.Text)) + (1.8 * double.Parse(textBox1.Text)) - (4.7 * double.Parse(textBox3.Text));
                }

                label11.Text = BMR.ToString("F0");
                label22.Text = (BMR * 1.2).ToString("F0");
                label21.Text = (BMR * 1.375).ToString("F0");
                label20.Text = (BMR * 1.55).ToString("F0");
                label19.Text = (BMR * 1.725).ToString("F0");
                label18.Text = (BMR * 1.9).ToString("F0");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            panel3.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            panel3.Visible = false;
        }
    }
}
