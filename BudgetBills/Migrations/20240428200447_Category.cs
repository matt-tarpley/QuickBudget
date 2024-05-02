using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BudgetBills.Migrations
{
    /// <inheritdoc />
    public partial class Category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "BillId",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "BillId",
                keyValue: 2,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "BillId",
                keyValue: 3,
                column: "CategoryId",
                value: 2);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description1", "Description2" },
                values: new object[,]
                {
                    { 1, "Housing/Utilities", "Needs" },
                    { 2, "Transportation", "Needs" },
                    { 3, "Subscriptions", "Wants" },
                    { 4, "Pets", "Needs" },
                    { 6, "Medical", "Needs" },
                    { 7, "Personal", "Wants" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CategoryId",
                table: "Bills",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Categories_CategoryId",
                table: "Bills",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Categories_CategoryId",
                table: "Bills");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Bills_CategoryId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Bills");
        }
    }
}
