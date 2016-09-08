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
using System.Collections.ObjectModel;
using BE;
using BL;
using System.ComponentModel;

namespace PL_Wpf
{
    /// <summary>
    /// Interaction logic for AddDishesToOrderPage.xaml
    /// </summary>
    public partial class AddDishesToOrderPage : Page
    {
        Ibl bl;

        public Ordered_Dish od = new Ordered_Dish();
        public AddDishesToOrderPage()
        {
            try
            {
                InitializeComponent();
                bl = FactoryBl.getBl();
                this.DishTypeComboBox.ItemsSource = Enum.GetValues(typeof(DISH_TYPE));
                this.MainGrid.DataContext = od;
                this.DishDataGrid.ItemsSource = bl.getDishesList();
                this.OrderedDishDataGrid.ItemsSource = bl.getOrderedDishes(od.OrderID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                InitializeComponent();
            }

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();

        }

        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            while (this.NavigationService.CanGoBack)
                this.NavigationService.GoBack();
        }

        private void OrderIDTextBox_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (bl.getOrder(od.OrderID) == null && od.OrderID != 0)
            {
                MessageBox.Show("Order does not exist!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.NavigationService.GoBack();
            }
        }


        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DataGridRow r = sender as DataGridRow;
                Dish d = r.Item as Dish;
                Ordered_Dish x = new Ordered_Dish();
                x.DishID = d.DishID;
                x.OrderID = od.OrderID;
                bl.addOD(x);
                OrderedDishDataGrid.ItemsSource = bl.getOrderedDishes(od.OrderID);
                this.PriceLabel.Content = bl.calcTotalPrice(od.OrderID);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OrderedDishDataGrid_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            this.OrderedDishDataGrid.ItemsSource = bl.getOrderedDishes(od.OrderID);
        }

        private void DishTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((DISH_TYPE)this.DishTypeComboBox.SelectedItem == DISH_TYPE.Salads)
                this.DishDataGrid.ItemsSource = bl.dishesForDishType(DISH_TYPE.Salads);
            else if ((DISH_TYPE)this.DishTypeComboBox.SelectedItem == DISH_TYPE.Soups)
                this.DishDataGrid.ItemsSource = bl.dishesForDishType(DISH_TYPE.Soups);
            else if ((DISH_TYPE)this.DishTypeComboBox.SelectedItem == DISH_TYPE.Fish)
                this.DishDataGrid.ItemsSource = bl.dishesForDishType(DISH_TYPE.Fish);
            else if ((DISH_TYPE)this.DishTypeComboBox.SelectedItem == DISH_TYPE.Meat)
                this.DishDataGrid.ItemsSource = bl.dishesForDishType(DISH_TYPE.Meat);
            else if ((DISH_TYPE)this.DishTypeComboBox.SelectedItem == DISH_TYPE.Desserts)
                this.DishDataGrid.ItemsSource = bl.dishesForDishType(DISH_TYPE.Desserts);
            else if ((DISH_TYPE)this.DishTypeComboBox.SelectedItem == DISH_TYPE.Beverages )
                this.DishDataGrid.ItemsSource = bl.dishesForDishType(DISH_TYPE.Beverages );
            else
                this.DishDataGrid.ItemsSource = bl.getDishesList();
        }

        private void ShowAllButton_Click(object sender, RoutedEventArgs e)
        {
            this.DishDataGrid.ItemsSource = bl.getDishesList();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Ordered_Dish obj = ((FrameworkElement)sender).DataContext as Ordered_Dish;
            bl.delOD(obj.ItemID);
            OrderedDishDataGrid.ItemsSource = bl.getOrderedDishes(od.OrderID);
            this.PriceLabel.Content = bl.calcTotalPrice(od.OrderID);

        }
    }
}
