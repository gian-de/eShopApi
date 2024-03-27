using System;
using eShopApi.Entities;
using Microsoft.EntityFrameworkCore;


namespace eShopApi.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
            .HasOne(p => p.Tenant)
            .WithMany(t => t.Products)
            .HasForeignKey(p => p.TenantId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tenant>()
                .HasMany(t => t.Products)
                .WithOne(p => p.Tenant)
                .HasForeignKey(p => p.TenantId)
                .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<Product>()
            // .HasMany(p => p.ProductVariants)
            // .WithOne(pv => pv.Product)
            // .HasForeignKey(pv => pv.ProductId)
            // .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<ProductVariant>()
            //     .HasMany(pv => pv.ProductImages)
            //     .WithOne(pi => pi.ProductVariant)
            //     .HasForeignKey(pv => pv.ProductVariantId)
            //     .OnDelete(DeleteBehavior.Cascade);

            // renameing tables to lowercase or snake_case
            modelBuilder.Entity<Tenant>().ToTable("tenant");
            modelBuilder.Entity<Product>().ToTable("product");
            modelBuilder.Entity<ProductVariant>().ToTable("product_variant");
            modelBuilder.Entity<ProductImage>().ToTable("product_images");
        }
    }
}