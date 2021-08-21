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
    public partial class FrmDlgUsersUpdate : Form
    {

        #region " Init "

        public FrmDlgUsersUpdate(User SelectedUser)
        {
            InitializeComponent();

            BtnSave.Click += BtnSave_Click;

            TxtID.Text = SelectedUser.ID;
            TxtName.Text = SelectedUser.Name;
            TxtUsername.Text = SelectedUser.Username;
            TxtPassword.Text = SelectedUser.Password;
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
                ID = TxtID.Text,
                Name = TxtName.Text,
                Username = TxtUsername.Text,
                Password = TxtPassword.Text
            };
            var Mgr = new UserManagement();
            var Res = Mgr.UserUpdate(Model);

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
