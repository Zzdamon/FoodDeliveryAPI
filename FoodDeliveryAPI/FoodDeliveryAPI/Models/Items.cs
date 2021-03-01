using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Models
{
    public class Items
    {   [Key]
        public int itemId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string description { get; set; }

        public float price { get; set; }

        [ForeignKey("Category")]
        public int categId { get; set; }
        public Categories Category { get; set; }
    }
}
