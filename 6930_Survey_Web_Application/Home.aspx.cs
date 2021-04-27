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
            else if (followupQuestions.Count() > 0)
            {
                currentQuestionIdInSession = followupQuestions.Peek();
            }

            Question question = getNextQuestion(currentQuestionIdInSession);

            //for debugging purpose
            //AnswerSelectedByUser.Text = question.ToString();

            if (question != null)
            {
                QuestionText.Text = question.Question_text;

                //here

                if (question.Question_type.Equals("text"))
                {
                    TextBox textBox = new TextBox();
                    //Creating a box control for the text box
                    textBox.ID = "AnswerTxtBox";
                    PlaceHolder1.Controls.Add(textBox);
                    Session["CURRENT_QUESTION_TYPE"] = textBox.ID;
                }
                else if (question.Question_type.Equals("radio"))
                {
                    //Creating radio buttom question control
                    RadioButtonList radioBtnQuestion = new RadioButtonList();
                    //RadioButtonUserControl
                    //RadioButtonUserCOntrol
                    radioBtnQuestion.ID = "RadioButton";
                    //RadioButtonList
                    Session["CURRENT_QUESTION_TYPE"] = radioBtnQuestion.ID;

                    List<QuestionOption> questionOptions = getQuestionOptions(currentQuestionIdInSession);

                    foreach (QuestionOption option in questionOptions)
                    {
                        ListItem newItem = new ListItem();
                        newItem.Text = option.Option_text;
                        newItem.Value = option.Id.ToString();
                        radioBtnQuestion.Items.Add(newItem);
                        //radioBtnQuestion
                    }

                    PlaceHolder1.Controls.Add(radioBtnQuestion);

                }
                else if (question.Question_type.Equals("checkbox"))
                {
                    //creating checkbox question controls
                    CheckBoxList checkBoxQuestion = new CheckBoxList();
                    //CheckBoxUserControl
                    checkBoxQuestion.ID = "CheckBoxButton";
                    Session["CURRENT_QUESTION_TYPE"] = checkBoxQuestion.ID;
                    //CheckBoxList
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
                        //checkBoxQuestion
                    }
                    PlaceHolder1.Controls.Add(checkBoxQuestion);
                    //here
                }
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
            //HERE

            //Access the actual question from the Placeholder
            Control userControl = PlaceHolder1.FindControl(Session["CURRENT_QUESTION_TYPE"].ToString());

            //Access question answers from session:
            List<QuestionAnswers> questionAnswersInSession = (List<QuestionAnswers>)Session["Question_ANSWER_LIST"];
            if (questionAnswersInSession == null)
            {
                //Null is when the first question is the first one, so we create a new question ansewr list:
                questionAnswersInSession = new List<QuestionAnswers>();
                Session["Question_ANSWER_LIST"] = questionAnswersInSession;
            }

            //HERE CLOSE

            Stack<int> followUpQuestionList = (Stack<int>)Session["FOLLOWUP_ID_LIST"];

            int currentQuestionIdInSession = followUpQuestionList.Pop();
            Question question = getNextQuestion(currentQuestionIdInSession);
            if (question.Next_q_id != null)
            {
                //followUpQuestionList.Push((int)question.nextQuestionId);
                insertNextQuestionId((int)question.Next_q_id, followUpQuestionList);
            }


            //HERE

            //if (userControl is TextBoxUserControl)
            if (userControl is TextBox)
            {
                //TextBoxUserCOnttrol textBoxcontr = (TextBoxUserControl)userControl;
                TextBox textBoxcontr = (TextBox)userControl;
                //Label1.Text = textBoxcontr.getControl().Text;
                //Session["UserAnswer"] = textBoxcontr.getControl().Text;
                Session["UserAnswer"] = textBoxcontr.Text;
                //System.Diagnostics.Debug.WriteLine("Answer = " + textBoxcontr.getControl().Text);
                System.Diagnostics.Debug.WriteLine("Answer = " + textBoxcontr.Text);

                //HERE ARE THE ANSWER OF THE USERS:
                QuestionAnswers answer = new QuestionAnswers();
                //answer.Option_text = textBoxcontr.getControl().Text;
                answer.Option_text = textBoxcontr.Text;
                answer.Q_id = currentQuestionIdInSession;

                questionAnswersInSession.Add(answer);
            }
            //else if (userControl is CheckBoxUserControl)
            else if (userControl is CheckBoxList)
            {
                //CheckBoxUserCOntrol checkBoxcontr = (checkBoxUserControl)userControl;
                CheckBoxList checkBoxcontr = (CheckBoxList)userControl;
                string answerVar = "";
                //foreach (ListItem item in checkBoxcontr.getControl().Items)
                foreach (ListItem item in checkBoxcontr.Items)
                {
                    if (item.Selected)
                    {
                        answerVar += item.Text + ",";

                        if (item.Attributes["nextQuestionId"] != null)
                        {
                            //followUpQuestion
                            insertNextQuestionId(int.Parse(item.Attributes["nextQuestionId"]), followUpQuestionList);
                        }

                        QuestionAnswers answer = new QuestionAnswers();
                        answer.Option_text = item.Text;
                        answer.Q_id = currentQuestionIdInSession;
                        answer.Option_id = int.Parse(item.Value);

                        questionAnswersInSession.Add(answer);
                    }
                }

                Session["UserAnswer"] = answerVar;
            }
            else
            {
                //CheckBoxUserCOntrol checkBoxcontr = (checkBoxUserControl)userControl;
                RadioButtonList radioButtonContr = (RadioButtonList)userControl;
                //foreach (ListItem item in checkBoxcontr.getControl().Items)

                ListItem item = radioButtonContr.SelectedItem;
                string answerVar = item.Text;

                if (item.Attributes["nextQuestionId"] != null)
                {
                    //followUpQuestion
                    insertNextQuestionId(int.Parse(item.Attributes["nextQuestionId"]), followUpQuestionList);
                }

                QuestionAnswers answer = new QuestionAnswers();
                answer.Option_text = item.Text;
                answer.Q_id = currentQuestionIdInSession;
                answer.Option_id = int.Parse(item.Value);

                questionAnswersInSession.Add(answer);

                Session["UserAnswer"] = answerVar;
            }

            //1.Identify which type of question is current question
            //2. Access that question to get answer out from it
            // Label.Tex = "Text labe;";

            if (followUpQuestionList.Count() > 0)
            {
                //Session["CURRENT_QUESTION_ID"] = question.nextQuestionId;
                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Redirect("EndOfSurvey.aspx");
            }

            //HERE CLOSE

            /*
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
            */
        }

        //method to add the next question to the stack:
        private void insertNextQuestionId(int nextQuestionId, Stack<int> followupList)
        {
            //we check if there is already any quastion on the stack, if ther is, we do not need to add
            if (!followupList.Contains(nextQuestionId))
            {
                //in case it does not contais, we add to stack
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