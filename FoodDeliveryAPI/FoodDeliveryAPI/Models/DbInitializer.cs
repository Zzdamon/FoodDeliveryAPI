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
            if (context.Restaurants.Any() || context.Categories.Any() || context.Items.Any() || context.Tag.Any() || context.RestaurantTag.Any())
            {
                return;   // DB has been seeded
            }

            var restaurants = new Restaurant[]
            {
                new Restaurant{Name="KFC", MinOrder=25,Logo="https://i.imgur.com/DWJWbwa.png",
                    Address="Bulevardul Alexandru Lăpușneanu 116C, Constanța 900419",
                    Description="fast food",
                    },

                 new Restaurant{Name="McDonald's", MinOrder=20,Logo="https://i.imgur.com/Lk9Fexu.png",
                    Address="Bulevardul Mamaia 255, Constanța 300417",
                    Description="fast food",
                    },

                  new Restaurant{Name="Domino's Pizza", MinOrder=20,Logo="https://i.imgur.com/Lk9Fexu.png",
                    Address="Strada Ion Luca Caragiale nr. 4, Constanța 900211",
                    Description="pizza",
                    }
            };
            foreach (Restaurant s in restaurants)
            {
                context.Restaurants.Add(s);
            }
            context.SaveChanges();

            var categories = new Category[]
            {
                new Category
                {
                    Name="Buckets",
                    RestaurantId=1
                },

                new Category
                {
                    Name="Burgers",
                    RestaurantId=1
                },

                new Category
                {
                    Name="Pizza",
                    RestaurantId=3
                },

                new Category
                {
                    Name="Pasta",
                    RestaurantId=3
                },

                new Category
                {
                    Name="Premium Menus",
                    RestaurantId=2
                },

                new Category
                {
                    Name="Classic Menus",
                    RestaurantId=2
                },

            };
            foreach (Category s in categories)
            {
                context.Categories.Add(s);
            }
            context.SaveChanges();

            var items = new Item[]
            {
                new Item
                {
                    Name="Giant Bucket",
                    Price=80,
                    Description="bucket for 5 people",
                    CategId=1
                },

                 new Item
                {
                    Name="Booster",
                    Description="chicken burger",
                    Price=20.5F,
                    CategId=2
                },
                  new Item
                {
                    Name="Pizza Domino's Special",
                    Description="tomato sauce, salami, cheese",
                    Price=32,
                    CategId=3
                },

                  new Item
                {
                    Name="Carbonara Pasta",
                    Description="pasta with cheese and bacon",
                    Price=24.5F,
                    CategId=4
                },
                  new Item
                {
                    Name="Royal Deluxe Menu",
                    Description="Big tasty burger, large fries, cola/fanta/sprite",
                    Price=21,
                    CategId=5
                },
                  new Item
                {
                    Name="McChicken Menu",
                    Description="McChicken burger, fries, cola/fanta/sprite",
                    Price=17.9F,
                    CategId=6
                },
            };
            foreach (Item s in items)
            {
                context.Items.Add(s);
            }
            context.SaveChanges();


            var tags = new Tag[]
            {
                new Tag
                {   TagId="pizza",
                    Banner="https://i.imgur.com/7hm6AZ6.png",
                    Description="Best pizza made by italian chefs"
                },
                new Tag
                {
                    TagId="burgers",
                    Banner="https://i.imgur.com/LhG3CIk.jpg",
                    Description="Best american burgers"
                },
                  new Tag
                {
                    TagId="fast food",
                    Banner="https://i.imgur.com/h1SGcqq.jpg",
                    Description="Fast food for when you're in a hurry"
                }
            };
            foreach (Tag s in tags)
            {
                context.Tag.Add(s);
            }
            context.SaveChanges();


            var restTags = new RestaurantTag[]
             {
               new RestaurantTag
               {
                   RestaurantId=1,
                   TagId="burgers"
               },
             new RestaurantTag
               {
                   RestaurantId=2,
                   TagId="burgers"
               },
             new RestaurantTag
               {
                   RestaurantId=2,
                   TagId="fast food"
               },
             new RestaurantTag
               {
                   RestaurantId=3,
                   TagId="pizza"
               },
             };
            foreach (RestaurantTag s in restTags)
            {
                context.RestaurantTag.Add(s);
            }
            context.SaveChanges();
        }
    }
}




//context.Tags.Where(tag => tag.description =="Best american burgers" ).FirstOrDefault().tagId
//context.Tags.Where(tag => tag.description =="Fast food for when you're in a hurry" ).FirstOrDefault().tagId
//=context.Tags.Where(tag => tag.description =="Best pizza made by italian chefs" ).FirstOrDefault().tagId