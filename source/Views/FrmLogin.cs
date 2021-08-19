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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var Mgr = new UserManagement();
            var Res = Mgr.Login(txtUsername.Text, txtPassword.Text);

            if (Res.Success.Equals(false))
            {
                MessageBox.Show(Res.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Session.Currentuser = (User)Res.Data;

            Hide();

            var Dash = new FrmDashboard();

            Dash.ShowDialog();

            Show();
        }
    }
}
