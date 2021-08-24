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

    public partial class DeletedMedicineListView : Window
    {
        public ObservableCollection<Medicine> Medicines { get; set; } = new ObservableCollection<Medicine>();
        private MedicineController medicineController = new MedicineController();

        public DeletedMedicineListView()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            medicineController.GetAllDeletedMedicines().ForEach(x => Medicines.Add(x));
            this.DataContext = this;
        }
    }
}
