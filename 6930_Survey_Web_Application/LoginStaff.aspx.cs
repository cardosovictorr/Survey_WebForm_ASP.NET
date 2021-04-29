using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _6930_Survey_Web_Application
{
    public partial class LoginStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void enterButton_Click(object sender, EventArgs e)
        {
            //get input from the user

            //check if username and password are correct

            //send to the search page
            Response.Redirect("Search.aspx");
        }
    }
}