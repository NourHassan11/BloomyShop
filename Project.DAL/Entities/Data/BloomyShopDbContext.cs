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


            modelBuilder.Entity<BouquetSize>().HasData(
                new BouquetSize
                {
                    SizeID = 1,
                    Size = "Small",
                    BasePrice = 100
                 },
                 new BouquetSize
                 {
                    SizeID = 2,
                    Size = "Medium",
                    BasePrice = 200
                 },
                 new BouquetSize
                 {
                    SizeID = 3,
                    Size = "Large",
                    BasePrice = 300
                  }
                  );

            modelBuilder.Entity<Occasion>().HasData(
                 new Occasion
                 {
                    OccasionID = 1,
                    Name = "Wedding"
                 },
                new Occasion
                {
                    OccasionID = 2,
                    Name = "Birthday"
                },
                new Occasion
                {
                    OccasionID = 3,
                    Name = "Engagement"
                },
                new Occasion
                {
                    OccasionID = 4,
                    Name = "Graduation"
                }
                );

            modelBuilder.Entity<DecorationType>().HasData(
               new DecorationType
               {
                   DecorationTypeID = 1,
                   Name = "Balloon Decoration",
                   Description = "Balloon decorations for events"
               },
               new DecorationType
               {
                   DecorationTypeID = 2,
                   Name = "Table Decoration",
                   Description = "Decorations for tables and dining areas"
               },
               new DecorationType
               {
                   DecorationTypeID = 3,
                   Name = "Flower Decoration",
                   Description = "Flower arrangements for events"
               },
               new DecorationType
               {
                  DecorationTypeID = 4,
                  Name = "Wedding Decoration",
                  Description = "Special decorations for weddings"
               }
               );

            modelBuilder.Entity<Wrapping>().HasData(
                new Wrapping
                {
                    WrappingID = 1,
                    Name = "Classic",
                    Price = 50
                },
                new Wrapping
                {
                    WrappingID = 2,
                    Name = "Luxury",
                    Price = 100
                },
                new Wrapping
                {
                    WrappingID = 3,
                    Name = "Premium",
                    Price = 150
                }
            );

            modelBuilder.Entity<AddOn>().HasData(
                new AddOn
                {
                    AddOnID = 1,
                    Name = "Teddy Bear",
                    Price = 200
                },
                new AddOn
                {
                    AddOnID = 2,
                    Name = "Chocolate Box",
                    Price = 150
                },
                new AddOn
                {
                    AddOnID = 3,
                    Name = "Greeting Card",
                    Price = 50
                }
            );

            modelBuilder.Entity<Flower>().HasData(
                new Flower
                {
                    FlowerID = 1,
                    Name = "Rose",
                    BasePrice = 50,
                    Quantity = 100,
                    Image = "rose.jpg"
                },
                new Flower
                {
                    FlowerID = 2,
                    Name = "Tulip",
                    BasePrice = 40,
                    Quantity = 80,
                    Image = "tulip.jpg"
                },
                new Flower
                {
                    FlowerID = 3,
                    Name = "Lily",
                    BasePrice = 45,
                    Quantity = 70,
                    Image = "lily.jpg"
                },
                new Flower
                {
                    FlowerID = 4,
                    Name = "Sunflower",
                    BasePrice = 35,
                    Quantity = 60,
                    Image = "sunflower.jpg"
                }
            );

            modelBuilder.Entity<FlowerColor>().HasData(
                new FlowerColor
                {
                    FlowerColorID = 1,
                    Color = "Red",
                    FlowerID = 1
                },
                new FlowerColor
                {
                    FlowerColorID = 2,
                    Color = "White",
                    FlowerID = 1
                },
                new FlowerColor
                {
                    FlowerColorID = 3,
                    Color = "Pink",
                    FlowerID = 1
                },
                new FlowerColor
                {
                    FlowerColorID = 4,
                    Color = "Yellow",
                    FlowerID = 2
                },
                new FlowerColor
                {
                    FlowerColorID = 5,
                    Color = "Pink",
                    FlowerID = 2
                },
                new FlowerColor
                {
                    FlowerColorID = 6,
                    Color = "White",
                    FlowerID = 3
                },
                new FlowerColor
                {
                    FlowerColorID = 7,
                    Color = "Orange",
                    FlowerID = 4
                }
            );

            modelBuilder.Entity<Bouquet>().HasData(
                new Bouquet
                {
                    BouquetID = 1,
                    Name = "Romantic Roses",
                    Description = "A beautiful bouquet of fresh red roses.",
                    Image = "romantic-roses.jpg",
                    PreparationTime = "30 minutes",
                    Price = 300,
                    IsActive = true,
                    SizeID = 2
                },
                new Bouquet
                {
                    BouquetID = 2,
                    Name = "Spring Garden",
                    Description = "A colorful bouquet of fresh seasonal flowers.",
                    Image = "spring-garden.jpg",
                    PreparationTime = "40 minutes",
                    Price = 400,
                    IsActive = true,
                    SizeID = 3
                },
                new Bouquet
                {
                    BouquetID = 3,
                    Name = "Sunny Bouquet",
                    Description = "A cheerful bouquet featuring bright sunflowers.",
                    Image = "sunny-bouquet.jpg",
                    PreparationTime = "25 minutes",
                    Price = 250,
                    IsActive = true,
                    SizeID = 1
                },
                new Bouquet
                {
                    BouquetID = 4,
                    Name = "Elegant White",
                    Description = "An elegant bouquet of white lilies and flowers.",
                    Image = "elegant-white.jpg",
                    PreparationTime = "35 minutes",
                    Price = 350,
                    IsActive = true,
                    SizeID = 2
                }
            );

            modelBuilder.Entity<BouquetFlower>().HasData(
                new BouquetFlower
                {
                    BouquetID = 1,
                    FlowerID = 1
                },
                new BouquetFlower
                {
                    BouquetID = 2,
                    FlowerID = 2
                },
                new BouquetFlower
                {
                    BouquetID = 2,
                    FlowerID = 4
                },
                new BouquetFlower
                {
                    BouquetID = 3,
                    FlowerID = 4
                },
                new BouquetFlower
                {
                    BouquetID = 4,
                    FlowerID = 3
                },
                new BouquetFlower
                {
                    BouquetID = 4,
                    FlowerID = 1
                }
            );

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    AdminID = 1,
                    FullName = "Bloomy Admin",
                    Password = "Admin@123"
                }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerID = 1,
                    FName = "Noor",
                    Lname = "Hassan",
                    FullName = "Noor Hassan",
                    Email = "noor@example.com",
                    Password = "Customer@123",
                    Phone = "01000000001",
                    City = "Damietta",
                    street = "Main Street"
                },
                new Customer
                {
                    CustomerID = 2,
                    FName = "Sara",
                    Lname = "Ahmed",
                    FullName = "Sara Ahmed",
                    Email = "sara@example.com",
                    Password = "Customer@123",
                    Phone = "01000000002",
                    City = "Cairo",
                    street = "Nile Street"
                },
            new Customer
            {
                CustomerID = 3,
                FName = "Mariam",
                Lname = "Ali",
                FullName = "Mariam Ali",
                Email = "mariam@example.com",
                Password = "Customer@123",
                Phone = "01000000003",
                City = "Alexandria",
                street = "Corniche Street"
            },
            new Customer
            {
                CustomerID = 4,
                FName = "Omar",
                Lname = "Mohamed",
                FullName = "Omar Mohamed",
                Email = "omar@example.com",
                Password = "Customer@123",
                Phone = "01000000004",
                City = "Mansoura",
                street = "University Street"
            }
            );

            modelBuilder.Entity<CustomerBouquet>().HasData(
                new CustomerBouquet
                {
                    CustomerID = 1,
                    BouquetID = 1
                },
                new CustomerBouquet
                {
                    CustomerID = 1,
                    BouquetID = 3
                },
                new CustomerBouquet
                {
                    CustomerID = 2,
                    BouquetID = 2
                },
                new CustomerBouquet
                {
                    CustomerID = 3,
                    BouquetID = 4
                },
                new CustomerBouquet
                {
                    CustomerID = 4,
                    BouquetID = 1
                },
                new CustomerBouquet
                {
                    CustomerID = 4,
                    BouquetID = 2
                }
            );

            modelBuilder.Entity<CustomizedBouquet>().HasData(
                new CustomizedBouquet
                {
                    CustomizationID = 1,
                    CreatedAt = new DateTime(2026, 1, 10),
                    PreparationTime = 45,
                    CustomerID = 1,
                    SizeID = 2,
                    WrappingID = 1
                },
                new CustomizedBouquet
                {
                    CustomizationID = 2,
                    CreatedAt = new DateTime(2026, 1, 12),
                    PreparationTime = 60,
                    CustomerID = 2,
                    SizeID = 3,
                    WrappingID = 2
                },
                new CustomizedBouquet
                {
                    CustomizationID = 3,
                    CreatedAt = new DateTime(2026, 1, 15),
                    PreparationTime = 30,
                    CustomerID = 3,
                    SizeID = 1,
                    WrappingID = 3
                },
                new CustomizedBouquet
                {
                    CustomizationID = 4,
                    CreatedAt = new DateTime(2026, 1, 18),
                    PreparationTime = 50,
                    CustomerID = 4,
                    SizeID = 2,
                    WrappingID = 1
                }
            );

            modelBuilder.Entity<CustomizedBouquetFlower>().HasData(
                new CustomizedBouquetFlower
                {
                    CustomizationID = 1,
                    FlowerID = 1
                },
                new CustomizedBouquetFlower
                {
                    CustomizationID = 1,
                    FlowerID = 3
                },
                new CustomizedBouquetFlower
                {
                    CustomizationID = 2,
                    FlowerID = 2
                },
                new CustomizedBouquetFlower
                {
                    CustomizationID = 2,
                    FlowerID = 4
                },
                new CustomizedBouquetFlower
                {
                    CustomizationID = 3,
                    FlowerID = 1
                },
                new CustomizedBouquetFlower
                {
                    CustomizationID = 4,
                    FlowerID = 3
                }
            );

            modelBuilder.Entity<CustomizedBouquetFlowerColor>().HasData(
                new CustomizedBouquetFlowerColor
                {
                    CustomizationID = 1,
                    FlowerColorID = 1
                },
                new CustomizedBouquetFlowerColor
                {
                    CustomizationID = 1,
                    FlowerColorID = 6
                },
                new CustomizedBouquetFlowerColor
                {
                    CustomizationID = 2,
                    FlowerColorID = 5
                },
                new CustomizedBouquetFlowerColor
                {
                    CustomizationID = 2,
                    FlowerColorID = 7
                },
                new CustomizedBouquetFlowerColor
                {
                    CustomizationID = 3,
                    FlowerColorID = 3
                },
                new CustomizedBouquetFlowerColor
                {
                    CustomizationID = 4,
                    FlowerColorID = 2
                }
            );

            modelBuilder.Entity<CustomizedBouquetAddOn>().HasData(
                new CustomizedBouquetAddOn
                {
                    CustomizationID = 1,
                    AddOnID = 1
                },
                new CustomizedBouquetAddOn
                {
                    CustomizationID = 1,
                    AddOnID = 3
                },
                new CustomizedBouquetAddOn
                {
                    CustomizationID = 2,
                    AddOnID = 2
                },
                new CustomizedBouquetAddOn
                {
                    CustomizationID = 3,
                    AddOnID = 3
                },
                new CustomizedBouquetAddOn
                {
                    CustomizationID = 4,
                    AddOnID = 1
                },
                new CustomizedBouquetAddOn
                {
                    CustomizationID = 4,
                    AddOnID = 2
                }
            );

            modelBuilder.Entity<Cart>().HasData(
                new Cart
                {
                    CartID = 1,
                    CreatedAt = new DateTime(2026, 1, 10),
                    CustomerID = 1
                },
                new Cart
                {
                    CartID = 2,
                    CreatedAt = new DateTime(2026, 1, 12),
                    CustomerID = 2
                },
                new Cart
                {
                    CartID = 3,
                    CreatedAt = new DateTime(2026, 1, 15),
                    CustomerID = 3
                },
                new Cart
                {
                    CartID = 4,
                    CreatedAt = new DateTime(2026, 1, 18),
                    CustomerID = 4
                }
            );


            modelBuilder.Entity<CartItem>().HasData(
                new CartItem
                {
                    CartItemID = 1,
                    Quantity = 2,
                    UnitPrice = 300,
                    CartID = 1,
                    BouquetID = 1,
                    CustomizedBouquetID = null
                },
                new CartItem
                {
                    CartItemID = 2,
                    Quantity = 1,
                    UnitPrice = 250,
                    CartID = 2,
                    BouquetID = 3,
                    CustomizedBouquetID = null
                },
                new CartItem
                {
                    CartItemID = 3,
                    Quantity = 1,
                    UnitPrice = 0,
                    CartID = 3,
                    BouquetID = null,
                    CustomizedBouquetID = 3
                },
                new CartItem
                {
                    CartItemID = 4,
                    Quantity = 1,
                    UnitPrice = 0,
                    CartID = 4,
                    BouquetID = null,
                    CustomizedBouquetID = 4
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderID = 1,
                    OrderDate = new DateTime(2026, 1, 20),
                    Status = "Pending",
                    TotalPrice = 600,
                    DeliveryAddress = "Main Street, Damietta",
                    CustomerID = 1
                },
                new Order
                {
                    OrderID = 2,
                    OrderDate = new DateTime(2026, 1, 22),
                    Status = "Confirmed",
                    TotalPrice = 250,
                    DeliveryAddress = "Nile Street, Cairo",
                    CustomerID = 2
                },
                new Order
                {
                    OrderID = 3,
                    OrderDate = new DateTime(2026, 1, 25),
                    Status = "Delivered",
                    TotalPrice = 350,
                    DeliveryAddress = "Corniche Street, Alexandria",
                    CustomerID = 3
                },
                new Order
                {
                    OrderID = 4,
                    OrderDate = new DateTime(2026, 1, 28),
                    Status = "Pending",
                    TotalPrice = 400,
                    DeliveryAddress = "University Street, Mansoura",
                    CustomerID = 4
                }
            );

            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    OrderItemID = 1,
                    Quantity = 2,
                    UnitPrice = 300,
                    OrderID = 1,
                    BouquetID = 1,
                    CustomizedBouquetID = null
                },
                new OrderItem
                {
                    OrderItemID = 2,
                    Quantity = 1,
                    UnitPrice = 250,
                    OrderID = 2,
                    BouquetID = 3,
                    CustomizedBouquetID = null
                },
                new OrderItem
                {
                    OrderItemID = 3,
                    Quantity = 1,
                    UnitPrice = 350,
                    OrderID = 3,
                    BouquetID = null,
                    CustomizedBouquetID = 3
                },
                new OrderItem
                {
                    OrderItemID = 4,
                    Quantity = 1,
                    UnitPrice = 400,
                    OrderID = 4,
                    BouquetID = 2,
                    CustomizedBouquetID = null
                }
            );

            modelBuilder.Entity<EventRequest>().HasData(
                new EventRequest
                {
                    EventRequestID = 1,
                    LocationType = "Indoor",
                    NumberOfGuests = 50,
                    EventDate = new DateTime(2026, 2, 14),
                    Theme = "Romantic",
                    Budget = 5000,
                    AdminResponse = "Request received and under review.",
                    Status = "Pending",
                    CustomerID = 1,
                    OccasionID = 1,
                    AdminID = 1
                },
                new EventRequest
                {
                    EventRequestID = 2,
                    LocationType = "Outdoor",
                    NumberOfGuests = 100,
                    EventDate = new DateTime(2026, 3, 20),
                    Theme = "Elegant Garden",
                    Budget = 10000,
                    AdminResponse = "Request approved.",
                    Status = "Approved",
                    CustomerID = 2,
                    OccasionID = 2,
                    AdminID = 1
                },
                new EventRequest
                {
                    EventRequestID = 3,
                    LocationType = "Indoor",
                    NumberOfGuests = 30,
                    EventDate = new DateTime(2026, 4, 5),
                    Theme = "Simple and Elegant",
                    Budget = 3000,
                    AdminResponse = null,
                    Status = "Pending",
                    CustomerID = 3,
                    OccasionID = 3,
                    AdminID = null
                }
            );

            modelBuilder.Entity<EventRequestDecoration>().HasData(
                new EventRequestDecoration
                {
                    EventRequestID = 1,
                    DecorationTypeID = 1
                },
                new EventRequestDecoration
                {
                    EventRequestID = 1,
                    DecorationTypeID = 2
                },
                new EventRequestDecoration
                {
                    EventRequestID = 2,
                    DecorationTypeID = 3
                },
                new EventRequestDecoration
                {
                    EventRequestID = 2,
                    DecorationTypeID = 4
                },
                new EventRequestDecoration
                {
                    EventRequestID = 3,
                    DecorationTypeID = 1
                }
            );


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
