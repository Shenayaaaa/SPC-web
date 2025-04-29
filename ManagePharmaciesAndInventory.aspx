<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagePharmaciesAndInventory.aspx.cs" Inherits="SPC_Web.ManagePharmaciesAndInventory" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Pharmacies and Inventory</title>
    <style>
        body {
            font-family: 'Arial', sans-serif;
            background-color: #f8f9fa;
            color: #333;
            margin: 0;
            padding: 0;
        }

        h1, h2 {
            color: #007bff;
        }

        h3 a {
            color: #007bff;
            text-decoration: none;
            font-size: 18px;
        }

        h3 a:hover {
            text-decoration: underline;
        }

        .container {
            width: 80%;
            margin: 0 auto;
        }

        .section {
            margin-bottom: 30px;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 8px;
            background-color: #fff;
        }

        .section h2 {
            margin-bottom: 15px;
        }

        .section label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }

        .section input[type="text"] {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            border-radius: 5px;
            border: 1px solid #ddd;
            font-size: 16px;
            transition: border 0.3s ease;
        }

        .section input[type="text"]:focus {
            border-color: #007bff;
            box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
        }

        .btn {
            background-color: #28a745;
            color: white;
            border: none;
            padding: 10px 20px;
            font-size: 16px;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .btn:hover {
            background-color: #218838;
        }

        .btn.delete {
            background-color: #dc3545;
        }

        .btn.delete:hover {
            background-color: #c82333;
        }

        .table-container {
            margin-top: 20px;
        }

        .message {
            font-size: 16px;
            padding: 10px;
            margin-top: 20px;
            border-radius: 5px;
            display: inline-block;
        }

        .message.success {
            background-color: #28a745;
            color: white;
        }

        .message.error {
            background-color: #dc3545;
            color: white;
        }

        /* Responsive Design */
        @media (max-width: 768px) {
            .container {
                width: 95%;
            }

            .section input[type="text"] {
                width: 100%;
            }
        }
    </style>
</head>
<body>

    <form id="form1" runat="server" class="container">
        <h1>Manage Pharmacies and Inventory</h1>
        <h3><a href="Inventory.aspx">Go to Inventory Management</a></h3>

        <!-- Add Pharmacy Section -->
        <div class="section">
            <h2>Add Pharmacy</h2>
            <label for="txtPharmacyName">Pharmacy Name:</label>
            <input type="text" id="txtPharmacyName" runat="server" />
            <label for="txtLocation">Location:</label>
            <input type="text" id="txtLocation" runat="server" />
            <label for="txtPhoneNumber">Phone Number:</label>
            <input type="text" id="txtPhoneNumber" runat="server" />
            <label for="txtEmail">Email:</label>
            <input type="text" id="txtEmail" runat="server" />
            <asp:Button ID="btnAddPharmacy" runat="server" Text="Add Pharmacy" OnClick="btnAddPharmacy_Click" CssClass="btn" />
        </div>

        <!-- Delete Pharmacy Section -->
        <div class="section">
            <h2>Delete Pharmacy</h2>
            <label for="txtDeletePharmacyId">Pharmacy ID:</label>
            <input type="text" id="txtDeletePharmacyId" runat="server" />
            <asp:Button ID="btnDeletePharmacy" runat="server" Text="Delete Pharmacy" OnClick="btnDeletePharmacy_Click" CssClass="btn delete" />
        </div>

        <!-- Show Pharmacies Section -->
        <div class="section">
            <h2>All Pharmacies</h2>
            <div class="table-container">
                <asp:Literal ID="litPharmacies" runat="server" />
            </div>
        </div>

        <!-- Message Labels -->
        <asp:Label ID="lblMessage" runat="server" CssClass="message" />
    </form>

</body>
</html>
