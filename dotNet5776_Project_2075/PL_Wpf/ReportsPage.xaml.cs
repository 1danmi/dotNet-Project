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
    /// Interaction logic for ReportsPage.xaml
    /// </summary>
    public partial class ReportsPage : Page
    {
        Ibl bl;
        public ReportsPage()
        {
            InitializeComponent();
            bl = FactoryBl.getBl();
            this.PredicateComboBox.ItemsSource = App.CompPred;

        }

        
        private void BranchRevenueButton_Click(object sender, RoutedEventArgs e)
        {
            BranchRevenueUserControl uc = new BranchRevenueUserControl();
            uc.Source = bl.revenuePerBranch();
            this.ReportContentCotrol.Content = uc;
        }

        private void DishRevenueButton_Click(object sender, RoutedEventArgs e)
        {
            DishRevenueUserControl uc = new DishRevenueUserControl();
            uc.Source = bl.revenuePerDish();
            this.ReportContentCotrol.Content = uc;
        }

       

        private void FindOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PredicateComboBox.SelectedItem == null)
                    throw new Exception("you must choose predicate first!");
                OrdersUserControl uc = new OrdersUserControl();
                if ((string)PredicateComboBox.SelectedItem == "<")
                    uc.Source = bl.findOrders(x => bl.calcTotalPrice(x.OrderID) < Convert.ToInt32(FindOrdertextBox.Text));
                else if ((string)PredicateComboBox.SelectedItem == ">")
                    uc.Source = bl.findOrders(x => bl.calcTotalPrice(x.OrderID) > Convert.ToInt32(FindOrdertextBox.Text));
                else if ((string)PredicateComboBox.SelectedItem == "<=")
                    uc.Source = bl.findOrders(x => bl.calcTotalPrice(x.OrderID) <= Convert.ToInt32(FindOrdertextBox.Text));
                else if ((string)PredicateComboBox.SelectedItem == ">=")
                    uc.Source = bl.findOrders(x => bl.calcTotalPrice(x.OrderID) >= Convert.ToInt32(FindOrdertextBox.Text));
                else if ((string)PredicateComboBox.SelectedItem == "=")
                    uc.Source = bl.findOrders(x => bl.calcTotalPrice(x.OrderID) == Convert.ToInt32(FindOrdertextBox.Text));
                this.ReportContentCotrol.Content = uc;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OrdersPerMonth_Click(object sender, RoutedEventArgs e)
        {
            RevenuePerMonthUserControl uc = new RevenuePerMonthUserControl();
            uc.Source = bl.ordersPerMonth();
            this.ReportContentCotrol.Content = uc;
        }
    }
}
