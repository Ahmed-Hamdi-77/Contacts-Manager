using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePersonNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Persons",
                newName: "PersonName");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("35ed84ce-7a22-4d4d-8764-069c021752b4"),
                column: "PersonName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("4ee181a7-2845-4af6-a29a-4fb67a8f90d6"),
                column: "PersonName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("64d3feeb-4354-4f17-85d2-d6d96aca05b7"),
                column: "PersonName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("75b85283-8384-4c78-9db1-15dd27c9927f"),
                column: "PersonName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("8ba16644-a00a-4722-8e76-336432127180"),
                column: "PersonName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("bf5eef4d-3422-47cd-90c9-6ed5ad996020"),
                column: "PersonName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("e8bc8b10-cd84-4f5c-8630-50bfd91430b9"),
                column: "PersonName",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonName",
                table: "Persons",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("35ed84ce-7a22-4d4d-8764-069c021752b4"),
                column: "Name",
                value: "Ali");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("4ee181a7-2845-4af6-a29a-4fb67a8f90d6"),
                column: "Name",
                value: "Marry");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("64d3feeb-4354-4f17-85d2-d6d96aca05b7"),
                column: "Name",
                value: "Nada");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("75b85283-8384-4c78-9db1-15dd27c9927f"),
                column: "Name",
                value: "Mohammed");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("8ba16644-a00a-4722-8e76-336432127180"),
                column: "Name",
                value: "Ahmed");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("bf5eef4d-3422-47cd-90c9-6ed5ad996020"),
                column: "Name",
                value: "John");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("e8bc8b10-cd84-4f5c-8630-50bfd91430b9"),
                column: "Name",
                value: "Sara");
        }
    }
}
