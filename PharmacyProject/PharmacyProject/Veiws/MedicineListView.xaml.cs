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
using Model;

namespace PharmacyProject.Veiws
{

    public partial class MedicineListView : Window
    {
        public ObservableCollection<Medicine> Medicines { get; set; } = new ObservableCollection<Medicine>();

        public MedicineListView(List<Medicine> med)
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

        private void DoctorsReviewButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
