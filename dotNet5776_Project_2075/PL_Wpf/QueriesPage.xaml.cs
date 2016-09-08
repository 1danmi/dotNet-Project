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
    public class QueryAns
    {
        public double RevenueForCity { get; set; }

        public double RevenueForDishType { get; set; }

        public double RevenueForDish { get; set; }
        
        public double AverageOrder { get; set; }

        public double MostValueOrder { get; set; }
    }
    /// <summary>
    /// Interaction logic for QueriesPage.xaml
    /// </summary>
    public partial class QueriesPage : Page
    {
        Ibl bl;
        QueryAns qa;
        public QueriesPage()
        {
            bl = FactoryBl.getBl();
            qa = new QueryAns();
            InitializeComponent();
            qa.AverageOrder = bl.averageOrder();
            qa.MostValueOrder = bl.mostValueOrder();
            this.QueryGrid.DataContext = qa;
            this.CityComboBox.ItemsSource = Enum.GetValues(typeof(CITY));
            this.DishTypeComboBox.ItemsSource = Enum.GetValues(typeof(DISH_TYPE));
            this.DishComboBox.ItemsSource = bl.getDishesList();
            int MEO = bl.mostValueOrder();
            this.MostExpensiveOrderLabel.Content = "Order ID: " + MEO + "    Total Price: " + bl.calcTotalPrice(MEO)+ "₪";
            this.AverageOrderLabel.Content = bl.averageOrder() + "₪";
        }

        private void CityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.RevenueForCityTextBox.Text = bl.revenueForCity((CITY)CityComboBox.SelectedIndex).ToString();
        }

        private void DishTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.RevenueForDishTypeTextBox.Text = bl.revenueForDishType((DISH_TYPE)DishTypeComboBox.SelectedItem).ToString();
        }

        private void DishComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.RevenueForDishTextBox.Text = bl.revenueForDish(((Dish)DishComboBox.SelectedItem).DishID).ToString();
        }
    }
}
