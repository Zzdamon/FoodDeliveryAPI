using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Models
{
    public class DbInitializer
    {
        public async static void Initialize(FoodDeliveryDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any data.
            if (context.Restaurants.Any() || context.Categories.Any() || context.Items.Any() || context.Tag.Any() || context.RestaurantTag.Any() || context.Clients.Any() || context.Couriers.Any() )
            {
                return;   // DB has been seeded
            }

            var client = new Client
            {
                Email = "damon@gmail.com",
                Password = "123456",
                LastName = "Lepirda",
                FirstName = "Damon"
            };

            await context.Clients.AddAsync(client);
            context.SaveChanges();


            var courier = new Courier
            {
                Email = "gabi@gmail.com",
                Password = "123456",
                LastName = "Lepirda",
                FirstName = "Gabriel"
            };
            
            await context.Couriers.AddAsync(courier);
            context.SaveChanges();


            var restaurants = new Restaurant[]
            {
                new Restaurant{Name="KFC", MinOrder=25,Logo="https://i.imgur.com/DWJWbwa.png",
                    Address="Bulevardul Alexandru Lăpușneanu 116C, Constanța 900419",
                    Description="Kentucky Fried Chicken, following the colonel's classic recipe",
                    RestaurantLat= 44.20326811524546 ,
                    RestaurantLng=28.630486542562647
                    },

                 new Restaurant{Name="McDonald's", MinOrder=20,Logo="https://i.imgur.com/Lk9Fexu.png",
                    Address="Bulevardul Mamaia 255, Constanța 300417",
                    Description="That's so good!",
                     RestaurantLat= 44.20578790563886,
                    RestaurantLng=28.64278571187222

                    },

                  new Restaurant{Name="Domino's Pizza", MinOrder=20,Logo="https://i.imgur.com/AEixqGw.png",
                    Address="Strada Ion Luca Caragiale nr. 4, Constanța 900211",
                    Description="Best pizza in town!",
                    RestaurantLat= 44.17645560439799,
                    RestaurantLng=28.62225421187142

                    }
            };
            foreach (Restaurant s in restaurants)
            {
               await context.Restaurants.AddAsync(s);
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
               await context.Categories.AddAsync(s);
            }
            context.SaveChanges();

            var items = new Item[]
            {
                new Item
                {
                    Name="Giant Bucket",
                    Price=80,
                    Description="bucket for 5 people",
                    CategId=3
                },
                new Item
                {
                    Name="Trio Bucket",
                    Price=55,
                    Description="bucket for 3 people with fries",
                    CategId=3
                },
                  new Item
                {
                    Name="Duo Bucket",
                    Price=45,
                    Description="bucket for 2 people with small fries",
                    CategId=3
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
                    CategId=1
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
                await context.Items.AddAsync(s);
            }
            context.SaveChanges();


            var tags = new Tag[]
            {
                new Tag
                {   TagId="Pizza",
                    Banner="https://i.imgur.com/7hm6AZ6.png",
                    Description="Best pizza made by italian chefs"
                },
                new Tag
                {
                    TagId="Burgers",
                    Banner="https://i.imgur.com/LhG3CIk.jpg",
                    Description="Best american burgers"
                },
                  new Tag
                {
                    TagId="Fast Food",
                    Banner="https://i.imgur.com/kg4yPC0.jpg?1",
                    Description="Fast food for when you're in a hurry"
                },
                     new Tag
                {
                    TagId="Pasta",
                    Banner="https://i.imgur.com/5XVD7Sg.jpg?1",
                    Description="Great pasta to lighten your day"
                }
            };
            foreach (Tag s in tags)
            {
                await context.Tag.AddAsync(s);
            }
            context.SaveChanges();


            var restTags = new RestaurantTag[]
             {
               new RestaurantTag
               {
                   RestaurantId=1,
                   TagId="Burgers"
               },
             new RestaurantTag
               {
                   RestaurantId=2,
                   TagId="Burgers"
               },
             new RestaurantTag
               {
                   RestaurantId=2,
                   TagId="Fast Food"
               },
             new RestaurantTag
               {
                   RestaurantId=3,
                   TagId="Pizza"
               },
             new RestaurantTag
               {
                   RestaurantId=3,
                   TagId="Pasta"
               }
             };
            foreach (RestaurantTag s in restTags)
            {
                await context.RestaurantTag.AddAsync(s);
            }
            context.SaveChanges();
        }
    }
}




//context.Tags.Where(tag => tag.description =="Best american burgers" ).FirstOrDefault().tagId
//context.Tags.Where(tag => tag.description =="Fast food for when you're in a hurry" ).FirstOrDefault().tagId
//=context.Tags.Where(tag => tag.description =="Best pizza made by italian chefs" ).FirstOrDefault().tagId