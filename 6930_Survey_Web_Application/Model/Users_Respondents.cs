using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _6930_Survey_Web_Application.Model
{
    public class Users_Respondents
    {
        private string id;
        private string user_first_name;
        private string user_last_name;
        private string user_gender;
        private string user_state;
        private string user_post_code;
        private string user_bank;
        private string user_newspaper;
        private string user_bank_services;
        private string user_news_interests;
        private string user_age;
        private string user_email;
        private string user_bank_used;

        public string Id { get => id; set => id = value; }
        public string User_first_name { get => user_first_name; set => user_first_name = value; }
        public string User_last_name { get => user_last_name; set => user_last_name = value; }
        public string User_gender { get => user_gender; set => user_gender = value; }
        public string User_state { get => user_state; set => user_state = value; }
        public string User_post_code { get => user_post_code; set => user_post_code = value; }
        public string User_bank { get => user_bank; set => user_bank = value; }
        public string User_newspaper { get => user_newspaper; set => user_newspaper = value; }
        public string User_bank_services { get => user_bank_services; set => user_bank_services = value; }
        public string User_news_interests { get => user_news_interests; set => user_news_interests = value; }
        public string User_age { get => user_age; set => user_age = value; }
        public string User_email { get => user_email; set => user_email = value; }
        public string User_bank_used { get => user_bank_used; set => user_bank_used = value; }
    }
}