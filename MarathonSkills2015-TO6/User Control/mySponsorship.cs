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
    public partial class mySponsorship : UserControl
    {
        ICallback parent;
        DataClasses1DataContext data = new DataClasses1DataContext();
        string runnerId;

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public mySponsorship()
        {
            InitializeComponent();
        }

        public mySponsorship(string runnerId)
        {
            InitializeComponent();
            this.runnerId = runnerId;
            getData();
        }

        private void getData()
        {
            double totalAmount = 0;
            var regId = data.Registrations.Where(x => x.RunnerId.Equals(this.runnerId)).Select(x => x.RegistrationId).FirstOrDefault();
            var sponsor = data.Sponsorships.Where(x => x.RegistrationId.Equals(regId)).Where(x => x.Registration.RegistrationEvents.Where(z => z.Event.Marathon.MarathonName.Equals("Marathon Skills 2015")).Count() > 0);

            foreach (var a in sponsor)
            {
                totalAmount += double.Parse(a.Amount.ToString());
            }

            if (sponsor.Count() <= 0)
            {
                MessageBox.Show("No Sponsorship for this runner");
            }

            var sponsorReg = data.Registrations.Where(x => x.RunnerId.Equals(this.runnerId)).FirstOrDefault();

            if (sponsorReg != null)
            {
                var charity = data.Charities.Where(x => x.CharityId.Equals(sponsorReg.CharityId)).Select(x => new {
                    x.CharityName,
                    x.CharityLogo,
                    x.CharityDescription
                });

                label4.Text = charity.First().CharityName;
                pictureBox1.ImageLocation = Environment.CurrentDirectory + "/Resources/" + charity.First().CharityLogo;
                label3.Text = charity.First().CharityDescription;
            }

            dataGridView1.DataSource = sponsor.Select(x => new { Sponsor = x.SponsorName, Amount = String.Format("{0:C}", x.Amount) });
            lblTotAmount.Text = "Total " + String.Format("{0:C}", totalAmount);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
