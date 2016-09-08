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
    /// Interaction logic for InfoPage.xaml
    /// </summary>
    public partial class InfoPage : Page
    {
        Ibl bl;
        public InfoPage()
        {
            InitializeComponent();
            bl = FactoryBl.getBl();
            this.BranchesListBox.ItemsSource = bl.getBranchesList();
            this.ClientsListBox.ItemsSource = bl.getClientsList();
            this.OrdersListBox.ItemsSource = bl.getOrdersList();
        }

        private void BranchesButton_Click(object sender, RoutedEventArgs e)
        {
            //this.BranchesListBox.ItemsSource = bl.getBranchesList();
            this.BranchesListBox.Visibility = System.Windows.Visibility.Visible;
            this.ClientsListBox.Visibility = System.Windows.Visibility.Hidden;
            this.OrdersListBox.Visibility = System.Windows.Visibility.Hidden;

        }

        private void ClientsButton_Click(object sender, RoutedEventArgs e)
        {
            //this.BranchesListBox.ItemsSource = bl.getClientList();
            this.BranchesListBox.Visibility = System.Windows.Visibility.Hidden;
            this.ClientsListBox.Visibility = System.Windows.Visibility.Visible;
            this.OrdersListBox.Visibility = System.Windows.Visibility.Hidden;

        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            //this.BranchesListBox.ItemsSource = bl.getOrdersList();
            this.BranchesListBox.Visibility = System.Windows.Visibility.Hidden;
            this.ClientsListBox.Visibility = System.Windows.Visibility.Hidden;
            this.OrdersListBox.Visibility = System.Windows.Visibility.Visible;
        }

        private void Branches_Row_DoubleClick(object sender, RoutedEventArgs e)
        {
            DataGridRow r = sender as DataGridRow;
            Branch d = r.Item as Branch;
            UpdateBranchPage p = new UpdateBranchPage(bl.getBranch(d.BranchID));
            p.branch = d;
            NavigationService.Navigate(p);
        }
    }
}
