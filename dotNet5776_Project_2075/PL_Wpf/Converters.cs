using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using BE;
using BL;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;

namespace PL_Wpf
{
    public class IntToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int intValue = (int)value;
            if (intValue == 0)
                return System.Windows.Visibility.Hidden;
            else
                return System.Windows.Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class OrderIDToTotalPriceConverter : IValueConverter
    {
        Ibl bl = FactoryBl.getBl();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int orderID = (int)value;
            try
            {
                return bl.calcTotalPrice(orderID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }




        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class IntToVisibilityConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int intValue = (int)value;
            if (intValue == 0)
                return System.Windows.Visibility.Visible;
            else
                return System.Windows.Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                File.OpenRead((string)value);
                if(!File.Exists((string)value))
                    throw new Exception("");

                BitmapImage b = new BitmapImage(new Uri((string)value, UriKind.RelativeOrAbsolute));
                Console.WriteLine(b.DpiX);
                return b;
            }
            catch (Exception ex)
            {
                return new BitmapImage(new Uri(@"Images\Placeholder.jpg", UriKind.RelativeOrAbsolute));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return ((BitmapImage)value).UriSource.LocalPath;
            }
            catch
            {
                return @"Images\Placeholder.jpg";
            }
        }
    }

    public class BranchIDToBranchNameConverter : IValueConverter
    {
        Ibl bl = FactoryBl.getBl();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                int BranchID = (int)value;
                return bl.getBranch(BranchID).Name;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ClientIDToClientNameConverter : IValueConverter
    {
        Ibl bl = FactoryBl.getBl();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                int ClientID = (int)value;
                return bl.getClient(ClientID).Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DishIDToDishNameConverter : IValueConverter
    {
        Ibl bl = FactoryBl.getBl();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                int DishID = (int)value;
                return bl.getDish(DishID).Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class LocationToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((Address)value == null)
                return false;
            else
                return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class OrderIDToKosherConverter : IValueConverter
    {
        Ibl bl = FactoryBl.getBl();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return bl.getOrder((int)value).Kosher; 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class MonthNumToMonthNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                return mfi.GetMonthName((int)value).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
