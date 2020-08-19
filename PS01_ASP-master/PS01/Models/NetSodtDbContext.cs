using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PS01.Models
{
    public class NetSodtDbContext : DbContext
    {
        public NetSodtDbContext() : base("DefaultConnection")
        {

        }

        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Support> Supports { get; set; }
    }
}
