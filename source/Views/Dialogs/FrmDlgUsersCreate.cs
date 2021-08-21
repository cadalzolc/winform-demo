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
    public partial class FrmDlgUsersCreate : Form
    {


        #region " Init "

        public FrmDlgUsersCreate()
        {
            InitializeComponent();
        }

        #endregion

        #region " Event - Button "

        private void BtnSave_Click(object sender, EventArgs e)
        {

            if (TxtName.Text.Equals(""))
            {
                MessageBox.Show("Please input Name");
                return;
            }

            if (TxtUsername.Text.Equals(""))
            {
                MessageBox.Show("Please input Username");
                return;
            }

            if (TxtPassword.Text.Equals(""))
            {
                MessageBox.Show("Please input Password");
                return;
            }

            var Model = new User
            {
                Name = TxtName.Text,
                Username = TxtUsername.Text,
                Password = TxtPassword.Text
            };
            var Mgr = new UserManagement();
            var Res = Mgr.UserCreate(Model);

            if (Res.Success.Equals(false))
            {
                MessageBox.Show(Res.Message);
                return;
            }

            MessageBox.Show(Res.Message);

            DialogResult = DialogResult.OK;

            Close();
        }

        #endregion

    }
}
