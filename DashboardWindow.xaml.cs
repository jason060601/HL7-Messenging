// DashboardWindow.xaml.cs

using System;
using System.Windows;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace YourAppName
{
    public partial class DashboardWindow : Window
    {
        // Connection string to database
        private readonly string connectionString = "Server=localhost; Database=YourDatabase; Trusted_Connection=True";

        // Collections to hold data for different sections
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
        private void InitializeData()
        {
            LoadPatientRecords();
            LoadMessages();
            LoadPatients();
            LoadLogEntries();
        }

        // Method to load patient records
        private void LoadPatientRecords()
        {
            patientRecords = new ObservableCollection<PatientRecord>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM PatientRecords";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Create PatientRecord objects and add them to the collection
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

