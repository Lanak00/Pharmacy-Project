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
using Controller;
using Model;

namespace PharmacyProject.Veiws
{

    public partial class SortMedicinesView : Window
    {
        private List<Medicine> medicines = new List<Medicine>();
        public MedicineController medicineController = new MedicineController();
        private String medicineStatus;

        public SortMedicinesView(String medicineStatus)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.medicineStatus = medicineStatus;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (NameButton.IsChecked == true)
            {
                medicines = medicineController.SortByName(medicineStatus);
                ShowMedicinesBasedOnMedicineStatus();
            }

            if (PriceButton.IsChecked == true)
            {
                medicines = medicineController.SortByPrice(medicineStatus);
                ShowMedicinesBasedOnMedicineStatus();
            }
            if (AmountButton.IsChecked == true)
            {
                medicines = medicineController.SortByAmountLeft(medicineStatus);
                ShowMedicinesBasedOnMedicineStatus();
            }
            if (NameButton.IsChecked == false &&
                PriceButton.IsChecked == false &&
                AmountButton.IsChecked == false)
                MessageBox.Show("Please select one of the parameters", "Parameter not selected");
        }

        private void SkipButton_Click(object sender, RoutedEventArgs e)
        {
            medicines = medicineController.SortByName(medicineStatus);
            ShowMedicinesBasedOnMedicineStatus();
        }

        private void ShowMedicinesBasedOnMedicineStatus()
        {
            if (medicineStatus == "accepted")
                ShowViewBasedOnUser();
            else
                new RejectedMedicineListView(medicines).Show();

            this.Close();
        }

        private void ShowViewBasedOnUser()
        {
            if (Globals.LoggedUser.Role == "PHARMACIST")
                ShowPharmacistMedicineView();
            if (Globals.LoggedUser.Role == "DOCTOR")
                ShowMedicineView();
            if (Globals.LoggedUser.Role == "PATIENT")
                ShowPatientMedicineView();
        }

        private void ShowMedicineView()
        {
            MedicineListView window = new MedicineListView(medicines);
            window.Show();
            this.Close();
        }

        private void ShowPharmacistMedicineView()
        {
            PharmacistMedicineListView window = new PharmacistMedicineListView(medicines);
            window.Show();
            this.Close();
        }

        private void ShowPatientMedicineView()
        {
            PatientMedicineListView window = new PatientMedicineListView(medicines);
            window.Show();
            this.Close();
        }


    }
}









