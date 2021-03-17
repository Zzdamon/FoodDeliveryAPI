using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Models
{
    public class Auth
    {
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Email{get; set;}

        public string Password { get => password; set => password = new HashPassword().hashPassword(value, this.Email); }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        private string password;

    }
}
