<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="GUI.Usuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="LogoutBTN" runat="server" Text="Logout" OnClick="LogoutBTN_Click" />
        <br />
        <asp:Label ID="UsuarioID" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
