using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SPC_Web
{
    /// <summary>
    /// Summary description for TenderService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TenderService : System.Web.Services.WebService
    {

        private string connectionString = "Server=SHEYYAT\\SQLEXPRESS;Database=SPC_SYSTEM;Trusted_Connection=True;";

        [WebMethod]
        public string AddTender(string tenderTitle, string description, string status, int supplierId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Tenders (TenderTitle, Description, Status, SupplierId) VALUES (@TenderTitle, @Description, @Status, @SupplierId)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TenderTitle", tenderTitle);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@SupplierId", supplierId);

                    command.ExecuteNonQuery();
                }

                return "Tender added successfully.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        [WebMethod]
        public string EditTender(int tenderId, string tenderTitle, string description, string status, int supplierId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Tenders SET TenderTitle = @TenderTitle, Description = @Description, Status = @Status, SupplierId = @SupplierId WHERE TenderId = @TenderId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TenderTitle", tenderTitle);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@SupplierId", supplierId);
                    command.Parameters.AddWithValue("@TenderId", tenderId);

                    command.ExecuteNonQuery();
                }

                return "Tender updated successfully.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        [WebMethod]
        public string DeleteTender(int tenderId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Tenders WHERE TenderId = @TenderId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TenderId", tenderId);

                    command.ExecuteNonQuery();
                }

                return "Tender deleted successfully.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        [WebMethod]
        public string ChangeTenderStatus(int tenderId, string newStatus)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Tenders SET Status = @NewStatus WHERE TenderId = @TenderId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NewStatus", newStatus);
                    command.Parameters.AddWithValue("@TenderId", tenderId);

                    command.ExecuteNonQuery();
                }

                return "Tender status updated successfully.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        [WebMethod]
        public string ShowTenders()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT TenderId, TenderTitle, Description, Status, SupplierId FROM Tenders";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    string result = "";
                    while (reader.Read())
                    {
                        result += $"TenderId: {reader["TenderId"]}, TenderTitle: {reader["TenderTitle"]}, Description: {reader["Description"]}, Status: {reader["Status"]}, SupplierId: {reader["SupplierId"]}\n";
                    }

                    return string.IsNullOrEmpty(result) ? "No tenders found." : result;
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        [WebMethod]
        public string AddSupplier(string supplierName, string contactName, string address, string phoneNumber, string email, string status)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Suppliers (SupplierName, ContactName, Address, PhoneNumber, Email, Status) " +
                                   "VALUES (@SupplierName, @ContactName, @Address, @PhoneNumber, @Email, @Status)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SupplierName", supplierName);
                    command.Parameters.AddWithValue("@ContactName", contactName);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Status", status);

                    command.ExecuteNonQuery();
                }

                return "Supplier added successfully.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        [WebMethod]
        public string DeleteSupplier(int supplierId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Suppliers WHERE SupplierId = @SupplierId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SupplierId", supplierId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return "Supplier deleted successfully.";
                    }
                    else
                    {
                        return "Supplier not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        [WebMethod]
        public string ShowSuppliers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT SupplierId, SupplierName, ContactName, Address, PhoneNumber, Email, Status FROM Suppliers";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    string result = "Suppliers:\n";

                    while (reader.Read())
                    {
                        result += $"SupplierId: {reader["SupplierId"]}, " +
                                  $"SupplierName: {reader["SupplierName"]}, " +
                                  $"ContactName: {reader["ContactName"]}, " +
                                  $"Address: {reader["Address"]}, " +
                                  $"PhoneNumber: {reader["PhoneNumber"]}, " +
                                  $"Email: {reader["Email"]}, " +
                                  $"Status: {reader["Status"]}\n";
                    }

                    reader.Close();

                    return string.IsNullOrWhiteSpace(result) ? "No suppliers found." : result;
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
