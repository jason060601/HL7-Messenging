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
using System.Windows.Shapes;

namespace FHIRMessagingApplication
{
    public partial class RegistrationPortal : Window
    {
        public RegistrationPortal()
        {
            InitializeComponent();
        }
    }
    
    private void PatientButton_Click(object sender, RoutedEventArgs e)
    {
        PatientRegistrationWindow patientRegistrationWindow = new PatientRegistrationWindow(); 
        patientRegistrationWindow.Show();
    }

    private void ClinicianButton_Click(object sender, RoutedEventArgs e)
    {
        ClinicianRegistrationWindow clinicianRegistrationWindow = new ClinicianRegistrationWindow(); 
        clinicianRegistrationWindow.Show();
    }
}
