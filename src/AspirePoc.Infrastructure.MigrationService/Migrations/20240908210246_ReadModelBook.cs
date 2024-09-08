using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspirePoc.Infrastructure.MigrationService.Migrations
{
    /// <inheritdoc />
    public partial class ReadModelBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Books_Read",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerializedObject = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books_Read", x => x.Guid);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Books_Guid",
                table: "Books",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_Read_Id",
                table: "Books_Read",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books_Read");

            migrationBuilder.DropIndex(
                name: "IX_Books_Guid",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Books");
        }
    }
}
