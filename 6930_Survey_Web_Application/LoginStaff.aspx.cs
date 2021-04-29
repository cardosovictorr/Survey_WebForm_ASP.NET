using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace _6930_Survey_Web_Application
{
    public partial class LoginStaff : System.Web.UI.Page
    {
        private static string connectionStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void enterButton_Click(object sender, EventArgs e)
        {
            //get input from the user
            string staffNameInput = UserNameTextBox.Text;
            string staffPassInput = passwordTextBox.Text;

            //check if username and password are correct
            //send to the search page

            //checkStaff(staffNameInput, staffPassInput);
            
            Response.Redirect("Search.aspx");
        }

        private void checkStaff(string username, string password)
        {
            
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Parent WHERE [staff_name]=@staffName AND [staff_pass]=@password", conn);
                conn.Open();

                cmd.Parameters.AddWithValue("@staffName", username);
                cmd.Parameters.AddWithValue("@password", password);

                //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //DataTable table

                //int result = cmd.ExecuteNonQuery();

                //SqlDataReader dr = cmd.ExecuteReader();

                //if (dr.Read())
                //{
                //    conn.Close();
                //    dr.Close();
                //    Response.Redirect("Search.aspx");
                //}
                //else
                //{
                //    errorStaffLabel.Text = "Invalid User! Try again with VALID username and password";
                //}
                //if (!dr.IsClosed)
                //    dr.Close();

                //if (result < 0)
                //{
                //    Console.WriteLine("The data have not been inserted in the Database!");
                //    errorStaffLabel.Text = "The data have not been inserted in the Database!";
                //} else
                //{
                //    Response.Redirect("Search.aspx");
                //}

                conn.Close();


            }
        }
    }
}