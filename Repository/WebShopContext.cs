using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class WebShopContext: DbContext
    {
        public WebShopContext():base("WebShop")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(pr => pr.Id).Property(pr => pr.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Product>().Property(pr => pr.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Product>().Property(pr => pr.Description).HasMaxLength(150);
            modelBuilder.Entity<Product>().Property(pr => pr.Category).HasMaxLength(20);
            modelBuilder.Entity<Product>().Property(pr => pr.Price).HasPrecision(30, 4);

            modelBuilder.Entity<Product>().Property(pr => pr.Producer).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Product>().Property(pr => pr.Supplier).HasMaxLength(50).IsRequired();




        }
        public virtual DbSet<Product> Products { get; set; }
      

      
    }
}
