using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zip.InstallmentService.Api.Migrations
{
    public partial class AddKeysnew111345 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InstallmentId",
                table: "Installment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstallmentId",
                table: "Installment");
        }
    }
}
