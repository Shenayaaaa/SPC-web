<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WarehouseDashboard.aspx.cs" Inherits="SPC_Web.WarehouseDashboard" %>

<!DOCTYPE html>
<html>
<head>
    <title>Warehouse Dashboard</title>
    <style>/* General Styles */
body {
    font-family: 'Arial', sans-serif;
    margin: 0;
    padding: 0;
    background-color: #f4f6f9;
    color: #333;
}

h2, h3 {
    color: #2c3e50;
    font-size: 1.6em;
    margin-bottom: 10px;
}

h3 {
    font-size: 1.4em;
    margin-top: 20px;
}

/* Container and Section */
form {
    width: 80%;
    margin: 20px auto;
    padding: 20px;
    background-color: #fff;
    border-radius: 8px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

section {
    margin-bottom: 40px;
}

/* Input Fields */
input[type="text"], input[type="number"], input[type="email"], input[type="date"], .form-input {
    width: 100%;
    padding: 12px;
    margin-bottom: 10px;
    border: 1px solid #ddd;
    border-radius: 4px;
    font-size: 1em;
    transition: border-color 0.3s ease;
}

input[type="text"]:focus, input[type="number"]:focus, input[type="email"]:focus, input[type="date"]:focus {
    border-color: #3498db;
    outline: none;
}

input::placeholder {
    color: #7f8c8d;
}

/* Button Styles */
button, .btn-common {
    padding: 12px 20px;
    border: none;
    border-radius: 4px;
    font-size: 1em;
    cursor: pointer;
    transition: background-color 0.3s ease;
}

button[type="submit"]:hover, .btn-common:hover {
    background-color: #2980b9;
}

/* Add Button - Green */
button[type="submit"].btn-add {
    background-color: #27ae60;
}

button[type="submit"].btn-add:hover {
    background-color: #2ecc71;
}

/* Edit Button - Blue */
button[type="submit"].btn-edit {
    background-color: #3498db;
}

button[type="submit"].btn-edit:hover {
    background-color: #2980b9;
}

/* Delete Button - Red */
button[type="submit"].btn-delete {
    background-color: #e74c3c;
}

button[type="submit"].btn-delete:hover {
    background-color: #c0392b;
}

/* GridView Styling */
table, .grid-view {
    width: 100%;
    border-collapse: collapse;
    margin-top: 10px;
}

table th, table td {
    padding: 12px;
    text-align: left;
    border: 1px solid #ddd;
}

table th {
    background-color: #3498db;
    color: white;
}

table tr:nth-child(even) {
    background-color: #f2f2f2;
}

table tr:hover {
    background-color: #ecf0f1;
}

/* Section Separation */
hr {
    border: 0;
    border-top: 1px solid #ddd;
    margin: 20px 0;
}

/* Mobile Responsiveness */
@media (max-width: 768px) {
    form {
        width: 90%;
        padding: 15px;
    }

    input[type="text"], input[type="number"], input[type="email"], input[type="date"] {
        padding: 10px;
        font-size: 0.9em;
    }

    h2, h3 {
        font-size: 1.2em;
    }

    button, .btn-common {
        width: 100%;
        padding: 10px 15px;
    }
}

@media (max-width: 480px) {
    h2, h3 {
        font-size: 1.1em;
    }
}
</style>
</head>
<body>
    <h2>Warehouse Dashboard</h2>

    <!-- Single form tag for the entire page -->
    <form method="post" runat="server">
        <h3>Add Warehouse</h3>
        <label for="WarehouseName">Warehouse Name:</label>
        <input type="text" id="WarehouseName" name="WarehouseName" runat="server" /><br /><br />

        <label for="Location">Location:</label>
        <input type="text" id="Location" name="Location" runat="server" /><br /><br />

        <button type="submit" runat="server" onserverclick="AddWarehouse_Click">Add Warehouse</button>
        
        <hr />

        <h3>Edit Warehouse</h3>
        <label for="WarehouseId">Warehouse ID:</label>
        <input type="number" id="WarehouseId" name="WarehouseId" runat="server" /><br /><br />

        <label for="EditWarehouseName">Warehouse Name:</label>
        <input type="text" id="EditWarehouseName" name="EditWarehouseName" runat="server" /><br /><br />

        <label for="EditLocation">Location:</label>
        <input type="text" id="EditLocation" name="EditLocation" runat="server" /><br /><br />

        <button type="submit" runat="server" onserverclick="EditWarehouse_Click">Edit Warehouse</button>

        <hr />

        <h3>Warehouses List</h3>
        <asp:Literal ID="litWarehouses" runat="server"></asp:Literal> 

        <!-- Pharmacy Dashboard -->
        <h2>Pharmacy Dashboard</h2>

       <h3>Manage Pharmacies</h3>
<asp:TextBox ID="txtPharmacyName" runat="server" Placeholder="Pharmacy Name"></asp:TextBox><br /><br />
<asp:TextBox ID="txtLocation" runat="server" Placeholder="Location"></asp:TextBox><br /><br />
<asp:TextBox ID="txtPhoneNumber" runat="server" Placeholder="Phone Number"></asp:TextBox><br /><br />
<asp:TextBox ID="txtEmail" runat="server" Placeholder="Email"></asp:TextBox> <br /><br />
<asp:Button ID="btnAddPharmacy" runat="server" CssClass="btn-common" Text="Add Pharmacy" OnClick="btnAddPharmacy_Click" /> 
<asp:Button ID="btnDeletePharmacy" runat="server" CssClass="btn-common" Text="Delete Pharmacy" OnClick="btnDeletePharmacy_Click" />
        <br /><br />
<asp:TextBox ID="txtPharmacyIdToDelete" runat="server" Placeholder="Pharmacy ID to Delete"></asp:TextBox>
<h3>Pharmacies</h3>
<asp:GridView ID="gvPharmacies" runat="server" AutoGenerateColumns="true"></asp:GridView><br /><br />

<!-- Inventory Management Section -->
<h3>Manage Inventory</h3>
<asp:TextBox ID="txtDrugName" runat="server" Placeholder="Drug Name"></asp:TextBox><br /><br />
<asp:TextBox ID="txtQuantity" runat="server" Placeholder="Quantity"></asp:TextBox><br /><br />
<asp:TextBox ID="txtExpiryDate" runat="server" Placeholder="Expiry Date (yyyy-MM-dd)"></asp:TextBox><br /><br />
<asp:TextBox ID="txtPrice" runat="server" Placeholder="Price"></asp:TextBox><br /><br />
<asp:TextBox ID="txtStockStatus" runat="server" Placeholder="Stock Status"></asp:TextBox><br /><br />
<asp:TextBox ID="txtSupplierId" runat="server" Placeholder="Supplier ID"></asp:TextBox><br /><br />
<asp:Button ID="btnAddInventory" runat="server" CssClass="btn-common" Text="Add Inventory" OnClick="btnAddInventory_Click" /><br /><br />
        <asp:TextBox ID="txtInventoryIdToDelete" runat="server" Placeholder="Inventory ID to Delete"></asp:TextBox><br /><br />
<asp:Button ID="btnDeleteInventory" runat="server" CssClass="btn-common" Text="Delete Inventory" OnClick="btnDeleteInventory_Click" />

<h3>Inventory</h3>
<asp:GridView ID="gvInventory" runat="server" AutoGenerateColumns="true"></asp:GridView>

<!-- Order Management Section -->
<h2>Manage Orders</h2>
<asp:TextBox ID="txtSearchOrder" runat="server" Placeholder="Search Orders"></asp:TextBox><br /><br />
<asp:Button ID="btnSearchOrder" runat="server" CssClass="btn-common" Text="Search Orders" OnClick="btnSearchOrder_Click" />


         <h3>Order List</h3>
         <asp:Literal ID="litOrders" runat="server"></asp:Literal>
    </form>
</body>
</html>