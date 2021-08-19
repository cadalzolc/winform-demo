using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cadalzo.demo
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            LblUser.Text = Session.Currentuser.Username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Frm = new FrmUser();
            Frm.ShowDialog();
        }
    }
}