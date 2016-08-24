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
    public partial class sponsorRunner : UserControl
    {
        ICallback parent;
        DataClasses1DataContext db = new DataClasses1DataContext();

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public sponsorRunner()
        {
            InitializeComponent();
            getData();
        }

        public void getData()
        {
            var runner = db.Registrations;
            foreach (var a in runner.OrderBy(x=>x.Runner.User.FirstName))
            {
                comboBox1.Items.Add(a.Runner.User.FirstName+" "+a.Runner.User.LastName+"-"+a.RegistrationEvents.Where(x=>x.RegistrationId.Equals(a.RegistrationId)).Select(x=>x.BibNumber).FirstOrDefault()+"("+a.Runner.CountryCode+")");
            }

            comboBox1.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Any(x => char.IsLetter(x)))
            {
                textBox1.Text = "";
                MessageBox.Show("Only number!");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            if (textBox4.Text.Any(x => char.IsLetter(x)))
            {
                textBox4.Text = "";
                MessageBox.Show("Only number!");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            if (textBox5.Text.Any(x => char.IsLetter(x)))
            {
                textBox5.Text = "";
                MessageBox.Show("Only number!");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            if (textBox6.Text.Any(x => char.IsLetter(x)))
            {
                textBox6.Text = "";
                MessageBox.Show("Only number!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] splitRunner = comboBox1.Text.Split(' ','-','(',')');
            var getCharity = db.Registrations.Where(
                x => x.Runner.User.FirstName.Equals(splitRunner[0]) &&
                    x.Runner.User.LastName.Equals(splitRunner[1])
                ).Select(x => x.CharityId).FirstOrDefault();

            if (getCharity != null)
            {
                var charity = db.Charities.Where(x=>x.CharityId.Equals(getCharity)).FirstOrDefault();
                if(charity!=null) {
                    label13.Text = charity.CharityName;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            charityDetail();
            panel2.Visible = true;
        }

        public void charityDetail()
        {
            var charities = db.Charities.Where(x => x.CharityName.Equals(label13.Text)).FirstOrDefault();
            if (charities != null)
            {
                label14.Text = charities.CharityName;
                label15.Text = charities.CharityDescription;
                pictureBox1.ImageLocation = Environment.CurrentDirectory + "/Resources/" + charities.CharityLogo;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text.Any(x => char.IsLetter(x)) || textBox7.Text.Equals("") || textBox7.Text.Equals("0"))
            {
                textBox7.Text = "10";
            }

            label6.Text = "$" + textBox7.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox7.Text = (decimal.Parse(textBox7.Text) + 10).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox7.Text = (decimal.Parse(textBox7.Text) - 10).ToString();
        }

        public void insertData()
        {
            string[] splitRunner = comboBox1.Text.Split(' ','-','(',')');
            var getRegId = db.Registrations.Where(
                x => x.Runner.User.FirstName.Equals(splitRunner[0]) &&
                    x.Runner.User.LastName.Equals(splitRunner[1])
                ).Select(x => x.RegistrationId).FirstOrDefault();

            Sponsorship r = new Sponsorship();
            r.RegistrationId = getRegId;
            r.Amount = decimal.Parse(textBox7.Text);
            r.SponsorName = textBox2.Text;

            try
            {
                db.Sponsorships.InsertOnSubmit(r);
                db.SubmitChanges();
                parent.aksi("SPONSORCONFIRM", splitRunner[0] + " " + splitRunner[1] + " ("+splitRunner[2]+") from "+splitRunner[3], label13.Text, label6.Text);
                //MessageBox.Show("Success");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "" || textBox5.Text != "" || textBox6.Text != "")
            {
                if (textBox1.Text.Length >= 16 && textBox6.Text.Length >= 3)
                {
                    if (int.Parse(textBox4.Text) <= 12)
                    {
                        if (int.Parse(textBox5.Text) >= DateTime.Now.Year)
                        {
                            if (int.Parse(textBox5.Text) == DateTime.Now.Year)
                            {
                                if (int.Parse(textBox4.Text) > DateTime.Now.Month)
                                {
                                    //insert
                                    insertData();
                                }
                                else
                                {
                                    MessageBox.Show("Credit card expired");
                                }
                            }
                            else
                            {
                                //insert
                                insertData();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Credit card expired");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Credit card expired");
                    }
                }
                else
                {
                    MessageBox.Show("Credit card must 16 digit and CVC must 3 digit");
                }
            }
            else
            {
                MessageBox.Show("Please complete the form!");
            }
        }
    }
}
