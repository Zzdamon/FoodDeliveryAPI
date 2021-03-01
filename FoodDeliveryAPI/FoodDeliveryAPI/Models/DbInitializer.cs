using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Models
{
    public class DbInitializer
    {
        public static void Initialize(FoodDeliveryDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Restaurants.Any())
            {
                return;   // DB has been seeded
            }

            var restaurants = new Restaurants[]
            {
                new Restaurants{name="KFC", minOrder=25,logo="https://i.imgur.com/DWJWbwa.png",
                    address="Bulevardul Alexandru Lăpușneanu 116C, Constanța 900419",
                    description="fast food"},

                 new Restaurants{name="McDonald's", minOrder=20,logo="https://i.imgur.com/Lk9Fexu.png",
                    address="Bulevardul Mamaia 255, Constanța 300417",
                    description="fast food"},

                  new Restaurants{name="Domino's Pizza", minOrder=20,logo="https://i.imgur.com/Lk9Fexu.png",
                    address="Strada Ion Luca Caragiale nr. 4, Constanța 900211",
                    description="pizza"}
            };
            foreach (Restaurants s in restaurants)
            {
                context.Restaurants.Add(s);
            }
            context.SaveChanges();

            var categories = new Categories[]
            {
                new Categories
                {
                    name="Buckets",
                    restaurantId=1
                },

                new Categories
                {
                    name="Burgers",
                    restaurantId=1
                },

                new Categories
                {
                    name="Pizza",
                    restaurantId=3
                },

                new Categories
                {
                    name="Pasta",
                    restaurantId=3
                },

                new Categories
                {
                    name="Premium Menus",
                    restaurantId=2
                },

                new Categories
                {
                    name="Classic Menus",
                    restaurantId=2
                },

            };
            foreach (Categories s in categories)
            {
                context.Categories.Add(s);
            }
            context.SaveChanges();

            var items = new Items[]
            {
                new Items
                {
                    name="Giant Bucket",
                    price=80,
                    description="bucket for 5 people",
                    categId=1
                },

                 new Items
                {
                    name="Booster",
                    description="chicken burger",
                    price=20.5F,
                    categId=2
                },
                  new Items
                {
                    name="Pizza Domino's Special",
                    description="tomato sauce, salami, cheese",
                    price=32,
                    categId=3
                },

                  new Items
                {
                    name="Carbonara Pasta",
                    description="pasta with cheese and bacon",
                    price=24.5F,
                    categId=4
                },
                  new Items
                {
                    name="Royal Deluxe Menu",
                    description="Big tasty burger, large fries, cola/fanta/sprite",
                    price=21,
                    categId=5
                },
                  new Items
                {
                    name="McChicken Menu",
                    description="McChicken burger, fries, cola/fanta/sprite",
                    price=17.9F,
                    categId=6
                },
            };
            foreach (Items s in items)
            {
                context.Items.Add(s);
            }
            context.SaveChanges();

        }


    }
}
    