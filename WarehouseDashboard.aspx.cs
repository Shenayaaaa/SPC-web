using SPC_Web.InventoryServiceReference;
using SPC_Web.OrderServiceReference;
using SPC_Web.PharmacyServiceReference;
using SPC_Web.WarehouseServiceReference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SPC_Web
{
    public partial class WarehouseDashboard : System.Web.UI.Page
    {
        PharmacyServiceSoapClient pharmacyService = new PharmacyServiceSoapClient();
        InventoryServiceSoapClient inventoryService = new InventoryServiceSoapClient();
        private OrderServiceSoapClient orderService = new OrderServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            // On initial page load, show warehouses.
            if (!IsPostBack)
            {
                ShowWarehouses();
                LoadPharmacies();
                LoadInventory();
                LoadOrders();
            }
        }

        private void LoadOrders()
        {
            string result = orderService.ShowOrders();
            litOrders.Text = result.Replace("\n", "<br/>");
        }

        protected void btnSearchOrder_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchOrder.Text;
            string result = orderService.SearchOrders(searchTerm);
            litOrders.Text = result.Replace("\n", "<br/>");
        }

        protected void btnAddPharmacy_Click(object sender, EventArgs e)
        {
            string name = txtPharmacyName.Text;
            string location = txtLocation.Text;
            string phone = txtPhoneNumber.Text;
            string email = txtEmail.Text;

            string result = pharmacyService.AddPharmacy(name, location, phone, email);
            Response.Write($"<script>alert('{result}');</script>");
            LoadPharmacies();
        }

        // Delete Pharmacy
        protected void btnDeletePharmacy_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtPharmacyIdToDelete.Text, out int pharmacyId))
            {
                string result = pharmacyService.DeletePharmacy(pharmacyId);
                Response.Write($"<script>alert('{result}');</script>");
                LoadPharmacies();
            }
            else
            {
                Response.Write("<script>alert('Invalid Pharmacy ID');</script>");
            }
        }

        // Load Pharmacies
        private void LoadPharmacies()
        {
            string pharmacies = pharmacyService.ShowPharmacies();
            gvPharmacies.DataSource = FormatData(pharmacies); // Helper method for formatting
            gvPharmacies.DataBind();
        }

        // Add Inventory
        protected void btnAddInventory_Click(object sender, EventArgs e)
        {
            string drugName = txtDrugName.Text;
            int.TryParse(txtQuantity.Text, out int quantity);
            DateTime.TryParse(txtExpiryDate.Text, out DateTime expiryDate);
            decimal.TryParse(txtPrice.Text, out decimal price);
            string stockStatus = txtStockStatus.Text;
            int.TryParse(txtSupplierId.Text, out int supplierId);

            string result = inventoryService.AddInventory(drugName, quantity, expiryDate, price, stockStatus, supplierId);
            Response.Write($"<script>alert('{result}');</script>");
            LoadInventory();
        }

        // Delete Inventory
        protected void btnDeleteInventory_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtInventoryIdToDelete.Text, out int inventoryId))
            {
                string result = inventoryService.DeleteInventory(inventoryId);
                Response.Write($"<script>alert('{result}');</script>");
                LoadInventory();
            }
            else
            {
                Response.Write("<script>alert('Invalid Inventory ID');</script>");
            }
        }

        // Load Inventory
        private void LoadInventory()
        {
            var inventory = inventoryService.GetInventory();
            gvInventory.DataSource = inventory;
            gvInventory.DataBind();
        }

        // Helper: Format Data for GridView
        private DataTable FormatData(string rawData)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Details");

            foreach (var line in rawData.Split('\n'))
            {
                if (!string.IsNullOrWhiteSpace(line))
                    dt.Rows.Add(line.Trim());
            }
            return dt;
        }

        // Add Warehouse button click event
        protected void AddWarehouse_Click(object sender, EventArgs e)
        {
            string warehouseName = WarehouseName.Value;
            string location = Location.Value;

            WarehouseServiceSoapClient service = new WarehouseServiceSoapClient();
            string result = service.AddWarehouse(warehouseName, location);

            // Show result
            litWarehouses.Text = result;
        }

        // Edit Warehouse button click event
        protected void EditWarehouse_Click(object sender, EventArgs e)
        {
            int warehouseId = int.Parse(WarehouseId.Value);
            string warehouseName = EditWarehouseName.Value;
            string location = EditLocation.Value;

            WarehouseServiceSoapClient service = new WarehouseServiceSoapClient();
            string result = service.EditWarehouse(warehouseId, warehouseName, location);

            // Show result
            litWarehouses.Text = result;
        }

        // Show all warehouses in a Literal control
        private void ShowWarehouses()
        {
            WarehouseServiceSoapClient service = new WarehouseServiceSoapClient();
            string result = service.ShowWarehouses();

            litWarehouses.Text = result;
        }
    }
}