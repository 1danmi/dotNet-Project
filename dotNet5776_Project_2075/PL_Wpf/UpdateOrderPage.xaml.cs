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
    /// Interaction logic for AddOrderPage2.xaml
    /// </summary>
    public partial class UpdateOrderPage : Page
    {
        Ibl bl;
        public Order order;
        public Branch branch;
        public UpdateOrderPage(Order o)
        {
            InitializeComponent();
            order = o;
            bl = FactoryBl.getBl();
            this.MainGrid.DataContext = order;
            this.BranchComboBox.ItemsSource = bl.getBranchesList();
            this.PaymentComboBox.ItemsSource = Enum.GetValues(typeof(PAYMENT));
            this.KashrutComboBox.ItemsSource = Enum.GetValues(typeof(KOSHER));
            this.creditCardUserControl.DataContext = order.CreditCard;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                order.BranchID = getBranchSelected();
                order.Time = DateTime.Now;
                KashrutComboBox.GetBindingExpression(ComboBox.TextProperty).UpdateSource();
                PaymentComboBox.GetBindingExpression(ComboBox.TextProperty).UpdateSource();
                this.creditCardUserControl.NameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                this.creditCardUserControl.NumberTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                this.creditCardUserControl.CVVTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                this.creditCardUserControl.MonthTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                this.creditCardUserControl.YearTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                this.NoteTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                int orderID = bl.nextOrderID();
                bl.updateOrder(order.OrderID,order);
                
                this.NavigationService.GoBack();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }
        private void isFormFull()
        {
            return;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void PaymentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((PAYMENT)this.PaymentComboBox.SelectedItem == PAYMENT.Diners || (PAYMENT)this.PaymentComboBox.SelectedItem == PAYMENT.MasterCard || (PAYMENT)this.PaymentComboBox.SelectedItem == PAYMENT.Visa)
            {
                this.creditCardUserControl.Visibility = System.Windows.Visibility.Visible;
                VoucherLabel.Visibility = System.Windows.Visibility.Hidden;
            }
            else if ((PAYMENT)this.PaymentComboBox.SelectedItem == PAYMENT.Voucher)
            {
                creditCardUserControl.Visibility = System.Windows.Visibility.Hidden;
                VoucherLabel.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                creditCardUserControl.Visibility = System.Windows.Visibility.Hidden;
                VoucherLabel.Visibility = System.Windows.Visibility.Hidden;
            }

        }

        private int getBranchSelected()
        {
            Branch var = this.BranchComboBox.SelectedValue as Branch;
            if (var == null)
                throw new Exception("You must select a branch");
            return var.BranchID;
        }
    }
}
