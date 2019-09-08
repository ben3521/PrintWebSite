using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrintWebSite.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintWebSite.Data
{
    public class PrintWebSiteDbContext : IdentityDbContext<PrintWebUser>
    {
        public PrintWebSiteDbContext(DbContextOptions<PrintWebSiteDbContext> contextOptions)
            : base(contextOptions)
        {
        }
        public PrintWebSiteDbContext()
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        //public DbSet<Comment> Comments { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderHistory> OrderHistories { get; set; }
    }
}
