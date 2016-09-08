using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using System.IO;

namespace DAL
{
    public class Dal_OD_XML_imp
    {

        XElement orderedDishRoot;
        string orderedDishPath = @"ODLinkToXml.xml";

        public Dal_OD_XML_imp()
        {
            if (!File.Exists(orderedDishPath))
                CreateFiles();
            else
                LoadData();
        }

        private void CreateFiles()
        {
            orderedDishRoot = new XElement("OrderedDishes");
            orderedDishRoot.Save(orderedDishPath);
        }
        private void LoadData()
        {
            try
            {
                orderedDishRoot = XElement.Load(orderedDishPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
        public void AddOD(Ordered_Dish od)
        {
            LoadData();
            XElement itemID = new XElement("ItemID", od.ItemID);
            XElement orderID = new XElement("OrderID", od.OrderID);
            XElement dishID = new XElement("DishID",od.DishID);
            XElement amount = new XElement("Amount", od.Amount);

            orderedDishRoot.Add(new XElement("Ordered_Dish", itemID, orderID,dishID,amount));
            orderedDishRoot.Save(orderedDishPath);
        }

        public List<Ordered_Dish> getODList()
        {
            LoadData();
            List<Ordered_Dish> od;
            try
            {
                od = (from p in orderedDishRoot.Elements()
                      select new Ordered_Dish() { ItemID = Convert.ToInt32(p.Element("ItemID").Value),
                                             OrderID = Convert.ToInt32(p.Element("OrderID").Value),
                                             DishID = Convert.ToInt32(p.Element("DishID").Value),
                                             Amount = Convert.ToInt32(p.Element("Amount").Value) }).ToList();
            }
            catch
            {
                od = null;
            }
            return od;
        }

        public Ordered_Dish getOD(int id)
        {
            LoadData();
            Ordered_Dish od;
            try
            {
                od = (from p in orderedDishRoot.Elements()
                           where Convert.ToInt32(p.Element("ItemID").Value) == id
                           select new Ordered_Dish()
                           {   ItemID = Convert.ToInt32(p.Element("ItemID").Value),
                               OrderID = Convert.ToInt32(p.Element("OrderID").Value),
                               DishID = Convert.ToInt32(p.Element("DishID").Value),
                               Amount = Convert.ToInt32(p.Element("Amount").Value)   }).FirstOrDefault();
            }
            catch
            {
                od = null;
            }
            return od;
        }

        public bool delOD(int id)
        {
            LoadData();
            XElement ODElement;
            try
            {
                ODElement = (from p in orderedDishRoot.Elements()
                             where Convert.ToInt32(p.Element("ItemID").Value) == id
                             select p).FirstOrDefault();
                ODElement.Remove();
                orderedDishRoot.Save(orderedDishPath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void updateOD(Ordered_Dish od)
        {
            LoadData();
            XElement odElement = (from p in orderedDishRoot.Elements()
                                       where Convert.ToInt32(p.Element("ItemID").Value) == od.ItemID
                                       select p).FirstOrDefault();
            odElement.Element("OrderID").Value = od.OrderID.ToString();
            odElement.Element("DishID").Value = od.DishID.ToString();
            odElement.Element("Amount").Value = od.Amount.ToString();


            orderedDishRoot.Save(orderedDishPath);
        }

    }
    public class FactoryDalXML
    {
        static Dal_OD_XML_imp dalXML = null;
        public static Dal_OD_XML_imp getDalXML()
        {
            if (dalXML == null)
                dalXML = new Dal_OD_XML_imp();
            return dalXML;
        }
    }
}
