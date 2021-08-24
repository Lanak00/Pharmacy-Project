using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PharmacyProject.Veiws
{
    public partial class RejectedMedicineListView : Window
    {
        public ObservableCollection<Medicine> Medicines { get; set; } = new ObservableCollection<Medicine>();
        MedicineController medicineController = new MedicineController();

        public RejectedMedicineListView(List<Medicine> med)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            med.ForEach(x => Medicines.Add(x));
            this.DataContext = this;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SearchMedicinesView window = new SearchMedicinesView("rejected");
            window.Show();
        }

        private void DoctorsReviewButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (FrameworkElement)sender;
            var medicine = (Medicine)button.DataContext;
            new DoctorsReviewView(medicine.DoctorsReport).Show();
        }

        private void DeleteMedicineButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (FrameworkElement)sender;
            var medicine = (Medicine)button.DataContext;
            medicineController.DeleteMedicine(medicine);
            RefreshView();
        }

        private void RefreshView()
        {
            List<Medicine> medicines = medicineController.GetAllRejectedMedicines();
            MessageBox.Show("Medicine deleted successfuly", "Success");
            this.Close();
            new RejectedMedicineListView(medicines).Show();
        }
    }
}
