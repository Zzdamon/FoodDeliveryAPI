using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Models
{
    public class OrderItems
    {  // [Key]
        public int itemId { get; set; }
       // [Key]
        public int orderId { get; set; }
    }
}
