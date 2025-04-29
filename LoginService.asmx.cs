using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;

namespace SPC_Web
{
    /// <summary>
    /// Summary description for LoginService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LoginService : System.Web.Services.WebService
    {

        private string connectionString = "Server=SHEYYAT\\SQLEXPRESS;Database=SPC_SYSTEM;Trusted_Connection=True;"; // Replace with your SPC database connection string

        // Method to hash password using SHA256 (or any hashing algorithm you're using)
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower(); // Return as lowercase hex string
            }
        }

        [WebMethod]
        public string Login(string email, string password)
        {
            try
            {
                // Hash the provided password
                string hashedPassword = HashPassword(password);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT Users.UserName, Roles.RoleName
                        FROM Users
                        INNER JOIN Roles ON Users.RoleId = Roles.RoleId
                        WHERE Users.Email = @Email AND Users.PasswordHash = @PasswordHash AND Users.IsActive = 1";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string roleName = reader["RoleName"].ToString();
                        return $"Success: {roleName}";
                    }
                    else
                    {
                        return "Error: Invalid credentials or inactive account.";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
