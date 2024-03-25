using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinServer.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumsPersonDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAdress",
                table: "Persons",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Persons",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Persons",
                newName: "EmailAdress");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Persons",
                newName: "Adress");
        }
    }
}
