using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace FoodDeliveryAPI.Models
{
    public class HashPassword
    {
        public string hashPassword(string password,string email)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {

                var salt = getSalt(password, email);
                byte[] bytes = Encoding.UTF8.GetBytes(salt);

                var key = mySHA256.ComputeHash(bytes);
                return Convert.ToBase64String(key); ;
            }
        }

        public string getSalt(string password,string email)
        {
            string firstHalf = email.Substring(0, email.Length / 2);
            string secondHalf = email.Substring(email.Length / 2);
            string saltPassword=null;
            for(int i = 0; i < password.Length; i++)
            {
                if(i==1)
                {
                    saltPassword += firstHalf;
                }
                if (i == 5)
                {
                    saltPassword += secondHalf;
                }

                saltPassword += password[i];
            }

            return saltPassword;
        }

    }
}
