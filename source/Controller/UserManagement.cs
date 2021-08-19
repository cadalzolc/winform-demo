﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cadalzo.demo
{
    public class UserManagement
    {

        #region " Login "

        public Response Login(string User, string Pass)
        {
            try
            {
                var Svr = new Server();
                using (var Con = Svr.Connection)
                {
                    using (var Cmd = new SqlCommand("SP_Sys_User_Login", Con))
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;

                        Cmd.Parameters.Add("@Username", SqlDbType.VarChar, 35);
                        Cmd.Parameters.Add("@Password", SqlDbType.VarChar, 35);
                        Cmd.Parameters.Add("@Err", SqlDbType.VarChar, 300);

                        Cmd.Parameters["@Err"].Direction = ParameterDirection.InputOutput;

                        Cmd.Parameters["@Username"].Value = User;
                        Cmd.Parameters["@Password"].Value = User;
                        Cmd.Parameters["@Err"].Value = "";

                        Cmd.ExecuteNonQuery();

                        var Err = Cmd.Parameters["@Err"].Value.ToString();

                        if (!Err.Equals("")) return new Response(Err);

                        var Res = Svr.ToData(Cmd);

                        if (Res.Success.Equals(false)) new Response(Res.Message);

                        var Row = (Res.Data as DataTable).Rows[0];
                        var Model = new User() 
                        {
                            ID = Row["PK_ID"].ToString(),
                            Username = User,
                            Password = Pass,
                            Name = Row["Name"].ToString(),
                            Status = Row["Status"].ToString(),
                            Last_Login = Row["Last_Login"].ToString(),
                        };

                        return new Response("Login", true, Model);
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response(ex.Message);
            }

        }

        #endregion

    }
}
