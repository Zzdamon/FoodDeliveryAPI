using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Models
{
    public class Order
    {   [Key]
        public int orderId { get; set; }

        [ForeignKey("User")]
        public int userId { get; set; }

        [ForeignKey("Restaurant")]
        public int restaurantId { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string deliveryAddress { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string orderNotes { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string stage { get; set; }


        public User User { get; set; }
        public Restaurant Restaurant{ get; set; }
    }
}
