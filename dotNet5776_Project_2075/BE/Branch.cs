using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Branch : IComparable
    {
        
        #region Properties

        public int BranchID { get; set; }
       
        public string Name { get; set; }

        public Address Add { get; set; }
       
        public string ManagerName { get; set; }

        public string PhoneNumber { get; set; }
             

        public KOSHER Kosher { get; set; }

        #endregion

        /// <summary>
        ///      Initializes a new instance of the Branch class to the value indicated
        ///      by the given parameters.
        /// </summary>
        public Branch(string name, string street, int houseNo, CITY city, int zipCode, string managerName, string phoneNumber, KOSHER kosher)
        {
            Add = new Address();
            Name = name;
            Add.Street = street;
            Add.HouseNO = houseNo;
            Add.City = city;
            Add.ZipCode = zipCode;
            ManagerName = managerName;
            PhoneNumber = phoneNumber;
            Kosher = kosher;
        }
       /// <summary>
       /// Default CTOR
       /// </summary>
        public Branch() { Add = new Address(); }

        /// <summary>
        ///     Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// 
        /// <returns>
        ///     The string representation of the branch's properties.
        /// </returns>
        public override string ToString()
        {
            return BranchID + " " + Name + ", " + Add.City + ", " + Kosher;
        }

        /// <summary>
        ///     Compares this instance to a specified Branch and returns an indication
        ///     of their relative values.    
        /// </summary>
        /// 
        /// <param name="obj">
        ///      The Branch to compare with this instance.
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
            return BranchID.CompareTo(((Branch)obj).BranchID);
        }
        
    }
}
