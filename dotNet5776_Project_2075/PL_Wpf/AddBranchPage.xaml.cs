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
    /// Interaction logic for AddBranchPage.xaml
    /// </summary>
    public partial class AddBranchPage : Page
    {
        Ibl bl;
        public Branch branch { get; set; }
        public AddBranchPage()
        {
            InitializeComponent();
            bl = FactoryBl.getBl();
            branch = new Branch();
            this.MainGrid.DataContext = branch;
            this.AddressGrid.DataContext = branch.Add;

            this.KashrutComboBox.ItemsSource = Enum.GetValues(typeof(KOSHER));
            this.CityComboBox.ItemsSource = Enum.GetValues(typeof(CITY));
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            try {
                int errorCount = 0;
                foreach (var child in this.MainGrid.Children)
                    if (child is System.Windows.Controls.TextBox)
                    {
                        TextBox textBox = child as TextBox;
                        if ((!App.isWordValid(textBox.Text) && textBox != this.HouseNumberTextBox && textBox != this.ZipCodeTextBox && textBox != this.PhoneNumberTextBox) ||
                            (textBox == this.HouseNumberTextBox && !App.isHouseNoValid(textBox.Text)) || (textBox == this.ZipCodeTextBox && !App.isZipCodeValid(textBox.Text)) ||
                            (textBox == this.PhoneNumberTextBox && !App.isPhoneValid(textBox.Text)))
                        {
                            errorCount++;
                            textBox.BorderBrush = Brushes.Red;
                        }
                        else
                            textBox.BorderBrush = Brushes.Black;
                    }
                if (errorCount != 0)
                    throw new Exception("Please fill all the fields correctly!");
                bl.addBranch(branch);
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

    }
}
