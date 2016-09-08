using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    
    #region enums

    public enum PAYMENT { Cash, Check, Visa, MasterCard, Diners, Voucher }
    public enum KOSHER { Rabanut, Mehadrin ,Rabanut_Mehadrin, Badats, Badats_Mehadrin };
    public enum SIZE { S, M, L, XL };
    public enum CITY {Afula,Akko,Arad,Ariel,Ashdod,Ashkelon,Bat_Yam,Beer_Sheva,Beit_Shean,Beit_Shemesh,Betar_Illit,Bnei_Berak,Dimona,
Eilat,Givatayim,Hadera,Haifa,Herzliya,Hod_HaSharon,Holon,Jerusalem,Karmiel,Kfar_Sava,Kiryat_Ata,Kiryat_Bialik,Kiryat_Gat,Kiryat_Malachi,
Kiryat_Motzkin,Kiryat_Ono,Kiryat_Shemona,Kiryat_Yam,Lod,Maale_Adumim,Maalot_Tarshiha,Migdal_HaEmek,Modiin,Nahariya,Nazareth,Nazrat_Illit,
Nes_Ziona,Nesher,Netanya,Netivot,Or_Yehuda,Petah_Tikva,Raanana,Ramat_Hasharon,Ramat_Gan,Ramle,Rehovot,Rishon_Lezion,Rosh_Haayin,	
Sderot,Tel_Aviv,Tiberias,Tirat_Carmel,Tsfat,Yavne,Yehud_Monosson,Other}
    public enum DISH_TYPE { Salads,Soups ,Fish, Meat, Desserts, Beverages }
    public enum TYPE { Branch,CITY,Client,Dish,DISH_TYPE,KOSHER,Order,Ordered_Dish,PAYMENT,SIZE};

    public enum ComparisonPredicate
    {
        Equal,
        Unequal,
        LessThan,
        LessThanOrEqualTo,
        GreaterThan,
        GreaterThanOrEqualTo
    }

    
    #endregion

    #region Extra classes

    public class CreditCard
    {
        public string CardHolder { get; set; }
        public string Number { get; set; }
        public int CVV { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        //public CreditCard(string cardHolder, string number, int cVV, ExpiredDate expired)
        //{
        //    CardHolder = cardHolder;
        //    Number = number;
        //    CVV = cVV;
        //    Expired = expired;
        //}
    }

    public class DateRange
    {
        
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public DateRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

    }

    public class Address
    {
        public string Street { get; set; }
        public int HouseNO
        {
            get
            {
                return houseNO;
            }

            set
            {
                if (value > 1000 || value <= 0)
                    throw new Exception("House Number must be a number between 1-1000");
                houseNO = value;
            }
        }
        public CITY City { get; set; }
        public int ZipCode { get; set; }

        private int houseNO;

        public Address(string street, int houseNO, CITY city, int zipcode)
        {
            Street = street;
            HouseNO = houseNO;
            City = city;
            ZipCode = zipcode;
        }
        public Address() { }
        public override string ToString()
        {
            return Street + " " + houseNO + ", " + City + " " + ZipCode;
        }
    }

    public class Revenue<T>
    {
        public Revenue(int iD, double _Revenue)
        {
            ID = iD;   
            this._Revenue = _Revenue;
        }
        public int ID { get; set; }
        public double _Revenue { get; set; }
        
    }
    #endregion
}
