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
    /// Interaction logic for AddDishPage.xaml
    /// </summary>
    public partial class AddDishPage : Page
    {
        Ibl bl;
        public Dish dish { get; set; }
        public AddDishPage()
        {
            InitializeComponent();
            bl = FactoryBl.getBl();
            dish = new Dish();
            DishTypeComboBox.ItemsSource = Enum.GetValues(typeof(DISH_TYPE));
            SizeComboBox.ItemsSource = Enum.GetValues(typeof(SIZE));
            KashrutComboBox.ItemsSource = Enum.GetValues(typeof(KOSHER));
            MainGrid.DataContext = dish;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            try {
                if (this.DishTypeComboBox.SelectedItem == null)
                {
                    this.DishTypeComboBox.BorderBrush = Brushes.Red;
                    throw new Exception("You must select dish type!");
                }
                if (App.isWordValid(NameTextBox.Text))
                {
                    NameTextBox.BorderBrush = Brushes.Red;
                    
                }
                bl.addDish(dish);
                this.NavigationService.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void ChooseImageButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog f = new Microsoft.Win32.OpenFileDialog();
            f.Filter = "All Files (*)|*|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            if (f.ShowDialog() == true)
            {
                BitmapImage a = new BitmapImage(new Uri(f.FileName));
                this.DishImage.Source = a;
            }
            
        }
        private void stop() { }

        private void DishTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DishTypeComboBox.SelectedItem == null)
                DishTypeComboBox.BorderBrush = Brushes.Red;
            else
                DishTypeComboBox.BorderBrush = Brushes.Black;
        }
    }
}
