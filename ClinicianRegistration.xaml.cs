using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
using System.Windows.Shapes;

namespace FHIRMessagingApplication
{
    public partial class ClinicianRegistrationWindow : Window
    {
        public ClinicianRegistrationWindow()
        {
            InitializeComponent();
        }
    }

    private void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        string email = txtEmail.Text;
        string password = txtPassword.Password;
        string firstName = txtFirstName.Text;
        string lastName = txtLastName.Text;
        DateTime birthDate = dpBirthDate.SelectedDate.Value;
        int npiNumber = int.Parse(txtNpiNumber.Text);
        string employerName = txtEmployerName.Text;

        //Needs error handling

        Close();

    }
}
