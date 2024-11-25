using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Assestment_2_c_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Recruitmentsystem classsystem = new Recruitmentsystem();
        public MainWindow()
        {
            InitializeComponent();
            ShowContractors();
            ShowJobs();
        }

        
        public void ShowContractors() //This is a method to get the list of students
        {
            contractorsList.ItemsSource = null;
            contractorsList.ItemsSource = classsystem.contractors;
        }

        public void ShowJobs() 
        { 
            jobsList.ItemsSource = null;
            jobsList.ItemsSource = classsystem.jobs;
        }

        private void GetAssignedContractors(Job job)
        {
            AssignedContractorsList.ItemsSource = null;
            AssignedContractorsList.ItemsSource = job.AssignedContractor;
        }

        private void BtnAddCont_Click(object sender, RoutedEventArgs e)
        {
            // Input validation
            if (string.IsNullOrEmpty(TxtBoxFName.Text) || string.IsNullOrEmpty(TxtBoxLName.Text) ||
                string.IsNullOrEmpty(TxTBoxContID.Text) || DatePickerContractor.SelectedDate == null ||
                string.IsNullOrEmpty(HourlyRateContractor.Text))
            {
                MessageBox.Show("Please fill all fields with valid information.");
                return;
            }

            if (!float.TryParse(HourlyRateContractor.Text, out float hourlyRate))
            {
                MessageBox.Show("Please enter a valid number for the Hourly Rate.");
                return;
            }

            // Create and add the contractor
            Contractor newcontractor = new Contractor(
                Convert.ToInt32(TxTBoxContID.Text),
                TxtBoxFName.Text,
                TxtBoxLName.Text,
                DateOnly.FromDateTime(DatePickerContractor.SelectedDate ?? DateTime.Now),
                hourlyRate);

            classsystem.AddContractor(newcontractor);
            ShowContractors(); // Refresh list
        }



        private void RemoveContractorButton_Click(object sender, RoutedEventArgs e)
        {
            Contractor removecontractor = contractorsList.SelectedItem as Contractor;
            classsystem.RemoveStudent(removecontractor);
            ShowContractors();
        }

        private void AddJobBtn_Click(object sender, RoutedEventArgs e)
        {
            // Input validation
            if (string.IsNullOrEmpty(TxtJobTitle.Text) || string.IsNullOrEmpty(TxtJobId.Text) ||
                string.IsNullOrEmpty(TxtCostJob.Text) || DatePickerJob.SelectedDate == null)
            {
                MessageBox.Show("Please fill all fields with valid information.");
                return;
            }

            if (!float.TryParse(TxtCostJob.Text, out float jobCost))
            {
                MessageBox.Show("Please enter a valid number for the Job Cost.");
                return;
            }

            // Create and add the job
            Job addjob = new Job(
                Convert.ToInt32(TxtJobId.Text),
                TxtJobTitle.Text,
                DateOnly.FromDateTime(DatePickerJob.SelectedDate ?? DateTime.Now),
                jobCost,
                false, // Job completed status
                false); // Contractor assigned status

            classsystem.AddJob(addjob);
            ShowJobs(); // Refresh list
        }


        private void BtnAssignContractor_Click(object sender, RoutedEventArgs e)
        {
            Contractor contractorL = contractorsList.SelectedItem as Contractor;
            Job jobL = jobsList.SelectedItem as Job;

            if (contractorL != null && jobL != null)
            {
                classsystem.AssignContractorJob(contractorL, jobL);
                GetAssignedContractors(jobL);
            }
        }

        private void AssignContractorBtn_Click(object sender, RoutedEventArgs e)
        {
            Contractor contractorL = contractorsList.SelectedItem as Contractor;
            Job jobL = jobsList.SelectedItem as Job;

            if (contractorL != null && jobL != null)
            {
                if (jobL.ContractorAssigned) // Check if contractor is already assigned
                {
                    MessageBox.Show("This job already has a contractor assigned.");
                    return;
                }

                // Assign contractor to job
                classsystem.AssignContractorJob(contractorL, jobL);
                GetAssignedContractors(jobL); // Update the list of assigned contractors for the job
            }
            else
            {
                MessageBox.Show("Please select both a contractor and a job.");
            }
        }

    }
}