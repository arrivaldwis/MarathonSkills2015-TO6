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
    public partial class addDetailEmployee : Form
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        string year, position;
        public addDetailEmployee(string year, string position)
        {
            InitializeComponent();
            this.year = year;
            this.position = position;
            getData();
        }

        private void getData()
        {
            label3.Text = this.position + " - " + this.year;
            var getEmployee = data.Timesheets.Where(
                x => x.Staff.Position.PositionName.Equals(this.position) &&
                     x.StartDateTime.Value.Year.Equals(this.year) &&
                    x.StartDateTime.Value.Year.Equals(this.year)).Select(x => new
                    {
                        FullName = x.Staff.FirstName + " " + x.Staff.LastName
                    }).GroupBy(x => x.FullName);

            dataGridView1.DataSource = getEmployee.Select(x => new
            {
                FullName = x.Key,
                Gender = data.Staffs.Where(
                    y => (y.FirstName + " " + y.LastName).Equals(x.Key) &&
                         y.Position.PositionName.Equals(this.position) &&
                         y.Timesheets.Where(r=>r.StartDateTime.Value.Year.Equals(this.year)).Count() > 0
                    ).Select(z => z.Gender).First(),
                DateOfBirth = String.Format("{0:dd-MMM-yyyy}", data.Staffs.Where(
                    y => (y.FirstName + " " + y.LastName).Equals(x.Key) &&
                         y.Position.PositionName.Equals(this.position) &&
                         y.Timesheets.Where(r => r.StartDateTime.Value.Year.Equals(this.year)).Count() > 0
                     ).Select(z => z.DateOfBirth).First()),
                Email = data.Staffs.Where(
                    y => (y.FirstName + " " + y.LastName).Equals(x.Key) &&
                         y.Position.PositionName.Equals(this.position) &&
                         y.Timesheets.Where(r=>r.StartDateTime.Value.Year.Equals(this.year)).Count() > 0
                    ).Select(z => z.Email).FirstOrDefault().ToString(),
                WorkingHour = data.Timesheets.Where(
                    y => (y.Staff.FirstName + " " + y.Staff.LastName).Equals(x.Key) &&
                         y.Staff.Position.PositionName.Equals(this.position) &&
                         y.StartDateTime.Value.Year.Equals(this.year)
                    ).Sum(z => (z.EndDateTime.Value - z.StartDateTime.Value).Hours).ToString() + " hours",
                PaymentAmount = String.Format("{0:C}", data.Timesheets.Where(
                    y => (y.Staff.FirstName + " " + y.Staff.LastName).Equals(x.Key) &&
                         y.Staff.Position.PositionName.Equals(this.position) &&
                         y.StartDateTime.Value.Year.Equals(this.year)
                    ).Sum(z => z.PayAmount.Value))
            });
        }
    }
}
