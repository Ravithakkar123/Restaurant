using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    CustomerNum = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CustomerPinCode = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "FoodItem",
                columns: table => new
                {
                    FoodItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodItemName = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    FoodItemInfo = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    FoodItemPrice = table.Column<string>(type: "nvarchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItem", x => x.FoodItemId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNo = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    TotalAmount = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    PaymentId = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    CardOwnerName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    Exp = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    FoodItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_FoodItem_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItem",
                        principalColumn: "FoodItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_FoodItemId",
                table: "Order",
                column: "FoodItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "FoodItem");
        }
    }
}
