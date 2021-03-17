using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryAPI.Models;

namespace FoodDeliveryAPI.Models
{
    public class FoodDeliveryDbContext:DbContext
    {
        public FoodDeliveryDbContext(DbContextOptions<FoodDeliveryDbContext> options):base(options) 
        {
            
        }

        public DbSet<Restaurant>Restaurants{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients{ get; set; }
        public DbSet<Courier> Couriers{ get; set; }
        public DbSet<Item> Items{ get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<OrderItem> OrderItems{ get; set; }

        public DbSet<FoodDeliveryAPI.Models.Tag> Tag { get; set; }

        public DbSet<FoodDeliveryAPI.Models.RestaurantTag> RestaurantTag { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RestaurantTag>()
        .HasKey(t => new { t.RestaurantId, t.TagId });

            builder.Entity<RestaurantTag>()
                .HasOne(rt => rt.Restaurant)
                .WithMany(p => p.RestaurantTags)
                .HasForeignKey(pt => pt.RestaurantId);

            builder.Entity<RestaurantTag>()
                .HasOne(rt => rt.Tag)
                .WithMany(t => t.RestaurantTags)
                .HasForeignKey(pt => pt.TagId);

            builder.Entity<Client>()
            .HasIndex(u => u.Email)
            .IsUnique();


            builder.Entity<Courier>()
            .HasIndex(u => u.Email)
            .IsUnique();

            builder.Entity<OrderItem>().HasKey(table => new { table.ItemId, table.OrderId });
        }

   

    }
}
