<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Web.register_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Register</title>
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
            <h1>-Register-</h1>
            <p>
                <asp:Label ID="lb_name" runat="server" class="label_input" Text="Name: "></asp:Label>
                <asp:TextBox ID="Name" class="text_field" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lb_account" runat="server" class="label_input" Text="Account: "></asp:Label>
                <asp:TextBox ID="Account" class="text_field" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lb_password" runat="server" class="label_input" Text="Password: "></asp:Label>
                <asp:TextBox ID="Password" class="text_field" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lb_com_password" runat="server" class="label_input" Text="Confirm Password: "></asp:Label>
                <asp:TextBox ID="Comfirm_Password" class="text_field" runat="server" ></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lb_hobby" runat="server" class="label_input" Text="Hobby: "></asp:Label>
                <asp:DropDownList ID="Hobby" class="text_field" runat="server" >
                    <asp:ListItem>運動</asp:ListItem>
                    <asp:ListItem>音樂</asp:ListItem>
                    <asp:ListItem>電影</asp:ListItem>
                    <asp:ListItem>讀書</asp:ListItem>
                    <asp:ListItem>旅遊</asp:ListItem>
                </asp:DropDownList>
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
                <asp:Button ID="Reset" class="btn" runat="server" Text="reset" OnClick="Reset_Click" />                
                <asp:Button ID="Summit" class="btn" runat="server" Text="comfirm" OnClick="Summit_Click" />
                <asp:Button ID="Back" class="btn" runat="server" Text="back" OnClick="Back_Click" />
            </div>
        </div>
    </form>
</body>
</html>
