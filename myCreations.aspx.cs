using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipeSharing
{
    public partial class myCreations : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                using (MySqlConnection connection = new MySqlConnection(@"server=localhost;userid=root;password=;database=recipes"))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    string SQL = "SELECT * FROM recipes where CreatorId="+Session["id"];
                    command.CommandText = SQL;

                    MySqlDataReader dr = command.ExecuteReader();
                    string creationshtml = "";
                    while (dr.Read())
                    {
                        byte[] bytes = (byte[])dr["RecipeImage"];
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        creationshtml = creationshtml + "<div class='col-sm-3'><button type='submit' class='recipe' formaction='recipe.aspx?recipeid=" + dr["RecipeId"] + "'>" +
                            "<img src='" + "data:image/png;base64," + base64String + "' width='280' height='220'><h4><b>" + dr["RecipeName"] + "</b></h4>" +
                            "<i class='fa fa-thumbs-up fa-3' aria-hidden='true'> " + dr["Likes"] + " </i>" +
                            "</button></div>";
                    }
                    creations.InnerHtml = creationshtml;
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