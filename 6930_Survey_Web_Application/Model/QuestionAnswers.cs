using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _6930_Survey_Web_Application.Model
{
    public class QuestionAnswers
    {
        private int id;
        private string option_text;
        private int q_id;
        private int? option_id;

        public int Id { get => id; set => id = value; }
        public string Option_text { get => option_text; set => option_text = value; }
        public int Q_id { get => q_id; set => q_id = value; }
        public int? Option_id { get => option_id; set => option_id = value; }
    }
}