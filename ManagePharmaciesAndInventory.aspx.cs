using SPC_Web.PharmacyServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SPC_Web
{
    public partial class ManagePharmaciesAndInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowPharmacies(); // Load pharmacies when the page loads
            }
        }

        // Show pharmacies by calling ASMX WebService
        protected void ShowPharmacies()
        {
            try
            {
                var pharmacyService = new PharmacyServiceSoapClient();
                string result = pharmacyService.ShowPharmacies();

                if (result != "No pharmacies found.")
                {
                    litPharmacies.Text = result.Replace("\n", "<br/>"); // Display the list of pharmacies
                }
                else
                {
                    litPharmacies.Text = result;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        // Add a pharmacy
        protected void btnAddPharmacy_Click(object sender, EventArgs e)
        {
            try
            {
                string pharmacyName = txtPharmacyName.Value;
                string location = txtLocation.Value;
                string phoneNumber = txtPhoneNumber.Value;
                string email = txtEmail.Value;

                var pharmacyService = new PharmacyServiceSoapClient();
                string result = pharmacyService.AddPharmacy(pharmacyName, location, phoneNumber, email);

                lblMessage.Text = result;
                ShowPharmacies(); // Refresh the list
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        // Delete a pharmacy
        protected void btnDeletePharmacy_Click(object sender, EventArgs e)
        {
            try
            {
                int pharmacyId = int.Parse(txtDeletePharmacyId.Value);

                var pharmacyService = new PharmacyServiceSoapClient();
                string result = pharmacyService.DeletePharmacy(pharmacyId);

                lblMessage.Text = result;
                ShowPharmacies(); // Refresh the list
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}