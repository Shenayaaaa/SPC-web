<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="SPC_Web.ManageUsers" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Users</title>
    <style>/* General Page Styles */
body {
    font-family: Arial, sans-serif;
    background-color: #f7f7f7;
    margin: 0;
    padding: 0;
}

.container {
    width: 80%;
    max-width: 1200px;
    margin: 0 auto;
    padding: 20px;
    background-color: #ffffff;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}

h1 {
    text-align: center;
    color: #333;
}

/* Section Styling */
.form-section {
    margin-bottom: 20px;
    padding: 20px;
    background-color: #f9f9f9;
    border-radius: 8px;
}

.form-section h2 {
    color: #333;
    font-size: 1.5em;
    margin-bottom: 10px;
}

label {
    font-weight: bold;
    color: #555;
    margin-top: 10px;
    display: block;
}

/* Input Fields */
.input-field {
    width: 100%;
    padding: 10px;
    margin-top: 5px;
    border: 1px solid #ccc;
    border-radius: 4px;
    font-size: 1em;
    box-sizing: border-box;
}

.input-field:focus {
    border-color: #66afe9;
    outline: none;
}

/* Button Styling */
.btn {
    padding: 10px 15px;
    border: none;
    border-radius: 4px;
    font-size: 1em;
    cursor: pointer;
    width: 100%;
    margin-top: 10px;
    transition: background-color 0.3s ease;
}

.btn:hover {
    opacity: 0.9;
}

.btn:active {
    transform: scale(0.98);
}

.btn-add {
    background-color: #28a745;
    color: white;
}

.btn-add:hover {
    background-color: #218838;
}

.btn-delete {
    background-color: #dc3545;
    color: white;
}

.btn-delete:hover {
    background-color: #c82333;
}

/* Message Label */
.message {
    display: block;
    text-align: center;
    margin-top: 20px;
    padding: 10px;
    font-size: 1.1em;
    font-weight: bold;
}

.message.success {
    background-color: #d4edda;
    color: #155724;
}

.message.error {
    background-color: #f8d7da;
    color: #721c24;
}

/* Responsive Design */
@media (max-width: 768px) {
    .container {
        width: 100%;
        padding: 15px;
    }

    .form-section {
        padding: 15px;
    }

    .input-field {
        width: 100%;
        padding: 8px;
    }

    .btn {
        width: 100%;
    }
}
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Manage Users</h1>

            <!-- Message Label -->
            <asp:Label ID="lblMessage" runat="server" CssClass="message" />

            <!-- Add User Section -->
            <div class="form-section">
                <h2>Add User</h2>
                <label for="txtUserName">Username:</label>
                <input type="text" id="txtUserName" runat="server" class="input-field" /><br />
                
                <label for="txtEmail">Email:</label>
                <input type="text" id="txtEmail" runat="server" class="input-field" /><br />
                
                <label for="txtPassword">Password:</label>
                <input type="password" id="txtPassword" runat="server" class="input-field" /><br />
                
                <label for="ddlRole">Role:</label>
                <asp:DropDownList ID="ddlRole" runat="server" class="input-field"></asp:DropDownList><br />
                
                <label for="txtIsActive">Is Active:</label>
                <input type="text" id="txtIsActive" runat="server" class="input-field" /><br />
                
                <asp:Button ID="btnAddUser" runat="server" Text="Add User" OnClick="btnAddUser_Click" CssClass="btn btn-add" />
            </div>

            <!-- Delete User Section -->
            <div class="form-section">
                <h2>Delete User</h2>
                <label for="txtDeleteUserId">User ID:</label>
                <input type="text" id="txtDeleteUserId" runat="server" class="input-field" /><br />
                <asp:Button ID="btnDeleteUser" runat="server" Text="Delete User" OnClick="btnDeleteUser_Click" CssClass="btn btn-delete" />
            </div>

            <!-- Show Users Section -->
            <div class="form-section">
                <h2>All Users</h2>
                <asp:Literal ID="litUsers" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
