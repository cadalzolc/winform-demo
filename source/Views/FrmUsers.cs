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
        public FrmUser()
        {
            InitializeComponent();
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            LblEncoder.Text = Session.Currentuser.Username;
            LoadGrid();
        }


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
    }
}
