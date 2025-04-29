using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SPC_Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Use the web reference to call the ASMX service
            LoginServiceReference.LoginServiceSoapClient loginService = new LoginServiceReference.LoginServiceSoapClient();

            string response = loginService.Login(email, password);

            if (response.StartsWith("Success"))
            {
                // Extract role from response
                string role = response.Split(':')[1].Trim();

                // Redirect based on role
                switch (role)
                {
                    case "Admin":
                        Response.Redirect("AdminDashboard.aspx");
                        break;
                    case "Supplier":
                        Response.Redirect("SupplierDashboard.aspx");
                        break;
                    case "Pharmacy Staff":
                        Response.Redirect("PharmacyDashboard.aspx");
                        break;
                    case "Warehouse Staff":
                        Response.Redirect("WarehouseDashboard.aspx");
                        break;
                    case "Manufacturing Staff":
                        Response.Redirect("ManufacturingDashboard.aspx");
                        break;
                    default:
                        lblMessage.Text = "Role not recognized.";
                        break;
                }
            }
            else
            {
                lblMessage.Text = response;
            }
        }
    }
}