using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatService.Data;
using ChatService.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace ChatService.Controllers
{
    [HubName("myHub")]
    public class MyHub : Hub
    {
        AppDbContext db = new AppDbContext();
        static List<User> ConnectedUser = new List<User>();
        public void Connect(string Name)
        {
            User user = new User
            {
                Name = Name,
                ConnectionTime = DateTime.Now.ToString(),
                ConnectionID = Context.ConnectionId
            };
            ConnectedUser.Add(user);
            db.Users.Add(user);
            db.SaveChanges();
            Clients.Others.ReceivedMessage("New User", Name);
            Clients.Caller.ReceivedMessage("Me", Name);
        }
        public void Send(string Msg)
        {
            var uid = db.Users.Where(u => u.ConnectionID == Context.ConnectionId).SingleOrDefault().ID;
            var uname = ConnectedUser.SingleOrDefault(n => n.ConnectionID == Context.ConnectionId).Name;
            Message message = new Message
            {
                Text = Msg,
                MsgTime = DateTime.Now.ToString(),
                UserID = uid
            };
            db.Messages.Add(message);
            db.SaveChanges();
            Clients.Others.ReceivedMessage(uname, Msg);
            Clients.Caller.ReceivedMessage("Me", Msg);
        }
    }
}