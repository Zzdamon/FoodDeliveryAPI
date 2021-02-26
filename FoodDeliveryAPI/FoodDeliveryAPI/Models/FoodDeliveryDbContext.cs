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

        public DbSet<Restaurants>Restaurants{ get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Users> Users{ get; set; }
        public DbSet<Items> Items{ get; set; }
        public DbSet<Orders> Orders{ get; set; }
        public DbSet<OrderItems> OrderItems{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Users>()
            .HasIndex(u => u.email)
            .IsUnique();

            builder.Entity<OrderItems>().HasKey(table => new { table.itemId, table.orderId });
        }

    }
}
