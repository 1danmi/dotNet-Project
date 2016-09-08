using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PL_Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string[] CompPred = new string[] { "<", ">", "<=", ">=", "=" };
        public static bool isPhoneValid(string s)
        {
            return Regex.Match(s, @"[0-9]+${9,10}").Success;
        }
        public static bool isWordValid(string s)
        {
            return Regex.Match(s, @"[a-zA-Z\s]+${1,20}").Success;
        }
        public static bool isHouseNoValid(string s)
        {
            return Regex.Match(s, @"(\d{1,3}){1}").Success;
        }
        public static bool isZipCodeValid(string s)
        {
            return Regex.Match(s, @"(\d{5,7}){1}").Success;
        }

        

        public static void Word_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox x = sender as TextBox;
            if (App.isWordValid(x.Text))
                x.BorderBrush = Brushes.Green;
            else
                x.BorderBrush = Brushes.Red;
        }
        public static void Phone_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox x = sender as TextBox;
            if (App.isPhoneValid(x.Text))
                x.BorderBrush = Brushes.Green;
            else
                x.BorderBrush = Brushes.Red;
        }
        public static void HouseNo_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox x = sender as TextBox;
            if (App.isHouseNoValid(x.Text))
                x.BorderBrush = Brushes.Green;
            else
                x.BorderBrush = Brushes.Red;
        }
        public static void ZipCode_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox x = sender as TextBox;
            if (App.isZipCodeValid(x.Text))
                x.BorderBrush = Brushes.Green;
            else
                x.BorderBrush = Brushes.Red;
        }
    }
}
