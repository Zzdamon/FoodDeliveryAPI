using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Models
{
    public class Restaurants
    {   [Key]
        public int id { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string name { get; set; }

        public float minOrder { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string logo { get; set; }

        //public float lat { get; set; }
        //public float lng { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string address { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string description { get; set; }
    }
}
