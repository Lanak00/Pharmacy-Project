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
using PharmacyProject.DTOs;

namespace PharmacyProject.Veiws
{
 
    public partial class SearchIngridientsByMedicinesView : Window
    {

        public IngridientController ingridientController = new IngridientController();
        public MedicineController medicineController = new MedicineController();

        public ObservableCollection<Medicine> Medicines { get; set; } = new ObservableCollection<Medicine>();
        public List<Ingridient> ingridients = new List<Ingridient>();

        public SearchIngridientsByMedicinesView()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            List<Medicine> medicines = medicineController.GetAllApprovedMedicines();
            medicines.ForEach(x => Medicines.Add(x));
            this.DataContext = this;
        }

        public void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            List<Medicine> medicines = getSelectedMedicines();
            foreach (Medicine medicine in medicines)
            {
                addIngridientsToList(medicine);
            }
            ShowIngridientView();
        }

        public void addIngridientsToList(Medicine medicine)
        {
            foreach (var name in medicine.Ingridients.Keys)
            {
                Ingridient ingridient = ingridientController.GetIngridientByName(name);
                if (!ingridients.Contains(ingridient))
                {
                    ingridients.Add(ingridient);
                }
            }
        }

        public List<Medicine> getSelectedMedicines()
        {
            List<Medicine> medicines = new List<Medicine>();

            for (int i = 0; i < MedicinesListBox.SelectedItems.Count; i++)
            {
                medicines.Add(((Medicine)MedicinesListBox.SelectedItems[i]));
            }

            return medicines;
        }

        private void ShowIngridientView()
        {
            List<IngridientDTO> ingridientDTOs = ingridientController.GetListOfIngridientDTOs(ingridients);
            IngridientListView window = new IngridientListView(ingridientDTOs);
            this.Close();
            window.SearchButton.Visibility = Visibility.Hidden;
            window.Show();
        }

    }
}
