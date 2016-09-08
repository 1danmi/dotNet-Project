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
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    

    public partial class MenuPage : Page
    {
        Ibl bl;
        public MenuPage()
        {
            InitializeComponent();
            bl = FactoryBl.getBl();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }

        private void SaladsButton_Click(object sender, RoutedEventArgs e)
        {
            DishListPage p = new DishListPage(DISH_TYPE.Salads);
            //p.dt.DT = DISH_TYPE.Salads;
            this.NavigationService.Navigate(p);
            
        }

        private void DesertsButton_Click(object sender, RoutedEventArgs e)
        {
            DishListPage p = new DishListPage(DISH_TYPE.Desserts);
            //p.dt.DT = DISH_TYPE.Deserts;
            this.NavigationService.Navigate(p);
        }

        private void FishButton_Click(object sender, RoutedEventArgs e)
        {
            DishListPage p = new DishListPage(DISH_TYPE.Fish);
            //p.dt.DT = DISH_TYPE.Starters;
            this.NavigationService.Navigate(p);
        }

        private void DrinksButton_Click(object sender, RoutedEventArgs e)
        {
            DishListPage p = new DishListPage(DISH_TYPE.Beverages );
            //p.dt.DT = DISH_TYPE.Drinks;
            this.NavigationService.Navigate(p);
        }

        private void MainsButton_Click(object sender, RoutedEventArgs e)
        {
            DishListPage p = new DishListPage(DISH_TYPE.Meat);
            //p.dt.DT = DISH_TYPE.Mains;
            this.NavigationService.Navigate(p);
        }

        private void SoupsButton_Click(object sender, RoutedEventArgs e)
        {
            DishListPage p = new DishListPage(DISH_TYPE.Soups);
            //p.dt.DT = DISH_TYPE.Mains;
            this.NavigationService.Navigate(p);
        }
    }
}
