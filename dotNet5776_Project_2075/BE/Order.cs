using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{

    public class Order : IComparable
    {
        
        
        #region Properties
        

        public int OrderID { get; set; }

        public DateTime Time { get; set; }

        public int BranchID { get; set; }

        public KOSHER Kosher { get; set; }

        public CreditCard CreditCard { get; set; }

        public string Voucher { get; set; }

        public int ClientID { get; set; }

        public PAYMENT PaymentType { get; set; }

        public bool Delivery { get; set; }

        public string Notes { get; set; }

        #endregion


        /// <summary>
        ///  Initializes a new instance of the Order class to the value indicated
        ///  by the given parameters.
        /// </summary>
        //public Order(int orderID, int branchID, KOSHER kosher, CreditCard creditCard, int clientID, PAYMENT paymentType, bool delivery)
        //{
        //    OrderID = orderID;
        //    Time = DateTime.Now;
        //    BranchID = branchID;
        //    Kosher = kosher;
        //    CreditCard = creditCard;
        //    ClientID = clientID;
        //    PaymentType = paymentType;
        //    Delivery = delivery;
        //}

        /// <summary>
        ///     Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// 
        /// <returns>
        ///     The string representation of the order's properties.
        /// </returns>
        public override string ToString()
        {
            return OrderID.ToString();
        }

        /// <summary>
        ///     Compares this instance to a specified Order and returns an indication
        ///     of their relative values.
        /// </summary>
        /// 
        /// <param name="obj">
        ///      The Order to compare with this instance.
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
            return OrderID.CompareTo(((Order)obj).OrderID);
        }

    }
}
