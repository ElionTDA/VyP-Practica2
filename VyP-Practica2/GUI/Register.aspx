<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GUI.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
           <td>Nickname </td> 
            <td><asp:TextBox ID="NicknameTB" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Contraseña</td>
            <td><asp:TextBox ID="ContraseñaTB" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Nombre </td>
            <td><asp:TextBox ID="NombreTB" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Apellido 1 </td>
            <td><asp:TextBox ID="Apellido1TB" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Apellido 2 </td>
            <td><asp:TextBox ID="Apellido2TB" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Fecha de nacimiento(dd/mm/aaaa)</td>
            <td>
                <asp:TextBox ID="DiaTB" runat="server"></asp:TextBox>
                <asp:TextBox ID="MesTB" runat="server"></asp:TextBox>
                <asp:TextBox ID="AñoTB" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>

        <asp:Button ID="RegisteringButton" runat="server" Text="Register!" OnClick="RegisteringButton_Click" />

        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>

    </div>
    </form>
</body>
</html>
