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
    public partial class userManagement : UserControl
    {
        ICallback parent;
        DataClasses1DataContext data = new DataClasses1DataContext();
        DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public userManagement()
        {
            InitializeComponent();
            getData();
        }

        private void getData()
        {
            btnEdit.Name = "btnEdit";
            btnEdit.HeaderText = "Edit";
            btnEdit.Text = "Edit";
            btnEdit.UseColumnTextForButtonValue = true;

            var role = data.Roles;

            cbRole.Items.Add("All roles");
            foreach (var a in role)
            {
                cbRole.Items.Add(a.RoleName);
            }

            cbRole.SelectedIndex = 0;
            cbSort.SelectedIndex = 0;

            refreshData();
            dataGridView1.Columns.Insert(4, btnEdit);
        }

        private void refreshData()
        {
            var user = data.Users.Join(data.Roles, x => x.RoleId, y => y.RoleId, (x, y) => new {
                x.FirstName,
                x.LastName,
                x.Email,
                y.RoleName
            });

            if (cbRole.SelectedIndex != 0)
            {
                user = user.Where(x => x.RoleName.Equals(cbRole.Text) && (x.FirstName.Contains(txtSearch.Text) || x.LastName.Contains(txtSearch.Text) || x.Email.Contains(txtSearch.Text)));
            }
            else
            {
                user = user.Where(x => (x.FirstName.Contains(txtSearch.Text) || x.LastName.Contains(txtSearch.Text) || x.Email.Contains(txtSearch.Text)));
            }

            if (cbSort.SelectedIndex == 0)
            {
                user = user.OrderBy(x => x.FirstName);
            }
            else if (cbSort.SelectedIndex == 1)
            {
                user = user.OrderBy(x => x.LastName);
            }
            else if (cbSort.SelectedIndex == 2)
            {
                user = user.OrderBy(x => x.Email);
            }
            else if (cbSort.SelectedIndex == 3)
            {
                user = user.OrderBy(x => x.RoleName);
            }

            dataGridView1.DataSource = user;
            lblTotUser.Text = user.Count().ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                string email = dataGridView1[3, row].Value.ToString();
                parent.aksi("EDITUSER", email, "", "");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parent.aksi("ADDUSER", "", "", "");
        }
    }
}
