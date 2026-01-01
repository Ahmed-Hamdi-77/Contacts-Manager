using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecieveNewsletter = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryName" },
                values: new object[,]
                {
                    { new Guid("7a536480-94b8-40ea-991d-6cac7ac32a86"), "UK" },
                    { new Guid("8efba64c-38da-4956-8733-dbef6ac860b2"), "Australia" },
                    { new Guid("ae6f4b3a-ec46-4e34-99e3-64a0f0d2174b"), "Canada" },
                    { new Guid("bc5c0290-49fb-423d-9440-007db6ac1363"), "USA" },
                    { new Guid("e7d45e4a-be35-4955-9e3a-53e3829df119"), "Spain" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "BirthDate", "CountryId", "Email", "Gender", "Name", "RecieveNewsletter" },
                values: new object[,]
                {
                    { new Guid("35ed84ce-7a22-4d4d-8764-069c021752b4"), "55 mhamiez st", new DateTime(2001, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ae6f4b3a-ec46-4e34-99e3-64a0f0d2174b"), "ali568505@gmail.com", "Male", "Ali", true },
                    { new Guid("4ee181a7-2845-4af6-a29a-4fb67a8f90d6"), "48 hendson st", new DateTime(2005, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8efba64c-38da-4956-8733-dbef6ac860b2"), "ma568505@gmail.com", "Female", "Marry", false },
                    { new Guid("64d3feeb-4354-4f17-85d2-d6d96aca05b7"), "155 sting st", new DateTime(2011, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e7d45e4a-be35-4955-9e3a-53e3829df119"), "na568505@gmail.com", "Female", "Nada", true },
                    { new Guid("75b85283-8384-4c78-9db1-15dd27c9927f"), "120 zodiac st", new DateTime(2010, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7a536480-94b8-40ea-991d-6cac7ac32a86"), "mo568505@gmail.com", "Male", "Mohammed", false },
                    { new Guid("8ba16644-a00a-4722-8e76-336432127180"), "135 abied st", new DateTime(2003, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bc5c0290-49fb-423d-9440-007db6ac1363"), "ah568505@gmail.com", "Male", "Ahmed", true },
                    { new Guid("bf5eef4d-3422-47cd-90c9-6ed5ad996020"), "77 Porto st", new DateTime(2002, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bc5c0290-49fb-423d-9440-007db6ac1363"), "jo568505@gmail.com", "Male", "John", true },
                    { new Guid("e8bc8b10-cd84-4f5c-8630-50bfd91430b9"), "62 mores st", new DateTime(2000, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7a536480-94b8-40ea-991d-6cac7ac32a86"), "sa568505@gmail.com", "Female", "Sara", false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
