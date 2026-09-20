using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;

namespace Project.DAL.Entities.Data
{
    public class BloomyShopDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bouquet> Bouquets { get; set; }
        public DbSet<BouquetSize> BouquetSizes { get; set; }
        public DbSet<Flower> Flowers { get; set; }
        public DbSet<FlowerColor> FlowerColors { get; set; }
        public DbSet<BouquetFlower> BouquetFlowers { get; set; }
        public DbSet<CustomerBouquet> CustomerBouquets { get; set; }

        public DbSet<CustomizedBouquet> CustomizedBouquets { get; set; }
        public DbSet<CustomizedBouquetFlower> CustomizedBouquetFlowers { get; set; }
        public DbSet<CustomizedBouquetFlowerColor> CustomizedBouquetFlowerColors { get; set; }
        public DbSet<CustomizedBouquetAddOn> CustomizedBouquetAddOns { get; set; }

        public DbSet<AddOn> AddOns { get; set; }
        public DbSet<Wrapping> Wrappings { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Occasion> Occasions { get; set; }
        public DbSet<EventRequest> EventRequests { get; set; }
        public DbSet<DecorationType> DecorationTypes { get; set; }
        public DbSet<EventRequestDecoration> EventRequestDecorations { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public BloomyShopDbContext(DbContextOptions<BloomyShopDbContext> options)
             : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Decimal Precision
            modelBuilder.Entity<AddOn>()
                .Property(a => a.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Bouquet>()
                .Property(b => b.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<BouquetSize>()
                .Property(bs => bs.BasePrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<EventRequest>()
                .Property(er => er.Budget)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Flower>()
                .Property(f => f.BasePrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Wrapping>()
                .Property(w => w.Price)
                .HasPrecision(18, 2);

            // BouquetSize Primary Key
            modelBuilder.Entity<BouquetSize>()
                .HasKey(bs => bs.SizeID);

            // CustomizedBouquet Primary Key
            modelBuilder.Entity<CustomizedBouquet>()
                .HasKey(cb => cb.CustomizationID);

            
 
            // Customer - Cart (1 : 1)
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Cart)
                .WithOne(c => c.Customer)
                .HasForeignKey<Cart>(c => c.CustomerID);


            // Customer - Order (1 : M)
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);


            // Customer - CustomizedBouquet (1 : M)
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.CustomizedBouquets)
                .WithOne(cb => cb.Customer)
                .HasForeignKey(cb => cb.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);


            // Customer - EventRequest (1 : M)
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.EventRequests)
                .WithOne(er => er.Customer)
                .HasForeignKey(er => er.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);


            // Customer - Bouquet (M : N)
            modelBuilder.Entity<CustomerBouquet>()
                .HasKey(cb => new { cb.CustomerID, cb.BouquetID });


            // CustomerBouquet - Customer (M : 1)
            modelBuilder.Entity<CustomerBouquet>()
                .HasOne(cb => cb.Customer)
                .WithMany(c => c.CustomerBouquets)
                .HasForeignKey(cb => cb.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);


            // CustomerBouquet - Bouquet (M : 1)
            modelBuilder.Entity<CustomerBouquet>()
                .HasOne(cb => cb.Bouquet)
                .WithMany(b => b.CustomerBouquets)
                .HasForeignKey(cb => cb.BouquetID)
                .OnDelete(DeleteBehavior.Cascade);



            // ==========================================
            // Bouquet Relationships
            // ==========================================

            // Bouquet 1 : M BouquetFlower
            modelBuilder.Entity<BouquetFlower>()
                .HasKey(bf => new { bf.BouquetID, bf.FlowerID });

            modelBuilder.Entity<BouquetFlower>()
                .HasOne(bf => bf.Bouquet)
                .WithMany(b => b.BouquetFlowers)
                .HasForeignKey(bf => bf.BouquetID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BouquetFlower>()
                .HasOne(bf => bf.Flower)
                .WithMany(f => f.BouquetFlowers)
                .HasForeignKey(bf => bf.FlowerID)
                .OnDelete(DeleteBehavior.Cascade);


            // BouquetSize 1 : M Bouquet
            modelBuilder.Entity<Bouquet>()
                .HasOne(b => b.BouquetSize)
                .WithMany(bs => bs.Bouquets)
                .HasForeignKey(b => b.SizeID)
                .OnDelete(DeleteBehavior.Restrict);


            // BouquetSize 1 : M CustomizedBouquet
            modelBuilder.Entity<CustomizedBouquet>()
                .HasOne(cb => cb.BouquetSize)
                .WithMany(bs => bs.CustomizedBouquets)
                .HasForeignKey(cb => cb.SizeID)
                .OnDelete(DeleteBehavior.Restrict);


            // Wrapping 1 : M CustomizedBouquet
            modelBuilder.Entity<CustomizedBouquet>()
                .HasOne(cb => cb.Wrapping)
                .WithMany(w => w.CustomizedBouquets)
                .HasForeignKey(cb => cb.WrappingID)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // CustomizedBouquet - Flower
            // ==========================================

            modelBuilder.Entity<CustomizedBouquetFlower>()
                .HasKey(cbf => new { cbf.CustomizationID, cbf.FlowerID });

            modelBuilder.Entity<CustomizedBouquetFlower>()
                .HasOne(cbf => cbf.CustomizedBouquet)
                .WithMany(cb => cb.CustomizedBouquetFlowers)
                .HasForeignKey(cbf => cbf.CustomizationID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CustomizedBouquetFlower>()
                .HasOne(cbf => cbf.Flower)
                .WithMany(f => f.CustomizedBouquetFlowers)
                .HasForeignKey(cbf => cbf.FlowerID)
                .OnDelete(DeleteBehavior.Cascade);


            // ==========================================
            // Flower - FlowerColor
            // ==========================================

            modelBuilder.Entity<FlowerColor>()
                .HasOne(fc => fc.Flower)
                .WithMany(f => f.FlowerColors)
                .HasForeignKey(fc => fc.FlowerID)
                .OnDelete(DeleteBehavior.Cascade);


            // ==========================================
            // CustomizedBouquet - FlowerColor
            // ==========================================

            modelBuilder.Entity<CustomizedBouquetFlowerColor>()
                .HasKey(cfc => new { cfc.CustomizationID, cfc.FlowerColorID });

            modelBuilder.Entity<CustomizedBouquetFlowerColor>()
                .HasOne(cfc => cfc.CustomizedBouquet)
                .WithMany(cb => cb.CustomizedBouquetFlowerColors)
                .HasForeignKey(cfc => cfc.CustomizationID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CustomizedBouquetFlowerColor>()
                .HasOne(cfc => cfc.FlowerColor)
                .WithMany(fc => fc.CustomizedBouquetFlowerColors)
                .HasForeignKey(cfc => cfc.FlowerColorID)
                .OnDelete(DeleteBehavior.Cascade);


            // ==========================================
            // CustomizedBouquet - AddOn
            // ==========================================

            modelBuilder.Entity<CustomizedBouquetAddOn>()
                .HasKey(ca => new { ca.CustomizationID, ca.AddOnID });

            modelBuilder.Entity<CustomizedBouquetAddOn>()
                .HasOne(ca => ca.CustomizedBouquet)
                .WithMany(cb => cb.CustomizedBouquetAddOns)
                .HasForeignKey(ca => ca.CustomizationID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CustomizedBouquetAddOn>()
                .HasOne(ca => ca.AddOn)
                .WithMany(a => a.CustomizedBouquetAddOns)
                .HasForeignKey(ca => ca.AddOnID)
                .OnDelete(DeleteBehavior.Cascade);


            // ==========================================
            // Cart Relationships
            // ==========================================

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Bouquet)
                .WithMany(b => b.CartItems)
                .HasForeignKey(ci => ci.BouquetID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.CustomizedBouquet)
                .WithMany(cb => cb.CartItems)
                .HasForeignKey(ci => ci.CustomizedBouquetID)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // Order Relationships
            // ==========================================

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Bouquet)
                .WithMany(b => b.OrderItems)
                .HasForeignKey(oi => oi.BouquetID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.CustomizedBouquet)
                .WithMany(cb => cb.OrderItems)
                .HasForeignKey(oi => oi.CustomizedBouquetID)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // EventRequest Relationships
            // ==========================================

            // Occasion 1 : M EventRequest
            modelBuilder.Entity<EventRequest>()
                .HasOne(er => er.Occasion)
                .WithMany(o => o.EventRequests)
                .HasForeignKey(er => er.OccasionID)
                .OnDelete(DeleteBehavior.Restrict);


            // Admin 1 : M EventRequest
            modelBuilder.Entity<EventRequest>()
                .HasOne(er => er.Admin)
                .WithMany(a => a.ReviewedEventRequests)
                .HasForeignKey(er => er.AdminID)
                .OnDelete(DeleteBehavior.SetNull);


            // EventRequest - DecorationType
            modelBuilder.Entity<EventRequestDecoration>()
                .HasKey(erd => new { erd.EventRequestID, erd.DecorationTypeID });

            modelBuilder.Entity<EventRequestDecoration>()
                .HasOne(erd => erd.EventRequest)
                .WithMany(er => er.EventRequestDecorations)
                .HasForeignKey(erd => erd.EventRequestID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EventRequestDecoration>()
                .HasOne(erd => erd.DecorationType)
                .WithMany(dt => dt.EventRequestDecorations)
                .HasForeignKey(erd => erd.DecorationTypeID)
                .OnDelete(DeleteBehavior.Cascade);




        }

    }
}
