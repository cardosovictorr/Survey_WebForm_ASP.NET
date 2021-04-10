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

            /*
            if (!IsPostBack)
            {
                InputType_DropDownList1.Items.Add(new ListItem("TextBox"));
                InputType_DropDownList1.Items.Add(new ListItem("CheckBox"));
                InputType_DropDownList1.Items.Add(new ListItem("Radio"));
            }
            else
            {
                string selectedControl = InputType_DropDownList1.SelectedItem.Text;
                if (selectedControl.Equals("TextBox"))
                {
                    TextBox textBox1 = new TextBox();
                    PlaceHolder1.Controls.Add(textBox1);

                    textBox1.ID = "textBox1";
                }
                else if (selectedControl.Equals("CheckBox"))
                {
                    CheckBoxList checkBoxList1 = new CheckBoxList();
                    checkBoxList1.Items.Add(new ListItem("ANZ"));
                    checkBoxList1.Items.Add(new ListItem("CommBank"));
                    checkBoxList1.Items.Add(new ListItem("WestBank"));
                    checkBoxList1.Items.Add(new ListItem("SunCorp"));

                    checkBoxList1.ID = "checkBoxList1";

                    PlaceHolder1.Controls.Add(checkBoxList1);
                }
                else if (selectedControl.Equals("Radio"))
                {
                    RadioButtonList radioButtonList1 = new RadioButtonList();

                    radioButtonList1.Items.Add(new ListItem("Male"));
                    radioButtonList1.Items.Add(new ListItem("Female"));
                    radioButtonList1.Items.Add(new ListItem("Other"));

                    radioButtonList1.ID = "radioButtonList1";

                    PlaceHolder1.Controls.Add(radioButtonList1);
                }
            }
            */
        }
        private Question getNextQuestion(int currentQuestionId)
        {
            Question que = null;
            
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                //conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Question where Id =" + currentQuestionId, conn);
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
    }
}