<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageSuppliers.aspx.cs" Inherits="SPC_Web.ManageSuppliers" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Suppliers</title>
   <style>/* General Styles */
body {
    font-family: Arial, sans-serif;
    background-color: #f4f4f9;
    margin: 0;
    padding: 0;
    color: #333;
}

#form1 {
    width: 80%;
    margin: 2% auto;
    padding: 20px;
    background-color: #ffffff;
    border-radius: 8px;
    box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
}

/* Headings */
h2 {
    font-size: 2em;
    color: #4CAF50;
    text-align: center;
    margin-bottom: 20px;
}

/* Fieldset & Legend */
fieldset {
    border: 2px solid #ddd;
    padding: 20px;
    margin-bottom: 20px;
    border-radius: 8px;
}

legend {
    font-size: 1.3em;
    color: #4CAF50;
    font-weight: bold;
}

/* Label and Input Styles */
label {
    display: block;
    margin-bottom: 8px;
    font-weight: 600;
}

input[type="text"] {
    width: 100%;
    padding: 12px;
    margin-bottom: 16px;
    border-radius: 8px;
    border: 1px solid #ddd;
    font-size: 1em;
}

input[type="text"]:focus {
    border-color: #4CAF50;
    outline: none;
}

/* Button Styles */
.btn {
    padding: 12px 24px;
    border-radius: 8px;
    border: none;
    color: white;
    font-size: 1.1em;
    cursor: pointer;
    transition: background-color 0.3s ease;
}

.btn:hover {
    opacity: 0.9;
}

.btn:active {
    background-color: #333;
}

/* Add Supplier Button */
#btnAddSupplier {
    background-color: #4CAF50;
}

/* Delete Supplier Button */
#btnDeleteSupplier {
    background-color: #f44336;
}

/* Show Suppliers Button */
#btnShowSuppliers {
    background-color: #2196F3;
    margin-top: 20px;
    display: block;
    width: 100%;
}

/* Message Label */
.message {
    font-size: 1.2em;
    padding: 10px;
    margin-bottom: 20px;
    border-radius: 8px;
    text-align: center;
}

.message.success {
    background-color: #4CAF50;
    color: white;
}

.message.error {
    background-color: #f44336;
    color: white;
}

/* Table Styles */
.table-container {
    margin-top: 20px;
}

table {
    width: 100%;
    border-collapse: collapse;
    margin-top: 20px;
}

table, th, td {
    border: 1px solid #ddd;
}

th, td {
    padding: 10px;
    text-align: left;
}

th {
    background-color: #f2f2f2;
    color: #4CAF50;
}

tr:nth-child(even) {
    background-color: #f9f9f9;
}

/* Responsiveness */
@media screen and (max-width: 768px) {
    #form1 {
        width: 95%;
        padding: 15px;
    }

    input[type="text"] {
        padding: 10px;
        font-size: 0.9em;
    }

    .btn {
        width: 100%;
        padding: 10px;
    }

    table {
        font-size: 0.9em;
    }
}
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="form1">
            <h2>Manage Suppliers</h2>

            <!-- Message Label -->
            <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>

            <!-- Add Supplier Form -->
            <fieldset>
                <legend>Add Supplier</legend>
                <label for="txtSupplierName">Supplier Name:</label>
                <asp:TextBox ID="txtSupplierName" runat="server"></asp:TextBox><br />
                
                <label for="txtContactName">Contact Name:</label>
                <asp:TextBox ID="txtContactName" runat="server"></asp:TextBox><br />
                
                <label for="txtAddress">Address:</label>
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox><br />
                
                <label for="txtPhoneNumber">Phone Number:</label>
                <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox><br />
                
                <label for="txtEmail">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
                
                <label for="txtStatus">Status:</label>
                <asp:TextBox ID="txtStatus" runat="server"></asp:TextBox><br />
                
                <asp:Button ID="btnAddSupplier" runat="server" Text="Add Supplier" OnClick="btnAddSupplier_Click" CssClass="btn" />
            </fieldset>

            <!-- Delete Supplier Form -->
            <fieldset>
                <legend>Delete Supplier</legend>
                <label for="txtDeleteSupplierId">Supplier ID:</label>
                <asp:TextBox ID="txtDeleteSupplierId" runat="server"></asp:TextBox><br />
                <asp:Button ID="btnDeleteSupplier" runat="server" Text="Delete Supplier" OnClick="btnDeleteSupplier_Click" CssClass="btn" />
            </fieldset>

            <!-- Show Suppliers -->
            <asp:Button ID="btnShowSuppliers" runat="server" Text="Show All Suppliers" OnClick="btnShowSuppliers_Click" CssClass="btn" />
            
            <div class="table-container">
                <asp:Literal ID="litSuppliers" runat="server"></asp:Literal>
            </div>
        </div>
    </form>
</body>
</html>