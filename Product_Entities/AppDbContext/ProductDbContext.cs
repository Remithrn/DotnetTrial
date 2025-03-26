using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Product_Entities.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Entities.AppDbContext
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }
        public DbSet<ProductEntity> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>()
                .Property(p => p.Price)
                .HasPrecision(18, 2)
                .IsRequired();
        }
    }
}
