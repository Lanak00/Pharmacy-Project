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

namespace PharmacyProject.Veiws
{

    public partial class UsersMainView : Window
    {
        public UsersMainView()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            ShowViewBasedOnRole();
        }

        private void Medicines_Click(object sender, RoutedEventArgs e)
        {
            new SortMedicinesView("accepted").Show();
        }

        private void IngridientsButton_Click(object sender, RoutedEventArgs e)
        {
            new SortIngridientsView().Show();
        }

        private void PatientsButton_Click(object sender, RoutedEventArgs e)
        {
            new SortPatientsView().Show();
        }

        private void AddPatientButton_Click(object sender, RoutedEventArgs e)
        {
            new AddPatientView().Show();
        }

        private void MedicinesToApproveButton_Click(object sender, RoutedEventArgs e)
        {
            new MedicinesToApproveListView().Show();
        }

        private void AddMedicineButton_Click(object sender, RoutedEventArgs e)
        {
            new AddMedicineView().Show();
        }

        private void RejectedMedicinesButton_Click(object sender, RoutedEventArgs e)
        {
            new SortMedicinesView("rejected").Show();
        }
        private void DeletedMedicinesButton_Click(object sender, RoutedEventArgs e)
        {
            new DeletedMedicineListView().Show();
        }

        private void MyShoppingChartButton_Click(object sender, RoutedEventArgs e)
        {
            new ShoppingChartView().Show();
        }

        private void MyRecieptsButton_Click(object sender, RoutedEventArgs e)
        {
            new ReceiptListView().Show();
        }

        private void ShowViewBasedOnRole()
        {
            switch(Globals.LoggedUser.Role)
            {
                case ("DOCTOR"):
                    PatientsButton.Visibility = Visibility.Visible;
                    AddPatientButton.Visibility = Visibility.Visible;
                    MedicinesToApprove.Visibility = Visibility.Visible;
                    break;
                case ("PHARMACIST"):
                    AddMedicineButton.Visibility = Visibility.Visible;
                    RejectedMedicinesButton.Visibility = Visibility.Visible;
                    DeletedMedicinesButton.Visibility = Visibility.Visible;
                    break;
                case ("PATIENT"):
                    MyShoppingChartButton.Visibility = Visibility.Visible;
                    MyReceiptsButton.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
