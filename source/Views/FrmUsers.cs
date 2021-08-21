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
    public partial class FrmUser : Form
    {

        #region " Properties "

        public User SelectedUser { get; set; } = new User();    

        #endregion

        #region " Init "

        public FrmUser()
        {
            InitializeComponent();

            BtnUserCreate.Click += BtnUserCreate_Click;
            BtnUsersUpdate.Click += BtnUsersUpdate_Click;

            GrdUsers.CellMouseClick += GrdUsers_CellMouseClick;
        }

        #endregion

        #region " Load Grid "

        public void LoadGrid()
        {
            GrdUsers.DataSource = null;

            var Svr = new Server();
            var Res = Svr.ToData("SELECT * FROM Sys_Users");

            if (Res.Success.Equals(false)) return;

            GrdUsers.DataSource = Res.Data as DataTable;
        }

        #endregion

        #region  " Event - Form "

        private void FrmUser_Load(object sender, EventArgs e)
        {
            LblEncoder.Text = Session.Currentuser.Username;
            LoadGrid();
        }

        #endregion

        #region " Event - Button "

        private void BtnUserCreate_Click(object sender, EventArgs e)
        {
            var Frm = new FrmDlgUsersCreate();

            if (Frm.ShowDialog() != DialogResult.OK) return;

            LoadGrid();
        }

        private void BtnUsersUpdate_Click(object sender, EventArgs e)
        {
            var Frm = new FrmDlgUsersUpdate(SelectedUser);

            if (Frm.ShowDialog() != DialogResult.OK) return;

            LoadGrid();
        }

        #endregion

        #region " Event - Grid "

        private void GrdUsers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                BtnUsersUpdate.Enabled = false;
                return;
            }
            SelectedUser = new User
            {
                ID = GrdUsers.Rows[e.RowIndex].Cells["PK_ID"].Value.ToString(),
                Name = GrdUsers.Rows[e.RowIndex].Cells["Name"].Value.ToString(),
                Username = GrdUsers.Rows[e.RowIndex].Cells["Username"].Value.ToString(),
                Password = GrdUsers.Rows[e.RowIndex].Cells["Password"].Value.ToString(),
                Status = GrdUsers.Rows[e.RowIndex].Cells["Status"].Value.ToString(),
                Last_Login = GrdUsers.Rows[e.RowIndex].Cells["Last_Login"].Value.ToString()
            };
            BtnUsersUpdate.Enabled = true;
        }


        #endregion


    }
}
