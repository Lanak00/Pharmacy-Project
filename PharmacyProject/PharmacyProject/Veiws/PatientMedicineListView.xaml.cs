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
using System.Collections.ObjectModel;

namespace PharmacyProject.Veiws
{

    public partial class PatientMedicineListView : Window
    {

        public ObservableCollection<Medicine> Medicines { get; set; } = new ObservableCollection<Medicine>();
        public MedicineController medicineController = new MedicineController();

        public PatientMedicineListView(List<Medicine> med)
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

        private void AddToChartButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (FrameworkElement)sender;
            var medicine = (Medicine)button.DataContext;

            if(MedicineAlreadyInChart(medicine.Id))
                MessageBox.Show("Medicine already added to Chart");
            else
                new MedicineAmountInputView(medicine).Show();
        }

        private bool MedicineAlreadyInChart(string id)
        {
            return Globals.LoggedUser.ShoppingChart.ContainsKey(id);
        }
    }
}
