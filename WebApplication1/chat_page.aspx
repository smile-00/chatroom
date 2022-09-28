<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chat_page.aspx.cs" Inherits="WebApplication1.chat_page" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Chat Room</title>
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/jquery.signalR-2.2.2.min.js"></script>
    <script src="signalR/hubs"></script>
    <link rel="stylesheet" href="style/style_chat.css" />
</head>
<body>
    <script>
        var chat = $.connection.chatHub;//chatHub小寫
        var name = "";
        var reciver = '<%=Session["reciver"]%>';

        //初始
        $(function () {
            //var account
            var account = '<%=Session["account"]%>';
            $('#talkTo').html(reciver);
            $('#lblTalkToWho').html(account);
            name = account;
        });

        //signalR啟動完成後，要執行的動作
        $.connection.hub.start().done(function () {

            //通知Server，有新使用者連進來
            chat.server.userConnected(name);

            //按傳送鈕
            $('#btnSend').click(function () {
                send();
            });
            //按Enter鍵
            $('#txtMsg').keydown(function (e) {
                if (e.which == 13) {
                    send();
                }
            });
            
        });

        //顯示訊息
        chat.client.show = function (message) {
            //<div class="chatOdd"><img src="girl.jpg"><div class="triAngleToLeft"></div><div class="textRight">我沒有哭，只是剛好眼淚流出了眼眶</div></div>
            $('#chatRoom').append('<div class="chatOdd"><img src="sample.jpg"><div class="triAngleToLeft"></div><div class="textRight">' + message + '</div></div>');
            
        };
       

        //使用者離開
        chat.client.removeList = function (id) {
            $('#' + id).remove();
        };

        //傳送聊天內容至Server
        function send() {
            //<div class="chatEven"><img src="boy.png"><div class="triAngleToRight"></div><div class="textLeft" id="text1"></div></div>
            $('#chatRoom').append('<div class="chatEven"><img src="sample.jpg"><div class="triAngleToRight"></div><div class="textLeft">' + $('#txtMsg').val()+'</div></div>');
            chat.server.sendOne(reciver, $('#txtMsg').val());

            $('#txtMsg').val('');
        }
    </script>

    <div>
        <div id="chat">
            <p id="talkTo"></p>
            <ul id="chatRoom"></ul>
        </div>
        <div id="user" hidden="">
            <p>使用者列表</p>
            <ul id="lstUser">
            </ul>
        </div>
    </div>
    <div>
        <label id="lblTalkToWho"></label>
        <input id="txtMsg" type="text" />
        <input id="btnSend" type="button" value="send" />
    </div>


</body>
</html>