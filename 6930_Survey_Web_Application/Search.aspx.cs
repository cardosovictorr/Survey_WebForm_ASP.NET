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
            typeTableLabel.Text = "QUESTIONS TABLE";

        }

        private void getAnswersData(string searchText)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand("Select * from Users_Respondents where user_first_name like @option_text", conn);
                cmd.Parameters.AddWithValue("option_text", "%" + searchText + "%");

                conn.Open();

                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
            typeTableLabel.Text = "ANSWERS TABLE";
        }

        private void getStateData(string searchText)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand("Select * from Users_Respondents where user_state like @option_text", conn);
                cmd.Parameters.AddWithValue("option_text", "%" + searchText + "%");

                conn.Open();

                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
            typeTableLabel.Text = "ANSWERS TABLE";
        }

        private void getRegisteredData(string searchText)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand("Select * from User_Registration where user_name like @option_text", conn);
                cmd.Parameters.AddWithValue("option_text", "%" + searchText + "%");

                conn.Open();

                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
            typeTableLabel.Text = "REGISTERED USERS TABLE";
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            string inputFromUser = UserSearchText.Text;
            getQuestionData(inputFromUser);
            UserSearchText.Text = string.Empty;
        }

        protected void searchInResponsesButton_Click(object sender, EventArgs e)
        {
            string inputFromUser = byResponsesTextBox.Text;
            getAnswersData(inputFromUser);
            byResponsesTextBox.Text = string.Empty;
        }

        protected void searchByStateButton_Click(object sender, EventArgs e)
        {
            string inputFromUser = byStatesTextBox.Text;
            getStateData(inputFromUser);
            byStatesTextBox.Text = string.Empty;
        }

        protected void byRegisteredButton_Click(object sender, EventArgs e)
        {
            string inputFromUser = byRegisterTextBox.Text;
            getRegisteredData(inputFromUser);
            byRegisterTextBox.Text = string.Empty;
        }

        protected void allQuestionButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand("Select * from Question", conn);
                //cmd.Parameters.AddWithValue("option_text", "%" + searchText + "%");

                conn.Open();

                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
            typeTableLabel.Text = "QUESTIONS TABLE";
        }

        protected void seeAllAnswersButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand("Select * from Users_Respondents", conn);
                //cmd.Parameters.AddWithValue("option_text", "%" + searchText + "%");

                conn.Open();

                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
            typeTableLabel.Text = "ANSWERS TABLE";
        }

        protected void seeAllRegisteredButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand("Select * from User_Registration", conn);
                //cmd.Parameters.AddWithValue("option_text", "%" + searchText + "%");

                conn.Open();

                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
            typeTableLabel.Text = "REGISTERED USERS TABLE";
        }
    }
}