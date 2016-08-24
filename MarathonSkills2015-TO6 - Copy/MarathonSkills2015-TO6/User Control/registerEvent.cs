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
    public partial class registerEvent : UserControl
    {
        ICallback parent;
        DataClasses1DataContext db = new DataClasses1DataContext();
        string eventSel = "";
        char raceKitOption = 'A';
        double optionCost, totalCost, eventCost;
        string runnerId;
        int checkeds = 0;

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public registerEvent(string email)
        {
            InitializeComponent();
            this.runnerId = db.Runners.Where(x=>x.Email.Equals(email)).Select(x=>x.RunnerId).FirstOrDefault().ToString();
            getData();
        }

        public void getData()
        {
            foreach (var a in db.Charities)
            {
                comboBox1.Items.Add(a.CharityName);
            }

            comboBox1.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Any(x => char.IsLetter(x)) || textBox1.Text.Equals("") || textBox1.Text.Equals("0"))
            {
                textBox1.Text = "10";
            }
        }

        public void charityDetail()
        {
            var charities = db.Charities.Where(x => x.CharityName.Equals(comboBox1.Text)).FirstOrDefault();
            if (charities != null)
            {
                label14.Text = charities.CharityName;
                label15.Text = charities.CharityDescription;
                pictureBox1.ImageLocation = Environment.CurrentDirectory + "/Resources/" + charities.CharityLogo;
            }
        }

        public void eventChecked(string eventName, double cost, CheckBox ck)
        {
            eventSel = eventName;

            if (ck.Checked == true)
            {
                eventCost += cost;
            }
            else
            {
                eventCost -= cost;
            }

            totalCost = eventCost + optionCost;
            label6.Text = "$" + totalCost;
        }

        public void optionChanged(char kit, double cost)
        {
            raceKitOption = kit;

            optionCost = cost;
            totalCost = eventCost + optionCost;

            label6.Text = "$" + totalCost;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            charityDetail();
            panel2.Visible = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            eventChecked("A", 145, checkBox1);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            eventChecked("B", 75, checkBox2);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            eventChecked("C", 20, checkBox3);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            optionChanged('A', 0);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            optionChanged('B', 20);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            optionChanged('C', 45);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (eventSel != "")
            {
                if (checkBox1.CheckState == CheckState.Unchecked && checkBox2.CheckState == CheckState.Unchecked && checkBox3.CheckState == CheckState.Unchecked)
                {
                    MessageBox.Show("Please choose at least one event!");
                }
                else
                {
                    insertData();
                }
            }
            else
            {
                MessageBox.Show("Please choose at least one event!");
            }
        }

        public void insertData()
        {
            Registration r = new Registration();
            r.CharityId = db.Charities.Where(x => x.CharityName.Equals(comboBox1.Text)).Select(x => x.CharityId).FirstOrDefault();
            r.Cost = decimal.Parse(totalCost.ToString());
            r.RaceKitOptionId = raceKitOption;
            r.RunnerId = int.Parse(this.runnerId);
            r.RegistrationDateTime = DateTime.Now;
            r.RegistrationStatusId = 1;
            r.SponsorshipTarget = decimal.Parse(textBox1.Text);

            try
            {
                db.Registrations.InsertOnSubmit(r);
                db.SubmitChanges();

                if (checkBox1.Checked == true)
                {
                    checkeds++;
                }
                
                if (checkBox2.Checked == true)
                {
                    checkeds++;
                }

                if (checkBox3.Checked == true)
                {
                    checkeds++;
                }

                for (int i = 0; i < checkeds; i++)
                {
                    if (checkBox1.Checked == true)
                    {
                        checkBox1.Checked = false;
                        insertEvent(r, "15_5FM");
                    }
                    else if (checkBox2.Checked == true)
                    {
                        checkBox2.Checked = false;
                        insertEvent(r, "15_5HM");
                    }
                    else if (checkBox3.Checked == true)
                    {
                        checkBox3.Checked = false;
                        insertEvent(r, "15_5FR");
                    }
                }

                parent.aksi("REGISTEREVENTCONFIRM", "", "", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void insertEvent(Registration r, string eventId)
        {
            var bib = db.RegistrationEvents.Where(x=>x.RegistrationId.Equals(r.RegistrationId)).Select(x=>x.BibNumber).FirstOrDefault();

            RegistrationEvent ra = new RegistrationEvent();
            ra.BibNumber = bib;
            ra.RegistrationId = r.RegistrationId;
            ra.EventId = eventId;

            try
            {
                db.RegistrationEvents.InsertOnSubmit(ra);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }
    }
}
