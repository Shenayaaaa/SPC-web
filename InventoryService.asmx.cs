using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SPC_Web
{
    /// <summary>
    /// Summary description for InventoryService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class InventoryService : System.Web.Services.WebService
    {

        private string connectionString = "Server=SHEYYAT\\SQLEXPRESS;Database=SPC_SYSTEM;Trusted_Connection=True;";

        [WebMethod]
        public string AddInventory(string drugName, int quantity, DateTime expiryDate, decimal price, string stockStatus, int supplierId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Inventory (DrugName, Quantity, ExpiryDate, Price, StockStatus, SupplierId) " +
                                   "VALUES (@DrugName, @Quantity, @ExpiryDate, @Price, @StockStatus, @SupplierId)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DrugName", drugName);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@ExpiryDate", expiryDate);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@StockStatus", stockStatus);
                    command.Parameters.AddWithValue("@SupplierId", supplierId);

                    command.ExecuteNonQuery();
                }

                return "Inventory item added successfully.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        [WebMethod]
        public string EditInventory(int inventoryId, string drugName, int quantity, DateTime expiryDate, decimal price, string stockStatus, int supplierId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Inventory SET DrugName = @DrugName, Quantity = @Quantity, ExpiryDate = @ExpiryDate, " +
                                   "Price = @Price, StockStatus = @StockStatus, SupplierId = @SupplierId WHERE InventoryId = @InventoryId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DrugName", drugName);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@ExpiryDate", expiryDate);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@StockStatus", stockStatus);
                    command.Parameters.AddWithValue("@SupplierId", supplierId);
                    command.Parameters.AddWithValue("@InventoryId", inventoryId);

                    command.ExecuteNonQuery();
                }

                return "Inventory item updated successfully.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        [WebMethod]
        public string DeleteInventory(int inventoryId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Inventory WHERE InventoryId = @InventoryId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@InventoryId", inventoryId);

                    command.ExecuteNonQuery();
                }

                return "Inventory item deleted successfully.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        [WebMethod]
        public List<InventoryItem> GetInventory()
        {
            List<InventoryItem> inventoryList = new List<InventoryItem>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT InventoryId, DrugName, Quantity, ExpiryDate, Price, StockStatus, SupplierId FROM Inventory";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        InventoryItem item = new InventoryItem
                        {
                            InventoryId = Convert.ToInt32(reader["InventoryId"]),
                            DrugName = reader["DrugName"].ToString(),
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            ExpiryDate = Convert.ToDateTime(reader["ExpiryDate"]),
                            Price = Convert.ToDecimal(reader["Price"]),
                            StockStatus = reader["StockStatus"].ToString(),
                            SupplierId = Convert.ToInt32(reader["SupplierId"])
                        };
                        inventoryList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<InventoryItem> { new InventoryItem { DrugName = "Error: " + ex.Message } };
            }

            return inventoryList;
        }

        [WebMethod]
        public List<InventoryItem> SearchInventory(string searchTerm)
        {
            List<InventoryItem> searchResults = new List<InventoryItem>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                    SELECT InventoryId, DrugName, Quantity, ExpiryDate, Price, StockStatus, SupplierId
                    FROM Inventory
                    WHERE DrugName LIKE @SearchTerm OR InventoryId LIKE @SearchTerm";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        InventoryItem item = new InventoryItem
                        {
                            InventoryId = Convert.ToInt32(reader["InventoryId"]),
                            DrugName = reader["DrugName"].ToString(),
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            ExpiryDate = Convert.ToDateTime(reader["ExpiryDate"]),
                            Price = Convert.ToDecimal(reader["Price"]),
                            StockStatus = reader["StockStatus"].ToString(),
                            SupplierId = Convert.ToInt32(reader["SupplierId"])
                        };
                        searchResults.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<InventoryItem> { new InventoryItem { DrugName = "Error: " + ex.Message } };
            }

            return searchResults;
        }
    }

    public class InventoryItem
    {
        public int InventoryId { get; set; }
        public string DrugName { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Price { get; set; }
        public string StockStatus { get; set; }
        public int SupplierId { get; set; }
    }
}

