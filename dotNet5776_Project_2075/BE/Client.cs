using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Client : IComparable
    {
        #region Properties

        public int ClientID { get; set; }

        public string Name { get; set; }

        public Address Add { get; set; }

        public Address Location { get; set; }
         
        public string PhoneNumber { get; set; }

        public string strBD
        {
            get { return BirthDate.Date.ToString("d"); }
        }

        public bool Delivery { get; set; }

        public DateTime BirthDate { get; set; }

        #endregion


        /// <summary>
        /// Initializes a new instance of the Branch class to the value indicated
        /// by the given parameters.
        /// </summary>
        public Client(string name, string street, int houseNo, CITY city, int zipCode, string phoneNumber = null)
        {
            BirthDate = new DateTime(1996, 1, 1);
            Name = name;
            Add = new Address(street, houseNo, city, zipCode);
            Location = Add;
            PhoneNumber = phoneNumber;
        }
        /// <summary>
        /// Default CTOR
        /// </summary>
        public Client() { }

        /// <summary>
        ///     Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// 
        /// <returns>
        ///     The string representation of the client's properties
        /// </returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        ///     Compares this instance to a specified Client and returns an indication
        ///     of their relative values.
        /// </summary>
        /// 
        /// <param name="obj">
        ///      The Client to compare with this instance.
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
            return ClientID.CompareTo(((Client)obj).ClientID);
        }
    }
}
