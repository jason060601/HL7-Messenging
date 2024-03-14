using System;
using System.Net.Http;
using System.Windows;
using Hl7.Fhir.Rest; // Import FHIR client classes
using Hl7.Fhir.Model; // Import FHIR model classes
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace FHIRMessagingApplication
{
    public partial class DashboardWindow : Window
    {
        private readonly string fhirServerUrl = "https://your-fhir-server-url"; // Replace with the actual FHIR server URL
        private readonly FhirClient fhirClient; // Use FhirClient for interacting with the FHIR server

        private ObservableCollection<Patient> patients;
        private ObservableCollection<Message> messages;
        private ObservableCollection<LogEntry> logEntries;

        public DashboardWindow()
        {
            InitializeComponent();

            // Initialize FhirClient for interacting with the FHIR server
            fhirClient = new FhirClient(fhirServerUrl);

            InitializeData();
        }

        private async void InitializeData()
        {
            await LoadPatients();
            await LoadMessages();
            // Load other data as needed
        }

        private async Task LoadPatients()
        {
            patients = new ObservableCollection<Patient>();

            try
            {
                Bundle response = await fhirClient.SearchAsync<Patient>(); // Use FhirClient to search for Patients
                foreach (var entry in response.Entry)
                {
                    var patient = (Patient)entry.Resource;
                    patients.Add(patient);
                }
            }
            catch (FhirOperationException ex)
            {
                MessageBox.Show($"Error loading patients: {ex.Message}");
            }
        }

        private async Task LoadMessages()
        {
            messages = new ObservableCollection<Message>();

            try
            {
                Bundle response = await fhirClient.SearchAsync<Message>(); // Use FhirClient to search for Messages
                foreach (var entry in response.Entry)
                {
                    var message = (Message)entry.Resource;
                    messages.Add(message);
                }
            }
            catch (FhirOperationException ex)
            {
                MessageBox.Show($"Error loading messages: {ex.Message}");
            }
        }

        // Implement similar methods for loading log entries and other data
    }
}


