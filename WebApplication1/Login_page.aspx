<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_page.aspx.cs" Inherits="Web.Login_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link rel="stylesheet" href="style/login.css" />
</head>
<body>
    <div class="wrap">
        <ul class="circles">
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
        </ul>
    </div>
    <form id="form1" runat="server">
        <div id="frame">
            <h1>-Login-</h1>
            <p>
                <asp:Label ID="lb_account" runat="server" class="label_input" Text="Account: "></asp:Label>
                <asp:TextBox ID="Account" class="text_field" runat="server" Text=""></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lb_password" runat="server" class="label_input" Text="Password: "></asp:Label>
                <asp:TextBox ID="Password" class="text_field" runat="server" Text=""></asp:TextBox>
            </p>
            <div id="control">            
                <asp:Button ID="btn_login" class="btn" runat="server" Text="Login" OnClick="login_Click" /> 
                <a class="pwd" href="Register.aspx">Register</a>
                <a class="pwd" href="password_forget.aspx">Forget Password</a>
            </div>
        </div>
    </form>
</body>
</html>

