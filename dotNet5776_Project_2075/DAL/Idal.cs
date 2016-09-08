using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    public interface Idal
    {
        #region Dish

        /// <summary>
        /// Adds dish to the dishes list.
        /// </summary>
        /// <param name="d"> Reprsents the added dish </param>
        void addDish(Dish d);

        /// <summary>
        /// Deletes dish from the dish list.
        /// </summary>
        /// <param name="dishID">Reprsents the dishID of the deleted Dish</param>
        /// <returns>Return whether the deletion succeeded</returns>
        bool delDish(int dishID);

        /// <summary>
        /// Updates dish details by deleting the old instance and re-enter new instance with the updated details.
        /// </summary>
        /// <param name="dishID">Represents the DishID of the old dish</param>
        /// <param name="s">Represnt an instance of the dish with the updated details.</param>
        void updateDish(int dishID, Dish s);

        /// <summary>
        /// Returns dish according to its ID.
        /// </summary>
        /// <param name="dishID">Represnts the DishID of the requested dish.</param>
        /// <returns>Returns dish according to 'dishID'.</returns>
        Dish getDish(int dishID);

        #endregion

        #region Branch

        /// <summary>
        /// Adds branch to the branches list.
        /// </summary>
        /// <param name="d"> Reprsents the added branch </param>
        void addBranch(Branch d);

        /// <summary>
        /// Deletes branch from the branches list.
        /// </summary>
        /// <param name="branchID">Reprsents the BranchID of the deleted branch</param>
        /// <returns>Return whether the deletion succeeded</returns>
        bool delBranch(int branchID);

        /// <summary>
        /// Updates Branch details by deleting the old instance and re-enter new instance with the updated details.
        /// </summary>
        /// <param name="branchID">Represents the BranchID of the old branch</param>
        /// <param name="s">Represnt an instance of the Branch with the updated details.</param>
        void updateBranch(int branchID, Branch s);

        /// <summary>
        /// Returns Branch according to its ID.
        /// </summary>
        /// <param name="branchID">Represnts the BranchID of the requested branch.</param>
        /// <returns>Returns Branch according to 'branchID'.</returns>
        Branch getBranch(int branchID);

        #endregion

        #region Order

        /// <summary>
        /// Adds order to the orders list.
        /// </summary>
        /// <param name="d"> Reprsents the added order </param>
        void addOrder(Order d);

        /// <summary>
        /// Deletes order from the orders list.
        /// </summary>
        /// <param name="orderID">Reprsents the OrderID of the deleted order</param>
        /// <returns>Return whether the deletion succeeded</returns>
        bool delOrder(int orderID);

        /// <summary>
        /// Updates order Details by deleting the old instance and re-enter new instance with the updated details.
        /// </summary>
        /// <param name="orderID">Represents the OrderID of the old order</param>
        /// <param name="s">Represnt an instance of the order with the updated details.</param>
        void updateOrder(int orderID, Order s);

        /// <summary>
        /// Returns order according to its ID.
        /// </summary>
        /// <param name="orderID">Represnts the OrderID of the requested order.</param>
        /// <returns>Returns order according to 'orderID'.</returns>
        Order getOrder(int orderID);

        /// <summary>
        /// Returns the order ID for the next new orders. 
        /// </summary>
        /// <returns>Returns the order ID for the next new order.</returns>
        int nextOrderID();

        #endregion

        #region Ordered Dish

        /// <summary>
        /// Adds ordered dish to the ordered dishes list.
        /// </summary>
        /// <param name="d"> Reprsents the added ordered dish </param>
        void addOD(Ordered_Dish d);

        /// <summary>
        /// Deletes ordered dish from the ordered dishes.
        /// </summary>
        /// <param name="itenID">Reprsents the ItemID of the deleted ordered-dish</param>
        /// <returns>Return whether the deletion succeeded</returns>
        bool delOD(int itemID);

        /// <summary>
        /// Updates ordered-dish d0etails by deleting the old instance and re-enter new instance with the updated details.
        /// </summary>
        /// <param name="itemID">Represents the ItemID of the old order ordered-dish</param>
        /// <param name="s">Represnt an instance of the ordered-dish with the updated details.</param>
        void updateOD(int itemID, Ordered_Dish s);

        /// <summary>
        /// Returns ordered dish according to its ID.
        /// </summary>
        /// <param name="itemID">Represnts the ItemID of the requested ordered dish.</param>
        /// <returns>Returns ordered dish according to 'itemID'.</returns>
        Ordered_Dish getOD(int itemID);


        #endregion

        #region Client

        /// <summary>
        /// Adds client to the client list.
        /// </summary>
        /// <param name="d"> Reprsents the added client </param>
        void addClient(Client d);

        /// <summary>
        /// Deletes client from the clients list.
        /// </summary>
        /// <param name="clientID">Reprsents the ClientID of the deleted client</param>
        /// <returns>Return whether the deletion succeeded</returns>
        bool delClient(int clientID);

        /// <summary>
        /// Updates client Details by deleting the old instance and re-enter new instance with the updated details.
        /// </summary>
        /// <param name="ClientID">Represents the ClientID of the old client</param>
        /// <param name="s">Represnt an instance of the client with the updated details.</param>
        void updateClient(int clientID, Client s);

        /// <summary>
        /// Returns client according to its ID.
        /// </summary>
        /// <param name="clientID">Represnts the ClientID of the requested client.</param>
        /// <returns>Returns client according to 'clientID'.</returns>
        Client getClient(int clientID);

        #endregion

        #region getLists

        /// <summary>
        /// Retrieves the orders list from the DataSource.
        /// </summary>
        /// <returns>Returns the orders list from the DataSource.</returns>
        List<Order> getOrdersList();

        /// <summary>
        /// Retrieves the dishes list from the DataSource.
        /// </summary>
        /// <returns>Returns the dishes list from the DataSource.</returns>
        List<Dish> getDishesList();

        /// <summary>
        /// Retrieves the branches list from the DataSource.
        /// </summary>
        /// <returns>Returns the branches list from the DataSource.</returns>
        List<Branch> getBranchesList();

        /// <summary>
        /// Retrieves the clients list from the DataSource.
        /// </summary>
        /// <returns>Returns the clients list from the DataSource</returns>
        List<Client> getClientsList();

        /// <summary>
        /// Retrieves the ordered dishes list from the DataSource.
        /// </summary>
        /// <returns>Returns the ordered dishes list from the DataSource</returns>
        List<Ordered_Dish> getODList();

        #endregion

        #region XMLSerializers

        /// <summary>
        /// Serializes the dishes list and writes the XML document to a file
        /// using the specified System.IO.Stream.
        /// </summary>
        /// <param name="path">The path used to write the XML document.</param>
        void saveDishesToXML(string path);

        /// <summary>
        /// Serializes the branch list and writes the XML document to a file
        /// using the specified System.IO.Stream.
        /// </summary>
        /// <param name="path">The path used to write the XML document.</param>
        void saveBranchesToXML(string path);

        /// <summary>
        /// Serializes the orders list and writes the XML document to a file
        /// using the specified System.IO.Stream.
        /// </summary>
        /// <param name="path">The path used to write the XML document.</param>
        void saveOrdersToXML(string path);

        /// <summary>
        /// Serializes the clients list and writes the XML document to a file
        /// using the specified System.IO.Stream.
        /// </summary>
        /// <param name="path">The path used to write the XML document.</param>
        void saveClientsToXML(string path);


        //void saveODToXML(string path);

        /// <summary>
        /// Deserializes the XML document contained by the specified path.
        /// </summary>
        /// <param name="path">The path that contains the XML document to deserialize.</param>
        void loadBranchesFromXML(string path);

        /// <summary>
        /// Deserializes the XML document contained by the specified path.
        /// </summary>
        /// <param name="path">The path that contains the XML document to deserialize.</param>
        void loadClientsFromXML(string path);

        /// <summary>
        /// Deserializes the XML document contained by the specified path.
        /// </summary>
        /// <param name="path">The path that contains the XML document to deserialize.</param>
        void loadDishesFromXML(string path);

        /// <summary>
        /// Deserializes the XML document contained by the specified path.
        /// </summary>
        /// <param name="path">The path that contains the XML document to deserialize.</param>
        void loadOrdersFromXML(string path);


        //void loadODFromXML(string path);

        #endregion

        /// <summary>
        /// Returns all the ordered dishes which belongs to a specific order.
        /// </summary>
        /// <param name="orderID">the specified order ID</param>
        /// <returns>Returns all the ordered dishes which belongs to a specific order.</returns>
        IEnumerable<Ordered_Dish> getOrderedDishes(int orderID);

        /// <summary>
        /// Returns whether a spesific ordered dish is already exist.
        /// </summary>
        /// <param name="d">The specified ordered dish ID</param>
        /// <returns>Returns whether a spesific ordered dish is already exist.</returns>
        Ordered_Dish isODExist(Ordered_Dish d);

    }
}
