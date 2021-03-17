using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Models
{
    public class Restaurant
    {   [Key]
        public int Id { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string Name { get; set; }

        public float MinOrder { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Logo { get; set; }

        //public float lat { get; set; }
        //public float lng { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }

        public double RestaurantLat { get; set; }
        public double RestaurantLng { get; set; }

        public List<RestaurantTag> RestaurantTags { get; set; }

    }
}
