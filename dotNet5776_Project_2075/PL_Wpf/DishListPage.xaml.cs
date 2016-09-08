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

namespace PL_Wpf
{
    public class DishType
    {
        public DISH_TYPE DT { get; set; }
    }
    /// <summary>
    /// Interaction logic for DishListPage.xaml
    /// </summary>
    public partial class DishListPage : Page
    {
        Ibl bl;
        public DishType dt;
        public DishListPage(DISH_TYPE DishT)
        {
            InitializeComponent();
            bl = FactoryBl.getBl();
            dt = new DishType();
            dt.DT = DishT;
            this.DataContext = dt;
            this.DishListBox.ItemsSource = bl.dishesForDishType(dt.DT);

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        
        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }

        private void TitleLabel_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            this.DishListBox.ItemsSource = bl.dishesForDishType(dt.DT);
        }

    }
    
}
