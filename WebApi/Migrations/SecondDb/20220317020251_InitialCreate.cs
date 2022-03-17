using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations.SecondDb
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CreateUser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdateUser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "City", "CreateDate", "CreateUser", "Email", "FirstName", "LastName", "LastUpdate", "LastUpdateUser", "PhoneNumber" },
                values: new object[] { 1, "İstanbul", new DateTime(2022, 3, 17, 5, 2, 50, 530, DateTimeKind.Local).AddTicks(500), "Admin", "ahmet.gunduz@xyz.com", "Ahmet", "Gündüz", new DateTime(2022, 3, 17, 5, 2, 50, 546, DateTimeKind.Local).AddTicks(1970), "Admin", "123548" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "City", "CreateDate", "CreateUser", "Email", "FirstName", "LastName", "LastUpdate", "LastUpdateUser", "PhoneNumber" },
                values: new object[] { 2, "Ankara", new DateTime(2022, 3, 17, 5, 2, 50, 546, DateTimeKind.Local).AddTicks(9900), "Admin", "mustafa.yilmaz@xyz.com", "Mustafa", "Yılmaz", new DateTime(2022, 3, 17, 5, 2, 50, 547, DateTimeKind.Local).AddTicks(160), "Admin", "2322323" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "City", "CreateDate", "CreateUser", "Email", "FirstName", "LastName", "LastUpdate", "LastUpdateUser", "PhoneNumber" },
                values: new object[] { 3, "İzmir", new DateTime(2022, 3, 17, 5, 2, 50, 547, DateTimeKind.Local).AddTicks(990), "Admin", "mehmet.gunes@xyz.com", "Mehmet", "Güneş", new DateTime(2022, 3, 17, 5, 2, 50, 547, DateTimeKind.Local).AddTicks(1000), "Admin", "2323" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
