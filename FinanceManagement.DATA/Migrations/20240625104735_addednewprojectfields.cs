using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManagement.DATA.Migrations
{
    /// <inheritdoc />
    public partial class addednewprojectfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Clients_ClientId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ClientId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Projects",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "TeamMembersCount",
                table: "Projects",
                newName: "TeamSize");

            migrationBuilder.RenameColumn(
                name: "ProjectReferenceId",
                table: "Projects",
                newName: "ProjectType");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Projects",
                newName: "ProjectRefId");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Projects",
                newName: "CreatedDate");

            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "Projects",
                type: "text",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "Projects",
                type: "text",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientEmail",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Progress",
                table: "Projects",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProjectID",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectManager",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "Projects",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientEmail",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Progress",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectManager",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Projects",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "TeamSize",
                table: "Projects",
                newName: "TeamMembersCount");

            migrationBuilder.RenameColumn(
                name: "ProjectType",
                table: "Projects",
                newName: "ProjectReferenceId");

            migrationBuilder.RenameColumn(
                name: "ProjectRefId",
                table: "Projects",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Projects",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Projects",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Projects",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Projects",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId",
                table: "Projects",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Clients_ClientId",
                table: "Projects",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
