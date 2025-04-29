using SPC_Web.TenderServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SPC_Web
{
    public partial class ManageSuppliers : System.Web.UI.Page
    {
        TenderServiceSoapClient client = new TenderServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear message on load
            lblMessage.Text = "";
        }

        protected void btnAddSupplier_Click(object sender, EventArgs e)
        {
            // Get form input
            string supplierName = txtSupplierName.Text;
            string contactName = txtContactName.Text;
            string address = txtAddress.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string email = txtEmail.Text;
            string status = txtStatus.Text;

            // Call AddSupplier web method
            string result = client.AddSupplier(supplierName, contactName, address, phoneNumber, email, status);
            lblMessage.Text = result;
        }

        protected void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            // Get supplier ID
            int supplierId;
            if (int.TryParse(txtDeleteSupplierId.Text, out supplierId))
            {
                // Call DeleteSupplier web method
                string result = client.DeleteSupplier(supplierId);
                lblMessage.Text = result;
            }
            else
            {
                lblMessage.Text = "Invalid Supplier ID.";
            }
        }

        protected void btnShowSuppliers_Click(object sender, EventArgs e)
        {
            // Call ShowSuppliers web method
            string result = client.ShowSuppliers();
            litSuppliers.Text = $"<pre>{result}</pre>";
        }
    }
}