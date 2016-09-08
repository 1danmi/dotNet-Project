using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    public class BL_imp : Ibl
    {
        Idal dal = FactoryDal.getDal();
       
        #region BL Add Functions

        public void addBranch(Branch d)
        {
            dal.addBranch(d);
        }

        public void addClient(Client d)
        {
            dal.addClient(d);
        }

        public void addDish(Dish d)
        {
            dal.addDish(d);
        }

        public void addOD(Ordered_Dish d)
        {
            if (dal.getOrder(d.OrderID).Kosher <= dal.getDish(d.DishID).Kosher)
            {
                if (calcTotalPrice(d.OrderID)+dal.getDish(d.DishID).Price<400)
                    dal.addOD(d);
                else
                    throw new Exception("The total price of order can't be more than 400₪");

            }
            else
                throw new Exception("This dish has not the appropriate kashrut level for this order!");
        }

        public void addOrder(Order d)
        {
            if(d.Kosher>=dal.getBranch(d.BranchID).Kosher)
                dal.addOrder(d);
            else
                throw new Exception("The minimum Kashrut level is lower than the branch");
        }

        #endregion 

        #region BL Delete Functions

        public bool delBranch(int branchID)
        {
            return dal.delBranch(branchID);
        }

        public bool delClient(int clientID)
        {
            return dal.delClient(clientID);
        }

        public bool delDish(int dishID)
        {
            return dal.delDish(dishID);
        }

        public bool delOD(int itemID)
        {
            return dal.delOD(itemID);
        }

        public bool delOrder(int orderID)
        {
            return dal.delOrder(orderID);
        }

        #endregion

        #region DAL Get Lists Functions

        public List<Branch> getBranchesList()
        {
            return dal.getBranchesList();
        }

        public List<Client> getClientsList()
        {
            return dal.getClientsList();
        }

        public List<Dish> getDishesList()
        {
            return dal.getDishesList();
        }

        public List<Ordered_Dish> getODList()
        {
            return dal.getODList();
        }

        public List<Order> getOrdersList()
        {
            return dal.getOrdersList();
        }

        #endregion

        #region BL Update Functions

        public void updateBranch(int branchID, Branch s)
        {
            dal.updateBranch(branchID, s);
        }

        public void updateClient(int clientID, Client s)
        {
            dal.updateClient(clientID, s);
        }

        public void updateDish(int dishID, Dish s)
        {
            dal.updateDish(dishID, s);
        }

        public void updateOD(int itemID, Ordered_Dish s)
        {
            dal.updateOD(itemID, s);
        }

        public void updateOrder(int orderID, Order s)
        {
            if (delOrder(orderID))
                addOrder(s);
        }

        #endregion

        #region Get Var

        public Dish getDish(int dishID)
        {
            return dal.getDish(dishID);
        }

        public Branch getBranch(int branchID)
        {
            return dal.getBranch(branchID);
        }

        public Order getOrder(int orderID)
        {
            return dal.getOrder(orderID);
        }

        public Ordered_Dish getOD(int itemID)
        {
            return dal.getOD(itemID);
        }

        public Client getClient(int clientID)
        {
            return dal.getClient(clientID);
        }

        #endregion

        #region Limits

        //public bool kosherLimitDish(int itemID)
        //{
        //    return true;//(dal.getDish(dal.getOD(itemID).DishID).Kosher >= dal.getOrder(dal.getOD(itemID).OrderID).Kosher);
        //}

        //public bool orderLimit(int orderID, double limit)
        //{
        //    return (calcTotalPrice(orderID) <= limit);
        //}

        //public bool ageLimit(int orderID)
        //{
        //    return true;//(DateTime.Now.Year - dal.getClient(dal.getOrder(orderID).ClientID).BirthDate.Year >= 18);
        //}

        //public bool kosherLimitBranch(int orderID)
        //{
        //    return true;//(dal.getOrder(orderID).Kosher >= dal.getBranch(dal.getOrder(orderID).BranchID).Kosher);
        //}

        #endregion

        #region revenue

        public IEnumerable<Order> ordersBetweenDates(DateRange range)
        {
            var x = from a in dal.getOrdersList()
                    group a by inRange(a, range) into g
                    select g;
            double sum = 0;
            foreach (var item in x)
                if (item.Key)
                    foreach (var i in item)
                        sum += calcTotalPrice(i.OrderID);
            return null;
        }
        public IEnumerable<IGrouping<int,Order>> ordersPerMonth()
        {
            var x = from item in getOrdersList()
                    group item by item.Time.Month into g
                    select g;
            return x;
        }

        public double revenueForCity(CITY city)
        {
            var x = from a in dal.getOrdersList()
                    group a by dal.getBranch(a.BranchID).Add.City into g
                    select g;
            double sum = 0;
            foreach (var item in x)
                if (item.Key == city)
                    foreach (var i in item)
                        sum += calcTotalPrice(i.OrderID);
            return sum;
        }

        public double revenueForDishType(DISH_TYPE dishType)
        {
            var x = from item in dal.getODList()
                    group item by dal.getDish(item.DishID).DishType into g
                    select g;
            double sum = 0;
            foreach (var item in x)
            {
                if (item.Key==dishType)
                    foreach (var a in item)
                        sum += dal.getDish(a.DishID).Price;
            }
            return sum;
        }

        public double revenueForDish(int dishID)
        {
            var c = from x in dal.getODList()
                    group x by x.DishID into g
                    select g;
            int count = 0;
            foreach (var x in c)
            {
                if (x.Key == dishID)
                    count++;
            }
            return count * dal.getDish(dishID).Price;
        }

        public IEnumerable<Revenue<CITY>> averageOrderPerCity()
        {
            var x = from item in dal.getOrdersList()
                    group item by dal.getClient(item.ClientID).Add.City into g
                    select g;
            var revenue = from item in x
                          let a = item.Average(s => calcTotalPrice(s.OrderID))
                          select new Revenue<CITY>((int)item.Key, a);
            return revenue;
        }

        public IEnumerable<Revenue<Dish>> revenuePerDish()
        {
            var revenue = from item in dal.getDishesList()
                          let a = revenueForDish(item.DishID)
                          select new Revenue<Dish>(item.DishID, a);
            return revenue;
        }

        public IEnumerable<Revenue<CITY>> revenuePerCity()
        {
            var x = from item in dal.getOrdersList()
                    group item by dal.getClient(item.ClientID).Add.City into g
                    select g;
            var revenue = from item in x
                    let a = item.Sum(s => calcTotalPrice(s.OrderID))
                    select new Revenue<CITY>((int)item.Key, a);
           
            return revenue;
        }
        
        public IEnumerable<Revenue<Branch>> revenuePerBranch()
        {
            var x = from item in dal.getOrdersList()
                    group item by item.BranchID into g
                    select g;
            var revenue = from item in x
                          let a = item.Sum(s => calcTotalPrice(s.OrderID))
                          select new Revenue<Branch>(item.Key, a);
            return revenue.ToList();

        }

        #endregion

        #region XMLSerializer

        public void saveDishesToXML(string path)
        {
            dal.saveDishesToXML(path);
        }

        public void saveBranchesToXML(string path)
        {
            dal.saveBranchesToXML(path);
        }

        public void saveOrdersToXML(string path)
        {
            dal.saveOrdersToXML(path);
        }

        public void saveClientsToXML(string path)
        {
            dal.saveClientsToXML(path);
        }

        //public void saveODToXML(string path)
        //{
        //    dal.saveODToXML(path);
        //}


        public void loadBranchesFromXML(string path)
        {
            dal.loadBranchesFromXML(path);
        }

        public void loadClientsFromXML(string path)
        {
            dal.loadClientsFromXML(path);
        }

        public void loadDishesFromXML(string path)
        {
            dal.loadDishesFromXML(path);
        }

        public void loadOrdersFromXML(string path)
        {
            dal.loadOrdersFromXML(path);
        }

        //public void loadODFromXML(string path)
        //{
        //    dal.loadODFromXML(path);
        //}

        #endregion

        #region Others

        public double calcTotalPrice(int orderID)
        {
            if (orderID == 0)
                return 0;
            List<Ordered_Dish> orders = dal.getOrderedDishes(orderID).ToList();
            if (orders == null||orders.Count==0)
                return 0;
            double sum = 0;
            foreach (var item in orders)
            {
                sum += dal.getDish(item.DishID).Price*item.Amount;
            }
            return sum;
        }

        private bool inRange(Order a, DateRange range)
        {
            if (a.Time >= range.Start && a.Time <= range.End)
                return true;
            return false;
        }

        public int mostValueOrder()
        {
            double max = dal.getOrdersList().Max(x => calcTotalPrice(x.OrderID));
            int maxOrder = dal.getOrdersList().Find(delegate (Order x) { return calcTotalPrice(x.OrderID) == max; }).OrderID;
            return maxOrder;
        }

        public double averageOrder()
        {
            return dal.getOrdersList().Average(s => calcTotalPrice(s.OrderID));
        }

        public Client findClientByPhoneNumber(string phoneNumber)
        {

            var client = dal.getClientsList().Find(delegate (Client x) { return x.PhoneNumber == phoneNumber; });
            if (client == null)
                throw new Exception("Client doesn't exist!");
            return client;
        }
        
        public IEnumerable<Order> findOrders(Predicate<Order> cond)
        {
            List<Order> orders = dal.getOrdersList();
            var a = from x in orders
                    where cond(x)
                    select x;
            return a;
        }

        //public IEnumerable<Client> getClientByAlphabet()
        //{
        //    var x = from item in dal.getClientsList()
        //            orderby item.Name
        //            select item;
        //    return x;
        //}

        public IEnumerable<IGrouping<DISH_TYPE, Dish>> dishesPerDishType()
        {
            var x = from item in dal.getDishesList()
                    group item by item.DishType into g
                    select g;
            return x;
        }

        public IEnumerable<IGrouping<CITY, Order>> orderPerCity()
        {
            var x = from item in dal.getOrdersList()
                    group item by dal.getClient(item.ClientID).Add.City into g
                    select g;
            return x;
        }

        public IEnumerable<Dish> dishesForDishType(DISH_TYPE dishType)
        {
            var x = dishesPerDishType();
            List<Dish> d = new List<Dish>();
            foreach (var item in x)
                if (item.Key == dishType)
                {
                    foreach (var Item in item)
                        d.Add(Item);
                }
            return d;
        }

        public int nextOrderID()
        {
            return dal.nextOrderID();
        }

        public IEnumerable<Ordered_Dish> getOrderedDishes(int orderID)
        {
            return dal.getOrderedDishes(orderID);
        }

        public Ordered_Dish isODExist(Ordered_Dish d)
        {
            return dal.isODExist(d);
        }

        
        #endregion
    }

    
}
