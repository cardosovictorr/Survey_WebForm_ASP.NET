using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _6930_Survey_Web_Application.Model;
using System.Configuration;
using System.Data.SqlClient;

namespace _6930_Survey_Web_Application
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        private static string connectionStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        User_Registration registrationUser = new User_Registration();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            string inputName = userNameTextBox.Text;
            string inputLastName = lastNameTextBox.Text;
            string inputBirth = dateOfBirthTextBox.Text;
            string inputContact = contactNumberTextBox.Text;
            saverUserRegistration(inputName, inputLastName, inputBirth, inputContact);

        }

        protected void saverUserRegistration(string name, string lastName, string birth, string contact)
        {

            if (userNameTextBox.Text == "" || lastNameTextBox.Text == "" || dateOfBirthTextBox.Text == "" || contactNumberTextBox.Text == "")
            {
                //Console.WriteLine("Please, write a valid answer!");
                //errorMessageLabel.Visible = true;
                messageLabel.Text = "Please, provide an answer!";
                return;
            }

            //Save info from input in the Object
            registrationUser.User_name = userNameTextBox.Text;
            registrationUser.User_last_name = lastNameTextBox.Text;
            registrationUser.User_birth = dateOfBirthTextBox.Text;
            registrationUser.User_contact = contactNumberTextBox.Text;
            //Save the new register in the database

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                String query = "INSERT INTO User_Registration (user_name, user_last_name, user_birth, user_contact) VALUES (@user_name, @user_last_name, @user_birth, @user_contact)";
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@user_name", registrationUser.User_name);
                    command.Parameters.AddWithValue("@user_last_name", registrationUser.User_last_name);
                    command.Parameters.AddWithValue("@user_birth", registrationUser.User_birth);
                    command.Parameters.AddWithValue("@user_contact", registrationUser.User_contact);


                    int result = command.ExecuteNonQuery();
                    if (result < 0)
                    {
                        Console.WriteLine("The data have not been inserted in the Database!");
                        messageLabel.Text = "The data have not been inserted in the Database!";
                    }
                }

            }

            //send to Thank you Page
        }

        protected void noRegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ThankYou.aspx");
        }
    }
}