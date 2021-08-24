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

namespace PharmacyProject.Veiws
{

    public partial class MedicineAmountInputView : Window
    {
        private MedicineController medicineController = new MedicineController();
        private UserController userController = new UserController();
        private Medicine medicine;

        private int maxDailyAmount = 5;
        private int maxWeeklyAmount = 50;

        public MedicineAmountInputView(Medicine medicine)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.medicine = medicine;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsIputAmountValid() && IsDailyAmountValid() && IsWeeklyAmountValid())
            {

                Globals.LoggedUser.ShoppingChart.Add(medicine.Id, int.Parse(AmountInput.Text));
                this.Close();
                userController.UpdateUserList(Globals.LoggedUser);
                MessageBox.Show("Medicine added to Chart", "Success");
            }
        }


        private bool IsIputAmountValid()
        {
            if (!(int.Parse(AmountInput.Text) < ++maxDailyAmount && int.Parse(AmountInput.Text) < (medicine.Ammount + 1)))
            {
                MessageBox.Show("Maximum daily amount of medicine to purchace is 5");
                return false;
            } 
            else
                return true;
        }

        private bool IsDailyAmountValid()
        {
            String dateTime = DateTime.Now.ToString();
            string[] parsed = dateTime.Split(' ');
            string date = parsed[0];
            int dailyAmount = int.Parse(AmountInput.Text);
            List<Receipt> receipts = Globals.LoggedUser.Receipts.FindAll(i => i.DateTime.Contains(date));
            foreach (Receipt receipt in receipts)
            {
                foreach (var item in receipt.Items)
                {
                    if (item.Key == medicine.Name)
                        dailyAmount += item.Value;
                }
            }

            if (dailyAmount > maxDailyAmount)
                MessageBox.Show("Maximum daily amount of medicine to purchace is 5");

            return (dailyAmount < ++maxDailyAmount);

        }

        private bool IsWeeklyAmountValid()
        {

            List<string> dates = new List<string>();
            List<Receipt> receipts = new List<Receipt>();
            int weeklyAmount = int.Parse(AmountInput.Text);
            
            for (int i = 0; i < 7; i++)
            {
                String dateTime = DateTime.Today.AddDays(-i).ToString();
                string[] parsedDates = dateTime.Split(' ');
                dates.Add(parsedDates[0]);
            }


            foreach (string d in dates)
            {
                receipts.AddRange(Globals.LoggedUser.Receipts.FindAll(i => i.DateTime.Contains(d)));
            }

            foreach (Receipt receipt in receipts)
            {
                foreach (var item in receipt.Items)
                {
                        weeklyAmount += item.Value;
                }
            }

            if (weeklyAmount > maxWeeklyAmount)
                MessageBox.Show("Maximum weekly amount of medicines to purchace is 50");
            
            return (weeklyAmount < ++maxWeeklyAmount);
        }
    }
}
