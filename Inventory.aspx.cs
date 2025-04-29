using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SPC_Web
{
    public partial class Inventory : System.Web.UI.Page
    {
        private readonly InventoryServiceReference.InventoryServiceSoapClient inventoryService = new InventoryServiceReference.InventoryServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowInventory();
        }

        private void ShowInventory()
        {

            try
            {
                // Call the GetInventory web service to get the list of inventory items
                var inventoryList = inventoryService.GetInventory();

                // Format the inventory data to display in the Literal control
                string inventoryTableHtml = "<table border='1'>";
                inventoryTableHtml += "<thead><tr><th>Inventory ID</th><th>Drug Name</th><th>Quantity</th><th>Expiry Date</th><th>Price</th><th>Stock Status</th><th>Supplier ID</th></tr></thead>";
                inventoryTableHtml += "<tbody>";
                foreach (var item in inventoryList)
                {
                    inventoryTableHtml += "<tr>";
                    inventoryTableHtml += "<td>" + item.InventoryId + "</td>";
                    inventoryTableHtml += "<td>" + item.DrugName + "</td>";
                    inventoryTableHtml += "<td>" + item.Quantity + "</td>";
                    inventoryTableHtml += "<td>" + item.ExpiryDate.ToString("yyyy-MM-dd") + "</td>";
                    inventoryTableHtml += "<td>" + item.Price.ToString("C") + "</td>";
                    inventoryTableHtml += "<td>" + item.StockStatus + "</td>";
                    inventoryTableHtml += "<td>" + item.SupplierId + "</td>";
                    inventoryTableHtml += "</tr>";
                }
                inventoryTableHtml += "</tbody></table>";

                // Set the generated HTML as the content for the Literal control
                litInventory.Text = inventoryTableHtml;
            }
            catch (Exception ex)
            {
                litInventory.Text = "<p>Error: " + ex.Message + "</p>";
            }
        }

        // Add Inventory Item
        protected void btnAddInventory_Click(object sender, EventArgs e)
        {
            string drugName = txtDrugName.Value;
            int quantity = int.Parse(txtQuantity.Value);
            DateTime expiryDate = DateTime.Parse(txtExpiryDate.Value);
            decimal price = decimal.Parse(txtPrice.Value);
            string stockStatus = txtStockStatus.Value;
            int supplierId = int.Parse(txtSupplierId.Value);

            string result = inventoryService.AddInventory(drugName, quantity, expiryDate, price, stockStatus, supplierId);
            lblMessage.Text = result;
        }

        // Delete Inventory Item
        protected void btnDeleteInventory_Click(object sender, EventArgs e)
        {
            int inventoryId = int.Parse(txtDeleteInventoryId.Value);

            string result = inventoryService.DeleteInventory(inventoryId);
            lblMessage.Text = result;
        }

        // Search Inventory Items
        protected void btnSearchInventory_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchTerm.Value;

            var inventoryList = inventoryService.SearchInventory(searchTerm);
            string inventoryResults = "<ul>";

            foreach (var item in inventoryList)
            {
                inventoryResults += $"<li>{item.DrugName} (ID: {item.InventoryId}, Quantity: {item.Quantity}, Price: {item.Price}, Expiry: {item.ExpiryDate}, Status: {item.StockStatus}, Supplier ID: {item.SupplierId})</li>";
            }

            inventoryResults += "</ul>";
            litInventory.Text = inventoryResults;
        }
    }
}