using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cadalzo.demo
{
    public class Server
    {

        public string ConnectionString => "SERVER=.;DATABASE=urapz_test;UID=sa;PWD=P@ssw0rd;Persist Security Info=True";

        #region " Connection "

        public SqlConnection Connection
        {
            get
            {
                try
                {
                    var Con = new SqlConnection(ConnectionString);
                    Con.Open();
                    return Con;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        #endregion

        #region " Test "

        public void Test()
        {
            try
            {
                var Con = new SqlConnection(ConnectionString);
                Con.Open();
                Con.Close();
                MessageBox.Show("Connected!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region " To Data "

        public Response ToData(string Query)
        {
            try
            {
                using(var Con = Connection)
                {
                    var DT = new DataTable();
                    var DA = new SqlDataAdapter(Query, Connection);
                    DA.Fill(DT);
                    return new Response("Success", true, DT);
                }
            }
            catch (Exception ex)
            {
                return new Response(ex.Message);
            }
        }

        public Response ToData(SqlCommand Cmd)
        {
            try
            {
                var DT = new DataTable();
                var DA = new SqlDataAdapter(Cmd);
                DA.Fill(DT);
                return new Response("Success", true, DT);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message);
            }
        }

        #endregion

    }
}
