using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _6930_Survey_Web_Application.Model;

namespace _6930_Survey_Web_Application
{
    public partial class EndOfSurvey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<QuestionAnswers> questionAnswersInSession = (List<QuestionAnswers>)Session["Question_ANSWER_LIST"];

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
    }
}