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
        DataClasses1DataContext db = new DataClasses1DataContext();
        string runnerId;

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public mySponsorship(string runnerId)
        {
            InitializeComponent();
            this.runnerId = runnerId;
            getData();
        }

        public void getData()
        {
            decimal amount = 0;
            var getRegId = db.Registrations.Where(x=>x.RunnerId.Equals(this.runnerId)).Select(x=>x.RegistrationId).FirstOrDefault();
            if(getRegId!=null) {
                
                var sponsor = db.Sponsorships.Where(x => x.RegistrationId.Equals(getRegId));
                
                if (sponsor != null)
                {
                    dataGridView1.DataSource = sponsor.Select(
                        x => new
                        {
                            Sponsor = x.SponsorName,
                            Amount = String.Format("{0:C}",x.Amount)
                        });

                    foreach (var a in sponsor)
                    {
                        amount += a.Amount;
                    }

                    label4.Text = String.Format("Total {0:C}", amount);
                }
                else
                {
                    MessageBox.Show("This runner don't have any sponsorship");
                }
            }

            var getCharity = db.Registrations.Where(x => x.RunnerId.Equals(this.runnerId)).Select(x => x.CharityId).FirstOrDefault();
            
            if (getCharity != null)
            {
                var charity = db.Charities.Where(x=>x.CharityId.Equals(getCharity)).FirstOrDefault();
                label3.Text = charity.CharityName;
                pictureBox1.ImageLocation = Environment.CurrentDirectory + "/Resources/" + charity.CharityLogo;
                label2.Text = charity.CharityDescription;
            }
        }
    }
}
