// DashboardWindow.xaml.cs

//Most of the methods will have to be scrapped due to noncompliance to FHIR standard, unless there are future revisions being done
//Currently looking at libraries and source code that incorporates R4-standard for patient-clinician messaging
//Existing built-in libraries such as Cryptography, Security, HTTP can assist in securing communication over HTTPS

using System;
using System.Windows;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

//common namespace for the application
namespace FHIRMessagingApplication
{
    public partial class DashboardWindow : Window
    {
        //Warning: There is an arbitrary value {Database=YourDatabase} should have a connection key (for local testing) or the endpoint of the instance
        //Since it is an endpoint, to connect to the EC2 instance (helpful for viewing files, information in the container)
        //1) Install Remote Development extension pack
        //2) Open command palette and select Remote SSH: Add New SSH Host
        //3) In the "Add New SSH Host Ddialog", this is where we will put the IP address associated with the instance
        //4) Click Add
        //5) Open command palette and select the "Remote SSH: Connect to Host..." command
        //6) Select the host which will be the EC2 instance
        //Note: An SSH key pair must be provided to connect! This will be provided closer to the testing of the application

        //This must be replaced by a connection to the EC2 instance (different file) that utilizes TLS 
       // private readonly string connectionString = "Server=localhost; Database=YourDatabase; Trusted_Connection=True";

        // Collections to hold data for different sections
        //Not sure about collections holding the necessary information, as it must be serialized in JSON (for HTTP POST request)
        //Then deserialized
        //Also, not sure how the collection will conform to the data model for class Patient
        private ObservableCollection<PatientRecord> patientRecords;
        private ObservableCollection<Message> messages;
        private ObservableCollection<Patient> patients;
        private ObservableCollection<LogEntry> logEntries;

        public DashboardWindow()
        {
            InitializeComponent();
            InitializeData();
        }

        // Method to initialize data for each section
        //Looks like this assume that the 
        private void InitializeData()
        {
            LoadPatientRecords();
            LoadMessages();
            LoadPatients();
            LoadLogEntries();
        }

        // Method to load patient records
        //Entire method needs to be redone, as it is not FHIR compliant.
        //Like mentioned earlier, 1) exchanges must be done using TLS handshakes; 2) data format must be in FHIR-approved form; and 3) encryption is vital to protecting information
        
        private void LoadPatientRecords()
        {
            patientRecords = new ObservableCollection<PatientRecord>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //Current code results in querying all patient records
                    //Update needed to ensure patient sees only their records - Josh
                    string query = "SELECT * FROM PatientRecords";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Create PatientRecord objects and add them to the collection
                        //Unsecure method to receive information it should be sent in JSON format
                        
                        patientRecords.Add(new PatientRecord
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            // Add other properties as needed
                            
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patient records: " + ex.Message);
            }
        }

        // Method to load messages
    
        private void LoadMessages()
        {
            messages = new ObservableCollection<Message>();

            try
            {
                // Implement logic to load messages from database or any other source
                // Example:
                // messages.Add(new Message { Content = "Sample message 1", Sender = "John", Timestamp = DateTime.Now });
                // messages.Add(new Message { Content = "Sample message 2", Sender = "Alice", Timestamp = DateTime.Now });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading messages: " + ex.Message);
            }
        }

        // Method to load patients
        private void LoadPatients()
        {
            patients = new ObservableCollection<Patient>();

            try
            {
                // Implement logic to load patients from database or any other source
                // Example:
                // patients.Add(new Patient { Id = 1, Name = "John Doe", Age = 30 });
                // patients.Add(new Patient { Id = 2, Name = "Alice Smith", Age = 25 });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patients: " + ex.Message);
            }
        }

        // Method to load log entries
        private void LoadLogEntries()
        {
            logEntries = new ObservableCollection<LogEntry>();

            try
            {
                // Implement logic to load log entries from database or any other source
                // Example:
                // logEntries.Add(new LogEntry { Message = "User login successful", Timestamp = DateTime.Now });
                // logEntries.Add(new LogEntry { Message = "Failed login attempt", Timestamp = DateTime.Now });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading log entries: " + ex.Message);
            }
        }

    }
}

