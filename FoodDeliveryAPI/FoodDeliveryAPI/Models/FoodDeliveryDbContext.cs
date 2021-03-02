using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Models
{
    public class FoodDeliveryDbContext:DbContext
    {
        public FoodDeliveryDbContext(DbContextOptions<FoodDeliveryDbContext> options):base(options) 
        {
            
        }

        public DbSet<Restaurant>Restaurants{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Item> Items{ get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<OrderItem> OrderItems{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RestaurantTag>()
        .HasKey(t => new { t.RestaurantId, t.TagId });

            builder.Entity<RestaurantTag>()
                .HasOne(rt => rt.restaurant)
                .WithMany(p => p.RestaurantTags)
                .HasForeignKey(pt => pt.RestaurantId);

            builder.Entity<RestaurantTag>()
                .HasOne(rt => rt.Tag)
                .WithMany(t => t.RestaurantTags)
                .HasForeignKey(pt => pt.TagId);

            builder.Entity<User>()
            .HasIndex(u => u.email)
            .IsUnique();

            builder.Entity<OrderItem>().HasKey(table => new { table.itemId, table.orderId });
        }

    }
}
