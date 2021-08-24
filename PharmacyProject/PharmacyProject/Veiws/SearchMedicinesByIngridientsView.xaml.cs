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

    public partial class SearchMedicinesByIngridientsView : Window
    {
        public ObservableCollection<Ingridient> Ingridients { get; set; } = new ObservableCollection<Ingridient>();
        public IngridientController ingridientController = new IngridientController();
        public MedicineController medicineController = new MedicineController();

        private List<String> mustContainAll = new List<String>();
        private List<List<String>> mustContainOneOf = new List<List<String>>();
        private List<Medicine> medicines = new List<Medicine>();
        private string medicineStatus;
        public SearchMedicinesByIngridientsView(String medicineStatus)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            List<Ingridient> ingridients = ingridientController.GetAllIngridients();
            ingridients.ForEach(x => Ingridients.Add(x));
            this.DataContext = this;
            this.medicineStatus = medicineStatus;
        }

        private void AndButton_Click(object sender, RoutedEventArgs e)
        {

            if (IngridientsListBox.SelectedItems.Count == 1)
            {
                Ingridient selectedItem = (Ingridient)IngridientsListBox.SelectedItem;
                mustContainAll.Add(selectedItem.Name.ToString());
            }
                

            if (IngridientsListBox.SelectedItems.Count > 1)
                AddIngridientsToOneOfList();

            IngridientsListBox.UnselectAll();

        }

        private void AddIngridientsToOneOfList() {

            List<String> ingridients = new List<String>();

            for (int i = 0; i < IngridientsListBox.SelectedItems.Count; i++)
            {
                ingridients.Add(((Ingridient)IngridientsListBox.SelectedItems[i]).Name);
            }
            mustContainOneOf.Add(ingridients);
        }
          
        

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

            if (IngridientsListBox.SelectedItems.Count == 1)
            {
                Ingridient selectedItem = (Ingridient)IngridientsListBox.SelectedItem; 
                mustContainAll.Add(selectedItem.Name.ToString());           
            }

            if (IngridientsListBox.SelectedItems.Count > 1)
                AddIngridientsToOneOfList();

            medicines = medicineController.SearchByIngridients(mustContainAll, mustContainOneOf, medicineStatus);
            ShowViewBasedOnMedicineStatus();
        }

        private void ShowViewBasedOnMedicineStatus()
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

        private void ShowRejectedMedicineView()
        {
            RejectedMedicineListView window = new RejectedMedicineListView(medicines);
            window.SearchButton.Visibility = Visibility.Hidden;
            window.Show();
            this.Close();
        }
    }
}
