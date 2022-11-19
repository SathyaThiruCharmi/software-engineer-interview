using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zip.InstallmentService.Api.Migrations
{
    public partial class AddKeysnew1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installment_PaymentPlan_PaymentPlanId",
                table: "Installment");

            migrationBuilder.DropIndex(
                name: "IX_Installment_PaymentPlanId",
                table: "Installment");

            migrationBuilder.DropColumn(
                name: "PaymentPlanId",
                table: "Installment");

            migrationBuilder.AddForeignKey(
                name: "FK_Installment_PaymentPlan_Id",
                table: "Installment",
                column: "Id",
                principalTable: "PaymentPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installment_PaymentPlan_Id",
                table: "Installment");

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentPlanId",
                table: "Installment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Installment_PaymentPlanId",
                table: "Installment",
                column: "PaymentPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Installment_PaymentPlan_PaymentPlanId",
                table: "Installment",
                column: "PaymentPlanId",
                principalTable: "PaymentPlan",
                principalColumn: "Id");
        }
    }
}
