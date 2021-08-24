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
using Model;
using Controller;


namespace PharmacyProject.Veiws
{
    public partial class MedicinesToApproveListView : Window
    {
        public ObservableCollection<Medicine> Medicines { get; set; } = new ObservableCollection<Medicine>();
        public MedicineController medicineController = new MedicineController();
        public MedicinesToApproveListView()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            medicineController.GetAllMededicinesWaitingForApproval().ForEach(x => Medicines.Add(x));
            this.DataContext = this;
        }

        private void ApproveMedicineButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (FrameworkElement)sender;
            var medicine = (Medicine)button.DataContext;
            medicine.IsAccepted = true;
            medicineController.UpdateMedicineList(medicine);
            RefreshView();
            MessageBox.Show("Medicine approved successfuly", "Success");
        }

        private void RejectMedicineButton_Click(object sender, RoutedEventArgs e)
        { 
            var button = (FrameworkElement)sender;
            var medicine = (Medicine)button.DataContext;
            new DoctorsReportView(medicine).Show();
        }

        private void RefreshView()
        {
            List<Medicine> medicines = medicineController.GetAllMededicinesWaitingForApproval();
            this.Close();
            new MedicinesToApproveListView().Show();
        }
    }
}
