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

namespace BK6RIJ_HFT_2021221.WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Customers_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow window = new CustomerWindow();
            window.Show();
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow window = new ProductWindow();
            window.Show();
        }

       

        private void Deliveries_Click(object sender, RoutedEventArgs e)
        {
            DeliveryWindow window = new DeliveryWindow();
            window.Show();
        }
    }
}
