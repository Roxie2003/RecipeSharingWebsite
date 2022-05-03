using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using MySqlConnector;

namespace RecipeSharing
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void signin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (MySqlConnection connection = new MySqlConnection(@"server=localhost;userid=root;password=;database=recipes"))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    string SQL = "SELECT * FROM Users where Username='" + your_name.Text + "' and Password='" + your_pass.Text + "'";
                    command.CommandText = SQL;
                    MySqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {   Session["email"] = dr["Email"].ToString();
                        Session["id"] = dr["UserId"];
                        Response.Redirect("home.aspx");
                    }
                    else
                    {Response.Write("<script>Alert('Incorrect Credentials or User doesn't exist');</script>");}
                    dr.Close();
                    connection.Close();
                }
            }
        }
    }
}