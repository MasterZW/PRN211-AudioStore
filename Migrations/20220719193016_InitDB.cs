using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AudioStore.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avatars",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Thumnail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avatars", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", maxLength: 250, nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: true),
                    Delete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvatarID = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Avatars_AvatarID",
                        column: x => x.AvatarID,
                        principalTable: "Avatars",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Thumnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    CommentID = table.Column<int>(type: "int", nullable: false),
                    Stars = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Evaluates_Comments_CommentID",
                        column: x => x.CommentID,
                        principalTable: "Comments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluates_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BillMode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.ProductID, x.OrderID });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Avatars",
                columns: new[] { "ID", "Thumnail" },
                values: new object[] { 1, "https://www.cariblist.com/admin/assets/avatars/" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "LoudSpeaker" },
                    { 2, "Headphone" },
                    { 3, "Battery" },
                    { 4, "Webcam" },
                    { 5, "Mouse" },
                    { 6, "Keyboard" },
                    { 7, "Cable" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "CreateAt", "Description", "ProductDetail", "ProductName", "Price", "Stock", "Thumnail" },
                values: new object[,]
                {
                    { 3, 1, new DateTime(2022, 7, 20, 2, 30, 15, 523, DateTimeKind.Local).AddTicks(1086), "", "", "JBL Charge 5", 50.0, 58, "https://3kshop.vn/wp-content/uploads/2021/09/QNrL8MzWoEYkLptNdJngqQ.jpeg" },
                    { 4, 1, new DateTime(2022, 7, 20, 2, 30, 15, 523, DateTimeKind.Local).AddTicks(1090), "", "", "Edifier R1280DBs", 110.0, 26, "https://3kshop.vn/wp-content/uploads/2021/09/unnamed-1.jpg" },
                    { 5, 1, new DateTime(2022, 7, 20, 2, 30, 15, 523, DateTimeKind.Local).AddTicks(1093), "", "", "Marshall Emberton", 105.0, 89, "https://3kshop.vn/wp-content/uploads/2020/07/loa-marshall-Emberton-BlacknBrass.png" },
                    { 1, 2, new DateTime(2022, 7, 20, 2, 30, 15, 523, DateTimeKind.Local).AddTicks(703), "", "", "Fender Track", 175.0, 50, "https://3kshop.vn/wp-content/uploads/2022/03/3kshop-fender-track-1.jpg" },
                    { 2, 2, new DateTime(2022, 7, 20, 2, 30, 15, 523, DateTimeKind.Local).AddTicks(1081), "", "", "Jabra Elite 4 Active", 100.0, 78, "https://3kshop.vn/wp-content/uploads/2022/01/jabra-elite-active-4-1.jpg" },
                    { 6, 3, new DateTime(2022, 7, 20, 2, 30, 15, 523, DateTimeKind.Local).AddTicks(1097), "", "", "UmeTravel TRIP10C", 10.0, 100, "https://www.xtmobile.vn/vnt_upload/product/11_2020/thumbs/600_pin_du_phong_polymer_umetravel_trip10c_10000mah.jpg" },
                    { 7, 4, new DateTime(2022, 7, 20, 2, 30, 15, 523, DateTimeKind.Local).AddTicks(1101), "", "", "Webcam Logitech C925E", 100.0, 96, "https://anphat.com.vn/media/product/22508_logitech_c925_1.png" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Address", "AvatarID", "CreateAt", "Email", "Password", "PhoneNumber", "Role", "Username" },
                values: new object[] { 1, "", 1, new DateTime(2022, 7, 20, 2, 30, 15, 521, DateTimeKind.Local).AddTicks(5823), "admin@admin.com", "f6fdffe48c908deb0f4c3bd36c032e72", "0396384095", 0, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluates_CommentID",
                table: "Evaluates",
                column: "CommentID");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluates_ProductID",
                table: "Evaluates",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluates_UserId",
                table: "Evaluates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AvatarID",
                table: "Users",
                column: "AvatarID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluates");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Avatars");
        }
    }
}
