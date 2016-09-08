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
using BE;
using BL;

namespace PL_Wpf
{
    /// <summary>
    /// Interaction logic for GetOrderIDWindow.xaml
    /// </summary>
    public partial class GetOrderIDWindow : Window
    {
        Ibl bl;
        Order order;
        public GetOrderIDWindow()
        {
            bl = FactoryBl.getBl();
            InitializeComponent();
            order = new Order();
            this.DataContext = order;

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (bl.getOrder(order.OrderID) == null)
                    throw new Exception("Order doesn't exist!");
                //if (bl.getOrder(order.OrderID).Time.Date != DateTime.Now.Date)
                //    throw new Exception("You can change only order from today!");
                MainWindow w = this.Owner as MainWindow;
                var x = w.MainFrame.Content as MainPage;
                AddDishesToOrderPage p = new AddDishesToOrderPage();
                p.od.OrderID = order.OrderID;
                p.OrderedDishDataGrid.ItemsSource = bl.getOrderedDishes(order.OrderID);
                x.NavigationService.Navigate(p);
                GetOrderIDWindow w2 = Window.GetWindow(this) as GetOrderIDWindow;
                w2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            GetOrderIDWindow w = Window.GetWindow(this) as GetOrderIDWindow;
            w.Close();
        }
    }
}
