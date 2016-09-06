using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarathonSkills2015_TO6.Additional
{
    public partial class addRunnerDetailInformation : Form
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        public addRunnerDetailInformation()
        {
            InitializeComponent();
        }

        public string IntegerToWords(string rawnumber)
        {
            int inputNum = 0;
            int dig1, dig2, dig3, level = 0, lasttwo, threeDigits;
            string dollars, cents;
            try
            {
                string[] Splits = new string[2];
                Splits = rawnumber.Split('.');   //notice that it is ' and not "
                inputNum = Convert.ToInt32(Splits[0]);

                //get inputNum as an int

                //dollars = Convert.ToString(inputNum);
                dollars = "";
                cents = Splits[1];
                if (cents.Length == 1)
                {
                    cents += "0";   // 12.5 is twelve and 50/100, not twelve and 5/100
                }
            }
            catch
            {
                cents = "00";
                inputNum = Convert.ToInt32(rawnumber);
                dollars = "";
                //dollars = Convert.ToString(rawnumber);
            }

            string x = "";

            //they had zero for ones and tens but that gave ninety zero for 90
            string[] ones = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] thou = { "", "thousand", "million", "billion", "trillion", "quadrillion", "quintillion" };

            bool isNegative = false;
            if (inputNum < 0)
            {
                isNegative = true;
                inputNum *= -1;
            }
            if (inputNum == 0)
            {
                return "zero and " + cents + "/100";
            }

            string s = inputNum.ToString();

            //for (int t = 0; t < 5; t++)
            while (s.Length > 0)
            {
                if (s.Length > 0)
                {
                    //Get the three rightmost characters
                    x = (s.Length < 3) ? s : s.Substring(s.Length - 3, 3);

                    // Separate the three digits
                    threeDigits = int.Parse(x);
                    lasttwo = threeDigits % 100;
                    dig1 = threeDigits / 100;
                    dig2 = lasttwo / 10;
                    dig3 = (threeDigits % 10);


                    // append a "thousand" where appropriate
                    if (level > 0 && dig1 + dig2 + dig3 > 0)
                    {
                        dollars = thou[level] + " " + dollars;
                        dollars = dollars.Trim();
                    }

                    // check that the last two digits is not a zero
                    if (lasttwo > 0)
                    {
                        if (lasttwo < 20)
                        {
                            // if less than 20, use "ones" only
                            dollars = ones[lasttwo] + " " + dollars;
                        }
                        else
                        {
                            // otherwise, use both "tens" and "ones" array
                            dollars = tens[dig2] + " " + ones[dig3] + " " + dollars;
                        }
                        if (s.Length < 3)
                        {
                            if (isNegative) { dollars = "negative " + dollars; }
                            return dollars + " and " + cents + "/100";
                        }
                    }

                    // if a hundreds part is there, translate it
                    if (dig1 > 0)
                    {
                        dollars = ones[dig1] + " hundred " + dollars;
                        s = (s.Length - 3) > 0 ? s.Substring(0, s.Length - 3) : "";
                        level++;
                    }
                }
            }
            if (isNegative) { dollars = "negative " + dollars; }
            return dollars + " and " + cents + "/100";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string[] name = textBox1.Text.Split(' ');

                try {
                    var getRunner = data.Runners.Where(x => x.User.FirstName.Equals(name[0]) && x.User.LastName.Equals(name[1])).FirstOrDefault();

                    string decimals = "";

                    if (getRunner != null)
                    {
                        String cost = String.Format("{0:C}", getRunner.Registrations.Where(x => x.RunnerId.Equals(getRunner.RunnerId)).Select(x => x.Cost).FirstOrDefault());
                        String sponsorTarget = String.Format("{0:C}", getRunner.Registrations.Where(x => x.RunnerId.Equals(getRunner.RunnerId)).Select(x => x.SponsorshipTarget).FirstOrDefault());

                        //String strWords = IntegerToWords(getRunner.Registrations.Where(x => x.RunnerId.Equals(getRunner.RunnerId)).Select(x => x.Cost).FirstOrDefault().ToString());
                        //String strWords2 = IntegerToWords(getRunner.Registrations.Where(x => x.RunnerId.Equals(getRunner.RunnerId)).Select(x => x.SponsorshipTarget).FirstOrDefault().ToString());

                        label27.Text = "USD" + sponsorTarget;
                        label23.Text = getRunner.Registrations.Where(x => x.RunnerId.Equals(getRunner.RunnerId)).Select(x => x.RaceKitOption.RaceKitOption1).FirstOrDefault();
                        label22.Text = "USD" + cost;
                        label21.Text = String.Format("{0:dd MMMM yyyy}", getRunner.DateOfBirth.Value);
                        label20.Text = getRunner.Country.CountryName;
                        label19.Text = getRunner.Registrations.Where(x => x.RunnerId.Equals(getRunner.RunnerId)).Select(x => String.Format("{0:dd MMMM yyyy}", x.RegistrationDateTime)).FirstOrDefault();
                        label18.Text = getRunner.Registrations.Where(x => x.RunnerId.Equals(getRunner.RunnerId)).Select(x => x.RegistrationStatus.RegistrationStatus1).FirstOrDefault();
                        label17.Text = "USD$0.00 (Zero Dollar)";
                        label16.Text = getRunner.User.FirstName;
                        label15.Text = getRunner.User.LastName;
                        label14.Text = getRunner.Email;
                        label13.Text = getRunner.Gender;

                        var getSponsorship = data.Sponsorships.Where(x => x.Registration.RunnerId.Equals(getRunner.RunnerId));

                        int cellNum = 0;
                        int rowNum = 0;

                        DataTable dt = new DataTable();
                        dt.Columns.Add(new DataColumn("No", typeof(int)));
                        dt.Columns.Add(new DataColumn("Sponsor Name", typeof(string)));
                        dt.Columns.Add(new DataColumn("Amount", typeof(string)));

                        foreach(var a in getSponsorship)
                        {
                            cellNum += 1;
                            dt.Rows.Add(cellNum, a.SponsorName, String.Format("USD{0:C}", a.Amount));
                        }

                        dataGridView1.DataSource = dt;

                    }
                    else
                    {
                        MessageBox.Show("Runner Data is not Complete, Please Try Again!");
                    }
                } catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else
            {
                MessageBox.Show("Please input runner name");
            }
        }
    }
}
