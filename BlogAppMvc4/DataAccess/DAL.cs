using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BlogAppMvc4.DataAccess
{
    public class DAL
    {
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyBlogContext"].ToString());

        public static bool UserIsValid(string username, string password)
        {
            bool authenticated = false;

            string query = string.Format("SELECT * FROM [Registers] WHERE Email = '{0}' AND Password = '{1}'", username, password);

            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            //while (sdr.Read())
            //{
            //    Class1.userid = sdr["UserID"].ToString();
            //}
            authenticated = sdr.HasRows;
            conn.Close();
            return (authenticated);
        }
    }
}