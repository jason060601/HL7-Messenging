using System.Windows;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Net.Configuration;
using System;

namespace YourAppName
{
    public partial class MainWindow : Window
    {
        private readonly string connectionString = "Server=localhost; Database=master; Trusted_Connection=True";
        // In a real-world scenario, replace this with actual authentication logic
        private bool AuthenticateUser(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", (password));

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
                // Successful login
                txtMessage.Text = "Login successful!";
                // Add logic to navigate to the next part of your application
            }
            else
            {
                // Failed login
                txtMessage.Text = "Invalid username or password. Please try again.";
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationPortal registrationPortal = new RegistrationPortal();
            registrationPortal.Show();
        }
    }
}
