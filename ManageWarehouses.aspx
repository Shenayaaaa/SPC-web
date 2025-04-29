<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageWarehouses.aspx.cs" Inherits="SPC_Web.ManageWarehouses" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Warehouses</title>
    <style>/* General Layout */
body {
    font-family: 'Arial', sans-serif;
    background-color: #f4f7fa;
    margin: 0;
    padding: 0;
}

.container {
    max-width: 1000px;
    margin: 20px auto;
    padding: 20px;
    background-color: #fff;
    border-radius: 8px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

h1 {
    text-align: center;
    color: #333;
    font-size: 32px;
}

h2 {
    color: #333;
    font-size: 24px;
    margin-bottom: 10px;
}

h3 {
    color: #444;
    font-size: 18px;
    margin-bottom: 10px;
}

.form-section {
    margin-bottom: 30px;
}

label {
    font-size: 14px;
    font-weight: bold;
    color: #555;
    display: inline-block;
    margin: 5px 0;
}

.input-field {
    width: 100%;
    padding: 10px;
    margin-bottom: 20px;
    border: 2px solid #ccc;
    border-radius: 4px;
    font-size: 14px;
}

.input-field:focus {
    border-color: #4CAF50;
}

.btn {
    padding: 10px 20px;
    font-size: 16px;
    border-radius: 4px;
    cursor: pointer;
    transition: background-color 0.3s ease;
}

.btn-add {
    background-color: #4CAF50;
    color: white;
    border: none;
}

.btn-add:hover {
    background-color: #45a049;
}

.btn-delete {
    background-color: #f44336;
    color: white;
    border: none;
}

.btn-delete:hover {
    background-color: #e53935;
}

.btn-show {
    background-color: #2196F3;
    color: white;
    border: none;
}

.btn-show:hover {
    background-color: #1976d2;
}

.message {
    font-weight: bold;
    margin-top: 10px;
    display: block;
}

.message.success {
    color: #4CAF50;
}

.message.error {
    color: #f44336;
}

/* Responsive Design */
@media (max-width: 768px) {
    .container {
        padding: 10px;
        width: 90%;
    }

    .input-field {
        padding: 8px;
    }

    .btn {
        width: 100%;
        padding: 12px;
    }
}
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Manage Warehouses</h1>

            <!-- Add Warehouse Section -->
            <div class="form-section">
                <h2>Add Warehouse</h2>
                <label for="txtWarehouseName">Warehouse Name:</label>
                <input type="text" id="txtWarehouseName" runat="server" class="input-field" /><br />

                <label for="txtLocation">Location:</label>
                <input type="text" id="txtLocation" runat="server" class="input-field" /><br />

                <asp:Button ID="btnAddWarehouse" runat="server" Text="Add Warehouse" OnClick="btnAddWarehouse_Click" CssClass="btn btn-add" />
                <asp:Label ID="lblAddMessage" runat="server" CssClass="message"></asp:Label>
            </div>

            <!-- Delete Warehouse Section -->
            <div class="form-section">
                <h2>Delete Warehouse</h2>
                <label for="txtDeleteWarehouseId">Warehouse ID:</label>
                <input type="text" id="txtDeleteWarehouseId" runat="server" class="input-field" /><br />
                
                <asp:Button ID="btnDeleteWarehouse" runat="server" Text="Delete Warehouse" OnClick="btnDeleteWarehouse_Click" CssClass="btn btn-delete" />
                <asp:Label ID="lblDeleteMessage" runat="server" CssClass="message"></asp:Label>
            </div>

            <!-- Show Warehouses Section -->
            <div class="form-section">
                <h2>Show Warehouses</h2>
                <asp:Button ID="btnShowWarehouses" runat="server" Text="Show All Warehouses" OnClick="btnShowWarehouses_Click" CssClass="btn btn-show" /><br />

                <h3>Warehouse Results:</h3>
                <asp:Literal ID="litWarehouses" runat="server" />
            </div>

            <!-- Message Labels -->
            <asp:Label ID="lblMessage" runat="server" CssClass="message" />
        </div>
    </form>
</body>
</html>
