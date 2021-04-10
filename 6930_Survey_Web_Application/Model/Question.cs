using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _6930_Survey_Web_Application.Model
{
    public class Question
    {
        private int Id;
        private string question_text;
        private string question_type;
        private int? next_q_id;

        public int Id1 { get => Id; set => Id = value; }
        public string Question_text { get => question_text; set => question_text = value; }
        public string Question_type { get => question_type; set => question_type = value; }
        public int? Next_q_id { get => next_q_id; set => next_q_id = value; }
    }
}