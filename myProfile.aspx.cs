using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipeSharing
{
    public partial class myProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                using (MySqlConnection connection = new MySqlConnection(@"server=localhost;userid=root;password=;database=recipes"))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    string SQL = "SELECT * FROM users where UserId="+Session["id"];
                    command.CommandText = SQL;
                    MySqlDataReader dr = command.ExecuteReader();
                    dr.Read();
                    byte[] bytes = (byte[])dr["ProfilePhoto"];
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    profilePhoto.ImageUrl = "data:image/png;base64," + base64String;
                    username.Text = dr["Username"].ToString();
                    Email.Text = dr["Email"].ToString();
                    if(!dr["Following"].ToString().Equals(""))
                    following.Text = "Following  "+dr["Following"].ToString().Split(',').Length.ToString();
                    dr.Close();
                    SQL = "Select Count(UserId) as Followers FROM Users where Following LIKE '%"+Session["id"]+"%'";
                    command.CommandText = SQL;
                    dr = command.ExecuteReader();
                    dr.Read();
                    followers.Text = "Followers  "+dr["Followers"].ToString();
                    dr.Close();
                    SQL = "Select Count(RecipeId) as Creations FROM Recipes where CreatorId="+ Session["id"];
                    command.CommandText = SQL;
                    dr = command.ExecuteReader();
                    dr.Read();
                    creations.Text = "Creations  " + dr["Creations"].ToString();
                    dr.Close();
                }
            }
            else
            {   Response.Write("<script>Alert('Sorry But not logged In!!');</script>");
                Response.Redirect("login.aspx");
            }
        }
    }
}