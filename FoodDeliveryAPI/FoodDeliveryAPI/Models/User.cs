using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Models
{


    //public enum Providers
    //{
    //    Google,
    //    Facebook,
    //    yEat
    //}

    //public Providers checkProvider(string value)
    //{
    //    if (value == "Google")
    //    {
    //        return Providers.Google;
    //    }
    //    else if (value == "Facebook")
    //    {
    //        return Providers.Facebook;
    //    }
    //    else if (value == "yEat")
    //    {
    //        return Providers.yEat;
    //    }
    //    else throw new Exception("Invalid provider");
    //}

    public class User
    {   [Key]
        public int userId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string accountType { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string defaultAddress { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string email { get; set; }

        public string Password { get => password; set => password = new HashPassword().hashPassword(value, this.email ); }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        private string password;

    }
}
//= new HashPassword().hashPassword(password);
//get
//{ return password; }
//set
//{ this.password = password; }