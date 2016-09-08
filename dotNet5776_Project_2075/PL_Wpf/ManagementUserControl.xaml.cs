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

namespace PL_Wpf
{
    /// <summary>
    /// Interaction logic for ManagementUserControl.xaml
    /// </summary>
    public partial class ManagementUserControl : UserControl
    {

        public ManagementUserControl()
        {
            InitializeComponent();
        }

        private void AddBranchButton_Click(object sender, RoutedEventArgs e)
        {
            AddBranchPage p = new AddBranchPage();
            MainWindow w = Window.GetWindow(this) as MainWindow;
            var x = w.MainFrame.Content as MainPage;
            x.TransitionFrame.UnloadPage(this);
            w.MainFrame.Navigate(p);
        }

        private void AddDishButton_Click(object sender, RoutedEventArgs e)
        {
            AddDishPage p = new AddDishPage();
            MainWindow w = Window.GetWindow(this) as MainWindow;
            var x = w.MainFrame.Content as MainPage;
            x.TransitionFrame.UnloadPage(this);
            w.MainFrame.Navigate(p);
        }

        //private void InfoButton_Click(object sender, RoutedEventArgs e)
        //{
        //    InfoPage p = new InfoPage();
        //    MainWindow w = Window.GetWindow(this) as MainWindow;
        //    var x = w.MainFrame.Content as MainPage;
        //    x.TransitionFrame.UnloadPage(this);
        //    w.MainFrame.Navigate(p);
        //}

        private void UpdateInfoButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDeletePage p = new UpdateDeletePage();
            MainWindow w = Window.GetWindow(this) as MainWindow;
            var x = w.MainFrame.Content as MainPage;
            x.TransitionFrame.UnloadPage(this);
            w.MainFrame.Navigate(p);
        }

        private void QueriesButton_Click(object sender, RoutedEventArgs e)
        {
            QueriesPage p = new QueriesPage();
            MainWindow w = Window.GetWindow(this) as MainWindow;
            var x = w.MainFrame.Content as MainPage;
            x.TransitionFrame.UnloadPage(this);
            w.MainFrame.Navigate(p);
        }

        private void ReportsButton_Click(object sender, RoutedEventArgs e)
        {
            ReportsPage p = new ReportsPage();
            MainWindow w = Window.GetWindow(this) as MainWindow;
            var x = w.MainFrame.Content as MainPage;
            x.TransitionFrame.UnloadPage(this);
            w.MainFrame.Navigate(p);
        }
    }
}
