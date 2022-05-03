using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.IO;
using MySqlConnector;

namespace RecipeSharing
{
    public partial class createRecipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                if (Request.QueryString["recipeid"] != null)
                {
                    using (MySqlConnection connection = new MySqlConnection(@"server=localhost;userid=root;password=;database=recipes"))
                    {
                        header.InnerText = "Edit Recipe";
                        connection.Open();
                        MySqlCommand command = connection.CreateCommand();
                        string SQL = "SELECT * FROM recipes where RecipeId=" + Request.QueryString["recipeid"];
                        command.CommandText = SQL;
                        MySqlDataReader dr = command.ExecuteReader();
                        dr.Read();
                        byte[] bytes = (byte[])dr["RecipeImage"];
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        frame.ImageUrl = "data:image/png;base64," + base64String;
                        recipeName.Text = dr["RecipeName"].ToString();
                        description.Text = dr["Description"].ToString();
                        ingredients.Text = dr["Ingredients"].ToString();
                        directions.Text = dr["Directions"].ToString();
                    }
                }
            }
            else
            {Response.Redirect("login.aspx");}
        }
        protected void createRecipeBtn_Click(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                using (MySqlConnection connection = new MySqlConnection(@"server=localhost;userid=root;password=;database=recipes"))
                {connection.Open();
                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        if (Request.QueryString["recipeid"] != null)
                        {   string contentType = FileUpload1.PostedFile.ContentType;
                            Stream fs = FileUpload1.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            
                            string SQL = "Update recipes set RecipeName=@RecipeName,RecipeImage=@Photo,Description=@Description," +
                                "Ingredients=@Ingredients,Directions=@Directions where RecipeId=@RecipeId";
                            command.CommandText = SQL;
                            command.Parameters.AddWithValue("@RecipeName", recipeName.Text);
                            command.Parameters.AddWithValue("@Photo", bytes);
                            command.Parameters.AddWithValue("@Description", description.Text);
                            command.Parameters.AddWithValue("@Ingredients", ingredients.Text);
                            command.Parameters.AddWithValue("@Directions", directions.Text);
                            command.Parameters.AddWithValue("@RecipeId",Request.QueryString["recipeid"]);
                            command.ExecuteReader();
                            connection.Close();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Recipe edited Successfully');window.location ='home.aspx';", true);
                        }
                        else
                        {
                            string contentType = FileUpload1.PostedFile.ContentType;
                            Stream fs = FileUpload1.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            string SQL = "INSERT INTO `recipes` (`RecipeName`, `RecipeImage`,`Description`,`Ingredients`, `Directions`,`CreatorId`) VALUES (@RecipeName, @Photo,@Description, @Ingredients, @Directions,@CreatorId)";
                            command.CommandText = SQL;
                            command.Parameters.AddWithValue("@RecipeName", recipeName.Text);
                            command.Parameters.AddWithValue("@Photo", bytes);
                            command.Parameters.AddWithValue("@Description", description.Text);
                            command.Parameters.AddWithValue("@Ingredients", ingredients.Text);
                            command.Parameters.AddWithValue("@Directions", directions.Text);
                            command.Parameters.AddWithValue("@CreatorId", Session["Id"]);

                            try
                            {   command.ExecuteNonQuery();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Recipe Created Successfully');window.location ='home.aspx';", true);
                            }
                            catch (Exception ex)
                            {ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed to Create Recipe');window.location ='home.aspx';", true);}
                            finally
                            {connection.Close();}
                        }
                    }
                }
            }
            else
            {Response.Redirect("login.aspx");}
        }
    }
}