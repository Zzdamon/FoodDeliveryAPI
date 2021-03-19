using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Models
{   
    public class OrdersHub:Hub
    {
        readonly static String COURIER_GROUP = "couriers";
        readonly static String CLIENT_GROUP = "clients";
        public Task JoinRoom(string roomName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            
        }

        public Task LeaveRoom(string roomName)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }

        public Task AddOrder(Order order)
        {
            return Clients.Group(COURIER_GROUP).SendAsync("NewOrder",order);

        }
    }
}
