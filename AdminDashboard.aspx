<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="SPC_PHARMA_SYSTEM.AdminDashboard" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <title>Admin Home</title>
    <style>
/* General Body Styles */
body {
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    background-color: #f4f7fa;
    margin: 0;
    padding: 0;
}

/* Header Style */
h1 {
    text-align: center;
    color: #333;
    padding-top: 30px;
    font-size: 2.5rem;
    font-weight: bold;
}

/* Container to center cards */
.container {
    display: grid;
    grid-template-columns: repeat(auto-fill, minmax(250px, 1fr));
    gap: 20px;
    padding: 20px;
    max-width: 1200px;
    margin: 0 auto;
}

/* Card Style */
.card {
    background-color: #ffffff;
    padding: 20px;
    border-radius: 10px;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
    transition: transform 0.3s, box-shadow 0.3s;
    text-align: center;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    height: 200px;
}

/* Card Hover Effects */
.card:hover {
    transform: translateY(-10px);
    box-shadow: 0 6px 12px rgba(0, 0, 0, 0.15);
}

/* Card Title */
.card h3 {
    color: #333;
    font-size: 1.6rem;
    font-weight: bold;
    margin-bottom: 20px;
}

/* Card Link Style */
.card a {
    color: #007bff;
    text-decoration: none;
    font-size: 1.1rem;
    padding: 10px 15px;
    border-radius: 5px;
    background-color: #f0f8ff;
    border: 1px solid #007bff;
    display: inline-block;
    margin-top: 20px;
    transition: background-color 0.3s, color 0.3s;
}

/* Card Link Hover Effect */
.card a:hover {
    background-color: #007bff;
    color: #ffffff;
}

/* Responsive Design */
@media (max-width: 768px) {
    /* Adjust container grid to single column for smaller screens */
    .container {
        grid-template-columns: 1fr;
    }

    /* Scale down font sizes on mobile */
    h1 {
        font-size: 1.8rem;
    }

    .card h3 {
        font-size: 1.4rem;
    }

    .card a {
        font-size: 1rem;
    }
}



    </style>
</head>

<body>
    <h1>Admin Home Panel</h1>
    <form id="form1" runat="server">
        <div class="container">
            <div class="card">
                <h3>Manage Users</h3>
                <a href="ManageUsers.aspx">Users Management</a>
            </div>
            <div class="card">
                <h3>Manage Pharmacies and Inventory</h3>
                <a href="ManagePharmaciesAndInventory.aspx">Pharmacies and Inventory</a>
            </div>
            <div class="card">
                <h3>Manage Warehouses</h3>
                <a href="ManageWarehouses.aspx">Warehouses Management</a>
            </div>
            <div class="card">
                <h3>Manage Plants</h3>
                <a href="ManageManufacturingPlants.aspx">Manufacturing Plants</a>
            </div>
            <div class="card">
                <h3>Manage Suppliers</h3>
                <a href="ManageSuppliers.aspx">Go to Suppliers Management</a>
            </div>
        </div>
    </form>
</body>
</html>
