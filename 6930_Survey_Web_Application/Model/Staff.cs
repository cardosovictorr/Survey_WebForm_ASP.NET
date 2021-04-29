using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _6930_Survey_Web_Application.Model
{
    public class Staff
    {
        private int id;
        private string staff_name;
        private int staff_pass;

        public int Id { get => id; set => id = value; }
        public string Staff_name { get => staff_name; set => staff_name = value; }
        public int Staff_pass { get => staff_pass; set => staff_pass = value; }
    }
}