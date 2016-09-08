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
using BL;
using BE;
using System.Collections.ObjectModel;

namespace PL_Wpf
{
    /// <summary>
    /// Interaction logic for UpdateDeletePage.xaml
    /// </summary>
    public partial class UpdateDeletePage : Page
    {
        Ibl bl;
        public UpdateDeletePage()
        {
            InitializeComponent();
            bl = FactoryBl.getBl();
            this.BranchesDataGrid.ItemsSource = bl.getBranchesList();
            this.ClientsDataGrid.ItemsSource = bl.getClientsList();
            this.OrdersDataGrid.ItemsSource = bl.getOrdersList();
            this.DishesDataGrid.ItemsSource = bl.getDishesList();
        }

        private void BranchEditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Branch obj = ((FrameworkElement)sender).DataContext as Branch;
                UpdateBranchPage p = new UpdateBranchPage(bl.getBranch(obj.BranchID));
                this.NavigationService.Navigate(p);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteBranchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Branch obj = ((FrameworkElement)sender).DataContext as Branch;
                bl.delBranch(obj.BranchID);
                this.BranchesDataGrid.ItemsSource = null;
                this.BranchesDataGrid.ItemsSource = bl.getBranchesList();
                this.OrdersDataGrid.ItemsSource = null;
                this.OrdersDataGrid.ItemsSource = bl.getOrdersList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClientEditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client obj = ((FrameworkElement)sender).DataContext as Client;
                UpdateClientPage p = new UpdateClientPage(bl.getClient(obj.ClientID));
                this.NavigationService.Navigate(p);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteClientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client obj = ((FrameworkElement)sender).DataContext as Client;
                bl.delClient(obj.ClientID);
                this.ClientsDataGrid.ItemsSource = null;
                this.ClientsDataGrid.ItemsSource = bl.getClientsList();
                this.OrdersDataGrid.ItemsSource = null;
                this.OrdersDataGrid.ItemsSource = bl.getOrdersList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OrderEditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order obj = ((FrameworkElement)sender).DataContext as Order;
                UpdateOrderPage p = new UpdateOrderPage(bl.getOrder(obj.OrderID));
                this.NavigationService.Navigate(p);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order obj = ((FrameworkElement)sender).DataContext as Order;
                bl.delOrder(obj.OrderID);
                this.OrdersDataGrid.ItemsSource = null;
                this.OrdersDataGrid.ItemsSource = bl.getOrdersList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void DishEditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dish obj = ((FrameworkElement)sender).DataContext as Dish;
                UpdateDishPage p = new UpdateDishPage(bl.getDish(obj.DishID));
                this.NavigationService.Navigate(p);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void DeleteDishButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dish obj = ((FrameworkElement)sender).DataContext as Dish;
                bl.delDish(obj.DishID);
                this.DishesDataGrid.ItemsSource = null;
                this.DishesDataGrid.ItemsSource = bl.getDishesList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
    }
}
