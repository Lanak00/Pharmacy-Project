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
    public partial class PharmacistMedicineListView : Window
    {
        public ObservableCollection<Medicine> Medicines { get; set; } = new ObservableCollection<Medicine>();
        public MedicineController medicineController = new MedicineController();

        public PharmacistMedicineListView(List<Medicine> med)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            med.ForEach(x => Medicines.Add(x));
            this.DataContext = this;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SearchMedicinesView window = new SearchMedicinesView("accepted");
            window.Show();
        }

        private void DeleteMedicineButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (FrameworkElement)sender;
            var medicine = (Medicine)button.DataContext;
            medicineController.DeleteMedicine(medicine);
            MessageBox.Show("Medicine deleted successfuly", "Success");
        }
    }
}
