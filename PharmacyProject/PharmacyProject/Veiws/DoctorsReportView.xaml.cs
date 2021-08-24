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
using System.Diagnostics;
using System.Reflection;

namespace PharmacyProject.Veiws
{

    public partial class DoctorsReportView : Window
    {
        public Medicine medicine { get; set; }
        public MedicineController medicineController = new MedicineController();
        public DoctorsReportView(Medicine medicine)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.medicine = medicine;
        }

        private void ConfirmClick_Click(object sender, RoutedEventArgs e)
        {
            
            medicine.IsRejected = true;
            medicine.DoctorsReport = ReportInput.Text;
            medicineController.UpdateMedicineList(medicine);
            RefreshView();
        }

        private void RefreshView()
        {
            List<Medicine> medicines = medicineController.GetAllMededicinesWaitingForApproval();
            CloseMedicinesToApproveListView();
            new MedicinesToApproveListView().Show();
            this.Close();
            MessageBox.Show("Medicine rejected successfuly", "Success");
        }

        public static void CloseMedicinesToApproveListView()
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            foreach (Window w in Application.Current.Windows)
            {
                if (w.GetType().Assembly == currentAssembly && w.Title == "MedicinesToApproveListView")
                {
                    w.Close();
                    break;
                }
            }
        }
    }
}
