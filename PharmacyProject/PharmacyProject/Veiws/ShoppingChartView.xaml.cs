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
using PharmacyProject.DTOs;

namespace PharmacyProject.Veiws
{

    public partial class ShoppingChartView : Window
    {
        public ObservableCollection<ChartItemDTO> ShoppingChart { get; set; } = new ObservableCollection<ChartItemDTO>();
        public MedicineController medicineController = new MedicineController();
        public ReceiptController receiptController = new ReceiptController();
        public UserController userController = new UserController();

        private float finalPrice = 0;
        public ShoppingChartView()
        {
            PopulateShoppingChart();
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = this;
            SetFinalPrice();
        }

        public void PopulateShoppingChart()
        {
            foreach (var item in Globals.LoggedUser.ShoppingChart)
            {
                ChartItemDTO chartItem = new ChartItemDTO();
                Medicine medicine = new Medicine();
                medicine = medicineController.GetMedicineById(item.Key);
                chartItem.Id = medicine.Id;
                chartItem.Name = medicine.Name;
                chartItem.PricePerUnit = medicine.Price;
                chartItem.Amount = item.Value;
                chartItem.ItemPrice = item.Value * medicine.Price;
                ShoppingChart.Add(chartItem);

                finalPrice += chartItem.ItemPrice;
            }
        }

        public void SetFinalPrice()
        {
            TotalPriceTextBlock.Text = finalPrice.ToString();
        }

        private void CheckoutButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Globals.LoggedUser.ShoppingChart.Any())
                MessageBox.Show("Add Items to your Shopping Chart", "Shopping Chart is empty");
            else
                CompletePurchase();

        }

        private void CompletePurchase()
        {
            Receipt receipt = CreateReceipt();

            Globals.LoggedUser.Receipts.Add(receipt);
            DecreaseAvailableMedicineAmount();
            EmptyShoppingChart();

            userController.UpdateUserList(Globals.LoggedUser);
            receiptController.SaveReceipt(receipt);

            MessageBox.Show("Successful Purchace, go to your Receipts to se Receipt", "Success");
        }

        private Receipt CreateReceipt()
        {
            Receipt receipt = new Receipt();
            receipt.Items = new Dictionary<string, int>();
            receipt.Id = (receiptController.GetAllReceipts().Count + 1).ToString();
            receipt.Pharmacist = "Marko Markovic";
            receipt.DateTime = DateTime.Now.ToString();
            foreach (ChartItemDTO item in ShoppingChart)
            {
                receipt.Items.Add(item.Name, item.Amount);
            }
            receipt.TotalPrice = finalPrice;

            return receipt;
        }

        private void EmptyShoppingChart()
        {
            Dictionary<string, int> shoppingChart = new Dictionary<string, int>();
            Globals.LoggedUser.ShoppingChart = shoppingChart;
        }

        private void DecreaseAvailableMedicineAmount()
        {
            foreach (var item in Globals.LoggedUser.ShoppingChart)
            {
                Medicine medicine = medicineController.GetMedicineById(item.Key);
                medicine.Ammount -= item.Value;
                medicineController.UpdateMedicineList(medicine);
            }
        }

        private void RemoveMedicineButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (FrameworkElement)sender;
            var medicine = (ChartItemDTO)button.DataContext;
            Globals.LoggedUser.ShoppingChart.Remove(medicine.Id);
            this.Close();
            new ShoppingChartView().Show();
            MessageBox.Show("Item removed from Shopping Chart", "Success");
        }
    }
}
