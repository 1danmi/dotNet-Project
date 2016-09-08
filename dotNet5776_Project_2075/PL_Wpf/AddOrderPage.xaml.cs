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
    /// Interaction logic for AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        public Client client;
        Ibl bl; 
        public AddOrderPage()
        {
            InitializeComponent();
            client = new Client();
            bl = FactoryBl.getBl();
            this.DataContext = client;

        }

        //private void BackButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if(this.NavigationService.CanGoBack)
        //        this.NavigationService.GoBack();
        //}

        private void OpenClientButton_Click(object sender, RoutedEventArgs e)
        {
            NewClientPage p = new NewClientPage();
            this.NavigationService.Navigate(p);
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string s = this.PhoneTextBox.Text;
                //if (s == "")
                //    throw new Exception("Please enter a phone number!");
                if (App.isPhoneValid(s))
                {
                    this.PhoneTextBox.BorderBrush = Brushes.Black;
                    this.PhoneTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                    AddOrderPage2 p = new AddOrderPage2();
                    p.order.ClientID = bl.findClientByPhoneNumber(client.PhoneNumber).ClientID;
                    this.NavigationService.Navigate(p);
                }
                else
                {
                    this.PhoneTextBox.BorderBrush = Brushes.Red;
                    throw new Exception("Phone number must contain 9-10 digits only!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr", MessageBoxButton.OK, MessageBoxImage.Error);     
            }
            
            
            
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoForward)
                this.NavigationService.GoForward();
        }
    }
}
