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

        public static string NumberToText(int number, bool isUK)
        {
            if (number == 0) return "Zero";
            string and = isUK ? "and " : ""; // deals with UK or US numbering
            if (number == -2147483648)
                return "Minus Two Billion One Hundred " + and +
"Forty Seven Million Four Hundred " + and + "Eighty Three Thousand " +
"Six Hundred " + and + "Forty Eight";
            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }
            string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
            string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
            string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
            string[] words3 = { "Thousand ", "Million ", "Billion " };
            num[0] = number % 1000;           // units
            num[1] = number / 1000;
            num[2] = number / 1000000;
            num[1] = num[1] - 1000 * num[2];  // thousands
            num[3] = number / 1000000000;     // billions
            num[2] = num[2] - 1000 * num[3];  // millions
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;
                u = num[i] % 10;              // ones
                t = num[i] / 10;
                h = num[i] / 100;             // hundreds
                t = t - 10 * h;               // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i < first) sb.Append(and);
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string[] name = textBox1.Text.Split(' ');

                try
                {
                    var getRunner = data.Runners.Where(x => x.User.FirstName.Equals(name[0]) && x.User.LastName.Equals(name[1])).FirstOrDefault();

                    if (getRunner != null)
                    {
                        String cost = String.Format("{0:C}", getRunner.Registrations.Where(x => x.RunnerId.Equals(getRunner.RunnerId)).Select(x => x.Cost).FirstOrDefault());
                        String sponsorTarget = String.Format("{0:C}", getRunner.Registrations.Where(x => x.RunnerId.Equals(getRunner.RunnerId)).Select(x => x.SponsorshipTarget).FirstOrDefault());
                        int costs = Decimal.ToInt32(getRunner.Registrations.Where(x => x.RunnerId.Equals(getRunner.RunnerId)).Select(x => x.Cost).FirstOrDefault());
                        int sponsors = Decimal.ToInt32(getRunner.Registrations.Where(x => x.RunnerId.Equals(getRunner.RunnerId)).Select(x => x.SponsorshipTarget).FirstOrDefault());
                        
                        label27.Text = "USD" + sponsorTarget + " ("+NumberToText(sponsors, true)+" Dollar)";
                        label23.Text = getRunner.Registrations.Where(x => x.RunnerId.Equals(getRunner.RunnerId)).Select(x => x.RaceKitOption.RaceKitOption1).FirstOrDefault();
                        label22.Text = "USD" + cost + " ("+NumberToText(costs, true)+" Dollar)";
                        label21.Text = String.Format("{0:dd MMMM yyyy}", getRunner.DateOfBirth.Value);
                        label20.Text = getRunner.Country.CountryName;
                        label19.Text = getRunner.Registrations.Where(x => x.RunnerId.Equals(getRunner.RunnerId)).Select(x => String.Format("{0:dd MMMM yyyy}", x.RegistrationDateTime)).FirstOrDefault();
                        label18.Text = getRunner.Registrations.Where(x => x.RunnerId.Equals(getRunner.RunnerId)).Select(x => x.RegistrationStatus.RegistrationStatus1).FirstOrDefault();
                        label17.Text = "USD$0.00" + " (" + NumberToText(0, true) + " Dollar)";
                        label16.Text = getRunner.User.FirstName;
                        label15.Text = getRunner.User.LastName;
                        label14.Text = getRunner.Email;
                        label13.Text = getRunner.Gender;

                        var getSponsorship = data.Sponsorships.Where(x => x.Registration.RunnerId.Equals(getRunner.RunnerId));

                        int cellNum = 0;

                        DataTable dt = new DataTable();
                        dt.Columns.Add(new DataColumn("No", typeof(int)));
                        dt.Columns.Add(new DataColumn("Sponsor Name", typeof(string)));
                        dt.Columns.Add(new DataColumn("Amount", typeof(string)));

                        foreach (var a in getSponsorship)
                        {
                            cellNum += 1;
                            int amount = Decimal.ToInt32(a.Amount);
                            dt.Rows.Add(cellNum, a.SponsorName, String.Format("USD{0:C} ({1} Dollar)", a.Amount, NumberToText(amount, true)));
                        }

                        dataGridView1.DataSource = dt;

                    }
                    else
                    {
                        MessageBox.Show("Runner Data is not Complete, Please Try Again!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please input runner name");
            }
        }
    }
}
