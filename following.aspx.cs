using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipeSharing
{
    public partial class following : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                using (MySqlConnection connection = new MySqlConnection(@"server=localhost;userid=root;password=;database=recipes"))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    string SQL = "Select Following from users where UserId=" + Session["id"];
                    command.CommandText = SQL;
                    MySqlDataReader dr = command.ExecuteReader();
                    dr.Read();
                    command = connection.CreateCommand();
                    SQL = "SELECT UserId,Username,ProfilePhoto FROM users where UserId in ('" + dr["Following"].ToString() + "')";
                    SQL = SQL.Replace("'", "");
                    SQL = SQL.Replace(",)", ")");
                    command.CommandText = SQL;
                    dr.Close();
                    dr = command.ExecuteReader();
                    string followinghtml = "";
                    while (dr.Read())
                    {
                        byte[] bytes = (byte[])dr["ProfilePhoto"];
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        followinghtml = followinghtml + "<button type='submit' formaction='othersProfile.aspx?id=" + dr["UserId"] + "'>" +
                            "<div class='col-sm-1'><img src = '" + "data:image/png;base64," + base64String + "' class='profileImg' alt='Image'></div>" +
                            "<div class='col-sm-9'><br><h4>"+dr["Username"]+"</h4></div>" +
                            "</button><br>";
                    }
                    followings.InnerHtml = followinghtml;
                    dr.Close();
                    connection.Close();
                }
            }
            else
            {
                Response.Write("<script>Alert('Sorry But not logged In!!');</script>");
                Response.Redirect("login.aspx");
            }
        }
    }
}