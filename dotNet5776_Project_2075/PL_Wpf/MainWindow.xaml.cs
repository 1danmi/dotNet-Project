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
using System.Xml.Serialization;
using System.IO;

namespace PL_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ibl bl; 
        public MainWindow()
        {
            bl = FactoryBl.getBl();
            InitializeComponent();
            bl.loadBranchesFromXML("BranchesXmlBySerilalizer.xml");
            bl.loadDishesFromXML("DishesXmlBySerilalizer.xml");
            bl.loadClientsFromXML("ClientsXmlBySerilalizer.xml");
            bl.loadOrdersFromXML("OrdersXmlBySerilalizer.xml");
            //bl.loadODFromXML("ODXmlBySerilalizer.xml");
            MainFrame.Navigate(new MainPage());
            
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            bl.saveBranchesToXML("BranchesXmlBySerilalizer.xml");
            bl.saveDishesToXML("DishesXmlBySerilalizer.xml");
            bl.saveClientsToXML("ClientsXmlBySerilalizer.xml");
            bl.saveOrdersToXML("OrdersXmlBySerilalizer.xml");
            //bl.saveODToXML("ODXmlBySerilalizer.xml");
            this.Close();
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            //if (this.WindowState == WindowState.Normal)
            //    this.WindowState = WindowState.Maximized;
            //else
            //    this.WindowState = WindowState.Normal;
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try {
                this.DragMove();
            }
            catch(Exception ex)
            {
               
            }
        }

        
    }
}
