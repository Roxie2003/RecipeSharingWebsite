using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipeSharing
{
    public partial class bookmarks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                using (MySqlConnection connection = new MySqlConnection(@"server=localhost;userid=root;password=;database=recipes"))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    string SQL = "Select Bookmarks from users where UserId="+Session["id"];
                    command.CommandText = SQL;
                    MySqlDataReader dr = command.ExecuteReader();
                    dr.Read();
                    command = connection.CreateCommand();
                    SQL = "SELECT * FROM recipes Join users where recipes.CreatorId=users.UserId and RecipeId in ('"+dr["Bookmarks"].ToString()+"')";
                    SQL = SQL.Replace("'", "");
                    SQL = SQL.Replace(",)", ")");
                    command.CommandText = SQL;

                    dr.Close();
                    dr = command.ExecuteReader();
                    string bookmarkhtml = "";
                    while (dr.Read())
                    {
                        byte[] bytes = (byte[])dr["RecipeImage"];
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        bookmarkhtml =bookmarkhtml+ "<div class='col-sm-3'><button type='submit' class='recipe' formaction='recipe.aspx?recipeid=" + dr["RecipeId"] + "'>" +
                            "<img src='" + "data:image/png;base64," + base64String + "' width='280' height='220'><h4><b>" + dr["RecipeName"] + "</b></h4>" +
                            "<p>" + dr["Username"] + "</p>" +
                            "<i class='fa fa-thumbs-up fa-3' aria-hidden='true'> " + dr["Likes"] + " </i>" +
                            "</button></div>";
                    }
                    bookmark.InnerHtml = bookmarkhtml;
                    dr.Close();
                    connection.Close();
                }
            }
            else
            {   Response.Write("<script>Alert('Sorry But not logged In!!');</script>");
                Response.Redirect("login.aspx");
            }
        }
    }
}