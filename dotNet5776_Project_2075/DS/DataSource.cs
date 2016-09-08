using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Collections.ObjectModel;
namespace DS
{
    public class DataSource
    {
        public static List<Branch> branches = new List<Branch>();
        public static List<Client> clients = new List<Client>();
        public static List<Dish> dishes = new List<Dish>();
        public static List<Order> orders = new List<Order>();

        //public static List<Ordered_Dish> orderedDishes = new List<Ordered_Dish>();
    }
}
