using LoginPortal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegistratePortal
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password != txtConfirmPassword.Password)
            {
                MessageBox.Show("Passwords do not match. Please re-enter your password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtPassword.Clear();
                txtConfirmPassword.Clear();
                txtPassword.Focus();
            }

            else
             {
        //Passwords match, hash the password
        //string hashedPassword = HashPassword(txtPassword.Password);
        
        //This string will be local server string, until SQL server uploaded into instance
        //string connectionString = "";

        //using (SqlConnection connection = new SqlConnection(connectionString)) {

        //connection.Open();
        //string sql = "INSERT INTO [User] (Email, Password)
        //SqlCommand command = new SqlCommand(sql, connection)
        //command.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
        //command.Parameters.AddWithValue("@Password". txtPassword.Password);
  
        //This will allow the user to move onto the "Personal Information" section
             }
        }
    }
}
