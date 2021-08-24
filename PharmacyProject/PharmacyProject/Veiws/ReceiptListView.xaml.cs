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
using System.Collections.ObjectModel;

namespace PharmacyProject.Veiws
{
 
    public partial class ReceiptListView : Window
    {
        public ObservableCollection<Receipt> Receipts { get; set; } = new ObservableCollection<Receipt>();

        public ReceiptListView()
        {
            PopulateRecieptList();
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = this;
        }

        private void PopulateRecieptList()
        {
            foreach (Receipt receipt in Globals.LoggedUser.Receipts)
            {
                Receipts.Add(receipt);
            }
        }
    }
}
