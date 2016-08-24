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
    public partial class manageRunner : UserControl
    {
        ICallback parent;
        string regId;

        public void setParent(ICallback parent)
        {
            this.parent = parent;
        }

        public manageRunner(string regId)
        {
            InitializeComponent();
            this.regId = regId;
        }
    }
}
