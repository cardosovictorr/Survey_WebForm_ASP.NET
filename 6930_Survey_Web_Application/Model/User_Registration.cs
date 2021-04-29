using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _6930_Survey_Web_Application.Model
{
    public class User_Registration
    {
        private string id;
        private string user_name;
        private string user_last_name;
        private string user_birth;
        private string user_contact;
        private string u_resp_id;

        public string Id { get => id; set => id = value; }
        public string User_name { get => user_name; set => user_name = value; }
        public string User_last_name { get => user_last_name; set => user_last_name = value; }
        public string User_birth { get => user_birth; set => user_birth = value; }
        public string User_contact { get => user_contact; set => user_contact = value; }
        public string U_resp_id { get => u_resp_id; set => u_resp_id = value; }
    }
}