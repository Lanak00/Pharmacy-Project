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
using Model;
using Controller;

namespace PharmacyProject.Veiws
{

    public partial class SortPatientsView : Window
    {
        private List<User> patients = new List<User>();
        public UserController userController = new UserController();

        public SortPatientsView()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (FirstNameButton.IsChecked == true)
            {
                patients = userController.SortPatientsByFirstName();
                ShowPatientView();
            }

            if (LastNameButton.IsChecked == true)
            {
                patients = userController.SortPatientsByLastName();
                ShowPatientView();
            }
    
            if (FirstNameButton.IsChecked == false &&
                LastNameButton.IsChecked == false)
                MessageBox.Show("Please select one of the parameters", "Parameter not selected");

        }


        private void SkipButton_Click(object sender, RoutedEventArgs e)
        {
            patients = userController.GetAllPatients();
            ShowPatientView();
        }

        private void ShowPatientView()
        {
            PatientListView window = new PatientListView(patients);
            this.Close();
            window.Show();
        }
    }
}
