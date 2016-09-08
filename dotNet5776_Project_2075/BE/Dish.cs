using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace BE
{
    
    public class Dish : IComparable
    {
        #region Properties

        public int DishID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public SIZE Size { get; set; }

        public double Price { get; set; }

        public KOSHER Kosher { get; set; }

        public DISH_TYPE DishType { get; set; }

        private string imageSource;

        public string ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; }
        } 
           
        //public Image Photo { get; set; } 

        #endregion

        /// <summary>
        ///     Initializes a new instance of the Dish class to the value indicated
        ///     by the given parameters.
        /// </summary>
        /// 
        /// <param name="name">Dish's name</param>
        /// <param name="size">Dish's size</param>
        /// <param name="price">Dish's price</param>
        /// <param name="kosher">Dish's kashrut</param>
        public Dish(string name, string description, SIZE size, double price = 0, KOSHER kosher = KOSHER.Rabanut, DISH_TYPE dishType = DISH_TYPE.Fish)
        {
            Name = name;
            Description = description;
            Size = size;
            Price = price;
            Kosher = kosher;
            DishType = dishType;
        }
        public Dish() { }

        /// <summary>
        ///     Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// 
        /// <returns>
        ///     The string representation of the dish's properties.
        /// </returns>
        public override string ToString()
        {
            return DishID + " " + Name;
        }

        /// <summary>
        ///     Compares this instance to a specified Dish and returns an indication
        ///     of their relative values.  
        /// </summary>
        /// 
        /// <param name="obj">
        ///      The Dish to compare with this instance.
        /// </param>
        /// 
        /// <returns>
        ///     A 32-bit signed integer that indicates whether this instance precedes, follows,
        ///     or appears in the same position in the sort order as the value parameter.Value
        ///     Condition Less than zero This instance precedes obj. Zero This instance has
        ///     the same position in the sort order as obj. Greater than zero This instance
        ///     follows obj.-or- obj is null.
        ///</returns>
        public int CompareTo(object obj)
        {
            return DishID.CompareTo(((Dish)obj).DishID);
        }
    }
}
