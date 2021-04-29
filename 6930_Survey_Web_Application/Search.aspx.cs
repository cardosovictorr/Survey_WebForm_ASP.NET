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
    public partial class Search : System.Web.UI.Page
    {
        private static string connectionStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //getQuestionData("state");
        }

        private void getQuestionData(string searchText)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand("Select * from Question where question_text like @option_text", conn);
                cmd.Parameters.AddWithValue("option_text", "%" + searchText + "%");

                conn.Open();

                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }

        private void getAnswersData(string searchText)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand("Select * from Users_Respondents where user_state like @option_text", conn);
                cmd.Parameters.AddWithValue("option_text", "%" + searchText + "%");

                conn.Open();

                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
                
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            string inputFromUser = UserSearchText.Text;
            getQuestionData(inputFromUser);
        }

        protected void searchInResponsesButton_Click(object sender, EventArgs e)
        {
            string inputFromUser = byResponsesTextBox.Text;
            getAnswersData(inputFromUser);
        }
    }
}