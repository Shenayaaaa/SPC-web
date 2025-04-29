using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SPC_Web
{
    /// <summary>
    /// Summary description for UserService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserService : System.Web.Services.WebService
    {
        private string connectionString = "Server=SHEYYAT\\SQLEXPRESS;Database=SPC_SYSTEM;Trusted_Connection=True;";

        [WebMethod]
        public string AddUser(string userName, string email, string passwordHash, int roleId, string isActive)
        {
            try
            {
                // Convert isActive to boolean
                bool parsedIsActive;
                if (!bool.TryParse(isActive, out parsedIsActive))
                {
                    return "Error: Invalid value for 'isActive'. Expected 'true' or 'false'.";
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Users (UserName, Email, PasswordHash, RoleId, CreatedAt, IsActive) " +
                                   "VALUES (@UserName, @Email, @PasswordHash, @RoleId, @CreatedAt, @IsActive)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    command.Parameters.AddWithValue("@RoleId", roleId);
                    command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                    command.Parameters.AddWithValue("@IsActive", parsedIsActive);

                    command.ExecuteNonQuery();
                }

                return "User added successfully.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }


        [WebMethod]
        public string EditUser(string userIdStr, string userName, string email, string passwordHash, int roleId, bool isActive)
        {
            try
            {
                // Attempt to parse userId from the string
                if (!int.TryParse(userIdStr, out int userId) || userId <= 0)
                {
                    return "Error: Invalid UserId. Please provide a valid integer.";
                }

                // Log the userId value for debugging
                System.Diagnostics.Debug.WriteLine("UserId: " + userId);

                // Check if user data is valid
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(passwordHash))
                {
                    return "Error: User data is incomplete. Please provide all necessary fields.";
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Users SET UserName = @UserName, Email = @Email, PasswordHash = @PasswordHash, " +
                                    "RoleId = @RoleId, IsActive = @IsActive WHERE UserId = @UserId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    command.Parameters.AddWithValue("@RoleId", roleId);
                    command.Parameters.AddWithValue("@IsActive", isActive);
                    command.Parameters.AddWithValue("@UserId", userId);

                    // Execute the query to update the user details
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return "User updated successfully.";
                    }
                    else
                    {
                        return "Error: No user found with the provided UserId.";
                    }
                }
            }
            catch (Exception ex)
            {
                // Return the error message in case of an exception
                return "Error: " + ex.Message;
            }
        }

        [WebMethod]
        public string DeleteUser(int userId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Users WHERE UserId = @UserId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserId", userId);

                    command.ExecuteNonQuery();
                }

                return "User deleted successfully.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        [WebMethod]
        public string ShowUsers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT UserId, UserName, Email, RoleId, CreatedAt, IsActive FROM Users";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    string result = "";
                    while (reader.Read())
                    {
                        result += $"UserId: {reader["UserId"]}, UserName: {reader["UserName"]}, Email: {reader["Email"]}, " +
                                  $"RoleId: {reader["RoleId"]}, CreatedAt: {reader["CreatedAt"]}, IsActive: {reader["IsActive"]}\n";
                    }

                    return string.IsNullOrEmpty(result) ? "No users found." : result;
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        [WebMethod]
        public string SearchUsers(string searchTerm)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Initialize query and parameters
                    string query = "";
                    SqlCommand command = new SqlCommand();

                    // Check if the searchTerm can be parsed as an integer for UserId search
                    int userId;
                    if (int.TryParse(searchTerm, out userId)) // search by UserId if it's a number
                    {
                        query = "SELECT UserId, UserName, Email, RoleId, CreatedAt, IsActive FROM Users WHERE UserId = @SearchTerm";
                        command.Parameters.AddWithValue("@SearchTerm", userId);  // Pass the parsed integer
                    }
                    else // search by UserName if it's a string
                    {
                        query = "SELECT UserId, UserName, Email, RoleId, CreatedAt, IsActive FROM Users WHERE UserName LIKE @SearchTerm";
                        command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");  // Add wildcards for LIKE search
                    }

                    // Set up the SQL command and execute
                    command.Connection = connection;
                    command.CommandText = query;

                    SqlDataReader reader = command.ExecuteReader();

                    string result = "";
                    while (reader.Read())
                    {
                        result += $"UserId: {reader["UserId"]}, UserName: {reader["UserName"]}, Email: {reader["Email"]}, " +
                                  $"RoleId: {reader["RoleId"]}, CreatedAt: {reader["CreatedAt"]}, IsActive: {reader["IsActive"]}\n";
                    }

                    return string.IsNullOrEmpty(result) ? "No users found." : result;
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
