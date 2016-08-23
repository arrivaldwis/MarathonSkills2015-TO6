using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MarathonSkills2015_TO6.User_Control
{
    public partial class addEditCharity : UserControl
    {
        ICallback parent;
        DataClasses1DataContext data = new DataClasses1DataContext();
        string charityName;

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public addEditCharity()
        {
            InitializeComponent();
        }

        public addEditCharity(string charityName)
        {
            InitializeComponent();
            this.charityName = charityName;
            getData();
        }

        private void getData()
        {
            if (this.charityName != "")
            {
                var charity = data.Charities.Where(x => x.CharityName.Equals(this.charityName)).First();
                label4.Text = charity.CharityId.ToString();
                txtName.Text = charity.CharityName;
                txtDescriptions.Text = charity.CharityDescription;
                txtFile.Text = Environment.CurrentDirectory + "/Resources/" + charity.CharityLogo;
                pictureBox1.ImageLocation = txtFile.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName.Contains("jpg") || openFileDialog1.FileName.Contains("jpeg") ||
                    openFileDialog1.FileName.Contains("png") || openFileDialog1.FileName.Contains("gif") ||
                    openFileDialog1.FileName.Contains("bmp"))
                {
                    txtFile.Text = openFileDialog1.FileName;
                    pictureBox1.ImageLocation = txtFile.Text;
                }
                else
                {
                    MessageBox.Show("only jpg,jpeg,png,gif and bmp file format!");
                    txtName.Text = "";
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" || txtDescriptions.Text != "" || txtFile.Text != "")
            {
                if (this.charityName == "")
                {
                    if (txtFile.Text == "")
                    {
                        MessageBox.Show("Please choose charity logo!");
                    }
                    else
                    {
                        Charity c = new Charity();
                        string imageName = DateTime.Now.ToString("MMddyyyyHHmmssfff") + " - " + openFileDialog1.SafeFileName;
                        c.CharityName = txtName.Text;
                        c.CharityDescription = txtDescriptions.Text;
                        c.CharityLogo = imageName;
                        File.Copy(txtFile.Text, Environment.CurrentDirectory + "/Resources/" + imageName);
                        try
                        {
                            data.Charities.InsertOnSubmit(c);
                            data.SubmitChanges();
                            MessageBox.Show("Charities added!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    var c = data.Charities.Where(x => x.CharityId.Equals(label4.Text)).First();
                    c.CharityName = txtName.Text;
                    c.CharityDescription = txtDescriptions.Text;

                    if ((Environment.CurrentDirectory + "/Resources/" + c.CharityLogo).Equals(txtFile.Text))
                    {
                        //no update
                    }
                    else
                    {
                        string imageName = DateTime.Now.ToString("MMddyyyyHHmmssfff") + " - " + openFileDialog1.SafeFileName;
                        c.CharityLogo = imageName;
                        File.Copy(txtFile.Text, Environment.CurrentDirectory + "/Resources/" + imageName);
                    }

                    data.SubmitChanges();
                    MessageBox.Show("Charities updated!");
                }
            }
            else
            {
                MessageBox.Show("Please Complete the form!");
            }
        }
    }
}
