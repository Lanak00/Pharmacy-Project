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

    public partial class SearchMedicinesView : Window
    {
        private List<Medicine> medicines = new List<Medicine>();
        public MedicineController medicineController = new MedicineController();
        private string medicineStatus;
        public SearchMedicinesView(string medicineStatus)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.medicineStatus = medicineStatus;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            bool buttonIsChecked = false;

            if (IdButton.IsChecked == true)
            {
                ShowIdSearchInputForm();
                buttonIsChecked = true;
            }

            if (NameButton.IsChecked == true)
            {
                ShowNameSearchInputForm();
                buttonIsChecked = true;
            }
            if (ManufacturerButton.IsChecked == true)
            {
                ShowManufacturerSearchInputForm();
                buttonIsChecked = true;
            }
            if (PriceRangeButton.IsChecked == true)
            {
                ShowPriceRangeSearchInputForm();
                buttonIsChecked = true;
            }
            if (AmountButton.IsChecked == true)
            {
                ShowAmountSearchInputForm();
                buttonIsChecked = true;
            }
            if (IngridientsButton.IsChecked == true)
            {
                ShowIngridientsSearchInputForm();
                buttonIsChecked = true;
            }

            if (buttonIsChecked == false)
                MessageBox.Show("Select one of Parameters to search Medicines", "Parameter not chosen");

        }


        private void SearchByIdButton_Click(object sender, RoutedEventArgs e)
        {
            string id = IdInput.Text;
            medicines = medicineController.SearchById(id, medicineStatus);
            ShowFilteredMedicineList();
        }
        
        private void SearchByNameButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameInput.Text.ToLower();
            medicines = medicineController.SearchByName(name, medicineStatus);
            ShowFilteredMedicineList();
        }

        private void SearchByManufacturerButton_Click(object sender, RoutedEventArgs e)
        {
            string manufacturer = ManufacturerInput.Text.ToLower();
            medicines = medicineController.SearchByManufacturer(manufacturer, medicineStatus);
            ShowFilteredMedicineList();
        }

        private void SearchByPriceRangeButton_Click(object sender, RoutedEventArgs e)
        {
            float from = float.Parse(PriceRangeFromInput.Text);
            float to = float.Parse(PriceRangeToInput.Text);
            medicines = medicineController.SearchByPriceRange(from, to, medicineStatus);
            ShowFilteredMedicineList();
        }

        private void SearchByAmountButton_Click(object sender, RoutedEventArgs e)
        {
            int amount = int.Parse(AmountInput.Text);
            medicines = medicineController.SearchByAmmount(amount, medicineStatus);
            ShowFilteredMedicineList();
        }


        private void ShowFilteredMedicineList()
        {
            if (medicineStatus == "accepted")
                ShowViewBasedOnUser();
            else
                ShowRejectedMedicineView();
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
            window.SearchButton.Visibility = Visibility.Hidden;
            window.Show();
            this.Close();
        }

        private void ShowPharmacistMedicineView()
        {
            PharmacistMedicineListView window = new PharmacistMedicineListView(medicines);
            window.SearchButton.Visibility = Visibility.Hidden;
            window.Show();
            this.Close();
        }

        private void ShowPatientMedicineView()
        {
            PatientMedicineListView window = new PatientMedicineListView(medicines);
            window.SearchButton.Visibility = Visibility.Hidden;
            window.Show();
            this.Close();
        }

        private void ShowRejectedMedicineView()
        {
            RejectedMedicineListView window = new RejectedMedicineListView(medicines);
            window.SearchButton.Visibility = Visibility.Hidden;
            window.Show();
            this.Close();
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        public void HideButtons()
        {
            CancelButton.Visibility = Visibility.Hidden;
            ConfirmButton.Visibility = Visibility.Hidden;
        }
        public void ShowIdSearchInputForm()
        {
            HideButtons();
            IdInput.Visibility = Visibility.Visible;
            SearchByIdButton.Visibility = Visibility.Visible;
        }

        public void ShowNameSearchInputForm()
        {
            HideButtons();
            NameInput.Visibility = Visibility.Visible;
            SearchByNameButton.Visibility = Visibility.Visible;
        }

        public void ShowManufacturerSearchInputForm()
        {
            HideButtons();
            ManufacturerInput.Visibility = Visibility.Visible;
            SearchByManufacturerButton.Visibility = Visibility.Visible;
        }

        public void ShowPriceRangeSearchInputForm()
        {
            HideButtons();
            PriceRangeFromInput.Visibility = Visibility.Visible;
            PriceRangeToInput.Visibility = Visibility.Visible;
            DashBlock.Visibility = Visibility.Visible;
            SearchByPriceRangeButton.Visibility = Visibility.Visible;
        }
        public void ShowAmountSearchInputForm()
        {
            HideButtons();
            AmountInput.Visibility = Visibility.Visible;
            SearchByAmountButton.Visibility = Visibility.Visible;
        }

        public void ShowIngridientsSearchInputForm()
        {
            this.Close();
            SearchMedicinesByIngridientsView window = new SearchMedicinesByIngridientsView(medicineStatus);
            window.Show();
        }

       
    }
}
