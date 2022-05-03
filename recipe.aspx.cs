using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipeSharing
{
    public partial class recipe : System.Web.UI.Page
    {
        private string creatorId;
        private string recipeId;
        private byte[] recipeImageByte;
        protected void Page_Load(object sender, EventArgs e)
        {   if (Session["id"] != null)
            {   using (MySqlConnection connection = new MySqlConnection(@"server=localhost;userid=root;password=;database=recipes"))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    string SQL = "SELECT * FROM recipes where RecipeId="+Request.QueryString["recipeid"];
                    command.CommandText = SQL;
                    MySqlDataReader dr = command.ExecuteReader();
                    dr.Read();
                    recipeImageByte = (byte[])dr["RecipeImage"];
                    string base64String = Convert.ToBase64String(recipeImageByte, 0, recipeImageByte.Length);
                    recipeImage.ImageUrl = "data:image/png;base64," + base64String;
                    recipeId = dr["RecipeId"].ToString();
                    RecipeName.Text = dr["RecipeName"].ToString();
                    description.Text = dr["Description"].ToString().Replace("\n", "<br>");
                    ingredients.Text = "<ul><li>"+dr["Ingredients"].ToString().Replace("\n", "</li><li>")+"</ul>";
                    directions.Text = dr["directions"].ToString().Replace("\n", "<br>");
                    if (Session["id"].Equals(dr["CreatorId"]))
                    {
                        EditBtn.Visible = true;
                        DelBtn.Visible = true;
                        CreatorInfo.Visible = false;
                    }
                    else {
                        CreatorInfo.Visible = true;
                        EditBtn.Visible = false;
                        DelBtn.Visible = false;
                    }
                    SQL = "SELECT UserId,Username,ProfilePhoto FROM users where UserId="+dr["CreatorId"];
                    dr.Close();
                    command.CommandText = SQL;
                    dr = command.ExecuteReader();
                    dr.Read();
                    byte[] bytes1 = (byte[])dr["ProfilePhoto"];
                    string base64String2 = Convert.ToBase64String(bytes1, 0, bytes1.Length);
                    profilePhoto.ImageUrl = "data:image/png;base64," + base64String2;
                    username.Text = dr["Username"].ToString();
                    creatorId = dr["UserId"].ToString();
                    dr.Close();
                    connection.Close();
                }
            }
            else
            {ScriptManager.RegisterStartupScript(this, this.GetType(),"alert", "alert('Sorry But not logged In');window.location ='login.aspx';", true);}
        }

        protected void BookmarkBtn_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(@"server=localhost;userid=root;password=;database=recipes"))
            {
                try
                {   connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    string SQL = "Update users set Bookmarks=concat(Bookmarks,'" + recipeId + ",')" + " where UserId=" + Session["id"];
                    command.CommandText = SQL;
                    command.ExecuteReader();
                    connection.Close();
                }
                catch (Exception ex)
                {Response.Write(ex+" ");}
            }
        }
        protected void goToProfileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("othersProfile.aspx?id="+creatorId);
        }

        protected void LikeBtn_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(@"server=localhost;userid=root;password=;database=recipes"))
            {
                try
                {   connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    string SQL = "Update recipes set Likes=Likes+1 where RecipeId=" + recipeId;
                    command.CommandText = SQL;
                    command.ExecuteReader();
                    connection.Close();
                }
                catch (Exception ex)
                {Response.Write(ex + " "); }
            }
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(@"server=localhost;userid=root;password=;database=recipes"))
            {
                try
                {   connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    string SQL = "Delete From Recipes where RecipeId=" + recipeId;
                    command.CommandText = SQL;
                    command.ExecuteReader();
                    connection.Close();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Deleted Successfully');window.location ='home.aspx';", true);
                }
                catch (Exception ex)
                {Response.Write(ex + " ");}
            }
        }

        protected void mailBtn_Click(object sender, EventArgs e)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                    sb.Append("<tr><td colspan = '2'><b>Recipe Name : </b> " + RecipeName.Text + "</td></tr>");
                    sb.Append("<tr><td colspan = '2'><b>Description : </b><br>" + description.Text+"</td></tr>");
                    sb.Append("<tr><td colspan = '2'><b>Ingredients : </b><br> " + ingredients.Text + "</td></tr>");
                    sb.Append("<tr><td colspan = '2'><b>Directions : </b><br> " + directions.Text + "</td></tr>");
                    sb.Append("</table>");
                    StringReader sr = new StringReader(sb.ToString());

                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        byte[] bytes = memoryStream.ToArray();
                        memoryStream.Close();
                        MailMessage mm = new MailMessage(Session["email"].ToString(), receiverEmail.Value);
                        mm.Subject = RecipeName.Text+" recipe";
                        mm.Body = "Have a look at the Recipe";
                        mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "Recipe.pdf"));
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential();
                        NetworkCred.UserName = Session["email"].ToString();
                        NetworkCred.Password = "Roxanne15@7588617216";
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Recipe has been sent to mail successfully');", true);
                    }
                }
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("createRecipe.aspx?recipeid="+Request.QueryString["recipeid"]);
        }
    }
}