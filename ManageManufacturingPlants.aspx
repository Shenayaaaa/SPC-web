<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageManufacturingPlants.aspx.cs" Inherits="SPC_Web.ManageManufacturingPlants" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Manage Manufacturing Plants</title>
    <style>/* General Body Styling */
body {
    font-family: 'Arial', sans-serif;
    background-color: #f4f7fa;
    margin: 0;
    padding: 0;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    height: 100vh;
}

/* Header Styling */
h2 {
    font-size: 2.5rem;
    color: #333;
    text-align: center;
    margin-bottom: 20px;
}

/* Form Section Styling */
form {
    width: 80%;
    max-width: 1000px;
    background-color: white;
    border-radius: 8px;
    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
    padding: 30px;
    margin-top: 900px;
}

/* Section Titles */
h3 {
    font-size: 1.5rem;
    color: #2c3e50;
    margin-top: 20px;
    margin-bottom: 10px;
}

/* Label Styling */
label {
    font-size: 1rem;
    color: #555;
    margin-bottom: 8px;
    display: block;
}

/* Input Fields */
input[type="text"] {
    width: 100%;
    padding: 10px;
    margin-bottom: 15px;
    border: 1px solid #ccc;
    border-radius: 5px;
    font-size: 1rem;
    background-color: #f9f9f9;
    transition: border-color 0.3s ease, box-shadow 0.3s ease;
}

input[type="text"]:focus {
    border-color: #3498db;
    box-shadow: 0 0 8px rgba(52, 152, 219, 0.2);
    outline: none;
}

/* Buttons */
button {
    padding: 12px 20px;
    font-size: 1rem;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    transition: background-color 0.3s ease, transform 0.2s ease;
    margin-top: 10px;
}

button[type="button"]:hover {
    transform: scale(1.05);
}

button[type="button"].add-plant {
    background-color: #3498db;
    color: white;
}

button[type="button"].edit-plant {
    background-color: #f39c12;
    color: white;
}

button[type="button"].delete-plant {
    background-color: #e74c3c;
    color: white;
}

/* Message Display */
label[for="lblMessage"] {
    font-size: 1rem;
    color: #e74c3c;
    display: block;
    margin-bottom: 20px;
}

label[for="lblMessage"].success {
    color: #2ecc71;
}

/* Display All Manufacturing Plants Section */
pre {
    font-size: 1rem;
    background-color: #ecf0f1;
    padding: 20px;
    border-radius: 5px;
    overflow-x: auto;
    color: #2c3e50;
    margin-top: 20px;
}

/* Card Layout for Adding, Editing, and Deleting Plants */
section {
    background-color: #fff;
    border-radius: 8px;
    box-shadow: 0 2px 6px rgba(0, 0, 0, 0.1);
    padding: 20px;
    margin-bottom: 20px;
}

/* Responsive Design */
@media (max-width: 768px) {
    form {
        width: 95%;
        padding: 15px;
    }

    h2 {
        font-size: 2rem;
    }

    input[type="text"] {
        font-size: 0.9rem;
        padding: 8px;
    }

    button {
        width: 100%;
    }
}
</style>
</head>
<body>

    <form runat="server">
        <h2>Manage Manufacturing Plants</h2>

        <!-- Displaying messages -->
        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" /><br />

        <!-- Add Manufacturing Plant Section -->
        <h3>Add Manufacturing Plant</h3>
        <label for="txtPlantName">Plant Name:</label><br />
        <input type="text" id="txtPlantName" runat="server" /><br />

        <label for="txtLocation">Location:</label><br />
        <input type="text" id="txtLocation" runat="server" /><br />

        <label for="txtContactName">Contact Name:</label><br />
        <input type="text" id="txtContactName" runat="server" /><br />

        <label for="txtPhoneNumber">Phone Number:</label><br />
        <input type="text" id="txtPhoneNumber" runat="server" /><br />

        <button type="button" runat="server" OnClick="AddManufacturingPlant_Click">Add Plant</button>

        <!-- Edit Manufacturing Plant Section -->
        <h3>Edit Manufacturing Plant</h3>
        <label for="txtEditPlantId">Plant ID:</label><br />
        <input type="text" id="txtEditPlantId" runat="server" /><br />

        <label for="txtEditPlantName">Plant Name:</label><br />
        <input type="text" id="txtEditPlantName" runat="server" /><br />

        <label for="txtEditLocation">Location:</label><br />
        <input type="text" id="txtEditLocation" runat="server" /><br />

        <label for="txtEditContactName">Contact Name:</label><br />
        <input type="text" id="txtEditContactName" runat="server" /><br />

        <label for="txtEditPhoneNumber">Phone Number:</label><br />
        <input type="text" id="txtEditPhoneNumber" runat="server" /><br />

        <button type="button" runat="server" OnClick="EditManufacturingPlant_Click">Edit Plant</button>

        <!-- Delete Manufacturing Plant Section -->
        <h3>Delete Manufacturing Plant</h3>
        <label for="txtDeletePlantId">Plant ID:</label><br />
        <input type="text" id="txtDeletePlantId" runat="server" /><br />
        <button type="button" runat="server" OnClick="DeleteManufacturingPlant_Click">Delete Plant</button>

        <!-- Display all Manufacturing Plants -->
        <h3>All Manufacturing Plants</h3>
        <pre runat="server" id="litManufacturingPlants"></pre>
    </form>

</body>  
</html>

