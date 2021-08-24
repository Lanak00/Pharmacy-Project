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

    public partial class AddPatientView : Window
    {
        public UserController userController = new UserController();
        public AddPatientView()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            User patient = new User();
            patient.FirstName = FirstNameInput.Text;
            patient.LastName = LastNameInput.Text;
            patient.Id = IdInput.Text;
            patient.Email = EmailInput.Text;
            patient.Password = PasswordInput.Text;
            patient.PhoneNumber = PhoneNumberInput.Text;
            patient.Role = "PATIENT";

            if(ValidateEmail(patient.Email) && ValidateId(patient.Id))
            {
                userController.SaveUser(patient);
                this.Close();
                MessageBox.Show("Patient added successfuly", "Success");
            } 

        }

        private  bool ValidateEmail(String email)
        {
            List<User> patients = userController.GetAllPatients();
            foreach(User patient in patients)
            {
                if (patient.Email == email)
                {
                    MessageBox.Show("Patient with this Email already exists");
                    return false;
                }
            }
            return true;
        }

        private bool ValidateId(String id)
        {
            List<User> patients = userController.GetAllPatients();
            foreach (User patient in patients)
            {
                if (patient.Id == id)
                {
                    MessageBox.Show("Patient with this Id already exists");
                    return false;
                }
            }
            return true;
        }

     
    }
}
