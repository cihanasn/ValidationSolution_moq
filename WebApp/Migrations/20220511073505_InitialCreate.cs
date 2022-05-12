using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Age", "Name", "Surname" },
                values: new object[] { new Guid("176ebf0d-3158-4b93-a4d9-16b92bc54942"), 23, "Cihan", "ASAN" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Age", "Name", "Surname" },
                values: new object[] { new Guid("92abade5-accf-4de3-b309-0b0fb59de300"), 35, "Mike", "Anderson" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
