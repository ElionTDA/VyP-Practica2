<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GUI.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Literal ID="Bienvenida" runat="server"></asp:Literal>
        <h1>Welcome to U-Dental</h1>
        <p>
            You may
            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="Login_Button" />
&nbsp;or
            <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="Register_Button" />
        </p>
    
    </div>
    </form>
</body>
</html>
