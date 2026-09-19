using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddOns",
                columns: table => new
                {
                    AddOnID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddOns", x => x.AddOnID);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "BouquetSizes",
                columns: table => new
                {
                    SizeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BouquetSizes", x => x.SizeID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    street = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "DecorationTypes",
                columns: table => new
                {
                    DecorationTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecorationTypes", x => x.DecorationTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Flowers",
                columns: table => new
                {
                    FlowerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flowers", x => x.FlowerID);
                });

            migrationBuilder.CreateTable(
                name: "Occasions",
                columns: table => new
                {
                    OccasionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occasions", x => x.OccasionID);
                });

            migrationBuilder.CreateTable(
                name: "Wrappings",
                columns: table => new
                {
                    WrappingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wrappings", x => x.WrappingID);
                });

            migrationBuilder.CreateTable(
                name: "Bouquets",
                columns: table => new
                {
                    BouquetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreparationTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SizeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bouquets", x => x.BouquetID);
                    table.ForeignKey(
                        name: "FK_Bouquets_BouquetSizes_SizeID",
                        column: x => x.SizeID,
                        principalTable: "BouquetSizes",
                        principalColumn: "SizeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartID);
                    table.ForeignKey(
                        name: "FK_Carts_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlowerColors",
                columns: table => new
                {
                    FlowerColorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlowerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowerColors", x => x.FlowerColorID);
                    table.ForeignKey(
                        name: "FK_FlowerColors_Flowers_FlowerID",
                        column: x => x.FlowerID,
                        principalTable: "Flowers",
                        principalColumn: "FlowerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventRequests",
                columns: table => new
                {
                    EventRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfGuests = table.Column<int>(type: "int", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AdminResponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    OccasionID = table.Column<int>(type: "int", nullable: false),
                    AdminID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRequests", x => x.EventRequestID);
                    table.ForeignKey(
                        name: "FK_EventRequests_Admins_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Admins",
                        principalColumn: "AdminID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_EventRequests_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventRequests_Occasions_OccasionID",
                        column: x => x.OccasionID,
                        principalTable: "Occasions",
                        principalColumn: "OccasionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomizedBouquets",
                columns: table => new
                {
                    CustomizationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PreparationTime = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    SizeID = table.Column<int>(type: "int", nullable: false),
                    WrappingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomizedBouquets", x => x.CustomizationID);
                    table.ForeignKey(
                        name: "FK_CustomizedBouquets_BouquetSizes_SizeID",
                        column: x => x.SizeID,
                        principalTable: "BouquetSizes",
                        principalColumn: "SizeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomizedBouquets_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomizedBouquets_Wrappings_WrappingID",
                        column: x => x.WrappingID,
                        principalTable: "Wrappings",
                        principalColumn: "WrappingID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BouquetFlowers",
                columns: table => new
                {
                    BouquetID = table.Column<int>(type: "int", nullable: false),
                    FlowerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BouquetFlowers", x => new { x.BouquetID, x.FlowerID });
                    table.ForeignKey(
                        name: "FK_BouquetFlowers_Bouquets_BouquetID",
                        column: x => x.BouquetID,
                        principalTable: "Bouquets",
                        principalColumn: "BouquetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BouquetFlowers_Flowers_FlowerID",
                        column: x => x.FlowerID,
                        principalTable: "Flowers",
                        principalColumn: "FlowerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerBouquets",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    BouquetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerBouquets", x => new { x.CustomerID, x.BouquetID });
                    table.ForeignKey(
                        name: "FK_CustomerBouquets_Bouquets_BouquetID",
                        column: x => x.BouquetID,
                        principalTable: "Bouquets",
                        principalColumn: "BouquetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerBouquets_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventRequestDecorations",
                columns: table => new
                {
                    EventRequestID = table.Column<int>(type: "int", nullable: false),
                    DecorationTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRequestDecorations", x => new { x.EventRequestID, x.DecorationTypeID });
                    table.ForeignKey(
                        name: "FK_EventRequestDecorations_DecorationTypes_DecorationTypeID",
                        column: x => x.DecorationTypeID,
                        principalTable: "DecorationTypes",
                        principalColumn: "DecorationTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventRequestDecorations_EventRequests_EventRequestID",
                        column: x => x.EventRequestID,
                        principalTable: "EventRequests",
                        principalColumn: "EventRequestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CartID = table.Column<int>(type: "int", nullable: false),
                    BouquetID = table.Column<int>(type: "int", nullable: true),
                    CustomizedBouquetID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemID);
                    table.ForeignKey(
                        name: "FK_CartItems_Bouquets_BouquetID",
                        column: x => x.BouquetID,
                        principalTable: "Bouquets",
                        principalColumn: "BouquetID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartID",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "CartID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_CustomizedBouquets_CustomizedBouquetID",
                        column: x => x.CustomizedBouquetID,
                        principalTable: "CustomizedBouquets",
                        principalColumn: "CustomizationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomizedBouquetAddOns",
                columns: table => new
                {
                    CustomizationID = table.Column<int>(type: "int", nullable: false),
                    AddOnID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomizedBouquetAddOns", x => new { x.CustomizationID, x.AddOnID });
                    table.ForeignKey(
                        name: "FK_CustomizedBouquetAddOns_AddOns_AddOnID",
                        column: x => x.AddOnID,
                        principalTable: "AddOns",
                        principalColumn: "AddOnID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomizedBouquetAddOns_CustomizedBouquets_CustomizationID",
                        column: x => x.CustomizationID,
                        principalTable: "CustomizedBouquets",
                        principalColumn: "CustomizationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomizedBouquetFlowerColors",
                columns: table => new
                {
                    CustomizationID = table.Column<int>(type: "int", nullable: false),
                    FlowerColorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomizedBouquetFlowerColors", x => new { x.CustomizationID, x.FlowerColorID });
                    table.ForeignKey(
                        name: "FK_CustomizedBouquetFlowerColors_CustomizedBouquets_CustomizationID",
                        column: x => x.CustomizationID,
                        principalTable: "CustomizedBouquets",
                        principalColumn: "CustomizationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomizedBouquetFlowerColors_FlowerColors_FlowerColorID",
                        column: x => x.FlowerColorID,
                        principalTable: "FlowerColors",
                        principalColumn: "FlowerColorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomizedBouquetFlowers",
                columns: table => new
                {
                    CustomizationID = table.Column<int>(type: "int", nullable: false),
                    FlowerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomizedBouquetFlowers", x => new { x.CustomizationID, x.FlowerID });
                    table.ForeignKey(
                        name: "FK_CustomizedBouquetFlowers_CustomizedBouquets_CustomizationID",
                        column: x => x.CustomizationID,
                        principalTable: "CustomizedBouquets",
                        principalColumn: "CustomizationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomizedBouquetFlowers_Flowers_FlowerID",
                        column: x => x.FlowerID,
                        principalTable: "Flowers",
                        principalColumn: "FlowerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    BouquetID = table.Column<int>(type: "int", nullable: true),
                    CustomizedBouquetID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemID);
                    table.ForeignKey(
                        name: "FK_OrderItems_Bouquets_BouquetID",
                        column: x => x.BouquetID,
                        principalTable: "Bouquets",
                        principalColumn: "BouquetID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_CustomizedBouquets_CustomizedBouquetID",
                        column: x => x.CustomizedBouquetID,
                        principalTable: "CustomizedBouquets",
                        principalColumn: "CustomizationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BouquetFlowers_FlowerID",
                table: "BouquetFlowers",
                column: "FlowerID");

            migrationBuilder.CreateIndex(
                name: "IX_Bouquets_SizeID",
                table: "Bouquets",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_BouquetID",
                table: "CartItems",
                column: "BouquetID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartID",
                table: "CartItems",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CustomizedBouquetID",
                table: "CartItems",
                column: "CustomizedBouquetID");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CustomerID",
                table: "Carts",
                column: "CustomerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBouquets_BouquetID",
                table: "CustomerBouquets",
                column: "BouquetID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomizedBouquetAddOns_AddOnID",
                table: "CustomizedBouquetAddOns",
                column: "AddOnID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomizedBouquetFlowerColors_FlowerColorID",
                table: "CustomizedBouquetFlowerColors",
                column: "FlowerColorID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomizedBouquetFlowers_FlowerID",
                table: "CustomizedBouquetFlowers",
                column: "FlowerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomizedBouquets_CustomerID",
                table: "CustomizedBouquets",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomizedBouquets_SizeID",
                table: "CustomizedBouquets",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomizedBouquets_WrappingID",
                table: "CustomizedBouquets",
                column: "WrappingID");

            migrationBuilder.CreateIndex(
                name: "IX_EventRequestDecorations_DecorationTypeID",
                table: "EventRequestDecorations",
                column: "DecorationTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_EventRequests_AdminID",
                table: "EventRequests",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_EventRequests_CustomerID",
                table: "EventRequests",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_EventRequests_OccasionID",
                table: "EventRequests",
                column: "OccasionID");

            migrationBuilder.CreateIndex(
                name: "IX_FlowerColors_FlowerID",
                table: "FlowerColors",
                column: "FlowerID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_BouquetID",
                table: "OrderItems",
                column: "BouquetID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_CustomizedBouquetID",
                table: "OrderItems",
                column: "CustomizedBouquetID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderID",
                table: "OrderItems",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BouquetFlowers");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "CustomerBouquets");

            migrationBuilder.DropTable(
                name: "CustomizedBouquetAddOns");

            migrationBuilder.DropTable(
                name: "CustomizedBouquetFlowerColors");

            migrationBuilder.DropTable(
                name: "CustomizedBouquetFlowers");

            migrationBuilder.DropTable(
                name: "EventRequestDecorations");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "AddOns");

            migrationBuilder.DropTable(
                name: "FlowerColors");

            migrationBuilder.DropTable(
                name: "DecorationTypes");

            migrationBuilder.DropTable(
                name: "EventRequests");

            migrationBuilder.DropTable(
                name: "Bouquets");

            migrationBuilder.DropTable(
                name: "CustomizedBouquets");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Flowers");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Occasions");

            migrationBuilder.DropTable(
                name: "BouquetSizes");

            migrationBuilder.DropTable(
                name: "Wrappings");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
