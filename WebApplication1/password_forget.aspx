<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="password_forget.aspx.cs" Inherits="WebApplication1.Home_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link rel="stylesheet" href="style/login.css" />
    <title>Forget Password</title>
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
        <div id ="frame">
            <p>
                <asp:Label ID="lb_account" runat="server" class="label_input" Text="Account: "></asp:Label>
                <asp:TextBox ID="account" class="text_field" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lb_mail" runat="server" class="label_input" Text="E-mail: "></asp:Label>
                <asp:TextBox ID="mail" class="text_field" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lb_question" runat="server" class="label_input" Text="Question: "></asp:Label>
                <asp:DropDownList ID="ddl_question" class="text_field" runat="server" >
                    <asp:ListItem>最喜歡的Vtuber?</asp:ListItem>
                    <asp:ListItem>最親近的家人?</asp:ListItem>
                    <asp:ListItem>最喜歡看的漫畫?</asp:ListItem>
                    <asp:ListItem>你的生日?</asp:ListItem>
                    <asp:ListItem>你的國小?</asp:ListItem>
                </asp:DropDownList><br />
            </p>
            <p>
                <asp:Label ID="lb_answer" runat="server" class="label_input" Text="Answer: "></asp:Label>
                <asp:TextBox ID="Answer" class="text_field" runat="server"></asp:TextBox>
            </p>
            <div id="control">         
                <asp:Button ID="Summit" class="btn" runat="server" Text="comfirm" OnClick="Summit_Click" />
                <asp:Button ID="Reset" class="btn" runat="server" Text="reset" OnClick="Reset_Click" />
                <asp:Button ID="Back" class="btn" runat="server" Text="back" OnClick="Back_Click" />
            </div>
        </div>
    </form>
</body>
</html>
