using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManagement.DATA.Migrations
{
    /// <inheritdoc />
    public partial class AddeClientEmailID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Clients",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Clients",
                newName: "ClientName");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Clients",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<string>(
                name: "ClientEmailId",
                table: "Clients",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientLocation",
                table: "Clients",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientEmailId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClientLocation",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Clients",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Clients",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ClientName",
                table: "Clients",
                newName: "Location");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Clients",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
