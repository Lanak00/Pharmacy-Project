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

namespace PharmacyProject.Veiws
{

    public partial class DoctorsReviewView : Window
    {
        private string review;
        public DoctorsReviewView(string review)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.review = review;
            ShowDoctorsReview();
        }

        private void ShowDoctorsReview()
        {
            ReportInput.Text = review;
        }
    }
}
