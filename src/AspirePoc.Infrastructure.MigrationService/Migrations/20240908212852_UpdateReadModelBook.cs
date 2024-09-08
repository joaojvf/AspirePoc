using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspirePoc.Infrastructure.MigrationService.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReadModelBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("56582a7c-093d-43c0-b661-e7ff0f9bf4b7"));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("c257e1b4-ce4d-4669-a733-9a104e5522a7"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("046cea45-6fcd-4d88-9fdb-2f762fbe9691"));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("0276e42c-1f4f-4186-ac32-950c1797c85c"));
        }
    }
}
