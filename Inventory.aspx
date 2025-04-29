<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="SPC_Web.Inventory" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inventory Management</title>
    <style>/* General Body Styles */
body {
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    background-color: #f9f9f9;
    margin: 0;
    padding: 0;
}

/* Header Styling */
h1 {
    text-align: center;
    font-size: 2.5rem;
    color: #333;
    margin-top: 30px;
    font-weight: bold;
}

/* Section Container Styles */
.section {
    background-color: #ffffff;
    padding: 20px;
    margin: 20px 0;
    border-radius: 8px;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}

/* Section Headings */
h2 {
    color: #333;
    font-size: 1.8rem;
    margin-bottom: 15px;
    font-weight: bold;
}

/* Input Field Styling */
input[type="text"],
input[type="date"] {
    width: 100%;
    padding: 10px;
    margin: 10px 0;
    border: 1px solid #ccc;
    border-radius: 8px;
    box-sizing: border-box;
    font-size: 1rem;
    background-color: #f9f9f9;
    transition: border 0.3s ease;
}

/* Input Focus Styling */
input[type="text"]:focus,
input[type="date"]:focus {
    border-color: #007bff;
    outline: none;
}

/* Button Styling */
button,
input[type="button"],
input[type="submit"] {
    padding: 12px 20px;
    font-size: 1.1rem;
    border: none;
    border-radius: 8px;
    cursor: pointer;
    margin-top: 15px;
    transition: background-color 0.3s, transform 0.3s;
    width: 100%;
}

.btn-primary {
    background-color: #007bff;
    color: white;
}

.btn-primary:hover {
    background-color: #0056b3;
    transform: translateY(-2px);
}

.btn-danger {
    background-color: #e53935;
    color: white;
}

.btn-danger:hover {
    background-color: #c62828;
    transform: translateY(-2px);
}

/* Inventory Results Section */
.inventory-results {
    background-color: #ffffff;
    padding: 20px;
    margin: 20px 0;
    border-radius: 8px;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}

.inventory-results h3 {
    font-size: 1.6rem;
    margin-bottom: 20px;
    color: #333;
}

/* Message Label Styling */
.message-label {
    font-size: 1.1rem;
    margin-top: 20px;
}

.message-label.error {
    color: #e53935;
}

/* Responsive Design */
@media (max-width: 768px) {
    /* Stack sections vertically on smaller screens */
    .section {
        margin: 10px;
    }

    input[type="text"],
    input[type="date"],
    button {
        width: 100%;
    }

    h1 {
        font-size: 2rem;
    }

    h2 {
        font-size: 1.5rem;
    }
}
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Inventory Management</h1>

            <!-- Add Inventory Section -->
            <div class="section">
                <h2>Add Inventory</h2>
                <label for="txtDrugName">Drug Name:</label>
                <input type="text" id="txtDrugName" runat="server" />
                <label for="txtQuantity">Quantity:</label>
                <input type="text" id="txtQuantity" runat="server" />
                <label for="txtExpiryDate">Expiry Date:</label>
                <input type="date" id="txtExpiryDate" runat="server" />
                <label for="txtPrice">Price:</label>
                <input type="text" id="txtPrice" runat="server" />
                <label for="txtStockStatus">Stock Status:</label>
                <input type="text" id="txtStockStatus" runat="server" />
                <label for="txtSupplierId">Supplier ID:</label>
                <input type="text" id="txtSupplierId" runat="server" />
                <asp:Button ID="btnAddInventory" runat="server" Text="Add Inventory" CssClass="btn-primary" OnClick="btnAddInventory_Click" />
            </div>

            <!-- Delete Inventory Section -->
            <div class="section">
                <h2>Delete Inventory</h2>
                <label for="txtDeleteInventoryId">Inventory ID:</label>
                <input type="text" id="txtDeleteInventoryId" runat="server" />
                <asp:Button ID="btnDeleteInventory" runat="server" Text="Delete Inventory" CssClass="btn-danger" OnClick="btnDeleteInventory_Click" />
            </div>

            <!-- Search Inventory Section -->
            <div class="section">
                <h2>Search Inventory</h2>
                <label for="txtSearchTerm">Search Term:</label>
                <input type="text" id="txtSearchTerm" runat="server" />
                <asp:Button ID="btnSearchInventory" runat="server" Text="Search Inventory" CssClass="btn-primary" OnClick="btnSearchInventory_Click" />
            </div>

            <!-- Show Inventory Results -->
            <div class="inventory-results">
                <h3>Inventory Results:</h3>
                <asp:Literal ID="litInventory" runat="server" />
            </div>

            <!-- Message Labels -->
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" CssClass="message-label" />
        </div>
    </form>
</body>
</html>

