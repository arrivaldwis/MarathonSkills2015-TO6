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
        DataClasses1DataContext data = new DataClasses1DataContext();

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public sponsorRunner()
        {
            InitializeComponent();
            getData();
        }

        private void getData()
        {
            var getRunner = data.Registrations.Where(x => x.RegistrationEvents.First().Event.Marathon.MarathonId == 5).Select(x => new
            {
                x.Runner.User.FirstName,
                x.Runner.User.LastName,
                x.RegistrationEvents.First().BibNumber,
                x.Runner.CountryCode
            });

            foreach (var a in getRunner.OrderBy(x => x.LastName))
            {
                cbRunner.Items.Add(a.LastName + "," + a.FirstName + "-" + a.BibNumber + "(" + a.CountryCode + ")");
            }

            cbRunner.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cbRunner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRunner.Text != "")
            {
                string[] splitRunner = cbRunner.Text.Split(',', '-', '(', ')');

                if (splitRunner[2].ToString() != "")
                {
                    var getRunner = data.Registrations.Where(
                                    x => x.Runner.User.LastName.Equals(splitRunner[0]) &&
                                    x.Runner.User.FirstName.Equals(splitRunner[1]) &&
                                    x.RegistrationEvents.First().BibNumber.Equals(int.Parse(splitRunner[2]))
                                    ).First();
                    lblCharityName.Text = getRunner.Charity.CharityName;
                } else
                {
                    var getRunner = data.Registrations.Where(
                                    x => x.Runner.User.LastName.Equals(splitRunner[0]) &&
                                    x.Runner.User.FirstName.Equals(splitRunner[1])
                                    ).First();
                    lblCharityName.Text = getRunner.Charity.CharityName;
                }
            }
        }

        private void txtCC_TextChanged(object sender, EventArgs e)
        {
            if (txtCC.Text.Any(x => char.IsLetter(x)))
            {
                txtCC.Text = "";
            }
        }

        private void txtMonth_TextChanged(object sender, EventArgs e)
        {
            if (txtMonth.Text.Any(x => char.IsLetter(x)))
            {
                txtMonth.Text = "";
            }
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            if (txtYear.Text.Any(x => char.IsLetter(x)))
            {
                txtYear.Text = "";
            }
        }

        private void txtCVC_TextChanged(object sender, EventArgs e)
        {
            if (txtCVC.Text.Any(x => char.IsLetter(x)))
            {
                txtCVC.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            detailCharity();
            panel1.Visible = true;
        }

        private void detailCharity()
        {
            var getCharity = data.Charities.Where(x => x.CharityName.Equals(lblCharityName.Text)).First();
            pictureBox1.ImageLocation = Environment.CurrentDirectory + "/Resources/" + getCharity.CharityLogo;
            label12.Text = getCharity.CharityName;
            label13.Text = getCharity.CharityDescription;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox7.Text = "" + (decimal.Parse(textBox7.Text) + 10);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox7.Text = "" + (decimal.Parse(textBox7.Text) - 10);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text == "" || textBox7.Text.Any(c => char.IsLetter(c)) || decimal.Parse(textBox7.Text) < 1)
            {
                textBox7.Text = "10";
            }

            lblTotal.Text = "$" + (decimal.Parse(textBox7.Text) * 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Equals("") || txtNameCard.Text.Equals("") || txtCC.Text.Equals("") || txtMonth.Text.Equals("") || txtYear.Text.Equals("") || txtCVC.Text.Equals(""))
            {
                MessageBox.Show("Please complete the form!");
            }
            else
            {
                if (textBox7.Text == "0")
                {
                    MessageBox.Show("Amount donate must positive integer");
                }
                else
                {
                    if (txtCVC.Text.Length < 3 || txtCC.Text.Length < 16)
                    {
                        MessageBox.Show("CVC must 3 digit and CC number must 16 digit!");
                    }
                    else
                    {
                        int mon = DateTime.Now.Month;
                        int year = DateTime.Now.Year;

                        if (int.Parse(txtYear.Text) < year || int.Parse(txtMonth.Text) > 12)
                        {
                            MessageBox.Show("Credit card expired/not valid");
                        }
                        else if (int.Parse(txtYear.Text) >= year)
                        {
                            if (int.Parse(txtMonth.Text) >= mon)
                            {
                                //aksi
                                insertData();
                            }
                            else
                            {
                                MessageBox.Show("Credit card expired/not valid");
                            }
                        }
                    }
                }
            }
        }

        private void insertData()
        {
            Sponsorship s = new Sponsorship();
            s.SponsorName = txtName.Text;

            string[] splitRunner = cbRunner.Text.Split(',', '-', '(', ')');

            if (splitRunner[2].ToString() != "")
            {
                var getRunner = data.Registrations.Where(
                                x => x.Runner.User.LastName.Equals(splitRunner[0]) &&
                                x.Runner.User.FirstName.Equals(splitRunner[1]) &&
                                x.RegistrationEvents.First().BibNumber.Equals(int.Parse(splitRunner[2]))
                                ).First();
                s.RegistrationId = getRunner.RegistrationId;
            }
            else
            {
                var getRunner = data.Registrations.Where(
                                x => x.Runner.User.LastName.Equals(splitRunner[0]) &&
                                x.Runner.User.FirstName.Equals(splitRunner[1])
                                ).First();
                s.RegistrationId = getRunner.RegistrationId;
            }

            s.Amount = int.Parse(lblTotal.Text.Substring(1));

            try
            {
                data.Sponsorships.InsertOnSubmit(s);
                data.SubmitChanges();
                parent.aksi("SPONSORCONFIRM", splitRunner[0] + " " + splitRunner[1] + " (" + splitRunner[2] + ") from " + splitRunner[3], lblTotal.Text, lblCharityName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
