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
using PharmacyProject.DTOs;
using Controller;

namespace PharmacyProject.Veiws
{

    public partial class SearchIngridientsViewxaml : Window
    {
        public List<IngridientDTO> ingridients = new List<IngridientDTO>();
        public IngridientController ingridientController = new IngridientController();

        public SearchIngridientsViewxaml()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            bool buttonIsChecked = false;

            if (NameButton.IsChecked == true)
            {
                ShowNameSearchInputForm();
                buttonIsChecked = true;
            }

            if (DescriptionButton.IsChecked == true)
            {
                ShowDescriptionSearchInputForm();
                buttonIsChecked = true;
            }
            if (MedicineButton.IsChecked == true)
            {
                ShowMedicineSearchInputForm();
                buttonIsChecked = true;
            }

            if (buttonIsChecked == false)
                MessageBox.Show("Select one of Parameters to search Medicines", "Parameter not chosen");

        }

        private void SearchByNameButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameInput.Text.ToLower();
            ingridients = ingridientController.SearchByName(name);
            ShowFilteredIngridientList();
        }

        private void SearchByDescriptionButton_Click(object sender, RoutedEventArgs e)
        {
            string description = DescriptionInput.Text.ToLower();
            ingridients = ingridientController.SearchByDescription(description);
            ShowFilteredIngridientList();
        }

        private void SearchByMedicineButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

















        private void ShowFilteredIngridientList()
        {
            IngridientListView window = new IngridientListView(ingridients);
            window.Show();
            window.SearchButton.Visibility = Visibility.Hidden;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        public void ShowNameSearchInputForm()
        {
            HideButtons();
            NameInput.Visibility = Visibility.Visible;
            SearchByNameButton.Visibility = Visibility.Visible;
        }

        public void ShowDescriptionSearchInputForm()
        {
            HideButtons();
            DescriptionInput.Visibility = Visibility.Visible;
            SearchByDescriptionButton.Visibility = Visibility.Visible;
        }

        public void ShowMedicineSearchInputForm()
        {
            this.Close();
            SearchIngridientsByMedicinesView window = new SearchIngridientsByMedicinesView();
            window.Show();
        }

        public void HideButtons()
        {
            CancelButton.Visibility = Visibility.Hidden;
            ConfirmButton.Visibility = Visibility.Hidden;
        }
    }
}
