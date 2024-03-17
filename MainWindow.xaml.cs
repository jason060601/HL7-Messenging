//Revisions on the front end include implementing UI library to improve user experience and make application look professional

using System.Windows;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Net.Configuration;
using System;

namespace LoginPortal
{
    public partial class MainWindow : Window
    {
        //For testing purposes, the connection is established to my local SQL database "MessagingApplication"
        private readonly string connectionString = "Server = localhost; Database=MessagingApplication ;Trusted_Connection=True";

        //Password input starts as cleartext then turns into a hash by SHA256 hashing algorithm
        public static string HashPassword (string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
        
        private bool AuthenticateUser(string username, string password)
        {
            //Call HashPassword function with initial cleartext input

            string hashedPassword = HashPassword(password);

            string query = "SELECT COUNT(*) FROM LoginPortal_MessagingApplication.dbo.Users WHERE Username = @username AND hashedPassword = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", (hashedPassword));

                    connection.Open();

                    int userCount = (int)command.ExecuteScalar();

                    return userCount == 1;
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (AuthenticateUser(username, password))
            {
                txtMessage.Text = "Login successful!";
                // Call LoadDashboard() function with the username and password parameters - in ConnectToDashboard Class
            }
            else
            {
                txtMessage.Text = "Invalid username or password. Please try again.";
            }
        }

      //  private void RegisterButton_Click(object sender, RoutedEventArgs e)
      //  {
           // RegistrationPortal registrationPortal = new RegistrationPortal();
           // registrationPortal.Show();
      //  }
    }
}
