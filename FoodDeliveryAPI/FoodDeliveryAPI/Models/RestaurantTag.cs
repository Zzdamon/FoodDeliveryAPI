using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Models
{
    public class RestaurantTag
    {
        public int RestaurantId { get; set; }
        public Restaurant restaurant { get; set; }

        public string TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
