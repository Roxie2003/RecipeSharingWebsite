using MySqlConnector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipeSharing
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void signupBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (MySqlConnection connection = new MySqlConnection(@"server=localhost;userid=root;password=;database=recipes"))
                {
                    connection.Open();
                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        string SQL = "SELECT * FROM Users where Username='" + your_name.Text + "' and Password='" + your_pass.Text + "'";
                        command.CommandText = SQL;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.Read())
                        {ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('User already exists');window.location ='login.aspx';", true);}
                        else
                        {
                            dr.Close();
                            string contentType = FileUpload1.PostedFile.ContentType;
                            Stream fs = FileUpload1.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            byte[] bytes = br.ReadBytes((Int32)fs.Length);

                            SQL = "INSERT INTO `users` (`Username`, `Email`,`Password`,`ProfilePhoto`) VALUES (@Username, @Email,@Password, @ProfilePhoto)";
                            command.CommandText = SQL;
                            command.Parameters.AddWithValue("@Username", your_name.Text);
                            command.Parameters.AddWithValue("@Email", your_email.Text);
                            command.Parameters.AddWithValue("@Password", your_pass.Text);
                            command.Parameters.AddWithValue("@ProfilePhoto", bytes);
    
                            try
                            {
                                command.ExecuteNonQuery();
                                SQL = "SELECT * FROM Users where Username='" + your_name.Text + "' and Password='" + your_pass.Text + "'";
                                command.CommandText = SQL;
                                dr = command.ExecuteReader();

                                if (dr.Read())
                                {   Session["email"] = dr["Email"].ToString();
                                    Session["id"] = dr["UserId"];
                                    Response.Redirect("home.aspx");
                                }
                                else
                                { ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Incorrect Credentials');window.location ='login.aspx';", true);}
                            }
                            catch (Exception ex)
                            {ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Failed to Create User');window.location ='signup.aspx';", true); ;}
                            finally
                            {connection.Close();}
                        }
                    }
                }
            }
        }
    }
}