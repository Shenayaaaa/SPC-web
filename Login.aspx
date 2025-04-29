<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SPC_Web.Login" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Login</title>
    <style>/* Reset some basic styles */
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

/* Body styling */
body {
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    background-color: #f0f0f0; /* Light background for the page */
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
}

/* Container for the login form */
.login-container {
    background-color: #ffffff; /* White background for the form */
    border-radius: 8px;
    padding: 30px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); /* Subtle shadow */
    width: 100%;
    max-width: 400px; /* Maximum width for the form */
    text-align: center;
}

/* Heading */
.login-container h2 {
    margin-bottom: 20px;
    font-size: 24px;
    color: #333;
}

/* Styling for form controls */
.form-control {
    width: 100%;
    padding: 12px;
    margin-bottom: 15px;
    border: 1px solid #ccc;
    border-radius: 8px;
    font-size: 16px;
    background-color: #fafafa;
    transition: border-color 0.3s ease, box-shadow 0.3s ease;
}

.form-control:focus {
    border-color: #4CAF50; /* Green border on focus */
    box-shadow: 0 0 5px rgba(76, 175, 80, 0.5); /* Light green shadow */
    outline: none;
}

/* Button styling */
.btn-primary {
    width: 100%;
    padding: 14px;
    background-color: #4CAF50; /* Green button */
    color: white;
    font-size: 16px;
    border: none;
    border-radius: 8px;
    cursor: pointer;
    transition: background-color 0.3s ease, transform 0.2s ease;
}

.btn-primary:hover {
    background-color: #45a049; /* Darker green on hover */
    transform: scale(1.05); /* Slightly enlarge the button */
}

.btn-primary:active {
    background-color: #388e3c; /* Even darker green when pressed */
}

/* Register link */
.register-link {
    display: inline-block;
    margin-top: 20px;
    color: #007bff; /* Blue color for the link */
    font-size: 14px;
    text-decoration: none;
}

.register-link:hover {
    color: #0056b3; /* Darker blue on hover */
    text-decoration: underline;
}

/* Message label */
.message-label {
    display: block;
    margin-bottom: 10px;
    color: red; /* Default to error messages in red */
    font-size: 14px;
}

/* Success message styling */
.message-label.success {
    color: green; /* Green for success */
}

/* Media Queries for responsiveness */
@media (max-width: 600px) {
    .login-container {
        padding: 20px;
    }

    .form-control {
        padding: 10px;
        font-size: 14px;
    }

    .btn-primary {
        padding: 12px;
        font-size: 14px;
    }

    .register-link {
        font-size: 12px;
    }
}
</style>
</head>
<body>

    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Login</h2>
            <asp:Label ID="lblMessage" runat="server" CssClass="message-label"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email" CssClass="form-control"></asp:TextBox>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Password" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn-primary" />

            <!-- Register Link -->
            <a href="Register.aspx" class="register-link">Don't have an account? Register here</a>
        </div>
    </form>

</body>
</html>
