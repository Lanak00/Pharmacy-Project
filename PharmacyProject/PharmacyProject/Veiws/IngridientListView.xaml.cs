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
using PharmacyProject.DTOs;

namespace PharmacyProject.Veiws
{

    public partial class IngridientListView : Window
    { 
        public ObservableCollection<IngridientDTO> Ingridients { get; set; } = new ObservableCollection<IngridientDTO>();
        public IngridientListView(List<IngridientDTO> ingridients)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ingridients.ForEach(x => Ingridients.Add(x));
            this.DataContext = this;
        }


        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchIngridientsViewxaml window = new SearchIngridientsViewxaml();
            window.Show();
        }
    }
}
