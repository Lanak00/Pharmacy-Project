using Controller;
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
using System.Collections.ObjectModel;

namespace PharmacyProject.Veiws
{
    public partial class AddMedicineView : Window
    {
        public ObservableCollection<Ingridient> Ingridients { get; set; } = new ObservableCollection<Ingridient>();
        public IngridientController ingridientController = new IngridientController();
        public MedicineController medicineController = new MedicineController();

        public Dictionary<string, float> ingridients = new Dictionary<string, float>();

        public AddMedicineView()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<Ingridient> ingridients = ingridientController.GetAllIngridients();
            ingridients.ForEach(x => Ingridients.Add(x));
            this.DataContext = this;
        }

        private void AddMedicineButton_Click(object sender, RoutedEventArgs e)
        {
            Medicine medicine = GetInputMedicine();
            medicineController.AddNewMedicine(medicine);
            this.Close();
            MessageBox.Show("Medicine added successfuly", "Success");
        }


        private Medicine GetInputMedicine()
        {
            ingridients.Add(((Ingridient)IngridientsListBox.SelectedItem).Name, float.Parse(MiligramsInput.Text));

            Medicine medicine = new Medicine();
            medicine.Id = IdInput.Text;
            medicine.Name = NameInput.Text;
            medicine.Manufacturer = ManufacturerInput.Text;
            medicine.Price = float.Parse(PriceInput.Text);
            medicine.Ammount = int.Parse(AmountInput.Text);
            medicine.IsAccepted = false;
            medicine.IsRejected = false;
            medicine.IsDeleted = false;
            medicine.DoctorsReport = "";
            medicine.Ingridients = ingridients;
            return medicine;
        }

        private void AndButton_Click(object sender, RoutedEventArgs e)
        {
            ingridients.Add(((Ingridient)IngridientsListBox.SelectedItem).Name, float.Parse(MiligramsInput.Text));
            IngridientsListBox.UnselectAll();
            MiligramsInput.Text = "0.0";
        }
    }
}
