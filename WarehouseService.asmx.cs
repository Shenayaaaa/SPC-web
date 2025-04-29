using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SPC_Web
{
    /// <summary>
    /// Summary description for WarehouseService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WarehouseService : System.Web.Services.WebService
    {
        private string connectionString = "Server=SHEYYAT\\SQLEXPRESS;Database=SPC_SYSTEM;Trusted_Connection=True;";

        [WebMethod]
        public string AddWarehouse(string warehouseName, string location)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Warehouses (WarehouseName, Location) VALUES (@WarehouseName, @Location)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@WarehouseName", warehouseName);
                    command.Parameters.AddWithValue("@Location", location);

                    command.ExecuteNonQuery();
                }

                return "Warehouse added successfully.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        [WebMethod]
        public string EditWarehouse(int warehouseId, string warehouseName, string location)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Warehouses SET WarehouseName = @WarehouseName, Location = @Location WHERE WarehouseId = @WarehouseId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@WarehouseName", warehouseName);
                    command.Parameters.AddWithValue("@Location", location);
                    command.Parameters.AddWithValue("@WarehouseId", warehouseId);

                    command.ExecuteNonQuery();
                }

                return "Warehouse updated successfully.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        [WebMethod]
        public string DeleteWarehouse(int warehouseId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Warehouses WHERE WarehouseId = @WarehouseId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@WarehouseId", warehouseId);

                    command.ExecuteNonQuery();
                }

                return "Warehouse deleted successfully.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        [WebMethod]
        public string ShowWarehouses()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT WarehouseId, WarehouseName, Location FROM Warehouses";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    string result = "";
                    while (reader.Read())
                    {
                        result += $"WarehouseId: {reader["WarehouseId"]}, WarehouseName: {reader["WarehouseName"]}, Location: {reader["Location"]}\n";
                    }

                    return string.IsNullOrEmpty(result) ? "No warehouses found." : result;
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        [WebMethod]
        public string SearchWarehouse(int? warehouseId, string warehouseName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT WarehouseId, WarehouseName, Location FROM Warehouses WHERE 1 = 1";

                    if (warehouseId.HasValue)
                    {
                        query += " AND WarehouseId = @WarehouseId";
                    }
                    if (!string.IsNullOrEmpty(warehouseName))
                    {
                        query += " AND WarehouseName LIKE @WarehouseName";
                    }

                    SqlCommand command = new SqlCommand(query, connection);
                    if (warehouseId.HasValue)
                    {
                        command.Parameters.AddWithValue("@WarehouseId", warehouseId.Value);
                    }
                    if (!string.IsNullOrEmpty(warehouseName))
                    {
                        command.Parameters.AddWithValue("@WarehouseName", "%" + warehouseName + "%");
                    }

                    SqlDataReader reader = command.ExecuteReader();

                    string result = "";
                    while (reader.Read())
                    {
                        result += $"WarehouseId: {reader["WarehouseId"]}, WarehouseName: {reader["WarehouseName"]}, Location: {reader["Location"]}\n";
                    }

                    return string.IsNullOrEmpty(result) ? "No warehouses found." : result;
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
