using Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Controller;

namespace PharmacyProject.Veiws
{

    public partial class LogInView : Window
    {
        public LogInView()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        public UserController userController = new UserController();

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            ExceedsLoginLimit();
            string id = Id.Text;
            string password = Password.Password;

            if (!userController.Login(id, password))
            {
                MessageBox.Show("Username and password incorrect. Try again.", "Unexisting user");
                return;
            }

            new UsersMainView().Show();

        }
        public void ExceedsLoginLimit()
        {
            ++Globals.LogInAttempts;
            if (Globals.LogInAttempts > Globals.AttemptsAllowed)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }
    }
}
