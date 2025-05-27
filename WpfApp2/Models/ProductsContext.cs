using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace DiscountApp.Models
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemDiscounts");
        }
    }
}

