using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class RestaurantDataContext : DbContext
    {
        public RestaurantDataContext(DbContextOptions<RestaurantDataContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customer { get; set; }

        public DbSet<FoodItem> FoodItem { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}
 