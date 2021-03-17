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
        public int OrderId { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        
        [ForeignKey("Courier")]
        public int CourierId { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string DeliveryAddress { get; set; }


        public double DeliveryLat { get; set; }
        public double DeliveryLng { get; set; }


        [Column(TypeName = "nvarchar(200)")]
        public string OrderNotes { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string Stage { get; set; }


        public Client Client { get; set; }
        public Courier Courier { get; set; }
        public Restaurant Restaurant{ get; set; }
    }
}
