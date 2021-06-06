using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Models
{
    public class OrderItem
    {  // [Key]

        public int ItemId { get; set; }
        //[ForeignKey("ItemId")]
        public Item Item { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        //[ForeignKey("OrderId")]
        //public Order Order { get; set; }
    }
}
