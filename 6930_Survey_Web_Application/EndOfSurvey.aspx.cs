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


        //ADDING A NEW OBJECT HERE FOR USER REPONDENTS TABLE
        //Here I am creating a object in my class User Respondets to use it later
        Users_Respondents responses = new Users_Respondents();
        protected void Page_Load(object sender, EventArgs e)
        {
            questionAnswersInSession = (List<QuestionAnswers>)Session["Question_ANSWER_LIST"];
            try
            {
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


                    if (answers.Q_id == 1)
                    {
                        responses.User_first_name = answers.Option_text;
                        //respondentsAnswersInSession.Add(text_response);
                    }
                    else if (answers.Q_id == 2)
                    {
                        responses.User_state = answers.Option_text;
                        //respondentsAnswersInSession.Add(responses);
                    }
                    else if (answers.Q_id == 3)
                    {
                        responses.User_gender = answers.Option_text;
                        //respondentsAnswersInSession.Add(responses);
                    }
                    else if (answers.Q_id == 4)
                    {
                        responses.User_post_code = answers.Option_text;
                        //respondentsAnswersInSession.Add(responses);
                    }
                    else if (answers.Q_id == 5)
                    {
                        responses.User_age = answers.Option_text;
                        //respondentsAnswersInSession.Add(responses);
                    }
                    else if (answers.Q_id == 6)
                    {
                        responses.User_email = answers.Option_text;
                        //respondentsAnswersInSession.Add(responses);
                    }
                    else if (answers.Q_id == 7)
                    {
                        responses.User_bank = answers.Option_text;
                        //respondentsAnswersInSession.Add(responses);
                    }
                    else if (answers.Q_id == 8)
                    {
                        responses.User_bank_services = answers.Option_text;
                        //respondentsAnswersInSession.Add(responses);
                    }
                    else if (answers.Q_id == 9)
                    {
                        responses.User_newspaper = answers.Option_text;
                        //respondentsAnswersInSession.Add(responses);
                    }

                    TableCell optionIdCell = new TableCell();
                    if (answers.Option_id != null)
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
            //this error is in case there is no answers from the user. 
            catch (NullReferenceException nrex)
            {
                
                questionAnswersInSession = new List<QuestionAnswers>();
            }
            //if the error is not handled before (e.g: nullReference) the error will be handle in the following:
            catch(Exception ex) 
            {
                //ex.Message
                return;
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
                String query = "INSERT INTO Users_Respondents (user_first_name, user_gender, user_state, user_post_code, user_bank, user_newspaper, user_bank_services, user_age, user_email) VALUES (@user_first_name, @user_gender, @user_state, @user_post_code, @user_bank, @user_newspaper, @user_bank_services, @user_age, @user_email)";
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@user_first_name", responses.User_first_name);
                    command.Parameters.AddWithValue("@user_gender", responses.User_gender);
                    command.Parameters.AddWithValue("@user_state", responses.User_state);
                    command.Parameters.AddWithValue("@user_post_code", responses.User_post_code);
                    command.Parameters.AddWithValue("@user_bank", responses.User_bank);
                    command.Parameters.AddWithValue("@user_newspaper", responses.User_newspaper);
                    command.Parameters.AddWithValue("@user_bank_services", responses.User_bank_services);
                    command.Parameters.AddWithValue("@user_age", responses.User_age);
                    command.Parameters.AddWithValue("@user_email", responses.User_email);


                    int result = command.ExecuteNonQuery();
                    if (result < 0)
                    {
                        Console.WriteLine("The data have not been inserted in the Database!");
                        LabelMessage.Text = "The data have not been inserted in the Database!";
                    }
                }

            }

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
                        //checking with error handling if the data has been saved properly
                        try
                        {
                            int result = command.ExecuteNonQuery();
                            if (result < 0)
                            {
                                Console.WriteLine("The data have not been inserted in the Database!");
                                LabelMessage.Text = "The data have not been inserted in the Database!";
                            }
                        }
                        catch (Exception ex)
                        {
                            string messageError = ex.Message;
                            Console.WriteLine("The database has an issue " + messageError);

                        }
                        

                    }
                }

            }
            Response.Redirect("UserRegistration.aspx");
        }
    }
}