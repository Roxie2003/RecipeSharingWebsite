
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace RecipeSharing
{
    public class DisplayImage : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            Int32 recipeId;
            if (context.Request.QueryString["RecipeId"] != null)
                recipeId = Convert.ToInt32(context.Request.QueryString["RecipeId"]);
            else
                throw new ArgumentException("No parameter specified");

            context.Response.ContentType = "image/jpg";
            Stream strm = DisplayRecipeImage(recipeId);
            byte[] buffer = new byte[4096];
            int byteSeq = strm.Read(buffer, 0, 4096);

            while (byteSeq > 0)
            {
                context.Response.OutputStream.Write(buffer, 0, byteSeq);
                byteSeq = strm.Read(buffer, 0, 4096);
            }
            context.Response.BinaryWrite(buffer);
        }

        public Stream DisplayRecipeImage(int recipeId)
        {
            string conn = @"server=localhost;userid=root;password=;database=recipes";
            MySqlConnection connection = new MySqlConnection(conn);
            string sql = "select RecipeImage from recipes where RecipeId=@ID";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@ID", recipeId);
            connection.Open();
            object img = cmd.ExecuteScalar();
            try
            {
                return new MemoryStream((byte[])img);
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
    
}

