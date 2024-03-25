using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinServer.Migrations
{
    /// <inheritdoc />
    public partial class PersonHistoryTransferAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonMoneys_Persons_PersonId",
                table: "PersonMoneys");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "PersonMoneys",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                table: "PersonMoneys",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "HistoryTransfers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RecipientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    MoneyTransfer = table.Column<double>(type: "float", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OperationType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryTransfers_Persons_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoryTransfers_Persons_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryTransfers_RecipientId",
                table: "HistoryTransfers",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryTransfers_SenderId",
                table: "HistoryTransfers",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonMoneys_Persons_PersonId",
                table: "PersonMoneys",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonMoneys_Persons_PersonId",
                table: "PersonMoneys");

            migrationBuilder.DropTable(
                name: "HistoryTransfers");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "PersonMoneys",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                table: "PersonMoneys",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonMoneys_Persons_PersonId",
                table: "PersonMoneys",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
