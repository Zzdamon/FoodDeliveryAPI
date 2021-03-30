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

        public Task JoinRoom(string roomName, int userId)
        {
            if (!HubUser.hubUsers.TryAdd(userId, Context.ConnectionId))
                HubUser.hubUsers[userId] = Context.ConnectionId;


            return Groups.AddToGroupAsync(Context.ConnectionId, roomName);

        }

        public Task LeaveRoom(string roomName)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }

        public Task AddOrder(Order order)
        {
            return Clients.Group(COURIER_GROUP).SendAsync("NewOrder", order);
            //Context.ConnectionId

        }

        public async Task TakeOrder(Order order)
        {
            await Clients.OthersInGroup(COURIER_GROUP).SendAsync("ExpiredOrder", order);

            await Clients.Client(HubUser.hubUsers.GetValueOrDefault(order.ClientId, "notFound")).SendAsync("UpdatedOrder", order);

        }
        public async Task SendLocation(string lat, string lng, int userId)
        {
            await Clients.Client(HubUser.hubUsers.GetValueOrDefault(userId, "notFound")).SendAsync("UpdatedLocation", lat, lng);

        }


    }





}




//readonly static String COURIER_GROUP = "couriers";
//readonly static String CLIENT_GROUP = "clients";

//public Task JoinRoom(string roomName)
//{
//    return Groups.AddToGroupAsync(Context.ConnectionId, roomName);

//}

//public Task LeaveRoom(string roomName)
//{
//    return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
//}

//public Task AddOrder(Order order)
//{
//    return Clients.Group(COURIER_GROUP).SendAsync("NewOrder", order, Context.ConnectionId);

//}

//public async Task TakeOrder(Order order, string clientConnectionId)
//{
//    await Clients.OthersInGroup(COURIER_GROUP).SendAsync("ExpiredOrder", order);
//    await Clients.Client(clientConnectionId).SendAsync("UpdatedOrder", order, "Courier", Context.ConnectionId);

//}
//public async Task SendLocation(string lat, string lng, string clientConnectionId)
//{
//    await Clients.Client(clientConnectionId).SendAsync("UpdatedLocation", lat, lng);

//}