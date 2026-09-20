using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AddOns",
                columns: new[] { "AddOnID", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Teddy Bear", 200m },
                    { 2, "Chocolate Box", 150m },
                    { 3, "Greeting Card", 50m }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminID", "FullName", "Password" },
                values: new object[] { 1, "Bloomy Admin", "Admin@123" });

            migrationBuilder.InsertData(
                table: "BouquetSizes",
                columns: new[] { "SizeID", "BasePrice", "Size" },
                values: new object[,]
                {
                    { 1, 100m, "Small" },
                    { 2, 200m, "Medium" },
                    { 3, 300m, "Large" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "City", "Email", "FName", "FullName", "Lname", "Password", "Phone", "street" },
                values: new object[,]
                {
                    { 1, "Damietta", "noor@example.com", "Noor", "Noor Hassan", "Hassan", "Customer@123", "01000000001", "Main Street" },
                    { 2, "Cairo", "sara@example.com", "Sara", "Sara Ahmed", "Ahmed", "Customer@123", "01000000002", "Nile Street" },
                    { 3, "Alexandria", "mariam@example.com", "Mariam", "Mariam Ali", "Ali", "Customer@123", "01000000003", "Corniche Street" },
                    { 4, "Mansoura", "omar@example.com", "Omar", "Omar Mohamed", "Mohamed", "Customer@123", "01000000004", "University Street" }
                });

            migrationBuilder.InsertData(
                table: "DecorationTypes",
                columns: new[] { "DecorationTypeID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Balloon decorations for events", "Balloon Decoration" },
                    { 2, "Decorations for tables and dining areas", "Table Decoration" },
                    { 3, "Flower arrangements for events", "Flower Decoration" },
                    { 4, "Special decorations for weddings", "Wedding Decoration" }
                });

            migrationBuilder.InsertData(
                table: "Flowers",
                columns: new[] { "FlowerID", "BasePrice", "Image", "Name", "Quantity" },
                values: new object[,]
                {
                    { 1, 50m, "rose.jpg", "Rose", 100 },
                    { 2, 40m, "tulip.jpg", "Tulip", 80 },
                    { 3, 45m, "lily.jpg", "Lily", 70 },
                    { 4, 35m, "sunflower.jpg", "Sunflower", 60 }
                });

            migrationBuilder.InsertData(
                table: "Occasions",
                columns: new[] { "OccasionID", "Name" },
                values: new object[,]
                {
                    { 1, "Wedding" },
                    { 2, "Birthday" },
                    { 3, "Engagement" },
                    { 4, "Graduation" }
                });

            migrationBuilder.InsertData(
                table: "Wrappings",
                columns: new[] { "WrappingID", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Classic", 50m },
                    { 2, "Luxury", 100m },
                    { 3, "Premium", 150m }
                });

            migrationBuilder.InsertData(
                table: "Bouquets",
                columns: new[] { "BouquetID", "Description", "Image", "IsActive", "Name", "PreparationTime", "Price", "SizeID" },
                values: new object[,]
                {
                    { 1, "A beautiful bouquet of fresh red roses.", "romantic-roses.jpg", true, "Romantic Roses", "30 minutes", 300m, 2 },
                    { 2, "A colorful bouquet of fresh seasonal flowers.", "spring-garden.jpg", true, "Spring Garden", "40 minutes", 400m, 3 },
                    { 3, "A cheerful bouquet featuring bright sunflowers.", "sunny-bouquet.jpg", true, "Sunny Bouquet", "25 minutes", 250m, 1 },
                    { 4, "An elegant bouquet of white lilies and flowers.", "elegant-white.jpg", true, "Elegant White", "35 minutes", 350m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "CartID", "CreatedAt", "CustomerID" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2026, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 }
                });

            migrationBuilder.InsertData(
                table: "CustomizedBouquets",
                columns: new[] { "CustomizationID", "CreatedAt", "CustomerID", "PreparationTime", "SizeID", "WrappingID" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 45, 2, 1 },
                    { 2, new DateTime(2026, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 60, 3, 2 },
                    { 3, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 30, 1, 3 },
                    { 4, new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 50, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "EventRequests",
                columns: new[] { "EventRequestID", "AdminID", "AdminResponse", "Budget", "CustomerID", "EventDate", "LocationType", "NumberOfGuests", "OccasionID", "Theme" },
                values: new object[,]
                {
                    { 1, 1, "Request received and under review.", 5000m, 1, new DateTime(2026, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indoor", 50, 1, "Romantic" },
                    { 2, 1, "Request approved.", 10000m, 2, new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Outdoor", 100, 2, "Elegant Garden" },
                    { 3, null, null, 3000m, 3, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indoor", 30, 3, "Simple and Elegant" }
                });

            migrationBuilder.InsertData(
                table: "FlowerColors",
                columns: new[] { "FlowerColorID", "Color", "FlowerID" },
                values: new object[,]
                {
                    { 1, "Red", 1 },
                    { 2, "White", 1 },
                    { 3, "Pink", 1 },
                    { 4, "Yellow", 2 },
                    { 5, "Pink", 2 },
                    { 6, "White", 3 },
                    { 7, "Orange", 4 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "CustomerID", "DeliveryAddress", "OrderDate", "Status", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 1, "Main Street, Damietta", new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 600m },
                    { 2, 2, "Nile Street, Cairo", new DateTime(2026, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed", 250m },
                    { 3, 3, "Corniche Street, Alexandria", new DateTime(2026, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 350m },
                    { 4, 4, "University Street, Mansoura", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 400m }
                });

            migrationBuilder.InsertData(
                table: "BouquetFlowers",
                columns: new[] { "BouquetID", "FlowerID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 4 },
                    { 3, 4 },
                    { 4, 1 },
                    { 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "CartItemID", "BouquetID", "CartID", "CustomizedBouquetID", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, null, 2, 300m },
                    { 2, 3, 2, null, 1, 250m },
                    { 3, null, 3, 3, 1, 0m },
                    { 4, null, 4, 4, 1, 0m }
                });

            migrationBuilder.InsertData(
                table: "CustomerBouquets",
                columns: new[] { "BouquetID", "CustomerID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 2, 2 },
                    { 4, 3 },
                    { 1, 4 },
                    { 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "CustomizedBouquetAddOns",
                columns: new[] { "AddOnID", "CustomizationID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 1, 4 },
                    { 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "CustomizedBouquetFlowerColors",
                columns: new[] { "CustomizationID", "FlowerColorID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 6 },
                    { 2, 5 },
                    { 2, 7 },
                    { 3, 3 },
                    { 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "CustomizedBouquetFlowers",
                columns: new[] { "CustomizationID", "FlowerID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 2 },
                    { 2, 4 },
                    { 3, 1 },
                    { 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "EventRequestDecorations",
                columns: new[] { "DecorationTypeID", "EventRequestID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 2 },
                    { 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemID", "BouquetID", "CustomizedBouquetID", "OrderID", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, null, 1, 2, 300m },
                    { 2, 3, null, 2, 1, 250m },
                    { 3, null, 3, 3, 1, 350m },
                    { 4, 2, null, 4, 1, 400m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BouquetFlowers",
                keyColumns: new[] { "BouquetID", "FlowerID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "BouquetFlowers",
                keyColumns: new[] { "BouquetID", "FlowerID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "BouquetFlowers",
                keyColumns: new[] { "BouquetID", "FlowerID" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "BouquetFlowers",
                keyColumns: new[] { "BouquetID", "FlowerID" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "BouquetFlowers",
                keyColumns: new[] { "BouquetID", "FlowerID" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "BouquetFlowers",
                keyColumns: new[] { "BouquetID", "FlowerID" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "CartItemID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "CartItemID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "CartItemID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "CartItemID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CustomerBouquets",
                keyColumns: new[] { "BouquetID", "CustomerID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CustomerBouquets",
                keyColumns: new[] { "BouquetID", "CustomerID" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CustomerBouquets",
                keyColumns: new[] { "BouquetID", "CustomerID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CustomerBouquets",
                keyColumns: new[] { "BouquetID", "CustomerID" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "CustomerBouquets",
                keyColumns: new[] { "BouquetID", "CustomerID" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "CustomerBouquets",
                keyColumns: new[] { "BouquetID", "CustomerID" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "CustomizedBouquetAddOns",
                keyColumns: new[] { "AddOnID", "CustomizationID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CustomizedBouquetAddOns",
                keyColumns: new[] { "AddOnID", "CustomizationID" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CustomizedBouquetAddOns",
                keyColumns: new[] { "AddOnID", "CustomizationID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CustomizedBouquetAddOns",
                keyColumns: new[] { "AddOnID", "CustomizationID" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "CustomizedBouquetAddOns",
                keyColumns: new[] { "AddOnID", "CustomizationID" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "CustomizedBouquetAddOns",
                keyColumns: new[] { "AddOnID", "CustomizationID" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "CustomizedBouquetFlowerColors",
                keyColumns: new[] { "CustomizationID", "FlowerColorID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CustomizedBouquetFlowerColors",
                keyColumns: new[] { "CustomizationID", "FlowerColorID" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "CustomizedBouquetFlowerColors",
                keyColumns: new[] { "CustomizationID", "FlowerColorID" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "CustomizedBouquetFlowerColors",
                keyColumns: new[] { "CustomizationID", "FlowerColorID" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "CustomizedBouquetFlowerColors",
                keyColumns: new[] { "CustomizationID", "FlowerColorID" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "CustomizedBouquetFlowerColors",
                keyColumns: new[] { "CustomizationID", "FlowerColorID" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "CustomizedBouquetFlowers",
                keyColumns: new[] { "CustomizationID", "FlowerID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CustomizedBouquetFlowers",
                keyColumns: new[] { "CustomizationID", "FlowerID" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CustomizedBouquetFlowers",
                keyColumns: new[] { "CustomizationID", "FlowerID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CustomizedBouquetFlowers",
                keyColumns: new[] { "CustomizationID", "FlowerID" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "CustomizedBouquetFlowers",
                keyColumns: new[] { "CustomizationID", "FlowerID" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CustomizedBouquetFlowers",
                keyColumns: new[] { "CustomizationID", "FlowerID" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "EventRequestDecorations",
                keyColumns: new[] { "DecorationTypeID", "EventRequestID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EventRequestDecorations",
                keyColumns: new[] { "DecorationTypeID", "EventRequestID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "EventRequestDecorations",
                keyColumns: new[] { "DecorationTypeID", "EventRequestID" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "EventRequestDecorations",
                keyColumns: new[] { "DecorationTypeID", "EventRequestID" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "EventRequestDecorations",
                keyColumns: new[] { "DecorationTypeID", "EventRequestID" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "FlowerColors",
                keyColumn: "FlowerColorID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Occasions",
                keyColumn: "OccasionID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AddOns",
                keyColumn: "AddOnID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AddOns",
                keyColumn: "AddOnID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AddOns",
                keyColumn: "AddOnID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bouquets",
                keyColumn: "BouquetID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bouquets",
                keyColumn: "BouquetID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bouquets",
                keyColumn: "BouquetID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bouquets",
                keyColumn: "BouquetID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "CartID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "CartID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "CartID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "CartID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CustomizedBouquets",
                keyColumn: "CustomizationID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CustomizedBouquets",
                keyColumn: "CustomizationID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CustomizedBouquets",
                keyColumn: "CustomizationID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CustomizedBouquets",
                keyColumn: "CustomizationID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DecorationTypes",
                keyColumn: "DecorationTypeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DecorationTypes",
                keyColumn: "DecorationTypeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DecorationTypes",
                keyColumn: "DecorationTypeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DecorationTypes",
                keyColumn: "DecorationTypeID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EventRequests",
                keyColumn: "EventRequestID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EventRequests",
                keyColumn: "EventRequestID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EventRequests",
                keyColumn: "EventRequestID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FlowerColors",
                keyColumn: "FlowerColorID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FlowerColors",
                keyColumn: "FlowerColorID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FlowerColors",
                keyColumn: "FlowerColorID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FlowerColors",
                keyColumn: "FlowerColorID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FlowerColors",
                keyColumn: "FlowerColorID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FlowerColors",
                keyColumn: "FlowerColorID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "AdminID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BouquetSizes",
                keyColumn: "SizeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BouquetSizes",
                keyColumn: "SizeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BouquetSizes",
                keyColumn: "SizeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "FlowerID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "FlowerID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "FlowerID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "FlowerID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Occasions",
                keyColumn: "OccasionID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Occasions",
                keyColumn: "OccasionID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Occasions",
                keyColumn: "OccasionID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Wrappings",
                keyColumn: "WrappingID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Wrappings",
                keyColumn: "WrappingID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Wrappings",
                keyColumn: "WrappingID",
                keyValue: 3);
        }
    }
}
