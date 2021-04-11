using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using _6930_Survey_Web_Application.Model;

namespace _6930_Survey_Web_Application
{
    public partial class Home : System.Web.UI.Page
    {
        private static string connectionStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Stack<int> followupQuestions = (Stack<int>)Session["FOLLOWUP_ID_LIST"];
            int currentQuestionIdInSession = 1;

            //in case its the very first time of the connection, we have to start the stack. So we create a stack session
            if (followupQuestions == null)
            {
                followupQuestions = new Stack<int>();
                followupQuestions.Push(1);
                Session["FOLLOWUP_ID_LIST"] = followupQuestions;
            }
            else if (followupQuestions.Count()>0)
            {
                currentQuestionIdInSession = followupQuestions.Peek();
            }

            Question question = getNextQuestion(currentQuestionIdInSession);

            if (question != null)
            {
                QuestionText.Text = question.Question_text;
            }
        }
        private Question getNextQuestion(int currentQuestionId)
        {
            Question que = null;
            
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                //conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Question where Id =" + currentQuestionId, conn);
                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    que = new Question();
                    que.Question_text = rd["question_text"].ToString();
                    que.Question_type = rd["question_type"].ToString();
                    que.Next_q_id = rd["next_q_id"] as int?;
                }
                //conn.Close();
            }
            return que;
        }

        protected void NextQuestionButton_Click(object sender, EventArgs e)
        {
            Stack<int> followUpQuestionList = (Stack<int>)Session["FOLLOWUP_ID_LIST"];

            int currentQuestionIdInSession = followUpQuestionList.Pop();
            Question question = getNextQuestion(currentQuestionIdInSession);

            if (question.Next_q_id != null)
            {
                insertNextQuestionId((int)question.Next_q_id, followUpQuestionList);
            }

            if (question != null)
            {
                QuestionText.Text = question.Question_text;

                if (question.Question_type.Equals("text"))
                {
                    TextBox textBox = new TextBox();
                    textBox.ID = "AnswerTxtBox";
                    PlaceHolder1.Controls.Add(textBox);
                    //Session["CURRENT_QUESTION_TYPE"] = textBox.ID;
                    
                }
                else if(question.Question_type.Equals("radio"))
                {
                    RadioButtonList radioBtnQuestion = new RadioButtonList();
                    radioBtnQuestion.ID = "RadioButton";
                    //Session["CURRENT_QUESTION_TYPE"] = radioBtnQuestion.ID;
                    
                    List<QuestionOption> questionOptions = getQuestionOptions(currentQuestionIdInSession);

                    foreach (QuestionOption option in questionOptions)
                    {
                        ListItem newItem = new ListItem();
                        newItem.Text = option.Option_text;
                        radioBtnQuestion.Items.Add(newItem);
                        //radioBtnQuestion.getControl().Items.Add(newItem);
                    }
                    PlaceHolder1.Controls.Add(radioBtnQuestion);
                }
                else if (question.Question_type.Equals("checkbox"))
                {
                    CheckBoxList checkBoxQuestion = new CheckBoxList();
                    checkBoxQuestion.ID = "CheckBoxButton";
                    //Session["CURRENT_QUESTION_TYPE"] = checkBoxQuestion.ID;

                    List<QuestionOption> questionOptions = getQuestionOptions(currentQuestionIdInSession);

                    foreach (QuestionOption option in questionOptions)
                    {
                        ListItem newItem = new ListItem();
                        newItem.Value = option.Id.ToString();
                        newItem.Text = option.Option_text;
                        if (option.Next_q_id != null)
                        {
                            newItem.Attributes["nextQuestionId"] = option.Next_q_id.ToString();
                        }
                        checkBoxQuestion.Items.Add(newItem);
                        //checkBoxQuestion.getControl().Items.Add(newItem);
                    }
                    PlaceHolder1.Controls.Add(checkBoxQuestion);
                }
            }
        }
        private void insertNextQuestionId(int nextQuestionId, Stack<int> followupList)
        {
            if (!followupList.Contains(nextQuestionId))
            {
                followupList.Push(nextQuestionId);
            }
        }

        private List<QuestionOption> getQuestionOptions(int currentQuestionId)
        {
            List<QuestionOption> options = new List<QuestionOption>();

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand("select * from Question_Options where q_id =" + currentQuestionId, conn);
                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                QuestionOption opt = null;

                while (rd.Read())
                {
                    opt = new QuestionOption();
                    opt.Id = (int)rd["id"];
                    opt.Option_text = rd["option_text"].ToString();
                    opt.Next_q_id = rd["next_q_id"] as int?;
                    options.Add(opt);
                }
            }
            return options;
                
        }
    }
}