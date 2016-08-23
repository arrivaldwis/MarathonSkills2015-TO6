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
        double eventCost = 0, optionCost = 0, totalCost = 0;
        string runnerId;
        char kitOption = 'A';
        string eventSel = "";
        int checkeds = 0;

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public registerEvent()
        {
            InitializeComponent();
        }

        public registerEvent(string runnerId)
        {
            InitializeComponent();
            this.runnerId = runnerId;
            getData();
        }

        private void getData()
        {
            foreach (var a in db.Charities)
            {
                cbCharity.Items.Add(a.CharityName);
            }

            cbCharity.SelectedIndex = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var getCharity = db.Charities.Where(x => x.CharityName.Equals(cbCharity.Text)).First();

            pictureBox1.ImageLocation = Environment.CurrentDirectory + "/Resources/" + getCharity.CharityLogo;
            label13.Text = getCharity.CharityDescription;
            label12.Text = getCharity.CharityName;

            panel1.Visible = true;
        }

        private void insertData()
        {

            Registration r = new Registration();
            r.RunnerId = int.Parse(this.runnerId);
            r.RegistrationDateTime = DateTime.Now;
            r.RaceKitOptionId = kitOption;
            r.RegistrationStatusId = 1;
            r.Cost = decimal.Parse(totalCost.ToString());
            r.CharityId = db.Charities.Where(x => x.CharityName.Equals(cbCharity.Text)).Select(x => x.CharityId).First();
            r.SponsorshipTarget = decimal.Parse(txtTargetRaise.Text);
            try
            {
                db.Registrations.InsertOnSubmit(r);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
                    checkBox1.CheckState = CheckState.Unchecked;
                    insertEvent(r, "15_5FM");
                }
                else if (checkBox2.Checked == true)
                {
                    checkBox2.CheckState = CheckState.Unchecked;
                    insertEvent(r, "15_5HM");
                }
                else if (checkBox3.Checked == true)
                {
                    checkBox3.CheckState = CheckState.Unchecked;
                    insertEvent(r, "15_5FR");
                }
            }

            parent.aksi("REGISTEREVENTCONFIRMATION", db.Runners.Where(x => x.RunnerId.Equals(this.runnerId)).First().Email, "R", "");
        }

        public void insertEvent(Registration r, string eventName)
        {
            var bib = db.RegistrationEvents.Where(x => x.Registration.Runner.RunnerId.Equals(this.runnerId)).Select(x => x.BibNumber);

            RegistrationEvent ra = new RegistrationEvent();
            ra.RegistrationId = r.RegistrationId;
            ra.EventId = db.Events.Where(x => x.EventId.Equals(eventName)).Select(x => x.EventId).First();
            if (bib.Count() > 0)
            {
                ra.BibNumber = bib.FirstOrDefault();
            }
            checkBox1.Checked = false;
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

        private void txtTargetRaise_TextChanged(object sender, EventArgs e)
        {
            if (txtTargetRaise.Text.Any(c => char.IsLetter(c)) || txtTargetRaise.Text == "0" || txtTargetRaise.Text == "")
            {
                MessageBox.Show("Only Positive Integer");
                txtTargetRaise.Text = "1";
            }
        }

        public void eventChecked(string sel, int price, CheckBox ck)
        {
            eventSel = sel;

            if (ck.Checked == true)
            {
                eventCost += price;
            }
            else
            {
                eventCost -= price;
            }

            totalCost = eventCost + optionCost;

            lblTotalCost.Text = "$" + totalCost;
        }

        public void optionChange(int cost, char option)
        {
            optionCost = cost;
            totalCost = eventCost + optionCost;
            kitOption = option;

            lblTotalCost.Text = "$" + totalCost;
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
            optionChange(0, 'A');
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            optionChange(20, 'B');
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            optionChange(45, 'C');
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (eventSel != "")
            {
                if (checkBox1.CheckState == CheckState.Unchecked && checkBox2.CheckState == CheckState.Unchecked && checkBox3.CheckState == CheckState.Unchecked)
                {
                    checkeds = 0;
                    MessageBox.Show("Please choose at least one event!");
                }
                else
                {
                    insertData();
                }
            }
            else
            {
                checkeds = 0;
                MessageBox.Show("Please choose at least one event!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
    }
}
