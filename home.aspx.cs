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
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {   using (MySqlConnection connection = new MySqlConnection(@"server=localhost;userid=root;password=;database=recipes"))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    if (Request.Form["search"] != null)
                    {
                        string SQL = "SELECT DISTINCT * FROM recipes Join users where recipes.CreatorId=users.UserId and (RecipeName LIKE '%" + Request.Form["search"] + "%' OR Description LIKE '%"+ Request.Form["search"] + "%')";
                        command.CommandText = SQL;
                        MySqlDataReader dr = command.ExecuteReader();
                        string searchresulthtml = " <form id='form1' runat='server' method='post' action='recipe.aspx'>"+
                            "<h3><b>Search Results For \"<u>" + Request.Form["search"] + "</u>\"</b></h3><hr><br>" +
                            "<div class='row' style='color:black;'>";
                        while (dr.Read())
                        {
                            byte[] bytes = (byte[])dr["RecipeImage"];
                            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            searchresulthtml = searchresulthtml + "<div class='col-sm-3' style='margin:15px 0px;'><button type='submit' class='recipe' formaction='recipe.aspx?recipeid=" + dr["RecipeId"]+"'>" +
                                "<img src='"+"data:image/png;base64,"+base64String+ "' width='280' height='220'><h4><b>" + dr["RecipeName"] + "</b></h4>" +
                                "<p>BY " + dr["Username"] + "</p>" +
                                "<i class='fa fa-thumbs-up fa-3' aria-hidden='true'> " + dr["Likes"] + " </i>" +
                                "</button></div>";
                        }
                        Content.InnerHtml = searchresulthtml + "</div></div><br><br></form>";
                        dr.Close();
                    }
                    else
                    {
                        string SQL = "SELECT * FROM recipes Join users where recipes.CreatorId=users.UserId Order By Likes Desc LIMIT 4 ";
                        command.CommandText = SQL;

                        MySqlDataReader dr = command.ExecuteReader();
                        string trendinghtml = " <h3 style='color:white;'><b>Trending</b></h3><br>";
                        while (dr.Read())
                        {
                            byte[] bytes = (byte[])dr["RecipeImage"];
                            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length); 
                            trendinghtml = trendinghtml + "<div class='col-sm-3' style='margin:15px 0px;'><button type='submit' class='recipe' formaction='recipe.aspx?recipeid=" + dr["RecipeId"] + "'>" +
                                "<img src='" + "data:image/png;base64," + base64String + "' width='280' height='220'><h4><b>" + dr["RecipeName"] + "</b></h4>" +
                                "<p>BY " + dr["Username"] + "</p>" +
                                "<i class='fa fa-thumbs-up fa-3' aria-hidden='true'> " + dr["Likes"] + " </i>" +
                                "</button></div>";
                        }
                        trending.InnerHtml = trendinghtml;
                        dr.Close();

                        string SQL2 = "SELECT * FROM recipes Join users where recipes.CreatorId=users.UserId Order By RecipeId Desc LIMIT 4";
                        command.CommandText = SQL2;
                        string latestCreationhtml = "<h3 style='color:white;'><b>Latest Creations</b></h3><br>";
                        dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            byte[] bytes = (byte[])dr["RecipeImage"];
                            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            latestCreationhtml = latestCreationhtml + "<div class='col-sm-3' style='margin:15px 0px;height:400px'><button type='submit' class='recipe' formaction='recipe.aspx?recipeid=" + dr["RecipeId"] + "'>" +
                                "<img src='"+"data:image/png;base64,"+base64String +"' width='280' height='220'><h4><b>" + dr["RecipeName"] + "</b></h4>" +
                                "<p>BY " + dr["Username"] + "</p>" +
                                "<i class='fa fa-thumbs-up fa-3' aria-hidden='true'> " + dr["Likes"] + " </i>" +
                                "</button></div>";
                        }
                        latestCreations.InnerHtml = latestCreationhtml;
                        dr.Close();
                        connection.Close();
                    }
                }
            }
            else
            {   Response.Write("<script>Alert('Sorry But not logged In!!');</script>");
                Response.Redirect("login.aspx");
            }
        }
    }
}