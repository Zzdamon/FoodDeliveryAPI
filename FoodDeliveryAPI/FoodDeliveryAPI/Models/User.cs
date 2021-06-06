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

    public class User:Auth
    {   

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        //[Column(TypeName = "nvarchar(100)")]
        //public string DefaultAddress { get; set; }


        //[Required]
        //[Column(TypeName = "nvarchar(20)")]
        //public string accountType { get; set; }


    }
}
//= new HashPassword().hashPassword(password);
//get
//{ return password; }
//set
//{ this.password = password; }