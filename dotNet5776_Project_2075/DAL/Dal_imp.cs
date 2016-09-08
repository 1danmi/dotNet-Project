using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using DS;
using System.Xml.Serialization;
using System.IO;

namespace DAL
{
    public class Dal_imp : Idal
    {
        Dal_OD_XML_imp odXML = FactoryDalXML.getDalXML(); 

        Random R = new Random();

        #region DAL Add Functions

        public void addBranch(Branch d)
        {
            DataSource.branches.Sort();
            if (d.BranchID == 0)
            {
                if (DataSource.branches.Count > 0)
                    d.BranchID = DataSource.branches[DataSource.branches.Count - 1].BranchID + 1;
                else
                    d.BranchID = 1;
            }
            else
            {
                var exist = from x in DataSource.branches
                            where x.BranchID == d.BranchID
                            select x;
                if (exist.Any())
                {
                    int i = 0;
                    for (; i < DataSource.branches.Count; i++)
                    {
                        if (DataSource.branches[i].BranchID != i)
                            break;
                    }
                    d.BranchID = i;
                }
            }
            DataSource.branches.Add(d);   
        }
        
        public void addClient(Client d)
        {
            DataSource.clients.Sort();
            if (d.ClientID == 0)
            {
                if (DataSource.clients.Count > 0)
                    d.ClientID = DataSource.clients[DataSource.clients.Count - 1].ClientID + 1;
                else d.ClientID = 1;
            }
            else
            {
                var exist = from x in DataSource.clients
                            where x.ClientID == d.ClientID
                            select x;
                if (exist.Any())
                {
                    int i = 0;
                    for (; i < DataSource.clients.Count; i++)
                    {
                        if (DataSource.clients[i].ClientID != i)
                            break;
                    }
                    d.ClientID = i;
                }
            }
            DataSource.clients.Add(d);
        }

        public void addDish(Dish d)
        {
            DataSource.dishes.Sort();
            if (d.DishID == 0)
            {
                if (DataSource.dishes.Count > 0)
                    d.DishID = DataSource.dishes[DataSource.dishes.Count - 1].DishID + 1;
                else
                    d.DishID = 1;
            }
            else
            {
                var exist = from x in DataSource.dishes
                            where x.DishID == d.DishID
                            select x;
                if (exist.Any())
                {
                    int i = 0;
                    for (; i < DataSource.dishes.Count; i++)
                    {
                        if (DataSource.dishes[i].DishID != i)
                            break;
                    }
                    d.DishID = i;
                }
            }
            DataSource.dishes.Add(d);
        }

        public void addOD(Ordered_Dish d)
        {
            List<Ordered_Dish> odList = odXML.getODList();
            if(odList==null)
            {
                d.ItemID = 1;
                odXML.AddOD(d);
                return;
            }
            var y = isODExist(d);
            if (y != null)
            {
                y.Amount++;
                odXML.updateOD(y);
            }
            else
            {
                odList.Sort();
                if (d.ItemID == 0)
                {
                    if (odList.Count > 0)
                        d.ItemID = odList[odList.Count - 1].ItemID + 1;
                    else
                        d.ItemID = 1;
                }
                else
                {
                    var exist = from x in odList
                                where x.ItemID == d.ItemID
                                select x;
                    if (exist.Any())
                    {
                        int i = 0;
                        for (; i < odList.Count; i++)
                        {
                            if (odList[i].ItemID != i)
                                break;
                        }
                        d.ItemID = i;
                    }
                }
                odXML.AddOD(d);
            }
        }

        public void addOrder(Order orderID)
        {
            DataSource.orders.Sort();
            if (orderID.OrderID == 0)
                orderID.OrderID = nextOrderID();
            else
            {
                var exist = from x in DataSource.orders
                            where x.OrderID == orderID.OrderID
                            select x;
                if (exist.Any())
                {
                    int i = 0;
                    for (; i < DataSource.orders.Count; i++)
                    {
                        if (DataSource.orders[i].OrderID != i)
                            break;
                    }
                    orderID.OrderID = i;
                }
            }
            DataSource.orders.Add(orderID);
        }

        #endregion

        #region DAL Delete Functions

        public bool delBranch(int branchID)
        {
            for(int i=0;i<DataSource.orders.Count;i++)
            {
                if (DataSource.orders[i].BranchID == branchID)
                {
                    delOrder(DataSource.orders[i].OrderID);
                    i--;
                }
            }
            return DataSource.branches.Remove(DataSource.branches.Find(x=>x.BranchID==branchID));
        }

        public bool delClient(int clientID)
        {
            for (int i = 0; i < DataSource.orders.Count; i++)
            {
                if (DataSource.orders[i].ClientID == clientID)
                {
                    delOrder(DataSource.orders[i].OrderID);
                    i--;
                }
                
            }
            return DataSource.clients.Remove(DataSource.clients.Find(x=>x.ClientID == clientID));
        }

        public bool delDish(int dishID)
        {
            List<Ordered_Dish> odList = odXML.getODList();
            for (int i = 0; i < odList.Count; i++)
            {
                if (odList[i].DishID == dishID)
                {
                    odXML.delOD(odList[i].ItemID);
                }
            }
            return DataSource.dishes.Remove(DataSource.dishes.Find(x => x.DishID == dishID));
        }

        public bool delOD(int ItemID)
        {
            var item = odXML.getOD(ItemID);
            if (item == null)
                throw new Exception("Ordered-Dish doesn't exist!");
            else if(item.Amount>1)
            {
                item.Amount--;
                odXML.updateOD(item);
                return true;
            }
            return odXML.delOD(ItemID);
        }

        public bool delOrder(int orderID)
        {
            List<Ordered_Dish> odList = odXML.getODList();
            for (int i = 0; i < odList.Count; i++)
            {
                if (odList[i].OrderID == orderID)
                {
                    odXML.delOD(odList[i].ItemID);
                }
            }
            return DataSource.orders.Remove(DataSource.orders.Find(x => x.OrderID == orderID));
        }

        #endregion

        #region DAL Get Lists Functions

        public List<Branch> getBranchesList()
        {
            return DataSource.branches;
        }

        public List<Client> getClientsList()
        {
            return DataSource.clients;
        }

        public List<Dish> getDishesList()
        {
            return DataSource.dishes;
        }

        public List<Ordered_Dish> getODList()
        {
            return odXML.getODList();
        }

        public List<Order> getOrdersList()
        {
            return DataSource.orders;
        }

        #endregion

        #region DAL Update Functions

        public void updateBranch(int branchID, Branch s)
        {
            if (DataSource.branches.Remove(DataSource.branches.Find(x => x.BranchID == branchID)))
                addBranch(s);
        }

        public void updateClient(int clientID, Client s)
        {
            if (DataSource.clients.Remove(DataSource.clients.Find(x => x.ClientID == clientID)))
                addClient(s);
        }

        public void updateDish(int dishID, Dish s)
        {
            if (DataSource.dishes.Remove(DataSource.dishes.Find(x => x.DishID == dishID)))
                addDish(s);
        }

        public void updateOD(int itemID, Ordered_Dish s)
        {
            odXML.updateOD(s);
        }

        public void updateOrder(int orderID, Order s)
        {
            if (DataSource.orders.Remove(DataSource.orders.Find(x => x.OrderID == orderID)))
                addOrder(s);
                
        }

        #endregion

        #region Get Var

        public Branch getBranch(int branchID)
        {
            Branch b = DataSource.branches.Find(x => x.BranchID == branchID);
            if (b == null)
                throw new Exception("Branch does not exist in the data base");
            return b;
    
        }

        public Client getClient(int clientID)
        {
            Client c =  DataSource.clients.Find(x => x.ClientID == clientID);
            if (c == null)
                throw new Exception("Client does not exist in the data base");
            return c;
        }

        public Dish getDish(int dishID)
        {
            Dish d = DataSource.dishes.Find(x => x.DishID == dishID);
            if (d == null)
                throw new Exception("Dish does not exist in the data base");
            return d;
        }

        public Ordered_Dish getOD(int itemID)
        {

            Ordered_Dish od = odXML.getOD(itemID);
            if (od == null)
                throw new Exception("Ordered-Dish doesn't exist!");
            return od;
        }

        public Order getOrder(int orderID)
        {
            Order o = DataSource.orders.Find(x => x.OrderID == orderID);
            if (o == null)
                throw new Exception("Order doesn't Exist!");
            return o;           
        }

        #endregion

        #region XMLSerializers

        public void saveBranchesToXML(string path)
        {
            XmlSerializer x = new XmlSerializer(DataSource.branches.GetType());
            FileStream fs = new FileStream(path, FileMode.Create);
            x.Serialize(fs, DataSource.branches);
        }
        public void saveClientsToXML(string path)
        {
            XmlSerializer x = new XmlSerializer(DataSource.clients.GetType());
            FileStream fs = new FileStream(path, FileMode.Create);
            x.Serialize(fs, DataSource.clients);
        }
        public void saveDishesToXML(string path)
        {
            XmlSerializer x = new XmlSerializer(DataSource.dishes.GetType());
            FileStream fs = new FileStream(path, FileMode.Create);
            x.Serialize(fs, DataSource.dishes);
        }
        public void saveOrdersToXML(string path)
        {
            XmlSerializer x = new XmlSerializer(DataSource.orders.GetType());
            FileStream fs = new FileStream(path, FileMode.Create);
            x.Serialize(fs, DataSource.orders);
        }
        //public void saveODToXML(string path)
        //{
        //    XmlSerializer x = new XmlSerializer(DataSource.orderedDishes.GetType());
        //    FileStream fs = new FileStream(path, FileMode.Create);
        //    x.Serialize(fs, DataSource.orderedDishes);
        //}

        public void loadBranchesFromXML(string path)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<Branch>));
            FileStream fs = new FileStream(path, FileMode.Open);
            DataSource.branches = (List<Branch>)x.Deserialize(fs);
        }
        public void loadClientsFromXML(string path)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<Client>));
            FileStream fs = new FileStream(path, FileMode.Open);
            DataSource.clients = (List<Client>)x.Deserialize(fs);
        }
        public void loadDishesFromXML(string path)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<Dish>));
            FileStream fs = new FileStream(path, FileMode.Open);
            DataSource.dishes = (List<Dish>)x.Deserialize(fs);
        }
        public void loadOrdersFromXML(string path)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<Order>));
            FileStream fs = new FileStream(path, FileMode.Open);
            DataSource.orders = (List<Order>)x.Deserialize(fs);
        }
        //public void loadODFromXML(string path)
        //{
        //    XmlSerializer x = new XmlSerializer(typeof(List<Ordered_Dish>));
        //    FileStream fs = new FileStream(path, FileMode.Open);
        //    DataSource.orderedDishes = (List<Ordered_Dish>)x.Deserialize(fs);
        //}


        #endregion

        public IEnumerable<Ordered_Dish> getOrderedDishes(int orderID)
        {
            if (orderID == 0)
                return null;
            IEnumerable<Ordered_Dish> x = from item in odXML.getODList()
                                          let y = item.OrderID
                                          where y == orderID
                                          select item;
            return x;

        }

        public int nextOrderID()
        {
            if (DataSource.orders.Count > 0)
                return DataSource.orders[DataSource.orders.Count - 1].OrderID + 1;
            else
                return 1;
        }

        public Ordered_Dish isODExist(Ordered_Dish x)
        {
            return odXML.getODList().Find(item => (item.OrderID == x.OrderID && item.DishID == x.DishID));
        }
            
    }
    public class FactoryDal
    {
        static Idal dal = null;
        public static Idal getDal()
        {
            if(dal==null)
                dal = new Dal_imp();
            return dal;
        }
    }
}
