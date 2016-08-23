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
    public partial class BMICalculator : UserControl
    {
        ICallback parent;
        string gender = "M";
        double BMI;

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public BMICalculator()
        {
            InitializeComponent();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            gender = "F";
            panel1.BackColor = Color.Gainsboro;
            panel2.BackColor = Color.Gray;
        }

        private void panel2_Click(object sender, EventArgs e)
        {

            gender = "F";
            panel1.BackColor = Color.Gainsboro;
            panel2.BackColor = Color.Gray;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("") || !textBox2.Text.Equals("") || !gender.Equals(""))
            {
                BMI = double.Parse(textBox2.Text) * 100 / (double.Parse(textBox1.Text) * double.Parse(textBox1.Text)) * 100;
                BMI = double.Parse(BMI.ToString("F2"));
                //BMI = BMI - 0.1;
                if (BMI < 18.5)
                {
                    panel8.Left = panel4.Left + (int)((panel4.Width * (BMI)) / 18.5) - 31;
                    label8.Text = "Underweight";
                    pictureBox3.ImageLocation = Environment.CurrentDirectory + "/Resources/bmi-underweight-icon.png";
                }
                else if (BMI >= 18.5 && BMI < 25)
                {
                    panel8.Left = panel5.Left + (int)((panel5.Width * (BMI - 18.5)) / (25 - 18.5)) - (31);
                    label8.Text = "Healthy";
                    pictureBox3.ImageLocation = Environment.CurrentDirectory + "/Resources/bmi-healthy-icon.png";
                }
                else if (BMI >= 25 && BMI < 30)
                {
                    panel8.Left = panel6.Left + (int)((panel6.Width * (BMI - 25)) / (30 - 25)) - 31;
                    label8.Text = "Overweight";
                    pictureBox3.ImageLocation = Environment.CurrentDirectory + "/Resources/bmi-overweight-icon.png";
                }
                else if (BMI > 30)
                {
                    panel8.Left = panel7.Left + (int)((panel7.Width * (BMI - (BMI - 70))) / (70)) - 31;
                    label8.Text = "Obese";
                    pictureBox3.ImageLocation = Environment.CurrentDirectory + "/Resources/bmi-obese-icon.png";
                }

                label9.Text = BMI.ToString("F2");
            }
            else
            {
                MessageBox.Show("Please complete the form!");
            }
        }
    }
}
