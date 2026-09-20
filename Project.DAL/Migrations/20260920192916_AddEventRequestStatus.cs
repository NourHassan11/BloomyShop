using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddEventRequestStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "EventRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "EventRequests",
                keyColumn: "EventRequestID",
                keyValue: 1,
                column: "Status",
                value: "Pending");

            migrationBuilder.UpdateData(
                table: "EventRequests",
                keyColumn: "EventRequestID",
                keyValue: 2,
                column: "Status",
                value: "Approved");

            migrationBuilder.UpdateData(
                table: "EventRequests",
                keyColumn: "EventRequestID",
                keyValue: 3,
                column: "Status",
                value: "Pending");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "EventRequests");
        }
    }
}
