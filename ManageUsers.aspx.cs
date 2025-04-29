using SPC_Web.RoleServiceReference;
using SPC_Web.UserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SPC_Web
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Load users on page load
            if (!IsPostBack)
            {
                ShowUsers();
                PopulateRoles();
            }
        }

        protected void PopulateRoles()
        {
            var userService = new RoleServiceSoapClient();

            // Call the WebMethod ShowRoles
            var rolesString = userService.ShowRoles();

            if (!string.IsNullOrEmpty(rolesString) && rolesString != "No roles found.")
            {
                // Split the roles string by newline or comma, whichever separates the records
                string[] roleEntries = rolesString.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                // Create a list to hold the role objects
                List<ListItem> roleList = new List<ListItem>();

                foreach (string roleEntry in roleEntries)
                {
                    // Split each entry into RoleId and RoleName
                    string[] roleParts = roleEntry.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (roleParts.Length >= 2)
                    {
                        string roleId = roleParts[0].Replace("RoleId: ", "").Trim();
                        string roleName = roleParts[1].Replace("RoleName: ", "").Trim();

                        // Add the role to the ListItem collection
                        roleList.Add(new ListItem(roleName, roleId));
                    }
                }

                // Bind the ListItem collection to the DropDownList
                ddlRole.DataSource = roleList;
                ddlRole.DataTextField = "Text";  // This will display the RoleName
                ddlRole.DataValueField = "Value";  // This will store the RoleId
                ddlRole.DataBind();
            }
            else
            {
                lblMessage.Text = "No roles found.";
            }
        }


        // Add user event handler
        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Value;
            string email = txtEmail.Value;
            string passwordHash = txtPassword.Value; // You should hash this password before storing it.
            int roleId = int.Parse(ddlRole.SelectedValue); // Assuming roles are populated
            string isActive = txtIsActive.Value; // Assuming "true" or "false"

            // Create a new UserServiceSoapClient instance
            var userService = new UserServiceSoapClient();

            // Call the WebMethod AddUser
            var result = userService.AddUser(userName, email, passwordHash, roleId, isActive);
            lblMessage.Text = result;
        }

        // Delete user event handler
        protected void btnDeleteUser_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(txtDeleteUserId.Value);

            // Create a new UserServiceSoapClient instance
            var userService = new UserServiceSoapClient();

            // Call the WebMethod DeleteUser
            var result = userService.DeleteUser(userId);
            lblMessage.Text = result;
        }

        // Show users event handler
        protected void ShowUsers()
        {
            // Create a new UserServiceSoapClient instance
            var userService = new UserServiceSoapClient();

            // Call the WebMethod ShowUsers
            var result = userService.ShowUsers();

            if (result != "No users found.")
            {
                // Set the result as the text for the Literal control
                litUsers.Text = result.Replace("\n", "<br/>"); // Add line breaks for better readability
            }
            else
            {
                litUsers.Text = result;
            }
        }
    }
}