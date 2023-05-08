using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShop.Database.Migrations
{
    public partial class CreateTableGroupProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9fe0b278-fbce-4eb5-9463-891fd8d7c61e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cc3feb7e-0dca-4237-b786-a9eabb70fb24"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d1c45428-5342-4d40-90f7-cdcda61a0c29"));

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GroupDes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NotShow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Des = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Inventory = table.Column<int>(type: "int", nullable: false),
                    SellOff = table.Column<int>(type: "int", nullable: false),
                    NotShow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "GroupDes", "GroupName", "NotShow" },
                values: new object[,]
                {
                    { 1, "خودروی خانواده", "sedan", false },
                    { 2, "خودروی اسپرت", "coupe", false },
                    { 3, "خودروی جوانان", "crossover", false }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[,]
                {
                    { new Guid("5fb70b0e-4aa7-4a7e-b08a-4795cd58295b"), "user", "کاربر" },
                    { new Guid("cfebfe75-7fd9-4728-81bd-dcddef7fb7bf"), "admin", "مدیر" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Code", "IsActive", "Mobile", "Password", "RoleId" },
                values: new object[] { new Guid("ebfbfcb5-1c3b-44de-8daa-c38ededa5c0b"), 0, true, "09112223344", "25-D5-5A-D2-83-AA-40-0A-F4-64-C7-6D-71-3C-07-AD", new Guid("cfebfe75-7fd9-4728-81bd-dcddef7fb7bf") });

            migrationBuilder.CreateIndex(
                name: "IX_Products_GroupId",
                table: "Products",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5fb70b0e-4aa7-4a7e-b08a-4795cd58295b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ebfbfcb5-1c3b-44de-8daa-c38ededa5c0b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cfebfe75-7fd9-4728-81bd-dcddef7fb7bf"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("9fe0b278-fbce-4eb5-9463-891fd8d7c61e"), "user", "کاربر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("d1c45428-5342-4d40-90f7-cdcda61a0c29"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Code", "IsActive", "Mobile", "Password", "RoleId" },
                values: new object[] { new Guid("cc3feb7e-0dca-4237-b786-a9eabb70fb24"), 0, true, "09112223344", "25-D5-5A-D2-83-AA-40-0A-F4-64-C7-6D-71-3C-07-AD", new Guid("d1c45428-5342-4d40-90f7-cdcda61a0c29") });
        }
    }
}
