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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Beverage selectedBeverage;
        public MainWindow()
        {
            InitializeComponent();

            cmbBeverage.ItemsSource = new[] {

                new Beverage{ Id=1,Name="Tea", Price=200},
                new Beverage{ Id=2,Name="Coffee", Price=300}

            };
            cmbBeverage.DisplayMemberPath= "Name";



        }

        private void btnPlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            if (cmbBeverage.SelectedItem == null)
            {
                MessageBox.Show("Please select a beverage.");
                return;
            }

            selectedBeverage = cmbBeverage.SelectedItem as Beverage;


            string OrderDetails = $"Order Details:\n" +
                $"Beverage: {selectedBeverage.Name}\n" +
                $"Sugar: {((chkSugar.IsChecked == true) ? "Yes" : "No")}\n" +
                $"Milk: {(chkMilk.IsChecked == true ? "Yes" : "No")}\n" +
                $"Cup Size: {(radSmall.IsChecked == true ? "Small" : radMedium.IsChecked == true ? "Medium" : "Large")}\n" +
                $"Total Price: {selectedBeverage.Price:C}";

          


            lblOrderDetails.Content = OrderDetails;
        }
    }

    public class Beverage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }


}
