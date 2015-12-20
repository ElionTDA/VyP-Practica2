<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GUI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        NickName:<asp:TextBox ID="NickTb" runat="server"></asp:TextBox>
        <br />
        Password:<asp:TextBox ID="PassTb" runat="server" TextMode="Password"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Logging_Button" runat="server" Text="Log In!" OnClick="Logging_Button_Click" />
        <br />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
