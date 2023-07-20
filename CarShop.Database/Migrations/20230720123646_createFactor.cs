using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShop.Database.Migrations
{
    public partial class createFactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f98e3b72-79af-4a07-b582-529b8859996e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ff1e6bcd-2a03-48ce-bf21-bacbdc3cf066"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f07d8136-e9fe-49f9-8536-416082f89c4b"));

            migrationBuilder.CreateTable(
                name: "Factors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OpenDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CloseDateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPay = table.Column<bool>(type: "bit", nullable: false),
                    PayInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Des = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactorDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DetailCount = table.Column<int>(type: "int", nullable: false),
                    DetailPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactorDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactorDetails_Factors_FactorId",
                        column: x => x.FactorId,
                        principalTable: "Factors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactorDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("258ec6a1-4e19-4939-958a-37a908a9c7cd"), "user", "کاربر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("3c3f1472-214a-4d9b-83a7-e9fe8d2bce60"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Code", "IsActive", "Mobile", "Password", "RoleId" },
                values: new object[] { new Guid("d547d7c0-a849-41ba-8adb-28c3a913cfb4"), 0, true, "09112223344", "99-21-64-DB-BF-B2-7F-38-0F-66-DF-8A-72-43-42-33", new Guid("3c3f1472-214a-4d9b-83a7-e9fe8d2bce60") });

            migrationBuilder.CreateIndex(
                name: "IX_FactorDetails_FactorId",
                table: "FactorDetails",
                column: "FactorId");

            migrationBuilder.CreateIndex(
                name: "IX_FactorDetails_ProductId",
                table: "FactorDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Factors_UserId",
                table: "Factors",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactorDetails");

            migrationBuilder.DropTable(
                name: "Factors");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("258ec6a1-4e19-4939-958a-37a908a9c7cd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d547d7c0-a849-41ba-8adb-28c3a913cfb4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3c3f1472-214a-4d9b-83a7-e9fe8d2bce60"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("f07d8136-e9fe-49f9-8536-416082f89c4b"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("f98e3b72-79af-4a07-b582-529b8859996e"), "user", "کاربر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Code", "IsActive", "Mobile", "Password", "RoleId" },
                values: new object[] { new Guid("ff1e6bcd-2a03-48ce-bf21-bacbdc3cf066"), 0, true, "09112223344", "25-D5-5A-D2-83-AA-40-0A-F4-64-C7-6D-71-3C-07-AD", new Guid("f07d8136-e9fe-49f9-8536-416082f89c4b") });
        }
    }
}
