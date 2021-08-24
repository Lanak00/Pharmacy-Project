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
using PharmacyProject.DTOs;
using Controller;

namespace PharmacyProject.Veiws
{

    public partial class SortIngridientsView : Window
    {

        private List<IngridientDTO> ingridients = new List<IngridientDTO>();
        public IngridientController ingridientController = new IngridientController();

        public SortIngridientsView()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (NameButton.IsChecked == true)
            {
                ingridients = ingridientController.SortByName();
                ShowIngridientView();
            }

            if (OccurenceButton.IsChecked == true)
            {
                ingridients = ingridientController.SortByOccurence();
                ShowIngridientView();
            }
            if (NameButton.IsChecked == false &&
                OccurenceButton.IsChecked == false)
                MessageBox.Show("Please select one of the parameters", "Parameter not selected");

        }

        private void ShowIngridientView()
        {
            IngridientListView window = new IngridientListView(ingridients);
            this.Close();
            window.Show();
        }

        private void SkipButton_Click(object sender, RoutedEventArgs e)
        {
            ingridients = ingridientController.SortByName();
            ShowIngridientView();
        }
    }
}
