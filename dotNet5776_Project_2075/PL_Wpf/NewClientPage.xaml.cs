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
    /// Interaction logic for NewClientPage.xaml
    /// </summary>
    public partial class NewClientPage : Page
    {
        public Client client; public Address Add; public Address Location;
        Ibl Bl;
        public NewClientPage()
        {
            Bl = FactoryBl.getBl();
            Add = new Address();
            Location = new Address();
            InitializeComponent();
            client = new Client();
            this.CityComboBox.ItemsSource = Enum.GetValues(typeof(CITY));
            this.DeliveryCityComboBox.ItemsSource = Enum.GetValues(typeof(CITY));
            this.MainGrid.DataContext = client;
            this.AddressGrid.DataContext = Add;
            this.DeliveryAddressGrid.DataContext =Location;
            this.BirthDatePicker.DisplayDateStart = new DateTime(1900, 1, 1).Date;
            this.BirthDatePicker.DisplayDateEnd = new DateTime(DateTime.Now.Year-18,DateTime.Now.Month,DateTime.Now.Day).Date;
            foreach(var child in MainGrid.Children)
            {
                if (child is TextBox)
                    ((TextBox)child).BorderBrush = Brushes.Black;
                if(child is ComboBox)
                    ((ComboBox)child).BorderBrush = Brushes.Black;
            }
            
        }


        

       

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            try {
                int errorCount = 0;
                foreach (var child in this.MainGrid.Children)
                {
                    if (child is TextBox)
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
                    else if (child is ComboBox)
                    {
                        ComboBox comboBox = child as ComboBox;
                        if (comboBox.SelectedItem == null)
                        {
                            comboBox.BorderBrush = Brushes.Red;
                            errorCount++;
                        }
                        else
                            comboBox.BorderBrush = Brushes.Black;
                    }
                }
                if(DifferntAddressCheckBox.IsChecked==true)
                    foreach(var child in DeliveryAddressGrid.Children)
                    {
                        if (child is TextBox)
                        {
                            TextBox textBox = child as TextBox;
                            if ((textBox == DeliveryStretTextBox && !App.isWordValid(textBox.Text))||(textBox == DeliveryHouseNoTextBox && !App.isHouseNoValid(textBox.Text))||(textBox==DeliveryZipCodeTextBox&&!App.isZipCodeValid(textBox.Text)))
                            {
                                textBox.BorderBrush = Brushes.Red;
                                errorCount++;
                            }
                            else
                                textBox.BorderBrush = Brushes.Black;
                        }
                        if(child is ComboBox)
                        {
                            ComboBox comboBox = child as ComboBox;
                            if (comboBox.SelectedItem == null)
                            {
                                comboBox.BorderBrush = Brushes.Red;
                                errorCount++;
                            }
                            else
                                comboBox.BorderBrush = Brushes.Black;
                        }
                    }       
                if (errorCount != 0)
                    throw new Exception("Please fill all the fields correctly!");

                client.Add = Add;
                if(DifferntAddressCheckBox.IsChecked==true)
                    client.Location = Location;
                Bl.addClient(client);
                AddOrderPage2 newOrder = new AddOrderPage2();
                newOrder.order.ClientID = Bl.findClientByPhoneNumber(client.PhoneNumber).ClientID;
                this.NavigationService.Navigate(newOrder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        bool isTheFormFull()
        {

            if (client.Name != null && client.Add.Street != null && client.Add.HouseNO != 0 && client.Add.City != 0 && client.Add.ZipCode != 0 && client.BirthDate.Date != null)
            {
                if (DeliveryAddressGrid.IsEnabled)
                    if (client.Location.Street == null || client.Location.HouseNO == 0 || client.Location.City == 0 || client.Location.ZipCode == 0)
                        return false;
                return true;
            }
            else
                return false;            
            

        }

        private void Word_LostFocus(object sender, RoutedEventArgs e)
        {
            App.Word_LostFocus(sender, e);
        }
        private void Phone_LostFocus(object sender, RoutedEventArgs e)
        {
            App.Phone_LostFocus(sender, e);
        }
        private void HouseNo_LostFocus(object sender, RoutedEventArgs e)
        {
            App.HouseNo_LostFocus(sender, e);
        }
        private void ZipCode_LostFocus(object sender, RoutedEventArgs e)
        {
            App.ZipCode_LostFocus(sender, e);
        }

    }
}
