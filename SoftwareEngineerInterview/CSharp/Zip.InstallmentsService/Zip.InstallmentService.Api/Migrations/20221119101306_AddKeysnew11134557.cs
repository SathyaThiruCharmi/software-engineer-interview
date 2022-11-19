using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zip.InstallmentService.Api.Migrations
{
    public partial class AddKeysnew11134557 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstallmentId",
                table: "Installment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InstallmentId",
                table: "Installment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
