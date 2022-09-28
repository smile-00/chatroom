<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_page.aspx.cs" Inherits="WebApplication1.User_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link rel="stylesheet" href="style/style_user.css" />
     <title>User</title>
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
            <div id="wrapper">
                <p id="home" class="panel intro">
                    <asp:Image ID="Image1" runat="server" ImageUrl="sample.jpg" Width="100" Height="100"/>  
                    <asp:Label ID="lb_id" runat="server" class="label_show" Text="ID: "></asp:Label>
                    <asp:Label ID="id" runat="server" Text=""></asp:Label>
                </p>
                <p>
                    <asp:Label ID="lb_hobby" runat="server" class="label_show" Text="Hobby: "></asp:Label>
                    <asp:Label ID="hobby" runat="server" Text=""></asp:Label>
                </p>
                <div id="pair" class="panel">
                    <p>
                        <asp:Label ID="lb_pair" runat="server" class="label_btn" Text="Recommend"></asp:Label>
                        <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                    </p>
                    <p>
                        <asp:Label ID="lb_friend" runat="server" class="label_btn" Text="Friends"></asp:Label>
                        <asp:Panel ID="Panel2" runat="server"></asp:Panel>
                    </p>
                </div>
                <%--<table><tr><th><asp:Button ID="pair1" class="btn" runat="server" Text="test123" OnClick="Pair_Click" /></th></tr></table>--%>
                <div id="footer">
                    <asp:Button ID="logout" class="btn" runat="server" Text="Logout" OnClick="logout_Click" />
                </div>
            </div>
        </form>
    </body>
</html>
