using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SPC_Web
{
    public partial class ManageManufacturingPlants : System.Web.UI.Page
    {
        private ManufacturingPlantService _service = new ManufacturingPlantService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load manufacturing plants on page load
                string result = _service.ShowManufacturingPlants();
                litManufacturingPlants.InnerText = result;  // Use InnerText instead of Text
            }
        }

        // Event to add a manufacturing plant
        protected void BtnAddManufacturingPlant_Click(object sender, EventArgs e)
        {
            string plantName = txtPlantName.Value;
            string location = txtLocation.Value;
            string contactName = txtContactName.Value;
            string phoneNumber = txtPhoneNumber.Value;

            // Call the web service method to add the manufacturing plant
            string result = _service.AddManufacturingPlant(plantName, location, contactName, phoneNumber);
            lblMessage.Text = result; // Use Label for message
            lblMessage.ForeColor = result.Contains("error") ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }

        // Event to edit a manufacturing plant
        protected void BtnEditManufacturingPlant_Click(object sender, EventArgs e)
        {
            int plantId = int.Parse(txtEditPlantId.Value);
            string plantName = txtEditPlantName.Value;
            string location = txtEditLocation.Value;
            string contactName = txtEditContactName.Value;
            string phoneNumber = txtEditPhoneNumber.Value;

            // Call the web service method to edit the manufacturing plant
            string result = _service.EditManufacturingPlant(plantId, plantName, location, contactName, phoneNumber);
            lblMessage.Text = result; // Use Label for message
            lblMessage.ForeColor = result.Contains("error") ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }

        // Event to delete a manufacturing plant
        protected void BtnDeleteManufacturingPlant_Click(object sender, EventArgs e)
        {
            int plantId = int.Parse(txtDeletePlantId.Value);

            // Call the web service method to delete the manufacturing plant
            string result = _service.DeleteManufacturingPlant(plantId);
            lblMessage.Text = result; // Use Label for message
            lblMessage.ForeColor = result.Contains("error") ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }
    }
}