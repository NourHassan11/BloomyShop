using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantityToCustomizedBouquetFlowe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CustomizedBouquetFlowers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "CustomizedBouquetFlowers",
                keyColumns: new[] { "CustomizationID", "FlowerID" },
                keyValues: new object[] { 1, 1 },
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CustomizedBouquetFlowers",
                keyColumns: new[] { "CustomizationID", "FlowerID" },
                keyValues: new object[] { 1, 3 },
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CustomizedBouquetFlowers",
                keyColumns: new[] { "CustomizationID", "FlowerID" },
                keyValues: new object[] { 2, 2 },
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CustomizedBouquetFlowers",
                keyColumns: new[] { "CustomizationID", "FlowerID" },
                keyValues: new object[] { 2, 4 },
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CustomizedBouquetFlowers",
                keyColumns: new[] { "CustomizationID", "FlowerID" },
                keyValues: new object[] { 3, 1 },
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CustomizedBouquetFlowers",
                keyColumns: new[] { "CustomizationID", "FlowerID" },
                keyValues: new object[] { 4, 3 },
                column: "Quantity",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CustomizedBouquetFlowers");
        }
    }
}
