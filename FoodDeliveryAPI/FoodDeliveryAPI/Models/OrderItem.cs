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
       // [Key]
        public int OrderId { get; set; }
    }
}
