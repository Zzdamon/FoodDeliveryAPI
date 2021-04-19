using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Models
{
    public static class HubUser
    {
        public static Dictionary<int, string> hubClients = new Dictionary<int, string>();
        public static Dictionary<int, string> hubCouriers = new Dictionary<int, string>();

    }
}
