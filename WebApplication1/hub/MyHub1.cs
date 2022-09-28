using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

public class ChatHub : Hub
{
    //宣告靜態類別，儲存user清單
    public static class Users
    {
        public static Dictionary<string, string> ConnectionIds = new Dictionary<string, string>();
        public static Dictionary<string, string> id = new Dictionary<string, string>();
        public static string sender = "";
    }


    //Dictionary<string, string> ConnectionIds = new Dictionary<string, string>();

    //傳送訊息給所有User
    public void Send(string message)
    {
        var user = Users.ConnectionIds.Where(u => u.Key == Context.ConnectionId).FirstOrDefault();
        Clients.All.show(user.Value + "： " + message);
    }

    //傳送訊息給某人
    public void SendOne(string reciver, string message)
    {
        var from = Users.ConnectionIds.Where(u => u.Key == Context.ConnectionId).FirstOrDefault();
        //message = HttpUtility.HtmlEncode(message);
        //var fromName = UserHandler.ConnectedIds.Where(p => p.Key == Context.ConnectionId).FirstOrDefault().Value;
        //message = fromName + " <span style='color:red'>悄悄的對你說</span>：" + message;
        //Clients.Client(ToId).sendMessage(message);
        //var to = Users.ConnectionIds.Where(u => u.Key == id).FirstOrDefault();
        //Clients.Client(me).show("<span>" + from.Value + ": " + message + "</span>");
        if (Users.id.ContainsKey(reciver))
        {
            Clients.Client(Users.id[reciver]).show("<span>" + message + "</span>");
        }
        else
        {
            Clients.Client(Users.id[from.Value]).show("<span>此用戶未上線!</span>");
        }
    }

    //新使用者連線進入聊天室
    public void userConnected(string name)
    {
        Users.sender = name;
        //將目前使用者新增至user清單
        if(!Users.ConnectionIds.ContainsKey(Context.ConnectionId))
        {
            Users.ConnectionIds.Add(Context.ConnectionId, name);
        }
        //Context.ConnectionId
        if(!Users.id.ContainsKey(name))
        {
            Users.id.Add(name, Context.ConnectionId);
        }
        //發送給所有人，取得user清單
        Clients.All.getList(Users.ConnectionIds.Select(u => new { id = u.Key, name = u.Value }).ToList());

        //通知其他人，有新使用者
        //Clients.Others.show("歡迎" + name + "進入聊天室");
    }

    //當使用者斷線時呼叫
    //stopCalled是SignalR 2.1.0版新增的參數
    public override Task OnDisconnected(bool stopCalled)
    {
        Clients.Others.removeList(Context.ConnectionId);
        Users.ConnectionIds.Remove(Context.ConnectionId);
        Users.id.Remove(Users.sender);
        return base.OnDisconnected(stopCalled);
    }
}