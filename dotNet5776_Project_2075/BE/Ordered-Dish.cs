using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Ordered_Dish : IComparable
    {

        #region Properties

        public int ItemID { get; set; }

        public int OrderID { get; set; }

        public int DishID { get; set; }

        public int Amount { get; set; } = 1;

        #endregion

        /// <
        /// mary>
        ///     Initializes a new instance of the Branch class to the value indicated
        ///     by the given parameters.
        /// </summary>
        /// 
        /// <param name="orderID">The OrderID of the ordered order.</param>
        /// <param name="dishID"> The DishID of the ordered dish.</param>
        /// <param name="amount"> Amount of dishes orderd.</param>
        ///public Ordered_Dish(int orderID=0, int dishID=0, int amount=0)
        //{
        //    ItemID = 0;
        //    OrderID = orderID;
        //    DishID = dishID;
        //    Amount = amount;
        //}
        /// <summary>
        ///     Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// 
        /// <returns>
        ///     The string representation of the ordered-dish's properties.
        /// </returns>
        public override string ToString()
        {
            return ItemID.ToString() + " " + OrderID.ToString() + " " + DishID.ToString() + " " + Amount.ToString();
        }
        /// <summary>
        ///     Compares this instance to a specified Branch and returns an indication
        ///     of their relative values.  
        /// </summary>
        /// 
        /// <param name="obj">
        ///      The Ordered-Dish to compare with this instance.
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
            return ItemID.CompareTo(((Ordered_Dish)obj).ItemID);
        }

      
    }
}
