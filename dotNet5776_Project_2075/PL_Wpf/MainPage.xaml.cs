using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BE;
using BL;

namespace PL_Wpf
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        Ibl bl;
        ManagementUserControl p;
        public Order order;
        public MainPage()
        {
            bl = FactoryBl.getBl();
            InitializeComponent();
            ManagementUserControl p = new ManagementUserControl();
            order = new Order();

        }

        private void newOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Page p = new AddOrderPage();
            this.NavigationService.Navigate(p);
        }

        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            Window w = new MenuWindow();
            w.Show();
        }

        
        private void ExistingOrderButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w1 = Window.GetWindow(this) as MainWindow;
            GetOrderIDWindow w2 = new GetOrderIDWindow();
            w2.Owner = w1;
            w2.ShowDialog();

        }

        
        private void NewOrderButton_MouseEnter(object sender, MouseEventArgs e)
        {

            this.NewOrderButton.FontSize = 60;
        }

        private void NewOrderButton_MouseLeave(object sender, MouseEventArgs e)
        {
            this.NewOrderButton.FontSize = 50;
        }



        

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.TransitionFrame.UnloadPage(p);
        }

        private void ManagementButton_Click(object sender, RoutedEventArgs e)
        {
            ManagementUserControl p = new ManagementUserControl();
            this.TransitionFrame.ShowPage(p);
        }          
        
    }
}
