using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Models
{
    public class Tag
    {
        [Key]
        public string tagId { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string description { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string banner { get; set; }

        public List<RestaurantTag> RestaurantTags { get; set; }

    }
}
