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

namespace PharmacyProject.Veiws
{
    public partial class PatientListView : Window
    {
        public ObservableCollection<User> Patients { get; set; } = new ObservableCollection<User>();

        public PatientListView(List<User> patients)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            patients.ForEach(x => Patients.Add(x));
            this.DataContext = this;
        }
    }
}
