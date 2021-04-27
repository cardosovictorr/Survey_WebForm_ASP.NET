using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _6930_Survey_Web_Application.Model;
using System.Configuration;
using System.Data.SqlClient;

namespace _6930_Survey_Web_Application
{
    public partial class EndOfSurvey : System.Web.UI.Page
    {
        private static string connectionStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        List<QuestionAnswers> questionAnswersInSession = null;
        //List<Users_Respondents> respondentsAnswersInSession = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            questionAnswersInSession = (List<QuestionAnswers>)Session["Question_ANSWER_LIST"];

            //respondentsAnswersInSession = (List<Users_Respondents>)Session["Question_ANSWER_LIST"];

            //foreach (Users_Respondents answers in respondentsAnswersInSession)
            //{
            //    TableRow row = new TableRow();
            //
            //
            //
            //}
            //
            foreach (QuestionAnswers answers in questionAnswersInSession)
            {
                TableRow row = new TableRow();

                //QUestions id will be here
                TableCell questionIdCell = new TableCell();

                //setting question id of the answer to table cell
                questionIdCell.Text = answers.Q_id.ToString();
                row.Cells.Add(questionIdCell);

                //Question answer text cell her:
                TableCell answerTextCell = new TableCell();
                answerTextCell.Text = answers.Option_text;
                row.Cells.Add(answerTextCell);

                TableCell optionIdCell = new TableCell();
                if(answers.Option_id != null)
                {
                    optionIdCell.Text = answers.Option_id.ToString();
                }
                else
                {
                    optionIdCell.Text = "";
                }

                row.Cells.Add(optionIdCell);

                quastionAnswerDisplayTable.Rows.Add(row);
            }
        }

        private void saveAnswersData(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                String query = "INSERT INTO Users_Respondents (user_first_name, user_last_name, user_gender, user_state,user_post_code,user_bank_user_newspaper, user_bank_services, user_news_interests, user_age, user_email, user_bank_used) VALUES (@user_first_name, @user_last_name, @user_gender, @user_state, @user_post_code, @user_bank_user_newspaper, @user_bank_services, @user_news_interests, @user_age, @user_email, @user_bank_used)";
                connection.Open();

                foreach (QuestionAnswers answers in questionAnswersInSession)
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@questionId", answers.Q_id);

                        if (answers.Option_id == null)
                        {
                            command.Parameters.AddWithValue("@optionId", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@optionId", answers.Option_id);
                        }

                        if (answers.Option_text == null)
                        {
                            command.Parameters.AddWithValue("@optionText", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@optionText", answers.Option_text);
                        }

                        int result = command.ExecuteNonQuery();
                        if (result < 0)
                        {
                            Console.WriteLine("The data have not been inserted in the Database!");
                            LabelMessage.Text = "The data have not been inserted in the Database!";
                        }

                    }
                }

            }
        }

        protected void ButtonSaveSurvey_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                String query = "INSERT INTO Question_Answers (option_text, q_id, option_id) VALUES (@optionText, @questionId, @optionId)";
                connection.Open();

                foreach (QuestionAnswers answers in questionAnswersInSession)
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@questionId", answers.Q_id);

                        if (answers.Option_id == null)
                        {
                            command.Parameters.AddWithValue("@optionId", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@optionId", answers.Option_id);
                        }

                        if (answers.Option_text == null)
                        {
                            command.Parameters.AddWithValue("@optionText", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@optionText", answers.Option_text);
                        }

                        int result = command.ExecuteNonQuery();
                        if (result < 0)
                        {
                            Console.WriteLine("The data have not been inserted in the Database!");
                            LabelMessage.Text = "The data have not been inserted in the Database!";
                        }

                    }
                }

            }
        }
    }
}